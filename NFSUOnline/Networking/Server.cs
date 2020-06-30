using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using NFSUOnline.Packets;

namespace NFSUOnline.Networking
{
    public class Server
    {
        private static ManualResetEvent allDone = new ManualResetEvent(false);

        public void startListening(string ipAddress, int port)
        {
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                listener.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.DontLinger, true);
                listener.Bind(new IPEndPoint(IPAddress.Parse(ipAddress), port));
                listener.Listen(100);

                Console.WriteLine("NFSU: Online is now listening on {0}:{1}", ipAddress, port);

                while (true)
                {
                    allDone.Reset();

                    listener.BeginAccept(acceptCallback, listener);

                    allDone.WaitOne();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Environment.Exit(1);
            }
        }

        private static void acceptCallback(IAsyncResult ar)
        {
            allDone.Set();

            Socket listener = (Socket) ar.AsyncState;
            Socket handler = listener.EndAccept(ar);

            Player client = new Player();
            client.workSocket = handler;

            handler.BeginReceive(client.buffer, 0, Player.bufferSize, 0, readCallback, client);
        }

        private static void readCallback(IAsyncResult ar)
        {
            Player client = (Player) ar.AsyncState;

            Socket handler = client.workSocket;

            int bytesRead = handler.EndReceive(ar);

            if (bytesRead > 0)
            {
                byte[] tempBuffer = new byte[bytesRead];

                Array.Copy(client.buffer, tempBuffer, tempBuffer.Length);

                client.process(tempBuffer);

                handler.BeginReceive(client.buffer, 0, Player.bufferSize, 0, readCallback, client);
            }
        }

        public void sendPacket(Player player, Packet packet)
        {
            packet.encode();
            packet.process();

            byte[] byteData = packet.data.ToArray();

            player.workSocket.BeginSend(byteData, 0, byteData.Length, 0, sendCallback, player);
        }

        private static void sendCallback(IAsyncResult ar)
        {
            Player player = (Player) ar.AsyncState;

            int bytesSent = player.workSocket.EndSend(ar);

            Console.WriteLine("Sent " + bytesSent + " bytes!");
        }
    }
}

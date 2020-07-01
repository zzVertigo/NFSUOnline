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

            Device client = new Device();
            client.workSocket = handler;

            handler.BeginReceive(client.buffer, 0, Device.bufferSize, 0, readCallback, client);
        }

        private static void readCallback(IAsyncResult ar)
        {
            Device client = (Device) ar.AsyncState;
            Socket handler = client.workSocket;

            SocketError errorCode;

            int bytesRead = handler.EndReceive(ar, out errorCode);

            if (bytesRead > 0 && errorCode == SocketError.Success)
            {
                byte[] tempBuffer = new byte[bytesRead];

                Array.Copy(client.buffer, tempBuffer, tempBuffer.Length);

                client.process(tempBuffer);
            }
            else
            {
                // disconnected but ignore :D
                return;
            }

            if (handler.Connected)
                handler.BeginReceive(client.buffer, 0, Device.bufferSize, 0, readCallback, client);
        }

        public void sendPacket(Device device, Packet packet)
        {
            packet.encode();
            packet.process();

            byte[] byteData = packet.data.ToArray();

            Console.WriteLine("Data: " + BitConverter.ToString(byteData).Replace("-", ""));

            if (device.workSocket.Connected)
                device.workSocket.BeginSend(byteData, 0, byteData.Length, 0, sendCallback, device);
        }

        private static void sendCallback(IAsyncResult ar)
        {
            Device device = (Device) ar.AsyncState;

            device?.workSocket.EndSend(ar);
        }
    }
}

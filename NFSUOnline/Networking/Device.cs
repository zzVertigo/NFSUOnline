using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using NFSUOnline.Helpers;
using NFSUOnline.Packets;

namespace NFSUOnline.Networking
{
    public class Device
    {
        public Player player;

        public Socket workSocket = null;
        public const int bufferSize = 2048;
        public byte[] buffer = new byte[bufferSize];

        public void process(byte[] data)
        {
            Console.WriteLine("RECV (" + data.Length + "): " + BitConverter.ToString(data).Replace("-", ""));

            try
            {
                using (Reader reader = new Reader(data))
                {
                    string packetType = reader.readString(4);

                    reader.BaseStream.Seek(7, SeekOrigin.Current);

                    // packetLength includes header length so we must subtract the header length to get the length of our packet data
                    int packetLength = reader.ReadByte() - 12;

                    string packetData = reader.readString(packetLength);

                    if (Factory.Packets.ContainsKey(packetType))
                    {
                        Console.WriteLine("Received packet (" + packetType + ")");

                        Packet packet = (Packet) Activator.CreateInstance(Factory.Packets[packetType], this, reader);

                        packet.packetType = packetType;
                        packet.packetLength = packetLength;
                        packet.data = Encoding.UTF8.GetBytes(packetData).ToList();

                        packet.reader = new Reader(packet.data.ToArray());

                        packet.decode();
                        packet.process();
                    }
                    else
                    {
                        Console.WriteLine("Unknown packet received (" + packetType + ") >:(");
                        Console.WriteLine("Data: " + packetData);
                    }
                }

                //byte[] response = 
                //{
                //    0x40, 0x64, 0x69, 0x72, // packet type

                //    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, // useless zeros

                //    0x5E, // packet length

                //    0x41, 0x44, 0x44, 0x52, 0x3D, 0x31, 0x30, 0x2E, 0x30, 0x2E, 0x30, 
                //    0x2E, 0x31, 0x34, 0x33, 0x0A, 0x50, 0x4F, 0x52, 0x54, 0x3D, 0x31, 
                //    0x30, 0x39, 0x30, 0x30, 0x0A, 0x53, 0x45, 0x53, 0x53, 0x3D, 0x31, 
                //    0x30, 0x37, 0x32, 0x30, 0x31, 0x30, 0x32, 0x38, 0x38, 0x0A, 0x4D, 
                //    0x41, 0x53, 0x4B, 0x3D, 0x30, 0x32, 0x39, 0x35, 0x66, 0x33, 0x66, 
                //    0x37, 0x30, 0x65, 0x63, 0x62, 0x31, 0x37, 0x35, 0x37, 0x63, 0x64,
                //    0x37, 0x30, 0x30, 0x31, 0x62, 0x39, 0x61, 0x37, 0x61, 0x35, 0x65, 
                //    0x61, 0x63, 0x38, 0x0A, 0x00 // packet data
                //};

                //workSocket.Send(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to read packet: " + ex.ToString());
            }
        }
    }
}

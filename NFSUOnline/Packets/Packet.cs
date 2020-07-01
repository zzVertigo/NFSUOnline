using System;
using System.Collections.Generic;
using System.Text;
using NFSUOnline.Helpers;
using NFSUOnline.Networking;

namespace NFSUOnline.Packets
{
    public class Packet
    {
        public string packetType;
        public int packetLength;
        public string[] packetData;

        public Device device;
        public Reader reader;

        public List<byte> data;

        public Packet(Device device, Reader reader)
        {
            this.device = device;
            this.reader = reader;
        }

        public Packet(Device device)
        {
            this.device = device;
            this.packetData = new string[30];
            this.data = new List<byte>(2048);
        }

        public List<byte> buildHeader(string packetType, int packetLength)
        {
            List<byte> headerPortion = new List<byte>();

            packetLength = packetLength + 12; // add the header

            headerPortion.AddRange(Encoding.UTF8.GetBytes(packetType));

            for (int i = 0; i < 7; i++)
            {
                headerPortion.Add(0x00);
            }

            headerPortion.Add((byte)packetLength);

            return headerPortion;
        }

        public List<byte> buildData(string[] _params, int paramCount)
        {
            List<byte> dataPortion = new List<byte>();

            int totalLength = 0;

            for (int i = 0; i < paramCount; i++)
            {
                byte[] value = Encoding.UTF8.GetBytes(_params[i] + '\x0A');

                totalLength += value.Length;

                dataPortion.AddRange(value);
            }

            dataPortion.Add(0x00); // tells the game that this is the end of the packet

            return dataPortion;
        }

        public virtual void decode() {}
        public virtual void encode() {}
        public virtual void process() {}
    }
}

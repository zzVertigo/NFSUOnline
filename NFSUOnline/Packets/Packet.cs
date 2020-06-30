using System;
using System.Collections.Generic;
using System.Text;
using NFSUOnline.Helpers;
using NFSUOnline.Networking;

namespace NFSUOnline.Packets
{
    public class Packet
    {
        public string type;
        public int length;
        public List<byte> data;

        public Player player;
        public Reader reader;

        public byte[] endPacket = {0x0A, 0x00};

        public Packet(Player player, Reader reader)
        {
            this.player = player;
            this.reader = reader;
        }

        public Packet(Player player)
        {
            this.player = player;
            this.data = new List<byte>(2048);
        }

        public virtual void decode() {}
        public virtual void encode() {}
        public virtual void process() {}
    }
}

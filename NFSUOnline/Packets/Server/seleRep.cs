using System;
using System.Collections.Generic;
using System.Text;
using NFSUOnline.Networking;

namespace NFSUOnline.Packets.Server
{
    public class seleRep : Packet
    {
        public seleRep(Device device) : base(device)
        {
            this.packetType = "sele";
        }

        public override void encode()
        {
            this.packetData[0] = "GAMES=1";
            this.packetData[1] = "ROOMS=1";
            this.packetData[2] = "USERS=1";
            this.packetData[3] = "MESGS=1";
            this.packetData[4] = "RANKS=0";
            this.packetData[5] = "MORE=1";
            this.packetData[6] = "SLOTS=36";

            List<byte> data = buildData(this.packetData, 7);
            List<byte> header = buildHeader(this.packetType, data.Count);

            this.data.AddRange(header);
            this.data.AddRange(data);
        }

        public override void process()
        {

        }
    }
}

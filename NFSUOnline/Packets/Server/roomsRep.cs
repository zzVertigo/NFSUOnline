using System;
using System.Collections.Generic;
using System.Text;
using NFSUOnline.Networking;

namespace NFSUOnline.Packets.Server
{
    public class roomsRep : Packet
    {
        public roomsRep(Device device) : base(device)
        {
            this.packetType = "+rom";
        }

        public override void encode()
        {
            this.packetData[0] = "I=1";
            this.packetData[1] = "N=zzVertigo";
            this.packetData[2] = "H=zzVertigo";
            this.packetData[3] = "F=CK";
            this.packetData[4] = "T=1";
            this.packetData[5] = "L=50";
            this.packetData[6] = "P=0";

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

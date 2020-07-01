using System;
using System.Collections.Generic;
using System.Text;
using NFSUOnline.Networking;

namespace NFSUOnline.Packets.Server
{
    public class cperRep : Packet
    {
        public cperRep(Device device) : base(device)
        {
            this.packetType = "cper";
        }

        public override void encode()
        {
            this.packetData[0] = "PERS=zzVertigo";
            this.packetData[1] = "NAME=zzVertigo";

            List<byte> data = buildData(this.packetData, 2);
            List<byte> header = buildHeader(this.packetType, data.Count);

            this.data.AddRange(header);
            this.data.AddRange(data);
        }

        public override void process()
        {
        }
    }
}

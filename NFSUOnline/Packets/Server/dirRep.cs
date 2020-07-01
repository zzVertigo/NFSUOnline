using System;
using System.Collections.Generic;
using NFSUOnline.Helpers;
using NFSUOnline.Networking;

namespace NFSUOnline.Packets.Server
{
    public class dirRep : Packet
    {
        public dirRep(Device device) : base(device)
        {
            this.packetType = "@dir";
        }

        public override void encode()
        {
            this.packetData[0] = ("ADDR=10.0.0.143");
            this.packetData[1] = ("PORT=10900");
            this.packetData[2] = ("SESS=1072010288");
            this.packetData[3] = ("MASK=0295f3f70ecb1757cd7001b9a7a5eac8");

            List<byte> data = buildData(this.packetData, 4);
            List<byte> header = buildHeader(this.packetType, data.Count);

            this.data.AddRange(header);
            this.data.AddRange(data);
        }

        public override void process()
        {
        }
    }
}

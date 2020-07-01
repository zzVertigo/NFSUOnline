using System;
using System.Collections.Generic;
using System.Text;
using NFSUOnline.Core;
using NFSUOnline.Networking;

namespace NFSUOnline.Packets.Server
{
    public class skeyRep : Packet
    {
        public skeyRep(Device device) : base(device)
        {
            this.packetType = "skey";
        }

        public override void encode()
        {
            this.packetData[0] = "SKEY=$5075626c6963204b6579";

            List<byte> data = buildData(this.packetData, 1);
            List<byte> header = buildHeader(this.packetType, data.Count);

            this.data.AddRange(header);
            this.data.AddRange(data);
        }

        public override void process()
        {
        }
    }
}

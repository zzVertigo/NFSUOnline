using System;
using System.Collections.Generic;
using System.Text;
using NFSUOnline.Networking;

namespace NFSUOnline.Packets.Server
{
    public class acctRep : Packet
    {
        public string NAME { get; set; }
        public string AGE { get; set; }

        public acctRep(Device device) : base(device)
        {
            this.packetType = "acct";
        }

        public override void encode()
        {
            this.packetData[0] = "NAME=" + NAME;
            this.packetData[1] = "PERSONAS=";
            this.packetData[2] = "AGE=" + AGE;

            List<byte> data = buildData(this.packetData, 3);
            List<byte> header = buildHeader(this.packetType, data.Count);

            this.data.AddRange(header);
            this.data.AddRange(data);
        }

        public override void process()
        {

        }
    }
}
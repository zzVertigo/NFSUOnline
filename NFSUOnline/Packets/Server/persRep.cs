using System;
using System.Collections.Generic;
using System.Text;
using NFSUOnline.Networking;

namespace NFSUOnline.Packets.Server
{
    public class persRep : Packet
    {
        public persRep(Device device) : base(device)
        {
            this.packetType = "pers";
        }

        public override void encode()
        {
            this.packetData[0] = "NAME=zzVertigo";
            this.packetData[1] = "PERS=zzVertigo";
            this.packetData[2] = "LAST=2003.12.8 15:51:58";
            this.packetData[3] = "PLAST=2003.12.8 16:51:40";
            this.packetData[4] = "LKEY=3fcf27540c92935b0a66fd3b0000283c";

            List<byte> data = buildData(this.packetData, 5);
            List<byte> header = buildHeader(this.packetType, data.Count);

            this.data.AddRange(header);
            this.data.AddRange(data);
        }

        public override void process()
        {

        }
    }
}

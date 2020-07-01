using System;
using System.Collections.Generic;
using System.Text;
using NFSUOnline.Networking;

namespace NFSUOnline.Packets.Server
{
    public class newsRep : Packet
    {
        public newsRep(Device device) : base(device)
        {
            this.packetType = "newsnew0";
        }

        public override void encode()
        {
            List<byte> data = buildData(this.packetData, 0);
            List<byte> header = buildHeader(this.packetType, data.Count);

            this.data.AddRange(header);
            this.data.AddRange(data);
        }

        public override void process()
        {

        }
    }
}

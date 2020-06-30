using System;
using NFSUOnline.Helpers;
using NFSUOnline.Networking;

namespace NFSUOnline.Packets.Server
{
    public class dirRep : Packet
    {
        public dirRep(Player player) : base(player)
        {
            this.type = "@dir";
        }

        public override void encode()
        {
            this.data.writeString(this.type);
            this.data.Add(0x00);
            this.data.Add(0x00);
            this.data.Add(0x00);
            this.data.Add(0x00);
            this.data.Add(0x00);
            this.data.Add(0x00);
            this.data.Add(0x00);
            this.data.Add(0x5E);
            this.data.writeValue("ADDR", "10.0.0.143");
            this.data.writeValue("PORT", "10900");
            this.data.writeValue("SESS", "1072010288");
            this.data.writeValue("MASK", "0295f3f70ecb1757cd7001b9a7a5eac8");
            this.data.Add(0x0A);
            this.data.Add(0x00);
        }

        public override void process()
        {

        }
    }
}

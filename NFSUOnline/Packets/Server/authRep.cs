using System;
using System.Collections.Generic;
using System.Text;
using NFSUOnline.Networking;

namespace NFSUOnline.Packets.Server
{
    public class authRep : Packet
    {
        public authRep(Device device) : base(device)
        {
            this.packetType = "auth";
        }

        public override void encode()
        {
            this.packetData[0] = "TOS=" + this.device.player.UserID;
            this.packetData[1] = "NAME=" + this.device.player.Username;
            this.packetData[2] = "MAIL=" + this.device.player.Mail;
            this.packetData[3] = "BORN=" + this.device.player.Born;
            this.packetData[4] = "GEND=" + this.device.player.Gender;
            this.packetData[5] = "FROM=US";
            this.packetData[6] = "LANG=en";
            this.packetData[7] = "SPAM=YY";

            this.packetData[8] = "PERSONAS=";

            this.packetData[9] = "LAST=2003.12.8 15:51:38";

            List<byte> data = buildData(this.packetData, 10);
            List<byte> header = buildHeader(this.packetType, data.Count);

            this.data.AddRange(header);
            this.data.AddRange(data);
        }

        public override void process()
        {

        }
    }
}

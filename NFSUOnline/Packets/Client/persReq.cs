using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using NFSUOnline.Core;
using NFSUOnline.Helpers;
using NFSUOnline.Networking;
using NFSUOnline.Packets.Server;

namespace NFSUOnline.Packets.Client
{
    public class persReq : Packet
    {
        public string PERS { get; set; }
        public string MID { get; set; }

        public persReq(Device device, Reader reader) : base(device, reader)
        {

        }

        public override void decode()
        {
            this.PERS = reader.readValue1("PERS");
            this.MID = reader.readValue1("MID");
        }

        public override void process()
        {

            Resources.server.sendPacket(this.device, new persRep(this.device));
        }
    }
}

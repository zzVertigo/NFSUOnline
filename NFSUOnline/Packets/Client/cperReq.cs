using System;
using System.Collections.Generic;
using System.Text;
using NFSUOnline.Core;
using NFSUOnline.Helpers;
using NFSUOnline.Networking;
using NFSUOnline.Packets.Server;

namespace NFSUOnline.Packets.Client
{
    public class cperReq : Packet
    {
        public string PERS { get; set; }

        public cperReq(Device device, Reader reader) : base(device, reader)
        {

        }

        public override void decode()
        {
            this.PERS = reader.readValue1("PERS");
        }

        public override void process()
        {

            Resources.server.sendPacket(this.device, new cperRep(this.device));
        }
    }
}

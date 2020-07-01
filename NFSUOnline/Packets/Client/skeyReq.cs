using System;
using System.Collections.Generic;
using System.Text;
using NFSUOnline.Core;
using NFSUOnline.Helpers;
using NFSUOnline.Networking;
using NFSUOnline.Packets.Server;

namespace NFSUOnline.Packets.Client
{
    public class skeyReq : Packet
    {
        private string SKEY { get; set; }

        public skeyReq(Device device, Reader reader) : base(device, reader)
        {

        }

        public override void decode()
        {
            this.SKEY = reader.readValue1("SKEY");
        }

        public override void process()
        {
            Resources.server.sendPacket(this.device, new skeyRep(this.device));
        }
    }
}
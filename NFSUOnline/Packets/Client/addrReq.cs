using System;
using System.Collections.Generic;
using System.Text;
using NFSUOnline.Core;
using NFSUOnline.Helpers;
using NFSUOnline.Networking;
using NFSUOnline.Packets.Server;

namespace NFSUOnline.Packets.Client
{
    public class addrReq : Packet
    {
        // $5075626c6963204b6579
        private string ADDR { get; set; }
        private string PORT { get; set; }

        public addrReq(Device device, Reader reader) : base(device, reader)
        {

        }

        public override void decode()
        {
            this.ADDR = reader.readValue1("ADDR");
            this.PORT = reader.readValue1("PORT");
        }

        public override void process()
        {
            Resources.server.sendPacket(this.device, new skeyRep(this.device));
        }
    }
}

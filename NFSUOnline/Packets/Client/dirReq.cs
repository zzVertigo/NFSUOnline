using System;
using System.Collections.Generic;
using System.Text;
using NFSUOnline.Core;
using NFSUOnline.Helpers;
using NFSUOnline.Networking;
using NFSUOnline.Packets.Server;

namespace NFSUOnline.Packets.Client
{
    public class dirReq : Packet
    {
        private string PROD { get; set; }
        private string VERS { get; set; }
        private string SLUS { get; set; }
        private string FROM { get; set; }
        private string LANG { get; set; }
        private string REGN { get; set; }
        private string CLST { get; set; }
        private string NETV { get; set; }

        public dirReq(Player player, Reader reader) : base(player, reader)
        {

        }

        public override void decode()
        {
            this.PROD = reader.readValue("PROD");
            this.VERS = reader.readValue("VERS");
            this.SLUS = reader.readValue("SLUS");
            this.FROM = reader.readValue("FROM");
            this.LANG = reader.readValue("LANG");
            this.REGN = reader.readValue("REGN");
            this.CLST = reader.readValue("CLST");
            this.NETV = reader.readValue("NETV");
        }

        public override void process()
        {
            Resources.server.sendPacket(this.player, new dirRep(this.player));
        }
    }
}

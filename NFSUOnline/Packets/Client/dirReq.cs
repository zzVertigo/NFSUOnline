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

        public dirReq(Device device, Reader reader) : base(device, reader)
        {

        }

        public override void decode()
        {
            this.PROD = reader.readValue1("PROD");
            this.VERS = reader.readValue1("VERS");
            this.SLUS = reader.readValue1("SLUS");
            this.FROM = reader.readValue1("FROM");
            this.LANG = reader.readValue1("LANG");
            this.REGN = reader.readValue1("REGN");
            this.CLST = reader.readValue1("CLST");
            this.NETV = reader.readValue1("NETV");
        }

        public override void process()
        {
            if (this.PROD == "nfs-pc-2003" && this.VERS == "\"pc/1.4-Jan 15 2004\"" && this.NETV == "5")
                Resources.server.sendPacket(this.device, new dirRep(this.device));
            else
                Console.WriteLine("Odd client joining lets just disconnect...");
        }
    }
}

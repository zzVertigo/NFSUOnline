using System;
using System.Collections.Generic;
using System.Text;
using NFSUOnline.Core;
using NFSUOnline.Helpers;
using NFSUOnline.Networking;
using NFSUOnline.Packets.Server;

namespace NFSUOnline.Packets.Client
{
    public class authReq : Packet
    {
        public string NAME { get; set; }
        public string PASS { get; set; }
        public string TOS { get; set; }
        public string MID { get; set; }
        public string FROM { get; set; }
        public string LANG { get; set; }
        public string PROD { get; set; }
        public string VERS { get; set; }
        public string SLUS { get; set; }
        public string REGN { get; set; }
        public string CLST { get; set; }
        public string NETV { get; set; }

        public authReq(Device device, Reader reader) : base(device, reader)
        {

        }

        public override void decode()
        {
            this.NAME = reader.readValue1("NAME");
            this.PASS = reader.readValue1("PASS");
            this.TOS = reader.readValue1("TOS");
            this.MID = reader.readValue1("MID");
            this.FROM = reader.readValue1("FROM");
            this.LANG = reader.readValue1("LANG");
            this.PROD = reader.readValue1("PROD");
            this.VERS = reader.readValue1("VERS");
            this.SLUS = reader.readValue1("SLUS");
            this.REGN = reader.readValue1("REGN");
            this.CLST = reader.readValue1("CLST");
            this.NETV = reader.readValue1("NETV");
        }

        public override void process()
        {
            Player player = Resources.players.getPlayer(this.device, this.NAME, this.PASS);

            if (player != null)
            {
                Resources.server.sendPacket(this.device, new authRep(this.device));
            }
            else
            {
                Console.WriteLine("Player is NULL?");
                // player not found
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using NFSUOnline.Core;
using NFSUOnline.Helpers;
using NFSUOnline.Networking;
using NFSUOnline.Packets.Server;

namespace NFSUOnline.Packets.Client
{
    public class acctReq : Packet
    {
        public string NAME { get; set; }
        public string PASS { get; set; }
        public string MAIL { get; set; }
        public string BORN { get; set; }
        public string GEND { get; set; }
        public string SPAM { get; set; }
        public string FROM { get; set; }
        public string LANG { get; set; }
        public string PROD { get; set; }
        public string VERS { get; set; }
        public string SLUS { get; set; }
        public string REGN { get; set; }
        public string CLST { get; set; }
        public string NETV { get; set; }

        public acctReq(Device device, Reader reader) : base(device, reader)
        {

        }

        public override void decode()
        {
            this.NAME = reader.readValue1("NAME");
            this.PASS = reader.readValue1("PASS");
            this.MAIL = reader.readValue1("MAIL");
            this.BORN = reader.readValue1("BORN");
            this.GEND = reader.readValue1("GEND");
            this.SPAM = reader.readValue1("SPAM");
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
            acctRep rep = new acctRep(this.device);

            int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            int dob = int.Parse(this.BORN);

            int age = (now - dob) / 10000;

            rep.NAME = this.NAME;
            rep.AGE = age.ToString();

            Player player = Resources.players.createPlayer(this.device, this.NAME, this.PASS);

            player.Age = age;
            player.Born = this.BORN;
            player.Gender = this.GEND;
            player.Mail = this.MAIL;
            player.Personas = new string[4][];

            Resources.players.savePlayer(player);

            if (this.PROD == "nfs-pc-2003" && this.VERS == "\"pc/1.4-Jan 15 2004\"" && this.NETV == "5")
                Resources.server.sendPacket(this.device, rep);
            else
                Console.WriteLine("Odd client joining lets just disconnect...");
        }
    }
}

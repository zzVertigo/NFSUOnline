using System;
using System.Collections.Generic;
using System.Text;
using NFSUOnline.Core;
using NFSUOnline.Helpers;
using NFSUOnline.Networking;
using NFSUOnline.Packets.Server;

namespace NFSUOnline.Packets.Client
{
    public class seleReq : Packet
    {
        public string ROOMS { get; set; }
        public string USERS { get; set; }
        public string MESGS { get; set; }
        public string RANKS { get; set; }
        public string GAMES { get; set; }

        public seleReq(Device device, Reader reader) : base(device, reader)
        {

        }

        public override void decode()
        {
            //this.ROOMS = reader.readValue2("ROOMS");
            //this.USERS = reader.readValue2("USERS");
            //this.MESGS = reader.readValue2("MESGS");
            //this.RANKS = reader.readValue2("RANKS");
            //this.GAMES = reader.readValue2("GAMES");
        }

        public override void process()
        {
            Resources.server.sendPacket(this.device, new seleRep(this.device));
            Resources.server.sendPacket(this.device, new roomsRep(this.device));
        }
    }
}

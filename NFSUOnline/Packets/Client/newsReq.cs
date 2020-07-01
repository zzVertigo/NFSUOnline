using System;
using System.Collections.Generic;
using System.Text;
using NFSUOnline.Core;
using NFSUOnline.Helpers;
using NFSUOnline.Networking;
using NFSUOnline.Packets.Server;

namespace NFSUOnline.Packets.Client
{
    public class newsReq : Packet
    {
        public newsReq(Device device, Reader reader) : base(device, reader)
        {

        }

        public override void decode()
        {

        }

        public override void process()
        {
            Resources.server.sendPacket(this.device, new newsRep(this.device));
        }
    }
}

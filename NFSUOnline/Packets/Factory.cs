using System;
using System.Collections.Generic;
using System.Text;
using NFSUOnline.Packets.Client;

namespace NFSUOnline.Packets
{
    public class Factory
    {
        public static Dictionary<string, Type> Packets = null;

        public Factory()
        {
            Packets = new Dictionary<string, Type>();

            Factory.LoadPackets();
        }

        private static void LoadPackets()
        {
            Packets.Add("@dir", typeof(dirReq));
            Packets.Add("addr", typeof(addrReq));
            Packets.Add("skey", typeof(skeyReq));
            Packets.Add("acct", typeof(acctReq));
            Packets.Add("auth", typeof(authReq));
            Packets.Add("cper", typeof(cperReq));
            Packets.Add("pers", typeof(persReq));
            Packets.Add("sele", typeof(seleReq));
            //Packets.Add("news", typeof(newsReq)); // broken?
        }
    }
}

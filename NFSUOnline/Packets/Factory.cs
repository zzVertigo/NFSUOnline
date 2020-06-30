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
        }
    }
}

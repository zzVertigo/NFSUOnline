using System;
using System.Collections.Generic;
using System.Text;
using NFSUOnline.Core.Slots;
using NFSUOnline.Networking;
using NFSUOnline.Packets;

namespace NFSUOnline.Core
{
    public static class Resources
    {
        private static Factory factory;
        public static Server server;
        public static Players players;

        public static void init()
        {
            players = new Players();

            factory = new Factory();
            server = new Server();
        }
    }
}

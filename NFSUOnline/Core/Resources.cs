using System;
using System.Collections.Generic;
using System.Text;
using NFSUOnline.Networking;
using NFSUOnline.Packets;

namespace NFSUOnline.Core
{
    public static class Resources
    {
        private static Factory factory;
        public static Server server;

        public static void init()
        {
            factory = new Factory();
            server = new Server();
        }
    }
}

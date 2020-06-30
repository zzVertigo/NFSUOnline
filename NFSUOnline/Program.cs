using System;
using System.Threading;
using NFSUOnline.Core;
using NFSUOnline.Networking;

namespace NFSUOnline
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Resources.init();

            Resources.server.startListening("10.0.0.143", 10900);

            Thread.Sleep(-1);
        }
    }
}

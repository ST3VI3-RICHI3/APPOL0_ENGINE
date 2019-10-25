using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Net.Sockets;
using System.Net;

namespace APOLL0
{
    class Dubugger
    {
        //Please note: This is used as an entrypoint to the engine when developing and used to debug for developers, do not use this in normal game operation.
        const Int32 DPort = 26000;
        static IPAddress DLocalAddr { get; } = IPAddress.Parse("127.0.0.1");
        static TcpListener DConHost = new TcpListener(DLocalAddr, DPort);
        public static async void StartDebug()
        {
            DConHost.Start();
            await DConHost.AcceptTcpClientAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetFlow;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Consoles
{
    class Program
    {
        static void Main(string[] args)
        {
            Templates _templates = new Templates();

            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint iep = new IPEndPoint(IPAddress.Any, 9996);
            sock.Bind(iep);
            EndPoint ep = (EndPoint)iep;

            byte[] data = new byte[2048];
            Console.WriteLine("Capture started...");
            while (true)
            {
                int recv = sock.ReceiveFrom(data, ref ep);
                //Console.ReadKey();
                Console.Clear();
                byte[] bytes = new byte[recv];

                for (int i = 0; i < recv; i++)
                    bytes[i] = data[i];

                Packet packet = new Packet(bytes, _templates);
                
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(packet.ToString());
            }
            sock.Close();

            Console.ReadKey();
        }
    }
}

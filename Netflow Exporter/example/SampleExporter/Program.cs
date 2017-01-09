using Rubenhak.NetflowExporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Rubenhak.SampleExporter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Netflow Export Sample Program");

            var templateDef = 
                new TemplateFlow(555)
                    .Field(FieldType.IPV4SourceAddress, 4)
                    .Field(FieldType.IPV4DestionationAddress, 4)
                    .Field(FieldType.L4SourcePort, 2)
                    .Field(FieldType.L4DestionationPort, 2)
                    .Field(FieldType.Protocol, 1)
                    .Field(FieldType.InputBytes, 4)
                    .Field(FieldType.InputPackets, 4)
                    ;

            var templateData = 
                new TemplateData(templateDef)
                .Data( IPAddress.Parse("192.168.10.66"),
                       IPAddress.Parse("10.12.13.14"),
                       (ushort)7777,
                       (ushort)21,
                       (byte)ProtocolType.Tcp,
                       (UInt32)20*1024,
                       (UInt32)20
                      )
                .Data(IPAddress.Parse("192.168.10.67"),
                       IPAddress.Parse("10.12.13.14"),
                       (ushort)6564,
                       (ushort)21,
                       (byte)ProtocolType.Tcp,
                       (UInt32)15 * 1024,
                       (UInt32)15
                      )
                      ;

            var exportData =
                new ExportPacket(0, 1234)
                    .Template(templateData)
                    .GetData();

            Console.WriteLine("Size = " + exportData.Length);
            Console.WriteLine("Data = " + BitConverter.ToString(exportData).Replace("-", " "));

            Send(exportData, "127.0.0.1", 9991);

            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }

        static void Send(byte[] data, string ip, int port)
        {
            Console.WriteLine(string.Format("Sending {0} bytes...", data.Length));
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            sock.SendTo(data, endPoint);
        }
    }
}

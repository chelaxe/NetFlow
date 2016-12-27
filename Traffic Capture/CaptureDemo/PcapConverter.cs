using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Rubenhak.NetflowExporter;
using SharpPcap;
using SharpPcap.LibPcap;

namespace CaptureDemo
{
    class PcapConverter
    {
        public static void reading_CaptureFile(string capFile)
        {
            Console.WriteLine("opening '{0}'", capFile);

            ICaptureDevice device;

            try
            {
                // Get an offline device
                device = new CaptureFileReaderDevice(capFile);

                // Open the device
                device.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("Caught exception when opening file" + e.ToString());
                return;
            }
            // Register our handler function to the 'packet arrival' event
            device.OnPacketArrival +=
                new PacketArrivalEventHandler(device_OnPacketArrival);

            Console.WriteLine();
            Console.WriteLine
                ("-- Capturing from '{0}', hit 'Ctrl-C' to exit...",
                capFile);

            // Start capture 'INFINTE' number of packets
            // This method will return when EOF reached.
            device.Capture();

            // Close the pcap device
            device.Close();
            Console.WriteLine("-- End of file reached.");
            Console.Write("Hit 'Enter' to exit...");
            Console.ReadLine();
        }

        private static int packetIndex = 0;
        static void device_OnPacketArrival(object sender, CaptureEventArgs e)
        {
            var time = e.Packet.Timeval.Date;
            var len = e.Packet.Data.Length;
            Console.WriteLine("{0}:{1}:{2},{3} Len={4}", time.Hour, time.Minute, time.Second, time.Millisecond, len);

            if (e.Packet.LinkLayerType == PacketDotNet.LinkLayers.Ethernet)
            {
                var packet = PacketDotNet.Packet.ParsePacket(e.Packet.LinkLayerType, e.Packet.Data);
                var ethernetPacket = (PacketDotNet.EthernetPacket)packet;

                Console.WriteLine("{0} At: {1}:{2}: MAC:{3} -> MAC:{4}",
                                  packetIndex,
                                  e.Packet.Timeval.Date.ToString(),
                                  e.Packet.Timeval.Date.Millisecond,
                                  ethernetPacket.Type,
                                  ethernetPacket.PayloadPacket.PrintHex());
                packetIndex++;
            }
            Console.WriteLine(e.Packet.ToString());
        }

        public static void Convert()
        {

        }

        public static void Export()
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
                .Data(IPAddress.Parse("192.168.10.66"),
                       IPAddress.Parse("10.12.13.14"),
                       (ushort)7777,
                       (ushort)21,
                       (byte)ProtocolType.Tcp,
                       (UInt32)20 * 1024,
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

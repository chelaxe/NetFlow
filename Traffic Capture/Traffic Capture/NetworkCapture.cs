using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpPcap;
using SharpPcap.LibPcap;

namespace Traffic_Capture
{
    public class NetworkCapture
    {
        private static CaptureFileWriterDevice captureFileWriter;
        private static int packetIndex = 0;
        public static void DumpToFile(object sender, CaptureEventArgs e)
        {
            //var device = (ICaptureDevice)sender;

            // write the packet to the file
            captureFileWriter.Write(e.Packet);
            Console.WriteLine("Packet dumped to file.");

            if (e.Packet.LinkLayerType == PacketDotNet.LinkLayers.Ethernet)
            {
                var packet = PacketDotNet.Packet.ParsePacket(e.Packet.LinkLayerType, e.Packet.Data);
                var ethernetPacket = (PacketDotNet.EthernetPacket)packet;

                Console.WriteLine("{0} At: {1}:{2}: MAC:{3} -> MAC:{4}",
                                  packetIndex,
                                  e.Packet.Timeval.Date.ToString(),
                                  e.Packet.Timeval.Date.Millisecond,
                                  ethernetPacket.SourceHwAddress,
                                  ethernetPacket.DestinationHwAddress);
                packetIndex++;
            }
        }

        /*-------------------------------------------------------------------------
        
         --------------------------------------------------------------------------*/

        
    }
}

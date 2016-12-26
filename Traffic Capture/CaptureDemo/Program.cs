using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpPcap;
using SharpPcap.AirPcap;
using SharpPcap.LibPcap;
using SharpPcap.WinPcap;
using Traffic_Capture;

namespace CaptureDemo
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Print SharpPcap version
            string ver = SharpPcap.Version.VersionString;
            Console.WriteLine("SharpPcap {0}, Example3.BasicCap.cs", ver);

            // Retrieve the device list
            var devices = CaptureDeviceList.Instance;

            // If no devices were found print an error
            if (devices.Count < 1)
            {
                Console.WriteLine("No devices were found on this machine");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("The following devices are available on this machine:");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine();

            int i = 0;

            // Print out the devices
            foreach (var dev in devices)
            {
                /* Description */
                Console.WriteLine("{0}) {1} {2}", i, dev.Name, dev.Description);
                i++;
            }

            Console.WriteLine();
            Console.Write("-- Please choose a device to capture: ");
            i = int.Parse(Console.ReadLine());

            var device = devices[i] as SharpPcap.WinPcap.WinPcapDevice;

            // Register our handler function to the 'pcap statistics' event
            device.OnPcapStatistics += new SharpPcap.WinPcap.StatisticsModeEventHandler(device_OnPcapStatistics);

          /*  // Register our handler function to the 'packet arrival' event
            device.OnPacketArrival +=
                new PacketArrivalEventHandler(device_OnPacketArrival);*/

          

            // Open the device for capturing
            int readTimeoutMilliseconds = 1000;
            if (device is AirPcapDevice)
            {
                // NOTE: AirPcap devices cannot disable local capture
                var airPcap = device as AirPcapDevice;
                airPcap.Open(SharpPcap.WinPcap.OpenFlags.DataTransferUdp, readTimeoutMilliseconds);
            }
            else if (device is WinPcapDevice)
            {
                var winPcap = device as WinPcapDevice;
                winPcap.Open(SharpPcap.WinPcap.OpenFlags.DataTransferUdp | SharpPcap.WinPcap.OpenFlags.NoCaptureLocal, readTimeoutMilliseconds);
            }
            else if (device is LibPcapLiveDevice)
            {
                var livePcapDevice = device as LibPcapLiveDevice;
                livePcapDevice.Open(DeviceMode.Promiscuous, readTimeoutMilliseconds);
            }
            else
            {
                throw new System.InvalidOperationException("unknown device type of " + device.GetType().ToString());
            }

            Console.WriteLine();
            Console.WriteLine("-- Listening on {0} {1}, hit 'Enter' to stop...",
                device.Name, device.Description);

            // Start the capturing process
            device.StartCapture();

            // Wait for 'Enter' from the user.
            Console.ReadLine();

            // Stop the capturing process
            device.StopCapture();

            Console.WriteLine("-- Capture stopped.");

            // Print out the device statistics
            Console.WriteLine(device.Statistics.ToString());

            // Close the pcap device
            device.Close();

            Console.ReadKey();
        }
        private static int packetIndex = 0;
        /// <summary>
        /// Prints the time and length of each received packet
        /// </summary>
        private static void device_OnPacketArrival(object sender, CaptureEventArgs e)
        {
            var time = e.Packet.Timeval.Date;
            var len = e.Packet.Data.Length;
            Console.WriteLine("{0}:{1}:{2},{3} Len={4}",time.Hour, time.Minute, time.Second, time.Millisecond, len);

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

        static ulong oldSec = 0;
        static ulong oldUsec = 0;
        /// <summary>
        /// Gets a pcap stat object and calculate bps and pps
        /// </summary>
        public static void device_OnPcapStatistics(object sender, SharpPcap.WinPcap.StatisticsModeEventArgs e)
        {
            // Calculate the delay in microseconds from the last sample.
            // This value is obtained from the timestamp that's associated with the sample.
            ulong delay = (e.Statistics.Timeval.Seconds - oldSec) * 1000000 - oldUsec + e.Statistics.Timeval.MicroSeconds;

            // Get the number of Bits per second
            ulong bps = ((ulong)e.Statistics.RecievedBytes * 8 * 1000000) / delay;
            /*                                       ^       ^
                                                     |       |
                                                     |       | 
                                                     |       |
                            converts bytes in bits --        |
                                                             |
                        delay is expressed in microseconds --
            */

            // Get the number of Packets per second
            ulong pps = ((ulong)e.Statistics.RecievedPackets * 1000000) / delay;

            // Convert the timestamp to readable format
            var ts = e.Statistics.Timeval.Date.ToLongTimeString();

            // Print Statistics
            Console.WriteLine("{0}: bps={1}, pps={2}", ts, bps, pps);

            //store current timestamp
            oldSec = e.Statistics.Timeval.Seconds;
            oldUsec = e.Statistics.Timeval.MicroSeconds;
        }
    }
}

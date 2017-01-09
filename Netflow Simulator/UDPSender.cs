using System;
using System.Net;
using System.Net.Sockets;

namespace flowsimulator {
    /// <summary>
    /// 
    /// </summary>
    public class UDPSender {
        private UdpClient server;

        public UDPSender(ushort lPort, ushort rPort, string host) {
            server = new UdpClient(lPort);
            server.Connect(host, rPort);
        }

        public void sendPacket(ref byte[] packet, ushort len) {
            if (server.Send(packet, len) != len) {
                throw new Exception("send error");
            }

        }
        public void close() {
            server.Close();
        }
    }
}

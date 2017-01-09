using System;
using System.Collections.Generic;
using System.Text;

namespace flowsimulator {
    public abstract class FlowGenerator {
        public flowsimulator.UDPSender UdpServer {
            get {
                return udpServer;
            }
            set {
                udpServer = value;
            }
        }
        public flowsimulator.OptionsForm Options {
            set {
                options = value;
            }
        }
        public System.Windows.Forms.TextBox StatusLine {
            set {
                statusLine = value;
            }
        }

        protected delegate void ShowStatusDelegate(string status);

        protected void ShowStatus(string status) {
            if (statusLine.InvokeRequired == false) {
                statusLine.Text = status;
            } else {
                // Show progress asynchronously
                ShowStatusDelegate showStatus =
                  new ShowStatusDelegate(ShowStatus);
                statusLine.Invoke(showStatus, new object[] { status });
            }
        }

        public abstract ushort createPacket(ushort flows);
        public abstract void sendPacket();

        protected unsafe byte[] packet;
        protected flowsimulator.UDPSender udpServer;
        protected System.Random random;
        protected flowsimulator.OptionsForm options;
        protected System.Windows.Forms.TextBox statusLine;
        protected System.Text.StringBuilder msg = new System.Text.StringBuilder();
    }
}

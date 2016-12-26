using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using System.Text;

namespace flowsimulator {
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class NetflowSimulator : System.Windows.Forms.Form {
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox collectorIP;
        private System.Windows.Forms.Label label3;
        private flowsimulator.NumericTextBox port;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox lstboxV8Aggregation;
        private System.Windows.Forms.CheckedListBox chklstFlowVersion;
        private flowsimulator.NumericTextBox txtBoxVolume;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label label7;
        private flowsimulator.NumericTextBox textBoxlPort;
        private System.Windows.Forms.Button btnOptions;
        private bool stopSimulation = false;
        private OptionsForm options = new OptionsForm();
        private ArrayList v9Templates = null;
        private ArrayList ipfixTemplates = null;
        private System.Windows.Forms.Button btnAbout;
        private ushort packetsRate = 1;
        private Label label8;
        private Label label9;
        private NumericTextBox numericTextBoxIpfixLocalPort;
        private NumericTextBox numericTextBoxIpfixPort;
        private Label label10;
        private NumericTextBox numericTextBoxSflowlport;
        private NumericTextBox numericTextSFlowrport;
        private CheckedListBox checkedListBoxSFlowVersion;
        private int v8aggregation = 0;
        private static int NUM_SFLOW_VERSIONS = (int)flowsimulator.CounterVersion.VlanCounter;
        private bool[] sFlowVersions;

        public NetflowSimulator() {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            collectorIP.Text = System.Net.Dns.GetHostName();
            sFlowVersions = new bool[NUM_SFLOW_VERSIONS + 1];
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing) {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.chklstFlowVersion = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.collectorIP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.lstboxV8Aggregation = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnOptions = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.checkedListBoxSFlowVersion = new System.Windows.Forms.CheckedListBox();
            this.numericTextBoxSflowlport = new flowsimulator.NumericTextBox();
            this.numericTextSFlowrport = new flowsimulator.NumericTextBox();
            this.numericTextBoxIpfixLocalPort = new flowsimulator.NumericTextBox();
            this.numericTextBoxIpfixPort = new flowsimulator.NumericTextBox();
            this.textBoxlPort = new flowsimulator.NumericTextBox();
            this.txtBoxVolume = new flowsimulator.NumericTextBox();
            this.port = new flowsimulator.NumericTextBox();
            this.SuspendLayout();
            // 
            // chklstFlowVersion
            // 
            this.chklstFlowVersion.CheckOnClick = true;
            this.chklstFlowVersion.Items.AddRange(new object[] {
            "Version 1",
            "Version 5",
            "Version 7",
            "Version 8",
            "Version 9",
            "IPFIX",
            "sFlow"});
            this.chklstFlowVersion.Location = new System.Drawing.Point(56, 41);
            this.chklstFlowVersion.Name = "chklstFlowVersion";
            this.chklstFlowVersion.Size = new System.Drawing.Size(80, 109);
            this.chklstFlowVersion.TabIndex = 1;
            this.chklstFlowVersion.SelectedIndexChanged += new System.EventHandler(this.chklstFlowVersion_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose Simulation Versions";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(32, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Target Host";
            // 
            // collectorIP
            // 
            this.collectorIP.Location = new System.Drawing.Point(103, 167);
            this.collectorIP.MaxLength = 64;
            this.collectorIP.Name = "collectorIP";
            this.collectorIP.Size = new System.Drawing.Size(120, 20);
            this.collectorIP.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(102, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Remote port";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(32, 307);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Traffic Rate";
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(171, 362);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(75, 23);
            this.btnStartStop.TabIndex = 14;
            this.btnStartStop.Text = "&Start";
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(199, 307);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "packets / sec";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(32, 330);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Status";
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Location = new System.Drawing.Point(104, 330);
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.ReadOnly = true;
            this.textBoxStatus.Size = new System.Drawing.Size(264, 20);
            this.textBoxStatus.TabIndex = 13;
            // 
            // lstboxV8Aggregation
            // 
            this.lstboxV8Aggregation.Items.AddRange(new object[] {
            "AS Aggregation",
            "Protocol Port Aggregation",
            "Source Prefix Aggregation",
            "Destination Prefix Aggregation",
            "Network Matrix (Prefix) Aggregation",
            "Destination Prefix ToS Matrix",
            "Prefix ToS Matrix",
            "Prefix Port Matrix",
            "AS ToS Aggregation",
            "Protocol Port ToS Aggregation",
            "Source Prefix ToS Aggregation"});
            this.lstboxV8Aggregation.Location = new System.Drawing.Point(208, 48);
            this.lstboxV8Aggregation.Name = "lstboxV8Aggregation";
            this.lstboxV8Aggregation.Size = new System.Drawing.Size(160, 108);
            this.lstboxV8Aggregation.TabIndex = 2;
            this.lstboxV8Aggregation.Visible = false;
            this.lstboxV8Aggregation.SelectedIndexChanged += new System.EventHandler(this.lstboxV8Aggregation_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(261, 193);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 16);
            this.label7.TabIndex = 7;
            this.label7.Text = "Local port";
            // 
            // btnOptions
            // 
            this.btnOptions.Location = new System.Drawing.Point(31, 362);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(75, 23);
            this.btnOptions.TabIndex = 15;
            this.btnOptions.Text = "&Options...";
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(311, 362);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(75, 23);
            this.btnAbout.TabIndex = 16;
            this.btnAbout.Text = "&About...";
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(32, 216);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Netflow";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(32, 254);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "IPFIX";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(31, 280);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "sFlow";
            // 
            // checkedListBoxSFlowVersion
            // 
            this.checkedListBoxSFlowVersion.CheckOnClick = true;
            this.checkedListBoxSFlowVersion.Items.AddRange(new object[] {
            "Generic Counters",
            "Ethernet Counters",
            "Tokenring Counters",
            "FDDI Counters",
            "VG Counters",
            "WAN Counters",
            "VLAN Counters"});
            this.checkedListBoxSFlowVersion.Location = new System.Drawing.Point(207, 43);
            this.checkedListBoxSFlowVersion.Name = "checkedListBoxSFlowVersion";
            this.checkedListBoxSFlowVersion.Size = new System.Drawing.Size(161, 109);
            this.checkedListBoxSFlowVersion.TabIndex = 28;
            this.checkedListBoxSFlowVersion.Visible = false;
            this.checkedListBoxSFlowVersion.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxSFlowVersion_SelectedIndexChanged);
            // 
            // numericTextBoxSflowlport
            // 
            this.numericTextBoxSflowlport.AllowSpace = false;
            this.numericTextBoxSflowlport.Location = new System.Drawing.Point(261, 272);
            this.numericTextBoxSflowlport.MaxLength = 5;
            this.numericTextBoxSflowlport.Name = "numericTextBoxSflowlport";
            this.numericTextBoxSflowlport.Size = new System.Drawing.Size(50, 20);
            this.numericTextBoxSflowlport.TabIndex = 26;
            this.numericTextBoxSflowlport.Text = "1236";
            // 
            // numericTextSFlowrport
            // 
            this.numericTextSFlowrport.AllowSpace = false;
            this.numericTextSFlowrport.Location = new System.Drawing.Point(102, 272);
            this.numericTextSFlowrport.MaxLength = 5;
            this.numericTextSFlowrport.Name = "numericTextSFlowrport";
            this.numericTextSFlowrport.Size = new System.Drawing.Size(72, 20);
            this.numericTextSFlowrport.TabIndex = 25;
            this.numericTextSFlowrport.Text = "6343";
            // 
            // numericTextBoxIpfixLocalPort
            // 
            this.numericTextBoxIpfixLocalPort.AllowSpace = false;
            this.numericTextBoxIpfixLocalPort.Location = new System.Drawing.Point(261, 244);
            this.numericTextBoxIpfixLocalPort.MaxLength = 5;
            this.numericTextBoxIpfixLocalPort.Name = "numericTextBoxIpfixLocalPort";
            this.numericTextBoxIpfixLocalPort.Size = new System.Drawing.Size(50, 20);
            this.numericTextBoxIpfixLocalPort.TabIndex = 23;
            this.numericTextBoxIpfixLocalPort.Text = "1235";
            // 
            // numericTextBoxIpfixPort
            // 
            this.numericTextBoxIpfixPort.AllowSpace = false;
            this.numericTextBoxIpfixPort.Location = new System.Drawing.Point(102, 244);
            this.numericTextBoxIpfixPort.MaxLength = 5;
            this.numericTextBoxIpfixPort.Name = "numericTextBoxIpfixPort";
            this.numericTextBoxIpfixPort.Size = new System.Drawing.Size(72, 20);
            this.numericTextBoxIpfixPort.TabIndex = 21;
            this.numericTextBoxIpfixPort.Text = "4739";
            // 
            // textBoxlPort
            // 
            this.textBoxlPort.AllowSpace = false;
            this.textBoxlPort.Location = new System.Drawing.Point(261, 216);
            this.textBoxlPort.MaxLength = 5;
            this.textBoxlPort.Name = "textBoxlPort";
            this.textBoxlPort.Size = new System.Drawing.Size(50, 20);
            this.textBoxlPort.TabIndex = 8;
            this.textBoxlPort.Text = "1234";
            // 
            // txtBoxVolume
            // 
            this.txtBoxVolume.AllowSpace = false;
            this.txtBoxVolume.Location = new System.Drawing.Point(104, 303);
            this.txtBoxVolume.MaxLength = 4;
            this.txtBoxVolume.Name = "txtBoxVolume";
            this.txtBoxVolume.Size = new System.Drawing.Size(88, 20);
            this.txtBoxVolume.TabIndex = 10;
            this.txtBoxVolume.Text = "1";
            // 
            // port
            // 
            this.port.AllowSpace = false;
            this.port.Location = new System.Drawing.Point(102, 216);
            this.port.MaxLength = 5;
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(72, 20);
            this.port.TabIndex = 6;
            this.port.Text = "9991";
            // 
            // NetflowSimulator
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(417, 397);
            this.Controls.Add(this.checkedListBoxSFlowVersion);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.numericTextBoxSflowlport);
            this.Controls.Add(this.numericTextSFlowrport);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.numericTextBoxIpfixLocalPort);
            this.Controls.Add(this.numericTextBoxIpfixPort);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnOptions);
            this.Controls.Add(this.textBoxlPort);
            this.Controls.Add(this.textBoxStatus);
            this.Controls.Add(this.txtBoxVolume);
            this.Controls.Add(this.port);
            this.Controls.Add(this.collectorIP);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lstboxV8Aggregation);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnStartStop);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chklstFlowVersion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NetflowSimulator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Netflow Simulator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.Run(new NetflowSimulator());
        }

        private void chklstFlowVersion_SelectedIndexChanged(object sender, System.EventArgs e) {
            if (chklstFlowVersion.SelectedIndex == (int)FlowVersionList.V8
                && chklstFlowVersion.GetItemChecked((int)FlowVersionList.V8)) {
                if (lstboxV8Aggregation.InvokeRequired) {
                    this.Invoke(new EventHandler(chklstFlowVersion_SelectedIndexChanged),
                        new object[] { sender, e });
                    return;
                }
                lstboxV8Aggregation.Visible = true;
                if (lstboxV8Aggregation.SelectedIndices.Count == 0) {
                    lstboxV8Aggregation.SetSelected(0, true);
                }
                v8aggregation = lstboxV8Aggregation.SelectedIndex + 1;
            } else {
                lstboxV8Aggregation.Visible = false;
            }

            if (chklstFlowVersion.SelectedIndex == (int)FlowVersionList.V9
                && chklstFlowVersion.GetItemChecked((int)FlowVersionList.V9)) {
                if (v9Templates == null) {
                    v9Templates = new ArrayList();
                }
                V9TemplateList form = new V9TemplateList();
                form.StartPosition = FormStartPosition.CenterParent;
                form.V9Templates = v9Templates;
                if (form.ShowDialog() != DialogResult.OK) {
                    chklstFlowVersion.SetItemChecked((int)FlowVersionList.V9, false);
                }
            }
            if (chklstFlowVersion.SelectedIndex == (int)FlowVersionList.IPFIX
                && chklstFlowVersion.GetItemChecked((int)FlowVersionList.IPFIX)) {
                if (ipfixTemplates == null) {
                    ipfixTemplates = new ArrayList();
                }
                FormIpfixTemplateList form = new FormIpfixTemplateList();
                form.StartPosition = FormStartPosition.CenterParent;
                form.IpfixTemplates = ipfixTemplates;
                if (form.ShowDialog() != DialogResult.OK) {
                    chklstFlowVersion.SetItemChecked((int)FlowVersionList.IPFIX, false);
                }
            }
            if (chklstFlowVersion.SelectedIndex == (int)FlowVersionList.SFLOW) {
                if (checkedListBoxSFlowVersion.InvokeRequired) {
                    this.Invoke(new EventHandler(chklstFlowVersion_SelectedIndexChanged),
                        new object[] { sender, e });
                    return;
                }
                bool hasOneCounterChecked = false;
                for (int i =0; i<sFlowVersions.Length;++i) {
                    if (sFlowVersions[i] == true) {
                        hasOneCounterChecked = true;
                        break;
                    }
                }
                if (!hasOneCounterChecked) {
                    checkedListBoxSFlowVersion.SetItemChecked(0, true);
                }
                checkedListBoxSFlowVersion.Visible = true;
            } else {
                checkedListBoxSFlowVersion.Visible = false;
            }
        }
        private bool checkInput() {
            StringBuilder message = new StringBuilder("Please correct the following errors:");
            bool correct = true;
            if (chklstFlowVersion.SelectedIndices.Count == 0) {
                message.Append("\n\tAt lease one version of netflow should be selected");
                correct = false;
            }
            if (collectorIP.Text == "") {
                correct = false;
                message.Append("\n\tNetflow collector must be specified");
            }
            if (port.Text == "") {
                correct = false;
                message.Append("\n\tRemote port must be specified");
            }
            if (textBoxlPort.Text == "") {
                correct = false;
                message.Append("\n\tLocal port must be specified");
            }
            if (txtBoxVolume.Text == "") {
                message.Append("\n\tInvalid value for packets/sec");
                correct = false;
            }
            try {
                packetsRate = Convert.ToUInt16(txtBoxVolume.Text);
            } catch (FormatException fe) {
                message.Append("\n\tInvalid value for packet/sec: " + fe.Message);
                correct = false;
            }
            if (!correct) {
                MessageBox.Show(this, message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return correct;
        }

        private void btnStartStop_Click(object sender, System.EventArgs e) {
            if (btnStartStop.Text == "Stop") {
                stopSimulation = true;
                btnStartStop.Text = "Start";
                return;
            } else {
                btnStartStop.Text = "Stop";
                stopSimulation = false;
            }

            if (!checkInput()) {
                return;
            }

            Thread t = new Thread(new ThreadStart(Run));
            t.Start();

            //stopSimulation = !stopSimulation;

        }
        protected delegate void StartStopClickDelegate(object sender, System.EventArgs e);

        protected void Run() {
            
            ushort rport = Convert.ToUInt16(port.Text);
            ushort lport = Convert.ToUInt16(textBoxlPort.Text);
            ushort ipfixrport = Convert.ToUInt16(numericTextBoxIpfixPort.Text);
            ushort ipfixlport = Convert.ToUInt16(numericTextBoxIpfixLocalPort.Text);
            ushort sflowLport = Convert.ToUInt16(numericTextBoxSflowlport.Text);
            ushort sflowRport = Convert.ToUInt16(numericTextSFlowrport.Text);

            int n = chklstFlowVersion.CheckedItems.Count;
            flowsimulator.FlowGenerator[] flows = new flowsimulator.FlowGenerator[n];

            UDPSender server = null; 
            UDPSender ipfixSender = null;
            UDPSender sflowSender = null;
            try {
                for (int i = 0; i < n; ++i) {
                    uint systime = (uint)Environment.TickCount;
                    FlowVersionList version = (FlowVersionList)chklstFlowVersion.CheckedIndices[i];
                    uint id = (uint)i;
                    flows[i] = null;

                    switch (version) {
                        case FlowVersionList.V1:
                            flows[i] = new netflow.V1Netflow(1, systime, id, 0);
                            break;
                        case FlowVersionList.V5:
                            flows[i] = new netflow.V5Netflow(5, systime, id, 0);
                            break;
                        case FlowVersionList.V7:
                            flows[i] = new netflow.V7Netflow(7, systime, id, 0);
                            break;
                        case FlowVersionList.V8:
                            flows[i] = new netflow.V8Netflow(8, systime, id, 0);
                            ((netflow.V8Netflow)flows[i]).Aggregation = (netflow.V8Aggregation)v8aggregation;
                            //(netflow.V8Aggregation)lstboxV8Aggregation.SelectedIndex + 1;
                            break;
                        case FlowVersionList.V9:
                            flows[i] = new netflow.V9Netflow(9, systime, id, 0);
                            ((netflow.V9Netflow)flows[i]).Templates = v9Templates;
                            break;
                        case FlowVersionList.IPFIX:
                            flows[i] = new netflow.Ipfix(10, systime, id, 0);
                            if (ipfixSender == null) {
                                ipfixSender = new UDPSender(ipfixlport
                                     , ipfixrport
                                     , collectorIP.Text);
                            }
                            flows[i].UdpServer = ipfixSender;
                            ((netflow.Ipfix)flows[i]).Templates = ipfixTemplates;
                            break;
                        case FlowVersionList.SFLOW:
                            flows[i] = new flowsimulator.SFlow(systime, sFlowVersions);
                            if (sflowSender == null) {
                                sflowSender = new UDPSender(sflowLport, sflowRport, collectorIP.Text);
                            }
                            flows[i].UdpServer = sflowSender;
                            break;
                    }
                    if (flows[i].UdpServer == null) {
                        if (server == null) {
                            server = new UDPSender(lport, rport, collectorIP.Text);
                        }
                        flows[i].UdpServer = server;
                    }
                    flows[i].Options = options;
                    flows[i].StatusLine = textBoxStatus;
                }
            } catch (Exception e) {
                StartStopClickDelegate btnClick = new StartStopClickDelegate(btnStartStop_Click);

                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (server != null) {
                    server.close();
                }
                if (ipfixSender != null) {
                    ipfixSender.close();
                }
                if (sflowSender != null) {
                    sflowSender.close();
                }
                if (btnStartStop.InvokeRequired) {
                    btnStartStop.Invoke(btnClick, new object[] { this, null });
                } else {
                    btnStartStop_Click(this, null);
                }
                return;
            }

            // let the game begin!
            while (!stopSimulation) {
                for (int i = 0; i < n; ++i) {
                    flows[i].sendPacket();
                    Thread.Sleep(1000 / packetsRate);
                }

            }
            if (server != null) {
                server.close();
            }
            if (ipfixSender != null) {
                ipfixSender.close();
            }
            if (sflowSender != null) {
                sflowSender.close();
            }
        }

        private void btnOptions_Click(object sender, System.EventArgs e) {
            if (options.ShowDialog() == DialogResult.OK) {
                //options.Close();
            }
        }

        private void btnAbout_Click(object sender, System.EventArgs e) {
            About a = new About();
            if (a.ShowDialog() == DialogResult.OK) {
                a.Close();
            }
        }



        enum FlowVersionList : byte {
            V1 = 0,
            V5,
            V7,
            V8,
            V9,
            IPFIX,
            SFLOW
        };

        private void lstboxV8Aggregation_SelectedIndexChanged(object sender, EventArgs e) {
            if (lstboxV8Aggregation.InvokeRequired) {
                this.Invoke(new EventHandler(lstboxV8Aggregation_SelectedIndexChanged),
                    new object[] { sender, e });
                return;
            }
            v8aggregation = lstboxV8Aggregation.SelectedIndex + 1;
        }

        private void checkedListBoxSFlowVersion_SelectedIndexChanged(object sender, EventArgs e) {
            if (checkedListBoxSFlowVersion.InvokeRequired) {
                this.Invoke(new EventHandler(checkedListBoxSFlowVersion_SelectedIndexChanged),
                    new object[] { sender, e });
                return;
            }
            int checkedCount = 0;
            for (int index = 0; index < checkedListBoxSFlowVersion.Items.Count; ++index) {
                if (checkedListBoxSFlowVersion.GetItemChecked(index)) {
                    checkedCount += 1;
                    sFlowVersions[index + 1] = true;
                } else {
                    sFlowVersions[index + 1] = false;
                }
                chklstFlowVersion.SetItemChecked((int)FlowVersionList.SFLOW, checkedCount > 0);
            }

        }
    }
}

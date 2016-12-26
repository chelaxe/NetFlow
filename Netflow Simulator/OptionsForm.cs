using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace flowsimulator {
    /// <summary>
    /// Summary description for OptionsForm.
    /// </summary>
    public class OptionsForm : System.Windows.Forms.Form {
        private System.Windows.Forms.RadioButton radioBtnRandom;
        private System.Windows.Forms.RadioButton radioBtnSemiRandom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelOptions;
        private System.Windows.Forms.Label interface_no;
        private System.Windows.Forms.TextBox textBoxInterface;
        private System.Windows.Forms.TextBox textBoxSrcAddress;
        private System.Windows.Forms.Label srcAddress;
        private System.Windows.Forms.TextBox textBoxTOS;
        private System.Windows.Forms.Label labelTos;
        private System.Windows.Forms.TextBox textBoxAS;
        private System.Windows.Forms.Label labelAS;
        private System.Windows.Forms.TextBox textBoxBytes;
        private System.Windows.Forms.Label labelBytes;
        private System.Windows.Forms.TextBox textBoxPackets;
        private System.Windows.Forms.Label labelPackets;
        private System.Windows.Forms.TextBox textBoxTCPFlags;
        private System.Windows.Forms.Label labelTcpFlags;
        private System.Windows.Forms.TextBox textBoxProtocols;
        private System.Windows.Forms.Label labelProtocols;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.TextBox textBoxMasks;
        private System.Windows.Forms.Label labelMasks;
        private System.Windows.Forms.Button btnApply;

        public enum RandomMode {
            PureRandom,
            LimitedRandom
        }
        private RandomMode randomMode = RandomMode.PureRandom;

        ValueRange2 interfaceRange = null;
        AddressRange srcAddressRange = null;
        AddressRange dstAddressRange = null;
        ValueRange1 tosRange = null;
        ValueRange2 asRange = null;
        ValueRange4 bytesRange = null;
        ValueRange4 packetsRange = null;
        ValueRange4 flowsRange = null;
        ValueRange1 tcpflagRange = null;
        ValueRange2 portRange = null;
        ValueRange1 protocolRange = null;
        ValueRange1 maskRange = null;
        private TextBox textBoxFlows;
        private Label labelFlows;
        private TextBox textBoxDstAddress;
        private Label dstAddress;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public OptionsForm() {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            radioBtnSemiRandom.Checked = true;
            panelOptions.Enabled = true;
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            btnApply_Click(this, null);
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
            this.radioBtnRandom = new System.Windows.Forms.RadioButton();
            this.radioBtnSemiRandom = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panelOptions = new System.Windows.Forms.Panel();
            this.textBoxDstAddress = new System.Windows.Forms.TextBox();
            this.dstAddress = new System.Windows.Forms.Label();
            this.textBoxFlows = new System.Windows.Forms.TextBox();
            this.labelFlows = new System.Windows.Forms.Label();
            this.textBoxMasks = new System.Windows.Forms.TextBox();
            this.labelMasks = new System.Windows.Forms.Label();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.labelPort = new System.Windows.Forms.Label();
            this.textBoxProtocols = new System.Windows.Forms.TextBox();
            this.labelProtocols = new System.Windows.Forms.Label();
            this.textBoxTCPFlags = new System.Windows.Forms.TextBox();
            this.labelTcpFlags = new System.Windows.Forms.Label();
            this.textBoxPackets = new System.Windows.Forms.TextBox();
            this.labelPackets = new System.Windows.Forms.Label();
            this.textBoxBytes = new System.Windows.Forms.TextBox();
            this.labelBytes = new System.Windows.Forms.Label();
            this.textBoxAS = new System.Windows.Forms.TextBox();
            this.labelAS = new System.Windows.Forms.Label();
            this.textBoxTOS = new System.Windows.Forms.TextBox();
            this.labelTos = new System.Windows.Forms.Label();
            this.textBoxSrcAddress = new System.Windows.Forms.TextBox();
            this.srcAddress = new System.Windows.Forms.Label();
            this.textBoxInterface = new System.Windows.Forms.TextBox();
            this.interface_no = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.panelOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioBtnRandom
            // 
            this.radioBtnRandom.Location = new System.Drawing.Point(24, 40);
            this.radioBtnRandom.Name = "radioBtnRandom";
            this.radioBtnRandom.Size = new System.Drawing.Size(120, 24);
            this.radioBtnRandom.TabIndex = 1;
            this.radioBtnRandom.Text = "Completely random";
            this.radioBtnRandom.CheckedChanged += new System.EventHandler(this.radioBtnRandom_CheckedChanged);
            // 
            // radioBtnSemiRandom
            // 
            this.radioBtnSemiRandom.Location = new System.Drawing.Point(24, 69);
            this.radioBtnSemiRandom.Name = "radioBtnSemiRandom";
            this.radioBtnSemiRandom.Size = new System.Drawing.Size(460, 40);
            this.radioBtnSemiRandom.TabIndex = 2;
            this.radioBtnSemiRandom.Text = "Limited random (either specify a range as 2 - 10, or individual values such as: 1" +
                ",3,5,10). You can leave some fields empty, and their values will be generated ra" +
                "ndomly.";
            this.radioBtnSemiRandom.CheckedChanged += new System.EventHandler(this.radioBtnSemiRandom_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please choose simulation behavior:";
            // 
            // panelOptions
            // 
            this.panelOptions.Controls.Add(this.textBoxDstAddress);
            this.panelOptions.Controls.Add(this.dstAddress);
            this.panelOptions.Controls.Add(this.textBoxFlows);
            this.panelOptions.Controls.Add(this.labelFlows);
            this.panelOptions.Controls.Add(this.textBoxMasks);
            this.panelOptions.Controls.Add(this.labelMasks);
            this.panelOptions.Controls.Add(this.textBoxPort);
            this.panelOptions.Controls.Add(this.labelPort);
            this.panelOptions.Controls.Add(this.textBoxProtocols);
            this.panelOptions.Controls.Add(this.labelProtocols);
            this.panelOptions.Controls.Add(this.textBoxTCPFlags);
            this.panelOptions.Controls.Add(this.labelTcpFlags);
            this.panelOptions.Controls.Add(this.textBoxPackets);
            this.panelOptions.Controls.Add(this.labelPackets);
            this.panelOptions.Controls.Add(this.textBoxBytes);
            this.panelOptions.Controls.Add(this.labelBytes);
            this.panelOptions.Controls.Add(this.textBoxAS);
            this.panelOptions.Controls.Add(this.labelAS);
            this.panelOptions.Controls.Add(this.textBoxTOS);
            this.panelOptions.Controls.Add(this.labelTos);
            this.panelOptions.Controls.Add(this.textBoxSrcAddress);
            this.panelOptions.Controls.Add(this.srcAddress);
            this.panelOptions.Controls.Add(this.textBoxInterface);
            this.panelOptions.Controls.Add(this.interface_no);
            this.panelOptions.Location = new System.Drawing.Point(9, 116);
            this.panelOptions.Name = "panelOptions";
            this.panelOptions.Size = new System.Drawing.Size(475, 397);
            this.panelOptions.TabIndex = 3;
            // 
            // textBoxDstAddress
            // 
            this.textBoxDstAddress.Location = new System.Drawing.Point(107, 80);
            this.textBoxDstAddress.MaxLength = 128;
            this.textBoxDstAddress.Name = "textBoxDstAddress";
            this.textBoxDstAddress.Size = new System.Drawing.Size(345, 20);
            this.textBoxDstAddress.TabIndex = 5;
            this.textBoxDstAddress.Text = "192.168.1.1-192.168.1.255";
            // 
            // dstAddress
            // 
            this.dstAddress.Location = new System.Drawing.Point(11, 84);
            this.dstAddress.Name = "dstAddress";
            this.dstAddress.Size = new System.Drawing.Size(82, 16);
            this.dstAddress.TabIndex = 4;
            this.dstAddress.Text = "Dst Address";
            // 
            // textBoxFlows
            // 
            this.textBoxFlows.Location = new System.Drawing.Point(107, 240);
            this.textBoxFlows.MaxLength = 128;
            this.textBoxFlows.Name = "textBoxFlows";
            this.textBoxFlows.Size = new System.Drawing.Size(345, 20);
            this.textBoxFlows.TabIndex = 15;
            this.textBoxFlows.Text = "1";
            // 
            // labelFlows
            // 
            this.labelFlows.Location = new System.Drawing.Point(11, 244);
            this.labelFlows.Name = "labelFlows";
            this.labelFlows.Size = new System.Drawing.Size(82, 16);
            this.labelFlows.TabIndex = 14;
            this.labelFlows.Text = "Flows";
            // 
            // textBoxMasks
            // 
            this.textBoxMasks.Location = new System.Drawing.Point(107, 368);
            this.textBoxMasks.MaxLength = 128;
            this.textBoxMasks.Name = "textBoxMasks";
            this.textBoxMasks.Size = new System.Drawing.Size(345, 20);
            this.textBoxMasks.TabIndex = 23;
            this.textBoxMasks.Text = "24";
            // 
            // labelMasks
            // 
            this.labelMasks.Location = new System.Drawing.Point(11, 372);
            this.labelMasks.Name = "labelMasks";
            this.labelMasks.Size = new System.Drawing.Size(82, 16);
            this.labelMasks.TabIndex = 22;
            this.labelMasks.Text = "Masks";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(107, 336);
            this.textBoxPort.MaxLength = 128;
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(345, 20);
            this.textBoxPort.TabIndex = 21;
            this.textBoxPort.Text = "21,22,25,80,161";
            // 
            // labelPort
            // 
            this.labelPort.Location = new System.Drawing.Point(11, 340);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(82, 16);
            this.labelPort.TabIndex = 20;
            this.labelPort.Text = "Port #";
            // 
            // textBoxProtocols
            // 
            this.textBoxProtocols.Location = new System.Drawing.Point(107, 304);
            this.textBoxProtocols.MaxLength = 128;
            this.textBoxProtocols.Name = "textBoxProtocols";
            this.textBoxProtocols.Size = new System.Drawing.Size(345, 20);
            this.textBoxProtocols.TabIndex = 19;
            this.textBoxProtocols.Text = "4";
            // 
            // labelProtocols
            // 
            this.labelProtocols.Location = new System.Drawing.Point(11, 308);
            this.labelProtocols.Name = "labelProtocols";
            this.labelProtocols.Size = new System.Drawing.Size(82, 16);
            this.labelProtocols.TabIndex = 18;
            this.labelProtocols.Text = "Protocols";
            // 
            // textBoxTCPFlags
            // 
            this.textBoxTCPFlags.Location = new System.Drawing.Point(107, 272);
            this.textBoxTCPFlags.MaxLength = 128;
            this.textBoxTCPFlags.Name = "textBoxTCPFlags";
            this.textBoxTCPFlags.Size = new System.Drawing.Size(345, 20);
            this.textBoxTCPFlags.TabIndex = 17;
            this.textBoxTCPFlags.Text = "3";
            // 
            // labelTcpFlags
            // 
            this.labelTcpFlags.Location = new System.Drawing.Point(11, 276);
            this.labelTcpFlags.Name = "labelTcpFlags";
            this.labelTcpFlags.Size = new System.Drawing.Size(82, 16);
            this.labelTcpFlags.TabIndex = 16;
            this.labelTcpFlags.Text = "TCP Flags";
            // 
            // textBoxPackets
            // 
            this.textBoxPackets.Location = new System.Drawing.Point(107, 208);
            this.textBoxPackets.MaxLength = 128;
            this.textBoxPackets.Name = "textBoxPackets";
            this.textBoxPackets.Size = new System.Drawing.Size(345, 20);
            this.textBoxPackets.TabIndex = 13;
            this.textBoxPackets.Text = "10-100";
            // 
            // labelPackets
            // 
            this.labelPackets.Location = new System.Drawing.Point(11, 212);
            this.labelPackets.Name = "labelPackets";
            this.labelPackets.Size = new System.Drawing.Size(82, 16);
            this.labelPackets.TabIndex = 12;
            this.labelPackets.Text = "Packets";
            // 
            // textBoxBytes
            // 
            this.textBoxBytes.Location = new System.Drawing.Point(107, 176);
            this.textBoxBytes.MaxLength = 128;
            this.textBoxBytes.Name = "textBoxBytes";
            this.textBoxBytes.Size = new System.Drawing.Size(345, 20);
            this.textBoxBytes.TabIndex = 11;
            this.textBoxBytes.Text = "1000-3000";
            // 
            // labelBytes
            // 
            this.labelBytes.Location = new System.Drawing.Point(11, 180);
            this.labelBytes.Name = "labelBytes";
            this.labelBytes.Size = new System.Drawing.Size(82, 16);
            this.labelBytes.TabIndex = 10;
            this.labelBytes.Text = "Bytes";
            // 
            // textBoxAS
            // 
            this.textBoxAS.Location = new System.Drawing.Point(107, 144);
            this.textBoxAS.MaxLength = 128;
            this.textBoxAS.Name = "textBoxAS";
            this.textBoxAS.Size = new System.Drawing.Size(345, 20);
            this.textBoxAS.TabIndex = 9;
            this.textBoxAS.Text = "2";
            // 
            // labelAS
            // 
            this.labelAS.Location = new System.Drawing.Point(11, 148);
            this.labelAS.Name = "labelAS";
            this.labelAS.Size = new System.Drawing.Size(82, 16);
            this.labelAS.TabIndex = 8;
            this.labelAS.Text = "AS #";
            // 
            // textBoxTOS
            // 
            this.textBoxTOS.Location = new System.Drawing.Point(107, 112);
            this.textBoxTOS.MaxLength = 128;
            this.textBoxTOS.Name = "textBoxTOS";
            this.textBoxTOS.Size = new System.Drawing.Size(345, 20);
            this.textBoxTOS.TabIndex = 7;
            this.textBoxTOS.Text = "1";
            // 
            // labelTos
            // 
            this.labelTos.Location = new System.Drawing.Point(11, 116);
            this.labelTos.Name = "labelTos";
            this.labelTos.Size = new System.Drawing.Size(82, 16);
            this.labelTos.TabIndex = 6;
            this.labelTos.Text = "TOS";
            // 
            // textBoxSrcAddress
            // 
            this.textBoxSrcAddress.Location = new System.Drawing.Point(107, 48);
            this.textBoxSrcAddress.MaxLength = 128;
            this.textBoxSrcAddress.Name = "textBoxSrcAddress";
            this.textBoxSrcAddress.Size = new System.Drawing.Size(345, 20);
            this.textBoxSrcAddress.TabIndex = 3;
            this.textBoxSrcAddress.Text = "192.168.0.1-192.168.0.255";
            // 
            // srcAddress
            // 
            this.srcAddress.Location = new System.Drawing.Point(11, 52);
            this.srcAddress.Name = "srcAddress";
            this.srcAddress.Size = new System.Drawing.Size(82, 16);
            this.srcAddress.TabIndex = 2;
            this.srcAddress.Text = "Src Address";
            // 
            // textBoxInterface
            // 
            this.textBoxInterface.Location = new System.Drawing.Point(107, 16);
            this.textBoxInterface.MaxLength = 128;
            this.textBoxInterface.Name = "textBoxInterface";
            this.textBoxInterface.Size = new System.Drawing.Size(345, 20);
            this.textBoxInterface.TabIndex = 1;
            this.textBoxInterface.Text = "1-5";
            // 
            // interface_no
            // 
            this.interface_no.Location = new System.Drawing.Point(11, 20);
            this.interface_no.Name = "interface_no";
            this.interface_no.Size = new System.Drawing.Size(82, 16);
            this.interface_no.TabIndex = 0;
            this.interface_no.Text = "Interface #";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(211, 525);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(72, 23);
            this.btnApply.TabIndex = 4;
            this.btnApply.Text = "Apply";
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // OptionsForm
            // 
            this.AcceptButton = this.btnApply;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(494, 557);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.panelOptions);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioBtnSemiRandom);
            this.Controls.Add(this.radioBtnRandom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Simulation Behavior";
            this.panelOptions.ResumeLayout(false);
            this.panelOptions.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private void radioBtnRandom_CheckedChanged(object sender, System.EventArgs e) {
            radioBtnSemiRandom.Checked = panelOptions.Enabled = !(radioBtnRandom.Checked);

        }

        private void radioBtnSemiRandom_CheckedChanged(object sender, System.EventArgs e) {
            radioBtnRandom.Checked = !(panelOptions.Enabled = (radioBtnSemiRandom.Checked));

        }

        private void btnApply_Click(object sender, System.EventArgs e) {
            randomMode = radioBtnRandom.Checked ? RandomMode.PureRandom : RandomMode.LimitedRandom;
            if (randomMode == RandomMode.PureRandom) {
                return;
            }
            try {
                interfaceRange = new ValueRange2(textBoxInterface.Text);
                srcAddressRange = new AddressRange(textBoxSrcAddress.Text);
                dstAddressRange = new AddressRange(textBoxDstAddress.Text);
                tosRange = new ValueRange1(textBoxTOS.Text);
                asRange = new ValueRange2(textBoxAS.Text);
                bytesRange = new ValueRange4(textBoxBytes.Text);
                packetsRange = new ValueRange4(textBoxPackets.Text);
                tcpflagRange = new ValueRange1(textBoxTCPFlags.Text);
                portRange = new ValueRange2(textBoxPort.Text);
                protocolRange = new ValueRange1(textBoxProtocols.Text);
                maskRange = new ValueRange1(textBoxMasks.Text);
                flowsRange = new ValueRange4(textBoxFlows.Text);
            } catch (InvalidValueSpecificationException ie) {
                MessageBox.Show(this, ie.Message, "Invalid Value Specified");
                //this.DialogResult = DialogResult.Cancel;
                return;
            }
            DialogResult = DialogResult.OK;
        }
        public byte NextTcpFlag {
            get {
                return tcpflagRange.NextValue();
            }
        }
        public ushort NextPort {
            get {
                return portRange.NextValue();
            }
        }
        public byte NextProtocol {
            get {
                return protocolRange.NextValue();
            }
        }
        public byte NextMask {
            get {
                return (byte)(maskRange.NextValue() % 32);
            }
        }

        public ushort NextInterface {
            get {
                return interfaceRange.NextValue();
            }
        }
        public uint NextSrcAddress {
            get {
                return srcAddressRange.NextValue();
            }
        }
        public uint NextDstAddress {
            get {
                return dstAddressRange.NextValue();
            }
        }
        public byte NextTOS {
            get {
                return tosRange.NextValue();
            }
        }
        public ushort NextAS {
            get {
                return asRange.NextValue();
            }
        }
        public uint NextBytes {
            get {
                return bytesRange.NextValue();
            }
        }
        public uint NextPackets {
            get {
                return packetsRange.NextValue();
            }
        }
        public uint NextFlows {
            get {
                return flowsRange.NextValue();
            }
        }
        public RandomMode Mode {
            get {
                return randomMode;
            }
        }
    }
}

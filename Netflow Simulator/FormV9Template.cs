using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace flowsimulator
{
	/// <summary>
	/// Summary description for PickV9Template.
	/// </summary>
	public class FormV9Template : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.ListBox listBoxAll;
		private System.Windows.Forms.ListBox listBoxSelected;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnMove;
		private System.Windows.Forms.Button btnRemove;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.TextBox textBoxTemplateId;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBoxFrequency;
		private System.Windows.Forms.Label label5;

		public static string[] TemplateItem = {
				"UNKNOWN",
				"IN_BYTES",
				"IN_PKTS",
				"FLOWS",
				"PROTOCOL",
				"SRC_TOS",	
				"TCP_FLAGS",
				"L4_SRC_PORT",
				"IPV4_SRC_ADDR",
				"SRC_MASK",
				"INPUT_SNMP",
				"L4_DST_PORT",
				"IPV4_DST_ADDR",
				"DST_MASK",
				"OUTPUT_SNMP",
				"IPV4_NEXT_HOP",
				"SRC_AS",
				"DST_AS",
				"BGP_IPV4_NEXT_HOP",
				"MUL_DST_PKTS",
				"MUL_DST_BYTES",
				"LAST_SWITCHED",
				"FIRST_SWITCHED",
				"OUT_BYTES",
				"OUT_PKTS",
				"MIN_PKT_LNGTH",
				"MAX_PKT_LNGTH",
				"IPV6_SRC_ADDR",
				"IPV6_DST_ADDR",
				"IPV6_SRC_MASK",
				"IPV6_DST_MASK",
				"IPV6_FLOW_LABEL",
				"ICMP_TYPE",
				"MUL_IGMP_TYPE",
				"SAMPLING_INTERVAL",
				"SAMPLING_ALGORITHM",
				"FLOW_ACTIVE_TIMEOUT",
				"FLOW_INACTIVE_TIMEOUT",
				"ENGINE_TYPE",
				"ENGINE_ID",
				"TOTAL_BYTES_EXP",
				"TOTAL_PKTS_EXP",
				"TOTAL_FLOWS_EXP",
				"VENDOR_PROP43",
				"IPV4_SRC_PREFIX",
				"IPV4_DST_PREFIX",
				"MPLS_TOP_LABEL_TYPE",
				"MPLS_TOP_LABEL_IP_ADDR",
				"FLOW_SAMPLER_ID",
				"FLOW_SAMPLER_MODE",
				"FLOW_SAMPLER_RANDOM_INTERVAL",
				"VENDOR_PROP51",
				"MIN_TTL",
				"MAX_TTL",
				"IPV4_IDENT",
				"DST_TOS",
				"IN_SRC_MAC",
				"OUT_DST_MAC",
				"SRC_VLAN",
				"DST_VLAN",
				"IP_PROTOCOL_VERSION",
				"DIRECTION",
				"IPV6_NEXT_HOP",
				"BPG_IPV6_NEXT_HOP",
				"IPV6_OPTION_HEADERS",
				"VENDOR_PROP65",
				"VENDOR_PROP66",
				"VENDOR_PROP67",
				"VENDOR_PROP68",
				"VENDOR_PROP69",
				"MPLS_LABEL_1",
				"MPLS_LABEL_2",
				"MPLS_LABEL_3",
				"MPLS_LABEL_4",
				"MPLS_LABEL_5",
				"MPLS_LABEL_6",
				"MPLS_LABEL_7",
				"MPLS_LABEL_8",
				"MPLS_LABEL_9",
				"MPLS_LABEL_10",
				"IN_DST_MAC",
				"OUT_SRC_MAC",
				"IF_NAME",
				"IF_DESC",
				"SAMPLER_NAME",
				"IN_PERMANENT_BYTES",
				"IN_PERMANENT_PKTS",
				"VENDOR_PROP87",
				"FRAGMENT_OFFSET",
				"FORWARDING_STATUS"
			};

		public enum TemplateType : ushort 
		{
			IN_BYTES = 1,
			IN_PKTS,
			FLOWS,
			PROTOCOL,
			SRC_TOS,	
			TCP_FLAGS,
			L4_SRC_PORT,
			IPV4_SRC_ADDR,
			SRC_MASK,
			INPUT_SNMP,
			L4_DST_PORT,
			IPV4_DST_ADDR,
			DST_MASK,
			OUTPUT_SNMP,
			IPV4_NEXT_HOP,
			SRC_AS,
			DST_AS,
			BGP_IPV4_NEXT_HOP,
			MUL_DST_PKTS,
			MUL_DST_BYTES,
			LAST_SWITCHED,
			FIRST_SWITCHED,
			OUT_BYTES,
			OUT_PKTS,
			MIN_PKT_LNGTH,
			MAX_PKT_LNGTH,
			IPV6_SRC_ADDR,
			IPV6_DST_ADDR,
			IPV6_SRC_MASK,
			IPV6_DST_MASK,
			IPV6_FLOW_LABEL,
			ICMP_TYPE,
			MUL_IGMP_TYPE,
			SAMPLING_INTERVAL,
			SAMPLING_ALGORITHM,
			FLOW_ACTIVE_TIMEOUT,
			FLOW_INACTIVE_TIMEOUT,
			ENGINE_TYPE,
			ENGINE_ID,
			TOTAL_BYTES_EXP,
			TOTAL_PKTS_EXP,
			TOTAL_FLOWS_EXP,
			VENDOR_PROP43,
			IPV4_SRC_PREFIX,
			IPV4_DST_PREFIX,
			MPLS_TOP_LABEL_TYPE,
			MPLS_TOP_LABEL_IP_ADDR,
			FLOW_SAMPLER_ID,
			FLOW_SAMPLER_MODE,
			FLOW_SAMPLER_RANDOM_INTERVAL,
			VENDOR_PROP51,
			MIN_TTL,
			MAX_TTL,
			IPV4_IDENT,
			DST_TOS,
			IN_SRC_MAC,
			OUT_DST_MAC,
			SRC_VLAN,
			DST_VLAN,
			IP_PROTOCOL_VERSION,
			DIRECTION,
			IPV6_NEXT_HOP,
			BPG_IPV6_NEXT_HOP,
			IPV6_OPTION_HEADERS,
			VENDOR_PROP65,
			VENDOR_PROP66,
			VENDOR_PROP67,
			VENDOR_PROP68,
			VENDOR_PROP69,
			MPLS_LABEL_1,
			MPLS_LABEL_2,
			MPLS_LABEL_3,
			MPLS_LABEL_4,
			MPLS_LABEL_5,
			MPLS_LABEL_6,
			MPLS_LABEL_7,
			MPLS_LABEL_8,
			MPLS_LABEL_9,
			MPLS_LABEL_10,
			IN_DST_MAC,
			OUT_SRC_MAC,
			IF_NAME,
			IF_DESC,
			SAMPLER_NAME,
			IN_PERMANENT_BYTES,
			IN_PERMANENT_PKTS,
			VENDOR_PROP87,
			FRAGMENT_OFFSET,
			FORWARDING_STATUS
		}

		static ushort[,] TemplateItemSize = 
		{
			{(ushort)TemplateType.IN_BYTES, 4},
			{(ushort)TemplateType.IN_PKTS, 4},
			{(ushort)TemplateType.FLOWS, 4},
			{(ushort)TemplateType.PROTOCOL, 1},
			{(ushort)TemplateType.SRC_TOS, 1},	
			{(ushort)TemplateType.TCP_FLAGS, 1},
			{(ushort)TemplateType.L4_SRC_PORT, 2},
			{(ushort)TemplateType.IPV4_SRC_ADDR, 4},
			{(ushort)TemplateType.SRC_MASK, 1},
			{(ushort)TemplateType.INPUT_SNMP, 2},
			{(ushort)TemplateType.L4_DST_PORT, 2},
			{(ushort)TemplateType.IPV4_DST_ADDR, 4},
			{(ushort)TemplateType.DST_MASK, 1},
			{(ushort)TemplateType.OUTPUT_SNMP, 2},
			{(ushort)TemplateType.IPV4_NEXT_HOP, 4},
			{(ushort)TemplateType.SRC_AS, 2},
			{(ushort)TemplateType.DST_AS, 2},
			{(ushort)TemplateType.BGP_IPV4_NEXT_HOP, 4},
			{(ushort)TemplateType.MUL_DST_PKTS, 4},
			{(ushort)TemplateType.MUL_DST_BYTES, 4},
			{(ushort)TemplateType.LAST_SWITCHED, 4},
			{(ushort)TemplateType.FIRST_SWITCHED, 4},
			{(ushort)TemplateType.OUT_BYTES, 4},
			{(ushort)TemplateType.OUT_PKTS, 4},
			{(ushort)TemplateType.MIN_PKT_LNGTH, 2},
			{(ushort)TemplateType.MAX_PKT_LNGTH, 2},
			{(ushort)TemplateType.IPV6_SRC_ADDR, 16},
			{(ushort)TemplateType.IPV6_DST_ADDR, 16},
			{(ushort)TemplateType.IPV6_SRC_MASK, 1},
			{(ushort)TemplateType.IPV6_DST_MASK, 1},
			{(ushort)TemplateType.IPV6_FLOW_LABEL, 3},
			{(ushort)TemplateType.ICMP_TYPE, 2},
			{(ushort)TemplateType.MUL_IGMP_TYPE, 1},
			{(ushort)TemplateType.SAMPLING_INTERVAL, 4},
			{(ushort)TemplateType.SAMPLING_ALGORITHM, 1},
			{(ushort)TemplateType.FLOW_ACTIVE_TIMEOUT, 2},
			{(ushort)TemplateType.FLOW_INACTIVE_TIMEOUT, 2},
			{(ushort)TemplateType.ENGINE_TYPE, 1},
			{(ushort)TemplateType.ENGINE_ID, 1},
			{(ushort)TemplateType.TOTAL_BYTES_EXP, 4},
			{(ushort)TemplateType.TOTAL_PKTS_EXP, 4},
			{(ushort)TemplateType.TOTAL_FLOWS_EXP, 4},
			{(ushort)TemplateType.VENDOR_PROP43, 4},
			{(ushort)TemplateType.IPV4_SRC_PREFIX, 4},
			{(ushort)TemplateType.IPV4_DST_PREFIX, 4},
			{(ushort)TemplateType.MPLS_TOP_LABEL_TYPE, 1},
			{(ushort)TemplateType.MPLS_TOP_LABEL_IP_ADDR, 4},
			{(ushort)TemplateType.FLOW_SAMPLER_ID, 1},
			{(ushort)TemplateType.FLOW_SAMPLER_MODE, 1},
			{(ushort)TemplateType.FLOW_SAMPLER_RANDOM_INTERVAL, 4},
			{(ushort)TemplateType.VENDOR_PROP51, 4},
			{(ushort)TemplateType.MIN_TTL, 1},
			{(ushort)TemplateType.MAX_TTL, 1},
			{(ushort)TemplateType.IPV4_IDENT, 2},
			{(ushort)TemplateType.DST_TOS, 1},
			{(ushort)TemplateType.IN_SRC_MAC, 6},
			{(ushort)TemplateType.OUT_DST_MAC, 6},
			{(ushort)TemplateType.SRC_VLAN, 2},
			{(ushort)TemplateType.DST_VLAN, 2},
			{(ushort)TemplateType.IP_PROTOCOL_VERSION, 1},
			{(ushort)TemplateType.DIRECTION, 1},
			{(ushort)TemplateType.IPV6_NEXT_HOP, 16},
			{(ushort)TemplateType.BPG_IPV6_NEXT_HOP, 16},
			{(ushort)TemplateType.IPV6_OPTION_HEADERS, 4},
			{(ushort)TemplateType.VENDOR_PROP65, 4},
			{(ushort)TemplateType.VENDOR_PROP66, 4},
			{(ushort)TemplateType.VENDOR_PROP67, 4},
			{(ushort)TemplateType.VENDOR_PROP68, 4},
			{(ushort)TemplateType.VENDOR_PROP69, 4},
			{(ushort)TemplateType.MPLS_LABEL_1, 3},
			{(ushort)TemplateType.MPLS_LABEL_2, 3},
			{(ushort)TemplateType.MPLS_LABEL_3, 3},
			{(ushort)TemplateType.MPLS_LABEL_4, 3},
			{(ushort)TemplateType.MPLS_LABEL_5, 3},
			{(ushort)TemplateType.MPLS_LABEL_6, 3},
			{(ushort)TemplateType.MPLS_LABEL_7, 3},
			{(ushort)TemplateType.MPLS_LABEL_8, 3},
			{(ushort)TemplateType.MPLS_LABEL_9, 3},
			{(ushort)TemplateType.MPLS_LABEL_10, 3},
			{(ushort)TemplateType.IN_DST_MAC, 6},
			{(ushort)TemplateType.OUT_SRC_MAC, 6},
			{(ushort)TemplateType.IF_NAME, 4},
			{(ushort)TemplateType.IF_DESC, 4},
			{(ushort)TemplateType.SAMPLER_NAME, 4},
			{(ushort)TemplateType.IN_PERMANENT_BYTES, 4},
			{(ushort)TemplateType.IN_PERMANENT_PKTS, 4},
			{(ushort)TemplateType.VENDOR_PROP87, 4},
			{(ushort)TemplateType.FRAGMENT_OFFSET, 2},
			{(ushort)TemplateType.FORWARDING_STATUS, 1}
		};
		private V9TemplateList parent = null;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormV9Template(V9TemplateList p)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			// 
			// listBoxAll
			// 
			for (int i = 1; i<TemplateItem.Length; ++i) 
			{
				listBoxAll.Items.Add(TemplateItem[i]);
			}

			this.parent = p;
			ushort nextId = 256;
			foreach (netflow.V9Template t in parent.TemplateList) 
			{
				if (t.TemplateId >= nextId) 
				{
					++nextId;
				}
			}
			textBoxTemplateId.Text = nextId.ToString();
			btnAdd.Enabled = false;

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxTemplateId = new System.Windows.Forms.TextBox();
			this.btnAdd = new System.Windows.Forms.Button();
			this.listBoxAll = new System.Windows.Forms.ListBox();
			this.listBoxSelected = new System.Windows.Forms.ListBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btnMove = new System.Windows.Forms.Button();
			this.btnRemove = new System.Windows.Forms.Button();
			this.btnClear = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.textBoxFrequency = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(160, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Available Template Elements:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(24, 376);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Template ID";
			// 
			// textBoxTemplateId
			// 
			this.textBoxTemplateId.Location = new System.Drawing.Point(192, 376);
			this.textBoxTemplateId.MaxLength = 3;
			this.textBoxTemplateId.Name = "textBoxTemplateId";
			this.textBoxTemplateId.Size = new System.Drawing.Size(48, 20);
			this.textBoxTemplateId.TabIndex = 3;
			this.textBoxTemplateId.Text = "";
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(224, 448);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.TabIndex = 4;
			this.btnAdd.Text = "Add";
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// listBoxAll
			// 
			this.listBoxAll.Location = new System.Drawing.Point(24, 48);
			this.listBoxAll.Name = "listBoxAll";
			this.listBoxAll.Size = new System.Drawing.Size(200, 303);
			this.listBoxAll.TabIndex = 5;
			this.listBoxAll.DoubleClick += new System.EventHandler(this.listBoxAll_DoubleClick);
			// 
			// listBoxSelected
			// 
			this.listBoxSelected.Location = new System.Drawing.Point(288, 48);
			this.listBoxSelected.Name = "listBoxSelected";
			this.listBoxSelected.Size = new System.Drawing.Size(200, 303);
			this.listBoxSelected.TabIndex = 6;
			this.listBoxSelected.DoubleClick += new System.EventHandler(this.listBoxSelected_DoubleClick);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(288, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(184, 16);
			this.label3.TabIndex = 7;
			this.label3.Text = "Selected Elements:";
			// 
			// btnMove
			// 
			this.btnMove.Location = new System.Drawing.Point(232, 128);
			this.btnMove.Name = "btnMove";
			this.btnMove.Size = new System.Drawing.Size(40, 23);
			this.btnMove.TabIndex = 8;
			this.btnMove.Text = ">";
			this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
			// 
			// btnRemove
			// 
			this.btnRemove.Location = new System.Drawing.Point(232, 184);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(40, 23);
			this.btnRemove.TabIndex = 9;
			this.btnRemove.Text = "<";
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			// 
			// btnClear
			// 
			this.btnClear.Location = new System.Drawing.Point(232, 240);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(40, 23);
			this.btnClear.TabIndex = 10;
			this.btnClear.Text = "<<";
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(24, 408);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(160, 16);
			this.label4.TabIndex = 12;
			this.label4.Text = "Send the template once every";
			// 
			// textBoxFrequency
			// 
			this.textBoxFrequency.Location = new System.Drawing.Point(192, 408);
			this.textBoxFrequency.MaxLength = 3;
			this.textBoxFrequency.Name = "textBoxFrequency";
			this.textBoxFrequency.Size = new System.Drawing.Size(48, 20);
			this.textBoxFrequency.TabIndex = 13;
			this.textBoxFrequency.Text = "20";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(264, 408);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(48, 16);
			this.label5.TabIndex = 14;
			this.label5.Text = "packets";
			// 
			// FormV9Template
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(512, 493);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.textBoxFrequency);
			this.Controls.Add(this.textBoxTemplateId);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.btnClear);
			this.Controls.Add(this.btnRemove);
			this.Controls.Add(this.btnMove);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.listBoxSelected);
			this.Controls.Add(this.listBoxAll);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormV9Template";
			this.Text = "Add / Edit V9 Template";
			this.ResumeLayout(false);

		}
		#endregion

		private void btnMove_Click(object sender, System.EventArgs e)
		{
			if (listBoxAll.SelectedIndex == -1)
				return;
			if (listBoxSelected.Items.IndexOf(listBoxAll.SelectedItem) == -1) 
			{
				listBoxSelected.Items.Add(listBoxAll.SelectedItem);
				btnAdd.Enabled = true;
			}
		}

		private void btnRemove_Click(object sender, System.EventArgs e)
		{
			if (listBoxSelected.SelectedIndex == -1)
				return;
			listBoxSelected.Items.RemoveAt(listBoxSelected.SelectedIndex);
			if (listBoxSelected.Items.Count == 0) 
			{
				btnAdd.Enabled = false;
			}
		}

		private void btnClear_Click(object sender, System.EventArgs e)
		{
			listBoxSelected.Items.Clear();
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			ushort id;
			ushort frequency;
			try 
			{
				id = Convert.ToUInt16(textBoxTemplateId.Text);
				frequency = Convert.ToUInt16(textBoxFrequency.Text);
				if (id<256) 
				{
					MessageBox.Show(this,"Invalid Template Id");
					textBoxTemplateId.Focus();
					DialogResult = DialogResult.None;
					return;
				}
				foreach (netflow.V9Template t in parent.TemplateList) 
				{
					if (id == t.TemplateId) 
					{
						MessageBox.Show(this,"The specified template id is already used.");
						textBoxTemplateId.Focus();
						DialogResult = DialogResult.None;
						return;
					}
				}
				if (frequency <= 10) 
				{
					if (MessageBox.Show(this, "The template send frequency is too low. Are you sure you want to do this?",
						"Confirm", MessageBoxButtons.YesNo) == DialogResult.No) 
					{
						textBoxFrequency.Focus();
						return;
					}
				}

			} 
			catch (FormatException fe) 
			{
				MessageBox.Show(this,fe.Message);
				textBoxTemplateId.Focus();
				DialogResult = DialogResult.None;
				return;
			}
			netflow.V9Template template = new netflow.V9Template(id);
			template.SendFrequency = frequency;
			foreach (string item in listBoxSelected.Items) 
			{
				ushort type = 0;
				ushort length;
				int i = listBoxAll.FindString(item);
				if (i != -1) 
				{
					type = (ushort) (i+1);
				}
				length = TemplateItemSize[type-1,1];
				template.AddField(type, length);
			}
			parent.TemplateList.Add(template);
			DialogResult = DialogResult.OK;
		}

		private void listBoxAll_DoubleClick(object sender, System.EventArgs e)
		{
			btnMove_Click(sender, e);
		}

		private void listBoxSelected_DoubleClick(object sender, System.EventArgs e)
		{
			btnRemove_Click(sender, e);
		}
	}
}

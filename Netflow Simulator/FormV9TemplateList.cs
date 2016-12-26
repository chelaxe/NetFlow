using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace flowsimulator {
    /// <summary>
    /// Summary description for V9TemplateList.
    /// </summary>
    public class V9TemplateList : System.Windows.Forms.Form {
        private System.Windows.Forms.ListBox listDetails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ListBox listTemplates;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public V9TemplateList() {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
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
            this.listDetails = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.listTemplates = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listDetails
            // 
            this.listDetails.Location = new System.Drawing.Point(222, 35);
            this.listDetails.Name = "listDetails";
            this.listDetails.Size = new System.Drawing.Size(159, 212);
            this.listDetails.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Defined Template";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(219, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Details";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(305, 266);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(25, 266);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(165, 266);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // listTemplates
            // 
            this.listTemplates.Location = new System.Drawing.Point(16, 35);
            this.listTemplates.Name = "listTemplates";
            this.listTemplates.Size = new System.Drawing.Size(167, 212);
            this.listTemplates.TabIndex = 7;
            this.listTemplates.SelectedIndexChanged += new System.EventHandler(this.listTemplates_SelectedIndexChanged);
            // 
            // V9TemplateList
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(405, 313);
            this.Controls.Add(this.listTemplates);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "V9TemplateList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "V9 Template List";
            this.ResumeLayout(false);

        }
        #endregion

        private void btnAdd_Click(object sender, System.EventArgs e) {
            FormV9Template form = new FormV9Template(this);
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog() == DialogResult.OK) {
                listTemplates.Items.Clear();
                foreach (netflow.V9Template template in v9Templates) {
                    listTemplates.Items.Add(template.TemplateId);
                    listTemplates.SelectedIndex = -1;
                }
                form.Close();
            }
        }

        private ArrayList v9Templates;

        public ArrayList V9Templates {
            set {
                v9Templates = value;
                foreach (netflow.V9Template template in v9Templates) {
                    listTemplates.Items.Add(template.TemplateId);
                    listTemplates.SelectedIndex = -1;
                }
            }
        }
        public ArrayList TemplateList {
            get {
                return v9Templates;
            }
        }

        private void listTemplates_SelectedIndexChanged(object sender, System.EventArgs e) {
            int index = listTemplates.SelectedIndex;
            if (index == -1) {
                btnDelete.Enabled = false;
                return;
            }
            btnDelete.Enabled = true;

            listDetails.Items.Clear();
            ushort templateId = (ushort)listTemplates.SelectedItem;
            netflow.V9Template t = null;
            foreach (netflow.V9Template tt in v9Templates) {
                if (tt.TemplateId == templateId) {
                    t = tt;
                    break;
                }
            }
            if (t == null) {
                MessageBox.Show(this, "Internal inconsistency!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ArrayList fields = t.GetFields();
            foreach (netflow.V9TemplateField field in fields) {
                listDetails.Items.Add(FormV9Template.TemplateItem[field.Type]);
            }
        }

        private void btnDelete_Click(object sender, System.EventArgs e) {
            int index = listTemplates.SelectedIndex;
            if (index == -1) {
                return;
            }
            if (MessageBox.Show(this, "Are you sure to delete this template?", "Confirm", MessageBoxButtons.YesNo) ==
                DialogResult.No) {
                return;
            }
            ushort id = (ushort)listTemplates.SelectedItem;
            foreach (netflow.V9Template tt in v9Templates) {
                if (tt.TemplateId == id) {
                    v9Templates.Remove(tt);
                    break;
                }
            }
            listDetails.Items.Clear();
            listTemplates.Items.RemoveAt(index);
            btnDelete.Enabled = false;
            listTemplates.SelectedIndex = -1;
        }

        private void btnOK_Click(object sender, System.EventArgs e) {
            DialogResult = (listTemplates.Items.Count == 0) ? DialogResult.Cancel : DialogResult.OK;
        }
    }
}

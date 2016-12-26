using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace flowsimulator {
    public partial class FormIpfixTemplateList : Form {
        private ArrayList ipfixTemplates;
        public FormIpfixTemplateList() {
            InitializeComponent();
            btnDelete.Enabled = false;
        }
        public ArrayList IpfixTemplates {
            set {
                ipfixTemplates = value;
                foreach (netflow.IpfixTemplate template in ipfixTemplates) {
                    listBoxTemplates.Items.Add(template.TemplateId);
                    listBoxTemplates.SelectedIndex = -1;
                }
            }
        }
        public ArrayList TemplateList {
            get {
                return ipfixTemplates;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            FormIpfixTemplate form = new FormIpfixTemplate(this);
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog() == DialogResult.OK) {
                listBoxTemplates.Items.Clear();
                foreach (netflow.IpfixTemplate template in ipfixTemplates) {
                    listBoxTemplates.Items.Add(template.TemplateId);
                    listBoxTemplates.SelectedIndex = -1;
                }
                form.Close();
            }

        }
        private void listBoxTemplates_SelectedIndexChanged(object sender, System.EventArgs e) {
            int index = listBoxTemplates.SelectedIndex;
            if (index == -1) {
                btnDelete.Enabled = false;
                return;
            }
            btnDelete.Enabled = true;

            listDetails.Items.Clear();
            ushort templateId = (ushort)listBoxTemplates.SelectedItem;
            netflow.IpfixTemplate t = null;
            foreach (netflow.IpfixTemplate tt in ipfixTemplates) {
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
            foreach (netflow.IpfixTemplateField field in fields) {
                listDetails.Items.Add(FormIpfixTemplate.TemplateItem[field.elementId]);
            }
        }

        private void btnDelete_Click(object sender, System.EventArgs e) {
            DialogResult = DialogResult.None;
            int index = listBoxTemplates.SelectedIndex;
            if (index == -1) {
                return;
            }
            if (MessageBox.Show(this, "Are you sure to delete this template?", "Confirm", MessageBoxButtons.YesNo) ==
                DialogResult.No) {
                return;
            }
            ushort id = (ushort)listBoxTemplates.SelectedItem;
            foreach (netflow.IpfixTemplate tt in ipfixTemplates) {
                if (tt.TemplateId == id) {
                    ipfixTemplates.Remove(tt);
                    break;
                }
            }
            listDetails.Items.Clear();
            listBoxTemplates.Items.RemoveAt(index);
            btnDelete.Enabled = false;
            listBoxTemplates.SelectedIndex = -1;
        }

        private void btnOK_Click(object sender, System.EventArgs e) {
            DialogResult = (listBoxTemplates.Items.Count == 0) ? DialogResult.Cancel : DialogResult.OK;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialToolSet
{
    public partial class LogSettingsForm : Form
    {
        private LogSettings data;

        public LogSettingsForm(ref LogSettings data)
        {
            this.data = data;
            InitializeComponent();
        }

        private void LogSettingsForm_Load(object sender, EventArgs e)
        {
            List<string> init_strs = data.GetSettings();
            txtItemName.Text = init_strs[0];
            txtItemPartNumber.Text = init_strs[1];
            txtRevision.Text = init_strs[2];
            txtSerialNumber.Text = init_strs[3];
            txtEngineerName.Text = init_strs[4];
            txtPath.Text = init_strs[5];
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            data.Update(txtItemName.Text, txtItemPartNumber.Text,
                        txtRevision.Text, txtSerialNumber.Text,
                        txtEngineerName.Text, txtPath.Text);
            this.Close();
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = txtPath.Text;
            DialogResult result = folderBrowserDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                txtPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}

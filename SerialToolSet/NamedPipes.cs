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
    public partial class NamedPipes : Form
    {
        private NamedPipeStore pipe_store;
        public NamedPipes(ref NamedPipeStore pipes)
        {
            this.pipe_store = pipes;
            InitializeComponent();
        }

        private void NamedPipes_Load(object sender, EventArgs e)
        {
            foreach (NamedPipeStore.Pipe p in pipe_store.pipe_list)
            {
                lstPipes.Items.Add(p.name);
            }
            if (lstPipes.Items.Count > 0)
            {
                btnClear.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstPipes.SelectedIndex != -1)
            {
                string pipe_name = lstPipes.SelectedItem.ToString();
                lstPipes.Items.Remove(lstPipes.Items[lstPipes.SelectedIndex]);
                this.pipe_store.DeletePipe(pipe_name);
            }
            if (lstPipes.Items.Count == 0)
            {
                btnDelete.Enabled = false;
                btnClear.Enabled = false;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            pipe_store.ResetPipes();
            lstPipes.Items.Clear();
            btnDelete.Enabled = false;
            btnClear.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool has_error = false;
            if (txtName.Text.Length == 0)
            {
                has_error = true;
                MessageBox.Show("The Pipe name is empty.", "Name Error", MessageBoxButtons.OK);
            }

            if (txtName.Text.Length > 256)
            {
                has_error = true;
                MessageBox.Show("The Pipe name exceeds a character limit of 256.", "Name Error", MessageBoxButtons.OK);
            }

            if (txtName.Text.Contains('\\'))
            {
                has_error = true;
                MessageBox.Show("The Pipe name contains \\ which is illegal.", "Name Error", MessageBoxButtons.OK);
            }

            if (pipe_store.HasPipe(txtName.Text.ToString()))
            {
                has_error = true;
                MessageBox.Show("The Pipe name already exists.", "Name Error", MessageBoxButtons.OK);
            }

            if (!has_error)
            {
                lstPipes.Items.Add(txtName.Text.ToString());
                pipe_store.AddPipe(txtName.Text.ToString(), chkCreate.Checked);
                txtName.Text = "";
                btnDelete.Enabled = true;
                btnClear.Enabled = true;
            }
        }
    }
}

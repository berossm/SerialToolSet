using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace SerialToolSet
{
    public partial class SerialToolSet : Form
    {
        private delegate void DUpdate(EventArgs e);
        private Delegate SerialStringDelegate;
        private Delegate SerialRawDelegate;
        private ConcurrentQueue<string> update_text;
        private const int buffer_size = 1024;
        private ConcurrentQueue<Byte> read_queue;
        private CommObjects comm_helper;
        private LogSettings log_helper;
        private NamedPipeStore pipes;
        private bool BCD = false;

        public SerialToolSet()
        {
            InitializeComponent();
        }

        private void SerialToolSet_Load(object sender, EventArgs e)
        {
            comm_helper = new CommObjects();
            List<string> tmp_str = new List<string>();
            cmboPort.Items.AddRange(comm_helper.populate_com(ref tmp_str).ToArray());
            log_helper = new LogSettings(System.IO.Directory.GetCurrentDirectory());
            serialPort1.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            SerialStringDelegate = new DUpdate(UpdateText);
            SerialRawDelegate = new DUpdate(UpdateRaw);
            cmboBaud.SelectedIndex = 3;
            cmboParity.SelectedIndex = 0;
            cmboDataBits.SelectedIndex = 0;
            cmboStopBits.Items.AddRange(Enum.GetNames(typeof(System.IO.Ports.StopBits)));
            cmboStopBits.SelectedIndex = 1;
            mnuByteOrder.SelectedIndex = 0;
            cmboChecksum.SelectedIndex = 0;
            update_text = new ConcurrentQueue<string>();
            read_queue = new ConcurrentQueue<byte>();
            try
            {
                log_helper.SetUser(System.DirectoryServices.AccountManagement.UserPrincipal.Current.DisplayName);
            }
            catch
            {
                log_helper.SetUser("");
            }
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!BCD)
            {
                BCD = true;
                DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    BCD = false;
                    e.Cancel = true;
                }
                else
                {
                    base.OnFormClosing(e);
                }
            }            
        }

        private void UpdateText(EventArgs e)
        {
            while (!update_text.IsEmpty)
            {
                string current_line;
                if (update_text.TryDequeue(out current_line))
                {
                    if (current_line == "<clr>")
                    {
                        txtRecieve.Text = "";
                        log_helper.LogString(System.Environment.NewLine +
                            "---------------------------------Screen Cleared---------------------------------" +
                            System.Environment.NewLine);
                    }
                    else
                    {
                        txtRecieve.AppendText(current_line + System.Environment.NewLine);
                        log_helper.LogString(current_line);
                    }
                }
            }
        }

        private void UpdateRaw(EventArgs e)
        {
            try
            {
                string new_text = "";
                Byte next_byte;
                while (!read_queue.IsEmpty)
                {
                    if (read_queue.TryDequeue(out next_byte))
                    {
                        new_text += CommObjects.hex_to_text(next_byte);
                    }
                }
                txtRecieve.AppendText(new_text);
                log_helper.LogString(new_text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "UpdateRaw has failed.", MessageBoxButtons.OK);
            }

        }

        private void DataReceivedHandler(
                            object sender,
                            SerialDataReceivedEventArgs e)
        {

            SerialPort sp = (SerialPort)sender;
            if (mnuASCII.Checked)
            {
                bool end_of_data = false;
                while (!end_of_data)
                {
                    try
                    {
                        string text_read = sp.ReadLine();
                        text_read = text_read.Trim();
                        update_text.Enqueue(text_read);
                    }
                    catch (TimeoutException)
                    {
                        end_of_data = true;
                    }
                }
                if (InvokeRequired == true) { BeginInvoke(SerialStringDelegate, e); }
                else { UpdateText(e); }

            }
            else
            {
                Byte[] read_buffer = new Byte[buffer_size];
                int read_bytes = 0;
                read_bytes += sp.Read(read_buffer, read_bytes, buffer_size);
                for (int byte_num = 0; byte_num < read_bytes; byte_num++)
                {
                    read_queue.Enqueue(read_buffer[byte_num]);
                }
                if (InvokeRequired == true) { BeginInvoke(SerialRawDelegate, e); }
                else { UpdateRaw(e); }
            }

        }

        private void mnuLogSettings_Click(object sender, EventArgs e)
        {
            LogSettingsForm log_form = new LogSettingsForm(ref log_helper);
            log_form.ShowDialog(this);
        }

        private void mnuConnect_Click(object sender, EventArgs e)
        {
            if (mnuLoggingEnabled.Checked)
            {
                string log_error = "";
                if (!log_helper.Start(ref log_error))
                {
                    MessageBox.Show(log_error, "Logging Error", MessageBoxButtons.OK);
                    return;
                }
                bool create_pipe = false;
                string com;
                string selected_com = cmboPort.SelectedItem.ToString();
                if (selected_com.StartsWith("\\\\.\\pipe\\"))
                {
                    string pipe_name = selected_com.Substring(selected_com.LastIndexOf('\\') + 1);
                    com = selected_com;
                    create_pipe = pipes.HasCreateFlag(pipe_name);
                }
                else
                {
                    int port_start = selected_com.IndexOf("(") + 1;
                    int com_len = selected_com.IndexOf(")") - port_start;
                    com = selected_com.Substring(port_start, com_len);
                }
                Connect(com, create_pipe);
            }
            
        }

        private void Connect(string portName, bool create_pipe)
        {
            //TODO: Deal with create_pipe/pipes in general
            if (!serialPort1.IsOpen)
            {
                int selected_rate;
                if (int.TryParse(cmboBaud.SelectedItem.ToString(), out selected_rate))
                {
                    serialPort1.PortName = portName;
                    serialPort1.BaudRate = selected_rate;
                    serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), cmboParity.SelectedItem.ToString());
                    serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cmboStopBits.SelectedItem.ToString());
                    serialPort1.ReadTimeout = 500;
                    serialPort1.Open();
                    serialPort1.WriteLine("");
                    mnuConnect.Enabled = false;
                    mnuDisconnect.Enabled = false;
                    btnSend.Enabled = true;
                    mnuLogSettings.Enabled = false;
                    txtSend.Enabled = true;
                    mnuEncoding.Enabled = false;
                    mnuSerialSettings.Enabled = false;
                    mnuLoggingEnabled.Enabled = false;
                    txtSend.Focus();
                    txtRecieve.Text = "";
                    txtChecksum.Text = "";

                    while (!update_text.IsEmpty)
                    {
                        string junk_string;
                        update_text.TryDequeue(out junk_string);
                    }

                    while (!read_queue.IsEmpty)
                    {
                        Byte junk_byte;
                        read_queue.TryDequeue(out junk_byte);
                    }

                    if (mnuData8.Checked)
                    {
                        statConnection.Text = "8-Bit HEX";
                        //TODO: Update for more data formats
                        txtSend.BackColor = Color.Red;
                        txtSend.CharacterCasing = CharacterCasing.Upper;
                        toolTip1.SetToolTip(txtSend, "Only 0-9 & A-F are valid characters.  Do not includes 0x in front of values.  Spaces are optional.");
                    }
                    else if (mnuASCII.Checked)
                    {
                        statConnection.Text = "ASCII";
                        toolTip1.SetToolTip(txtSend, "All displayable characters allowed.");
                    }
                }
                else
                {
                    MessageBox.Show("Baud rate error.", "Serial Fault.", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Serial port already open.", "Serial Fault.", MessageBoxButtons.OK);
            }
        }

        private void Close_Connection()
        {
            serialPort1.Close();
            mnuConnect.Enabled = true;
            mnuDisconnect.Enabled = false;
            btnSend.Enabled = false;
            mnuLogSettings.Enabled = true;
            txtSend.Enabled = false;
            mnuEncoding.Enabled = true;
            mnuSerialSettings.Enabled = true;
            mnuLoggingEnabled.Enabled = true;
            if (mnuLoggingEnabled.Checked)
            {
                log_helper.End();
            }
            statConnection.Text = "Disconnected";
            txtSend.CharacterCasing = CharacterCasing.Normal;
            txtSend.BackColor = Color.White;
            toolTip1.SetToolTip(txtSend, null);
        }

        private void txtSend_TextChanged(object sender, EventArgs e)
        {
            //TODO: Update for encoding and checksum
            if (mnuASCII.Checked)
            {
                return;
            }
            else
            if (CommObjects.validate_hex_string(txtSend.Text, CommObjects.DATASIZE.BIT_8))
            {
                if (cmboChecksum.SelectedIndex == (int)CommObjects.CHECKSUM.BIT72COMP)
                {
                    txtSend.BackColor = Color.White; //TODO: Is this the correct place?
                    Checksums.SevenBitSumTwosCompChecksum(txtSend.Text, buffer_size);
                }
                else
                {
                    txtSend.BackColor = Color.White;
                    txtChecksum.Text = "";
                }

            }
            else
            {
                txtSend.BackColor = Color.Red;
                txtChecksum.Text = "";
            }
        }

        private void txtSend_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (mnuASCII.Checked)
                {
                    send_ascii();
                }
                else if (mnuData8.Checked)
                {
                    send_raw();
                }

            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (mnuASCII.Checked)
            {
                send_ascii();
            }
            else if (mnuData8.Checked)
            {
                send_raw();
            }
        }

        private void send_ascii()
        {
            try
            {
                serialPort1.WriteLine(txtSend.Text);
                txtRecieve.AppendText(">>> " + txtSend.Text + System.Environment.NewLine);
                log_helper.LogString(">>> " + txtSend.Text);
                txtSend.Text = "";
            }
            catch (InvalidOperationException e)
            {
                txtRecieve.AppendText(">>> SERIAL CONNECTION LOST!" + System.Environment.NewLine);
                log_helper.LogString(">>> SERIAL CONNECTION LOST!  " + e.Message);
                Close_Connection();
            }

        }

        private void send_raw()
        {
            Byte[] write_buffer;
            int write_bytes = 0;
            string output_str;
            //TODO: Add data encoding settings
            if (CommObjects.validate_hex_string(txtSend.Text, CommObjects.DATASIZE.BIT_8))
            {
                write_bytes = CommObjects.text_to_hex(txtSend.Text, out write_buffer, out output_str, buffer_size);
                try
                {
                    serialPort1.Write(write_buffer, 0, write_bytes);
                    txtRecieve.AppendText(output_str + System.Environment.NewLine);
                    log_helper.LogString(output_str);
                    txtSend.Text = "";
                }
                catch (InvalidOperationException e)
                {
                    txtRecieve.AppendText(">>> SERIAL CONNECTION LOST!" + System.Environment.NewLine);
                    log_helper.LogString(">>> SERIAL CONNECTION LOST!  " + e.Message);
                    Close_Connection();
                }
            }
        }
    }
}

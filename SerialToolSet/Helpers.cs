using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SerialToolSet
{
    public class CommObjects
    {
        private List<string> ports;

        public CommObjects()
        {
            List<string> tmp_str = new List<string>();
            ports = new List<string>();
            populate_com(ref tmp_str);
        }

        public List<string> populate_com(ref List<string> pipes)
        {
            ports.Clear();
            System.Management.ManagementObjectSearcher manObjSearch = new System.Management.ManagementObjectSearcher("root\\CIMV2",
                                       "SELECT * FROM Win32_PnPEntity WHERE ClassGuid=\"{4d36e978-e325-11ce-bfc1-08002be10318}\"");
            System.Management.ManagementObjectCollection manObjReturn = manObjSearch.Get();

            foreach (System.Management.ManagementObject manObj in manObjReturn)
            {
                string name = manObj["Name"].ToString();
                if (!name.Contains("LPT"))
                {
                    ports.Add(name);
                }
            }
            foreach (string pipe in pipes)
            {
                ports.Add("\\\\.\\pipe\\" + pipe);
            }
            return ports;
        }

        public List<string> get_ports()
        {
            return ports;
        }
        public static string hex_to_text(Byte data)
        {
            string new_text = "";
            int second_digit = (data % 16);
            int first_digit = (data - second_digit) / 16;
            if (first_digit <= 9)
            {
                new_text += (char)(first_digit + (int)'0');
            }
            else
            {
                new_text += (char)(first_digit - 10 + (int)'A');
            }
            if (second_digit <= 9)
            {
                new_text += (char)(second_digit + (int)'0');
            }
            else
            {
                new_text += (char)(second_digit - 10 + (int)'A');
            }
            new_text += " ";
            return new_text;
        }

        public enum CHECKSUM
        {
            NONE = 0,
            BIT72COMP
        }        

        public enum DATASIZE
        {
            BIT_8 = 2,
            BIT_16 = 4,
            BIT_32 = 8
        }

        public static bool validate_hex_string(string data, DATASIZE nibbs)
        {
            //TODO: Update for other encoding
            bool validated = false;
            Regex regex = new Regex("^[A-F0-9]*$");
            string check_data = data.ToUpper().Replace(" ", "");
            if (regex.IsMatch(check_data))
            {
                if (check_data.Length % (int)nibbs == 0)
                {
                    validated = true;
                }
            }
            return validated;
        }

        static public int text_to_hex(string input, out Byte[] data, out string output_string, int buffer_size)
        {
            int write_bytes = 0;
            data = new Byte[buffer_size];
            string compressed_hex = input.ToUpper().Replace(" ", "");
            output_string = System.Environment.NewLine + ">>> ";
            for (int byte_num = 0; byte_num < (compressed_hex.Length / 2); byte_num++)
            {
                int first_index = byte_num * 2;
                int second_index = first_index + 1;
                int first_char = (int)compressed_hex[first_index];
                int second_char = (int)compressed_hex[second_index];
                output_string += compressed_hex.Substring(first_index, 2) + " ";
                if (first_char <= (int)'9')
                {
                    first_char -= (int)'0';
                }
                else
                {
                    first_char -= ((int)'A' - 10);
                }
                if (second_char <= (int)'9')
                {
                    second_char -= (int)'0';
                }
                else
                {
                    second_char -= ((int)'A' - 10);
                }
                data[byte_num] = (Byte)(first_char * 16 + second_char);
                write_bytes++;
            }
            return write_bytes;
        }
    }

    public class LogSettings
    {
        private string path;
        private string part_name;
        private string part_number;
        private string part_revision;
        private string user;
        private string serial_number;
        private bool logging;
        private System.IO.StreamWriter log_file;

        public LogSettings(string path)
        {
            this.path = path;
            this.part_name = "";
            this.logging = false;
            this.part_number = "";
            this.serial_number = "";
        }

        public void SetUser(string user)
        {
            this.user = user;
        }

        public void LogString(string text)
        {
            if (logging)
            {
                log_file.WriteLine(text);
            }
        }

        public List<string> GetSettings()
        {
            List<string> temp = new List<string>
            {
                this.part_name,
                this.part_number,
                this.part_revision,
                this.serial_number,
                this.user,
                this.path
            };
            return temp;
        }

        public void Update(string part_name, string part_number, string part_revision,
                           string serial_number, string user, string path)
        {
            this.part_name = part_name;
            this.part_number = part_number;
            this.part_revision = part_revision;
            this.serial_number = serial_number;
            this.user = user;
            this.path = path;
        }

        public bool Start(ref string error_msg)
        {
            if (logging)
            {
                error_msg = "Log already running.\n";
                return false;
            }
            if (!System.IO.Directory.Exists(this.path))
            {
                error_msg = "The logging file path is invalid.\n";
                return false;
            }
            string timestamp = DateTime.Now.ToString("s", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"));
            string log_file_name = "Log";
            if (this.part_number != "")
            {
                log_file_name += "_PN_" + this.part_number;
            }
            if (this.part_revision != "")
            {
                log_file_name += "_Rev_" + this.part_revision;
            }
            if (this.serial_number != "")
            {
                log_file_name += "_SN_" + this.part_revision;
            }
            log_file_name += "_" + timestamp + ".log";
            log_file_name = log_file_name.Replace(" ", "_");
            log_file_name = log_file_name.Replace(":", "-");
            log_file_name = log_file_name.Replace("<", "_");
            log_file_name = log_file_name.Replace(">", "_");
            log_file_name = log_file_name.Replace("\"", "_");
            log_file_name = log_file_name.Replace("/", "_");
            log_file_name = log_file_name.Replace("\\", "_");
            log_file_name = log_file_name.Replace("|", "_");
            log_file_name = log_file_name.Replace("?", "_");
            log_file_name = log_file_name.Replace("*", "_");
            string log_full_name = this.path + "\\" + log_file_name;
            if (System.IO.File.Exists(log_full_name))
            {
                error_msg = "The file already exists.\n";
                return false;
            }
            log_file = System.IO.File.CreateText(log_full_name);
            this.logging = true;
            this.LogString("################################################################################");
            this.LogString("## File:" + log_file_name);
            if (this.part_name != "")
            {
                this.LogString("## Part Name: " + this.part_name);
            }
            if (this.part_number != "")
            {
                this.LogString("## Part Number: " + this.part_number);
            }
            if (this.part_revision != "")
            {
                this.LogString("## Revision: " + this.part_revision);
            }
            if (this.serial_number != "")
            {
                this.LogString("## Serial Number: " + this.serial_number);
            }
            if (this.user != "")
            {
                this.LogString("## Created By: " + this.user);
            }
            this.LogString("## Log Started: " + timestamp);
            this.LogString("################################################################################");
            return true;
        }

        public bool End()
        {
            if (!logging)
            {
                return false;
            }
            this.log_file.Close();
            this.logging = false;
            return true;
        }
    }

    public class Checksums
    {
        static public string SevenBitSumTwosCompChecksum(string hex_str, int buffer_size)
        {
            
            Byte[] write_buffer = new Byte[buffer_size];
            int write_bytes = 0;
            string output_string;
            write_bytes = CommObjects.text_to_hex(hex_str, out write_buffer, out output_string, buffer_size);
            Byte byte_sum = 0;
            for (int i = 0; i < write_bytes; i++)
            {
                byte_sum += write_buffer[i];
            }
            byte_sum = (byte)~byte_sum;
            byte_sum += 1;
            byte_sum = (byte)(byte_sum & 0x7F);
            return CommObjects.hex_to_text(byte_sum);
        }
    }
}

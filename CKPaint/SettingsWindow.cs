using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace CKPaint
{
    public partial class SettingsWindow : Form
    {
        int badPasswordCount = 0;
        PLC AllenBradley = new PLC();
        bool plcConnected = false;


        public SettingsWindow()
        {
            InitializeComponent(); 
        }

        private void SettingsWindow_Load(object sender, EventArgs e)
        {
            printerTextBox.Text = CKPaint.Properties.Settings.Default["Printer"].ToString().Trim().ToUpper();
            stationComboBox.Text = CKPaint.Properties.Settings.Default["Station"].ToString().Trim().ToUpper();
            plantComboBox.Text = CKPaint.Properties.Settings.Default["Plant"].ToString().Trim().ToUpper();
            plcTextBox.Text = CKPaint.Properties.Settings.Default["PLC"].ToString().Trim();
            tagTextBox.Text = CKPaint.Properties.Settings.Default["Tag"].ToString().Trim();

            if(plantComboBox.Text == "BV")
            {
                siteTextBox.Text = "5130";
            } else if (plantComboBox.Text == "MP")
            {
                siteTextBox.Text = "5100";
            } else if (plantComboBox.Text == "GP")
            {
                siteTextBox.Text = "5140";
            }

        }

        private void SettingsWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (plcConnected == true)
            {
                AllenBradley.Disconnect();
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if(passwordTextBox.Text != "paintck")
            {
                badPasswordCount++;
                
                if(badPasswordCount >= 5)
                {
                    BadPassword badPasswordWindow = new BadPassword();
                    badPasswordWindow.ShowDialog();
                    badPasswordCount = 0;
                }

                return;
            }

            CKPaint.Properties.Settings.Default["Printer"] = printerTextBox.Text.ToString().Trim().ToUpper();
            CKPaint.Properties.Settings.Default["Station"] = stationComboBox.Text.ToString().Trim().ToUpper();
            CKPaint.Properties.Settings.Default["Plant"] = plantComboBox.Text.ToString().Trim().ToUpper();
            CKPaint.Properties.Settings.Default["Site"] = siteTextBox.Text.ToString().Trim().ToUpper();
            CKPaint.Properties.Settings.Default["PLC"] = plcTextBox.Text.ToString().Trim();
            CKPaint.Properties.Settings.Default["Tag"] = tagTextBox.Text.ToString().Trim();

            Properties.Settings.Default.Save();

            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            //Check if the IP address pings before attempting to connect to the PLC
            if (PingHost(plcTextBox.Text.ToString().Trim()) == true)
            {
                //Connect to the PLC
                plcConnected = AllenBradley.Connect(plcTextBox.Text.ToString().Trim());
                if (plcConnected == true)
                {
                    connectButton.Text = "Connected";
                    connectButton.Enabled = false;
                    connectButton.BackColor = Color.LimeGreen;
                    readButton.Enabled = true;
                }
                else
                {
                    MessageBox.Show("PLC Failed To Connect");
                }

            }
            else
            {
                MessageBox.Show("PLC IP Address supplied does not ping");
            }

        }

        private void readButtton_Click(object sender, EventArgs e)
        {
            string rslt = "";
            rslt = AllenBradley.ReadPLCStringTag(tagTextBox.Text.ToString().Trim());

            tagValueReadTextBox.Text = rslt;
        }

        private void writeButton_Click(object sender, EventArgs e)
        {
            bool rslt = false;
            rslt = AllenBradley.WritePLCTagString(tagTextBox.Text.ToString().Trim(), tagValueWriteTextBox.Text.ToString().Trim());

            if (rslt != true)
            {
                MessageBox.Show("PLC Tag Failed to Write");
            }

        }

        private void tagValueWriteTextBox_TextChanged(object sender, EventArgs e)
        {
            if (tagValueWriteTextBox.Text.Length > 0)
            {
                writeButton.Enabled = true;
            }
            else
            {
                writeButton.Enabled = false;
            }
        }

        private void plantComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (plantComboBox.Text == "BV")
            {
                siteTextBox.Text = "5130";
            }
            else if (plantComboBox.Text == "MP")
            {
                siteTextBox.Text = "5100";
            }
            else if (plantComboBox.Text == "GP")
            {
                siteTextBox.Text = "5140";
            }
        }

        public static bool PingHost(string nameOrAddress)
        {
            bool pingable = false;
            Ping pinger = null;

            try
            {
                pinger = new Ping();
                PingReply reply = pinger.Send(nameOrAddress);
                pingable = reply.Status == IPStatus.Success;

            }
            catch (PingException)
            {
                //Discard PingExceptions and return false
            }
            finally
            {
                if (pinger != null)
                {
                    pinger.Dispose();
                }
            }

            return pingable;
        }
    }
}

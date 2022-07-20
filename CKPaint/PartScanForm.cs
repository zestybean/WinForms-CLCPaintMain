using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Timers;
using System.Threading;


namespace CKPaint
{
    public partial class PartScanForm : Form
    {
        PLC AllenBradley = new PLC();

        System.Windows.Forms.Timer barcodeClearTimer = new System.Windows.Forms.Timer();

        List<string> scannedWOIDS = new List<string>();

        string barcode = "";
        string connStr_PBET = ConfigurationManager.ConnectionStrings["PBET"].ConnectionString;

        bool plcConnected = false;
        bool colorCodeMisMatch = false;

        public PartScanForm()
        {
            InitializeComponent();
        }
        private void PartScanForm_Load(object sender, EventArgs e)
        {
            //Connect to the PLC

            //Check if the IP address pings before attempting to connect to the PLC
            if (PingHost(CKPaint.Properties.Settings.Default["PLC"].ToString().Trim()) == true)
            {
                //Connect to the PLC
                plcConnected = AllenBradley.Connect(CKPaint.Properties.Settings.Default["PLC"].ToString().Trim());
                if (plcConnected == true)
                {
                    PLCTextBox.Text = "Connected";
                    PLCTextBox.ForeColor  = Color.LimeGreen;
                    PLCTextBox.BackColor  = PLCTextBox.BackColor;
                }
                else
                {
                    PLCTextBox.Text = "Disconnected";
                    PLCTextBox.ForeColor = Color.Red;
                    PLCTextBox.BackColor = PLCTextBox.BackColor;
                }

            }
            else
            {
                MessageBox.Show("PLC IP Address " + CKPaint.Properties.Settings.Default["PLC"].ToString().Trim() + " does not ping");
            }

            //Hide the control box (close, minimize, maximize)
            this.ControlBox = false;

            //Initialize the barcode clear timer
            barcodeClearTimer.Interval = 200;
            barcodeClearTimer.Tick += new EventHandler(BarcodeClearTimerTick);

        }
              

        private void PartScanForm_Shown(object sender, EventArgs e)
        {
            //Force the focus to the scan textbox for barcode scanning upon form being loaded and shown
            scanTextBox.Focus();
        }

        private void scanTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            //Check for enter key press
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                ProcessBarcode();
            }
            else if(scanTextBox.Text.ToString().Trim().Length == 7 || scanTextBox.Text.ToString().Trim() == "RESET")
            {
                ProcessBarcode();
            }
                       
        }
        private void scanTextBox_TextChanged(object sender, EventArgs e)
        {
            //Automatically clear out text so that typing isn't allowed
            barcodeClearTimer.Start();
        }

        private void BarcodeClearTimerTick(object sender, EventArgs e)
        {
            barcodeClearTimer.Stop();
            scanTextBox.Text = "";
        }
        private void ProcessBarcode()
        {

            barcode = scanTextBox.Text.ToString().Trim();

            if (barcode.Length > 0)
            {
                //The barcode "RESET" is the reset scan, otherwise it should be a WOID which is 7 digits
                if (barcode == "RESET")
                {
                    //Reset Code
                    statusTextBox.Text = "Reset Code Scanned";
                    statusTextBox.ForeColor = Color.Black;
                    statusTextBox.BackColor = statusTextBox.BackColor;

                    //Clear the fault condition and all scans
                    colorCodeMisMatch = false;
                    ClearScans();

                }
                else if (barcode.Length == 7 && colorCodeMisMatch != true && scannedWOIDS.Contains(barcode) == false)
                {
                    //WOID
                    statusTextBox.Text = "WOID: " + barcode + " Scanned";
                    statusTextBox.ForeColor = Color.Black;
                    statusTextBox.BackColor = statusTextBox.BackColor;
                    scannedWOIDS.Add(barcode);

                    //Query the WOID for the corresponding Color Code
                    string colorcode = QueryColorCode(barcode);
                    if (WOID1TextBox.Text.ToString().Trim() == "")
                    {
                        WOID1TextBox.Text = barcode;
                        colorCode1TextBox.Text = colorcode;
                        confirmScanButton.Enabled = true;
                    }
                    else if (WOID2TextBox.Text.ToString().Trim() == "")
                    {
                        WOID2TextBox.Text = barcode;
                        colorCode2TextBox.Text = colorcode;

                        //Check for color code match
                        if (colorCode1TextBox.Text == colorCode2TextBox.Text)
                        {
                            colorCode1TextBox.BackColor = Color.Green;
                            colorCode2TextBox.BackColor = Color.Green;
                        }
                        else
                        {
                            colorCode2TextBox.BackColor = Color.Red;
                            colorCodeMisMatch = true;
                            statusTextBox.Text = "Color Codes Do Match - Scan Reset Code";
                            statusTextBox.ForeColor = Color.Red;
                            statusTextBox.BackColor = statusTextBox.BackColor;
                            confirmScanButton.Enabled = false;
                            closeButton.Enabled = false;
                        }

                    }
                    else if (WOID3TextBox.Text.ToString().Trim() == "")
                    {
                        WOID3TextBox.Text = barcode;
                        colorCode3TextBox.Text = colorcode;

                        //Check for color code match
                        if (colorCode2TextBox.Text == colorCode3TextBox.Text)
                        {
                            colorCode3TextBox.BackColor = Color.Green;
                        }
                        else
                        {
                            colorCode3TextBox.BackColor = Color.Red;
                            colorCodeMisMatch = true;
                            statusTextBox.Text = "Color Codes Do Match - Scan Reset Code";
                            statusTextBox.ForeColor = Color.Red;
                            statusTextBox.BackColor = statusTextBox.BackColor;
                            confirmScanButton.Enabled = false;
                            closeButton.Enabled = false;
                        }
                    }
                    else if (WOID4TextBox.Text.ToString().Trim() == "")
                    {
                        WOID4TextBox.Text = barcode;
                        colorCode4TextBox.Text = colorcode;

                        //Check for color code match
                        if (colorCode3TextBox.Text == colorCode4TextBox.Text)
                        {
                            colorCode4TextBox.BackColor = Color.Green;
                        }
                        else
                        {
                            colorCode4TextBox.BackColor = Color.Red;
                            colorCodeMisMatch = true;
                            statusTextBox.Text = "Color Codes Do Match - Scan Reset Code";
                            statusTextBox.ForeColor = Color.Red;
                            statusTextBox.BackColor = statusTextBox.BackColor;
                            confirmScanButton.Enabled = false;
                            closeButton.Enabled = false;
                        }
                    }
                    else if (WOID5TextBox.Text.ToString().Trim() == "")
                    {
                        WOID5TextBox.Text = barcode;
                        colorCode5TextBox.Text = colorcode;

                        //Check for color code match
                        if (colorCode4TextBox.Text == colorCode5TextBox.Text)
                        {
                            colorCode5TextBox.BackColor = Color.Green;
                        }
                        else
                        {
                            colorCode5TextBox.BackColor = Color.Red;
                            colorCodeMisMatch = true;
                            statusTextBox.Text = "Color Codes Do Match - Scan Reset Code";
                            statusTextBox.ForeColor = Color.Red;
                            statusTextBox.BackColor = statusTextBox.BackColor;
                            confirmScanButton.Enabled = false;
                            closeButton.Enabled = false;
                        }
                    }
                    else if (WOID6TextBox.Text.ToString().Trim() == "")
                    {
                        WOID6TextBox.Text = barcode;
                        colorCode6TextBox.Text = colorcode;

                        //Check for color code match
                        if (colorCode5TextBox.Text == colorCode6TextBox.Text)
                        {
                            colorCode6TextBox.BackColor = Color.Green;
                        }
                        else
                        {
                            colorCode6TextBox.BackColor = Color.Red;
                            colorCodeMisMatch = true;
                            statusTextBox.Text = "Color Codes Do Match - Scan Reset Code";
                            statusTextBox.ForeColor = Color.Red;
                            statusTextBox.BackColor = statusTextBox.BackColor;
                            confirmScanButton.Enabled = false;
                            closeButton.Enabled = false;
                        }
                    }
                    else if (WOID7TextBox.Text.ToString().Trim() == "")
                    {
                        WOID7TextBox.Text = barcode;
                        colorCode7TextBox.Text = colorcode;

                        //Check for color code match
                        if (colorCode6TextBox.Text == colorCode7TextBox.Text)
                        {
                            colorCode7TextBox.BackColor = Color.Green;
                        }
                        else
                        {
                            colorCode7TextBox.BackColor = Color.Red;
                            colorCodeMisMatch = true;
                            statusTextBox.Text = "Color Codes Do Match - Scan Reset Code";
                            statusTextBox.ForeColor = Color.Red;
                            statusTextBox.BackColor = statusTextBox.BackColor;
                            confirmScanButton.Enabled = false;
                            closeButton.Enabled = false;
                        }
                    }
                    else if (WOID8TextBox.Text.ToString().Trim() == "")
                    {
                        WOID8TextBox.Text = barcode;
                        colorCode8TextBox.Text = colorcode;

                        //Check for color code match
                        if (colorCode7TextBox.Text == colorCode8TextBox.Text)
                        {
                            colorCode8TextBox.BackColor = Color.Green;
                        }
                        else
                        {
                            colorCode8TextBox.BackColor = Color.Red;
                            colorCodeMisMatch = true;
                            statusTextBox.Text = "Color Codes Do Match - Scan Reset Code";
                            statusTextBox.ForeColor = Color.Red;
                            statusTextBox.BackColor = statusTextBox.BackColor;
                            confirmScanButton.Enabled = false;
                            closeButton.Enabled = false;
                        }
                    }
                    else if (WOID9TextBox.Text.ToString().Trim() == "")
                    {
                        WOID9TextBox.Text = barcode;
                        colorCode9TextBox.Text = colorcode;

                        //Check for color code match
                        if (colorCode8TextBox.Text == colorCode9TextBox.Text)
                        {
                            colorCode9TextBox.BackColor = Color.Green;
                        }
                        else
                        {
                            colorCode9TextBox.BackColor = Color.Red;
                            colorCodeMisMatch = true;
                            statusTextBox.Text = "Color Codes Do Match - Scan Reset Code";
                            statusTextBox.ForeColor = Color.Red;
                            statusTextBox.BackColor = statusTextBox.BackColor;
                            confirmScanButton.Enabled = false;
                            closeButton.Enabled = false;
                        }
                    }
                    else if (WOID10TextBox.Text.ToString().Trim() == "")
                    {
                        WOID10TextBox.Text = barcode;
                        colorCode10TextBox.Text = colorcode;

                        //Check for color code match
                        if (colorCode9TextBox.Text == colorCode10TextBox.Text)
                        {
                            colorCode10TextBox.BackColor = Color.Green;
                        }
                        else
                        {
                            colorCode10TextBox.BackColor = Color.Red;
                            colorCodeMisMatch = true;
                            statusTextBox.Text = "Color Codes Do Match - Scan Reset Code";
                            statusTextBox.ForeColor = Color.Red;
                            statusTextBox.BackColor = statusTextBox.BackColor;
                            confirmScanButton.Enabled = false;
                            closeButton.Enabled = false;
                        }
                    }
                    else if (WOID11TextBox.Text.ToString().Trim() == "")
                    {
                        WOID11TextBox.Text = barcode;
                        colorCode11TextBox.Text = colorcode;

                        //Check for color code match
                        if (colorCode10TextBox.Text == colorCode11TextBox.Text)
                        {
                            colorCode11TextBox.BackColor = Color.Green;
                        }
                        else
                        {
                            colorCode11TextBox.BackColor = Color.Red;
                            colorCodeMisMatch = true;
                            statusTextBox.Text = "Color Codes Do Match - Scan Reset Code";
                            statusTextBox.ForeColor = Color.Red;
                            statusTextBox.BackColor = statusTextBox.BackColor;
                            confirmScanButton.Enabled = false;
                            closeButton.Enabled = false;
                        }
                    }
                    else if (WOID12TextBox.Text.ToString().Trim() == "")
                    {
                        WOID12TextBox.Text = barcode;
                        colorCode12TextBox.Text = colorcode;

                        //Check for color code match
                        if (colorCode11TextBox.Text == colorCode12TextBox.Text)
                        {
                            colorCode12TextBox.BackColor = Color.Green;
                        }
                        else
                        {
                            colorCode12TextBox.BackColor = Color.Red;
                            colorCodeMisMatch = true;
                            statusTextBox.Text = "Color Codes Do Match - Scan Reset Code";
                            statusTextBox.ForeColor = Color.Red;
                            statusTextBox.BackColor = statusTextBox.BackColor;
                            confirmScanButton.Enabled = false;
                            closeButton.Enabled = false;
                        }
                    }


                }
                else if (scannedWOIDS.Contains(barcode) == true)
                {
                    //Repeat barcode scanned
                    statusTextBox.Text = "WOID " + barcode + " Already Scanned";
                    statusTextBox.ForeColor = Color.Red;
                    statusTextBox.BackColor = statusTextBox.BackColor;
                }
                else
                {
                    //Invalid barcode
                    statusTextBox.Text = "Invalid Barcode: '" + barcode + "' Scanned";
                    statusTextBox.ForeColor = Color.Red;
                    statusTextBox.BackColor = statusTextBox.BackColor;
                }
            }

            //Clear out the barcode so the next one can be processed
            scanTextBox.Text = "";

        }

        private void ClearScans()
        {
            //Clear out all the barcode scans
            WOID1TextBox.Text = "";
            WOID2TextBox.Text = "";
            WOID3TextBox.Text = "";
            WOID4TextBox.Text = "";
            WOID5TextBox.Text = "";
            WOID6TextBox.Text = "";
            WOID7TextBox.Text = "";
            WOID8TextBox.Text = "";
            WOID9TextBox.Text = "";
            WOID10TextBox.Text = "";
            WOID11TextBox.Text = "";
            WOID12TextBox.Text = "";

            colorCode1TextBox.Text = "";
            colorCode2TextBox.Text = "";
            colorCode3TextBox.Text = "";
            colorCode4TextBox.Text = "";
            colorCode5TextBox.Text = "";
            colorCode6TextBox.Text = "";
            colorCode7TextBox.Text = "";
            colorCode8TextBox.Text = "";
            colorCode9TextBox.Text = "";
            colorCode10TextBox.Text = "";
            colorCode11TextBox.Text = "";
            colorCode12TextBox.Text = "";

            colorCode1TextBox.BackColor = SystemColors.Control;
            colorCode2TextBox.BackColor = SystemColors.Control;
            colorCode3TextBox.BackColor = SystemColors.Control;
            colorCode4TextBox.BackColor = SystemColors.Control;
            colorCode5TextBox.BackColor = SystemColors.Control;
            colorCode6TextBox.BackColor = SystemColors.Control;
            colorCode7TextBox.BackColor = SystemColors.Control;
            colorCode8TextBox.BackColor = SystemColors.Control;
            colorCode9TextBox.BackColor = SystemColors.Control;
            colorCode10TextBox.BackColor = SystemColors.Control;
            colorCode11TextBox.BackColor = SystemColors.Control;
            colorCode12TextBox.BackColor = SystemColors.Control;

            scannedWOIDS.Clear();

            confirmScanButton.Enabled = false;
            closeButton.Enabled = true;
        }

        private string QueryColorCode(string woid)
        {
           string colorcode = "";

            //Series of sql calls to gather data
            using (SqlConnection sqlConnection = new SqlConnection(connStr_PBET))
            {

                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("spSecondaryScheduleQueryColorCode", sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@WOID", woid);
                        var sqlReader = sqlCommand.ExecuteReader();

                        sqlReader.Read();
                        if (sqlReader.HasRows)
                        {
                            colorcode = sqlReader.GetString(0);
                        }
                        else
                        {
                            colorcode = "NOT FOUND";
                        }

                        sqlCommand.Dispose();
                        sqlReader.Close();
                    }



                    sqlConnection.Close();

                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "QueryColorCode Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine(err);
                    this.Close();
                }

                Cursor.Current = Cursors.Default;

            }

            return colorcode;
        }


        private void QueryInsertColorCode()
        {

            //Series of sql calls to gather data
            using (SqlConnection sqlConnection = new SqlConnection(connStr_PBET))
            {

                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("spInsertMLColorScanned", sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@COLORCODE", QueryColorCode(scannedWOIDS[0]));
                        sqlCommand.Parameters.AddWithValue("@PARTQTY", scannedWOIDS.Count());
                        sqlCommand.Parameters.AddWithValue("@SCANNEDDATE", DateTime.Now);
                        
                        sqlCommand.ExecuteNonQuery();
                        sqlCommand.Dispose();
                        
                    }

                    sqlConnection.Close();

                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "QueryInsertColorCode Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine(err);
                    this.Close();
                }

                Cursor.Current = Cursors.Default;

            }

        }


        private void PartScanForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (plcConnected == true)
            {
                AllenBradley.Disconnect();
            }
            barcodeClearTimer.Stop();
            barcodeClearTimer.Dispose();
            
        }

        private void scanTextBox_Leave(object sender, EventArgs e)
        {
            //Force focus to this textbox at all times for scanning
            scanTextBox.Focus();
        }
               
        private void confirmScanButton_Click(object sender, EventArgs e)
        {
            //Scan confirmed, send the color code to the PLC
            bool rslt = false;
            rslt = AllenBradley.WritePLCTagString(CKPaint.Properties.Settings.Default["Tag"].ToString().Trim(), colorCode1TextBox.Text.ToString());

            if (rslt != true)
            {
                MessageBox.Show("PLC Tag " + CKPaint.Properties.Settings.Default["Tag"].ToString().Trim() + " Failed to Write");
            }

            statusTextBox.Text = "Color Code " + colorCode1TextBox.Text.ToString() + " Written to PLC";

            //Template for new table, collecting date-time, color code, qty of parts
            QueryInsertColorCode();

            ClearScans();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
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

using ClosedXML.Excel;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base.Enums;
using TableDependency.SqlClient.Base.EventArgs;

namespace CKPaint
{
    public partial class MonitorReportForm : Form
    {
        string connStr_PBET = ConfigurationManager.ConnectionStrings["PBET"].ConnectionString;



        public MonitorReportForm()
        {
            InitializeComponent();
        }

        private void MonitorReportForm_Load(object sender, EventArgs e)
        {


            dateTimeStart.Format = DateTimePickerFormat.Custom;
            dateTimeStart.CustomFormat = "MM/dd/yyyy hh:mm tt";
            dateTimeStart.Value = DateTime.Today.AddDays(-1);

            dateTimeEnd.Format = DateTimePickerFormat.Custom;
            dateTimeEnd.CustomFormat = "MM/dd/yyyy hh:mm tt";
            dateTimeEnd.Value = DateTime.Today;
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            DataSet reportDataSet = new DataSet();
            dataGridView1.DataSource = reportDataSet;
            string reportType = "";

            if (dispositionReportRadioBtn.Checked)
            {
                reportType = "DISPOSITION";
            }
            else if (reworkOnFloorRadioBtn.Checked)
            {
                reportType = "REWORK";
            }
            else if (partInlineHistoryReportBtn.Checked)
            {
                reportType = "INLINE";
            }
            else
            {
                return;
            }


            //Series of sql calls to gather data
            using (SqlConnection sqlConnection = new SqlConnection(connStr_PBET))
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    sqlConnection.Open();

                    //Execute the stored procedure for Parts OnFloor
                    //and update the data grid view
                    using (SqlCommand sqlCommand = new SqlCommand("spGenerateReportByDateTime", sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@REPORTTYPE", reportType);
                        sqlCommand.Parameters.AddWithValue("@TIMESTART", dateTimeStart.Value);
                        sqlCommand.Parameters.AddWithValue("@TIMEEND", dateTimeEnd.Value);
                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                        {
                            sqlDataAdapter.Fill(reportDataSet, reportType);
                        }

                        ThreadSafe(() => dataGridView1.DataSource = reportDataSet);
                        ThreadSafe(() => dataGridView1.DataMember = reportType);

                    }

                    //Close connection after table is filled
                    sqlConnection.Close();

                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Refresh Table Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine(err);
                }

                using (var workbook = new XLWorkbook())
                {

                    DataTable reportTable = reportDataSet.Tables[0];

                    var workSheet = workbook.Worksheets.Add(reportTable, reportType);

                    workbook.SaveAs(@"C:\Users\Public\Desktop\CKPaint-Reports\CKPaint-" + reportType + ".xlsx");

                }

                Cursor.Current = Cursors.Default;
            }
        }

        public void ThreadSafe(MethodInvoker method)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(method);
                }
                else
                {
                    method();
                }
            }
            catch (ObjectDisposedException err)
            {
                MessageBox.Show(err.Message, "Thread Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(err);
            }
        }

        private void goToButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Users\Public\Desktop\CKPaint-Reports\");
        }

        private void monitorAllRadioBtn_CheckedChanged(object sender, EventArgs e)
        {


            RefreshPartsInlineTable();
            StartSecondaryScheduleTableDependency();

            dataGridView1.Columns["ScheduleID"].Visible = false;
            dataGridView1.Columns["Primer"].Visible = false;
            dataGridView1.Columns["ProductType"].Visible = false;
            dataGridView1.Columns["ProductPlatform"].Visible = false;
            dataGridView1.Columns["Description"].Visible = false;
            dataGridView1.Columns["DescriptionRH"].Visible = false;
            dataGridView1.Columns["RackPosition"].Visible = false;
            dataGridView1.Columns["RackPositionRH"].Visible = false;
            dataGridView1.Columns["AssembleDate"].Visible = false;
            dataGridView1.Columns["PaintBlock"].Visible = false;
            dataGridView1.Columns["ShipDate"].Visible = false;
            dataGridView1.Columns["ImportDate"].Visible = false;
            dataGridView1.Columns["PartFinesse"].Visible = false;
            dataGridView1.Columns["PartScrap"].Visible = false;
        }

        public SqlTableDependency<SecondarySchedule> secondaryScheduleDependency;

        private bool StartSecondaryScheduleTableDependency()
        {
            try
            {
                //Init the sql dependency using the connection string
                //after, point to the functions handling the onchanged and 
                //error functions
                secondaryScheduleDependency = new SqlTableDependency<SecondarySchedule>(connStr_PBET);
                secondaryScheduleDependency.OnChanged += SecondaryScheduleTableDependency_OnChange;
                secondaryScheduleDependency.OnError += SecondaryScheduleTableDependency_OnError;
                secondaryScheduleDependency.Start();
                return true;
            }
            catch (Exception err)
            {

                MessageBox.Show("Error setting up the table dependency please check the network and contact the shift supervisor.",
                    "Secondary Dependency Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(err);
            }

            return false;
        }

        private bool StopSecondaryScheduleTableDependency()
        {
            try
            {
                if (secondaryScheduleDependency != null)
                {
                    secondaryScheduleDependency.Stop();
                    return true;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Stop Secondary Dependency Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(err);
            }
            return false;
        }

        private void SecondaryScheduleTableDependency_OnError(object sender, ErrorEventArgs err)
        {
            MessageBox.Show(err.Message, "Secondary Dependency OnError", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Console.WriteLine(err.Error.Message);
        }

        private void SecondaryScheduleTableDependency_OnChange(object sender, RecordChangedEventArgs<SecondarySchedule> ent)
        {
            try
            {
                var changedEntity = ent.Entity;

                switch (ent.ChangeType)
                {
                    case ChangeType.Insert:
                        {
                            RefreshPartsInlineTable();
                        }
                        break;
                    case ChangeType.Update:
                        {
                            RefreshPartsInlineTable();
                        }
                        break;
                    case ChangeType.Delete:
                        {
                            RefreshPartsInlineTable();
                        }
                        break;

                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Secondary Dependency OnChange", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(err);
            }
        }


        public void RefreshPartsInlineTable()
        {
            string paintStation = CKPaint.Properties.Settings.Default["Station"].ToString().Trim().ToUpper();
            DataSet inlinePartsDataSet = new DataSet();

            //Series of sql calls to gather data
            using (SqlConnection sqlConnection = new SqlConnection(connStr_PBET))
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    sqlConnection.Open();

                    //Execute the stored procedure for Parts Inline
                    //and update the data grid view
                    using (SqlCommand sqlCommand = new SqlCommand("spGetInlineParts", sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        //sqlCommand.Parameters.AddWithValue("@PAINTSTATION", paintStation);
                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                        {
                            sqlDataAdapter.Fill(inlinePartsDataSet, "SecondaryScheduleInlineParts");
                        }

                        ThreadSafe(() => dataGridView1.DataSource = inlinePartsDataSet);
                        ThreadSafe(() => dataGridView1.DataMember = "SecondaryScheduleInlineParts");

                    }
                    //Close connection after table is filled
                    sqlConnection.Close();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Refresh Table Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine(err);
                }

                Cursor.Current = Cursors.Default;
            }
        }
    }
}

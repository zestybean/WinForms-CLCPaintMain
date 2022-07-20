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
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base.Enums;
using TableDependency.SqlClient.Base.EventArgs;

namespace CKPaint
{
    public partial class PartDisposition : Form
    {
        //This connection string is called from App.config file, alternatively it could also be hardcoded into this string var.
        string connStr_PBET = ConfigurationManager.ConnectionStrings["PBET"].ConnectionString;
        //string connStr_MODS = ConfigurationManager.ConnectionStrings["MODS"].ConnectionString;

        //Sql Dependency Object
        public SqlTableDependency<SecondarySchedule> secondaryScheduleDependency;
        public SqlTableDependency<PartDispositionHistory> partDispositionHistoryDependency;
        public PartDisposition()
        {
            InitializeComponent();
        }

        private void PartDisposition_Load(object sender, EventArgs e)
        {
            //On the start of the program fill the table up from the DB
            //and initialiaze the SQL dependecy functions
            RefreshInlinePartsTable();
            RefreshDispositionHistoryTable();
            StartSecondaryScheduleTableDependency();
            AdjustColumnOrder(dataGridView1);
        }

        private void PartDisposition_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Stop the dependency when applications is closing
            try
            {
                StopSecondaryScheduleTableDependency();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Form Closing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(err);
                this.Close();
            }
        }

        private void AdjustColumnOrder(DataGridView dv)
        {
            //Rearrange data grid view columns columns
            dv.Columns["JobNumber"].DisplayIndex = 0;
            dv.Columns["SequenceNumber"].DisplayIndex = 1;
            dv.Columns["WOID"].DisplayIndex = 2;
            dv.Columns["WOIDRH"].DisplayIndex = 3;
            dv.Columns["PartNumber"].DisplayIndex = 4;
            dv.Columns["PartNumberRH"].DisplayIndex = 5;
            dv.Columns["ColorCode"].DisplayIndex = 6;
            dv.Columns["SetNumber"].DisplayIndex = 7;
            dv.Columns["PartRework"].DisplayIndex = 8;
            dv.Columns["PartFinesse"].DisplayIndex = 9;
            dv.Columns["RackCode"].DisplayIndex = 10;
            dv.Columns["PaintDate"].DisplayIndex = 11;
            dv.Columns["PaintStation"].DisplayIndex = 12;

            //Ignore these
            dv.Columns["ScheduleID"].Visible = false;
            dv.Columns["Primer"].Visible = false;
            dv.Columns["ProductType"].Visible = false;
            dv.Columns["ProductPlatform"].Visible = false;
            dv.Columns["Description"].Visible = false;
            dv.Columns["DescriptionRH"].Visible = false;
            dv.Columns["RackPosition"].Visible = false;
            dv.Columns["RackPositionRH"].Visible = false;
            dv.Columns["AssembleDate"].Visible = false;
            dv.Columns["PaintBlock"].Visible = false;
            dv.Columns["ShipDate"].Visible = false;
            dv.Columns["ImportDate"].Visible = false;
            dv.Columns["PartInline"].Visible = false;
            dv.Columns["PartDisposed"].Visible = false;
            dv.Columns["PartScrap"].Visible = false;
        }
        
        void RefreshInlinePartsTable()
        {
            //This function fills the datagridview from the current data in the
            //db, because the table is using SQL dependency multi-threading needs
            //to be called in order to properly execute commands
            DataSet inlinePartsDataSet = new DataSet();

            //Series of sql calls to gather data
            using (SqlConnection sqlConnection = new SqlConnection(connStr_PBET))
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    sqlConnection.Open();

                    //Execute the stored procedure for Parts OnFloor
                    //and update the data grid view
                    using (SqlCommand sqlCommand = new SqlCommand("spGetInlineParts", sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

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
                    this.Close();
                }
                Cursor.Current = Cursors.Default;
            }
        }

        void RefreshDispositionHistoryTable()
        {
            //This function fills the datagridview from the current data in the
            //db, because the table is using SQL dependency multi-threading needs
            //to be called in order to properly execute commands
            DataSet dispositionHistoryDataSet = new DataSet();

            //Series of sql calls to gather data
            using (SqlConnection sqlConnection = new SqlConnection(connStr_PBET))
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    sqlConnection.Open();

                    //Execute the stored procedure for Parts Inline
                    //and update the data grid view
                    //DISPOSITION HISTORY HERE
                    using (SqlCommand sqlCommand = new SqlCommand("spGetDispositionHistory", sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                        {
                            sqlDataAdapter.Fill(dispositionHistoryDataSet, "SecondaryScheduleDispositionHistory");
                        }

                        ThreadSafe(() => dataGridView2.DataSource = dispositionHistoryDataSet);
                        ThreadSafe(() => dataGridView2.DataMember = "SecondaryScheduleDispositionHistory");

                    }


                    //Close connection after table is filled
                    sqlConnection.Close();

                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Refresh Table Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine(err);
                    this.Close();
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
                MessageBox.Show(err.Message, "Tread Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(err);
                this.Close();
            }
        }


        private bool StartSecondaryScheduleTableDependency()
        {
            try
            {
                //Init the sql dependency using the connection string
                //after, point to the functions handling the onchanged and 
                //error functions
                secondaryScheduleDependency = new SqlTableDependency<SecondarySchedule>(connStr_PBET);
                partDispositionHistoryDependency = new SqlTableDependency<PartDispositionHistory>(connStr_PBET);
                partDispositionHistoryDependency.OnChanged += PartDispositionHistyoryDependency_OnChange;
                partDispositionHistoryDependency.OnError += SecondaryScheduleTableDependency_OnError;
                secondaryScheduleDependency.OnChanged += SecondaryScheduleTableDependency_OnChange;
                secondaryScheduleDependency.OnError += SecondaryScheduleTableDependency_OnError;
                partDispositionHistoryDependency.Start();
                secondaryScheduleDependency.Start();
                return true;
            }
            catch (Exception err)
            {

                MessageBox.Show("Error setting up the table dependency please check the network and contact the shift supervisor.",
                    "Secondary Dependency Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(err);
                this.Close();
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
                this.Close();
            }
            return false;
        }

        private void SecondaryScheduleTableDependency_OnError(object sender, ErrorEventArgs err)
        {
            MessageBox.Show(err.Message, "Secondary Dependency OnError", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Console.WriteLine(err.Error.Message);
            this.Close();
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
                            RefreshDispositionHistoryTable();
                        }
                        break;
                    case ChangeType.Update:
                        {
                            RefreshDispositionHistoryTable();
                        }
                        break;
                    case ChangeType.Delete:
                        {
                            RefreshDispositionHistoryTable();
                        }
                        break;
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Secondary Dependency OnChange", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(err);
                this.Close();
            }
        }

        private void PartDispositionHistyoryDependency_OnChange(object sender, RecordChangedEventArgs<PartDispositionHistory> ent)
        {
            try
            {
                var changedEntity = ent.Entity;

                switch (ent.ChangeType)
                {
                    case ChangeType.Insert:
                        {
                            RefreshDispositionHistoryTable();
                        }
                        break;
                    case ChangeType.Update:
                        {
                            RefreshDispositionHistoryTable();
                        }
                        break;
                    case ChangeType.Delete:
                        {
                            RefreshDispositionHistoryTable();
                        }
                        break;
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Secondary Dependency OnChange", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(err);
                this.Close();
            }
        }

        private void searchJobNumRb_CheckedChanged(object sender, EventArgs e)
        {
            RefreshInlinePartsTable();
            RefreshDispositionHistoryTable();
        }

        private void searchWOIDRb_CheckedChanged(object sender, EventArgs e)
        {
            RefreshInlinePartsTable();
            RefreshDispositionHistoryTable();
        }
        private void searchButton_Click(object sender, EventArgs e)
        {
            SearchTxtBox.Text = SearchTxtBox.Text.Trim();

            if(string.IsNullOrEmpty(SearchTxtBox.Text))
            {
                SearchTxtBox.Clear();
                RefreshInlinePartsTable();
                RefreshDispositionHistoryTable();
                return;
            }

            DataSet inlinePartsDataset = new DataSet();

            //Series of sql calls to gather data
            using (SqlConnection sqlConnection = new SqlConnection(connStr_PBET))
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    sqlConnection.Open();
                    if (searchJobNumRb.Checked)
                    {
                        //Execute the stored procedure for Parts OnFloor
                        //and update the data grid view
                        using (SqlCommand sqlCommand = new SqlCommand("spGetInlinePartsByJobNumber", sqlConnection))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            sqlCommand.Parameters.AddWithValue("@JobNumber", SearchTxtBox.Text.ToString());

                            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                            {
                                sqlDataAdapter.Fill(inlinePartsDataset, "SecondaryScheduleInlineParts");
                            }

                            ThreadSafe(() => dataGridView1.DataSource = inlinePartsDataset);
                            ThreadSafe(() => dataGridView1.DataMember = "SecondaryScheduleInlineParts");

                        }
                    }
                    else
                    {
                        //Execute the stored procedure for Parts OnFloor
                        //and update the data grid view
                        using (SqlCommand sqlCommand = new SqlCommand("spGetInlinePartsByWOID", sqlConnection))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            sqlCommand.Parameters.AddWithValue("@WOID", SearchTxtBox.Text.ToString());

                            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                            {
                                sqlDataAdapter.Fill(inlinePartsDataset, "SecondaryScheduleInlineParts");
                            }

                            ThreadSafe(() => dataGridView1.DataSource = inlinePartsDataset);
                            ThreadSafe(() => dataGridView1.DataMember = "SecondaryScheduleInlineParts");

                        }
                    }
                    //Close connection after table is filled
                    sqlConnection.Close();

                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Refresh Table Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine(err);
                    this.Close();
                }
                Cursor.Current = Cursors.Default;
            }
            
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            SearchTxtBox.Clear();
            RefreshInlinePartsTable();
            RefreshDispositionHistoryTable();
        }

        private void finesseButton_Click(object sender, EventArgs e)
        { 
            SearchTxtBox.Text = SearchTxtBox.Text.Trim();

            if (string.IsNullOrEmpty(SearchTxtBox.Text))
            {
                SearchTxtBox.Clear();
                RefreshInlinePartsTable();
                RefreshDispositionHistoryTable();
                return;
            }

            DataSet inlinePartsDataset = new DataSet();

            //Series of sql calls to gather data
            using (SqlConnection sqlConnection = new SqlConnection(connStr_PBET))
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    sqlConnection.Open();
                    if (searchJobNumRb.Checked)
                    {
                        //Execute the stored procedure for Parts OnFloor
                        //and update the data grid view
                        using (SqlCommand sqlCommand = new SqlCommand("spGetFinesseByJobNumber", sqlConnection))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            sqlCommand.Parameters.AddWithValue("@JobNumber", SearchTxtBox.Text.ToString());

                            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                            {
                                sqlDataAdapter.Fill(inlinePartsDataset, "SecondaryScheduleInlineParts");
                            }

                            ThreadSafe(() => dataGridView1.DataSource = inlinePartsDataset);
                            ThreadSafe(() => dataGridView1.DataMember = "SecondaryScheduleInlineParts");

                        }
                    }
                    else
                    {
                        //Execute the stored procedure for Parts OnFloor
                        //and update the data grid view
                        using (SqlCommand sqlCommand = new SqlCommand("spGetFinesseByWOID", sqlConnection))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            sqlCommand.Parameters.AddWithValue("@WOID", SearchTxtBox.Text.ToString());

                            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                            {
                                sqlDataAdapter.Fill(inlinePartsDataset, "SecondaryScheduleInlineParts");
                            }

                            ThreadSafe(() => dataGridView1.DataSource = inlinePartsDataset);
                            ThreadSafe(() => dataGridView1.DataMember = "SecondaryScheduleInlineParts");

                        }
                    }
                    //Close connection after table is filled
                    sqlConnection.Close();

                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Refresh Table Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine(err);
                    this.Close();
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void getAllReworkButton_Click(object sender, EventArgs e)
        {

            SearchTxtBox.Text = SearchTxtBox.Text.Trim();

            if (string.IsNullOrEmpty(SearchTxtBox.Text))
            {
                SearchTxtBox.Clear();
                RefreshInlinePartsTable();
                RefreshDispositionHistoryTable();
                return;
            }

            DataSet inlinePartsDataset = new DataSet();

            //Series of sql calls to gather data
            using (SqlConnection sqlConnection = new SqlConnection(connStr_PBET))
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    sqlConnection.Open();
                    if (searchJobNumRb.Checked)
                    {
                        //Execute the stored procedure for Parts OnFloor
                        //and update the data grid view
                        using (SqlCommand sqlCommand = new SqlCommand("spGetReworkByJobNumber", sqlConnection))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            sqlCommand.Parameters.AddWithValue("@JobNumber", SearchTxtBox.Text.ToString());

                            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                            {
                                sqlDataAdapter.Fill(inlinePartsDataset, "SecondaryScheduleInlineParts");
                            }

                            ThreadSafe(() => dataGridView1.DataSource = inlinePartsDataset);
                            ThreadSafe(() => dataGridView1.DataMember = "SecondaryScheduleInlineParts");

                        }
                    }
                    else
                    {
                        //Execute the stored procedure for Parts OnFloor
                        //and update the data grid view
                        using (SqlCommand sqlCommand = new SqlCommand("spGetReworkByWOID", sqlConnection))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            sqlCommand.Parameters.AddWithValue("@WOID", SearchTxtBox.Text.ToString());

                            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                            {
                                sqlDataAdapter.Fill(inlinePartsDataset, "SecondaryScheduleInlineParts");
                            }

                            ThreadSafe(() => dataGridView1.DataSource = inlinePartsDataset);
                            ThreadSafe(() => dataGridView1.DataMember = "SecondaryScheduleInlineParts");

                        }
                    }
                    //Close connection after table is filled
                    sqlConnection.Close();

                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Refresh Table Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine(err);
                    this.Close();
                }
                Cursor.Current = Cursors.Default;
            }
        }

        string safeString(SqlDataReader sqlReader, int index)
        {
            if (!sqlReader.IsDBNull(index))
            {
                return sqlReader.GetString(index);
            }
            else
            {
                return string.Empty;
            }
        }

        DateTime safeDate(SqlDataReader sqlReader, int index)
        {
            if (!sqlReader.IsDBNull(index))
            {
                return sqlReader.GetDateTime(index);
            }
            else
            {
                return DateTime.Now;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            if (string.IsNullOrEmpty(inspectorComboBox.Text))
            {
                inspectorBox.BackColor = Color.Red;
                return;
            }

            //DISPOSITION DOUBLE CLICK
            string partWOID = dataGridView1.Rows[e.RowIndex].Cells[19].Value.ToString();
            

            PartDispositionForm partDispositionForm = new PartDispositionForm();
            partDispositionForm.disposePartWOID = partWOID;
            partDispositionForm.dispositionInspectorName = CKPaint.Properties.Settings.Default["Inspector"].ToString();



            partDispositionForm.ShowDialog();
            if (partDispositionForm.disposeActionButtonSelected)
            {
                //SecondarySchedule SecondarySchedule_Part = new SecondarySchedule();
                PartDispositionHistory PartDispositionHistory_Part = new PartDispositionHistory();

                //Series of sql calls to gather data
                using (SqlConnection sqlConnection = new SqlConnection(connStr_PBET))
                {

                    Cursor.Current = Cursors.WaitCursor;
                    try
                    {
                        sqlConnection.Open();
                        using (SqlCommand sqlCommand = new SqlCommand("spDisposePartByWOID", sqlConnection))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            sqlCommand.Parameters.AddWithValue("@WOID", partDispositionForm.disposePartWOID);
                            sqlCommand.Parameters.AddWithValue("@DISPOSITION", partDispositionForm.dispositionResult.ToString().ToUpper());
                            var sqlReader = sqlCommand.ExecuteReader();

                            sqlReader.Read();
                            if (sqlReader.HasRows)
                            {
                                PartDispositionHistory_Part.InspectorName = partDispositionForm.dispositionInspectorName.ToString();
                                PartDispositionHistory_Part.SequenceNumber = sqlReader.GetString(1);
                                PartDispositionHistory_Part.JobNumber = sqlReader.GetString(2);
                                PartDispositionHistory_Part.PartNumber = sqlReader.GetString(4);
                                PartDispositionHistory_Part.PartNumberRH = sqlReader.GetString(5);
                                PartDispositionHistory_Part.ColorCode = sqlReader.GetString(6);
                                PartDispositionHistory_Part.InspectorID = getInspectorId();
                                PartDispositionHistory_Part.PaintStation = safeString(sqlReader, 17);
                                PartDispositionHistory_Part.PaintDate = safeDate(sqlReader, 16);
                                PartDispositionHistory_Part.PartProcess = partDispositionForm.dispositionPartProcess.ToString().ToUpper();
                                PartDispositionHistory_Part.ProductType = sqlReader.GetString(8);
                                PartDispositionHistory_Part.WOID = sqlReader.GetString(19);
                                PartDispositionHistory_Part.WOIDRH = sqlReader.GetString(20);
                                PartDispositionHistory_Part.PartDefect = partDispositionForm.dispositionPartDefect.ToString().ToUpper();
                                PartDispositionHistory_Part.DPUCount = Convert.ToInt16(partDispositionForm.dispositionDPUNum);
                                PartDispositionHistory_Part.PartDisposition = partDispositionForm.dispositionResult.ToString().ToUpper();
                                PartDispositionHistory_Part.PartDescription = sqlReader.GetString(10);
                                PartDispositionHistory_Part.PartDescriptionRH = sqlReader.GetString(11);
                                PartDispositionHistory_Part.DispositionDate = DateTime.Now;
                                PartDispositionHistory_Part.PartRework = sqlReader.GetInt16(24);
                                PartDispositionHistory_Part.PartFinesse = sqlReader.GetInt16(26);

                                //PRINTING WILL OCCURR HERE!!!
                                PrintToZebraHelperDisposition.PrintToZebra(PartDispositionHistory_Part);
                            }
                            else
                            {
                                Console.WriteLine("Part does not exist or is inline!");
                            }

                            sqlCommand.Dispose();
                            sqlReader.Close();
                        }

                        //THIS NEEDS A BOUNDARY CHECK
                        using (SqlCommand sqlCommand = new SqlCommand("spInsertDispositionHistory", sqlConnection))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            sqlCommand.Parameters.AddWithValue("@INSPECTORNAME", PartDispositionHistory_Part.InspectorName);
                            sqlCommand.Parameters.AddWithValue("@SEQUENCENUMBER", PartDispositionHistory_Part.SequenceNumber);
                            sqlCommand.Parameters.AddWithValue("@JOBNUMBER", PartDispositionHistory_Part.JobNumber);
                            sqlCommand.Parameters.AddWithValue("@PARTNUMBER", PartDispositionHistory_Part.PartNumber);
                            sqlCommand.Parameters.AddWithValue("@PARTNUMBERRH", PartDispositionHistory_Part.PartNumberRH);
                            sqlCommand.Parameters.AddWithValue("@COLORCODE", PartDispositionHistory_Part.ColorCode);
                            sqlCommand.Parameters.AddWithValue("@PRODUCTTYPE", PartDispositionHistory_Part.ProductType);
                            sqlCommand.Parameters.AddWithValue("@INSPECTORID", PartDispositionHistory_Part.InspectorID);
                            sqlCommand.Parameters.AddWithValue("@PAINTSTATION", PartDispositionHistory_Part.PaintStation);
                            sqlCommand.Parameters.AddWithValue("@PAINTDATE", PartDispositionHistory_Part.PaintDate);
                            sqlCommand.Parameters.AddWithValue("@PARTPROCESS", PartDispositionHistory_Part.PartProcess);
                            sqlCommand.Parameters.AddWithValue("@WOID", PartDispositionHistory_Part.WOID);
                            sqlCommand.Parameters.AddWithValue("@WOIDRH", PartDispositionHistory_Part.WOIDRH);
                            sqlCommand.Parameters.AddWithValue("@PARTDEFECT", PartDispositionHistory_Part.PartDefect);
                            sqlCommand.Parameters.AddWithValue("@DPUCOUNT", PartDispositionHistory_Part.DPUCount);
                            sqlCommand.Parameters.AddWithValue("@PARTDISPOSITION", PartDispositionHistory_Part.PartDisposition);
                            sqlCommand.Parameters.AddWithValue("@PARTDESCRIPTION", PartDispositionHistory_Part.PartDescription);
                            sqlCommand.Parameters.AddWithValue("@PARTDESCRIPTIONRH", PartDispositionHistory_Part.PartDescriptionRH);
                            sqlCommand.Parameters.AddWithValue("@DISPOSITIONDATE", PartDispositionHistory_Part.DispositionDate);
                            sqlCommand.Parameters.AddWithValue("@PARTREWORK", PartDispositionHistory_Part.PartRework);
                            sqlCommand.Parameters.AddWithValue("@PARTFINESSE", PartDispositionHistory_Part.PartFinesse);

                            sqlCommand.ExecuteNonQuery();

                            sqlCommand.Dispose();

                        }
                        sqlConnection.Close();

                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message, "Print Label OnClick Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Console.WriteLine(err);
                        this.Close();
                    }

                    Cursor.Current = Cursors.Default;
                    RefreshInlinePartsTable();
                }
            }

        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Do something here...
        }

        private void inspectorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            inspectorBox.BackColor = Color.DarkGray;
            CKPaint.Properties.Settings.Default["Inspector"] = inspectorComboBox.Text.ToString();
            Properties.Settings.Default.Save();
        }

        private string getInspectorId()
        {
            string inspectorName = CKPaint.Properties.Settings.Default["Inspector"].ToString();
            string inspectorID = "";

            //Series of sql calls to gather data
            using (SqlConnection sqlConnection = new SqlConnection(connStr_PBET))
            {

                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("spGetInspectorID", sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@INSPECTORNAME", inspectorName);
                        var sqlReader = sqlCommand.ExecuteReader();

                        sqlReader.Read();
                        if (sqlReader.HasRows)
                        {
                            inspectorID = sqlReader.GetString(0);
                        }
                        else
                        {
                            Console.WriteLine("Inspector does not exist!");
                        }

                        sqlCommand.Dispose();
                        sqlReader.Close();
                    }



                    sqlConnection.Close();

                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Get InspectorID Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine(err);
                    this.Close();
                }

                Cursor.Current = Cursors.Default;

            }

            return inspectorID;
        }

        private void disposedSearchButton_Click(object sender, EventArgs e)
        {
            SearchTxtBox.Text = SearchTxtBox.Text.Trim();

            if (string.IsNullOrEmpty(SearchTxtBox.Text))
            {
                SearchTxtBox.Clear();
                RefreshInlinePartsTable();
                RefreshDispositionHistoryTable();
                return;
            }

            DataSet inlinePartsDataset = new DataSet();

            //Series of sql calls to gather data
            using (SqlConnection sqlConnection = new SqlConnection(connStr_PBET))
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    sqlConnection.Open();
                    if (searchJobNumRb.Checked)
                    {
                        //Execute the stored procedure for Parts OnFloor
                        //and update the data grid view
                        using (SqlCommand sqlCommand = new SqlCommand("spSearchAllByWOID", sqlConnection))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            sqlCommand.Parameters.AddWithValue("@WOID", SearchTxtBox.Text.ToString());

                            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                            {
                                sqlDataAdapter.Fill(inlinePartsDataset, "SecondaryScheduleInlineParts");
                            }

                            ThreadSafe(() => dataGridView1.DataSource = inlinePartsDataset);
                            ThreadSafe(() => dataGridView1.DataMember = "SecondaryScheduleInlineParts");

                        }
                    }
                    else
                    {
                        //Execute the stored procedure for Parts OnFloor
                        //and update the data grid view
                        using (SqlCommand sqlCommand = new SqlCommand("spSearchAllByWOID", sqlConnection))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            sqlCommand.Parameters.AddWithValue("@WOID", SearchTxtBox.Text.ToString());

                            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                            {
                                sqlDataAdapter.Fill(inlinePartsDataset, "SecondaryScheduleInlineParts");
                            }

                            ThreadSafe(() => dataGridView1.DataSource = inlinePartsDataset);
                            ThreadSafe(() => dataGridView1.DataMember = "SecondaryScheduleInlineParts");

                        }
                    }
                    //Close connection after table is filled
                    sqlConnection.Close();

                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Refresh Table Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine(err);
                    this.Close();
                }
                Cursor.Current = Cursors.Default;
            }
        }
    }
}

using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base.Enums;
using TableDependency.SqlClient.Base.EventArgs;

namespace CKPaint
{
    public partial class PartLoader : Form
    {
        //This connection string is called from App.config file, alternatively it could also be hardcoded into this string var.
        string connStr_PBET = ConfigurationManager.ConnectionStrings["PBET"].ConnectionString;
        //string connStr_MODS = ConfigurationManager.ConnectionStrings["MODS"].ConnectionString;

        //This function fills the datagridview from the current data in the
        //db, because the table is using SQL dependency multi-threading needs
        //to be called in order to properly execute commands
        

        //Sql Dependency Object
        public SqlTableDependency<SecondarySchedule> secondaryScheduleDependency;

        public PartLoader()
        {
            InitializeComponent();
        }

        private void LandingPage_Load(object sender, EventArgs e)
        {
            //On the start of the program fill the table up from the DB
            //and initialiaze the SQL dependecy functions

            RefreshPartsOnFloorTable();
            RefreshPartsInlineTable();
            StartSecondaryScheduleTableDependency();
            AdjustColumnOrder(dataGridView1);
            AdjustColumnOrder(dataGridView2);

            string paintStation = CKPaint.Properties.Settings.Default["Station"].ToString().Trim().ToUpper();


            //Check for SPOVEN 2
            if (paintStation == "SPOVEN 2")
            {
                searchButton.Visible = false;
                bumperSearchButton.Visible = false;
                peterbiltSearchButton.Visible = false;
                getAllReworkButton.Visible = false; 
            } else
            {
                primerSearchBtn.Visible = false;
                primerReworkSearchBtn.Visible = false;
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
            dv.Columns["PartInline"].DisplayIndex = 8;
            dv.Columns["PartRework"].DisplayIndex = 9;
            dv.Columns["PartDisposed"].DisplayIndex = 10;
            dv.Columns["PaintDate"].DisplayIndex = 11;
            dv.Columns["PaintStation"].DisplayIndex = 12;
            dv.Columns["AssembleDate"].DisplayIndex = 13;

            //Ignore these
            dv.Columns["ScheduleID"].Visible = false;
            dv.Columns["Primer"].Visible = false;
            dv.Columns["ProductType"].Visible = false;
            dv.Columns["ProductPlatform"].Visible = false;
            dv.Columns["Description"].Visible = false;
            dv.Columns["DescriptionRH"].Visible = false;
            dv.Columns["RackPosition"].Visible = false;
            dv.Columns["RackPositionRH"].Visible = false;
           
            dv.Columns["PaintBlock"].Visible = false;
            dv.Columns["ShipDate"].Visible = false;
            dv.Columns["ImportDate"].Visible = false;
            dv.Columns["PartFinesse"].Visible = false;
            dv.Columns["PartScrap"].Visible = false;
        }

        private void LandingPage_FormClosing(object sender, FormClosingEventArgs e)
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

        public void RefreshPartsOnFloorTable()
        {
            DataSet floorPartsDataSet = new DataSet();

            //Series of sql calls to gather data
            using (SqlConnection sqlConnection = new SqlConnection(connStr_PBET))
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    sqlConnection.Open();

                    //Execute the stored procedure for Parts OnFloor
                    //and update the data grid view
                    using (SqlCommand sqlCommand = new SqlCommand("spGetOnFloorParts", sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                        {
                            sqlDataAdapter.Fill(floorPartsDataSet, "SecondaryScheduleFloorParts");
                        }

                        ThreadSafe(() => dataGridView1.DataSource = floorPartsDataSet);
                        ThreadSafe(() => dataGridView1.DataMember = "SecondaryScheduleFloorParts");

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
                    using (SqlCommand sqlCommand = new SqlCommand("spGetInlinePartsByStation", sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@PAINTSTATION", paintStation);
                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                        {
                            sqlDataAdapter.Fill(inlinePartsDataSet, "SecondaryScheduleInlineParts");
                        }

                        ThreadSafe(() => dataGridView2.DataSource = inlinePartsDataSet);
                        ThreadSafe(() => dataGridView2.DataMember = "SecondaryScheduleInlineParts");
                       
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
                MessageBox.Show(err.Message, "Thread Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                this.Close();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            RefreshPartsOnFloorTable();
            RefreshPartsInlineTable();
            StartSecondaryScheduleTableDependency();
        }

        
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[22].Value != System.DBNull.Value)
                {
                    if (Convert.ToInt32(row.Cells[24].Value) == 1)
                    {
                        row.DefaultCellStyle.BackColor = Color.Yellow;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                    }
                }

            }

        }

        private void searchWOIDRb_CheckedChanged(object sender, EventArgs e)
        {
            RefreshPartsOnFloorTable();
            RefreshPartsInlineTable();
        }

        private void searchJobNumRb_CheckedChanged(object sender, EventArgs e)
        {
            RefreshPartsOnFloorTable();
            RefreshPartsInlineTable();
        }

        private void clearSearchButton_Click(object sender, EventArgs e)
        {
            SearchTxtBox.Clear();
            RefreshPartsOnFloorTable();
            RefreshPartsInlineTable();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            SearchTxtBox.Text = SearchTxtBox.Text.Trim();

            if (String.IsNullOrEmpty(SearchTxtBox.Text))
            {
                SearchTxtBox.Clear();
                RefreshPartsOnFloorTable();
                RefreshPartsInlineTable();
                return;
            }

            DataSet floorPartsDataSet = new DataSet();
           
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
                    using (SqlCommand sqlCommand = new SqlCommand("spSearchOnFloorPartsByJobNumber", sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@JobNumber", SearchTxtBox.Text.ToString());

                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                        {
                            sqlDataAdapter.Fill(floorPartsDataSet, "SecondaryScheduleFloorParts");
                        }

                        ThreadSafe(() => dataGridView1.DataSource = floorPartsDataSet);
                        ThreadSafe(() => dataGridView1.DataMember = "SecondaryScheduleFloorParts");

                    }
                } else
                {
                    //Execute the stored procedure for Parts OnFloor
                    //and update the data grid view
                    using (SqlCommand sqlCommand = new SqlCommand("spSearchOnFloorPartsByWOID", sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@WOID", SearchTxtBox.Text.ToString());

                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                        {
                            sqlDataAdapter.Fill(floorPartsDataSet, "SecondaryScheduleFloorParts");
                        }

                        ThreadSafe(() => dataGridView1.DataSource = floorPartsDataSet);
                        ThreadSafe(() => dataGridView1.DataMember = "SecondaryScheduleFloorParts");

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

        //Bumper Search
        private void bumperSearchButton_Click(object sender, EventArgs e)
        {
            SearchTxtBox.Text = SearchTxtBox.Text.Trim();

            if (String.IsNullOrEmpty(SearchTxtBox.Text))
            {
                SearchTxtBox.Clear();
                RefreshPartsOnFloorTable();
                RefreshPartsInlineTable();
                return;
            }

            DataSet floorPartsDataSet = new DataSet();
            DataSet inlinePartsDataSet = new DataSet();

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
                        using (SqlCommand sqlCommand = new SqlCommand("spBumperSearchOnFloorPartsByJobNumber", sqlConnection))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            sqlCommand.Parameters.AddWithValue("@JobNumber", SearchTxtBox.Text.ToString());

                            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                            {
                                sqlDataAdapter.Fill(floorPartsDataSet, "SecondaryScheduleFloorParts");
                            }

                            ThreadSafe(() => dataGridView1.DataSource = floorPartsDataSet);
                            ThreadSafe(() => dataGridView1.DataMember = "SecondaryScheduleFloorParts");

                        }
                    }
                    else
                    {
                        //Execute the stored procedure for Parts OnFloor
                        //and update the data grid view
                        using (SqlCommand sqlCommand = new SqlCommand("spBumperSearchOnFloorPartsByWOID", sqlConnection))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            sqlCommand.Parameters.AddWithValue("@WOID", SearchTxtBox.Text.ToString());

                            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                            {
                                sqlDataAdapter.Fill(floorPartsDataSet, "SecondaryScheduleFloorParts");
                            }

                            ThreadSafe(() => dataGridView1.DataSource = floorPartsDataSet);
                            ThreadSafe(() => dataGridView1.DataMember = "SecondaryScheduleFloorParts");

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

            DataSet floorPartsDataSet = new DataSet();
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
                    using (SqlCommand sqlCommand = new SqlCommand("spGetOnFloorReworkParts", sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                        {
                            sqlDataAdapter.Fill(floorPartsDataSet, "SecondaryScheduleFloorParts");
                        }

                        ThreadSafe(() => dataGridView1.DataSource = floorPartsDataSet);
                        ThreadSafe(() => dataGridView1.DataMember = "SecondaryScheduleFloorParts");

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

        /// <summary>
        /// PETERBILT SEARCH
        /// </summary>
        private void peterbiltSearchButton_Click(object sender, EventArgs e)
        {
            SearchTxtBox.Text = SearchTxtBox.Text.Trim();

            if (String.IsNullOrEmpty(SearchTxtBox.Text))
            {
                SearchTxtBox.Clear();
                RefreshPartsOnFloorTable();
                RefreshPartsInlineTable();
                return;
            }

            DataSet floorPartsDataSet = new DataSet();
            DataSet inlinePartsDataSet = new DataSet();

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
                        using (SqlCommand sqlCommand = new SqlCommand("spSearchPeterbiltOnFloorPartsByJobNumber", sqlConnection))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            sqlCommand.Parameters.AddWithValue("@SEQUENCENUMBER", SearchTxtBox.Text.ToString());

                            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                            {
                                sqlDataAdapter.Fill(floorPartsDataSet, "SecondaryScheduleFloorParts");
                            }

                            ThreadSafe(() => dataGridView1.DataSource = floorPartsDataSet);
                            ThreadSafe(() => dataGridView1.DataMember = "SecondaryScheduleFloorParts");

                        }
                    }
                    else
                    {
                        //Execute the stored procedure for Parts OnFloor
                        //and update the data grid view
                        using (SqlCommand sqlCommand = new SqlCommand("spSearchPeterbiltOnFloorPartsByWOID", sqlConnection))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            sqlCommand.Parameters.AddWithValue("@WOID", SearchTxtBox.Text.ToString());

                            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                            {
                                sqlDataAdapter.Fill(floorPartsDataSet, "SecondaryScheduleFloorParts");
                            }

                            ThreadSafe(() => dataGridView1.DataSource = floorPartsDataSet);
                            ThreadSafe(() => dataGridView1.DataMember = "SecondaryScheduleFloorParts");

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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string paintStation = CKPaint.Properties.Settings.Default["Station"].ToString().Trim().ToUpper();

            //REALLY?
            if (e.RowIndex == -1)
                return;

            bool RH = false;
            bool RHOnly = false;

            //LOAD DOUBLE CLICK
            string woidString = dataGridView1.Rows[e.RowIndex].Cells[19].Value.ToString();
            string woidStringRH = dataGridView1.Rows[e.RowIndex].Cells[20].Value.ToString();
            string partNumberString = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            string partNumberRHString = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();

            //WOID is blank
            if (string.IsNullOrEmpty(woidString))
            {
                //THIS
                RHOnly = true; 
            }

            ConfirmActionWindow confirmActionWindow = new ConfirmActionWindow();
            confirmActionWindow.partWOID = woidString;
            confirmActionWindow.partNumber = partNumberString;
            confirmActionWindow.partWOIDRH = woidStringRH;
            confirmActionWindow.partNumberRH = partNumberRHString;

            if (!string.IsNullOrEmpty(woidStringRH) && (woidString != woidStringRH))
            {
                RH = true;
            }

            SecondarySchedule SecondarySchedule_Part = new SecondarySchedule();

            confirmActionWindow.ShowDialog();
            if (confirmActionWindow.confirmActionButtonSelected)
            {
                //Series of sql calls to gather data
                using (SqlConnection sqlConnection = new SqlConnection(connStr_PBET))
                {

                    Cursor.Current = Cursors.WaitCursor;
                    try
                    {
                        sqlConnection.Open();
                        using (SqlCommand sqlCommand = new SqlCommand("spGetPartAndUpdateToInline", sqlConnection))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            sqlCommand.Parameters.AddWithValue("@WOID", woidString);
                            sqlCommand.Parameters.AddWithValue("@PAINTSTATION", paintStation);
                            var sqlReader = sqlCommand.ExecuteReader();

                            sqlReader.Read();
                            if (sqlReader.HasRows)
                            {
                                SecondarySchedule_Part.SequenceNumber = sqlReader.GetString(1);
                                SecondarySchedule_Part.JobNumber = sqlReader.GetString(2);
                                SecondarySchedule_Part.SetNumber = sqlReader.GetString(3);
                                SecondarySchedule_Part.PartNumber = sqlReader.GetString(4);
                                SecondarySchedule_Part.ColorCode = sqlReader.GetString(6);
                                SecondarySchedule_Part.ProductType = sqlReader.GetString(8);
                                SecondarySchedule_Part.Description = sqlReader.GetString(10);
                                SecondarySchedule_Part.RackCode = sqlReader.GetString(12);
                                SecondarySchedule_Part.RackPosition = sqlReader.GetString(13);
                                SecondarySchedule_Part.PaintBlock = sqlReader.GetString(18);
                                SecondarySchedule_Part.WOID = sqlReader.GetString(19);
                                SecondarySchedule_Part.PartRework = sqlReader.GetInt16(24);
                                SecondarySchedule_Part.PaintStation = paintStation;
                                //PRINTING WILL OCCURR HERE!

                                if (!RHOnly)
                                {
                                    PrintToZebraHelperLoader.PrintToZebra(SecondarySchedule_Part);
                                }

                                if (RH)
                                {
                                    SecondarySchedule_Part.PartNumberRH = sqlReader.GetString(5);
                                    SecondarySchedule_Part.DescriptionRH = sqlReader.GetString(11);
                                    SecondarySchedule_Part.RackPositionRH = sqlReader.GetString(14);
                                    SecondarySchedule_Part.WOIDRH = sqlReader.GetString(20);

                                    PrintToZebraHelperLoader.PrintToZebra(SecondarySchedule_Part, RH);
                                }

                                

                                debugLabel.Text = "Part moved to inline success!";
                            }
                            else
                            {
                                debugLabel.Text = "Part does not exist or is inline!";
                            }

                            sqlCommand.Dispose();
                            sqlReader.Close();
                        }

                        //ADD THE INLINE HISTORY INSERT HERE
                        using (SqlCommand sqlCommand = new SqlCommand("spInsertIntoInlineHistory", sqlConnection))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            sqlCommand.Parameters.AddWithValue("@SEQUENCENUMBER", SecondarySchedule_Part.SequenceNumber);
                            sqlCommand.Parameters.AddWithValue("@JOBNUMBER", SecondarySchedule_Part.JobNumber);
                            sqlCommand.Parameters.AddWithValue("@WOID", SecondarySchedule_Part.WOID);
                            sqlCommand.Parameters.AddWithValue("@WOIDRH", SecondarySchedule_Part.WOIDRH);
                            sqlCommand.Parameters.AddWithValue("@PARTNUMBER", SecondarySchedule_Part.PartNumber);
                            sqlCommand.Parameters.AddWithValue("@PARTNUMBERRH", SecondarySchedule_Part.PartNumberRH);
                            sqlCommand.Parameters.AddWithValue("@PARTDESCRIPTION", SecondarySchedule_Part.Description);
                            sqlCommand.Parameters.AddWithValue("@PARTDESCRIPTIONRH", SecondarySchedule_Part.DescriptionRH);
                            sqlCommand.Parameters.AddWithValue("@COLORCODE", SecondarySchedule_Part.ColorCode);
                            sqlCommand.Parameters.AddWithValue("@SETNUMBER", SecondarySchedule_Part.SetNumber);
                            sqlCommand.Parameters.AddWithValue("@RACKCODE", SecondarySchedule_Part.RackCode);
                            sqlCommand.Parameters.AddWithValue("@PRODUCTTYPE", SecondarySchedule_Part.ProductType);
                            sqlCommand.Parameters.AddWithValue("@PAINTDATE", SecondarySchedule_Part.PaintDate);
                            sqlCommand.Parameters.AddWithValue("@PAINTSTATION", SecondarySchedule_Part.PaintStation);
                            sqlCommand.Parameters.AddWithValue("@PARTREWORK", SecondarySchedule_Part.PartRework);

                            sqlCommand.ExecuteNonQuery();
                            sqlCommand.Dispose();
                        }

                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message, "Print Label OnClick Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Console.WriteLine(err);
                        this.Close();
                    }

                    Cursor.Current = Cursors.Default;
                    RefreshPartsOnFloorTable();
                }
            }
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //REALLY?
            if (e.RowIndex == -1)
                return;

            ConfirmActionWindow confirmActionWindow = new ConfirmActionWindow();
            confirmActionWindow.actionState = 1;

            //LOAD DOUBLE CLICK
            string woidString = dataGridView2.Rows[e.RowIndex].Cells[19].Value.ToString();
            string woidStringRH = dataGridView2.Rows[e.RowIndex].Cells[20].Value.ToString();
            string partNumberString = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
            string partNumberRHString = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();

            confirmActionWindow.partWOID = woidString;
            confirmActionWindow.partNumber = partNumberString;
            confirmActionWindow.partWOIDRH = woidStringRH;
            confirmActionWindow.partNumberRH = partNumberRHString;

            confirmActionWindow.ShowDialog();

            if (confirmActionWindow.confirmActionButtonSelected)
            {
                //Series of sql calls to gather data
                using (SqlConnection sqlConnection = new SqlConnection(connStr_PBET))
                {

                    Cursor.Current = Cursors.WaitCursor;
                    try
                    {
                        sqlConnection.Open();
                        using (SqlCommand sqlCommand = new SqlCommand("spResetPartByWOID", sqlConnection))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            sqlCommand.Parameters.AddWithValue("@WOID", woidString);
                            sqlCommand.ExecuteNonQuery();
                            sqlCommand.Dispose();
                        }

                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message, "Confirm Action Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Console.WriteLine(err);
                        this.Close();
                    }

                    Cursor.Current = Cursors.Default;
                    RefreshPartsOnFloorTable();
                }
            }

        }

        //PRIMER SEARCH BUTTONS
        private void primerSearchBtn_Click(object sender, EventArgs e)
        {

            SearchTxtBox.Text = SearchTxtBox.Text.Trim();

            if (String.IsNullOrEmpty(SearchTxtBox.Text))
            {
                SearchTxtBox.Clear();
                RefreshPartsOnFloorTable();
                RefreshPartsInlineTable();
                return;
            }

            DataSet floorPartsDataSet = new DataSet();
            DataSet inlinePartsDataSet = new DataSet();

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
                        using (SqlCommand sqlCommand = new SqlCommand("spSearchPrimerPartsByJobNumber", sqlConnection))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            sqlCommand.Parameters.AddWithValue("@JobNumber", SearchTxtBox.Text.ToString());

                            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                            {
                                sqlDataAdapter.Fill(floorPartsDataSet, "SecondaryScheduleFloorParts");
                            }

                            ThreadSafe(() => dataGridView1.DataSource = floorPartsDataSet);
                            ThreadSafe(() => dataGridView1.DataMember = "SecondaryScheduleFloorParts");

                        }
                    }
                    else
                    {
                        //Execute the stored procedure for Parts OnFloor
                        //and update the data grid view
                        using (SqlCommand sqlCommand = new SqlCommand("spSearchOnFloorPrimerPartsByWOID", sqlConnection))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            sqlCommand.Parameters.AddWithValue("@WOID", SearchTxtBox.Text.ToString());

                            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                            {
                                sqlDataAdapter.Fill(floorPartsDataSet, "SecondaryScheduleFloorParts");
                            }

                            ThreadSafe(() => dataGridView1.DataSource = floorPartsDataSet);
                            ThreadSafe(() => dataGridView1.DataMember = "SecondaryScheduleFloorParts");

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

        private void primerReworkSearchBtn_Click(object sender, EventArgs e)
        {
            DataSet floorPartsDataSet = new DataSet();
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
                    using (SqlCommand sqlCommand = new SqlCommand("spGetOnFloorReworkPrimerParts", sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                        {
                            sqlDataAdapter.Fill(floorPartsDataSet, "SecondaryScheduleFloorParts");
                        }

                        ThreadSafe(() => dataGridView1.DataSource = floorPartsDataSet);
                        ThreadSafe(() => dataGridView1.DataMember = "SecondaryScheduleFloorParts");

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

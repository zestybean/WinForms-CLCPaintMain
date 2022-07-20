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

namespace CKPaint
{
    public partial class ColorQueueForm : Form
    {   //This connection string is called from App.config file, alternatively it could also be hardcoded into this string var.
        string connStr_PBET = ConfigurationManager.ConnectionStrings["PBET"].ConnectionString;


        public ColorQueueForm()
        {
            InitializeComponent();
        }

        private void ColorQueueForm_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.MultiSelect = false;

            GetMLColorQueue();
            GetMLColorQueueHistory();
        }

        private void GetMLColorQueue ()
        {
            DataSet ColorQueueDataSet = new DataSet();
            
            //Series of sql calls to gather data
            using (SqlConnection sqlConnection = new SqlConnection(connStr_PBET))

            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    sqlConnection.Open();

                    //Execute the stored procedure for Parts Inline
                    //and update the data grid view
                    using (SqlCommand sqlCommand = new SqlCommand("spGetMLColorQueue", sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                        {
                            sqlDataAdapter.Fill(ColorQueueDataSet, "MLColorQueue");
                        }
                        dataGridView1.DataSource = ColorQueueDataSet;
                        dataGridView1.DataMember = "MLColorQueue";
                    }
                    //Close connection after table is filled
                    sqlConnection.Close();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Load Table Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine(err);
                    this.Close();
                }

                Cursor.Current = Cursors.Default;
            }

        }


        private void GetMLColorQueueHistory()
        {
            DataSet ColorQueueDataSet = new DataSet();

            //Series of sql calls to gather data
            using (SqlConnection sqlConnection = new SqlConnection(connStr_PBET))

            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    sqlConnection.Open();

                    //Execute the stored procedure for Parts Inline
                    //and update the data grid view
                    using (SqlCommand sqlCommand = new SqlCommand("spGetMLColorQueueHistory", sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                        {
                            sqlDataAdapter.Fill(ColorQueueDataSet, "MLColorQueueHistory");
                        }
                        dataGridView2.DataSource = ColorQueueDataSet;
                        dataGridView2.DataMember = "MLColorQueueHistory";
                    }
                    //Close connection after table is filled
                    sqlConnection.Close();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Load Table Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine(err);
                    this.Close();
                }

                Cursor.Current = Cursors.Default;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetMLColorQueue();
            GetMLColorQueueHistory();
        }
    }
}


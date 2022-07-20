using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CKPaint
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            setPlantSiteLabels();
            setVersion();
        }

        private void partLoaderBtn_Click(object sender, EventArgs e)
        {
            if(CKPaint.Properties.Settings.Default["Station"].ToString().Trim().ToUpper() == "QA")
            {
                return;
            }

            if (CKPaint.Properties.Settings.Default["Station"].ToString().Trim().ToUpper() == "USER")
            {
                return;
            }


            this.Hide();
            Form loaderWindow = new PartLoader();
            loaderWindow.ShowDialog();
            this.Show();
            
        }
               
        private void partScanBtn_Click(object sender, EventArgs e)
        {
            if (CKPaint.Properties.Settings.Default["Station"].ToString().Trim().ToUpper() == "QA")
            {
                return;
            }

            if (CKPaint.Properties.Settings.Default["Station"].ToString().Trim().ToUpper() == "USER")
            {
                return;
            }

            this.Hide();
            Form scanWindow = new PartScanForm();
            scanWindow.ShowDialog();
            this.Show();

        }

        private void partDispositionBtn_Click(object sender, EventArgs e)
        {
            if (CKPaint.Properties.Settings.Default["Station"].ToString().Trim().ToUpper() != "QA")
            {
                return;
            }

            if (CKPaint.Properties.Settings.Default["Station"].ToString().Trim().ToUpper() == "USER")
            {
                return;
            }

            this.Hide();
            Form dispositionWindow = new PartDisposition();
            dispositionWindow.ShowDialog();
            this.Show();
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            Form settingsWindow = new SettingsWindow();
            settingsWindow.ShowDialog();
            setPlantSiteLabels();
        }

        private void setPlantSiteLabels()
        {
            plantLabel.Text = "Plant:   " + CKPaint.Properties.Settings.Default["Plant"];
            siteLabel.Text = "Site:     " + CKPaint.Properties.Settings.Default["Site"];
        }

        private void monitorButton_Click(object sender, EventArgs e)
        {
            //ADD Inline Viewer Form
            MonitorReportForm monitorReportForm = new MonitorReportForm();
            monitorReportForm.ShowDialog();
        }

        private void setVersion()
        {
            versionLabel.Text = versionLabel.Text + CKPaint.Properties.Settings.Default["Version"].ToString().Trim().ToUpper();
        }

        private void colorQueueBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            ColorQueueForm colorQueueForm = new ColorQueueForm();
            colorQueueForm.ShowDialog();
            this.Show();
        }
    }
}

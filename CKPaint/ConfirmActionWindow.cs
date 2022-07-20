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
    public partial class ConfirmActionWindow : Form
    {
        /// <summary>
        /// 0 = Normal Print Label
        /// 1 = Move Part Back
        /// </summary>
        public int actionState = 0;
        public bool confirmActionButtonSelected = false;
        public string partWOID = "";
        public string partNumber = "";

        public string partWOIDRH = "";
        public string partNumberRH = "";

        public ConfirmActionWindow()
        {
            InitializeComponent();
        }

        private void ConfirmActionWindow_Load(object sender, EventArgs e)
        {
            woidTxtLbl.Text = partWOID;
            partNumTxtLbl.Text = partNumber;

            woidRHTxtLbl.Text = partWOIDRH;
            partNumRHTxtLbl.Text = partNumberRH;


            if (actionState == 0)
            {
                warningPanel.BackColor = Color.Gold;
                warningLogo.BackColor = Color.Transparent;
                codeDescriptionLabel.Visible = false;
                codeLabel.Visible = false;
                passwordTextBox.Visible = false;
                confirmButton.Text = "Print Label";

            } else if(actionState == 1)
            {
                warningPanel.BackColor = Color.Red;
                warningLogo.BackColor = Color.Transparent;
                codeDescriptionLabel.Visible = true;
                codeLabel.Visible = true;
                passwordTextBox.Visible = true;
                instructionBox.Visible = false;
                confirmButton.Text = "Confirm";
                confirmButton.BackColor = Color.ForestGreen;
                partNumTxtLbl.ForeColor = Color.Black;
                partNumRHTxtLbl.ForeColor = Color.Black;
                woidTxtLbl.ForeColor = Color.Black;
                woidRHTxtLbl.ForeColor = Color.Black;
                this.BackColor = Color.Firebrick;
                Blink();
            } else
            {
                woidTxtLbl.Text = "MAJOR ERROR";
            }
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
          if(actionState == 1)
            {
                if(passwordTextBox.Text == "super")
                {

                    confirmActionButtonSelected = true;
                    this.Close();
                } else
                {
                    return;
                }

            } else
            {
                confirmActionButtonSelected = true;
                this.Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void Blink()
        {
            while (true)
            {
                await Task.Delay(400);
                warningPanel.BackColor = warningPanel.BackColor == Color.DarkRed ? Color.Red : Color.DarkRed;
            }
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logix;

namespace CKPaint
{
    public class PLC
    {
        Controller LogixPLC = new Controller();
        Tag Tag = new Tag();
        Tag WriteTag = new Tag();


        public bool Connect(string ipaddress)
        {
            //Connect to the PLC given its IP address.
            bool rslt = false;

            try
            {
                LogixPLC.IPAddress = ipaddress;
                LogixPLC.CPUType = Controller.CPU.LOGIX;
                LogixPLC.Timeout = 3000;

                if (LogixPLC.Connect() == ResultCode.E_SUCCESS)
                {
                    rslt = true;

                }
            }
            catch (System.Exception ex)
            {
                //MessageBox.Show("Error : " + LogixPLC.ErrorString, this.Text);
            }

            return rslt;
        }

        public void Disconnect()
        {
            try
            {
                LogixPLC.Disconnect();
               
            }
            catch (System.Exception ex)
            {
                //MessageBox.Show("Error : " + LogixPLC.ErrorString, this.Text);
            }
                       
        }

        public int ReadPLCIntegerTag(string tagaddress)
        {
            //This function reads a DINT (double integer / 32 bit integer) tag from the PLC. 
            int rslt = -1;

            try
            {
                Tag = new Tag(tagaddress);
                Tag.DataType = Tag.ATOMIC.DINT;
                Tag.Length = 1;

                rslt = LogixPLC.ReadTag(Tag);

                if (rslt != ResultCode.E_SUCCESS)
                {
                    //MessageBox.Show("Error : " + LogixPLC.ErrorString, this.Text);
                    return -99;
                }

            }
            catch (System.Exception ex)
            {
                //MessageBox.Show("Error : " + LogixPLC.ErrorString, this.Text);
                return -99;
            }

            return rslt;
        }

        public string ReadPLCStringTag(string tagaddress)
        {
            //This function reads a string tag from the PLC.
            string rslt = "-1"; 
            
            try
            {
                Tag = new Tag(tagaddress);
                Tag.DataType = Tag.ATOMIC.STRING;
                Tag.Length = 1;
                                

                if (LogixPLC.ReadTag(Tag) != ResultCode.E_SUCCESS)
                {
                    //MessageBox.Show("Error : " + LogixPLC.ErrorString, this.Text);
                    return "-99";
                }
                else
                {
                    //Read Success
                    rslt = Tag.Value.ToString();
                }

            }
            catch (System.Exception ex)
            {
                //MessageBox.Show("Error : " + LogixPLC.ErrorString, this.Text);
                return "-99";
            }

            return rslt;
        }

        public bool WritePLCTag(string tagaddress, int tagvalue)
        {
            //This function writes an integer value to the PLC. 
            bool rslt = false;

            try
            {
                WriteTag = new Tag(tagaddress);
                WriteTag.Value = tagvalue;
                WriteTag.DataType = Tag.ATOMIC.DINT;
               
                if (LogixPLC.WriteTag(WriteTag) == ResultCode.E_SUCCESS)
                {
                    rslt = true;
                }

            }
            catch (System.Exception ex)
            {
                //MessageBox.Show("Error : " + LogixPLC.ErrorString, this.Text);
            }

            return rslt;
        }

        public bool WritePLCTagString(string tagaddress, string tagvalue)
        {
            //This function writes an integer value to the PLC. 
            bool rslt = false;

            try
            {
                WriteTag = new Tag(tagaddress);
                WriteTag.Value = tagvalue;
                WriteTag.DataType = Tag.ATOMIC.STRING;
               
                if (LogixPLC.WriteTag(WriteTag) == ResultCode.E_SUCCESS)
                {
                    rslt = true;
                }

            }
            catch (System.Exception ex)
            {
                //MessageBox.Show("Error : " + LogixPLC.ErrorString, this.Text);
            }

            return rslt;
        }
    }
}

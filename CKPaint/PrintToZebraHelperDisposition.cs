using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

public static class PrintToZebraHelperDisposition
{ 
    public static bool PrintToZebra(CKPaint.PartDispositionHistory secondarySchedule_Part, bool RH = false)
    {
        string IPADDRESS = CKPaint.Properties.Settings.Default["Printer"].ToString();
        int PORT = 9100;

        string labelPath = @"\\hail\Shared\Pace Board\CK Paint Label Format\CK Paint Label.txt";

        System.IO.StreamReader fileReader = new System.IO.StreamReader(labelPath);
        string fileContent = fileReader.ReadToEnd().ToString();

        if (secondarySchedule_Part.ProductType.Contains("MLU") || secondarySchedule_Part.ProductType == "Bumper")
        {  
            if (RH)
            {
                fileContent = fileContent.Replace("@JN", secondarySchedule_Part.JobNumber).Replace("@LS", secondarySchedule_Part.SequenceNumber)
               .Replace("@P", secondarySchedule_Part.PartNumberRH).Replace("@CC", secondarySchedule_Part.ColorCode)
               .Replace("@WOID", secondarySchedule_Part.WOIDRH).Replace("@DT", System.DateTime.Now.ToString())
               .Replace("@DIS", secondarySchedule_Part.PartDisposition)
               .Replace("@REV", secondarySchedule_Part.InspectorName)
               .Replace("@LP", CKPaint.Properties.Settings.Default["Plant"].ToString());
            }
            else
            {
                fileContent = fileContent.Replace("@JN", secondarySchedule_Part.JobNumber).Replace("@LS", secondarySchedule_Part.SequenceNumber)
               .Replace("@P", secondarySchedule_Part.PartNumber).Replace("@CC", secondarySchedule_Part.ColorCode)
               .Replace("@WOID", secondarySchedule_Part.WOID).Replace("@DT", System.DateTime.Now.ToString())
               .Replace("@DIS", secondarySchedule_Part.PartDisposition)
               .Replace("@REV", secondarySchedule_Part.InspectorName)
               .Replace("@LP", CKPaint.Properties.Settings.Default["Plant"].ToString());
            }
        } else
        {
            if (RH)
            {
                fileContent = fileContent.Replace("@JN", secondarySchedule_Part.JobNumber)
               .Replace("@P", secondarySchedule_Part.PartNumberRH).Replace("@CC", secondarySchedule_Part.ColorCode)
               .Replace("@WOID", secondarySchedule_Part.WOIDRH).Replace("@DT", System.DateTime.Now.ToString())
               .Replace("@DIS", secondarySchedule_Part.PartDisposition)
               .Replace("@REV", secondarySchedule_Part.InspectorName)
               .Replace("@LP", CKPaint.Properties.Settings.Default["Plant"].ToString());
            }
            else
            {
                fileContent = fileContent.Replace("@JN", secondarySchedule_Part.JobNumber)
               .Replace("@P", secondarySchedule_Part.PartNumber).Replace("@CC", secondarySchedule_Part.ColorCode)
               .Replace("@WOID", secondarySchedule_Part.WOID).Replace("@DT", System.DateTime.Now.ToString())
               .Replace("@DIS", secondarySchedule_Part.PartDisposition)
               .Replace("@REV", secondarySchedule_Part.InspectorName)
               .Replace("@LP", CKPaint.Properties.Settings.Default["Plant"].ToString());
            }
        }

       
       
        try
        {
            //Open zebra connection
            System.Net.Sockets.TcpClient printer = new System.Net.Sockets.TcpClient();

            if (!printer.ConnectAsync(IPADDRESS, PORT).Wait(1000))
            {
                //MAYBE? SEND PART BACK?


                throw new Exception("Failed to connect to printer.");
                
                
            }

           // printer.Connect(IPADDRESS, PORT);
            //Write label file
            System.IO.StreamWriter writer = new System.IO.StreamWriter(printer.GetStream());
            writer.Write(fileContent);
            writer.Flush();

            writer.Close();
            printer.Close();
         
        }
        catch (Exception err)
        {
            MessageBox.Show(err.Message, "Print Label OnClick Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Console.WriteLine(err);

            return false;
        }

        fileReader.Close();

        return true;
    }

}
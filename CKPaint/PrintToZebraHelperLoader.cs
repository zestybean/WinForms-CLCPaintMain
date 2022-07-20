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

public static class PrintToZebraHelperLoader
{ 
    public static bool PrintToZebra(CKPaint.SecondarySchedule secondarySchedule_Part, bool RH = false)
    {
        string IPADDRESS = CKPaint.Properties.Settings.Default["Printer"].ToString();
        int PORT = 9100;

        string labelPath = @"\\hail\Shared\Pace Board\CK Paint Label Format\CK Paint Label.txt";

        System.IO.StreamReader fileReader = new System.IO.StreamReader(labelPath);
        string fileContent = fileReader.ReadToEnd().ToString();

        string reworkPart = "";

        if (secondarySchedule_Part.PartRework == 1)
        {
            reworkPart = "RP";
        }
        if (secondarySchedule_Part.ProductType.Contains("MLU") || secondarySchedule_Part.ProductType == "Bumper")
        {  
            if (RH)
            {
                fileContent = fileContent.Replace("@JN", secondarySchedule_Part.JobNumber).Replace("@LS", secondarySchedule_Part.SequenceNumber)
               .Replace("@P", secondarySchedule_Part.PartNumberRH).Replace("@CC", secondarySchedule_Part.ColorCode)
               .Replace("@DES", secondarySchedule_Part.DescriptionRH).Replace("@RC", secondarySchedule_Part.RackCode)
               .Replace("@RP", secondarySchedule_Part.RackPositionRH).Replace("@BLK", secondarySchedule_Part.PaintBlock)
               .Replace("@WOID", secondarySchedule_Part.WOIDRH).Replace("@DT", System.DateTime.Now.ToString())
               .Replace("@DIS", reworkPart)
               .Replace("@REV", CKPaint.Properties.Settings.Default["Station"].ToString())
               .Replace("@LP", CKPaint.Properties.Settings.Default["Plant"].ToString());
            }
            else
            {
                fileContent = fileContent.Replace("@JN", secondarySchedule_Part.JobNumber).Replace("@LS", secondarySchedule_Part.SequenceNumber)
               .Replace("@P", secondarySchedule_Part.PartNumber).Replace("@CC", secondarySchedule_Part.ColorCode)
               .Replace("@DES", secondarySchedule_Part.Description).Replace("@RC", secondarySchedule_Part.RackCode)
               .Replace("@RP", secondarySchedule_Part.RackPosition).Replace("@BLK", secondarySchedule_Part.PaintBlock)
               .Replace("@WOID", secondarySchedule_Part.WOID).Replace("@DT", System.DateTime.Now.ToString())
               .Replace("@DIS", reworkPart.ToString())
               .Replace("@REV", CKPaint.Properties.Settings.Default["Station"].ToString())
               .Replace("@LP", CKPaint.Properties.Settings.Default["Plant"].ToString());
            }
        } else
        {
            if (RH)
            {
                fileContent = fileContent.Replace("@JN", secondarySchedule_Part.JobNumber).Replace("@LS", secondarySchedule_Part.SetNumber)
               .Replace("@P", secondarySchedule_Part.PartNumberRH).Replace("@CC", secondarySchedule_Part.ColorCode)
               .Replace("@DES", secondarySchedule_Part.DescriptionRH).Replace("@RC", secondarySchedule_Part.RackCode)
               .Replace("@RP", secondarySchedule_Part.RackPositionRH).Replace("@BLK", secondarySchedule_Part.PaintBlock)
               .Replace("@WOID", secondarySchedule_Part.WOIDRH).Replace("@DT", System.DateTime.Now.ToString())
               .Replace("@DIS", reworkPart)
               .Replace("@REV", CKPaint.Properties.Settings.Default["Station"].ToString())
               .Replace("@LP", CKPaint.Properties.Settings.Default["Plant"].ToString());
            }
            else
            {
                fileContent = fileContent.Replace("@JN", secondarySchedule_Part.JobNumber).Replace("@LS", secondarySchedule_Part.SetNumber)
               .Replace("@P", secondarySchedule_Part.PartNumber).Replace("@CC", secondarySchedule_Part.ColorCode)
               .Replace("@DES", secondarySchedule_Part.Description).Replace("@RC", secondarySchedule_Part.RackCode)
               .Replace("@RP", secondarySchedule_Part.RackPosition).Replace("@BLK", secondarySchedule_Part.PaintBlock)
               .Replace("@WOID", secondarySchedule_Part.WOID).Replace("@DT", System.DateTime.Now.ToString())
               .Replace("@DIS", reworkPart.ToString())
               .Replace("@REV", CKPaint.Properties.Settings.Default["Station"].ToString())
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
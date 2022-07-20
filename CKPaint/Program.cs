using System;
using System.Windows.Forms;

namespace CKPaint
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool result;

            var mutex = new System.Threading.Mutex(true, "CKPaint", out result);

            if (!result)
            {
                MessageBox.Show("CK PAINT is already running.", "Warning!", MessageBoxButtons.OK);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Home());

            GC.KeepAlive(mutex);
        }
    }

}

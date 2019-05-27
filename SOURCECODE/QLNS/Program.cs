using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLNS.GUI;
namespace QLNS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DialogResult result;
            //using (Form1 login = new Form1())
            //    result = login.ShowDialog();
            //if (result == DialogResult.OK)
                Application.Run(new MainForm());
            //Application.Run(new MainForm());
        }
    }
}

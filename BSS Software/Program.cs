using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BSSSoftware
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
           //Application.Run(new CodeSetup.SMerchant());
            //Application.Run(new frmReceipt());
            //Application.Run(new ProductSale.Sale());
            Application.Run(new Main());
        }
    }
}

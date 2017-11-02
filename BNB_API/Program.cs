using Newtonsoft.Json.Linq;
using System;
using System.Windows.Forms;

namespace BNB_API
{
    public class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormBNB());

        }
    }

}

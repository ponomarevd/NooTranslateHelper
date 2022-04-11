using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NooTranslateHelper
{
    internal static class Program
    {
        public static string FileName;
        public static string RealFileName;
        public static string FilePath;
        public static ApplicationContext Context { get; set; }
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Context = new ApplicationContext(new Form1());
            Application.Run(Context);
        }
    }
}

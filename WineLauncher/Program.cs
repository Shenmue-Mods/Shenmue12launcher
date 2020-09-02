using System;
using System.Windows.Forms;

namespace WineLauncher
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0 && args[args.Length - 1] == "sm1")
            {
                ShenmueLauncherWin.StartGame(GameToRun.Shenmue1);
            }
            else if (args.Length > 0 && args[args.Length - 1] == "sm2")
            {
                ShenmueLauncherWin.StartGame(GameToRun.Shenmue2);
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new ShenmueLauncherWin());
            }
        }
    }
}

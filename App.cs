using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;

namespace SteamLauncher
{
	public class App : Application
	{
		public App()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			base.StartupUri = new Uri("ShenmueLauncherWindow.xaml", UriKind.Relative);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[STAThread]
		public static void Main(string[] args)
        {
            App app = new App();
            if (args.Length > 0 && args[args.Length-1] == "sm1")
            {
                ShenmueLauncherWindow.AutoLaunch = ShenmueLauncherWindow.GameType.SM1;
            }
            else if (args.Length > 0 && args[args.Length-1] == "sm2")
            {
                ShenmueLauncherWindow.AutoLaunch = ShenmueLauncherWindow.GameType.SM2;
            }
            app.InitializeComponent();
            app.Run();
		}
	}
}
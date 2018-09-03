using SharpDX.XInput;
using SteamLauncher.Properties;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace SteamLauncher
{
	public partial class ShenmueLauncherWindow : Window
	{
		private const double kFadeValue = 0.2;

		private const double kMaxNormalFade = 0.65;

		private const double kWhite = 1;

		private const double kBlack = 0;

		private const string kSm1PathDebug = "sm1/S1XP_x64Release.exe";

		private const string kSm2PathDebug = "sm2/S2X_x64Release.exe";

		private const string kSm1Path = "sm1/Shenmue.exe";

		private const string kSm2Path = "sm2/Shenmue2.exe";

		private const string kSm1Dir = "sm1";

		private const string kSm2Dir = "sm2";

		private ShenmueLauncherWindow.GameType mLastGamePlayed;

		private bool mGameLaunching;

		private MediaPlayer[] mSounds = new MediaPlayer[3];

		private Controller[] mController;

		private DispatcherTimer mControllerTimer = new DispatcherTimer();

        public static GameType? AutoLaunch { get; set; }

        public ShenmueLauncherWindow()
		{
			this.InitializeComponent();
            if (AutoLaunch == null)
            {
                this.mController = new Controller[] { new Controller(UserIndex.One), new Controller(UserIndex.Two), new Controller(UserIndex.Three), new Controller(UserIndex.Four) };
                if ((this.mController[0].IsConnected || this.mController[1].IsConnected || this.mController[2].IsConnected ? true : this.mController[3].IsConnected))
                {
                    this.mControllerTimer = new DispatcherTimer()
                    {
                        Interval = TimeSpan.FromMilliseconds(16)
                    };
                    this.mControllerTimer.Tick += new EventHandler(this.Controller_Tick);
                    this.mControllerTimer.Start();
                }
                for (int i = 0; i < 3; i++)
                {
                    this.mSounds[i] = new MediaPlayer();
                }
                this.mSounds[0].Open(new Uri("bg_music.wav", UriKind.RelativeOrAbsolute));
                this.PlaySound(ShenmueLauncherWindow.SoundIndex.Background);
                this.mSounds[0].MediaEnded += new EventHandler(this.MediaPlayer_MediaEnded);
                this.mSounds[1].Open(new Uri("menu_move.wav", UriKind.RelativeOrAbsolute));
                this.mSounds[2].Open(new Uri("menu_select.wav", UriKind.RelativeOrAbsolute));
                this.mSounds[1].Volume = 0.1;
                this.mSounds[2].Volume = 0.1;
            }
			this.LoadUserSettings();
            if(AutoLaunch != null)
            {
                mLastGamePlayed = AutoLaunch.Value;
                Launch_Anim_Complete(this, null);
            }
		}

		private void button_sm1_Click(object sender, RoutedEventArgs e)
		{
			this.PrepareLaunchGame(this.mLastGamePlayed);
		}

		private void button_sm2_Click(object sender, RoutedEventArgs e)
		{
			this.PrepareLaunchGame(this.mLastGamePlayed);
		}

		private void Controller_Tick(object sender, EventArgs e)
		{
			for (int i = 0; i < 4; i++)
			{
				if (this.mController[i].IsConnected)
				{
					State state = this.mController[i].GetState();
					bool flag = (state.Gamepad.Buttons == GamepadButtonFlags.A ? true : state.Gamepad.Buttons == GamepadButtonFlags.Start);
					bool buttons = state.Gamepad.Buttons == GamepadButtonFlags.DPadLeft;
					bool buttons1 = state.Gamepad.Buttons == GamepadButtonFlags.DPadRight;
					short leftThumbX = state.Gamepad.LeftThumbX;
					if (leftThumbX < -8191 | buttons)
					{
						this.MoveLeft();
						return;
					}
					if (leftThumbX > 8191 | buttons1)
					{
						this.MoveRight();
						return;
					}
					if (flag)
					{
						this.PrepareLaunchGame(this.mLastGamePlayed);
						return;
					}
				}
			}
		}

		private void Fade_Anim_Complete(object sender, EventArgs e)
		{
			if (this.mLastGamePlayed == ShenmueLauncherWindow.GameType.SM1)
			{
				this.FadeButton(0, this.button_sm1, ShenmueLauncherWindow.NextTask.LaunchGame);
				return;
			}
			this.FadeButton(0, this.button_sm2, ShenmueLauncherWindow.NextTask.LaunchGame);
		}

		private void FadeButton(double target, Button button, ShenmueLauncherWindow.NextTask nextTask)
		{
			DoubleAnimation doubleAnimation = new DoubleAnimation()
			{
				To = new double?(target),
				BeginTime = new TimeSpan?(TimeSpan.Zero),
				Duration = TimeSpan.FromSeconds(0.5),
				FillBehavior = FillBehavior.Stop
			};
			doubleAnimation.Completed += new EventHandler((object s, EventArgs a) => button.Opacity = target);
			button.BeginAnimation(UIElement.OpacityProperty, doubleAnimation);
			switch (nextTask)
			{
				case ShenmueLauncherWindow.NextTask.None:
				{
					return;
				}
				case ShenmueLauncherWindow.NextTask.FadeToBlack:
				{
					doubleAnimation.Completed += new EventHandler(this.Fade_Anim_Complete);
					return;
				}
				case ShenmueLauncherWindow.NextTask.LaunchGame:
				{
					doubleAnimation.Completed += new EventHandler(this.Launch_Anim_Complete);
					return;
				}
				default:
				{
					return;
				}
			}
		}

		private void Launch_Anim_Complete(object sender, EventArgs e)
		{
			string[] commandLineArgs = Environment.GetCommandLineArgs();
			bool flag = ((int)commandLineArgs.Length <= 1 ? false : commandLineArgs[1] == "debug");
			if (this.mLastGamePlayed == ShenmueLauncherWindow.GameType.SM1)
			{
				this.StartGame((flag ? "sm1/S1XP_x64Release.exe" : "sm1/Shenmue.exe"), "sm1");
				return;
			}
			this.StartGame((flag ? "sm2/S2X_x64Release.exe" : "sm2/Shenmue2.exe"), "sm2");
		}

		private void LoadUserSettings()
		{
			int lastLaunched = 0;
			try
			{
				lastLaunched = Settings.Default.LastLaunched;
			}
			catch (Exception exception)
			{
				Console.WriteLine("Failed to load user settings");
			}
			this.mLastGamePlayed = (ShenmueLauncherWindow.GameType)lastLaunched;
			ShenmueLauncherWindow.GameType gameType = this.mLastGamePlayed;
			if (gameType == ShenmueLauncherWindow.GameType.SM1 || gameType != ShenmueLauncherWindow.GameType.SM2)
			{
				this.button_sm1.Focus();
				this.FadeButton(0.65, this.button_sm1, ShenmueLauncherWindow.NextTask.None);
				this.FadeButton(0.2, this.button_sm2, ShenmueLauncherWindow.NextTask.None);
			}
			else
			{
				this.button_sm2.Focus();
				this.FadeButton(0.2, this.button_sm1, ShenmueLauncherWindow.NextTask.None);
				this.FadeButton(0.65, this.button_sm2, ShenmueLauncherWindow.NextTask.None);
			}
			Console.WriteLine(string.Concat("Last Game was: ", this.mLastGamePlayed.ToString()));
		}

		private void MediaPlayer_MediaEnded(object sender, EventArgs e)
		{
			this.mSounds[0].Position = TimeSpan.Zero;
			this.mSounds[0].Play();
		}

		private void mouse_enter_SM1(object sender, RoutedEventArgs e)
		{
			this.MoveLeft();
		}

		private void mouse_enter_SM2(object sender, RoutedEventArgs e)
		{
			this.MoveRight();
		}

		private void MoveLeft()
		{
			if (!this.mGameLaunching && this.mLastGamePlayed == ShenmueLauncherWindow.GameType.SM2)
			{
				this.PlaySound(ShenmueLauncherWindow.SoundIndex.MenuMove);
				this.mLastGamePlayed = ShenmueLauncherWindow.GameType.SM1;
				this.FadeButton(0.65, this.button_sm1, ShenmueLauncherWindow.NextTask.None);
				this.FadeButton(0.2, this.button_sm2, ShenmueLauncherWindow.NextTask.None);
			}
		}

		private void MoveRight()
		{
			if (!this.mGameLaunching && this.mLastGamePlayed == ShenmueLauncherWindow.GameType.SM1)
			{
				this.PlaySound(ShenmueLauncherWindow.SoundIndex.MenuMove);
				this.mLastGamePlayed = ShenmueLauncherWindow.GameType.SM2;
				this.FadeButton(0.2, this.button_sm1, ShenmueLauncherWindow.NextTask.None);
				this.FadeButton(0.65, this.button_sm2, ShenmueLauncherWindow.NextTask.None);
			}
		}

		private void on_key_down(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Return)
			{
				this.PrepareLaunchGame(this.mLastGamePlayed);
				return;
			}
			if (e.Key == Key.Left)
			{
				this.MoveLeft();
				return;
			}
			if (e.Key == Key.Right)
			{
				this.MoveRight();
				return;
			}
			if (e.Key == Key.Escape)
			{
				base.Close();
			}
		}

		private void PlaySound(ShenmueLauncherWindow.SoundIndex index)
		{
			if (index < ShenmueLauncherWindow.SoundIndex.SoundSize)
			{
				this.mSounds[(int)index].Position = TimeSpan.Zero;
				this.mSounds[(int)index].Play();
			}
		}

		private void PrepareLaunchGame(ShenmueLauncherWindow.GameType lastGamePlayed)
		{
			if (this.mGameLaunching)
			{
				return;
			}
			this.mGameLaunching = true;
			this.PlaySound(ShenmueLauncherWindow.SoundIndex.MenuSelect);
			this.mLastGamePlayed = lastGamePlayed;
			this.SaveUserSettings();
			if (this.mLastGamePlayed == ShenmueLauncherWindow.GameType.SM1)
			{
				this.FadeButton(1, this.button_sm1, ShenmueLauncherWindow.NextTask.FadeToBlack);
				return;
			}
			this.FadeButton(1, this.button_sm2, ShenmueLauncherWindow.NextTask.FadeToBlack);
		}

		private void SaveUserSettings()
		{
			try
			{
				Settings.Default.LastLaunched = (int)this.mLastGamePlayed;
				Settings.Default.Save();
			}
			catch (Exception exception)
			{
				Console.WriteLine("Failed to save user settings");
			}
		}

		private void StartGame(string filename, string dir)
		{
            if (mSounds[0] != null)
            {
                this.mSounds[0].Stop();
                this.mControllerTimer.Tick -= new EventHandler(this.Controller_Tick);
            }
			ProcessStartInfo processStartInfo = new ProcessStartInfo()
			{
				CreateNoWindow = false,
				UseShellExecute = false,
				FileName = filename,
				WindowStyle = ProcessWindowStyle.Hidden,
				WorkingDirectory = dir
			};
			base.Hide();
			try
			{
				using (Process process = Process.Start(processStartInfo))
				{
					process.WaitForExit();
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				Console.WriteLine(string.Format("Error Loading {0} -- {1}", filename, exception.Message));
			}
			try
			{
				base.Show();
			}
			catch (Exception exception3)
			{
				Exception exception2 = exception3;
				Console.WriteLine(string.Format("Error showing this window: E.what? {0} : E.src? {1}", exception2.Message, exception2.Source));
			}
			this.mGameLaunching = false;
            if (mSounds[0] != null)
            {
                this.LoadUserSettings();
                this.mSounds[0].Play();
                this.mControllerTimer.Tick += new EventHandler(this.Controller_Tick);
            }
            else
            {
                Close();
            }
		}

		public enum GameType
		{
			SM1,
			SM2
		}

		private enum NextTask
		{
			None,
			FadeToBlack,
			LaunchGame
		}

		private enum SoundIndex
		{
			Background,
			MenuMove,
			MenuSelect,
			SoundSize
		}
	}
}
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace WineLauncher
{
    public enum GameToRun { Shenmue1, Shenmue2 }

    public partial class ShenmueLauncherWin : Form
    {
        public ShenmueLauncherWin()
        {
            InitializeComponent();
            SetHoverImage(pbShenmue, 0, false, true);
            SetHoverImage(pbShenmue2, 2, false, true);
        }

        private void SetHoverImage(object sender, int offset, bool hover, bool startup = false)
        {
            if((Visible || startup) && sender is PictureBox box)
            {
                box.Image = imgList.Images[offset + (hover ? 1 : 0)];
            }
        }

        private void pbShenmue2_MouseEnter(object sender, EventArgs e)
        {
            SetHoverImage(pbShenmue2, 2, true);
        }

        private void pbShenmue2_MouseLeave(object sender, EventArgs e)
        {
            SetHoverImage(pbShenmue2, 2, false);
        }

        private void pbShenmue_MouseEnter(object sender, EventArgs e)
        {
            SetHoverImage(pbShenmue, 0, true);
        }

        private void pbShenmue_MouseLeave(object sender, EventArgs e)
        {
            SetHoverImage(pbShenmue, 0, false);
        }

        private void pbShenmue_Click(object sender, EventArgs e)
        {
            Hide();
            BeginInvoke(new Action(() => { StartGame(GameToRun.Shenmue1); }));
        }

        private void pbShenmue2_Click(object sender, EventArgs e)
        {
            Hide();
            BeginInvoke(new Action(() => { StartGame(GameToRun.Shenmue2); }));
        }

        public static void StartGame(GameToRun game)
        {
            string filename = "sm1/Shenmue.exe";
            string dir = "sm1";
            if(game == GameToRun.Shenmue2)
            {
                filename = "sm2/Shenmue2.exe";
                dir = "sm2";
            }
            ProcessStartInfo processStartInfo = new ProcessStartInfo()
            {
                CreateNoWindow = false,
                UseShellExecute = false,
                FileName = filename,
                WindowStyle = ProcessWindowStyle.Hidden,
                WorkingDirectory = dir
            };
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
            Application.Exit();
        }
    }
}

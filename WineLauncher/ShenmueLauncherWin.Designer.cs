namespace WineLauncher
{
    partial class ShenmueLauncherWin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShenmueLauncherWin));
            this.pbShenmue = new System.Windows.Forms.PictureBox();
            this.pbShenmue2 = new System.Windows.Forms.PictureBox();
            this.tblGames = new System.Windows.Forms.TableLayoutPanel();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbShenmue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbShenmue2)).BeginInit();
            this.tblGames.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbShenmue
            // 
            this.pbShenmue.BackColor = System.Drawing.Color.Black;
            this.pbShenmue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbShenmue.Location = new System.Drawing.Point(3, 3);
            this.pbShenmue.Name = "pbShenmue";
            this.pbShenmue.Size = new System.Drawing.Size(429, 427);
            this.pbShenmue.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbShenmue.TabIndex = 0;
            this.pbShenmue.TabStop = false;
            this.pbShenmue.Click += new System.EventHandler(this.pbShenmue_Click);
            this.pbShenmue.MouseEnter += new System.EventHandler(this.pbShenmue_MouseEnter);
            this.pbShenmue.MouseLeave += new System.EventHandler(this.pbShenmue_MouseLeave);
            // 
            // pbShenmue2
            // 
            this.pbShenmue2.BackColor = System.Drawing.Color.Black;
            this.pbShenmue2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbShenmue2.Location = new System.Drawing.Point(438, 3);
            this.pbShenmue2.Name = "pbShenmue2";
            this.pbShenmue2.Size = new System.Drawing.Size(429, 427);
            this.pbShenmue2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbShenmue2.TabIndex = 0;
            this.pbShenmue2.TabStop = false;
            this.pbShenmue2.Click += new System.EventHandler(this.pbShenmue2_Click);
            this.pbShenmue2.MouseEnter += new System.EventHandler(this.pbShenmue2_MouseEnter);
            this.pbShenmue2.MouseLeave += new System.EventHandler(this.pbShenmue2_MouseLeave);
            // 
            // tblGames
            // 
            this.tblGames.BackColor = System.Drawing.Color.Black;
            this.tblGames.ColumnCount = 2;
            this.tblGames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblGames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblGames.Controls.Add(this.pbShenmue2, 0, 0);
            this.tblGames.Controls.Add(this.pbShenmue, 0, 0);
            this.tblGames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblGames.Location = new System.Drawing.Point(0, 0);
            this.tblGames.Margin = new System.Windows.Forms.Padding(0);
            this.tblGames.Name = "tblGames";
            this.tblGames.RowCount = 1;
            this.tblGames.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblGames.Size = new System.Drawing.Size(870, 433);
            this.tblGames.TabIndex = 1;
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Black;
            this.imgList.Images.SetKeyName(0, "sm1.jpg");
            this.imgList.Images.SetKeyName(1, "sm1_over.jpg");
            this.imgList.Images.SetKeyName(2, "sm2.jpg");
            this.imgList.Images.SetKeyName(3, "sm2_over.jpg");
            // 
            // ShenmueLauncherWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(870, 433);
            this.Controls.Add(this.tblGames);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShenmueLauncherWin";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Shenmue Launcher";
            ((System.ComponentModel.ISupportInitialize)(this.pbShenmue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbShenmue2)).EndInit();
            this.tblGames.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pbShenmue;
        private System.Windows.Forms.PictureBox pbShenmue2;
        private System.Windows.Forms.TableLayoutPanel tblGames;
        private System.Windows.Forms.ImageList imgList;
    }
}


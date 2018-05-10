namespace WpfApplication1
{
    partial class MLGcustomPlayer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MLGcustomPlayer));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.NomPlaylist = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.ProgressBar1 = new Bunifu.Framework.UI.BunifuProgressBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.Header = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ButtonClose = new Bunifu.Framework.UI.BunifuImageButton();
            this.TimeLeft = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.TitreSon = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.ButtonBack = new Bunifu.Framework.UI.BunifuImageButton();
            this.ButtonForward = new Bunifu.Framework.UI.BunifuImageButton();
            this.ButtonStop = new Bunifu.Framework.UI.BunifuImageButton();
            this.ButtonPlay = new Bunifu.Framework.UI.BunifuImageButton();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.Footer = new System.Windows.Forms.Panel();
            this.TimerBar = new System.Windows.Forms.Timer(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.bunifuImageButton1 = new Bunifu.Framework.UI.BunifuImageButton();
            this.bunifuDragControl3 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.Menu = new System.Windows.Forms.Panel();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.list = new System.Windows.Forms.ListView();
            this.TimesLeft = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.Header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonForward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonStop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonPlay)).BeginInit();
            this.Footer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).BeginInit();
            this.Menu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // NomPlaylist
            // 
            this.NomPlaylist.Font = new System.Drawing.Font("Lucida Sans Unicode", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NomPlaylist.ForeColor = System.Drawing.Color.White;
            this.NomPlaylist.Location = new System.Drawing.Point(-26, 20);
            this.NomPlaylist.Name = "NomPlaylist";
            this.NomPlaylist.Size = new System.Drawing.Size(812, 36);
            this.NomPlaylist.TabIndex = 10;
            this.NomPlaylist.Text = "bunifuCustomLabel2";
            this.NomPlaylist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProgressBar1
            // 
            this.ProgressBar1.BackColor = System.Drawing.Color.Black;
            this.ProgressBar1.BorderRadius = 5;
            this.ProgressBar1.Location = new System.Drawing.Point(648, 70);
            this.ProgressBar1.MaximumValue = 100;
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.ProgressColor = System.Drawing.Color.White;
            this.ProgressBar1.Size = new System.Drawing.Size(292, 10);
            this.ProgressBar1.TabIndex = 0;
            this.ProgressBar1.Value = 0;
            this.ProgressBar1.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(13, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 29);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.ForeColor = System.Drawing.Color.White;
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(50, 11);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(132, 16);
            this.bunifuCustomLabel1.TabIndex = 2;
            this.bunifuCustomLabel1.Text = "yOPlay Media Player";
            this.bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Header
            // 
            this.Header.BackColor = System.Drawing.Color.Black;
            this.Header.Controls.Add(this.panel3);
            this.Header.Controls.Add(this.ButtonClose);
            this.Header.Controls.Add(this.pictureBox1);
            this.Header.Controls.Add(this.bunifuCustomLabel1);
            this.Header.Location = new System.Drawing.Point(-1, -2);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(981, 38);
            this.Header.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(3, 37);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(973, 10);
            this.panel3.TabIndex = 13;
            // 
            // ButtonClose
            // 
            this.ButtonClose.BackColor = System.Drawing.Color.Black;
            this.ButtonClose.Image = ((System.Drawing.Image)(resources.GetObject("ButtonClose.Image")));
            this.ButtonClose.ImageActive = null;
            this.ButtonClose.Location = new System.Drawing.Point(940, 3);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(27, 28);
            this.ButtonClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ButtonClose.TabIndex = 3;
            this.ButtonClose.TabStop = false;
            this.ButtonClose.Zoom = 10;
            this.ButtonClose.Click += new System.EventHandler(this.Close);
            // 
            // TimeLeft
            // 
            this.TimeLeft.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeLeft.ForeColor = System.Drawing.Color.White;
            this.TimeLeft.Location = new System.Drawing.Point(892, 44);
            this.TimeLeft.Name = "TimeLeft";
            this.TimeLeft.Size = new System.Drawing.Size(45, 23);
            this.TimeLeft.TabIndex = 10;
            this.TimeLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TimeLeft.Visible = false;
            // 
            // TitreSon
            // 
            this.TitreSon.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitreSon.ForeColor = System.Drawing.Color.White;
            this.TitreSon.Location = new System.Drawing.Point(617, 18);
            this.TitreSon.Name = "TitreSon";
            this.TitreSon.Size = new System.Drawing.Size(350, 18);
            this.TitreSon.TabIndex = 8;
            this.TitreSon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ButtonBack
            // 
            this.ButtonBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ButtonBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonBack.Image = ((System.Drawing.Image)(resources.GetObject("ButtonBack.Image")));
            this.ButtonBack.ImageActive = null;
            this.ButtonBack.Location = new System.Drawing.Point(226, 64);
            this.ButtonBack.Name = "ButtonBack";
            this.ButtonBack.Size = new System.Drawing.Size(38, 36);
            this.ButtonBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ButtonBack.TabIndex = 4;
            this.ButtonBack.TabStop = false;
            this.ButtonBack.Zoom = 50;
            this.ButtonBack.Click += new System.EventHandler(this.ButtonBack_Click);
            // 
            // ButtonForward
            // 
            this.ButtonForward.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ButtonForward.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonForward.Image = ((System.Drawing.Image)(resources.GetObject("ButtonForward.Image")));
            this.ButtonForward.ImageActive = null;
            this.ButtonForward.Location = new System.Drawing.Point(507, 64);
            this.ButtonForward.Name = "ButtonForward";
            this.ButtonForward.Size = new System.Drawing.Size(46, 36);
            this.ButtonForward.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ButtonForward.TabIndex = 3;
            this.ButtonForward.TabStop = false;
            this.ButtonForward.Zoom = 10;
            this.ButtonForward.Click += new System.EventHandler(this.ButtonForward_Click);
            // 
            // ButtonStop
            // 
            this.ButtonStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ButtonStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonStop.Image = ((System.Drawing.Image)(resources.GetObject("ButtonStop.Image")));
            this.ButtonStop.ImageActive = null;
            this.ButtonStop.Location = new System.Drawing.Point(396, 44);
            this.ButtonStop.Name = "ButtonStop";
            this.ButtonStop.Size = new System.Drawing.Size(90, 69);
            this.ButtonStop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ButtonStop.TabIndex = 2;
            this.ButtonStop.TabStop = false;
            this.ButtonStop.Visible = false;
            this.ButtonStop.Zoom = 10;
            this.ButtonStop.Click += new System.EventHandler(this.Stop);
            // 
            // ButtonPlay
            // 
            this.ButtonPlay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ButtonPlay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonPlay.Image = ((System.Drawing.Image)(resources.GetObject("ButtonPlay.Image")));
            this.ButtonPlay.ImageActive = null;
            this.ButtonPlay.Location = new System.Drawing.Point(286, 44);
            this.ButtonPlay.Name = "ButtonPlay";
            this.ButtonPlay.Size = new System.Drawing.Size(90, 69);
            this.ButtonPlay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ButtonPlay.TabIndex = 0;
            this.ButtonPlay.TabStop = false;
            this.ButtonPlay.Zoom = 10;
            this.ButtonPlay.Click += new System.EventHandler(this.Play);
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.Header;
            this.bunifuDragControl1.Vertical = true;
            // 
            // bunifuDragControl2
            // 
            this.bunifuDragControl2.Fixed = true;
            this.bunifuDragControl2.Horizontal = true;
            this.bunifuDragControl2.TargetControl = this.Footer;
            this.bunifuDragControl2.Vertical = true;
            // 
            // Footer
            // 
            this.Footer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.Footer.Controls.Add(this.TimeLeft);
            this.Footer.Controls.Add(this.ProgressBar1);
            this.Footer.Controls.Add(this.TitreSon);
            this.Footer.Controls.Add(this.ButtonBack);
            this.Footer.Controls.Add(this.ButtonForward);
            this.Footer.Controls.Add(this.ButtonStop);
            this.Footer.Controls.Add(this.ButtonPlay);
            this.Footer.Location = new System.Drawing.Point(-1, 434);
            this.Footer.Name = "Footer";
            this.Footer.Size = new System.Drawing.Size(981, 149);
            this.Footer.TabIndex = 1;
            // 
            // TimerBar
            // 
            this.TimerBar.Tick += new System.EventHandler(this.TimerBar_Tick);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // bunifuImageButton1
            // 
            this.bunifuImageButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.bunifuImageButton1.Image = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton1.Image")));
            this.bunifuImageButton1.ImageActive = null;
            this.bunifuImageButton1.Location = new System.Drawing.Point(33, 28);
            this.bunifuImageButton1.Name = "bunifuImageButton1";
            this.bunifuImageButton1.Size = new System.Drawing.Size(64, 41);
            this.bunifuImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton1.TabIndex = 0;
            this.bunifuImageButton1.TabStop = false;
            this.bunifuImageButton1.Zoom = 10;
            this.bunifuImageButton1.Click += new System.EventHandler(this.Retour);
            // 
            // bunifuDragControl3
            // 
            this.bunifuDragControl3.Fixed = true;
            this.bunifuDragControl3.Horizontal = true;
            this.bunifuDragControl3.TargetControl = this.Menu;
            this.bunifuDragControl3.Vertical = true;
            // 
            // Menu
            // 
            this.Menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.Menu.Controls.Add(this.bunifuImageButton1);
            this.Menu.Location = new System.Drawing.Point(-1, 36);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(150, 401);
            this.Menu.TabIndex = 2;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 500;
            // 
            // list
            // 
            this.list.BackColor = System.Drawing.Color.Black;
            this.list.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.list.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.list.ForeColor = System.Drawing.Color.White;
            this.list.FullRowSelect = true;
            this.list.Location = new System.Drawing.Point(3, 78);
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(828, 328);
            this.list.TabIndex = 11;
            this.list.UseCompatibleStateImageBehavior = false;
            this.list.View = System.Windows.Forms.View.List;
            // 
            // TimesLeft
            // 
            this.TimesLeft.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimesLeft.ForeColor = System.Drawing.Color.White;
            this.TimesLeft.Location = new System.Drawing.Point(917, 375);
            this.TimesLeft.Name = "TimesLeft";
            this.TimesLeft.Size = new System.Drawing.Size(60, 21);
            this.TimesLeft.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.panel1.Controls.Add(this.list);
            this.panel1.Controls.Add(this.NomPlaylist);
            this.panel1.Controls.Add(this.TimesLeft);
            this.panel1.Location = new System.Drawing.Point(146, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(834, 412);
            this.panel1.TabIndex = 0;
            // 
            // MLGcustomPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(978, 577);
            this.Controls.Add(this.Menu);
            this.Controls.Add(this.Footer);
            this.Controls.Add(this.Header);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MLGcustomPlayer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MLGcustomPlayer";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.Header.ResumeLayout(false);
            this.Header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonForward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonStop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonPlay)).EndInit();
            this.Footer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).EndInit();
            this.Menu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel Header;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl2;
        private Bunifu.Framework.UI.BunifuProgressBar ProgressBar1;
        private Bunifu.Framework.UI.BunifuImageButton ButtonBack;
        private Bunifu.Framework.UI.BunifuImageButton ButtonForward;
        private Bunifu.Framework.UI.BunifuImageButton ButtonStop;
        private Bunifu.Framework.UI.BunifuImageButton ButtonPlay;
        private Bunifu.Framework.UI.BunifuImageButton ButtonClose;
        private Bunifu.Framework.UI.BunifuCustomLabel TitreSon;
        private System.Windows.Forms.Timer TimerBar;
        private Bunifu.Framework.UI.BunifuCustomLabel TimeLeft;
        private Bunifu.Framework.UI.BunifuCustomLabel NomPlaylist;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel3;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl3;
        private System.Windows.Forms.Panel Menu;
        private System.Windows.Forms.Panel Footer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView list;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label TimesLeft;
    }
}
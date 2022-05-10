namespace NooTranslateHelper
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.labelSubsText = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxTranslateText = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.savePointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveBindToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBoxGoogleTranslate = new System.Windows.Forms.PictureBox();
            this.pictureBoxLeft = new System.Windows.Forms.PictureBox();
            this.pictureBoxRight = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelCountForEnd = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.roundButton1 = new NooTranslateHelper.RoundButton();
            this.roundButtonShowFile = new NooTranslateHelper.RoundButton();
            this.roundButtonNext = new NooTranslateHelper.RoundButton();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGoogleTranslate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelSubsText
            // 
            this.labelSubsText.AutoSize = true;
            this.labelSubsText.BackColor = System.Drawing.Color.Transparent;
            this.labelSubsText.ContextMenuStrip = this.contextMenuStrip1;
            this.labelSubsText.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubsText.ForeColor = System.Drawing.Color.White;
            this.labelSubsText.Location = new System.Drawing.Point(12, 52);
            this.labelSubsText.Name = "labelSubsText";
            this.labelSubsText.Size = new System.Drawing.Size(0, 24);
            this.labelSubsText.TabIndex = 4;
            this.labelSubsText.Click += new System.EventHandler(this.labelSubsText_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyTextToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(103, 26);
            // 
            // copyTextToolStripMenuItem
            // 
            this.copyTextToolStripMenuItem.Name = "copyTextToolStripMenuItem";
            this.copyTextToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.copyTextToolStripMenuItem.Text = "Copy";
            this.copyTextToolStripMenuItem.Click += new System.EventHandler(this.copyTextToolStripMenuItem_Click);
            // 
            // textBoxTranslateText
            // 
            this.textBoxTranslateText.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTranslateText.ForeColor = System.Drawing.Color.Gray;
            this.textBoxTranslateText.Location = new System.Drawing.Point(16, 118);
            this.textBoxTranslateText.Name = "textBoxTranslateText";
            this.textBoxTranslateText.Size = new System.Drawing.Size(471, 22);
            this.textBoxTranslateText.TabIndex = 5;
            this.textBoxTranslateText.TabStop = false;
            this.textBoxTranslateText.Text = "Enter the translation...";
            this.textBoxTranslateText.TextChanged += new System.EventHandler(this.textBoxTranslateText_TextChanged);
            this.textBoxTranslateText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxTranslateText_KeyPress);
            this.textBoxTranslateText.MouseMove += new System.Windows.Forms.MouseEventHandler(this.textBoxTranslateText_MouseMove);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.savePointToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveBindToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(499, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // savePointToolStripMenuItem
            // 
            this.savePointToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.savePointToolStripMenuItem.Name = "savePointToolStripMenuItem";
            this.savePointToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.savePointToolStripMenuItem.Text = "Load save";
            this.savePointToolStripMenuItem.Click += new System.EventHandler(this.loadSaveToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveBindToolStripMenuItem
            // 
            this.saveBindToolStripMenuItem.Name = "saveBindToolStripMenuItem";
            this.saveBindToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveBindToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.saveBindToolStripMenuItem.Text = "SaveBind";
            this.saveBindToolStripMenuItem.Visible = false;
            this.saveBindToolStripMenuItem.Click += new System.EventHandler(this.saveBindToolStripMenuItem_Click);
            // 
            // pictureBoxGoogleTranslate
            // 
            this.pictureBoxGoogleTranslate.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxGoogleTranslate.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxGoogleTranslate.Image")));
            this.pictureBoxGoogleTranslate.Location = new System.Drawing.Point(12, 248);
            this.pictureBoxGoogleTranslate.Name = "pictureBoxGoogleTranslate";
            this.pictureBoxGoogleTranslate.Size = new System.Drawing.Size(44, 39);
            this.pictureBoxGoogleTranslate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxGoogleTranslate.TabIndex = 8;
            this.pictureBoxGoogleTranslate.TabStop = false;
            this.pictureBoxGoogleTranslate.Click += new System.EventHandler(this.pictureBoxGoogleTranslate_Click);
            this.pictureBoxGoogleTranslate.MouseLeave += new System.EventHandler(this.pictureBoxGoogleTranslate_MouseLeave);
            this.pictureBoxGoogleTranslate.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxGoogleTranslate_MouseMove);
            // 
            // pictureBoxLeft
            // 
            this.pictureBoxLeft.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxLeft.Enabled = false;
            this.pictureBoxLeft.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLeft.Image")));
            this.pictureBoxLeft.Location = new System.Drawing.Point(16, 146);
            this.pictureBoxLeft.Name = "pictureBoxLeft";
            this.pictureBoxLeft.Size = new System.Drawing.Size(52, 37);
            this.pictureBoxLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLeft.TabIndex = 10;
            this.pictureBoxLeft.TabStop = false;
            this.pictureBoxLeft.Click += new System.EventHandler(this.pictureBoxLeft_Click);
            this.pictureBoxLeft.MouseLeave += new System.EventHandler(this.pictureBoxLeft_MouseLeave);
            this.pictureBoxLeft.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxLeft_MouseMove);
            // 
            // pictureBoxRight
            // 
            this.pictureBoxRight.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxRight.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxRight.Image")));
            this.pictureBoxRight.Location = new System.Drawing.Point(74, 146);
            this.pictureBoxRight.Name = "pictureBoxRight";
            this.pictureBoxRight.Size = new System.Drawing.Size(44, 37);
            this.pictureBoxRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxRight.TabIndex = 11;
            this.pictureBoxRight.TabStop = false;
            this.pictureBoxRight.Click += new System.EventHandler(this.pictureBoxRight_Click);
            this.pictureBoxRight.MouseLeave += new System.EventHandler(this.pictureBoxRight_MouseLeave);
            this.pictureBoxRight.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxRight_MouseMove);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.labelCountForEnd);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(165, 248);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(95, 39);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "To end";
            // 
            // labelCountForEnd
            // 
            this.labelCountForEnd.AutoSize = true;
            this.labelCountForEnd.Location = new System.Drawing.Point(6, 16);
            this.labelCountForEnd.Name = "labelCountForEnd";
            this.labelCountForEnd.Size = new System.Drawing.Size(0, 13);
            this.labelCountForEnd.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // roundButton1
            // 
            this.roundButton1.BackColor = System.Drawing.Color.IndianRed;
            this.roundButton1.BackColor2 = System.Drawing.Color.IndianRed;
            this.roundButton1.ButtonBorderColor = System.Drawing.Color.Transparent;
            this.roundButton1.ButtonHighlightColor = System.Drawing.Color.Orange;
            this.roundButton1.ButtonHighlightColor2 = System.Drawing.Color.OrangeRed;
            this.roundButton1.ButtonHighlightForeColor = System.Drawing.Color.Black;
            this.roundButton1.ButtonPressedColor = System.Drawing.Color.Red;
            this.roundButton1.ButtonPressedColor2 = System.Drawing.Color.Maroon;
            this.roundButton1.ButtonPressedForeColor = System.Drawing.Color.White;
            this.roundButton1.ButtonRoundRadius = 30;
            this.roundButton1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundButton1.ForeColor = System.Drawing.Color.White;
            this.roundButton1.Location = new System.Drawing.Point(410, 248);
            this.roundButton1.Name = "roundButton1";
            this.roundButton1.Size = new System.Drawing.Size(77, 40);
            this.roundButton1.TabIndex = 12;
            this.roundButton1.Text = "BACK";
            this.roundButton1.Click += new System.EventHandler(this.roundButtonExit_Click);
            // 
            // roundButtonShowFile
            // 
            this.roundButtonShowFile.BackColor = System.Drawing.Color.RoyalBlue;
            this.roundButtonShowFile.BackColor2 = System.Drawing.Color.LightBlue;
            this.roundButtonShowFile.ButtonBorderColor = System.Drawing.Color.Transparent;
            this.roundButtonShowFile.ButtonHighlightColor = System.Drawing.Color.Orange;
            this.roundButtonShowFile.ButtonHighlightColor2 = System.Drawing.Color.OrangeRed;
            this.roundButtonShowFile.ButtonHighlightForeColor = System.Drawing.Color.Black;
            this.roundButtonShowFile.ButtonPressedColor = System.Drawing.Color.Red;
            this.roundButtonShowFile.ButtonPressedColor2 = System.Drawing.Color.Maroon;
            this.roundButtonShowFile.ButtonPressedForeColor = System.Drawing.Color.White;
            this.roundButtonShowFile.ButtonRoundRadius = 30;
            this.roundButtonShowFile.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundButtonShowFile.ForeColor = System.Drawing.Color.White;
            this.roundButtonShowFile.Location = new System.Drawing.Point(62, 248);
            this.roundButtonShowFile.Name = "roundButtonShowFile";
            this.roundButtonShowFile.Size = new System.Drawing.Size(97, 40);
            this.roundButtonShowFile.TabIndex = 9;
            this.roundButtonShowFile.Text = "SHOW FILE";
            this.roundButtonShowFile.Click += new System.EventHandler(this.roundButtonShowFile_Click);
            // 
            // roundButtonNext
            // 
            this.roundButtonNext.BackColor = System.Drawing.Color.Aquamarine;
            this.roundButtonNext.BackColor2 = System.Drawing.Color.LightBlue;
            this.roundButtonNext.ButtonBorderColor = System.Drawing.Color.Transparent;
            this.roundButtonNext.ButtonHighlightColor = System.Drawing.Color.Orange;
            this.roundButtonNext.ButtonHighlightColor2 = System.Drawing.Color.OrangeRed;
            this.roundButtonNext.ButtonHighlightForeColor = System.Drawing.Color.Black;
            this.roundButtonNext.ButtonPressedColor = System.Drawing.Color.Red;
            this.roundButtonNext.ButtonPressedColor2 = System.Drawing.Color.Maroon;
            this.roundButtonNext.ButtonPressedForeColor = System.Drawing.Color.White;
            this.roundButtonNext.ButtonRoundRadius = 30;
            this.roundButtonNext.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundButtonNext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.roundButtonNext.Location = new System.Drawing.Point(165, 193);
            this.roundButtonNext.Name = "roundButtonNext";
            this.roundButtonNext.Size = new System.Drawing.Size(175, 40);
            this.roundButtonNext.TabIndex = 6;
            this.roundButtonNext.Text = "NEXT";
            this.roundButtonNext.Click += new System.EventHandler(this.roundButtonNext_Click);
            this.roundButtonNext.MouseMove += new System.Windows.Forms.MouseEventHandler(this.roundButtonNext_MouseMove);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(499, 300);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.roundButton1);
            this.Controls.Add(this.pictureBoxRight);
            this.Controls.Add(this.pictureBoxLeft);
            this.Controls.Add(this.roundButtonShowFile);
            this.Controls.Add(this.pictureBoxGoogleTranslate);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.roundButtonNext);
            this.Controls.Add(this.textBoxTranslateText);
            this.Controls.Add(this.labelSubsText);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(515, 339);
            this.MinimumSize = new System.Drawing.Size(515, 339);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Translate Tool";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGoogleTranslate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSubsText;
        private System.Windows.Forms.TextBox textBoxTranslateText;
        private RoundButton roundButtonNext;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copyTextToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem savePointToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBoxGoogleTranslate;
        private RoundButton roundButtonShowFile;
        private System.Windows.Forms.PictureBox pictureBoxLeft;
        private System.Windows.Forms.PictureBox pictureBoxRight;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private RoundButton roundButton1;
        private System.Windows.Forms.ToolStripMenuItem saveBindToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelCountForEnd;
        private System.Windows.Forms.Timer timer1;
    }
}
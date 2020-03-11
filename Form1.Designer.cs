namespace TPAD
{
    partial class MainForm
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
            this.downloadButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.nextButton = new System.Windows.Forms.Button();
            this.choices = new System.Windows.Forms.ComboBox();
            this.siteChoice = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dniButton = new System.Windows.Forms.Button();
            this.smdButton = new System.Windows.Forms.Button();
            this.prevImgButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // downloadButton
            // 
            this.downloadButton.FlatAppearance.BorderSize = 0;
            this.downloadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.downloadButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.downloadButton.Location = new System.Drawing.Point(292, 415);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(75, 23);
            this.downloadButton.TabIndex = 0;
            this.downloadButton.Text = "Download Image";
            this.downloadButton.UseVisualStyleBackColor = true;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(650, 348);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // nextButton
            // 
            this.nextButton.FlatAppearance.BorderSize = 0;
            this.nextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.nextButton.Location = new System.Drawing.Point(373, 415);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(75, 23);
            this.nextButton.TabIndex = 2;
            this.nextButton.Text = "Next Image";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // choices
            // 
            this.choices.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(60)))));
            this.choices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.choices.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.choices.FormattingEnabled = true;
            this.choices.Location = new System.Drawing.Point(667, 39);
            this.choices.Name = "choices";
            this.choices.Size = new System.Drawing.Size(121, 21);
            this.choices.TabIndex = 3;
            this.choices.Text = "avatar";
            // 
            // siteChoice
            // 
            this.siteChoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(60)))));
            this.siteChoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.siteChoice.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.siteChoice.FormattingEnabled = true;
            this.siteChoice.Location = new System.Drawing.Point(667, 12);
            this.siteChoice.Name = "siteChoice";
            this.siteChoice.Size = new System.Drawing.Size(121, 21);
            this.siteChoice.TabIndex = 4;
            this.siteChoice.Text = "nekos.life";
            this.siteChoice.SelectedIndexChanged += new System.EventHandler(this.siteChoice_SelectedIndexChanged);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dniButton
            // 
            this.dniButton.FlatAppearance.BorderSize = 0;
            this.dniButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dniButton.ForeColor = System.Drawing.Color.White;
            this.dniButton.Location = new System.Drawing.Point(697, 415);
            this.dniButton.Name = "dniButton";
            this.dniButton.Size = new System.Drawing.Size(91, 23);
            this.dniButton.TabIndex = 5;
            this.dniButton.Text = "Start Mass";
            this.dniButton.UseVisualStyleBackColor = true;
            this.dniButton.Click += new System.EventHandler(this.dniButton_Click);
            // 
            // smdButton
            // 
            this.smdButton.FlatAppearance.BorderSize = 0;
            this.smdButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.smdButton.ForeColor = System.Drawing.Color.White;
            this.smdButton.Location = new System.Drawing.Point(12, 415);
            this.smdButton.Name = "smdButton";
            this.smdButton.Size = new System.Drawing.Size(91, 23);
            this.smdButton.TabIndex = 6;
            this.smdButton.Text = "Stop Mass";
            this.smdButton.UseVisualStyleBackColor = true;
            this.smdButton.Click += new System.EventHandler(this.smdButton_Click);
            // 
            // prevImgButton
            // 
            this.prevImgButton.FlatAppearance.BorderSize = 0;
            this.prevImgButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.prevImgButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.prevImgButton.Location = new System.Drawing.Point(211, 415);
            this.prevImgButton.Name = "prevImgButton";
            this.prevImgButton.Size = new System.Drawing.Size(75, 23);
            this.prevImgButton.TabIndex = 7;
            this.prevImgButton.Text = "Prev Image";
            this.prevImgButton.UseVisualStyleBackColor = true;
            this.prevImgButton.Click += new System.EventHandler(this.prevImgButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.prevImgButton);
            this.Controls.Add(this.smdButton);
            this.Controls.Add(this.dniButton);
            this.Controls.Add(this.siteChoice);
            this.Controls.Add(this.choices);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.downloadButton);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.Text = "TPAD";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.ComboBox choices;
        private System.Windows.Forms.ComboBox siteChoice;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button dniButton;
        private System.Windows.Forms.Button smdButton;
        private System.Windows.Forms.Button prevImgButton;
    }
}


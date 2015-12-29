namespace Stenography
{
    partial class TextControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnDecode = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnEncode = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtText = new System.Windows.Forms.TextBox();
            this.ofdFile = new System.Windows.Forms.OpenFileDialog();
            this.sfdFile = new System.Windows.Forms.SaveFileDialog();
            this.prgDoing = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(164, 314);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 15);
            this.label1.TabIndex = 68;
            this.label1.Text = "Mật Khẩu";
            // 
            // txtPassword
            // 
            this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPassword.Location = new System.Drawing.Point(163, 333);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(234, 23);
            this.txtPassword.TabIndex = 62;
            // 
            // btnDecode
            // 
            this.btnDecode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDecode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.btnDecode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDecode.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDecode.FlatAppearance.BorderSize = 0;
            this.btnDecode.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(199)))), ((int)(((byte)(204)))));
            this.btnDecode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.btnDecode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDecode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDecode.Image = global::Stenography.Properties.Resources.encode;
            this.btnDecode.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDecode.Location = new System.Drawing.Point(480, 310);
            this.btnDecode.Margin = new System.Windows.Forms.Padding(0);
            this.btnDecode.Name = "btnDecode";
            this.btnDecode.Size = new System.Drawing.Size(80, 50);
            this.btnDecode.TabIndex = 67;
            this.btnDecode.Text = "Giải mã";
            this.btnDecode.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDecode.UseVisualStyleBackColor = false;
            this.btnDecode.Click += new System.EventHandler(this.btnDecode_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(199)))), ((int)(((byte)(204)))));
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClose.Image = global::Stenography.Properties.Resources.exit;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClose.Location = new System.Drawing.Point(560, 310);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 50);
            this.btnClose.TabIndex = 66;
            this.btnClose.Text = "Đóng";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.btnOpen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnOpen.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnOpen.FlatAppearance.BorderSize = 0;
            this.btnOpen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(199)))), ((int)(((byte)(204)))));
            this.btnOpen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnOpen.Image = global::Stenography.Properties.Resources.open;
            this.btnOpen.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnOpen.Location = new System.Drawing.Point(0, 310);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(0);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(80, 50);
            this.btnOpen.TabIndex = 65;
            this.btnOpen.Text = "Mở";
            this.btnOpen.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnEncode
            // 
            this.btnEncode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEncode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.btnEncode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEncode.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnEncode.FlatAppearance.BorderSize = 0;
            this.btnEncode.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(199)))), ((int)(((byte)(204)))));
            this.btnEncode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.btnEncode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEncode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnEncode.Image = global::Stenography.Properties.Resources.encode;
            this.btnEncode.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEncode.Location = new System.Drawing.Point(400, 310);
            this.btnEncode.Margin = new System.Windows.Forms.Padding(0);
            this.btnEncode.Name = "btnEncode";
            this.btnEncode.Size = new System.Drawing.Size(80, 50);
            this.btnEncode.TabIndex = 64;
            this.btnEncode.Text = "Mã hóa";
            this.btnEncode.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEncode.UseVisualStyleBackColor = false;
            this.btnEncode.Click += new System.EventHandler(this.btnEncode_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(199)))), ((int)(((byte)(204)))));
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSave.Image = global::Stenography.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSave.Location = new System.Drawing.Point(80, 310);
            this.btnSave.Margin = new System.Windows.Forms.Padding(0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 50);
            this.btnSave.TabIndex = 63;
            this.btnSave.Text = "Lưu";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtText
            // 
            this.txtText.BackColor = System.Drawing.Color.White;
            this.txtText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtText.Location = new System.Drawing.Point(0, 0);
            this.txtText.Margin = new System.Windows.Forms.Padding(0);
            this.txtText.Multiline = true;
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(640, 310);
            this.txtText.TabIndex = 69;
            // 
            // ofdFile
            // 
            this.ofdFile.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            // 
            // sfdFile
            // 
            this.sfdFile.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            // 
            // prgDoing
            // 
            this.prgDoing.Location = new System.Drawing.Point(0, 300);
            this.prgDoing.Margin = new System.Windows.Forms.Padding(0);
            this.prgDoing.MarqueeAnimationSpeed = 10;
            this.prgDoing.Name = "prgDoing";
            this.prgDoing.Size = new System.Drawing.Size(640, 10);
            this.prgDoing.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.prgDoing.TabIndex = 70;
            // 
            // TextControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.prgDoing);
            this.Controls.Add(this.txtText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDecode);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnEncode);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtPassword);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Name = "TextControl";
            this.Size = new System.Drawing.Size(640, 360);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDecode;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnEncode;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.OpenFileDialog ofdFile;
        private System.Windows.Forms.SaveFileDialog sfdFile;
        private System.Windows.Forms.ProgressBar prgDoing;
    }
}

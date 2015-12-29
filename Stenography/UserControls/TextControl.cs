using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace Stenography
{
    public partial class TextControl : UserControl
    {
        private MainForm frmWatermark;
        public TextControl(MainForm frmWatermark)
        {
            this.frmWatermark = frmWatermark;
            InitializeComponent();
            prgDoing.Hide();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (ofdFile.ShowDialog() == DialogResult.OK)
            {
                txtText.Text = File.ReadAllText(ofdFile.FileName);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (sfdFile.ShowDialog() == DialogResult.OK)
            {
                if (sfdFile.FileName.Length > 0)
                {
                    File.WriteAllText(sfdFile.FileName, txtText.Text);
                }
            }
        }

        private void btnEncode_Click(object sender, EventArgs e)
        {
            prgDoing.Show();
            new Thread(Encode).Start();
        }

        private void Encode()
        {
            string text = txtText.Text.Trim();
            if (text.Length > 0)
            {
                string password = txtPassword.Text.Trim();
                Bitmap source = (Bitmap)frmWatermark.picBitmap.Image;
                Bitmap target = Processor.EmbedStringToBitmap(source, text, password);
                this.Invoke((MethodInvoker)delegate
                {
                    frmWatermark.picBitmap.Image = target;
                    prgDoing.Hide();
                    MessageBox.Show("Đã mã hóa xong!");
                });
            }
        }

        private void btnDecode_Click(object sender, EventArgs e)
        {
            prgDoing.Show();
            new Thread(Decode).Start();
        }

        private void Decode()
        {
            Bitmap source = (Bitmap)frmWatermark.picBitmap.Image;
            string password = txtPassword.Text.Trim();
            if (source != null)
            {
                string text = Processor.GetEmbededStringFromBitmap(source, password);
                this.Invoke((MethodInvoker)delegate
                {
                    txtText.Text = text;
                    prgDoing.Hide();
                    MessageBox.Show("Đã giải mã xong!");
                });
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            txtPassword.Clear();
            txtText.Clear();
            prgDoing.Hide();
            Hide();
            frmWatermark.pnlEmbedded.Hide();

        }
    }
}

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
using System.Drawing.Imaging;
using System.Threading;

namespace Stenography
{
    public partial class ImageControl : UserControl
    {
        private MainForm frmWatermark;
        public ImageControl(MainForm frmWatermark)
        {
            this.frmWatermark = frmWatermark;
            InitializeComponent();
            prgDoing.Hide();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (ofdFile.ShowDialog() == DialogResult.OK)
            {
                picImage.Image = new Bitmap(ofdFile.FileName);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            txtPassword.Clear();
            picImage.Image = null;
            prgDoing.Hide();
            Hide();
            frmWatermark.pnlEmbedded.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (sfdFile.ShowDialog() == DialogResult.OK)
            {
                if (sfdFile.FileName.Length > 0)
                {
                    string extension = sfdFile.FileName.Substring(sfdFile.FileName.Length - 3).ToLower();
                    FileStream fileStream = new FileStream(sfdFile.FileName, FileMode.Create);
                    Bitmap bitmap = (Bitmap) picImage.Image;
                    switch (extension)
                    {
                        case "bmp":
                            bitmap.Save(fileStream, ImageFormat.Bmp);
                            break;

                        case "gif":
                            bitmap.Save(fileStream, ImageFormat.Gif);
                            break;

                        case "jpg":
                            bitmap.Save(fileStream, ImageFormat.Jpeg);
                            break;

                        case "png":
                            bitmap.Save(fileStream, ImageFormat.Png);
                            break;

                        default:
                            break;
                    }
                    fileStream.Close();
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
            Bitmap source = (Bitmap)frmWatermark.picBitmap.Image;
            Bitmap data = (Bitmap)picImage.Image;
            if (source != null && data != null)
            {
                string password = txtPassword.Text.Trim();
                Bitmap target = Processor.EmbedBitmapToBitmap(source, data, password);
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
            if (source != null)
            {
                string password = txtPassword.Text.Trim();
                Bitmap data = Processor.GetEmbededBitmapFromBitmap(source, password);
                this.Invoke((MethodInvoker)delegate
                {
                    picImage.Image = data;
                    prgDoing.Hide();
                    MessageBox.Show("Đã giải mã xong!");
                });
            }
        }
    }
}

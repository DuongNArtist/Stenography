using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Data.SqlClient;
using System.Globalization;
using System.Resources;
using System.IO;

namespace Stenography
{
    public partial class MainForm : Form
    {
        private int x;
        private int y;
        private bool moving = false;

        private ImageControl ctrEmbedImage;
        private TextControl ctrEmbedText;
        private DatabaseControl ctrConnectDatabase;

        public MainForm()
        {
            InitializeComponent();
            ctrEmbedText = new TextControl(this);
            ctrEmbedImage = new ImageControl(this);
            ctrConnectDatabase = new DatabaseControl(this);
            ctrEmbedText.Visible = false;
            ctrEmbedImage.Visible = false;
            ctrConnectDatabase.Visible = false;
            pnlEmbedded.Controls.Add(ctrEmbedText);
            pnlEmbedded.Controls.Add(ctrEmbedImage);
            pnlEmbedded.Controls.Add(ctrConnectDatabase);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            pnlEmbedded.Visible = false;
        }

        private void lblTitle_MouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            x = e.X;
            y = e.Y;
        }

        private void lblTitle_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving)
            {
                SetDesktopLocation(MousePosition.X - x, MousePosition.Y - y);
            }
        }

        private void lblTitle_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
        }



        private void btnMin_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Minimized;
            }
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (ofdFile.ShowDialog() == DialogResult.OK)
            {
                picBitmap.Image = new Bitmap(ofdFile.FileName);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = (Bitmap)picBitmap.Image;
            if (bitmap != null && sfdFile.ShowDialog() == DialogResult.OK)
            {
                if (sfdFile.FileName.Length > 0)
                {
                    string extension = sfdFile.FileName.Substring(sfdFile.FileName.Length - 3).ToLower();
                    FileStream fileStream = new FileStream(sfdFile.FileName, FileMode.Create);
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

        private void btnEmbedImage_Click(object sender, EventArgs e)
        {
            if (picBitmap.Image != null)
            {
                pnlEmbedded.Visible = true;
                ctrEmbedImage.Visible = true;
                ctrEmbedText.Visible = false;
            }
        }

        private void btnEmbedText_Click(object sender, EventArgs e)
        {
            if (picBitmap.Image != null)
            {
                pnlEmbedded.Visible = true;
                ctrEmbedText.Visible = true;
                ctrEmbedImage.Visible = false;
            }
        }

        private void btnConnectDatabase_Click(object sender, EventArgs e)
        {
            pnlEmbedded.Visible = true;
            ctrConnectDatabase.Visible = true;
            ctrEmbedText.Visible = false;
            ctrEmbedImage.Visible = false;
        }

        private void picBitmap_Click(object sender, EventArgs e)
        {
            pnlEmbedded.Hide();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stenography
{
    public partial class DatabaseControl : UserControl
    {
        private MainForm frmWatermark;
        private Dictionary<int, string> dicNames = new Dictionary<int, string>();
        private Dictionary<int, Bitmap> dicImages = new Dictionary<int, Bitmap>();
        int selected = -1;
        public DatabaseControl(MainForm frmWatermark)
        {
            this.frmWatermark = frmWatermark;
            InitializeComponent();
        }

        private void ConnectDatabaseControl_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void RefreshList()
        {
            lstImages.Images.Clear();
            lvwImages.Clear();
            dicNames.Clear();
            dicImages.Clear();
            dicNames = Database.GetInstance().GetImageNames();
            for (int i = 0; i < dicNames.Keys.Count; i++)
            {
                int key = dicNames.Keys.ElementAt(i);
                string value = dicNames.Values.ElementAt(i);
                Image image = Database.GetInstance().GetImageById(key);
                dicImages.Add(key, (Bitmap)image);
                lstImages.Images.Add(image);
                ListViewItem listViewItem = new ListViewItem(value);
                listViewItem.ImageIndex = i;
                lvwImages.Items.Add(listViewItem);
            }
            lvwImages.LargeImageList = lstImages;
        }

        private void lvwImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwImages.SelectedItems.Count > 0)
            {
                selected = lvwImages.SelectedIndices[0];
                txtName.Text = lvwImages.SelectedItems[0].Text;
                frmWatermark.picBitmap.Image = dicImages.Values.ElementAt(selected);
            }
            else
            {
                selected = -1;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Hide();
            frmWatermark.pnlEmbedded.Hide();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            Image image = frmWatermark.picBitmap.Image;
            if (name.Length > 0 && image != null)
            {
                int result = Database.GetInstance().InsertImageToDatabase(name, image);
                if (result > 0)
                {
                    RefreshList();
                    MessageBox.Show("Image '" + name + "' inserted succeed!");
                }
                else
                {
                    MessageBox.Show("Image '" + name + "' updated failed!");
                }
            }
            else
            {
                txtName.Focus();
                MessageBox.Show("Please enter a name for image!");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selected != -1)
            {
                int id = dicNames.ElementAtOrDefault(selected).Key;
                int count = Database.GetInstance().GetCountOfId(id);
                if (count > 0)
                {
                    string name = txtName.Text.Trim();
                    Image image = frmWatermark.picBitmap.Image;
                    if (name.Length > 0 && image != null)
                    {
                        int result = Database.GetInstance().UpdateImageById(id, name, image);
                        if (result > 0)
                        {
                            RefreshList();
                            MessageBox.Show("Image '" + name + "' updated succeed!");
                        }
                        else
                        {
                            MessageBox.Show("Image '" + name + "' updated failed!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter a name for image!");
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selected != -1)
            {
                int id = dicNames.Keys.ElementAtOrDefault(selected);
                string name = dicNames.Values.ElementAtOrDefault(selected);
                int result = Database.GetInstance().DeleteImageById(id);
                if (result > 0)
                {
                    txtName.Clear();
                    frmWatermark.picBitmap.Image = null;
                    RefreshList();
                    MessageBox.Show("Image '" + name + "' deleted succeed!");
                }
                else
                {
                    MessageBox.Show("Image '" + name + "' deleted failed!");
                }
            }
        }
    }
}

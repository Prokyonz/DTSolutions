using AForge.Video;
using AForge.Video.DirectShow;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiamondTrading.Transaction
{
    public partial class FrmTakePicture : DevExpress.XtraEditors.XtraForm
    {
        FilterInfoCollection videoDevices;
        VideoCaptureDevice videoCaptureDevice;
        int SelectedTab = 0;

        public PictureBox Image1
        {
            get
            {
                return pictureBox1;
            }
            set
            {
                pictureBox1 = value;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        public PictureBox Image2
        {
            get
            {
                return pictureBox2;
            }
            set
            {
                pictureBox2 = value;
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        public PictureBox Image3
        {
            get
            {
                return pictureBox3;
            }
            set
            {
                pictureBox3 = value;
                pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        public int SelectedImage
        {
            get;
            set;
        }

        public FrmTakePicture()
        {
            InitializeComponent();
        }

        private void FrmTakePicture_Load(object sender, EventArgs e)
        {
            SelectedTab = SelectedImage;
            if (SelectedImage == 0)
            {
                tabControl1.SelectedTab = tabPage1;
            }
            else if (SelectedImage == 1)
            {
                tabControl1.SelectedTab = tabPage2;
            }
            else if (SelectedImage == 2)
            {
                tabControl1.SelectedTab = tabPage3;
            }

            picImage1.Image = Image1.Image;
            picImage1.SizeMode = PictureBoxSizeMode.StretchImage;
            picImage2.Image = Image2.Image;
            picImage2.SizeMode = PictureBoxSizeMode.StretchImage;
            picImage3.Image = Image3.Image;
            picImage3.SizeMode = PictureBoxSizeMode.StretchImage;

            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Id");
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            int DeviceId = 0;
            if (videoDevices.Count == 0)
            {
                dt.Rows.Add("No devices found", DeviceId);
            }
            else
            {
                foreach (FilterInfo videoDevice in videoDevices)
                {
                    dt.Rows.Add(videoDevice.Name, DeviceId);
                    DeviceId++;
                }
            }
            lueDeviceDetails.Properties.DataSource = dt;
            lueDeviceDetails.Properties.DisplayMember = "Name";
            lueDeviceDetails.Properties.ValueMember = "Id";
            if (dt.Rows.Count > 0)
            {
                lueDeviceDetails.EditValue = 0;
            }

            videoCaptureDevice = new VideoCaptureDevice();
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            if (btnCapture.Text == "Start Capturing")
            {
                btnClick.Enabled = true;
                videoCaptureDevice = new VideoCaptureDevice();

                btnCapture.Text = "Capturing...";
                videoCaptureDevice = new VideoCaptureDevice(videoDevices[Convert.ToInt32(lueDeviceDetails.EditValue)].MonikerString);
                videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
                videoCaptureDevice.Start();
            }
            else
            {
                btnClick.Enabled = false;
                btnCapture.Text = "Start Capturing";
                videoCaptureDevice.Stop();
            }
        }

        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if (SelectedTab == 0)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
            }
            else if (SelectedTab == 1)
            {
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox2.Image = (Bitmap)eventArgs.Frame.Clone();
            }
            else if (SelectedTab == 2)
            {
                pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox3.Image = (Bitmap)eventArgs.Frame.Clone();
            }
        }

        private void btnClick_Click(object sender, EventArgs e)
        {
            btnCapture.Text = "Start Capturing";
            videoCaptureDevice.Stop();
            Bitmap snapshot = null;
            if (tabControl1.SelectedTab == tabPage1)
            {
                snapshot = new Bitmap(pictureBox1.Image);
                pictureBox1.Image = snapshot;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                picImage1.Image = snapshot;
                picImage1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (tabControl1.SelectedTab == tabPage2)
            {
                snapshot = new Bitmap(pictureBox2.Image);
                pictureBox2.Image = snapshot;
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                picImage2.Image = snapshot;
                picImage2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (tabControl1.SelectedTab == tabPage3)
            {
                snapshot = new Bitmap(pictureBox3.Image);
                pictureBox3.Image = snapshot;
                pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                picImage3.Image = snapshot;
                picImage3.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void picImage1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
            SelectedTab = 0;
        }

        private void picImage2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
            SelectedTab = 1;
        }

        private void picImage3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
            SelectedTab = 2;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            btnClick.Enabled = false;
            btnCapture.Text = "Start Capturing";
            videoCaptureDevice.Stop();
            openFileDialog1.Filter = "Image Files(*.BMP;*.JPG;*.JPEG;*.PNG)|*.BMP;*.JPG;*.JPEG;*.PNG";
            openFileDialog1.FileName = string.Empty;
            if (DialogResult.OK == openFileDialog1.ShowDialog())
            {
                if (videoCaptureDevice != null && videoCaptureDevice.IsRunning)
                    videoCaptureDevice.Stop();
                if (openFileDialog1.FileName != string.Empty)
                {
                    try
                    {
                        Byte[] logo = null;
                        logo = File.ReadAllBytes(openFileDialog1.FileName);
                        MemoryStream ms = new MemoryStream(logo);
                        Image newimage = Image.FromStream(ms);
                        if (SelectedTab == 0)
                        {
                            pictureBox1.Image = newimage;
                            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                            picImage1.Image = newimage;
                            picImage1.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                        else if (SelectedTab == 1)
                        {
                            pictureBox2.Image = newimage;
                            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

                            picImage2.Image = newimage;
                            picImage2.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                        else if (SelectedTab == 2)
                        {
                            pictureBox3.Image = newimage;
                            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;

                            picImage3.Image = newimage;
                            picImage3.SizeMode = PictureBoxSizeMode.StretchImage;
                        }

                        logo = null;
                        ms = null;
                        newimage = null;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("CM01:" + ex.Message, "AD InfoTech", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Cursor = Cursors.Default;
                    }
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void FrmTakePicture_FormClosed(object sender, FormClosedEventArgs e)
        {
            pictureBox1.Image = picImage1.Image;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Image = picImage2.Image;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.Image = picImage3.Image;
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;

            this.DialogResult = DialogResult.OK;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            trackBar1.Value = 1;
            if (tabControl1.SelectedTab == tabPage1)
            {
                SelectedTab = 0;
            }
            else if (tabControl1.SelectedTab == tabPage2)
            {
                SelectedTab = 1;
            }
            else if (tabControl1.SelectedTab == tabPage3)
            {
                SelectedTab = 2;
            }
        }

        private Image ZoomPicture(Image image, Size size)
        {
            Bitmap bm = new Bitmap(image);
            try
            {
                bm = new Bitmap(image, Convert.ToInt32(image.Width * size.Width), Convert.ToInt32(image.Height * size.Height));
                Graphics gpu = Graphics.FromImage(bm);
                //gpu.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                return bm;
            }
            catch
            {
                return bm;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (trackBar1.Value != 1)
            {
                if (tabControl1.SelectedTab == tabPage1)
                {
                    pictureBox1.Image = null;
                    pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                    pictureBox1.Image = ZoomPicture(picImage1.Image, new Size(trackBar1.Value/100, trackBar1.Value/100));
                }
                else if (tabControl1.SelectedTab == tabPage2)
                {
                    pictureBox2.Image = null;
                    pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
                    pictureBox2.Image = ZoomPicture(picImage2.Image, new Size(trackBar1.Value/100, trackBar1.Value/100));
                }
                else if (tabControl1.SelectedTab == tabPage3)
                {
                    pictureBox3.Image = null;
                    pictureBox3.SizeMode = PictureBoxSizeMode.AutoSize;
                    pictureBox3.Image = ZoomPicture(picImage3.Image, new Size(trackBar1.Value/100, trackBar1.Value/100));
                }
            }
            else
            {
                if (tabControl1.SelectedTab == tabPage1)
                {
                    pictureBox1.Image = picImage1.Image;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else if (tabControl1.SelectedTab == tabPage2)
                {
                    pictureBox2.Image = picImage2.Image;
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else if (tabControl1.SelectedTab == tabPage3)
                {
                    pictureBox3.Image = picImage3.Image;
                    pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }
    }
}
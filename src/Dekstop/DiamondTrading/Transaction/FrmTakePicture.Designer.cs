
namespace DiamondTrading.Transaction
{
    partial class FrmTakePicture
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnClick = new DevExpress.XtraEditors.SimpleButton();
            this.btnBrowse = new DevExpress.XtraEditors.SimpleButton();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.btnCapture = new DevExpress.XtraEditors.SimpleButton();
            this.lueDeviceDetails = new DevExpress.XtraEditors.LookUpEdit();
            this.picImage1 = new System.Windows.Forms.PictureBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.picImage3 = new System.Windows.Forms.PictureBox();
            this.picImage2 = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDeviceDetails.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage2)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnClick);
            this.groupControl1.Controls.Add(this.btnBrowse);
            this.groupControl1.Controls.Add(this.trackBar1);
            this.groupControl1.Controls.Add(this.btnCapture);
            this.groupControl1.Controls.Add(this.lueDeviceDetails);
            this.groupControl1.Controls.Add(this.picImage1);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.picImage3);
            this.groupControl1.Controls.Add(this.picImage2);
            this.groupControl1.Location = new System.Drawing.Point(12, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(198, 336);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Camera Device Details";
            // 
            // btnClick
            // 
            this.btnClick.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnClick.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClick.Appearance.Options.UseBackColor = true;
            this.btnClick.Appearance.Options.UseFont = true;
            this.btnClick.Enabled = false;
            this.btnClick.Location = new System.Drawing.Point(109, 155);
            this.btnClick.Name = "btnClick";
            this.btnClick.Size = new System.Drawing.Size(80, 27);
            this.btnClick.TabIndex = 151;
            this.btnClick.Text = "Click";
            this.btnClick.Click += new System.EventHandler(this.btnClick_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Appearance.Options.UseFont = true;
            this.btnBrowse.Location = new System.Drawing.Point(10, 155);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(93, 27);
            this.btnBrowse.TabIndex = 150;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 1;
            this.trackBar1.Location = new System.Drawing.Point(8, 113);
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(179, 45);
            this.trackBar1.TabIndex = 149;
            this.trackBar1.Value = 1;
            this.trackBar1.Visible = false;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // btnCapture
            // 
            this.btnCapture.Appearance.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCapture.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapture.Appearance.Options.UseBackColor = true;
            this.btnCapture.Appearance.Options.UseFont = true;
            this.btnCapture.Location = new System.Drawing.Point(8, 80);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(179, 27);
            this.btnCapture.TabIndex = 15;
            this.btnCapture.Text = "Start Capturing";
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // lueDeviceDetails
            // 
            this.lueDeviceDetails.Location = new System.Drawing.Point(8, 48);
            this.lueDeviceDetails.Name = "lueDeviceDetails";
            this.lueDeviceDetails.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lueDeviceDetails.Properties.Appearance.Options.UseFont = true;
            this.lueDeviceDetails.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueDeviceDetails.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Device Name", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "DeviceID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lueDeviceDetails.Properties.NullText = "";
            this.lueDeviceDetails.Size = new System.Drawing.Size(179, 26);
            this.lueDeviceDetails.TabIndex = 7;
            // 
            // picImage1
            // 
            this.picImage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImage1.Image = global::DiamondTrading.Properties.Resources.background;
            this.picImage1.Location = new System.Drawing.Point(17, 271);
            this.picImage1.Name = "picImage1";
            this.picImage1.Size = new System.Drawing.Size(50, 50);
            this.picImage1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImage1.TabIndex = 145;
            this.picImage1.TabStop = false;
            this.picImage1.Click += new System.EventHandler(this.picImage1_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(8, 28);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(95, 14);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "Name Of Device*";
            // 
            // picImage3
            // 
            this.picImage3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImage3.Image = global::DiamondTrading.Properties.Resources.background;
            this.picImage3.Location = new System.Drawing.Point(127, 271);
            this.picImage3.Name = "picImage3";
            this.picImage3.Size = new System.Drawing.Size(50, 50);
            this.picImage3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImage3.TabIndex = 147;
            this.picImage3.TabStop = false;
            this.picImage3.Click += new System.EventHandler(this.picImage3_Click);
            // 
            // picImage2
            // 
            this.picImage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImage2.Image = global::DiamondTrading.Properties.Resources.background;
            this.picImage2.Location = new System.Drawing.Point(72, 271);
            this.picImage2.Name = "picImage2";
            this.picImage2.Size = new System.Drawing.Size(50, 50);
            this.picImage2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImage2.TabIndex = 146;
            this.picImage2.TabStop = false;
            this.picImage2.Click += new System.EventHandler(this.picImage2_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(216, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(537, 339);
            this.tabControl1.TabIndex = 148;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(529, 313);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Image 1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DiamondTrading.Properties.Resources.background;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(523, 307);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 139;
            this.pictureBox1.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.Controls.Add(this.pictureBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(529, 313);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Image 2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DiamondTrading.Properties.Resources.background;
            this.pictureBox2.Location = new System.Drawing.Point(3, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(523, 307);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 140;
            this.pictureBox2.TabStop = false;
            // 
            // tabPage3
            // 
            this.tabPage3.AutoScroll = true;
            this.tabPage3.Controls.Add(this.pictureBox3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(529, 313);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Image 3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DiamondTrading.Properties.Resources.background;
            this.pictureBox3.Location = new System.Drawing.Point(3, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(523, 307);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 140;
            this.pictureBox3.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FrmTakePicture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 353);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupControl1);
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTakePicture";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Take Picture";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmTakePicture_FormClosed);
            this.Load += new System.EventHandler(this.FrmTakePicture_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDeviceDetails.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage2)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LookUpEdit lueDeviceDetails;
        private DevExpress.XtraEditors.SimpleButton btnCapture;
        private DevExpress.XtraEditors.SimpleButton btnClick;
        private DevExpress.XtraEditors.SimpleButton btnBrowse;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.PictureBox picImage1;
        private System.Windows.Forms.PictureBox picImage3;
        private System.Windows.Forms.PictureBox picImage2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

namespace DiamondTrading
{
    partial class frmMasterDetails
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
            this.xtabBranchMaster = new DevExpress.XtraTab.XtraTabPage();
            this.xtabCompanyMaster = new DevExpress.XtraTab.XtraTabPage();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.xtabMasterDetails = new DevExpress.XtraTab.XtraTabControl();
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.accordianAddBtn = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement2 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement3 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.xtabCompanyMaster.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtabMasterDetails)).BeginInit();
            this.xtabMasterDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // xtabBranchMaster
            // 
            this.xtabBranchMaster.Name = "xtabBranchMaster";
            this.xtabBranchMaster.Size = new System.Drawing.Size(695, 411);
            this.xtabBranchMaster.Text = "Branch Master";
            // 
            // xtabCompanyMaster
            // 
            this.xtabCompanyMaster.Controls.Add(this.gridControl1);
            this.xtabCompanyMaster.Name = "xtabCompanyMaster";
            this.xtabCompanyMaster.Size = new System.Drawing.Size(764, 411);
            this.xtabCompanyMaster.Text = "Company Master";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(764, 411);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // xtabMasterDetails
            // 
            this.xtabMasterDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtabMasterDetails.Location = new System.Drawing.Point(57, 3);
            this.xtabMasterDetails.Name = "xtabMasterDetails";
            this.xtabMasterDetails.SelectedTabPage = this.xtabCompanyMaster;
            this.xtabMasterDetails.Size = new System.Drawing.Size(766, 434);
            this.xtabMasterDetails.TabIndex = 0;
            this.xtabMasterDetails.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtabCompanyMaster,
            this.xtabBranchMaster});
            // 
            // accordionControl1
            // 
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordianAddBtn,
            this.accordionControlElement2,
            this.accordionControlElement3});
            this.accordionControl1.Location = new System.Drawing.Point(3, 3);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.OptionsMinimizing.State = DevExpress.XtraBars.Navigation.AccordionControlState.Minimized;
            this.accordionControl1.Size = new System.Drawing.Size(48, 434);
            this.accordionControl1.TabIndex = 2;
            this.accordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // accordianAddBtn
            // 
            this.accordianAddBtn.ImageOptions.Image = global::DiamondTrading.Properties.Resources.Add_24;
            this.accordianAddBtn.Name = "accordianAddBtn";
            this.accordianAddBtn.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordianAddBtn.Text = "Add";
            this.accordianAddBtn.Click += new System.EventHandler(this.accordianAddBtn_Click);
            // 
            // accordionControlElement2
            // 
            this.accordionControlElement2.ImageOptions.Image = global::DiamondTrading.Properties.Resources.edit_24;
            this.accordionControlElement2.Name = "accordionControlElement2";
            this.accordionControlElement2.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement2.Text = "Edit";
            // 
            // accordionControlElement3
            // 
            this.accordionControlElement3.ImageOptions.Image = global::DiamondTrading.Properties.Resources.delete_24;
            this.accordionControlElement3.Name = "accordionControlElement3";
            this.accordionControlElement3.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement3.Text = "Delete";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.accordionControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.xtabMasterDetails, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(826, 440);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // frmMasterDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 440);
            this.Controls.Add(this.tableLayoutPanel1);
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMasterDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Master Details";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.xtabCompanyMaster.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtabMasterDetails)).EndInit();
            this.xtabMasterDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabPage xtabBranchMaster;
        private DevExpress.XtraTab.XtraTabPage xtabCompanyMaster;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraTab.XtraTabControl xtabMasterDetails;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordianAddBtn;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement2;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
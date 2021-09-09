
namespace DiamondTrading
{
    partial class FrmMasterDetails
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
            this.tlCompanyMaster = new DevExpress.XtraTreeList.TreeList();
            this.Name = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.Id = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.Type = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.xtabMasterDetails = new DevExpress.XtraTab.XtraTabControl();
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.accordianAddBtn = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionEditBtn = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionDeleteBtn = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionRefreshBtn = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.xtabCompanyMaster.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlCompanyMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtabMasterDetails)).BeginInit();
            this.xtabMasterDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // xtabBranchMaster
            // 
            this.xtabBranchMaster.Name = "xtabBranchMaster";
            this.xtabBranchMaster.Size = new System.Drawing.Size(764, 411);
            this.xtabBranchMaster.Text = "Branch Master";
            // 
            // xtabCompanyMaster
            // 
            this.xtabCompanyMaster.Controls.Add(this.tlCompanyMaster);
            this.xtabCompanyMaster.Name = "xtabCompanyMaster";
            this.xtabCompanyMaster.Size = new System.Drawing.Size(764, 411);
            this.xtabCompanyMaster.Text = "Company Master";
            // 
            // tlCompanyMaster
            // 
            this.tlCompanyMaster.Appearance.Row.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlCompanyMaster.Appearance.Row.Options.UseFont = true;
            this.tlCompanyMaster.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.Name,
            this.Id,
            this.Type});
            this.tlCompanyMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlCompanyMaster.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlCompanyMaster.KeyFieldName = "Id";
            this.tlCompanyMaster.Location = new System.Drawing.Point(0, 0);
            this.tlCompanyMaster.Name = "tlCompanyMaster";
            this.tlCompanyMaster.OptionsBehavior.AllowPixelScrolling = DevExpress.Utils.DefaultBoolean.True;
            this.tlCompanyMaster.OptionsBehavior.Editable = false;
            this.tlCompanyMaster.OptionsScrollAnnotations.ShowSelectedRows = DevExpress.Utils.DefaultBoolean.True;
            this.tlCompanyMaster.OptionsSelection.UseIndicatorForSelection = true;
            this.tlCompanyMaster.ParentFieldName = "Type";
            this.tlCompanyMaster.Size = new System.Drawing.Size(764, 411);
            this.tlCompanyMaster.TabIndex = 1;
            // 
            // Name
            // 
            this.Name.Caption = "Company Name";
            this.Name.FieldName = "Name";
            this.Name.Name = "Name";
            this.Name.Visible = true;
            this.Name.VisibleIndex = 0;
            // 
            // Id
            // 
            this.Id.Caption = "CompanyID";
            this.Id.FieldName = "Id";
            this.Id.Name = "Id";
            // 
            // Type
            // 
            this.Type.Caption = "Type";
            this.Type.FieldName = "Type";
            this.Type.Name = "Type";
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
            this.xtabMasterDetails.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtabMasterDetails_SelectedPageChanged);
            // 
            // accordionControl1
            // 
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordianAddBtn,
            this.accordionEditBtn,
            this.accordionDeleteBtn,
            this.accordionRefreshBtn});
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
            // accordionEditBtn
            // 
            this.accordionEditBtn.ImageOptions.Image = global::DiamondTrading.Properties.Resources.edit_24;
            this.accordionEditBtn.Name = "accordionEditBtn";
            this.accordionEditBtn.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionEditBtn.Text = "Edit";
            this.accordionEditBtn.Click += new System.EventHandler(this.accordionEditBtn_Click);
            // 
            // accordionDeleteBtn
            // 
            this.accordionDeleteBtn.ImageOptions.Image = global::DiamondTrading.Properties.Resources.delete_24;
            this.accordionDeleteBtn.Name = "accordionDeleteBtn";
            this.accordionDeleteBtn.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionDeleteBtn.Text = "Delete";
            // 
            // accordionRefreshBtn
            // 
            this.accordionRefreshBtn.ImageOptions.Image = global::DiamondTrading.Properties.Resources.refresh_24;
            this.accordionRefreshBtn.Name = "accordionRefreshBtn";
            this.accordionRefreshBtn.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionRefreshBtn.Text = "Refresh";
            this.accordionRefreshBtn.Click += new System.EventHandler(this.accordionRefreshBtn_Click);
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
            // FrmMasterDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 440);
            this.Controls.Add(this.tableLayoutPanel1);
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Master Details";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMasterDetails_Load);
            this.xtabCompanyMaster.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tlCompanyMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtabMasterDetails)).EndInit();
            this.xtabMasterDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabPage xtabBranchMaster;
        private DevExpress.XtraTab.XtraTabPage xtabCompanyMaster;
        private DevExpress.XtraTab.XtraTabControl xtabMasterDetails;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordianAddBtn;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionEditBtn;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionDeleteBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraTreeList.TreeList tlCompanyMaster;
        private DevExpress.XtraTreeList.Columns.TreeListColumn Name;
        private DevExpress.XtraTreeList.Columns.TreeListColumn Id;
        private DevExpress.XtraTreeList.Columns.TreeListColumn Type;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionRefreshBtn;
    }
}
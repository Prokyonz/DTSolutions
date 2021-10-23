
namespace DiamondTrading
{
    partial class FrmTransactionDetails
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            this.grdChildCompanyMaster = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdCompanyMaster = new DevExpress.XtraGrid.GridControl();
            this.grvCompanyMaster = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn26 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn27 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn28 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn29 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn30 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtabSales = new DevExpress.XtraTab.XtraTabPage();
            this.xtabPurchase = new DevExpress.XtraTab.XtraTabPage();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.xtabMasterDetails = new DevExpress.XtraTab.XtraTabControl();
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.accordianAddBtn = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionEditBtn = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionDeleteBtn = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionRefreshBtn = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionCancelButton = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.grdChildCompanyMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCompanyMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCompanyMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.xtabSales.SuspendLayout();
            this.xtabPurchase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtabMasterDetails)).BeginInit();
            this.xtabMasterDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdChildCompanyMaster
            // 
            this.grdChildCompanyMaster.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15});
            this.grdChildCompanyMaster.GridControl = this.grdCompanyMaster;
            this.grdChildCompanyMaster.Name = "grdChildCompanyMaster";
            this.grdChildCompanyMaster.OptionsBehavior.Editable = false;
            this.grdChildCompanyMaster.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Id";
            this.gridColumn8.FieldName = "Id";
            this.gridColumn8.Name = "gridColumn8";
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Company Name";
            this.gridColumn9.FieldName = "Name";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 0;
            this.gridColumn9.Width = 359;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Registration No";
            this.gridColumn10.FieldName = "RegistrationNo";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 2;
            this.gridColumn10.Width = 82;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "GST No";
            this.gridColumn11.FieldName = "GSTNo";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 1;
            this.gridColumn11.Width = 89;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Mobile No";
            this.gridColumn13.FieldName = "MobileNo";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 4;
            this.gridColumn13.Width = 94;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Pancard No";
            this.gridColumn14.FieldName = "PanCardNo";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 3;
            this.gridColumn14.Width = 82;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Updated Date";
            this.gridColumn15.FieldName = "UpdatedDate";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 5;
            this.gridColumn15.Width = 84;
            // 
            // grdCompanyMaster
            // 
            this.grdCompanyMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.LevelTemplate = this.grdChildCompanyMaster;
            gridLevelNode1.RelationName = "Child";
            this.grdCompanyMaster.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grdCompanyMaster.Location = new System.Drawing.Point(0, 0);
            this.grdCompanyMaster.MainView = this.grvCompanyMaster;
            this.grdCompanyMaster.Name = "grdCompanyMaster";
            this.grdCompanyMaster.Size = new System.Drawing.Size(764, 411);
            this.grdCompanyMaster.TabIndex = 2;
            this.grdCompanyMaster.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvCompanyMaster,
            this.grdChildCompanyMaster});
            // 
            // grvCompanyMaster
            // 
            this.grvCompanyMaster.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn12,
            this.gridColumn6,
            this.gridColumn7});
            this.grvCompanyMaster.GridControl = this.grdCompanyMaster;
            this.grvCompanyMaster.Name = "grvCompanyMaster";
            this.grvCompanyMaster.OptionsBehavior.Editable = false;
            this.grvCompanyMaster.OptionsView.ShowGroupPanel = false;
            this.grvCompanyMaster.MasterRowEmpty += new DevExpress.XtraGrid.Views.Grid.MasterRowEmptyEventHandler(this.gridViewCompanyMaster_MasterRowEmpty);
            this.grvCompanyMaster.MasterRowGetChildList += new DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventHandler(this.gridViewCompanyMaster_MasterRowGetChildList);
            this.grvCompanyMaster.MasterRowGetRelationName += new DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventHandler(this.gridViewCompanyMaster_MasterRowGetRelationName);
            this.grvCompanyMaster.MasterRowGetRelationCount += new DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventHandler(this.gridViewCompanyMaster_MasterRowGetRelationCount);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Id";
            this.gridColumn1.FieldName = "Id";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Company Name";
            this.gridColumn2.FieldName = "Name";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 313;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Registration No";
            this.gridColumn3.FieldName = "RegistrationNo";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 93;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Mobile No";
            this.gridColumn4.FieldName = "MobileNo";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            this.gridColumn4.Width = 93;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "GST No";
            this.gridColumn5.FieldName = "GSTNo";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            this.gridColumn5.Width = 93;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Pancard No";
            this.gridColumn12.FieldName = "PanCardNo";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 2;
            this.gridColumn12.Width = 93;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Updated By";
            this.gridColumn6.FieldName = "UpdatedBy";
            this.gridColumn6.Name = "gridColumn6";
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Updated Date";
            this.gridColumn7.FieldName = "UpdatedDate";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            this.gridColumn7.Width = 105;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn18,
            this.gridColumn19,
            this.gridColumn20,
            this.gridColumn21,
            this.gridColumn22});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Id";
            this.gridColumn16.FieldName = "Id";
            this.gridColumn16.Name = "gridColumn16";
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "Company Name";
            this.gridColumn17.FieldName = "Name";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 0;
            this.gridColumn17.Width = 359;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "Registration No";
            this.gridColumn18.FieldName = "RegistrationNo";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 2;
            this.gridColumn18.Width = 82;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "GST No";
            this.gridColumn19.FieldName = "GSTNo";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 1;
            this.gridColumn19.Width = 89;
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "Mobile No";
            this.gridColumn20.FieldName = "MobileNo";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 4;
            this.gridColumn20.Width = 94;
            // 
            // gridColumn21
            // 
            this.gridColumn21.Caption = "Pancard No";
            this.gridColumn21.FieldName = "PanCardNo";
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.Visible = true;
            this.gridColumn21.VisibleIndex = 3;
            this.gridColumn21.Width = 82;
            // 
            // gridColumn22
            // 
            this.gridColumn22.Caption = "Updated Date";
            this.gridColumn22.FieldName = "UpdatedDate";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 5;
            this.gridColumn22.Width = 84;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode2.LevelTemplate = this.gridView1;
            gridLevelNode2.RelationName = "Child";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2});
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView2;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(764, 411);
            this.gridControl1.TabIndex = 3;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2,
            this.gridView1});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn23,
            this.gridColumn24,
            this.gridColumn25,
            this.gridColumn26,
            this.gridColumn27,
            this.gridColumn28,
            this.gridColumn29,
            this.gridColumn30});
            this.gridView2.GridControl = this.gridControl1;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn23
            // 
            this.gridColumn23.Caption = "Id";
            this.gridColumn23.FieldName = "Id";
            this.gridColumn23.Name = "gridColumn23";
            // 
            // gridColumn24
            // 
            this.gridColumn24.Caption = "Company Name";
            this.gridColumn24.FieldName = "Name";
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.Visible = true;
            this.gridColumn24.VisibleIndex = 0;
            this.gridColumn24.Width = 313;
            // 
            // gridColumn25
            // 
            this.gridColumn25.Caption = "Registration No";
            this.gridColumn25.FieldName = "RegistrationNo";
            this.gridColumn25.Name = "gridColumn25";
            this.gridColumn25.Visible = true;
            this.gridColumn25.VisibleIndex = 3;
            this.gridColumn25.Width = 93;
            // 
            // gridColumn26
            // 
            this.gridColumn26.Caption = "Mobile No";
            this.gridColumn26.FieldName = "MobileNo";
            this.gridColumn26.Name = "gridColumn26";
            this.gridColumn26.Visible = true;
            this.gridColumn26.VisibleIndex = 4;
            this.gridColumn26.Width = 93;
            // 
            // gridColumn27
            // 
            this.gridColumn27.Caption = "GST No";
            this.gridColumn27.FieldName = "GSTNo";
            this.gridColumn27.Name = "gridColumn27";
            this.gridColumn27.Visible = true;
            this.gridColumn27.VisibleIndex = 1;
            this.gridColumn27.Width = 93;
            // 
            // gridColumn28
            // 
            this.gridColumn28.Caption = "Pancard No";
            this.gridColumn28.FieldName = "PanCardNo";
            this.gridColumn28.Name = "gridColumn28";
            this.gridColumn28.Visible = true;
            this.gridColumn28.VisibleIndex = 2;
            this.gridColumn28.Width = 93;
            // 
            // gridColumn29
            // 
            this.gridColumn29.Caption = "Updated By";
            this.gridColumn29.FieldName = "UpdatedBy";
            this.gridColumn29.Name = "gridColumn29";
            // 
            // gridColumn30
            // 
            this.gridColumn30.Caption = "Updated Date";
            this.gridColumn30.FieldName = "UpdatedDate";
            this.gridColumn30.Name = "gridColumn30";
            this.gridColumn30.Visible = true;
            this.gridColumn30.VisibleIndex = 5;
            this.gridColumn30.Width = 105;
            // 
            // xtabSales
            // 
            this.xtabSales.Controls.Add(this.gridControl1);
            this.xtabSales.Name = "xtabSales";
            this.xtabSales.PageVisible = false;
            this.xtabSales.Size = new System.Drawing.Size(764, 411);
            this.xtabSales.Text = "SALES DETAILS";
            // 
            // xtabPurchase
            // 
            this.xtabPurchase.Controls.Add(this.grdCompanyMaster);
            this.xtabPurchase.Name = "xtabPurchase";
            this.xtabPurchase.PageVisible = false;
            this.xtabPurchase.Size = new System.Drawing.Size(764, 411);
            this.xtabPurchase.Text = "PURCHASE DETAILS";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(276, 47);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // xtabMasterDetails
            // 
            this.xtabMasterDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtabMasterDetails.Location = new System.Drawing.Point(57, 3);
            this.xtabMasterDetails.Name = "xtabMasterDetails";
            this.xtabMasterDetails.SelectedTabPage = this.xtabPurchase;
            this.xtabMasterDetails.Size = new System.Drawing.Size(766, 434);
            this.xtabMasterDetails.TabIndex = 0;
            this.xtabMasterDetails.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtabPurchase,
            this.xtabSales});
            this.xtabMasterDetails.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtabMasterDetails_SelectedPageChanged);
            // 
            // accordionControl1
            // 
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordianAddBtn,
            this.accordionEditBtn,
            this.accordionDeleteBtn,
            this.accordionRefreshBtn,
            this.accordionCancelButton});
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
            this.accordionDeleteBtn.Click += new System.EventHandler(this.accordionDeleteBtn_Click);
            // 
            // accordionRefreshBtn
            // 
            this.accordionRefreshBtn.ImageOptions.Image = global::DiamondTrading.Properties.Resources.refresh_24;
            this.accordionRefreshBtn.Name = "accordionRefreshBtn";
            this.accordionRefreshBtn.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionRefreshBtn.Text = "Refresh";
            this.accordionRefreshBtn.Click += new System.EventHandler(this.accordionRefreshBtn_Click);
            // 
            // accordionCancelButton
            // 
            this.accordionCancelButton.ImageOptions.Image = global::DiamondTrading.Properties.Resources.close_24;
            this.accordionCancelButton.Name = "accordionCancelButton";
            this.accordionCancelButton.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionCancelButton.Text = "Cancel";
            this.accordionCancelButton.Click += new System.EventHandler(this.accordionCancelButton_Click);
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
            // FrmTransactionDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(826, 440);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTransactionDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transaction Details";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMasterDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdChildCompanyMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCompanyMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCompanyMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.xtabSales.ResumeLayout(false);
            this.xtabPurchase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtabMasterDetails)).EndInit();
            this.xtabMasterDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabPage xtabSales;
        private DevExpress.XtraTab.XtraTabPage xtabPurchase;
        private DevExpress.XtraTab.XtraTabControl xtabMasterDetails;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordianAddBtn;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionEditBtn;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionDeleteBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionRefreshBtn;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionCancelButton;
        private DevExpress.XtraGrid.GridControl grdCompanyMaster;
        private DevExpress.XtraGrid.Views.Grid.GridView grvCompanyMaster;
        private DevExpress.XtraGrid.Views.Grid.GridView grdChildCompanyMaster;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn26;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn27;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn28;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn29;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn30;
    }
}
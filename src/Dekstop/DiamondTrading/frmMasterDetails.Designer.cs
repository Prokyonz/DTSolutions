
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.grdLessWeightGroupDetailMaster = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdLessGroupWeightMaster = new DevExpress.XtraGrid.GridControl();
            this.grvLessGroupWeightMaster = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colLessWeightGroupID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLessWeightGroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtabBranchMaster = new DevExpress.XtraTab.XtraTabPage();
            this.xtabCompanyMaster = new DevExpress.XtraTab.XtraTabPage();
            this.tlCompanyMaster = new DevExpress.XtraTreeList.TreeList();
            this.Name = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.Id = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.Type = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colCompanyMobileNo = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colCompanyRegistrationNo = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colCompanyGSTNo = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colCompanyPancardNo = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.xtabMasterDetails = new DevExpress.XtraTab.XtraTabControl();
            this.xtabLessWeightGroupMaster = new DevExpress.XtraTab.XtraTabPage();
            this.xtabShapeMaster = new DevExpress.XtraTab.XtraTabPage();
            this.grdShapeMaster = new DevExpress.XtraGrid.GridControl();
            this.grvShapeMaster = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colShapeId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShapeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtabPurityMaster = new DevExpress.XtraTab.XtraTabPage();
            this.grdPurityMaster = new DevExpress.XtraGrid.GridControl();
            this.grvPurityMaster = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPurityId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPurityName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.accordianAddBtn = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionEditBtn = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionDeleteBtn = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionRefreshBtn = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.xtabSizeMaster = new DevExpress.XtraTab.XtraTabPage();
            this.grdSizeMaster = new DevExpress.XtraGrid.GridControl();
            this.grvSizeMaster = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSizeId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSizeName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdLessWeightGroupDetailMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLessGroupWeightMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLessGroupWeightMaster)).BeginInit();
            this.xtabCompanyMaster.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlCompanyMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtabMasterDetails)).BeginInit();
            this.xtabMasterDetails.SuspendLayout();
            this.xtabLessWeightGroupMaster.SuspendLayout();
            this.xtabShapeMaster.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdShapeMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvShapeMaster)).BeginInit();
            this.xtabPurityMaster.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPurityMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPurityMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.xtabSizeMaster.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSizeMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSizeMaster)).BeginInit();
            this.SuspendLayout();
            // 
            // grdLessWeightGroupDetailMaster
            // 
            this.grdLessWeightGroupDetailMaster.GridControl = this.grdLessGroupWeightMaster;
            this.grdLessWeightGroupDetailMaster.Name = "grdLessWeightGroupDetailMaster";
            // 
            // grdLessGroupWeightMaster
            // 
            this.grdLessGroupWeightMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.LevelTemplate = this.grdLessWeightGroupDetailMaster;
            gridLevelNode1.RelationName = "Level1";
            this.grdLessGroupWeightMaster.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grdLessGroupWeightMaster.Location = new System.Drawing.Point(0, 0);
            this.grdLessGroupWeightMaster.MainView = this.grvLessGroupWeightMaster;
            this.grdLessGroupWeightMaster.Name = "grdLessGroupWeightMaster";
            this.grdLessGroupWeightMaster.ShowOnlyPredefinedDetails = true;
            this.grdLessGroupWeightMaster.Size = new System.Drawing.Size(764, 411);
            this.grdLessGroupWeightMaster.TabIndex = 0;
            this.grdLessGroupWeightMaster.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvLessGroupWeightMaster,
            this.grdLessWeightGroupDetailMaster});
            // 
            // grvLessGroupWeightMaster
            // 
            this.grvLessGroupWeightMaster.Appearance.Row.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvLessGroupWeightMaster.Appearance.Row.Options.UseFont = true;
            this.grvLessGroupWeightMaster.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colLessWeightGroupID,
            this.colLessWeightGroupName});
            this.grvLessGroupWeightMaster.GridControl = this.grdLessGroupWeightMaster;
            this.grvLessGroupWeightMaster.Name = "grvLessGroupWeightMaster";
            this.grvLessGroupWeightMaster.OptionsBehavior.Editable = false;
            this.grvLessGroupWeightMaster.OptionsScrollAnnotations.ShowSelectedRows = DevExpress.Utils.DefaultBoolean.True;
            this.grvLessGroupWeightMaster.OptionsView.ShowGroupPanel = false;
            this.grvLessGroupWeightMaster.MasterRowEmpty += new DevExpress.XtraGrid.Views.Grid.MasterRowEmptyEventHandler(this.grvLessGroupWeightMaster_MasterRowEmpty);
            this.grvLessGroupWeightMaster.MasterRowGetChildList += new DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventHandler(this.grvLessGroupWeightMaster_MasterRowGetChildList);
            // 
            // colLessWeightGroupID
            // 
            this.colLessWeightGroupID.Caption = "ID";
            this.colLessWeightGroupID.FieldName = "Id";
            this.colLessWeightGroupID.Name = "colLessWeightGroupID";
            // 
            // colLessWeightGroupName
            // 
            this.colLessWeightGroupName.Caption = "Name";
            this.colLessWeightGroupName.FieldName = "Name";
            this.colLessWeightGroupName.Name = "colLessWeightGroupName";
            this.colLessWeightGroupName.Visible = true;
            this.colLessWeightGroupName.VisibleIndex = 0;
            this.colLessWeightGroupName.Width = 388;
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
            this.Type,
            this.colCompanyMobileNo,
            this.colCompanyRegistrationNo,
            this.colCompanyGSTNo,
            this.colCompanyPancardNo});
            this.tlCompanyMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlCompanyMaster.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlCompanyMaster.KeyFieldName = "Id";
            this.tlCompanyMaster.Location = new System.Drawing.Point(0, 0);
            this.tlCompanyMaster.Name = "tlCompanyMaster";
            this.tlCompanyMaster.OptionsBehavior.AllowPixelScrolling = DevExpress.Utils.DefaultBoolean.True;
            this.tlCompanyMaster.OptionsBehavior.Editable = false;
            this.tlCompanyMaster.OptionsBehavior.PopulateServiceColumns = true;
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
            this.Name.Width = 302;
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
            // colCompanyMobileNo
            // 
            this.colCompanyMobileNo.Caption = "Mobile No";
            this.colCompanyMobileNo.FieldName = "MobileNo";
            this.colCompanyMobileNo.Name = "colCompanyMobileNo";
            this.colCompanyMobileNo.Visible = true;
            this.colCompanyMobileNo.VisibleIndex = 1;
            this.colCompanyMobileNo.Width = 106;
            // 
            // colCompanyRegistrationNo
            // 
            this.colCompanyRegistrationNo.Caption = "Registration No";
            this.colCompanyRegistrationNo.FieldName = "RegistrationNo";
            this.colCompanyRegistrationNo.Name = "colCompanyRegistrationNo";
            this.colCompanyRegistrationNo.Visible = true;
            this.colCompanyRegistrationNo.VisibleIndex = 2;
            this.colCompanyRegistrationNo.Width = 92;
            // 
            // colCompanyGSTNo
            // 
            this.colCompanyGSTNo.Caption = "GST No";
            this.colCompanyGSTNo.FieldName = "GSTNo";
            this.colCompanyGSTNo.Name = "colCompanyGSTNo";
            this.colCompanyGSTNo.Visible = true;
            this.colCompanyGSTNo.VisibleIndex = 3;
            this.colCompanyGSTNo.Width = 99;
            // 
            // colCompanyPancardNo
            // 
            this.colCompanyPancardNo.Caption = "Pancard No";
            this.colCompanyPancardNo.FieldName = "PanCardNo";
            this.colCompanyPancardNo.Name = "colCompanyPancardNo";
            this.colCompanyPancardNo.Visible = true;
            this.colCompanyPancardNo.VisibleIndex = 4;
            this.colCompanyPancardNo.Width = 84;
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
            this.xtabBranchMaster,
            this.xtabLessWeightGroupMaster,
            this.xtabShapeMaster,
            this.xtabPurityMaster,
            this.xtabSizeMaster});
            this.xtabMasterDetails.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtabMasterDetails_SelectedPageChanged);
            // 
            // xtabLessWeightGroupMaster
            // 
            this.xtabLessWeightGroupMaster.Controls.Add(this.grdLessGroupWeightMaster);
            this.xtabLessWeightGroupMaster.Name = "xtabLessWeightGroupMaster";
            this.xtabLessWeightGroupMaster.Size = new System.Drawing.Size(764, 411);
            this.xtabLessWeightGroupMaster.Text = "Less Weight Group Master";
            // 
            // xtabShapeMaster
            // 
            this.xtabShapeMaster.Controls.Add(this.grdShapeMaster);
            this.xtabShapeMaster.Name = "xtabShapeMaster";
            this.xtabShapeMaster.Size = new System.Drawing.Size(764, 411);
            this.xtabShapeMaster.Text = "Shape Master";
            // 
            // grdShapeMaster
            // 
            this.grdShapeMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdShapeMaster.Location = new System.Drawing.Point(0, 0);
            this.grdShapeMaster.MainView = this.grvShapeMaster;
            this.grdShapeMaster.Name = "grdShapeMaster";
            this.grdShapeMaster.Size = new System.Drawing.Size(764, 411);
            this.grdShapeMaster.TabIndex = 0;
            this.grdShapeMaster.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvShapeMaster});
            // 
            // grvShapeMaster
            // 
            this.grvShapeMaster.Appearance.Row.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvShapeMaster.Appearance.Row.Options.UseFont = true;
            this.grvShapeMaster.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colShapeId,
            this.colShapeName});
            this.grvShapeMaster.GridControl = this.grdShapeMaster;
            this.grvShapeMaster.Name = "grvShapeMaster";
            this.grvShapeMaster.OptionsBehavior.Editable = false;
            this.grvShapeMaster.OptionsView.ShowGroupPanel = false;
            // 
            // colShapeId
            // 
            this.colShapeId.Caption = "Id";
            this.colShapeId.FieldName = "Id";
            this.colShapeId.Name = "colShapeId";
            // 
            // colShapeName
            // 
            this.colShapeName.Caption = "Shape Name";
            this.colShapeName.FieldName = "Name";
            this.colShapeName.Name = "colShapeName";
            this.colShapeName.Visible = true;
            this.colShapeName.VisibleIndex = 0;
            // 
            // xtabPurityMaster
            // 
            this.xtabPurityMaster.Controls.Add(this.grdPurityMaster);
            this.xtabPurityMaster.Name = "xtabPurityMaster";
            this.xtabPurityMaster.Size = new System.Drawing.Size(764, 411);
            this.xtabPurityMaster.Text = "Purity Master";
            // 
            // grdPurityMaster
            // 
            this.grdPurityMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPurityMaster.Location = new System.Drawing.Point(0, 0);
            this.grdPurityMaster.MainView = this.grvPurityMaster;
            this.grdPurityMaster.Name = "grdPurityMaster";
            this.grdPurityMaster.Size = new System.Drawing.Size(764, 411);
            this.grdPurityMaster.TabIndex = 1;
            this.grdPurityMaster.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvPurityMaster});
            // 
            // grvPurityMaster
            // 
            this.grvPurityMaster.Appearance.Row.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvPurityMaster.Appearance.Row.Options.UseFont = true;
            this.grvPurityMaster.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPurityId,
            this.colPurityName});
            this.grvPurityMaster.GridControl = this.grdPurityMaster;
            this.grvPurityMaster.Name = "grvPurityMaster";
            this.grvPurityMaster.OptionsBehavior.Editable = false;
            this.grvPurityMaster.OptionsView.ShowGroupPanel = false;
            // 
            // colPurityId
            // 
            this.colPurityId.Caption = "Id";
            this.colPurityId.FieldName = "Id";
            this.colPurityId.Name = "colPurityId";
            // 
            // colPurityName
            // 
            this.colPurityName.Caption = "Purity Name";
            this.colPurityName.FieldName = "Name";
            this.colPurityName.Name = "colPurityName";
            this.colPurityName.Visible = true;
            this.colPurityName.VisibleIndex = 0;
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
            // xtabSizeMaster
            // 
            this.xtabSizeMaster.Controls.Add(this.grdSizeMaster);
            this.xtabSizeMaster.Name = "xtabSizeMaster";
            this.xtabSizeMaster.Size = new System.Drawing.Size(764, 411);
            this.xtabSizeMaster.Text = "Size Master";
            // 
            // grdSizeMaster
            // 
            this.grdSizeMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSizeMaster.Location = new System.Drawing.Point(0, 0);
            this.grdSizeMaster.MainView = this.grvSizeMaster;
            this.grdSizeMaster.Name = "grdSizeMaster";
            this.grdSizeMaster.Size = new System.Drawing.Size(764, 411);
            this.grdSizeMaster.TabIndex = 2;
            this.grdSizeMaster.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvSizeMaster});
            // 
            // grvSizeMaster
            // 
            this.grvSizeMaster.Appearance.Row.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvSizeMaster.Appearance.Row.Options.UseFont = true;
            this.grvSizeMaster.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSizeId,
            this.colSizeName});
            this.grvSizeMaster.GridControl = this.grdSizeMaster;
            this.grvSizeMaster.Name = "grvSizeMaster";
            this.grvSizeMaster.OptionsBehavior.Editable = false;
            this.grvSizeMaster.OptionsView.ShowGroupPanel = false;
            // 
            // colSizeId
            // 
            this.colSizeId.Caption = "Id";
            this.colSizeId.FieldName = "Id";
            this.colSizeId.Name = "colSizeId";
            // 
            // colSizeName
            // 
            this.colSizeName.Caption = "Size Name";
            this.colSizeName.FieldName = "Name";
            this.colSizeName.Name = "colSizeName";
            this.colSizeName.Visible = true;
            this.colSizeName.VisibleIndex = 0;
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
            ((System.ComponentModel.ISupportInitialize)(this.grdLessWeightGroupDetailMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLessGroupWeightMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLessGroupWeightMaster)).EndInit();
            this.xtabCompanyMaster.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tlCompanyMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtabMasterDetails)).EndInit();
            this.xtabMasterDetails.ResumeLayout(false);
            this.xtabLessWeightGroupMaster.ResumeLayout(false);
            this.xtabShapeMaster.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdShapeMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvShapeMaster)).EndInit();
            this.xtabPurityMaster.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPurityMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPurityMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.xtabSizeMaster.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSizeMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSizeMaster)).EndInit();
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
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCompanyMobileNo;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCompanyRegistrationNo;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCompanyGSTNo;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCompanyPancardNo;
        private DevExpress.XtraTab.XtraTabPage xtabLessWeightGroupMaster;
        private DevExpress.XtraGrid.GridControl grdLessGroupWeightMaster;
        private DevExpress.XtraGrid.Views.Grid.GridView grvLessGroupWeightMaster;
        private DevExpress.XtraGrid.Columns.GridColumn colLessWeightGroupID;
        private DevExpress.XtraGrid.Columns.GridColumn colLessWeightGroupName;
        private DevExpress.XtraGrid.Views.Grid.GridView grdLessWeightGroupDetailMaster;
        private DevExpress.XtraTab.XtraTabPage xtabShapeMaster;
        private DevExpress.XtraGrid.GridControl grdShapeMaster;
        private DevExpress.XtraGrid.Views.Grid.GridView grvShapeMaster;
        private DevExpress.XtraGrid.Columns.GridColumn colShapeId;
        private DevExpress.XtraGrid.Columns.GridColumn colShapeName;
        private DevExpress.XtraTab.XtraTabPage xtabPurityMaster;
        private DevExpress.XtraGrid.GridControl grdPurityMaster;
        private DevExpress.XtraGrid.Views.Grid.GridView grvPurityMaster;
        private DevExpress.XtraGrid.Columns.GridColumn colPurityId;
        private DevExpress.XtraGrid.Columns.GridColumn colPurityName;
        private DevExpress.XtraTab.XtraTabPage xtabSizeMaster;
        private DevExpress.XtraGrid.GridControl grdSizeMaster;
        private DevExpress.XtraGrid.Views.Grid.GridView grvSizeMaster;
        private DevExpress.XtraGrid.Columns.GridColumn colSizeId;
        private DevExpress.XtraGrid.Columns.GridColumn colSizeName;
    }
}
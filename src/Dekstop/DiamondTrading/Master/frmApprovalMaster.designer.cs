
namespace DiamondTrading.Master
{
    partial class frmApprovalMaster
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
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.grdPermissionDetails = new DevExpress.XtraGrid.GridControl();
            this.grvPermissionDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colApproverType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colApproverName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repoUserName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridView6 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn43 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPermissionDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPermissionDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoUserName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView6)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(565, 305);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(646, 305);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.grdPermissionDetails);
            this.groupControl3.Location = new System.Drawing.Point(11, 12);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(710, 287);
            this.groupControl3.TabIndex = 9;
            this.groupControl3.Text = "Permissions";
            // 
            // grdPermissionDetails
            // 
            this.grdPermissionDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPermissionDetails.Location = new System.Drawing.Point(2, 23);
            this.grdPermissionDetails.MainView = this.grvPermissionDetails;
            this.grdPermissionDetails.Name = "grdPermissionDetails";
            this.grdPermissionDetails.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repoUserName});
            this.grdPermissionDetails.Size = new System.Drawing.Size(706, 262);
            this.grdPermissionDetails.TabIndex = 5;
            this.grdPermissionDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvPermissionDetails,
            this.gridView6});
            // 
            // grvPermissionDetails
            // 
            this.grvPermissionDetails.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colApproverType,
            this.colApproverName});
            this.grvPermissionDetails.GridControl = this.grdPermissionDetails;
            this.grvPermissionDetails.Name = "grvPermissionDetails";
            this.grvPermissionDetails.OptionsView.ShowGroupPanel = false;
            // 
            // colId
            // 
            this.colId.Caption = "Id";
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.Width = 148;
            // 
            // colApproverType
            // 
            this.colApproverType.Caption = "Approval Type";
            this.colApproverType.FieldName = "DisplayName";
            this.colApproverType.Name = "colApproverType";
            this.colApproverType.OptionsColumn.AllowEdit = false;
            this.colApproverType.Visible = true;
            this.colApproverType.VisibleIndex = 0;
            this.colApproverType.Width = 384;
            // 
            // colApproverName
            // 
            this.colApproverName.Caption = "Select Approvar Name";
            this.colApproverName.ColumnEdit = this.repoUserName;
            this.colApproverName.FieldName = "Name";
            this.colApproverName.Name = "colApproverName";
            this.colApproverName.Visible = true;
            this.colApproverName.VisibleIndex = 1;
            this.colApproverName.Width = 258;
            // 
            // repoUserName
            // 
            this.repoUserName.AutoHeight = false;
            this.repoUserName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repoUserName.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.repoUserName.Name = "repoUserName";
            this.repoUserName.NullText = "";
            // 
            // gridView6
            // 
            this.gridView6.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn43});
            this.gridView6.GridControl = this.grdPermissionDetails;
            this.gridView6.Name = "gridView6";
            this.gridView6.OptionsBehavior.Editable = false;
            this.gridView6.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn43
            // 
            this.gridColumn43.Caption = "Id";
            this.gridColumn43.FieldName = "Id";
            this.gridColumn43.Name = "gridColumn43";
            // 
            // frmApprovalMaster
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(735, 338);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.IconOptions.ShowIcon = false;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmApprovalMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Approval Details";
            this.Load += new System.EventHandler(this.frmUserMaster_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmUserMaster_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPermissionDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPermissionDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoUserName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraGrid.GridControl grdPermissionDetails;
        private DevExpress.XtraGrid.Views.Grid.GridView grvPermissionDetails;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn43;
        private DevExpress.XtraGrid.Columns.GridColumn colApproverType;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colApproverName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repoUserName;
    }
}

namespace DiamondTrading.Master
{
    partial class FrmLessWeightGroupMaster
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
            this.txtLessWeightGroupName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.grdLessGroupWeightDetails = new DevExpress.XtraGrid.GridControl();
            this.grvLessGroupWeightDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMinWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colMaxWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLessWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnReset = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLessWeightGroupName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLessGroupWeightDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLessGroupWeightDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtLessWeightGroupName);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Location = new System.Drawing.Point(10, 9);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(345, 86);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Group Name ";
            // 
            // txtLessWeightGroupName
            // 
            this.txtLessWeightGroupName.Location = new System.Drawing.Point(10, 50);
            this.txtLessWeightGroupName.Name = "txtLessWeightGroupName";
            this.txtLessWeightGroupName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.txtLessWeightGroupName.Properties.Appearance.Options.UseFont = true;
            this.txtLessWeightGroupName.Properties.BeepOnError = false;
            this.txtLessWeightGroupName.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLessWeightGroupName.Size = new System.Drawing.Size(324, 26);
            this.txtLessWeightGroupName.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(10, 30);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(38, 14);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Name*";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.grdLessGroupWeightDetails);
            this.groupControl2.Location = new System.Drawing.Point(10, 101);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(345, 270);
            this.groupControl2.TabIndex = 2;
            this.groupControl2.Text = "Details";
            // 
            // grdLessGroupWeightDetails
            // 
            this.grdLessGroupWeightDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLessGroupWeightDetails.Location = new System.Drawing.Point(2, 23);
            this.grdLessGroupWeightDetails.MainView = this.grvLessGroupWeightDetails;
            this.grdLessGroupWeightDetails.Name = "grdLessGroupWeightDetails";
            this.grdLessGroupWeightDetails.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1});
            this.grdLessGroupWeightDetails.Size = new System.Drawing.Size(341, 245);
            this.grdLessGroupWeightDetails.TabIndex = 1;
            this.grdLessGroupWeightDetails.UseEmbeddedNavigator = true;
            this.grdLessGroupWeightDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvLessGroupWeightDetails});
            // 
            // grvLessGroupWeightDetails
            // 
            this.grvLessGroupWeightDetails.Appearance.Row.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.grvLessGroupWeightDetails.Appearance.Row.Options.UseFont = true;
            this.grvLessGroupWeightDetails.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMinWeight,
            this.colMaxWeight,
            this.colLessWeight});
            this.grvLessGroupWeightDetails.GridControl = this.grdLessGroupWeightDetails;
            this.grvLessGroupWeightDetails.Name = "grvLessGroupWeightDetails";
            this.grvLessGroupWeightDetails.OptionsNavigation.EnterMoveNextColumn = true;
            this.grvLessGroupWeightDetails.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.grvLessGroupWeightDetails.OptionsView.ShowGroupPanel = false;
            this.grvLessGroupWeightDetails.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.grvLessGroupWeightDetails_ValidateRow);
            // 
            // colMinWeight
            // 
            this.colMinWeight.Caption = "Min Weight";
            this.colMinWeight.ColumnEdit = this.repositoryItemTextEdit1;
            this.colMinWeight.FieldName = "MinWeight";
            this.colMinWeight.Name = "colMinWeight";
            this.colMinWeight.Visible = true;
            this.colMinWeight.VisibleIndex = 0;
            this.colMinWeight.Width = 242;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.BeepOnError = true;
            this.repositoryItemTextEdit1.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.repositoryItemTextEdit1.MaskSettings.Set("mask", "f");
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            this.repositoryItemTextEdit1.UseMaskAsDisplayFormat = true;
            this.repositoryItemTextEdit1.ValidateOnEnterKey = true;
            // 
            // colMaxWeight
            // 
            this.colMaxWeight.Caption = "Max Weight";
            this.colMaxWeight.ColumnEdit = this.repositoryItemTextEdit1;
            this.colMaxWeight.FieldName = "MaxWeight";
            this.colMaxWeight.Name = "colMaxWeight";
            this.colMaxWeight.Visible = true;
            this.colMaxWeight.VisibleIndex = 1;
            this.colMaxWeight.Width = 272;
            // 
            // colLessWeight
            // 
            this.colLessWeight.AppearanceCell.BackColor = System.Drawing.Color.Silver;
            this.colLessWeight.AppearanceCell.Options.UseBackColor = true;
            this.colLessWeight.AppearanceHeader.BackColor = System.Drawing.Color.Silver;
            this.colLessWeight.AppearanceHeader.Options.UseBackColor = true;
            this.colLessWeight.Caption = "Less Weight";
            this.colLessWeight.ColumnEdit = this.repositoryItemTextEdit1;
            this.colLessWeight.FieldName = "LessWeight";
            this.colLessWeight.Name = "colLessWeight";
            this.colLessWeight.Visible = true;
            this.colLessWeight.VisibleIndex = 2;
            this.colLessWeight.Width = 276;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(283, 380);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(202, 380);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 8;
            this.btnReset.Text = "&Reset";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(121, 380);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FrmLessWeightGroupMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(368, 412);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.IconOptions.ShowIcon = false;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLessWeightGroupMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New Less Weight Group";
            this.Load += new System.EventHandler(this.FrmLessWeightGroupMaster_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmLessWeightGroupMaster_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLessWeightGroupName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdLessGroupWeightDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLessGroupWeightDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit txtLessWeightGroupName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnReset;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraGrid.GridControl grdLessGroupWeightDetails;
        private DevExpress.XtraGrid.Views.Grid.GridView grvLessGroupWeightDetails;
        private DevExpress.XtraGrid.Columns.GridColumn colMinWeight;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colMaxWeight;
        private DevExpress.XtraGrid.Columns.GridColumn colLessWeight;
    }
}
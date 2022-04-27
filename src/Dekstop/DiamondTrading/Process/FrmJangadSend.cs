using DevExpress.XtraEditors;
using EFCore.SQL.Repository;
using Repository.Entities;
using Repository.Entities.Models;
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

namespace DiamondTrading.Process
{
    public partial class FrmJangadSend : DevExpress.XtraEditors.XtraForm
    {
        BoilMasterRepository _boilMasterRepository;
        PartyMasterRepository _partyMasterRepository;
        BrokerageMasterRepository _brokerageMasterRepository;
        JangadMasterRepository _JangadMasterRepository;
        int _RejectionType = 0;

        public FrmJangadSend(int RejectionType)
        {
            InitializeComponent();
            _boilMasterRepository = new BoilMasterRepository();
            _partyMasterRepository = new PartyMasterRepository();
            _brokerageMasterRepository = new BrokerageMasterRepository();
            _JangadMasterRepository = new JangadMasterRepository();

            _RejectionType = RejectionType;

            LoadCompany();
            _ = GetSizeDetail();
            _ = GetMaxSrNo();

            if (RejectionType == 1)
            {
                SetThemeColors(Color.FromArgb(250, 243, 197));
                this.Text = "JANGAD RECEIVE";

                grvParticularsDetails.Columns["Size"].Visible = false;
                grvParticularsDetails.Columns["SizeR"].Visible = true;
                grvParticularsDetails.Columns["SizeR"].Width = 355;
            }
            else if (RejectionType == 2)
            {
                SetThemeColors(Color.FromArgb(215, 246, 214));
                this.Text = "JANGAD SEND";

                grvParticularsDetails.Columns["Size"].Visible = true;
                grvParticularsDetails.Columns["SizeR"].Visible = false;
                grvParticularsDetails.Columns["Size"].Width = 355;
            }
        }

        private async Task GetPartyList()
        {
            string companyId = Common.LoginCompany;
            if (lueCompany.EditValue != null)
            {
                if (lueCompany.EditValue.ToString() != Common.LoginCompany)
                    companyId = lueCompany.EditValue.ToString();
            }
            var PartyDetailList = await _partyMasterRepository.GetAllPartyAsync(companyId, PartyTypeMaster.Party);
            lueParty.Properties.DataSource = PartyDetailList;
            lueParty.Properties.DisplayMember = "Name";
            lueParty.Properties.ValueMember = "Id";
        }

        private async Task GetMaxSrNo()
        {
            var SrNo = await _JangadMasterRepository.GetMaxSrNoAsync(Common.LoginCompany.ToString(), Common.LoginFinancialYear, _RejectionType);
            txtSerialNo.Text = SrNo.ToString();
        }

        private async Task GetBrokerList()
        {
            string companyId = Common.LoginCompany;
            if (lueCompany.EditValue != null)
            {
                if (lueCompany.EditValue.ToString() != Common.LoginCompany)
                    companyId = lueCompany.EditValue.ToString();
            }
            var BrokerDetailList = await _partyMasterRepository.GetAllPartyAsync(companyId, PartyTypeMaster.Employee, PartyTypeMaster.Broker);
            lueBroker.Properties.DataSource = BrokerDetailList;
            lueBroker.Properties.DisplayMember = "Name";
            lueBroker.Properties.ValueMember = "Id";
        }

        private async Task GetSizeDetail()
        {
            grdParticularsDetails.DataSource = GetDTColumnsforParticularDetails();
            if (_RejectionType == 1)
            {
                if (lueCompany.EditValue != null && lueBroker.EditValue != null)
                {
                    var JangadReceiveDetails = await _JangadMasterRepository.GetJangadReceiveDetails(lueCompany.EditValue.ToString(), Common.LoginFinancialYear, lueBroker.EditValue.ToString());
                    repoSizeR.DataSource = JangadReceiveDetails;
                    repoSizeR.DisplayMember = "Size";
                    repoSizeR.ValueMember = "Id";
                }
            }
            else
            {
                SizeMasterRepository sizeMasterRepository = new SizeMasterRepository();
                var sizeMaster = await sizeMasterRepository.GetAllSizeAsync();
                repoSize.DataSource = sizeMaster;
                repoSize.DisplayMember = "Name";
                repoSize.ValueMember = "Id";
            }

            repoSizeR.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            repoSizeR.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
        }

        private async void LoadCompany()
        {
            CompanyMasterRepository companyMasterRepository = new CompanyMasterRepository();
            var companies = await companyMasterRepository.GetAllCompanyAsync();
            lueCompany.Properties.DataSource = companies;
            lueCompany.Properties.DisplayMember = "Name";
            lueCompany.Properties.ValueMember = "Id";

            lueCompany.EditValue = Common.LoginCompany;

            await GetPartyList();
            await GetBrokerList();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetThemeColors(Color color)
        {
            if (!color.ToArgb().ToString().Equals(Color.FromArgb(0).Name))
            {
                grpGroup1.AppearanceCaption.BorderColor = color;
                grpGroup2.AppearanceCaption.BorderColor = color;
                grpDocuments.AppearanceCaption.BorderColor = color;
            }
        }

        private async void FrmBoilSend_Load(object sender, EventArgs e)
        {
            dtDate.EditValue = DateTime.Now;
            dtTime.EditValue = DateTime.Now;
        }

        private static DataTable GetDTColumnsforParticularDetails()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Size");
            dt.Columns.Add("SizeR");
            dt.Columns.Add("SizeId");
            dt.Columns.Add("Carat");
            dt.Columns.Add("Rate");
            dt.Columns.Add("Amount");
            dt.Columns.Add("ReceiveSrNo");
            return dt;
        }

        private void grvParticularsDetails_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column == colSize)
                {
                    if (_RejectionType == 2)
                    {
                        grvParticularsDetails.SetRowCellValue(e.RowHandle, colSizeId, ((SizeMaster)repoSize.GetDataSourceRowByKeyValue(e.Value)).Id);
                    }
                }
                else if(e.Column == colSizeR)
                {
                    if (_RejectionType == 1)
                    {
                        grvParticularsDetails.SetRowCellValue(e.RowHandle, colSizeId, ((Repository.Entities.Model.JangadSPReceiveModel)repoSizeR.GetDataSourceRowByKeyValue(e.Value)).SizeId);
                        grvParticularsDetails.SetRowCellValue(e.RowHandle, colCarat, ((Repository.Entities.Model.JangadSPReceiveModel)repoSizeR.GetDataSourceRowByKeyValue(e.Value)).AvailableWeight);
                        grvParticularsDetails.SetRowCellValue(e.RowHandle, colRate, ((Repository.Entities.Model.JangadSPReceiveModel)repoSizeR.GetDataSourceRowByKeyValue(e.Value)).Rate);
                        grvParticularsDetails.SetRowCellValue(e.RowHandle, colAmount, ((Repository.Entities.Model.JangadSPReceiveModel)repoSizeR.GetDataSourceRowByKeyValue(e.Value)).Amount);
                        grvParticularsDetails.SetRowCellValue(e.RowHandle, colReceiveSrNo, ((Repository.Entities.Model.JangadSPReceiveModel)repoSizeR.GetDataSourceRowByKeyValue(e.Value)).SrNo);
                    }
                }
                else if (e.Column == colCarat || e.Column == colRate)
                {
                    decimal Carats = 0;
                    decimal Rate = 0;
                    if (grvParticularsDetails.GetRowCellValue(e.RowHandle, colCarat) != null &&
                        grvParticularsDetails.GetRowCellValue(e.RowHandle, colCarat).ToString().Trim().Length > 0)
                    {
                        Carats = Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(e.RowHandle, colCarat).ToString());
                    }

                    if (grvParticularsDetails.GetRowCellValue(e.RowHandle, colRate) != null &&
                        grvParticularsDetails.GetRowCellValue(e.RowHandle, colRate).ToString().Trim().Length > 0)
                    {
                        Rate = Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(e.RowHandle, colRate).ToString());
                    }

                    grvParticularsDetails.SetRowCellValue(e.RowHandle, colAmount, Carats * Rate);
                }
            }
            catch
            {

            }
        }

        private void FrmBoilSend_KeyDown(object sender, KeyEventArgs e)
        {
            Common.MoveToNextControl(sender, e, this);
        }

        private bool CheckValidation()
        {
            if (lueCompany.EditValue == null)
            {
                MessageBox.Show("Please select Receive from name", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                lueCompany.Focus();
                return false;
            }
            else if (lueParty.EditValue == null)
            {
                MessageBox.Show("Please select Send to name", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                lueParty.Focus();
                return false;
            }
            else if (grvParticularsDetails.RowCount == 0)
            {
                MessageBox.Show("Please select Particulars Details", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                grvParticularsDetails.Focus();
                return false;
            }
            return true;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (!CheckValidation())
                    return;

                bool IsSuccess = false;
                try
                {
                    string tempId = Guid.NewGuid().ToString();
                    JangadMaster jangadMaster = new JangadMaster();
                    for (int i = 0; i < grvParticularsDetails.RowCount; i++)
                    {
                        jangadMaster = new JangadMaster();
                        jangadMaster.Id = tempId;
                        jangadMaster.SrNo = Convert.ToInt32(txtSerialNo.Text);
                        jangadMaster.CompanyId = lueCompany.EditValue.ToString();
                        jangadMaster.BranchId = Common.LoginBranch;
                        jangadMaster.FinancialYearId = Common.LoginFinancialYear;
                        jangadMaster.PartyId = lueParty.EditValue.ToString();
                        jangadMaster.BrokerId = lueBroker.EditValue.ToString();

                        jangadMaster.SizeId = grvParticularsDetails.GetRowCellValue(i, colSizeId).ToString();
                        jangadMaster.Totalcts = Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(i, colCarat).ToString());
                        jangadMaster.Rate = float.Parse(grvParticularsDetails.GetRowCellValue(i, colRate).ToString());
                        jangadMaster.Amount = float.Parse(grvParticularsDetails.GetRowCellValue(i, colAmount).ToString());

                        if (Image1.Image != null)
                            jangadMaster.Image1 = ImageToByteArray(Image1.Image);
                        if (Image2.Image != null)
                            jangadMaster.Image2 = ImageToByteArray(Image2.Image);
                        if (Image3.Image != null)
                            jangadMaster.Image3 = ImageToByteArray(Image3.Image);

                        if(_RejectionType == 1)
                            jangadMaster.ReceivedSrNo = Convert.ToInt32(grvParticularsDetails.GetRowCellValue(i, colReceiveSrNo).ToString());

                        jangadMaster.Remarks = txtRemark.Text;
                        jangadMaster.EntryType = _RejectionType;
                        jangadMaster.IsDelete = false;
                        jangadMaster.CreatedDate = DateTime.Now;
                        jangadMaster.CreatedBy = Common.LoginUserID;
                        jangadMaster.UpdatedDate = DateTime.Now;
                        jangadMaster.UpdatedBy = Common.LoginUserID;
                        
                        var result = _JangadMasterRepository.AddJangadAsync(jangadMaster);
                        IsSuccess = true;
                    }
                }
                catch
                {
                    IsSuccess = false;
                }

                if (IsSuccess)
                {
                    MessageBox.Show(AppMessages.GetString(AppMessageID.SaveSuccessfully), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Utility.FrmViewJangad fvj = new Utility.FrmViewJangad(txtSerialNo.Text, Common.LoginFinancialYear, lueCompany.EditValue.ToString());
                    //fvj.ShowDialog();
                    Reset();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error : " + Ex.Message.ToString(), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }

        private async void Reset()
        {
            grdParticularsDetails.DataSource = null;
            dtDate.EditValue = DateTime.Now;
            dtTime.EditValue = DateTime.Now;
            txtRemark.Text = "";
            lueCompany.EditValue = null;
            lueParty.EditValue = null;
            lueBroker.EditValue = null;
            repoSizeR.DataSource = null;

            Image1.Image = null;
            Image2.Image = null;
            Image3.Image = null;

            await GetMaxSrNo();
            LoadCompany();

            lueCompany.Select();
            lueCompany.Focus();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void BrowseImage(int SelectedImage)
        {
            Transaction.FrmTakePicture fpc = new Transaction.FrmTakePicture();
            fpc.Image1.Image = Image1.Image;
            fpc.Image2.Image = Image2.Image;
            fpc.Image3.Image = Image3.Image;
            fpc.SelectedImage = SelectedImage;
            if (fpc.ShowDialog() == DialogResult.OK)
            {
                Image1.Image = fpc.Image1.Image;
                Image2.Image = fpc.Image2.Image;
                Image3.Image = fpc.Image3.Image;

                Image1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
                Image2.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
                Image3.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            }
        }

        private void Image1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            BrowseImage(0);
        }

        private void Image2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            BrowseImage(1);
        }

        private void Image3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            BrowseImage(2);
        }

        private void lueBroker_EditValueChanged(object sender, EventArgs e)
        {
            _ = GetSizeDetail();
        }

        private void lueCompany_EditValueChanged(object sender, EventArgs e)
        {
            _ = GetSizeDetail();
        }
    }
}
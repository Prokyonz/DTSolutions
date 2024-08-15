using DevExpress.XtraEditors;
using EFCore.SQL.Repository;
using Repository.Entities;
using Repository.Entities.Model;
using Repository.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiamondTrading.Process
{
    public partial class FrmRejectionSendReceive : DevExpress.XtraEditors.XtraForm
    {
        CompanyMasterRepository _companyMasterRepository;
        BoilMasterRepository _boilMasterRepository;
        PartyMasterRepository _partyMasterRepository;
        RejectionInOutMasterRepository _rejectionInOutMasterRepository;
        List<RejectionSendReceiveSPModel> ListRejectionSendReceiveSPModel;
        int _RejectionType = 0;

        public FrmRejectionSendReceive(int RejectionType)
        {
            InitializeComponent();
            _companyMasterRepository = new CompanyMasterRepository();

            _boilMasterRepository = new BoilMasterRepository();
            _partyMasterRepository = new PartyMasterRepository();
            _rejectionInOutMasterRepository = new RejectionInOutMasterRepository();

            _RejectionType = RejectionType;

            LoadCompany();

            if (RejectionType == 1)
            {
                SetThemeColors(Color.FromArgb(250, 243, 197));
                this.Text = "REJECTION RECEIVE";
            }
            else if (RejectionType == 2)
            {
                SetThemeColors(Color.FromArgb(215, 246, 214));
                this.Text = "REJECTION SEND";
            }
        }

        private async void LoadCompany()
        {
            var data = await _companyMasterRepository.GetUserCompanyMappingAsync(Common.LoginUserID);

            lueCompany.Properties.DataSource = data;
            lueCompany.Properties.DisplayMember = "Name";
            lueCompany.Properties.ValueMember = "Id";

            lueCompany.EditValue = Common.LoginCompany;
        }

        private async Task LoadParty()
        {
            string companyId = Common.LoginCompany;
            if (lueCompany.EditValue != null)
            {
                if (lueCompany.EditValue.ToString() != Common.LoginCompany)
                    companyId = lueCompany.EditValue.ToString();
            }

            if (_RejectionType == 2)
            {
                var PartyDetailList = await _partyMasterRepository.GetAllPartyAsync(companyId, PartyTypeMaster.PartyBuy);
                lueParty.Properties.DataSource = PartyDetailList;
                lueParty.Properties.DisplayMember = "Name";
                lueParty.Properties.ValueMember = "Id";
            }
            else
            {
                var PartyDetailList = await _partyMasterRepository.GetAllPartyAsync(companyId, PartyTypeMaster.PartySale);
                lueParty.Properties.DataSource = PartyDetailList;
                lueParty.Properties.DisplayMember = "Name";
                lueParty.Properties.ValueMember = "Id";
            }
        }

        private async Task GetBrokerList()
        {
            string companyId = Common.LoginCompany;
            if (lueCompany.EditValue != null)
            {
                if (lueCompany.EditValue.ToString() != Common.LoginCompany)
                    companyId = lueCompany.EditValue.ToString();
            }
            var BrokerDetailList = await _partyMasterRepository.GetAllPartyAsync(companyId, PartyTypeMaster.Employee, new int[] { PartyTypeMaster.Broker });
            lueBroker.Properties.DataSource = BrokerDetailList;
            lueBroker.Properties.DisplayMember = "Name";
            lueBroker.Properties.ValueMember = "Id";
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
            timer1.Start();

            //SetThemeColors(Color.FromArgb(250, 243, 197));

            await GetMaxSrNo();
            await LoadParty();
            await GetBrokerList();
            grdParticularsDetails.DataSource = GetDTColumnsforParticularDetails();

            await GetRejectionData();
        }

        private async Task GetRejectionData()
        {
            ListRejectionSendReceiveSPModel = await _rejectionInOutMasterRepository.GetRejectionSendReceiveDetail(lueCompany.EditValue.ToString(), Common.LoginFinancialYear, _RejectionType);
            var SlipNos = ListRejectionSendReceiveSPModel.Select(x => new { x.SlipNo }).Distinct().OrderBy(x => Convert.ToInt32(x.SlipNo)).ToList();
            lueSlipNo.Properties.DataSource = SlipNos;
            lueSlipNo.Properties.DisplayMember = "SlipNo";
            lueSlipNo.Properties.ValueMember = "SlipNo";
        }

        private async Task GetMaxSrNo()
        {
            var SrNo = await _rejectionInOutMasterRepository.GetMaxSrNoAsync(Common.LoginCompany.ToString(), Common.LoginFinancialYear, _RejectionType);
            txtSerialNo.Text = SrNo.ToString();
        }

        private static DataTable GetDTColumnsforParticularDetails()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("SlipNo");
            dt.Columns.Add("Size");
            dt.Columns.Add("Available");
            dt.Columns.Add("Carat");
            dt.Columns.Add("SizeId");
            dt.Columns.Add("ShapeId");
            dt.Columns.Add("PurityId");
            dt.Columns.Add("KapanId");
            dt.Columns.Add("Rate");
            dt.Columns.Add("Amount");
            dt.Columns.Add("SlipNo1");
            dt.Columns.Add("ProcessType");
            dt.Columns.Add("LessWeight");
            dt.Columns.Add("NumberId");
            dt.Columns.Add("CharniSizeId");
            dt.Columns.Add("PurchaseSaleDetailsId");
            return dt;
        }

        private async void lueKapan_EditValueChanged(object sender, EventArgs e)
        {
            if (lueSlipNo.EditValue != null)
            {
                var SelectedSlips = ListRejectionSendReceiveSPModel?.Where(x => x.SlipNo.ToString() == lueSlipNo.EditValue.ToString()).ToList();
                repoSlipNo.DataSource = SelectedSlips;
                repoSlipNo.DisplayMember = "SlipNo";
                repoSlipNo.ValueMember = "Id";

                repoSlipNo.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                repoSlipNo.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;

                lueParty.EditValue = SelectedSlips.FirstOrDefault().PartyId;
                lueBroker.EditValue = SelectedSlips.FirstOrDefault().BrokerageId;
            }
        }

        private void grvParticularsDetails_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column == colSlipNo)
                {
                    grvParticularsDetails.SetRowCellValue(e.RowHandle, colACarat, ((Repository.Entities.Model.RejectionSendReceiveSPModel)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).Available);
                    grvParticularsDetails.SetRowCellValue(e.RowHandle, colSizeId, ((Repository.Entities.Model.RejectionSendReceiveSPModel)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).SizeId);
                    grvParticularsDetails.SetRowCellValue(e.RowHandle, colShapeId, ((Repository.Entities.Model.RejectionSendReceiveSPModel)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).ShapeId);
                    grvParticularsDetails.SetRowCellValue(e.RowHandle, colPurityId, ((Repository.Entities.Model.RejectionSendReceiveSPModel)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).PurityId);
                    grvParticularsDetails.SetRowCellValue(e.RowHandle, colSlipNo1, ((Repository.Entities.Model.RejectionSendReceiveSPModel)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).SlipNo);
                    grvParticularsDetails.SetRowCellValue(e.RowHandle, colkapanId, ((Repository.Entities.Model.RejectionSendReceiveSPModel)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).KapanId);
                    grvParticularsDetails.SetRowCellValue(e.RowHandle, colRate, ((Repository.Entities.Model.RejectionSendReceiveSPModel)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).Rate);
                    grvParticularsDetails.SetRowCellValue(e.RowHandle, colProcessType, ((Repository.Entities.Model.RejectionSendReceiveSPModel)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).ProcessType);
                    grvParticularsDetails.SetRowCellValue(e.RowHandle, colNumberId, ((Repository.Entities.Model.RejectionSendReceiveSPModel)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).NumberId);
                    grvParticularsDetails.SetRowCellValue(e.RowHandle, colCharniSizeId, ((Repository.Entities.Model.RejectionSendReceiveSPModel)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).CharniSizeId);
                    grvParticularsDetails.SetRowCellValue(e.RowHandle, colPurchaseSaleDetailsId, ((Repository.Entities.Model.RejectionSendReceiveSPModel)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).PurchaseSaleDetailsId);
                    //grvPurchaseItems.FocusedRowHandle = e.RowHandle;
                    //grvPurchaseItems.FocusedColumn = colBoilCarat;
                }
                else if (e.Column == colCarat || e.Column == colLessWeight || e.Column == colRate)
                {
                    decimal AvailableCarat = Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(e.RowHandle, colACarat).ToString());
                    decimal Carat = 0;
                    if (!string.IsNullOrWhiteSpace(grvParticularsDetails.GetRowCellValue(e.RowHandle, colCarat).ToString()))
                        Carat = Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(e.RowHandle, colCarat).ToString());

                    if(Carat > AvailableCarat)
                    {
                        MessageBox.Show("Sorry, You can send/receive rejection max to "+AvailableCarat+".", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        grvParticularsDetails.SetRowCellValue(e.RowHandle, colCarat, 0);
                        return;
                    }

                    decimal Rate = 0;
                    if(!string.IsNullOrWhiteSpace(grvParticularsDetails.GetRowCellValue(e.RowHandle, colRate).ToString()))
                        Rate = Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(e.RowHandle, colRate).ToString());
                    //decimal LessCarat = 0;
                    //if (!string.IsNullOrWhiteSpace(grvParticularsDetails.GetRowCellValue(e.RowHandle, colLessWeight).ToString()))
                    //    LessCarat = Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(e.RowHandle, colLessWeight).ToString());

                    decimal FinalAmount = (Carat * Rate);
                    decimal LessPer = Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(e.RowHandle, colLessWeight));
                    if (LessPer < 0)
                        LessPer *= -1;
                    decimal LessAmt = (FinalAmount * LessPer) / 100;
                    FinalAmount -= LessAmt;

                    grvParticularsDetails.SetRowCellValue(e.RowHandle, colAmount, FinalAmount);
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
            if (lueSlipNo.EditValue == null)
            {
                MessageBox.Show("Please select Kapan", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                lueSlipNo.Focus();
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
                    string RejectionInOutId = string.Empty;
                    RejectionInOutMaster rejectionInOutMaster = new RejectionInOutMaster();
                    for (int i = 0; i < grvParticularsDetails.RowCount; i++)
                    {
                        RejectionInOutId = Guid.NewGuid().ToString();
                        rejectionInOutMaster = new RejectionInOutMaster();
                        rejectionInOutMaster.Id = RejectionInOutId;
                        rejectionInOutMaster.SrNo = Convert.ToInt32(txtSerialNo.Text);
                        rejectionInOutMaster.CompanyId = lueCompany.EditValue.ToString();
                        rejectionInOutMaster.BranchId = Common.LoginBranch;
                        rejectionInOutMaster.EntryDate = Convert.ToDateTime(dtDate.Text).ToString("yyyyMMdd");
                        rejectionInOutMaster.PartyId = lueParty.EditValue.ToString();
                        rejectionInOutMaster.BrokerageId = lueBroker.EditValue.ToString();
                        rejectionInOutMaster.FinancialYearId = Common.LoginFinancialYear;
                        rejectionInOutMaster.TransType = _RejectionType; //send/Boil/Charni/Gala/Number receive-2 or receive/Sales-1
                        rejectionInOutMaster.SlipNo = lueSlipNo.EditValue.ToString();
                        rejectionInOutMaster.SizeId = grvParticularsDetails.GetRowCellValue(i, colSizeId).ToString();
                        rejectionInOutMaster.PurityId = grvParticularsDetails.GetRowCellValue(i, colPurityId).ToString();
                        rejectionInOutMaster.CharniSizeId = grvParticularsDetails.GetRowCellValue(i, colCharniSizeId).ToString();
                        rejectionInOutMaster.GalaSizeId = "";
                        rejectionInOutMaster.NumberSizeId = grvParticularsDetails.GetRowCellValue(i, colNumberId).ToString();
                        rejectionInOutMaster.TableName = ""; //Boil/Charni/Gala/Number
                        rejectionInOutMaster.TableEntryID = "";
                        rejectionInOutMaster.Rate = float.Parse(grvParticularsDetails.GetRowCellValue(i, colRate).ToString());
                        rejectionInOutMaster.TotalCarat = Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(i, colCarat).ToString());
                        rejectionInOutMaster.Amount = Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(i, colAmount).ToString());
                        rejectionInOutMaster.Remarks = txtRemark.Text;
                        rejectionInOutMaster.CreatedDate = DateTime.Now;
                        rejectionInOutMaster.CreatedBy = Common.LoginUserID;
                        rejectionInOutMaster.UpdatedDate = DateTime.Now;
                        rejectionInOutMaster.UpdatedBy = Common.LoginUserID;
                        rejectionInOutMaster.ProcessType = grvParticularsDetails.GetRowCellValue(i, colProcessType).ToString();
                        rejectionInOutMaster.KapanId = grvParticularsDetails.GetRowCellValue(i, colkapanId).ToString();
                        rejectionInOutMaster.LessWeight = Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(i, colLessWeight).ToString());
                        rejectionInOutMaster.PurchaseSaleDetailsId = grvParticularsDetails.GetRowCellValue(i, colPurchaseSaleDetailsId).ToString();

                        var Result = await _rejectionInOutMasterRepository.AddRejectionAsync(rejectionInOutMaster);
                        IsSuccess = true;
                    }
                }
                catch
                {
                    IsSuccess = false;
                }

                if (IsSuccess)
                {
                    Reset();
                    MessageBox.Show(AppMessages.GetString(AppMessageID.SaveSuccessfully), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private async void Reset()
        {
            grdParticularsDetails.DataSource = null;
            await GetRejectionData();
            dtDate.EditValue = DateTime.Now;
            dtTime.EditValue = DateTime.Now;
            txtRemark.Text = "";
            //lueCompany.EditValue = null;
            lueParty.EditValue = null;
            lueSlipNo.EditValue = null;
            lueBroker.EditValue = null;
            repoSlipNo.DataSource = null;

            await GetMaxSrNo();
            await LoadParty();
            await GetBrokerList();
            grdParticularsDetails.DataSource = GetDTColumnsforParticularDetails();

            lueCompany.Select();
            lueCompany.Focus();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private async void lueParty_EditValueChanged(object sender, EventArgs e)
        {
            if (lueParty.EditValue == null)
                return;

            string companyId = Common.LoginCompany;
            if (lueCompany.EditValue != null)
            {
                if (lueCompany.EditValue.ToString() != Common.LoginCompany)
                    companyId = lueCompany.EditValue.ToString();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dtTime.EditValue = DateTime.Now;
        }
    }
}
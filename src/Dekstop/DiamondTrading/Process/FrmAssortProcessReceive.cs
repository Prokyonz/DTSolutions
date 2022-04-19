using DevExpress.XtraEditors;
using EFCore.SQL.Repository;
using Repository.Entities;
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
    public partial class FrmAssortProcessReceive : DevExpress.XtraEditors.XtraForm
    {
        AccountToAssortMasterRepository _accountToAssortMasterRepository;
        PartyMasterRepository _partyMasterRepository;
        List<CharniProcessSend> ListCharniProcessSend;
        List<GalaProcessSend> ListGalaProcessSend;
        List<NumberProcessSend> ListNumberProcessSend;
        List<NumberProcessReturn> ListNumberProcessReturn;

        public FrmAssortProcessReceive()
        {
            InitializeComponent();
            _accountToAssortMasterRepository = new AccountToAssortMasterRepository();
            _partyMasterRepository = new PartyMasterRepository();
        }

        private void SetThemeColors(Color color)
        {
            if (!color.ToArgb().ToString().Equals(Color.FromArgb(0).Name))
            {
                grpGroup1.AppearanceCaption.BorderColor = color;
                grpGroup2.AppearanceCaption.BorderColor = color;
            }
        }

        private async void FrmAssortProcessSend_Load(object sender, EventArgs e)
        {
            dtDate.EditValue = DateTime.Now;
            dtTime.EditValue = DateTime.Now;

            SetThemeColors(Color.FromArgb(215, 246, 214));

            await GetMaxSrNo();
            GetDepartmentList();
            await GetEmployeeList();
            await GetKapanDetail();
        }

        private void GetDepartmentList()
        {
            var Department = DepartmentMaster1.GetAllDepartment();

            if (Department != null)
            {
                lueDepartment.Properties.DataSource = Department;
                lueDepartment.Properties.DisplayMember = "Name";
                lueDepartment.Properties.ValueMember = "Id";
            }
        }

        private async Task GetMaxSrNo()
        {
            if (lueDepartment.EditValue != null)
            {
                if (Convert.ToInt32(lueDepartment.EditValue) == DepartmentMaster1.Boil)
                {
                    BoilMasterRepository boilMasterRepository = new BoilMasterRepository();
                    var SrNo = await boilMasterRepository.GetMaxSrNoAsync(Common.LoginCompany.ToString(), Common.LoginBranch.ToString(), Common.LoginFinancialYear, 2);
                    txtSerialNo.Text = SrNo.ToString();
                }
                else if (Convert.ToInt32(lueDepartment.EditValue) == DepartmentMaster1.Charni)
                {
                    CharniProcessMasterRepository charniProcessMasterRepository = new CharniProcessMasterRepository();
                    var SrNo = await charniProcessMasterRepository.GetMaxSrNoAsync(Common.LoginCompany.ToString(), Common.LoginBranch.ToString(), Common.LoginFinancialYear, 2);
                    txtSerialNo.Text = SrNo.ToString();
                }
                else if (Convert.ToInt32(lueDepartment.EditValue) == DepartmentMaster1.Gala)
                {
                    GalaProcessMasterRepository galaProcessMasterRepository = new GalaProcessMasterRepository();
                    var SrNo = await galaProcessMasterRepository.GetMaxSrNoAsync(Common.LoginCompany.ToString(), Common.LoginBranch.ToString(), Common.LoginFinancialYear, 2);
                    txtSerialNo.Text = SrNo.ToString();
                }
                else if (Convert.ToInt32(lueDepartment.EditValue) == DepartmentMaster1.Number)
                {
                    NumberProcessMasterRepository numberProcessMasterRepository = new NumberProcessMasterRepository();
                    var SrNo = await numberProcessMasterRepository.GetMaxSrNoAsync(Common.LoginCompany.ToString(), Common.LoginBranch.ToString(), Common.LoginFinancialYear, 2);
                    txtSerialNo.Text = SrNo.ToString();
                }
            }
            //var SrNo = await _accountToAssortMasterRepository.GetMaxSrNoAsync(Common.LoginCompany.ToString(), Common.LoginBranch.ToString(), Common.LoginFinancialYear);
            //txtSerialNo.Text = SrNo.ToString();
        }

        private async Task GetEmployeeList()
        {
            var EmployeeDetailList = await _partyMasterRepository.GetAllPartyAsync(Common.LoginCompany.ToString(), PartyTypeMaster.Employee, PartyTypeMaster.Other);
            lueReceiveFrom.Properties.DataSource = EmployeeDetailList;
            lueReceiveFrom.Properties.DisplayMember = "Name";
            lueReceiveFrom.Properties.ValueMember = "Id";

            lueSendto.Properties.DataSource = EmployeeDetailList;
            lueSendto.Properties.DisplayMember = "Name";
            lueSendto.Properties.ValueMember = "Id";
        }

        private async Task GetKapanDetail()
        {
            KapanMasterRepository kapanMasterRepository = new KapanMasterRepository();
            var kapanMaster = await kapanMasterRepository.GetAllKapanAsync();
            lueKapan.Properties.DataSource = kapanMaster;
            lueKapan.Properties.DisplayMember = "Name";
            lueKapan.Properties.ValueMember = "Id";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void lueDepartment_EditValueChanged(object sender, EventArgs e)
        {
            if (lueDepartment.EditValue != null)
            {
                colRate.Visible = false;
                colAmount.Visible = false;

                if (Convert.ToInt32(lueDepartment.EditValue) == DepartmentMaster1.Boil)
                {
                    await GetMaxSrNo();
                    await GetBoilProcessReceivedDetail();
                    repoSlipNo.Columns["BoilNo"].Visible = true;
                    repoSlipNo.Columns["CharniSize"].Visible = false;
                    repoSlipNo.Columns["GalaNumber"].Visible = false;
                    repoSlipNo.Columns["Number"].Visible = false;
                    colCharniSize.Visible = false;
                    colGalaSize.Visible = false;
                    colNumberSize.Visible = false;
                }
                else if (Convert.ToInt32(lueDepartment.EditValue) == DepartmentMaster1.Charni)
                {
                    await GetMaxSrNo();
                    await GetCharniProcessReceiveDetail();
                    repoSlipNo.Columns["BoilNo"].Visible = false;
                    repoSlipNo.Columns["CharniSize"].Visible = true;
                    repoSlipNo.Columns["GalaNumber"].Visible = false;
                    repoSlipNo.Columns["Number"].Visible = false;
                    colCharniSize.Visible = true;
                    colGalaSize.Visible = false;
                    colNumberSize.Visible = false;
                }
                else if (Convert.ToInt32(lueDepartment.EditValue) == DepartmentMaster1.Gala)
                {
                    await GetMaxSrNo();
                    await GetGalaProcessReceiveDetail();
                    repoSlipNo.Columns["BoilNo"].Visible = false;
                    repoSlipNo.Columns["CharniSize"].Visible = true;
                    repoSlipNo.Columns["GalaNumber"].Visible = true;
                    repoSlipNo.Columns["Number"].Visible = false;
                    colCharniSize.Visible = true;
                    colGalaSize.Visible = true;
                    colNumberSize.Visible = false;
                }
                else if (Convert.ToInt32(lueDepartment.EditValue) == DepartmentMaster1.Number)
                {
                    await GetMaxSrNo();
                    await GetNumberProcessReceiveDetail();
                    repoSlipNo.Columns["BoilNo"].Visible = false;
                    repoSlipNo.Columns["CharniSize"].Visible = true;
                    repoSlipNo.Columns["GalaNumber"].Visible = false;
                    repoSlipNo.Columns["Number"].Visible = true;
                    colCharniSize.Visible = true;
                    colGalaSize.Visible = false;
                    colRate.Visible = true;
                    colAmount.Visible = true;
                }
                repoSlipNo.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                repoSlipNo.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
            }
        }

        private async Task GetBoilProcessReceivedDetail()
        {
            CharniProcessMasterRepository charniProcessMasterRepository = new CharniProcessMasterRepository();
            grdParticularsDetails.DataSource = GetDTColumnsforParticularDetails();
            ListCharniProcessSend = await charniProcessMasterRepository.GetCharniSendToDetails(Common.LoginCompany.ToString(), Common.LoginBranch.ToString(), Common.LoginFinancialYear.ToString());

            lueKapan.Properties.DataSource = ListCharniProcessSend.Select(x => new { x.KapanId, x.Kapan }).Distinct().ToList();
            lueKapan.Properties.DisplayMember = "Kapan";
            lueKapan.Properties.ValueMember = "KapanId";
        }

        private async Task GetCharniProcessReceiveDetail()
        {
            GalaProcessMasterRepository galaProcessMasterRepository = new GalaProcessMasterRepository();
            grdParticularsDetails.DataSource = GetDTColumnsforParticularDetails();
            ListGalaProcessSend = await galaProcessMasterRepository.GetGalaSendToDetails(Common.LoginCompany.ToString(), Common.LoginBranch.ToString(), Common.LoginFinancialYear.ToString());

            lueKapan.Properties.DataSource = ListGalaProcessSend.Select(x => new { x.KapanId, x.Kapan }).Distinct().ToList();
            lueKapan.Properties.DisplayMember = "Kapan";
            lueKapan.Properties.ValueMember = "KapanId";
        }

        private async Task GetGalaProcessReceiveDetail()
        {
            NumberProcessMasterRepository numberProcessMasterRepository = new NumberProcessMasterRepository();
            grdParticularsDetails.DataSource = GetDTColumnsforParticularDetails();
            ListNumberProcessSend = await numberProcessMasterRepository.GetNumberSendToDetails(Common.LoginCompany.ToString(), Common.LoginBranch.ToString(), Common.LoginFinancialYear.ToString());

            lueKapan.Properties.DataSource = ListNumberProcessSend.Select(x => new { x.KapanId, x.Kapan }).Distinct().ToList();
            lueKapan.Properties.DisplayMember = "Kapan";
            lueKapan.Properties.ValueMember = "KapanId";
        }

        private async Task GetNumberProcessReceiveDetail()
        {
            NumberProcessMasterRepository numberProcessMasterRepository = new NumberProcessMasterRepository();
            grdParticularsDetails.DataSource = GetDTColumnsforParticularDetails();
            ListNumberProcessReturn = await numberProcessMasterRepository.GetNumberReturnDetails(Common.LoginCompany.ToString(), Common.LoginBranch.ToString(), Common.LoginFinancialYear.ToString());

            lueKapan.Properties.DataSource = ListNumberProcessReturn.Select(x => new { x.KapanId, x.Kapan }).Distinct().ToList();
            lueKapan.Properties.DisplayMember = "Kapan";
            lueKapan.Properties.ValueMember = "KapanId";
        }

        private static DataTable GetDTColumnsforParticularDetails()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("BoilNo");
            dt.Columns.Add("SlipNo");
            dt.Columns.Add("Size");
            dt.Columns.Add("AvailableWeight");
            dt.Columns.Add("CharniCarat");
            dt.Columns.Add("SizeId");
            dt.Columns.Add("ShapeId");
            dt.Columns.Add("PurityId");
            dt.Columns.Add("BoilNo1");

            dt.Columns.Add("GalaCarat");
            dt.Columns.Add("SlipNo1");
            dt.Columns.Add("CharniSize");
            dt.Columns.Add("CharniSizeId");
            dt.Columns.Add("GalaSize");
            dt.Columns.Add("GalaNumberId");
            dt.Columns.Add("Number");
            dt.Columns.Add("NumberId");

            dt.Columns.Add("Rate");
            dt.Columns.Add("Amount");
            return dt;
        }

        private void lueKapan_EditValueChanged(object sender, EventArgs e)
        {
            if (lueDepartment.EditValue != null)
            {
                if (Convert.ToInt32(lueDepartment.EditValue) == DepartmentMaster1.Boil && ListCharniProcessSend != null)
                {
                    repoSlipNo.DataSource = ListCharniProcessSend.Where(x => x.KapanId == lueKapan.EditValue.ToString()).ToList();
                    repoSlipNo.DisplayMember = "BoilNo";
                    repoSlipNo.ValueMember = "Id";

                    repoSlipNo.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                    repoSlipNo.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
                }
                else if (Convert.ToInt32(lueDepartment.EditValue) == DepartmentMaster1.Charni && ListGalaProcessSend != null)
                {
                    repoSlipNo.DataSource = ListGalaProcessSend.Where(x => x.KapanId == lueKapan.EditValue.ToString()).ToList();
                    repoSlipNo.DisplayMember = "SlipNo";
                    repoSlipNo.ValueMember = "Id";

                    repoSlipNo.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                    repoSlipNo.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
                }
                else if (Convert.ToInt32(lueDepartment.EditValue) == DepartmentMaster1.Gala && ListNumberProcessSend != null)
                {
                    repoSlipNo.DataSource = ListNumberProcessSend.Where(x => x.KapanId == lueKapan.EditValue.ToString()).ToList();
                    repoSlipNo.DisplayMember = "SlipNo";
                    repoSlipNo.ValueMember = "Id";

                    repoSlipNo.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                    repoSlipNo.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
                }
                else if (Convert.ToInt32(lueDepartment.EditValue) == DepartmentMaster1.Number && ListNumberProcessReturn != null)
                {
                    repoSlipNo.DataSource = ListNumberProcessReturn.Where(x => x.KapanId == lueKapan.EditValue.ToString()).ToList();
                    repoSlipNo.DisplayMember = "SlipNo";
                    repoSlipNo.ValueMember = "Id";

                    repoSlipNo.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                    repoSlipNo.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
                }
            }
        }

        private void grvParticularsDetails_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column == colSrNo)

                {
                    if (lueDepartment.EditValue != null)
                    {
                        if (Convert.ToInt32(lueDepartment.EditValue) == DepartmentMaster1.Boil)
                        {
                            grvParticularsDetails.SetRowCellValue(e.RowHandle, colSlipNo, ((Repository.Entities.Models.CharniProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).SlipNo);
                            grvParticularsDetails.SetRowCellValue(e.RowHandle, colSize, ((Repository.Entities.Models.CharniProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).Size);
                            grvParticularsDetails.SetRowCellValue(e.RowHandle, colACarat, ((Repository.Entities.Models.CharniProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).AvailableWeight);
                            grvParticularsDetails.SetRowCellValue(e.RowHandle, colSizeId, ((Repository.Entities.Models.CharniProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).SizeId);
                            grvParticularsDetails.SetRowCellValue(e.RowHandle, colShapeId, ((Repository.Entities.Models.CharniProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).ShapeId);
                            grvParticularsDetails.SetRowCellValue(e.RowHandle, colPurityId, ((Repository.Entities.Models.CharniProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).PurityId);
                            grvParticularsDetails.SetRowCellValue(e.RowHandle, colBoilNo1, ((Repository.Entities.Models.CharniProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).BoilNo);
                        }
                        else if (Convert.ToInt32(lueDepartment.EditValue) == DepartmentMaster1.Charni)
                        {
                            grvParticularsDetails.SetRowCellValue(e.RowHandle, colSlipNo1, ((Repository.Entities.Models.GalaProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).SlipNo);
                            grvParticularsDetails.SetRowCellValue(e.RowHandle, colSlipNo, ((Repository.Entities.Models.GalaProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).SlipNo);
                            grvParticularsDetails.SetRowCellValue(e.RowHandle, colSize, ((Repository.Entities.Models.GalaProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).Size);
                            grvParticularsDetails.SetRowCellValue(e.RowHandle, colACarat, ((Repository.Entities.Models.GalaProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).AvailableWeight);
                            grvParticularsDetails.SetRowCellValue(e.RowHandle, colSizeId, ((Repository.Entities.Models.GalaProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).SizeId);
                            grvParticularsDetails.SetRowCellValue(e.RowHandle, colShapeId, ((Repository.Entities.Models.GalaProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).ShapeId);
                            grvParticularsDetails.SetRowCellValue(e.RowHandle, colPurityId, ((Repository.Entities.Models.GalaProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).PurityId);
                            grvParticularsDetails.SetRowCellValue(e.RowHandle, colCharniSize, ((Repository.Entities.Models.GalaProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).CharniSize);
                            grvParticularsDetails.SetRowCellValue(e.RowHandle, colCharniSizeId, ((Repository.Entities.Models.GalaProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).CharniSizeId);
                        }
                        else if (Convert.ToInt32(lueDepartment.EditValue) == DepartmentMaster1.Gala)
                        {
                            grvParticularsDetails.SetRowCellValue(e.RowHandle, colSlipNo1, ((Repository.Entities.Models.NumberProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).SlipNo);
                            grvParticularsDetails.SetRowCellValue(e.RowHandle, colSlipNo, ((Repository.Entities.Models.NumberProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).SlipNo);
                            grvParticularsDetails.SetRowCellValue(e.RowHandle, colSize, ((Repository.Entities.Models.NumberProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).Size);
                            grvParticularsDetails.SetRowCellValue(e.RowHandle, colACarat, ((Repository.Entities.Models.NumberProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).AvailableWeight);
                            grvParticularsDetails.SetRowCellValue(e.RowHandle, colSizeId, ((Repository.Entities.Models.NumberProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).SizeId);
                            grvParticularsDetails.SetRowCellValue(e.RowHandle, colShapeId, ((Repository.Entities.Models.NumberProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).ShapeId);
                            grvParticularsDetails.SetRowCellValue(e.RowHandle, colPurityId, ((Repository.Entities.Models.NumberProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).PurityId);
                            grvParticularsDetails.SetRowCellValue(e.RowHandle, colCharniSize, ((Repository.Entities.Models.NumberProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).CharniSize);
                            grvParticularsDetails.SetRowCellValue(e.RowHandle, colCharniSizeId, ((Repository.Entities.Models.NumberProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).CharniSizeId);
                            grvParticularsDetails.SetRowCellValue(e.RowHandle, colGalaNumberId, ((Repository.Entities.Models.NumberProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).GalaNumberId);
                            grvParticularsDetails.SetRowCellValue(e.RowHandle, colGalaSize, ((Repository.Entities.Models.NumberProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).GalaNumber);
                        }
                        else if (Convert.ToInt32(lueDepartment.EditValue) == DepartmentMaster1.Number)
                        {
                            grvParticularsDetails.SetRowCellValue(e.RowHandle, colSlipNo1, ((Repository.Entities.Models.NumberProcessReturn)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).SlipNo);
                            grvParticularsDetails.SetRowCellValue(e.RowHandle, colSlipNo, ((Repository.Entities.Models.NumberProcessReturn)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).SlipNo);
                            grvParticularsDetails.SetRowCellValue(e.RowHandle, colSize, ((Repository.Entities.Models.NumberProcessReturn)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).Size);
                            grvParticularsDetails.SetRowCellValue(e.RowHandle, colACarat, ((Repository.Entities.Models.NumberProcessReturn)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).AvailableWeight);
                            grvParticularsDetails.SetRowCellValue(e.RowHandle, colSizeId, ((Repository.Entities.Models.NumberProcessReturn)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).SizeId);
                            grvParticularsDetails.SetRowCellValue(e.RowHandle, colShapeId, ((Repository.Entities.Models.NumberProcessReturn)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).ShapeId);
                            grvParticularsDetails.SetRowCellValue(e.RowHandle, colPurityId, ((Repository.Entities.Models.NumberProcessReturn)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).PurityId);
                            grvParticularsDetails.SetRowCellValue(e.RowHandle, colCharniSize, ((Repository.Entities.Models.NumberProcessReturn)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).CharniSize);
                            grvParticularsDetails.SetRowCellValue(e.RowHandle, colCharniSizeId, ((Repository.Entities.Models.NumberProcessReturn)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).CharniSizeId);
                            grvParticularsDetails.SetRowCellValue(e.RowHandle, colNumberId, ((Repository.Entities.Models.NumberProcessReturn)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).NumberId);
                            grvParticularsDetails.SetRowCellValue(e.RowHandle, colNumberSize, ((Repository.Entities.Models.NumberProcessReturn)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).Number);
                        }
                        //grvPurchaseItems.FocusedRowHandle = e.RowHandle;
                        //grvPurchaseItems.FocusedColumn = colBoilCarat;
                    }
                }
                else if (e.Column == colCharniCarat || e.Column == colRate)
                {
                    decimal Receivedcts = 0;
                    decimal Rate = 0;
                    if (grvParticularsDetails.GetRowCellValue(e.RowHandle, colCharniCarat).ToString().Trim().Length > 0)
                    {
                        Receivedcts = Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(e.RowHandle, colCharniCarat).ToString());
                    }

                    if (grvParticularsDetails.GetRowCellValue(e.RowHandle, colRate).ToString().Trim().Length > 0)
                    {
                        Rate = Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(e.RowHandle, colRate).ToString());
                    }

                    grvParticularsDetails.SetRowCellValue(e.RowHandle, colAmount, Receivedcts * Rate);
                }
            }
            catch
            {

            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (!CheckValidation())
                    return;

                if (lueDepartment.EditValue != null)
                {
                    if (Convert.ToInt32(lueDepartment.EditValue) == DepartmentMaster1.Boil)
                    {
                        string Cts = "0";

                        BoilMasterRepository boilMasterRepository = new BoilMasterRepository();
                        BoilProcessMaster boilProcessMaster = new BoilProcessMaster();
                        bool IsSuccess = false;
                        try
                        {
                            for (int i = 0; i < grvParticularsDetails.RowCount; i++)
                            {
                                Cts = grvParticularsDetails.GetRowCellValue(i, colCharniCarat).ToString();
                                boilProcessMaster = new BoilProcessMaster();
                                boilProcessMaster.Id = Guid.NewGuid().ToString();
                                boilProcessMaster.BoilNo = Convert.ToInt32(grvParticularsDetails.GetRowCellValue(i, colBoilNo1));
                                boilProcessMaster.JangadNo = Convert.ToInt32(txtSerialNo.Text);
                                boilProcessMaster.CompanyId = Common.LoginCompany;
                                boilProcessMaster.BranchId = Common.LoginBranch;
                                boilProcessMaster.EntryDate = Convert.ToDateTime(dtDate.Text).ToString("yyyyMMdd");
                                boilProcessMaster.EntryTime = Convert.ToDateTime(dtTime.Text).ToString("hh:mm:ss ttt");
                                boilProcessMaster.FinancialYearId = Common.LoginFinancialYear;
                                boilProcessMaster.BoilType = Convert.ToInt32(ProcessType.Return);
                                boilProcessMaster.KapanId = lueKapan.EditValue.ToString();
                                boilProcessMaster.ShapeId = grvParticularsDetails.GetRowCellValue(i, colShapeId).ToString();
                                boilProcessMaster.SizeId = grvParticularsDetails.GetRowCellValue(i, colSizeId).ToString();
                                boilProcessMaster.PurityId = grvParticularsDetails.GetRowCellValue(i, colPurityId).ToString();
                                boilProcessMaster.Weight = Convert.ToDecimal(Cts);
                                boilProcessMaster.LossWeight = 0;
                                boilProcessMaster.RejectionWeight = 0;
                                boilProcessMaster.HandOverById = lueReceiveFrom.EditValue.ToString();
                                boilProcessMaster.HandOverToId = lueSendto.EditValue.ToString();
                                boilProcessMaster.SlipNo = grvParticularsDetails.GetRowCellValue(i, colSlipNo).ToString();
                                //boilProcessMaster.BoilCategoy = Convert.ToInt32(grvParticularsDetails.GetRowCellValue(i, colCategory));
                                boilProcessMaster.Remarks = txtRemark.Text;
                                boilProcessMaster.IsDelete = false;
                                boilProcessMaster.CreatedDate = DateTime.Now;
                                boilProcessMaster.CreatedBy = Common.LoginUserID;
                                boilProcessMaster.UpdatedDate = DateTime.Now;
                                boilProcessMaster.UpdatedBy = Common.LoginUserID;

                                //boilProcessMaster.TransferCaratRate = Convert.ToDouble(grvParticularsDetails.GetRowCellValue(i, colRate).ToString());
                                var Result = await boilMasterRepository.AddBoilAsync(boilProcessMaster);
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
                    else if (Convert.ToInt32(lueDepartment.EditValue) == DepartmentMaster1.Charni)
                    {
                        string Cts = "0";

                        CharniProcessMasterRepository charniProcessMasterRepository = new CharniProcessMasterRepository();
                        CharniProcessMaster charniProcessMaster = new CharniProcessMaster();
                        bool IsSuccess = false;
                        try
                        {
                            for (int i = 0; i < grvParticularsDetails.RowCount; i++)
                            {
                                Cts = "0";
                                Cts = grvParticularsDetails.GetRowCellValue(i, colCharniCarat).ToString();
                                charniProcessMaster = new CharniProcessMaster();
                                charniProcessMaster.Id = Guid.NewGuid().ToString();
                                //charniProcessMaster.CharniNo = Convert.ToInt32(lueKapan.GetColumnValue("CharniNo").ToString());
                                charniProcessMaster.JangadNo = Convert.ToInt32(txtSerialNo.Text);
                                //charniProcessMaster.BoilJangadNo = Convert.ToInt32(lueKapan.GetColumnValue("BoilJangadNo").ToString());
                                charniProcessMaster.CompanyId = Common.LoginCompany;
                                charniProcessMaster.BranchId = Common.LoginBranch;
                                charniProcessMaster.EntryDate = Convert.ToDateTime(dtDate.Text).ToString("yyyyMMdd");
                                charniProcessMaster.EntryTime = Convert.ToDateTime(dtTime.Text).ToString("hh:mm:ss ttt");
                                charniProcessMaster.FinancialYearId = Common.LoginFinancialYear;
                                charniProcessMaster.CharniType = Convert.ToInt32(ProcessType.Return);
                                charniProcessMaster.KapanId = lueKapan.GetColumnValue("KapanId").ToString();
                                charniProcessMaster.ShapeId = grvParticularsDetails.GetRowCellValue(i, colShapeId).ToString();
                                charniProcessMaster.SizeId = grvParticularsDetails.GetRowCellValue(i, colSizeId).ToString();
                                charniProcessMaster.PurityId = grvParticularsDetails.GetRowCellValue(i, colPurityId).ToString();
                                charniProcessMaster.CharniSizeId = grvParticularsDetails.GetRowCellValue(i, colCharniSizeId).ToString();
                                charniProcessMaster.Weight = 0;//Convert.ToDecimal(txtACarat.Text);
                                charniProcessMaster.CharniWeight = Convert.ToDecimal(Cts);
                                charniProcessMaster.LossWeight = 0;
                                charniProcessMaster.RejectionWeight = 0;
                                charniProcessMaster.HandOverById = lueReceiveFrom.EditValue.ToString();
                                charniProcessMaster.HandOverToId = lueSendto.EditValue.ToString();
                                charniProcessMaster.SlipNo = grvParticularsDetails.GetRowCellValue(i, colSlipNo1).ToString();
                                //charniProcessMaster.CharniCategoy = Convert.ToInt32(grvParticularsDetails.GetRowCellValue(i, colCategory));
                                charniProcessMaster.Remarks = txtRemark.Text;
                                charniProcessMaster.IsDelete = false;
                                charniProcessMaster.CreatedDate = DateTime.Now;
                                charniProcessMaster.CreatedBy = Common.LoginUserID;
                                charniProcessMaster.UpdatedDate = DateTime.Now;
                                charniProcessMaster.UpdatedBy = Common.LoginUserID;
                                //charniProcessMaster.TransferCaratRate = Convert.ToDouble(grvParticularsDetails.GetRowCellValue(i, colRate).ToString());

                                var Result = await charniProcessMasterRepository.AddCharniProcessAsync(charniProcessMaster);
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
                    else if (Convert.ToInt32(lueDepartment.EditValue) == DepartmentMaster1.Gala)
                    {
                        string Cts = "0";

                        GalaProcessMasterRepository galaProcessMasterRepository = new GalaProcessMasterRepository();
                        GalaProcessMaster galaProcessMaster = new GalaProcessMaster();
                        bool IsSuccess = false;
                        try
                        {
                            for (int i = 0; i < grvParticularsDetails.RowCount; i++)
                            {
                                Cts = "0";
                                Cts = grvParticularsDetails.GetRowCellValue(i, colCharniCarat).ToString();
                                galaProcessMaster = new GalaProcessMaster();
                                galaProcessMaster.Id = Guid.NewGuid().ToString();
                                //galaProcessMaster.GalaNo = Convert.ToInt32(lueKapan.GetColumnValue("GalaNo").ToString());
                                galaProcessMaster.JangadNo = Convert.ToInt32(txtSerialNo.Text);
                                //galaProcessMaster.BoilJangadNo = Convert.ToInt32(lueKapan.GetColumnValue("BoilJangadNo").ToString());
                                galaProcessMaster.CompanyId = Common.LoginCompany;
                                galaProcessMaster.BranchId = Common.LoginBranch;
                                galaProcessMaster.EntryDate = Convert.ToDateTime(dtDate.Text).ToString("yyyyMMdd");
                                galaProcessMaster.EntryTime = Convert.ToDateTime(dtTime.Text).ToString("hh:mm:ss ttt");
                                galaProcessMaster.FinancialYearId = Common.LoginFinancialYear;
                                galaProcessMaster.GalaProcessType = Convert.ToInt32(ProcessType.Return);
                                galaProcessMaster.KapanId = lueKapan.GetColumnValue("KapanId").ToString();
                                galaProcessMaster.ShapeId = grvParticularsDetails.GetRowCellValue(i, colShapeId).ToString();
                                galaProcessMaster.SizeId = grvParticularsDetails.GetRowCellValue(i, colSizeId).ToString();
                                galaProcessMaster.PurityId = grvParticularsDetails.GetRowCellValue(i, colPurityId).ToString();
                                galaProcessMaster.CharniSizeId = grvParticularsDetails.GetRowCellValue(i, colCharniSizeId).ToString();
                                galaProcessMaster.Weight = 0;// Convert.ToDecimal(txtACarat.Text);
                                galaProcessMaster.GalaNumberId = grvParticularsDetails.GetRowCellValue(i, colGalaNumberId).ToString();
                                galaProcessMaster.GalaWeight = Convert.ToDecimal(Cts);
                                galaProcessMaster.LossWeight = 0;
                                galaProcessMaster.RejectionWeight = 0;
                                galaProcessMaster.HandOverById = lueReceiveFrom.EditValue.ToString();
                                galaProcessMaster.HandOverToId = lueSendto.EditValue.ToString();
                                galaProcessMaster.SlipNo = grvParticularsDetails.GetRowCellValue(i, colSlipNo1).ToString();
                                // galaProcessMaster.GalaCategoy = Convert.ToInt32(grvParticularsDetails.GetRowCellValue(i, colCategory));
                                galaProcessMaster.Remarks = txtRemark.Text;
                                galaProcessMaster.IsDelete = false;
                                galaProcessMaster.CreatedDate = DateTime.Now;
                                galaProcessMaster.CreatedBy = Common.LoginUserID;
                                galaProcessMaster.UpdatedDate = DateTime.Now;
                                galaProcessMaster.UpdatedBy = Common.LoginUserID;

                                //galaProcessMaster.TransferCaratRate = Convert.ToDouble(grvParticularsDetails.GetRowCellValue(i, colRate).ToString());

                                var Result = await galaProcessMasterRepository.AddGalaProcessAsync(galaProcessMaster);
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
                    else
                    {
                        string Cts = "0";

                        NumberProcessMasterRepository numberProcessMasterRepository = new NumberProcessMasterRepository();
                        NumberProcessMaster numberProcessMaster = new NumberProcessMaster();
                        bool IsSuccess = false;
                        try
                        {
                            for (int i = 0; i < grvParticularsDetails.RowCount; i++)
                            {
                                Cts = "0";
                                Cts = grvParticularsDetails.GetRowCellValue(i, colCharniCarat).ToString();
                                numberProcessMaster = new NumberProcessMaster();
                                numberProcessMaster.Id = Guid.NewGuid().ToString();
                                //numberProcessMaster.NumberNo = Convert.ToInt32(lueKapan.GetColumnValue("NumberNo").ToString());
                                numberProcessMaster.JangadNo = Convert.ToInt32(txtSerialNo.Text);
                                //galaProcessMaster.BoilJangadNo = Convert.ToInt32(lueKapan.GetColumnValue("BoilJangadNo").ToString());
                                numberProcessMaster.CompanyId = Common.LoginCompany;
                                numberProcessMaster.BranchId = Common.LoginBranch;
                                numberProcessMaster.EntryDate = Convert.ToDateTime(dtDate.Text).ToString("yyyyMMdd");
                                numberProcessMaster.EntryTime = Convert.ToDateTime(dtTime.Text).ToString("hh:mm:ss ttt");
                                numberProcessMaster.FinancialYearId = Common.LoginFinancialYear;
                                numberProcessMaster.NumberProcessType = Convert.ToInt32(ProcessType.Return);
                                numberProcessMaster.KapanId = lueKapan.GetColumnValue("KapanId").ToString();
                                numberProcessMaster.ShapeId = grvParticularsDetails.GetRowCellValue(i, colShapeId).ToString();
                                numberProcessMaster.SizeId = grvParticularsDetails.GetRowCellValue(i, colSizeId).ToString();
                                numberProcessMaster.PurityId = grvParticularsDetails.GetRowCellValue(i, colPurityId).ToString();
                                numberProcessMaster.CharniSizeId = grvParticularsDetails.GetRowCellValue(i, colCharniSizeId).ToString();
                                numberProcessMaster.Weight = 0;// Convert.ToDecimal(txtACarat.Text);
                                //numberProcessMaster.GalaNumberId = lueKapan.GetColumnValue("GalaNumberId").ToString(); //grvParticularsDetails.GetRowCellValue(i, colSize).ToString();
                                numberProcessMaster.NumberId = grvParticularsDetails.GetRowCellValue(i, colNumberId).ToString();
                                numberProcessMaster.NumberWeight = Convert.ToDecimal(Cts);
                                numberProcessMaster.LossWeight = 0;
                                numberProcessMaster.RejectionWeight = 0;
                                numberProcessMaster.HandOverById = lueReceiveFrom.EditValue.ToString();
                                numberProcessMaster.HandOverToId = lueSendto.EditValue.ToString();
                                numberProcessMaster.SlipNo = grvParticularsDetails.GetRowCellValue(i, colSlipNo1).ToString();
                                //numberProcessMaster.NumberCategoy = Convert.ToInt32(grvParticularsDetails.GetRowCellValue(i, colCategory));
                                numberProcessMaster.Remarks = txtRemark.Text;
                                numberProcessMaster.IsDelete = false;
                                numberProcessMaster.CreatedDate = DateTime.Now;
                                numberProcessMaster.CreatedBy = Common.LoginUserID;
                                numberProcessMaster.UpdatedDate = DateTime.Now;
                                numberProcessMaster.UpdatedBy = Common.LoginUserID;
                                numberProcessMaster.TransferCaratRate= Convert.ToDouble(grvParticularsDetails.GetRowCellValue(i, colRate).ToString());

                                var Result = await numberProcessMasterRepository.AddNumberProcessAsync(numberProcessMaster);
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

        private bool CheckValidation()
        {
            if (lueReceiveFrom.EditValue == null)
            {
                MessageBox.Show("Please select Receive from name", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                lueReceiveFrom.Focus();
                return false;
            }
            else if (lueSendto.EditValue == null)
            {
                MessageBox.Show("Please select Send to name", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                lueSendto.Focus();
                return false;
            }
            if (lueKapan.EditValue == null)
            {
                MessageBox.Show("Please select Kapan", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                lueKapan.Focus();
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

        private async void Reset()
        {
            grdParticularsDetails.DataSource = null;
            dtDate.EditValue = DateTime.Now;
            dtTime.EditValue = DateTime.Now;
            txtRemark.Text = "";
            lueReceiveFrom.EditValue = null;
            lueSendto.EditValue = null;
            lueDepartment.EditValue = null;
            lueKapan.EditValue = null;
            repoSlipNo.DataSource = null;

            await GetMaxSrNo();
            await GetEmployeeList();
            lueReceiveFrom.Select();
            lueReceiveFrom.Focus();
        }
    }
}
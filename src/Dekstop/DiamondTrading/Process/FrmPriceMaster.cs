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
    public partial class FrmPriceMaster : DevExpress.XtraEditors.XtraForm
    {
        CompanyMasterRepository _companyMasterRepository;
        PriceMasterRepository _priceMasterRepository;
        List<BoilProcessSend> ListAssortmentProcessSend;

        public FrmPriceMaster()
        {
            InitializeComponent();
            _companyMasterRepository = new CompanyMasterRepository();
            _priceMasterRepository = new PriceMasterRepository();

            LoadCompany();
            LoadCategory();
            //if (RejectionType == 1)
            //{
            //    SetThemeColors(Color.FromArgb(250, 243, 197));
            //    this.Text = "REJECTION RECEIVE";
            //}
            //else if (RejectionType == 2)
            //{
            //    SetThemeColors(Color.FromArgb(215, 246, 214));
            //    this.Text = "REJECTION SEND";
            //}
        }

        private void LoadCategory()
        {
            var Category = PriceMasterCategory.GetAllCategory();

            if (Category != null)
            {
                lueCategory.Properties.DataSource = Category;
                lueCategory.Properties.DisplayMember = "Name";
                lueCategory.Properties.ValueMember = "Id";
            }
        }

        private async void LoadCompany()
        {
            var data = await _companyMasterRepository.GetAllCompanyAsync();

            lueCompany.Properties.DataSource = data;
            lueCompany.Properties.DisplayMember = "Name";
            lueCompany.Properties.ValueMember = "Id";
            lueCompany.EditValue = Common.LoginCompany;
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
            }
        }

        private void FrmPriceMaster_Load(object sender, EventArgs e)
        {
            dtDate.EditValue = DateTime.Now;
            dtTime.EditValue = DateTime.Now;
        }

        private static DataTable GetDTColumnsforParticularDetails()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("SizeId");
            dt.Columns.Add("Size");
            dt.Columns.Add("NumberId");
            dt.Columns.Add("Number");
            dt.Columns.Add("Rate");
            return dt;
        }

        private void grvParticularsDetails_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column == colNumber)
                {
                    //grvParticularsDetails.SetRowCellValue(e.RowHandle, colACarat, ((Repository.Entities.Models.BoilProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).AvailableWeight);
                    //grvParticularsDetails.SetRowCellValue(e.RowHandle, colSizeId, ((Repository.Entities.Models.BoilProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).SizeId);
                    //grvParticularsDetails.SetRowCellValue(e.RowHandle, colShapeId, ((Repository.Entities.Models.BoilProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).ShapeId);
                    //grvParticularsDetails.SetRowCellValue(e.RowHandle, colPurityId, ((Repository.Entities.Models.BoilProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).PurityId);
                    //grvParticularsDetails.SetRowCellValue(e.RowHandle, colSlipNo1, ((Repository.Entities.Models.BoilProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).SlipNo);
                    //grvParticularsDetails.SetRowCellValue(e.RowHandle, colPurchaseDetailsId, ((Repository.Entities.Models.BoilProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).PurchaseDetailsId);
                    //grvPurchaseItems.FocusedRowHandle = e.RowHandle;
                    //grvPurchaseItems.FocusedColumn = colBoilCarat;
                }
            }
            catch
            {

            }
        }

        private bool CheckValidation()
        {
            if (lueCompany.EditValue == null)
            {
                MessageBox.Show("Please select Company name", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                lueCompany.Focus();
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
                    await _priceMasterRepository.DeletePriceAsync(lueCompany.EditValue.ToString(),lueCategory.EditValue.ToString());
                    PriceMaster priceMaster;
                    List<PriceMaster> priceMasterList = new List<PriceMaster>();
                    grvParticularsDetails.ExpandAllGroups();
                    for (int i = 0; i < grvParticularsDetails.RowCount; i++)
                    {
                        if (grvParticularsDetails.GetRowCellValue(i, colSizeId) != null)
                        {
                            priceMaster = new PriceMaster();
                            priceMaster.Id = Guid.NewGuid().ToString();
                            priceMaster.CompanyId = lueCompany.EditValue.ToString();
                            priceMaster.CategoryId = lueCategory.EditValue.ToString();
                            priceMaster.SizeId = grvParticularsDetails.GetRowCellValue(i, colSizeId).ToString();
                            priceMaster.NumberId = grvParticularsDetails.GetRowCellValue(i, colNumberId).ToString();
                            priceMaster.Price = decimal.Parse(grvParticularsDetails.GetRowCellValue(i, colPrice).ToString());
                            priceMaster.CreatedBy = Common.LoginUserID;
                            priceMaster.CreatedDate = DateTime.Now;
                            priceMaster.UpdatedBy = Common.LoginUserID;
                            priceMaster.UpdatedDate = DateTime.Now;

                            priceMasterList.Insert(i,priceMaster);
                        }
                    }

                    if (priceMasterList.Count > 0)
                    {
                        await _priceMasterRepository.AddPriceAsync(priceMasterList);
                        IsSuccess = true;
                    }
                }
                catch(Exception Ex)
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

        private void Reset()
        {
            LoadCompany();
            LoadCategory();
            grdParticularsDetails.DataSource = null;
            ListAssortmentProcessSend = null;
            dtDate.EditValue = DateTime.Now;
            dtTime.EditValue = DateTime.Now;
            lueCompany.EditValue = null;
            repoSlipNo.DataSource = null;;

            lueCompany.Select();
            lueCompany.Focus();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void FrmPriceMaster_KeyDown(object sender, KeyEventArgs e)
        {
            Common.MoveToNextControl(sender, e, this);
        }

        private async void lueCompany_EditValueChanged(object sender, EventArgs e)
        {
            await GetPriceDetails();
        }

        private async Task GetPriceDetails()
        {
            if (lueCompany.EditValue != null && lueCategory.EditValue != null)
            {
                var defaultPriceList = await _priceMasterRepository.GetDefaultPriceList();
                DataTable dtDefaultList = Common.ToDataTable(defaultPriceList);
                grdParticularsDetails.DataSource = dtDefaultList;

                var priceList = await _priceMasterRepository.GetAllPricesAsync(lueCompany.EditValue.ToString(), lueCategory.EditValue.ToString());
                if (priceList != null)
                {
                    var priceDetail = priceList.Where(x => x.Price > 0).ToList();
                    DataView dtView = new DataView(dtDefaultList);
                    if (dtView.Count > 0)
                    {
                        for (int i = 0; i < priceDetail.Count; i++)
                        {
                            dtView.RowFilter = "SizeId='" + priceDetail[i].SizeId + "' and NumberId='" + priceDetail[i].NumberId + "'";
                            if (dtView.Count > 0)
                            {
                                dtView[0].Row["Price"] = priceDetail[i].Price;
                            }
                            dtView.RowFilter = string.Empty;
                        }
                    }
                }
            }
        }

        private async void lueCategory_EditValueChanged(object sender, EventArgs e)
        {
            await GetPriceDetails();
        }
    }
}
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
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
    public partial class FrmPriceMasterMobiles : DevExpress.XtraEditors.XtraForm
    {
        CompanyMasterRepository _companyMasterRepository;
        PriceMasterMobileRepository _priceMasterRepository;
        List<BoilProcessSend> ListAssortmentProcessSend;
        DataTable dt = null;
        public FrmPriceMasterMobiles()
        {
            InitializeComponent();
            _companyMasterRepository = new CompanyMasterRepository();
            _priceMasterRepository = new PriceMasterMobileRepository();

            LoadCompany();
            LoadCategory();
            dt = GetDTColumnsforParticularDetails();
            grdData.DataSource = dt;

            RefreshMobileData();
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
            var data = await _companyMasterRepository.GetUserCompanyMappingAsync(Common.LoginUserID);

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
            timer1.Start();
        }

        private static DataTable GetDTColumnsforParticularDetails()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("No");
            dt.Columns.Add("Size");
            dt.Columns.Add("Number");
            dt.Columns.Add("Price");
            return dt;
        }

        private void grvParticularsDetails_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
        }

        private bool CheckValidation()
        {
            if (lueCompany.EditValue == null)
            {
                MessageBox.Show("Please select Company name", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                lueCompany.Focus();
                return false;
            }

            if (lueCategory.EditValue == null)
            {
                MessageBox.Show("Please select Category", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                lueCategory.Focus();
                return false;
            }
            else if (gvData.RowCount == 0)
            {
                MessageBox.Show("Please select Particulars Details", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                gvData.Focus();
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
                    await _priceMasterRepository.DeletePriceAsync(lueCompany.EditValue.ToString(), lueCategory.EditValue.ToString());
                    PriceMasterMobile priceMaster;
                    List<PriceMasterMobile> priceMasterList = new List<PriceMasterMobile>();
                    for (int i = 0; i < gvData.RowCount; i++)
                    {
                        if (gvData.GetRowCellValue(i, colSize) != null && gvData.GetRowCellValue(i, colNumber) != null)
                        {
                            priceMaster = new PriceMasterMobile();
                            priceMaster.Id = Guid.NewGuid().ToString();
                            priceMaster.CompanyId = lueCompany.EditValue.ToString();
                            priceMaster.CategoryId = lueCategory.EditValue.ToString();
                            priceMaster.SizeName = gvData.GetRowCellValue(i, colSize).ToString();
                            priceMaster.NumberName = gvData.GetRowCellValue(i, colNumber).ToString();
                            priceMaster.Price = decimal.Parse(gvData.GetRowCellValue(i, colPrice).ToString());
                            priceMaster.CreatedBy = Common.LoginUserID;
                            priceMaster.CreatedDate = DateTime.Now;
                            priceMaster.UpdatedBy = Common.LoginUserID;
                            priceMaster.UpdatedDate = DateTime.Now;

                            priceMasterList.Insert(i, priceMaster);
                        }
                    }

                    if (priceMasterList.Count > 0)
                    {
                        await _priceMasterRepository.AddPriceAsync(priceMasterList);
                        IsSuccess = true;
                    }
                }
                catch (Exception Ex)
                {
                    IsSuccess = false;
                }

                if (IsSuccess)
                {
                    Reset();
                    RefreshMobileData();
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
            grdData.DataSource = null;
            ListAssortmentProcessSend = null;
            dtDate.EditValue = DateTime.Now;
            dtTime.EditValue = DateTime.Now;
            lueCompany.EditValue = null;
            //repoSlipNo.DataSource = null;;

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

        private void lueCompany_EditValueChanged(object sender, EventArgs e)
        {
            RefreshMobileData();
        }

        private async void RefreshMobileData()
        {
            var defaultPriceList = await _priceMasterRepository.GetMobileData();
            int index = 1;
            dt.Rows.Clear();
            defaultPriceList.ToList().ForEach(x =>
            {
                dt.Rows.Add(index, x.SizeName, x.NumberName, x.Price);
                index++;
            });
            grdData.DataSource = dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNumber.Text.Trim()) || string.IsNullOrEmpty(txtPrice.Text) || string.IsNullOrEmpty(txtSize.Text.Trim()))
            {
                MessageBox.Show(this, "Please fill the missing value among Price/Number/Size.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (decimal.TryParse(txtPrice.Text.Trim(), out decimal price))
            {
                if (_priceMasterRepository.CheckDuplicateEntry(txtSize.Text.Trim(), txtNumber.Text.Trim(), price))
                {
                    MessageBox.Show(this, "Price/Number/Size Combination already exist.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show(this, "Price is not correct.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (btnAdd.Text == "&Add")
            {
                if (!CheckValueExists(txtSize.Text, txtNumber.Text, txtPrice.Text))
                {
                    int newRowHandle = gvData.GetRowHandle(gvData.DataRowCount);
                    dt.Rows.Add(newRowHandle + 1, txtSize.Text, txtNumber.Text, txtPrice.Text);
                    grdData.DataSource = dt;
                    txtSize.Text = string.Empty;
                    txtPrice.Text = string.Empty;
                    txtNumber.Text = string.Empty;
                    if (MessageBox.Show(this, "Do you want to add more?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ActiveControl = txtSize;
                    }
                }
            }
            else
            {
                DataRow selectedRow = gvData.GetDataRow(gvData.FocusedRowHandle);
                selectedRow["Size"] = txtSize.Text;
                selectedRow["Price"] = txtPrice.Text;
                selectedRow["Number"] = txtNumber.Text;

                txtSize.Text = string.Empty;
                txtPrice.Text = string.Empty;
                txtNumber.Text = string.Empty;
                gvData.RefreshData();
            }
            btnAdd.Text = "&Add";
        }

        private void gvData_DoubleClick(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null)
                return;
            // When a cell in the grid is clicked, load the cell's value into the textbox
            GridHitInfo info = view.CalcHitInfo(view.GridControl.PointToClient(MousePosition));

            if (info.InRow)
            {
                // Check if a row was double-clicked
                int rowHandle = info.RowHandle;

                btnAdd.Text = "Update";
                txtSize.Text = gvData.GetRowCellValue(rowHandle, "Size").ToString();
                txtPrice.Text = gvData.GetRowCellValue(rowHandle, "Price").ToString();
                txtNumber.Text = gvData.GetRowCellValue(rowHandle, "Number").ToString();
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            string size = gvData.GetRowCellValue(gvData.FocusedRowHandle, "Size").ToString();
            _ = decimal.TryParse(gvData.GetRowCellValue(gvData.FocusedRowHandle, "Price").ToString(), out decimal price);
            string number = gvData.GetRowCellValue(gvData.FocusedRowHandle, "Number").ToString();
            if (MessageBox.Show(this, "Are you sure to delete selected record?", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.OK)
            {
                bool isSuccess = await _priceMasterRepository.DeletePriceMasterEntryForMobileAsync(size, number, price);
                if (isSuccess)
                {
                    MessageBox.Show(this, "Record deleted successfully", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshMobileData();
                }
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is a digit (0-9), a decimal point, or a backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != (char)Keys.Back)
            {
                // Prevent the input of any other characters
                e.Handled = true;
            }

            // If the input contains a decimal point, make sure it's entered only once
            if (e.KeyChar == '.' && (sender as TextEdit).Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private bool ValueExistsInColumn(GridView gridView, string size, string nuuber, decimal price)
        {
            for (int rowHandle = 0; rowHandle < gridView.RowCount; rowHandle++)
            {
                object cellSize = gridView.GetRowCellValue(rowHandle, colSize);
                object cellNumber = gridView.GetRowCellValue(rowHandle, colNumber);
                object cellPrice = gridView.GetRowCellValue(rowHandle, colPrice);
                _ = decimal.TryParse(cellPrice.ToString(), out decimal priceCell);
                if (cellNumber.Equals(nuuber) && cellSize.Equals(size) && priceCell.Equals(price))
                {
                    return true; // Value exists in the column
                }
            }
            return false; // Value does not exist in the column
        }

        // Example of how to use the function:
        private bool CheckValueExists(string sizeToCheck, string numberToCheck, string priceToCheck)
        {
            // Get the GridView
            GridView gridView = grdData.MainView as GridView;

            _ = decimal.TryParse(priceToCheck, out decimal price);

            if (ValueExistsInColumn(gridView, sizeToCheck, numberToCheck, price))
            {
                MessageBox.Show("Value exists.");
                return true;
            }
            else
            {
                return false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dtTime.EditValue = DateTime.Now;
        }
    }
}
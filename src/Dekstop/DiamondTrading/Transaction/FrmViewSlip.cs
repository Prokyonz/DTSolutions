﻿using DevExpress.XtraEditors;
using EFCore.SQL.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiamondTrading.Transaction
{
    public partial class FrmViewSlip : DevExpress.XtraEditors.XtraForm
    {
        private PurchaseMasterRepository _purchaseMasterRepository;
        private string _Id = string.Empty;
        private string _SlipNo = string.Empty;
        private string _FinancialYearId = string.Empty;
        private int _ActionType = 0;
        DataTable dt = new DataTable();
        public FrmViewSlip(int ActionType,string SlipNo, string FinancialYearId, string Id)
        {
            InitializeComponent();
            _purchaseMasterRepository = new PurchaseMasterRepository();
            _Id = Id;
            _SlipNo = SlipNo;
            _FinancialYearId = FinancialYearId;
            _ActionType = ActionType;
        }

        private async void FrmViewSlip_Load(object sender, EventArgs e)
        {
            var slipDetails = await _purchaseMasterRepository.GetSlipDetails(_ActionType,Common.LoginCompany, _SlipNo, _FinancialYearId);
            dt = Common.ToDataTable(slipDetails);
            if (dt.Rows.Count > 0)
            {
                Reports.rptSlipPrint cls = new Reports.rptSlipPrint();
                cls.SetDataSource(dt);
                cls.SetDatabaseLogon("sa", "123");
                cls.PrintOptions.PrinterName = Common.SlipPrinterName;
                //cls.PrintOptions.PrinterName = Common.BarcodePrinter;
                //cls.PrintToPrinter(1, false, 0, 0);
                crystalReportViewer1.ReportSource = cls;
                crystalReportViewer1.Show();
            }
        }

        private async void btnPrint_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count > 0)
            {
                Reports.rptSlipPrint cls = new Reports.rptSlipPrint();
                cls.SetDataSource(dt);
                cls.SetDatabaseLogon("sa", "123");
                cls.PrintOptions.PrinterName = Common.SlipPrinterName;
                //cls.PrintOptions.PrinterName = Common.BarcodePrinter;
                cls.PrintToPrinter(1, false, 0, 0);
                //crystalReportViewer1.ReportSource = cls;
                //crystalReportViewer1.Show();

                if (_ActionType == 1) //Purchase
                {
                    var result = await _purchaseMasterRepository.UpdateSlipPrintStatusAsync(_Id, true);
                }
                else
                {
                    SalesMasterRepository _salesMasterRepository = new SalesMasterRepository();
                    var result = await _salesMasterRepository.UpdateSlipPrintStatusAsync(_Id, true);
                }
            }
        }
    }
}
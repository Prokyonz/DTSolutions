using DiamondTradeApp.ViewModels;
using DiamondTradeApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DiamondTradeApp.Models;
using DiamondTradeApp.Services;

namespace DiamondTradeApp.Views
{
    public partial class ReportsPage : ContentPage
    {
        ObservableCollection<PurchaseMaster> purchaseMastersList = new ObservableCollection<PurchaseMaster>();
        public ObservableCollection<PurchaseMaster> PeportMastersList { get { return purchaseMastersList; } }
        private readonly ReportMasterRepository _reportMasterRepository;

        public ReportsPage()
        {
            InitializeComponent();
            _reportMasterRepository = new ReportMasterRepository();
            var reportList = PurchaseReport();

            if (reportList != null)
            {
                collectionView.ItemsSource = reportList.OrderByDescending(e => e.Date)
                .Take(20).ToList();
            }
        }

        private ObservableCollection<PurchaseMaster> PurchaseReport()
        {
            var getPurchanseReport = _reportMasterRepository.GetPurchaseReport("", "", null);

            if (getPurchanseReport == null)
            {
                return null;
            }

            for (int i = 0; i < getPurchanseReport.Rows.Count; i++)
            {
                purchaseMastersList.Add(new PurchaseMaster
                {
                    ID = getPurchanseReport.Rows[i]["ID"].ToString(),
                    BrokerName = getPurchanseReport.Rows[i]["BrokerName"].ToString(),
                    Date = Convert.ToDateTime(getPurchanseReport.Rows[i]["Date"]).ToShortDateString(),
                    GrossTotal = Convert.ToDecimal(getPurchanseReport.Rows[i]["GrossTotal"]),
                    PartyName = getPurchanseReport.Rows[i]["PartyName"].ToString(),
                    Weight = Convert.ToDecimal(getPurchanseReport.Rows[i]["Weight"]),
                    Message = getPurchanseReport.Rows[i]["Message"].ToString(),
                    SlipNo = Convert.ToInt32(getPurchanseReport.Rows[i]["SlipNo"]) ,
                    BrokerAmount = Convert.ToDouble(getPurchanseReport.Rows[i]["RoundUpAmount"]),
                    BuyingRate = getPurchanseReport.Rows[i]["BuyingRate"].ToString()
                });
            }
            return purchaseMastersList;
        }
    }
    public class PurchaseMaster
    {
        public string ID { get; set; }
        public string PartyName { get; set; }
        public string Date { get; set; }
        public decimal Weight { get; set; }
        public string BrokerName { get; set; }
        public decimal GrossTotal { get; set; }
        public string Message { get; set; }
        public long SlipNo { get; set; }
        public double BrokerAmount { get; set; }
        public string BuyingRate { get; set; }

    }
}
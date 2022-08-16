using DiamondTradeApp.Services;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DiamondTradeApp.Views
{
    public partial class HomePage : ContentPage
    {
        ObservableCollection<ReportMaster> reportMastersList = new ObservableCollection<ReportMaster>();
        public ObservableCollection<ReportMaster> ReportMastersList { get { return reportMastersList; } }

        private readonly ReportMasterRepository _reportMasterRepository;

        public HomePage()
        {
            InitializeComponent();
            _reportMasterRepository = new ReportMasterRepository();
            
            FillBox();
            ReportsView.ItemsSource = reportMastersList;
        }

        private void FillBox()
        {
            var reportList = _reportMasterRepository.GetDashboardReports("", "", 0);
            if (reportList != null)
            {
                for (int i = 0; i < reportList.Rows.Count; i++)
                {
                    reportMastersList.Add(new ReportMaster()
                    {
                        Type = reportList.Rows[i][0].ToString(),
                        Component = reportList.Rows[i][1].ToString(),
                        Value = reportList.Rows[i][2].ToString()
                    });
                }
            }
        }
    }

    public class ReportMaster
    {
        public string Type { get; set; }
        public string Component { get; set; }
        public string Value { get; set; }

    }

    public class Employee
    {
        public string DisplayName { get; set; }
    }
}
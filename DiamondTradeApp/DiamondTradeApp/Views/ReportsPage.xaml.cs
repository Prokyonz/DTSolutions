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

namespace DiamondTradeApp.Views
{
    public partial class ReportsPage : ContentPage
    {
        private ObservableCollection<GroupedVeggieModel> grouped { get; set; }
        private ObservableCollection<GroupedVeggieModel> groupedCopy { get; set; }

        bool isNameSorted = true;
        List<Employee> Employees = new List<Employee>();
        public ReportsPage()
        {
            InitializeComponent();
            //this.BindingContext = new EmployeeListviewModel();

            grouped = InitData();
            groupedCopy = InitData();

            lstView.ItemsSource = grouped;
        }

        ObservableCollection<GroupedVeggieModel> InitData()
        {
            ObservableCollection<GroupedVeggieModel> grouped = new ObservableCollection<GroupedVeggieModel>();
            GroupedVeggieModel veggieGroup = new GroupedVeggieModel() { LongName = "Party Name", ShortName = "v", IsExpand = true };
            GroupedVeggieModel fruitGroup = new GroupedVeggieModel() { LongName = "Party Name 2", ShortName = "f", IsExpand = true };

            veggieGroup.Add(new VeggieModel() { Name = "celery", IsReallyAVeggie = true, Comment = "try ants on a log" });
            veggieGroup.Add(new VeggieModel() { Name = "tomato", IsReallyAVeggie = false, Comment = "pairs well with basil" });
            veggieGroup.Add(new VeggieModel() { Name = "zucchini", IsReallyAVeggie = true, Comment = "zucchini bread > bannana bread" });
            veggieGroup.Add(new VeggieModel() { Name = "peas", IsReallyAVeggie = true, Comment = "like peas in a pod" });
            fruitGroup.Add(new VeggieModel() { Name = "banana", IsReallyAVeggie = false, Comment = "available in chip form factor" });
            fruitGroup.Add(new VeggieModel() { Name = "strawberry", IsReallyAVeggie = false, Comment = "spring plant" });
            fruitGroup.Add(new VeggieModel() { Name = "cherry", IsReallyAVeggie = false, Comment = "topper for icecream" });
            grouped.Add(veggieGroup);
            grouped.Add(fruitGroup);
            return grouped;
        }

        void Click(GroupedVeggieModel model)
        {
            if (model.IsExpand)
            {
                var index = grouped.IndexOf(model);
                var context = groupedCopy[index];
                foreach (var m in context)
                {
                    model.Add(m);
                }
            }
            else
            {
                model.Clear();
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var label = sender as Label;
            var model = label.BindingContext as GroupedVeggieModel;
            model.IsExpand = !model.IsExpand;

            Click(model);
        }

        private void NameSort_Tapped(object sender, EventArgs e)
        {

            List<Employee> EmployeeList = new List<Employee>();
            Employees = new List<Employee>();
            //Sorry for this line of code :DD
            //if (EmplooyeList.ItemsSource is ObservableCollection<Employee> empCollection)
            //    EmployeeList.AddRange(empCollection);
            //else if (EmplooyeList.ItemsSource is List<Employee> empList)
            //    EmployeeList.AddRange(empList);

            if (isNameSorted)
            {
                EmployeeList = EmployeeList.OrderBy(x => x.DisplayName).ToList();
                foreach (var item in EmployeeList)
                {
                    Employees.Add(item);
                }
            }
            else
            {
                EmployeeList = EmployeeList.OrderByDescending(x => x.DisplayName).ToList();
                foreach (var item in EmployeeList)
                {
                    Employees.Add(item);
                }
            }
            //EmplooyeList.ItemsSource = Employees;
            isNameSorted = !isNameSorted;
        }
    }
}
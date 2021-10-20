using EFCore.SQL.Repository;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondTrading
{
    public static class AppLoadValues
    {
        private static CompanyMasterRepository _companyMasterRepository;
        private static BranchMasterRepository _branchMasterRepository;
        private static FinancialYearMasterRepository _financialYearRepository;
        private static bool _ForceLoad = false;
        public static bool ForceLoad
        {
            private get
            {
                return _ForceLoad;
            }
            set
            {
                if(value)
                {
                    _ForceLoad = value;
                    LoadAllCompany();
                    LoadAllBranch();
                    LoadAllFinancialYear();
                    _ForceLoad = false;
                }
            }
        }
        public static List<CompanyMaster> CompanyMastersList
        {
            get;
            private set;
        }
        
        public static List<BranchMaster> BranchMastersList
        {
            get;
            private set;
        }

        public static List<FinancialYearMaster> FinancialYearMastersList
        {
            get;
            private set;
        }

        static AppLoadValues()
        {
            _companyMasterRepository = new CompanyMasterRepository();
            _branchMasterRepository = new BranchMasterRepository();
            _financialYearRepository = new FinancialYearMasterRepository();

            LoadAllCompany();
            LoadAllBranch();
            LoadAllFinancialYear();
        }

        private static async void LoadAllCompany()
        {
            if (ForceLoad || CompanyMastersList == null)
            {
                CompanyMastersList = await _companyMasterRepository.GetParentCompanyAsync();
            }
        }

        private static async void LoadAllBranch()
        {
            if (ForceLoad || BranchMastersList == null)
            {
                BranchMastersList = await _branchMasterRepository.GetAllBranchAsync();
            }
        }

        private static async void LoadAllFinancialYear()
        {
            if (ForceLoad || FinancialYearMastersList == null)
            {
                FinancialYearMastersList = await _financialYearRepository.GetAllFinancialYear();
            }
        }
    }
}

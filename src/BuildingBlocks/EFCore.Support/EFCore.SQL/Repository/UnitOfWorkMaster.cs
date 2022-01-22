using EFCore.SQL.DBContext;
using EFCore.SQL.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.SQL.Repository
{
    public class UnitOfWorkMaster
    {
        private PurchaseMasterRepository _purchaseMasterRepository;
        private KapanMasterRepository _kapanMasterRepository;
        private ShapeMasterRepository _shapeMasterRepository;
        private SizeMasterRepository _sizeMasterRepository;
        private PurityMasterRepository _purityMasterRepository;
        private GalaMasterRepository _galaMasterRepository;
        private NumberMasterRepository _numberMasterRepository;
        private BranchMasterRepository _branchMasterRepository;
        private BrokerageMasterRepository _brokerageMasterRepository;
        private CompanyMasterRepository _companyMasterRepository;
        private CurrencyMasterRepository _currencyMasterRepository;
        private FinancialYearMasterRepository _financialYearMasterRepository;
        private LessWeightMasterRepository _lessWeightMasterRepository;
        private PartyMasterRepository _partyMasterRepository;
        private SalesMasterRepository _salesMasterRepository;
        private RoleMasterRepository _roleMasterRepository;
        private ExpenseMasterRepository _expenseMasterRepository;

        public UnitOfWorkMaster()
        {
            
        }

        public RoleMasterRepository RoleMaster
        {
            get
            {
                if (_roleMasterRepository == null)
                    _roleMasterRepository = new RoleMasterRepository();
                return _roleMasterRepository;
            }
        }
        public SalesMasterRepository SalesMaster
        {
            get
            {
                if (_salesMasterRepository == null)
                    _salesMasterRepository = new SalesMasterRepository();
                return _salesMasterRepository;
            }
        }

        public PurchaseMasterRepository PurchaseMaster { 
            get
            {
                if(_purchaseMasterRepository == null)
                    _purchaseMasterRepository = new PurchaseMasterRepository();
                return _purchaseMasterRepository;
            }
        }

        public KapanMasterRepository KapanMasster { 
            get
            {
                if (_kapanMasterRepository == null)
                    _kapanMasterRepository = new KapanMasterRepository();
                return _kapanMasterRepository;
            }
        }

        public ShapeMasterRepository ShapeMaster
        {
            get
            {
                if (_shapeMasterRepository == null)
                    _shapeMasterRepository = new ShapeMasterRepository();
                return _shapeMasterRepository;
            }
        }

        public SizeMasterRepository SizeMaster
        {
            get
            {
                if (_sizeMasterRepository == null)
                    _sizeMasterRepository = new SizeMasterRepository();
                return _sizeMasterRepository;
            }
        }

        public PurityMasterRepository PurityMaster
        {
            get
            {
                if (_purityMasterRepository == null)
                    _purityMasterRepository = new PurityMasterRepository();
                return _purityMasterRepository;
            }
        }

        public GalaMasterRepository GalaMaster
        {
            get
            {
                if (_galaMasterRepository == null)
                    _galaMasterRepository = new GalaMasterRepository();
                return _galaMasterRepository;
            }
        }

        public NumberMasterRepository NumberMaster
        {
            get
            {
                if (_numberMasterRepository == null)
                    _numberMasterRepository = new NumberMasterRepository();
                return _numberMasterRepository;
            }
        }

        public BranchMasterRepository BranchMaster
        {
            get
            {
                if (_branchMasterRepository == null)
                    _branchMasterRepository = new BranchMasterRepository();
                return _branchMasterRepository;
            }
        }

        public BrokerageMasterRepository BrokerageMaster
        {
            get
            {
                if (_brokerageMasterRepository == null)
                    _brokerageMasterRepository = new BrokerageMasterRepository();
                return _brokerageMasterRepository;
            }
        }

        public CompanyMasterRepository CompanyMaster
        {
            get
            {
                if (_companyMasterRepository == null)
                    _companyMasterRepository = new CompanyMasterRepository();
                return _companyMasterRepository;
            }
        }

        public FinancialYearMasterRepository FinancialYearMaster
        {
            get
            {
                if (_financialYearMasterRepository == null)
                    _financialYearMasterRepository = new FinancialYearMasterRepository();
                return _financialYearMasterRepository;
            }
        }

        public LessWeightMasterRepository LessWeightMaster
        {
            get
            {
                if (_lessWeightMasterRepository == null)
                    _lessWeightMasterRepository = new LessWeightMasterRepository();
                return _lessWeightMasterRepository;
            }
        }

        public PartyMasterRepository PartyMaster
        {
            get
            {
                if (_partyMasterRepository == null)
                    _partyMasterRepository = new PartyMasterRepository();
                return _partyMasterRepository;
            }
        }

        public IExpenseMaster ExpenseMasterRepository
        {
            get
            {
                if (_expenseMasterRepository == null)
                    _expenseMasterRepository = new ExpenseMasterRepository();
                return _expenseMasterRepository;
            }
        }

        public ICurrencyMaster CurrencyMasterRepository
        {
            get
            {
                if (_currencyMasterRepository == null)
                    _currencyMasterRepository = new CurrencyMasterRepository();
                return _currencyMasterRepository;
            }
        }
    }
}

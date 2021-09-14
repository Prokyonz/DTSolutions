using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace DiamondTrading
{
    public enum AppMessageID
    {
        #region "Basic commonly used messages"
        OK,
        Cancel,
        Save,
        Update,
        SaveSuccessfully,
        DeleteSuccessfully,
        #endregion
        #region "Access messages"
        InvalidUsername_Password,
        #endregion
        #region "FrmCompanyMaster"
        NewCompany,
        EmptyCompanyName,
        CompanyNameExist,
        AddMoreCompaniesConfirmation,
        DeleteCompanyCofirmation,
        #endregion
        #region "BranchMaster"
        EmptyParentCompanySelection,
        EmptyBranchName,
        EmptyLessWeightGroupSelection,
        BranchNameExist,
        AddMoreBranchConfirmation,
        DeleteBranchCofirmation,
        #endregion
        #region "FrmLessWeightGroupMaster"
        EmptyLessWeightGroupName,
        EmptyMinWeight,
        EmptyMaxWeight,
        EmptyLessWeight,
        LessWeightGroupNameExist,
        AddMoreLessWeightGroupConfirmation,
        EmptyLessWeightGroupItems,
        #endregion
        #region "FrmShapeMaster"
        EmptyShapeName,
        ShapeNameExist,
        AddMoreShapeConfirmation,
        DeleteShapeConfirmation,
        #endregion
        #region "FrmPurityMaster"
        EmptyPurityName,
        PurityNameExist,
        AddMorePurityConfirmation,
        DeletePurityConfirmation,
        #endregion
        #region "FrmSizeMaster"
        EmptySizeName,
        SizeNameExist,
        AddMoreSizeConfirmation,
        DeleteSizeConfirmation,
        #endregion
        #region "FrmGalaMaster"
        EmptyGalaName,
        GalaNameExist,
        AddMoreGalaConfirmation,
        DeleteGalaConfirmation,
        #endregion
        #region "FrmNumberMaster"
        EmptyNumberName,
        NumberNameExist,
        AddMoreNumberConfirmation,
        DeleteNumberConfirmation,
        #endregion
        #region "FrmFinancialYearMaster"
        EmptyFinancialYearName,
        FinancialYearNameExist,
        AddMoreFinancialYearConfirmation,
        DeleteFinancialYearConfirmation,
        #endregion
        #region "FrmBrokerageMaster"
        EmptyBrokerageName,
        BrokerageNameExist,
        AddMoreBrokerageConfirmation,
        DeleteBrokerageConfirmation,
        #endregion
        #region "FrmCurrencyMaster"
        EmptyCurrencyName,
        EmptyCurrencyShortName,
        EmptyCurrencyRate,
        CurrencyNameExist,
        AddMoreCurrencyConfirmation,
        DeleteCurrencyConfirmation,
        #endregion
        AppMessageIDNotFound
    }

    internal class AppMessages
    {
        private static ResourceManager _AppMsg = null;
        public static ResourceManager AppMsg
        {
            get
            {
                if (_AppMsg == null)
                    _AppMsg = new ResourceManager("DTTrading.RunDTTradingMsg", Assembly.GetExecutingAssembly());

                return _AppMsg;
            }
        }

        public static string GetString(AppMessageID ResNameID)
        {
            try
            {
                return AppMsg.GetString(ResNameID.ToString(), Common.AppUICultInfo);
            }
            catch (Exception ex)
            {
                string Msg = GetAppResMessageString(ResNameID);
                if (Msg.Trim().Length != 0)
                    return Msg;
                else
                    throw new Exception("ARS:1 " + " " + AppMessages.GetString(AppMessageID.AppMessageIDNotFound) + " " + ResNameID.ToString() + "\n\n" + ex.Message);
            }
        }

        private static string GetAppResMessageString(AppMessageID MsgCaption)
        {
            string ReturnMsg = string.Empty;
            switch (MsgCaption)
            {
                #region "Basic commonly used messages"
                case AppMessageID.OK:
                    ReturnMsg = "OK";
                    break;
                case AppMessageID.Cancel:
                    ReturnMsg = "Cancel";
                    break;
                case AppMessageID.SaveSuccessfully:
                    ReturnMsg = "Save Successfully.";
                    break;
                case AppMessageID.DeleteSuccessfully:
                    ReturnMsg = "Delete Successfully.";
                    break;
                case AppMessageID.Save:
                    ReturnMsg = "&Save";
                    break;
                case AppMessageID.Update:
                    ReturnMsg = "&Update";
                    break;
                #endregion
                #region "Access messages"
                case AppMessageID.InvalidUsername_Password:
                    ReturnMsg = "Invalid Username/ Password";
                    break;
                #endregion
                #region "FrmCompanyMaster"
                case AppMessageID.NewCompany:
                    ReturnMsg = "NEW COMPANY";
                    break;
                case AppMessageID.EmptyCompanyName:
                    ReturnMsg = "Please write Company Name.";
                    break;
                case AppMessageID.CompanyNameExist:
                    ReturnMsg = "Company Name already exist.";
                    break;
                case AppMessageID.AddMoreCompaniesConfirmation:
                    ReturnMsg = "Do you want to add more companies...?";
                    break;
                case AppMessageID.DeleteCompanyCofirmation:
                    ReturnMsg = "Are you sure you have to delete '{0}' company...?";
                    break;
                #endregion
                #region "Branch Master"
                case AppMessageID.EmptyParentCompanySelection:
                    ReturnMsg = "Parent company is compulsory for Branch create.";
                    break;
                case AppMessageID.EmptyBranchName:
                    ReturnMsg = "Please write Branch Name.";
                    break;
                case AppMessageID.EmptyLessWeightGroupSelection:
                    ReturnMsg = "Please select Less Weight Group for current Branch.";
                    break;
                case AppMessageID.BranchNameExist:
                    ReturnMsg = "Branch Name already exist.";
                    break;
                case AppMessageID.AddMoreBranchConfirmation:
                    ReturnMsg = "Do you want to add more branch...?";
                    break;
                case AppMessageID.DeleteBranchCofirmation:
                    ReturnMsg = "Are you sure you have to delete '{0}' branch...?";
                    break;
                #endregion
                #region "FrmLessWeightGroupMaster"
                case AppMessageID.EmptyLessWeightGroupName:
                    ReturnMsg = "Please write Less Weight Group Name.";
                    break;
                case AppMessageID.EmptyMinWeight:
                    ReturnMsg = "Please enter Min Weight of group.";
                    break;
                case AppMessageID.EmptyMaxWeight:
                    ReturnMsg = "Please enter Max Weight of group.";
                    break;
                case AppMessageID.EmptyLessWeight:
                    ReturnMsg = "Please enter Less Weight of group.";
                    break;
                case AppMessageID.LessWeightGroupNameExist:
                    ReturnMsg = "Less Weight Group Name already exist.";
                    break;
                case AppMessageID.AddMoreLessWeightGroupConfirmation:
                    ReturnMsg = "Do you want to add more Less Weight Groups...?";
                    break;
                case AppMessageID.EmptyLessWeightGroupItems:
                    ReturnMsg = "Please enter some Less Weight Group items.";
                    break;
                #endregion
                #region "FrmShapeMaster"
                case AppMessageID.EmptyShapeName:
                    ReturnMsg = "Please write Shape Name.";
                    break;
                case AppMessageID.ShapeNameExist:
                    ReturnMsg = "Shape Name already exist.";
                    break;
                case AppMessageID.AddMoreShapeConfirmation:
                    ReturnMsg = "Do you want to add more Shapes...?";
                    break;
                case AppMessageID.DeleteShapeConfirmation:
                    ReturnMsg = "Are you sure you have to delete '{0}' Shape...?";
                    break;
                #endregion
                #region "FrmPurityMaster"
                case AppMessageID.EmptyPurityName:
                    ReturnMsg = "Please write Purity Name.";
                    break;
                case AppMessageID.PurityNameExist:
                    ReturnMsg = "Purity Name already exist.";
                    break;
                case AppMessageID.AddMorePurityConfirmation:
                    ReturnMsg = "Do you want to add more Purity...?";
                    break;
                case AppMessageID.DeletePurityConfirmation:
                    ReturnMsg = "Are you sure you have to delete '{0}' Purity...?";
                    break;
                #endregion
                #region "FrmSizeMaster"
                case AppMessageID.EmptySizeName:
                    ReturnMsg = "Please write Size Name.";
                    break;
                case AppMessageID.SizeNameExist:
                    ReturnMsg = "Purity Name already exist.";
                    break;
                case AppMessageID.AddMoreSizeConfirmation:
                    ReturnMsg = "Do you want to add more Size...?";
                    break;
                case AppMessageID.DeleteSizeConfirmation:
                    ReturnMsg = "Are you sure you have to delete '{0}' Size...?";
                    break;
                #endregion
                #region "FrmGalaMaster"
                case AppMessageID.EmptyGalaName:
                    ReturnMsg = "Please write Gala Name.";
                    break;
                case AppMessageID.GalaNameExist:
                    ReturnMsg = "Gala Name already exist.";
                    break;
                case AppMessageID.AddMoreGalaConfirmation:
                    ReturnMsg = "Do you want to add more Galas...?";
                    break;
                case AppMessageID.DeleteGalaConfirmation:
                    ReturnMsg = "Are you sure you have to delete '{0}' Gala...?";
                    break;
                #endregion
                #region "FrmNumberMaster"
                case AppMessageID.EmptyNumberName:
                    ReturnMsg = "Please write Number Name.";
                    break;
                case AppMessageID.NumberNameExist:
                    ReturnMsg = "Number Name already exist.";
                    break;
                case AppMessageID.AddMoreNumberConfirmation:
                    ReturnMsg = "Do you want to add more Numbers...?";
                    break;
                case AppMessageID.DeleteNumberConfirmation:
                    ReturnMsg = "Are you sure you have to delete '{0}' Number...?";
                    break;
                #endregion
                #region "FrmFinancialYearMaster"
                case AppMessageID.EmptyFinancialYearName:
                    ReturnMsg = "Please write Financial Year Name.";
                    break;
                case AppMessageID.FinancialYearNameExist:
                    ReturnMsg = "Financial Year Name already exist.";
                    break;
                case AppMessageID.AddMoreFinancialYearConfirmation:
                    ReturnMsg = "Do you want to add more Financial Years...?";
                    break;
                case AppMessageID.DeleteFinancialYearConfirmation:
                    ReturnMsg = "Are you sure you have to delete '{0}' Financial Year...?";
                    break;
                #endregion
                #region "FrmBrokerageMaster"
                case AppMessageID.EmptyBrokerageName:
                    ReturnMsg = "Please write Brokerage Name.";
                    break;
                case AppMessageID.BrokerageNameExist:
                    ReturnMsg = "Brokerage Name already exist.";
                    break;
                case AppMessageID.AddMoreBrokerageConfirmation:
                    ReturnMsg = "Do you want to add more Brokerage...?";
                    break;
                case AppMessageID.DeleteBrokerageConfirmation:
                    ReturnMsg = "Are you sure you have to delete '{0}' Brokerage...?";
                    break;
                #endregion
                #region "FrmCurrencyMaster"
                case AppMessageID.EmptyCurrencyName:
                    ReturnMsg = "Please write Currency Name.";
                    break;
                case AppMessageID.EmptyCurrencyShortName:
                    ReturnMsg = "Please write Currency Short Name.";
                    break;
                case AppMessageID.EmptyCurrencyRate:
                    ReturnMsg = "Please write Currency Rate.";
                    break;
                case AppMessageID.CurrencyNameExist:
                    ReturnMsg = "Currency Name already exist.";
                    break;
                case AppMessageID.AddMoreCurrencyConfirmation:
                    ReturnMsg = "Do you want to add more Currency...?";
                    break;
                case AppMessageID.DeleteCurrencyConfirmation:
                    ReturnMsg = "Are you sure you have to delete '{0}' Currency...?";
                    break;
                #endregion
                #region "Others"
                case AppMessageID.AppMessageIDNotFound:
                    ReturnMsg = "Message ID Not Found";
                    break;
                default:
                    ReturnMsg = string.Empty;
                    break;
                #endregion
            }
            return ReturnMsg;
        }
    }
}

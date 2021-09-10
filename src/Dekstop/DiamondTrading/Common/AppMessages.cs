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

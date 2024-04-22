using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LandfillServices.UI.Web.UI
{
    public partial class LogisticTurnCollectEdit : System.Web.UI.Page
    {
        public ObjectsFunctions.UpdateDelegate OnUpdated;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                if (Request["ID"] != null)
                {
                    int ContractBorkerID = int.Parse(Request["ID"].ToString());

                    FillValues(ContractBorkerID);
                }
                else
                    DefaultFillValues();

            }
        }
        public int? LogisticTurnCollectID
        {
            get
            {
                if (ViewState["LogisticTurnCollectID"] != null)

                    return int.Parse(ViewState["LogisticTurnCollectID"].ToString());
                else return null;
            }
            set
            {
                ViewState["LogisticTurnCollectID"] = value;
            }
        }

        public void FillValues(int LogisticTurnCollectID)
        {
            this.LogisticTurnCollectID = LogisticTurnCollectID;
            var LogisticTurnCollect = ControllerFunctions.LogisticTurnCollectController.SearchByID(LogisticTurnCollectID);
            Utilities.DropDownListUtilities.FillContractsLogistic(DropDownListContractLogistic, true);
            
            if (LogisticTurnCollect != null)
            {
                LabelDate.Text = LogisticTurnCollect.Date.ToShortDateString();
                DropDownListContractLogistic.SelectedValue = LogisticTurnCollect.ContractsLogisticID.ToString();
                 TextBoxDistance.Text = LogisticTurnCollect.Distance.ToString();
            }
        }
        public void DefaultFillValues()
        {
            Utilities.DropDownListUtilities.FillContractsLogistic(DropDownListContractLogistic, true);
            
            LabelDate.Text = DateTime.Now.ToShortDateString();
            TextBoxDistance.Text = null;

        }


        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            if (this.LogisticTurnCollectID.HasValue)
            {
                var LogisticTurnCollect = ControllerFunctions.LogisticTurnCollectController.SearchByID(this.LogisticTurnCollectID.Value);
 
                ControllerFunctions.LogisticTurnCollectController.Save(LogisticTurnCollect);
                PanelSaveInformations.Visible = true;
                DefaultFillValues();

            }
            else
            {
                var LogisticTurnCollect = new ObjectsFunctions.LogisticTurnCollect();

                if (DropDownListContractLogistic.SelectedIndex <= 0 || string.IsNullOrEmpty(TextBoxDistance.Text))
                {
                    this.PanelControlsValues.Visible = true;
                    return;
                }
                LogisticTurnCollect.Date = DateTime.Now.Date;
                LogisticTurnCollect.ContractsLogisticID = int.Parse(DropDownListContractLogistic.SelectedValue);
               
                LogisticTurnCollect.Distance = decimal.Parse(TextBoxDistance.Text);
                ControllerFunctions.LogisticTurnCollectController.Save(LogisticTurnCollect);

                ObjectsFunctions.LogisticPaymentCommission LogisticPaymentCommission = new ObjectsFunctions.LogisticPaymentCommission();
                LogisticPaymentCommission.Amount = ControllerFunctions.LogisticPaymentCommissionController.CalculateAmountOfCommission(LogisticTurnCollect.ContractsLogistic, LogisticTurnCollect.Date,  LogisticTurnCollect.Distance);
                LogisticPaymentCommission.LogisticTurnCollectID = LogisticTurnCollect.ID;
                ControllerFunctions.LogisticPaymentCommissionController.Save(LogisticPaymentCommission);


                PanelSaveInformations.Visible = true;
                DefaultFillValues();

            }
        }
    }
}
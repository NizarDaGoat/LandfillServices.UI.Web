using LandfillServices.UI.Web.ControllerFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LandfillServices.UI.Web.UI
{
    public partial class ContractsBrokerEdit : System.Web.UI.Page
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
        public int? ContractBrokerID
        {
            get
            {
                if (ViewState["ContractBrokerID"] != null)

                    return int.Parse(ViewState["ContractBrokerID"].ToString());
                else return null;
            }
            set
            {
                ViewState["ContractBrokerID"] = value;
            }
        }

        public void FillValues(int contractBrokerID)
        {
            this.ContractBrokerID = contractBrokerID;
            var contractBroker = ControllerFunctions.ContractsBrokerController.SearchByID(ContractBrokerID.Value);
            Utilities.DropDownListUtilities.FillBrokers(DropDownListBroker, true);
            Utilities.DropDownListUtilities.FillEnumDisplay(DropDownListStatus, typeof(ObjectsFunctions.ContractsBrokerStatus), true);

            if (contractBroker != null)
            {
                TextBoxSubscriptionDate.Text = contractBroker.SubscriptionDate.ToShortDateString();
                LabelNumber.Text = contractBroker.Number;
                if (contractBroker.TerminationDate.HasValue)
                    TextBoxTerminationDate.Text = contractBroker.TerminationDate.Value.ToShortDateString();
                DropDownListBroker.SelectedValue = contractBroker.BrokerID.ToString();
                DropDownListStatus.SelectedValue = ((int)contractBroker.Status).ToString();

                GridViewList.DataSource = getDatasourceContratsBrokerRemuneratedSetting();
                GridViewList.DataBind();

                
                GridViewList.Columns[GridViewList.Columns.Count - 1].Visible = Utilities.UserUtilities.User.Type== 1;
            }
        }
        public void DefaultFillValues()
        {
              Utilities.DropDownListUtilities.FillBrokers(DropDownListBroker, true);
            Utilities.DropDownListUtilities.FillEnumDisplay(DropDownListStatus, typeof(ObjectsFunctions.ContractsBrokerStatus), true);
            Utilities.DropDownListUtilities.FillEnumDisplay(DropDownListProduct, typeof(ObjectsFunctions.ProductName), true);

            TextBoxSubscriptionDate.Text = null;
                LabelNumber.Text = null;
                  TextBoxTerminationDate.Text = null;
                
                GridViewList.Columns[GridViewList.Columns.Count - 1].Visible = Utilities.UserUtilities.User.Type == 1;
            
        }


        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            if (this.ContractBrokerID.HasValue)
            {
                var contractsBroker = ControllerFunctions.ContractsBrokerController.SearchByID(this.ContractBrokerID.Value);
                
              if(string.IsNullOrEmpty(TextBoxTerminationDate.Text)==false)
                contractsBroker.TerminationDate = DateTime.Parse(TextBoxTerminationDate.Text);
                if (DropDownListStatus.SelectedIndex > 0)
                    contractsBroker.Status = (ObjectsFunctions.ContractsBrokerStatus)int.Parse(DropDownListStatus.SelectedValue);

                ControllerFunctions.ContractsBrokerController.Save(contractsBroker);
                PanelSaveInformations.Visible = true;
                FillValues(contractsBroker.ID);

            }
            else
            {
                var contractsBroker = new ObjectsFunctions.ContractsBroker();

                if (DropDownListBroker.SelectedIndex <= 0 || string.IsNullOrEmpty(TextBoxSubscriptionDate.Text))
                {
                    this.PanelControlsValues.Visible = true;
                    return;
                }
                contractsBroker.SubscriptionDate = DateTime.Parse(TextBoxSubscriptionDate.Text);
                contractsBroker.BrokerID = int.Parse(DropDownListBroker.SelectedValue);
                if (DropDownListStatus.SelectedIndex > 0)
                    contractsBroker.Status = (ObjectsFunctions.ContractsBrokerStatus)int.Parse(DropDownListStatus.SelectedValue);

                ControllerFunctions.ContractsBrokerController.Save(contractsBroker);
                PanelSaveInformations.Visible = true;
                FillValues(contractsBroker.ID);

            }
        }

        protected void GridViewList_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewList.SelectedIndex = e.NewSelectedIndex;
            edit(int.Parse(GridViewList.SelectedDataKey.Value.ToString()));
        }


        protected void LinkButtonAdd_Click(object sender, EventArgs e)
        {
            edit(-1);
        }
        public int ContratsBrokerRemuneratedSettingID
        {
            get
            {
                return int.Parse(ViewState["ContratsBrokerRemuneratedSettingID"].ToString());
            }
            set
            {
                ViewState["ContratsBrokerRemuneratedSettingID"] = value;
            }
        }

        private void edit(int contratsBrokerRemuneratedSettingID)
        {
            PanelAdd.Visible = true;
            this.ContratsBrokerRemuneratedSettingID = contratsBrokerRemuneratedSettingID;

            Utilities.DropDownListUtilities.FillEnumDisplay(DropDownListProduct, typeof(ObjectsFunctions.ProductName), true);

            var contratsBrokerRemuneratedSetting =  ControllerFunctions.ContratsBrokerRemuneratedSettingController.SearchByID(ContratsBrokerRemuneratedSettingID);
            
            if (contratsBrokerRemuneratedSetting != null)
            {
                TextBoxDecimalValue.Text = contratsBrokerRemuneratedSetting.Value.ToString();
                TextBoxStartDate.Text = contratsBrokerRemuneratedSetting.StartDate.ToShortDateString();
                if (contratsBrokerRemuneratedSetting.EndDate.HasValue)
                    TextBoxEndDate.Text = contratsBrokerRemuneratedSetting.EndDate.Value.ToShortDateString();
                DropDownListProduct.SelectedValue = ((int)contratsBrokerRemuneratedSetting.ProductName).ToString();
            }
        }

        protected void ButtonSaveParameter_Click(object sender, EventArgs e)
        {
            var contractBroker = ControllerFunctions.ContractsBrokerController.SearchByID(this.ContractBrokerID.Value);
            var contratsBrokerRemuneratedSetting = ControllerFunctions.ContratsBrokerRemuneratedSettingController.SearchByID(this.ContratsBrokerRemuneratedSettingID);
            string typeAction = "";
            if (contratsBrokerRemuneratedSetting == null)
            {
                typeAction = "Nouveau";
                contratsBrokerRemuneratedSetting = new ObjectsFunctions.ContratsBrokerRemuneratedSetting();
                
            }

            contratsBrokerRemuneratedSetting.ContractsBrokerID = this.ContractBrokerID.Value;
            contratsBrokerRemuneratedSetting.Value = Convert.ToDecimal(TextBoxDecimalValue.Text);
            
            contratsBrokerRemuneratedSetting.StartDate = Convert.ToDateTime(TextBoxStartDate.Text);
            if(TextBoxEndDate.Text!=null && TextBoxEndDate.Text!=string.Empty)
            contratsBrokerRemuneratedSetting.EndDate = Convert.ToDateTime(TextBoxEndDate.Text);
            if (DropDownListProduct.SelectedIndex > 0)
                contratsBrokerRemuneratedSetting.ProductName = (ObjectsFunctions.ProductName)int.Parse(DropDownListProduct.SelectedValue);
            ControllerFunctions.ContratsBrokerRemuneratedSettingController.Save(contratsBrokerRemuneratedSetting);
             
             
            FillValues(contratsBrokerRemuneratedSetting.ContractsBroker.ID);

            if (OnUpdated != null)
                OnUpdated();

        }

        private List<ObjectsFunctions.ContratsBrokerRemuneratedSetting> getDatasourceContratsBrokerRemuneratedSetting()
        {
            List<ObjectsFunctions.ContratsBrokerRemuneratedSetting> bllRemurenateList = ControllerFunctions.ContratsBrokerRemuneratedSettingController.SearchByContractBrokerID(this.ContractBrokerID.Value);             

            return bllRemurenateList.ToList();
        }
    }
}
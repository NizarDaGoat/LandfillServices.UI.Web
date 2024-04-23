using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LandfillServices.UI.Web.UI
{
    public partial class ContractsLogisticEdit : System.Web.UI.Page
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
        public int? ContractLogisticID
        {
            get
            {
                if (ViewState["ContractLogisticID"] != null)

                    return int.Parse(ViewState["ContractLogisticID"].ToString());
                else return null;
            }
            set
            {
                ViewState["ContractLogisticID"] = value;
            }
        }

        public void FillValues(int contractLogisticID)
        {
            this.ContractLogisticID = contractLogisticID;
            var contractLogistic = ControllerFunctions.ContractsLogisticController.SearchByID(ContractLogisticID.Value);
            Utilities.DropDownListUtilities.FillLogistics(DropDownListLogistic, true);
            Utilities.DropDownListUtilities.FillEnumDisplay(DropDownListStatus, typeof(ObjectsFunctions.ContractsLogisticStatus), true);

            if (contractLogistic != null)
            {
                TextBoxSubscriptionDate.Text = contractLogistic.SubscriptionDate.ToShortDateString();
                LabelNumber.Text = contractLogistic.Number;
                if (contractLogistic.TerminationDate.HasValue)
                    TextBoxTerminationDate.Text = contractLogistic.TerminationDate.Value.ToShortDateString();
                DropDownListLogistic.SelectedValue = contractLogistic.LogisticID.ToString();
                DropDownListStatus.SelectedValue = ((int)contractLogistic.Status).ToString();

                GridViewList.DataSource = getDatasourceContratsLogisticRemuneratedSetting();
                GridViewList.DataBind();


                GridViewList.Columns[GridViewList.Columns.Count - 1].Visible = Utilities.UserUtilities.User.Type == 1;
            }
        }
        public void DefaultFillValues()
        {
            Utilities.DropDownListUtilities.FillLogistics(DropDownListLogistic, true);
            Utilities.DropDownListUtilities.FillEnumDisplay(DropDownListStatus, typeof(ObjectsFunctions.ContractsLogisticStatus), true);

            TextBoxSubscriptionDate.Text = null;
            LabelNumber.Text = null;
            TextBoxTerminationDate.Text = null;

            GridViewList.Columns[GridViewList.Columns.Count - 1].Visible = Utilities.UserUtilities.User.Type == 1;

        }


        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            if (this.ContractLogisticID.HasValue)
            {
                var contractsLogistic = ControllerFunctions.ContractsLogisticController.SearchByID(this.ContractLogisticID.Value);

                if (string.IsNullOrEmpty(TextBoxTerminationDate.Text) == false)
                    contractsLogistic.TerminationDate = DateTime.Parse(TextBoxTerminationDate.Text);
                if (DropDownListStatus.SelectedIndex > 0)
                    contractsLogistic.Status = (ObjectsFunctions.ContractsLogisticStatus)int.Parse(DropDownListStatus.SelectedValue);

                ControllerFunctions.ContractsLogisticController.Save(contractsLogistic);
                PanelSaveInformations.Visible = true;
                FillValues(contractsLogistic.ID);

            }
            else
            {
                var contractsLogistic = new ObjectsFunctions.ContractsLogistic();

                if (DropDownListLogistic.SelectedIndex <= 0 || string.IsNullOrEmpty(TextBoxSubscriptionDate.Text))
                {
                    this.PanelControlsValues.Visible = true;
                    return;
                }
                contractsLogistic.SubscriptionDate = DateTime.Parse(TextBoxSubscriptionDate.Text);
                contractsLogistic.LogisticID = int.Parse(DropDownListLogistic.SelectedValue);
                if (DropDownListStatus.SelectedIndex > 0)
                    contractsLogistic.Status = (ObjectsFunctions.ContractsLogisticStatus)int.Parse(DropDownListStatus.SelectedValue);

                ControllerFunctions.ContractsLogisticController.Save(contractsLogistic);
                PanelSaveInformations.Visible = true;
                FillValues(contractsLogistic.ID);

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
        public int ContratsLogisticRemuneratedSettingID
        {
            get
            {
                return int.Parse(ViewState["ContratsLogisticRemuneratedSettingID"].ToString());
            }
            set
            {
                ViewState["ContratsLogisticRemuneratedSettingID"] = value;
            }
        }

        private void edit(int contratsLogisticRemuneratedSettingID)
        {
            PanelAdd.Visible = true;
            this.ContratsLogisticRemuneratedSettingID = contratsLogisticRemuneratedSettingID;

            Utilities.DropDownListUtilities.FillEnumDisplay(DropDownListKmInterval, typeof(ObjectsFunctions.KmInterval), true);

            var contratsLogisticRemuneratedSetting = ControllerFunctions.ContratsLogisticsRemuneratedSettingController.SearchByID(ContratsLogisticRemuneratedSettingID);

            if (contratsLogisticRemuneratedSetting != null)
            {
                TextBoxDecimalValue.Text = contratsLogisticRemuneratedSetting.Value.ToString();
                TextBoxStartDate.Text = contratsLogisticRemuneratedSetting.StartDate.ToShortDateString();
                if (contratsLogisticRemuneratedSetting.EndDate.HasValue)
                    TextBoxEndDate.Text = contratsLogisticRemuneratedSetting.EndDate.Value.ToShortDateString();
                DropDownListKmInterval.SelectedValue = ((int)contratsLogisticRemuneratedSetting.KmInterval).ToString();
            }
        }

        protected void ButtonSaveParameter_Click(object sender, EventArgs e)
        {
            var contractLogistic = ControllerFunctions.ContractsLogisticController.SearchByID(this.ContractLogisticID.Value);
            var contratsLogisticRemuneratedSetting = ControllerFunctions.ContratsLogisticsRemuneratedSettingController.SearchByID(this.ContratsLogisticRemuneratedSettingID);
            string typeAction = "";
            if (contratsLogisticRemuneratedSetting == null)
            {
                typeAction = "Nouveau";
                contratsLogisticRemuneratedSetting = new ObjectsFunctions.ContratsLogisticsRemuneratedSetting();

            }

            contratsLogisticRemuneratedSetting.ContractsLogisticsID = this.ContractLogisticID.Value;
            contratsLogisticRemuneratedSetting.Value = Convert.ToDecimal(TextBoxDecimalValue.Text);

            contratsLogisticRemuneratedSetting.StartDate = Convert.ToDateTime(TextBoxStartDate.Text);
            if (TextBoxEndDate.Text != null && TextBoxEndDate.Text != string.Empty)
                contratsLogisticRemuneratedSetting.EndDate = Convert.ToDateTime(TextBoxEndDate.Text);
            if (DropDownListKmInterval.SelectedIndex > 0)
                contratsLogisticRemuneratedSetting.KmInterval = (ObjectsFunctions.KmInterval)int.Parse(DropDownListKmInterval.SelectedValue);
            ControllerFunctions.ContratsLogisticsRemuneratedSettingController.Save(contratsLogisticRemuneratedSetting);


            FillValues(contratsLogisticRemuneratedSetting.ContractsLogistic.ID);

            if (OnUpdated != null)
                OnUpdated();

        }

        private List<ObjectsFunctions.ContratsLogisticsRemuneratedSetting> getDatasourceContratsLogisticRemuneratedSetting()
        {
            List<ObjectsFunctions.ContratsLogisticsRemuneratedSetting> bllRemurenateList = ControllerFunctions.ContratsLogisticsRemuneratedSettingController.SearchByContratLogisticsID(this.ContractLogisticID.Value);

            return bllRemurenateList.ToList();
        }
    }
}
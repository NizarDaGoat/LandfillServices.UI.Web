using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LandfillServices.UI.Web.UI
{
    public partial class BrokerPassageProductEdit : System.Web.UI.Page
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
        public int? BrokerPassageProductID
        {
            get
            {
                if (ViewState["BrokerPassageProductID"] != null)

                    return int.Parse(ViewState["BrokerPassageProductID"].ToString());
                else return null;
            }
            set
            {
                ViewState["BrokerPassageProductID"] = value;
            }
        }

        public void FillValues(int BrokerPassageProductID)
        {
            this.BrokerPassageProductID = BrokerPassageProductID;
            var BrokerPassageProduct = ControllerFunctions.BrokerPassageProductController.SearchByID(BrokerPassageProductID);
            Utilities.DropDownListUtilities.FillContractsBroker(DropDownListContractBroker, true);
            Utilities.DropDownListUtilities.FillEnumDisplay(DropDownListProduct, typeof(ObjectsFunctions.ProductName), true);

            if (BrokerPassageProduct != null)
            {
                LabelDate.Text = BrokerPassageProduct.Date.ToShortDateString();
                 DropDownListContractBroker.SelectedValue = BrokerPassageProduct.ContractsBrokerID.ToString();
                DropDownListProduct.SelectedValue = ((int)BrokerPassageProduct.ProductName).ToString();
                TextBoxWeight.Text = BrokerPassageProduct.Weight.ToString();
            }
        }
        public void DefaultFillValues()
        {
            Utilities.DropDownListUtilities.FillContractsBroker(DropDownListContractBroker, true);
            Utilities.DropDownListUtilities.FillEnumDisplay(DropDownListProduct, typeof(ObjectsFunctions.ProductName), true);

            LabelDate.Text = DateTime.Now.ToShortDateString();
             TextBoxWeight.Text = null;
                        
        }


        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            if (this.BrokerPassageProductID.HasValue)
            {
                var BrokerPassageProduct = ControllerFunctions.BrokerPassageProductController.SearchByID(this.BrokerPassageProductID.Value);

                  if (DropDownListProduct.SelectedIndex > 0)
                    BrokerPassageProduct.ProductName = (ObjectsFunctions.ProductName)int.Parse(DropDownListProduct.SelectedValue);

                ControllerFunctions.BrokerPassageProductController.Save(BrokerPassageProduct);
                PanelSaveInformations.Visible = true;
                DefaultFillValues();

            }
            else
            {
                var BrokerPassageProduct = new ObjectsFunctions.BrokerPassageProduct();

                if (DropDownListContractBroker.SelectedIndex <= 0 || string.IsNullOrEmpty(TextBoxWeight.Text))
                {
                    this.PanelControlsValues.Visible = true;
                    return;
                }
                BrokerPassageProduct.Date = DateTime.Now.Date;
                BrokerPassageProduct.ContractsBrokerID = int.Parse(DropDownListContractBroker.SelectedValue);
                if (DropDownListProduct.SelectedIndex > 0)
                    BrokerPassageProduct.ProductName = (ObjectsFunctions.ProductName)int.Parse(DropDownListProduct.SelectedValue);

                BrokerPassageProduct.Weight= decimal.Parse( TextBoxWeight.Text);
                ControllerFunctions.BrokerPassageProductController.Save(BrokerPassageProduct);

                ObjectsFunctions.BrokerPaymentCommission brokerPaymentCommission = new ObjectsFunctions.BrokerPaymentCommission();
                brokerPaymentCommission.Amount = ControllerFunctions.BrokerPaymentCommissionController.CalculateAmountOfCommission(BrokerPassageProduct.ContractsBroker, BrokerPassageProduct.Date, BrokerPassageProduct.ProductName, BrokerPassageProduct.Weight);
                brokerPaymentCommission.BrokerPassageProductID = BrokerPassageProduct.ID;
          ControllerFunctions.BrokerPaymentCommissionController.Save(brokerPaymentCommission);


                PanelSaveInformations.Visible = true;
                DefaultFillValues();

            }
        }
    }
}
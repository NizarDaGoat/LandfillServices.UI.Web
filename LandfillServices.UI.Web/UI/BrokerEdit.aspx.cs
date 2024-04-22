using LandfillServices.UI.Web.ControllerFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LandfillServices.UI.Web.UI
{
    public partial class BrokerEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                if (Request["ID"] != null)
                {
                    int borkerID = int.Parse(Request["ID"].ToString());

                    FillValues(borkerID);
                }

            }
        }
        public int? BrokerID
        {
            get
            {
                if (ViewState["BrokerID"] != null)

                    return int.Parse(ViewState["BrokerID"].ToString());
                else return null;
            }
            set
            {
                ViewState["BrokerID"] = value;
            }
        }

        public void FillValues(int brokerID)
        {
            this.BrokerID = brokerID;
            var broker = ControllerFunctions.BrokerController.SearchByID(BrokerID.Value);
            if (broker != null)
            {
                TextBoxCompanyCoperate.Text = broker.CompanyCoperateName;
                TextBoxFirstName.Text = broker.FirstName;
                TextBoxLastName.Text = broker.LastName;
                TextBoxPhoneNumber.Text = broker.PhoneNumber;
                TextBoxAddress.Text = broker.Address;
                TextBoxCity.Text = broker.City;
                TextBoxEmail.Text = broker.Email;
                TextBoxCompanyRegistrationNumber.Text = broker.CompanyRegistrationNumber;
                 
            }
        }
 
       
        protected void ButtonSave_Click(object sender, EventArgs e)
        {
           
            if (this.BrokerID.HasValue)
            {
                
                var broker = ControllerFunctions.BrokerController.SearchByID(this.BrokerID.Value);
                if (broker == null)
                    broker = new ObjectsFunctions.Broker();

                broker.CompanyCoperateName = TextBoxCompanyCoperate.Text;
                broker.CompanyName = TextBoxCompanyCoperate.Text;
                broker.FirstName = TextBoxFirstName.Text;
                broker.LastName = TextBoxLastName.Text;
                broker.PhoneNumber = TextBoxPhoneNumber.Text;
                broker.Address = TextBoxAddress.Text;
                broker.City = TextBoxCity.Text;
                broker.Email = TextBoxEmail.Text;
                broker.CompanyRegistrationNumber = TextBoxCompanyRegistrationNumber.Text;
                
                ControllerFunctions.BrokerController.Save(broker);
                PanelSaveInformations.Visible = true;
                FillValues(broker.ID);

            }
            else
            {
                var user = ControllerFunctions.LandfilluserController.SearchByLogin(TextBoxEmail.Text);
                if (user != null)
                {
                    PanelEmailExisting.Visible = true;
                    return;
                }
                else
                {
                    PanelEmailExisting.Visible = false;
                }
                var broker = new ObjectsFunctions.Broker();

                broker.CompanyCoperateName = TextBoxCompanyCoperate.Text;
                broker.CompanyName = TextBoxCompanyCoperate.Text;
                broker.FirstName = TextBoxFirstName.Text;
                broker.LastName = TextBoxLastName.Text;
                broker.PhoneNumber = TextBoxPhoneNumber.Text;
                broker.Address = TextBoxAddress.Text;
                broker.City = TextBoxCity.Text;
                broker.Email = TextBoxEmail.Text;
                broker.CompanyRegistrationNumber = TextBoxCompanyRegistrationNumber.Text;

                ControllerFunctions.BrokerController.Save(broker);
                broker.InternalCode = broker.CurrentBrokerInternalCode;
                ControllerFunctions.BrokerController.Save(broker);
                PanelSaveInformations.Visible = true;
                FillValues(broker.ID);
            }
        }
        
    }
}
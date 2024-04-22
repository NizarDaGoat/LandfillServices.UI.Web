using LandfillServices.UI.Web.ControllerFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LandfillServices.UI.Web.UI
{
    public partial class LogisticEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                if (Request["ID"] != null)
                {
                    int logisticID = int.Parse(Request["ID"].ToString());

                    FillValues(logisticID);
                }

            }
        }
        public int? LogisticID
        {
            get
            {
                if (ViewState["LogisticID"] != null)

                    return int.Parse(ViewState["LogisticID"].ToString());
                else return null;
            }
            set
            {
                ViewState["LogisticID"] = value;
            }
        }

        public void FillValues(int logisticID)
        {
            this.LogisticID = logisticID;
            var logistic = ControllerFunctions.LogisticController.SearchByID(LogisticID.Value);
            if (logistic != null)
            {
                TextBoxCompanyCoperate.Text = logistic.CompanyCoperateName;
                TextBoxFirstName.Text = logistic.FirstName;
                TextBoxLastName.Text = logistic.LastName;
                TextBoxPhoneNumber.Text = logistic.PhoneNumber;
                TextBoxAddress.Text = logistic.Address;
                TextBoxCity.Text = logistic.City;
                TextBoxEmail.Text = logistic.Email;
                TextBoxCompanyRegistrationNumber.Text = logistic.CompanyRegistrationNumber;

            }
        }

       
        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            if (this.LogisticID.HasValue)
            {
                var Logistic = ControllerFunctions.LogisticController.SearchByID(this.LogisticID.Value);
                if (Logistic == null)
                    Logistic = new ObjectsFunctions.Logistic();

                Logistic.CompanyCoperateName = TextBoxCompanyCoperate.Text;
                Logistic.CompanyName = TextBoxCompanyCoperate.Text;
                Logistic.FirstName = TextBoxFirstName.Text;
                Logistic.LastName = TextBoxLastName.Text;
                Logistic.PhoneNumber = TextBoxPhoneNumber.Text;
                Logistic.Address = TextBoxAddress.Text;
                Logistic.City = TextBoxCity.Text;
                Logistic.Email = TextBoxEmail.Text;
                Logistic.CompanyRegistrationNumber = TextBoxCompanyRegistrationNumber.Text;

                ControllerFunctions.LogisticController.Save(Logistic);
                Logistic.InternalCode = Logistic.CurrentLogisticInternalCode;
                ControllerFunctions.LogisticController.Save(Logistic);
                PanelSaveInformations.Visible = true;
                FillValues(Logistic.ID);

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

                var Logistic = new ObjectsFunctions.Logistic();

                Logistic.CompanyCoperateName = TextBoxCompanyCoperate.Text;
                Logistic.CompanyName = TextBoxCompanyCoperate.Text;
                Logistic.FirstName = TextBoxFirstName.Text;
                Logistic.LastName = TextBoxLastName.Text;
                Logistic.PhoneNumber = TextBoxPhoneNumber.Text;
                Logistic.Address = TextBoxAddress.Text;
                Logistic.City = TextBoxCity.Text;
                Logistic.Email = TextBoxEmail.Text;
                Logistic.CompanyRegistrationNumber = TextBoxCompanyRegistrationNumber.Text;

                ControllerFunctions.LogisticController.Save(Logistic);
                PanelSaveInformations.Visible = true;
                FillValues(Logistic.ID);
            }
        }
    }
}
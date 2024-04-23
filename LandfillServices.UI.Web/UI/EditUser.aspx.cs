using LandfillServices.UI.Web.ControllerFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using LandfillServices.UI.Web.Utilities;

namespace LandfillServices.UI.Web.UI
{
    public partial class EditUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                if (Request["ID"] != null)
                {
                    int landfillUserID = int.Parse(Request["ID"].ToString());

                    FillValues(landfillUserID);
                }

            }
        }
        public int? LandfillUserID
        {
            get
            {
                if (ViewState["LandfillUserID"] != null)

                    return int.Parse(ViewState["LandfillUserID"].ToString());
                else return null;
            }
            set
            {
                ViewState["LandfillUserID"] = value;
            }
        }

        public void FillValues(int landfillUserID)
        {
            this.LandfillUserID = landfillUserID;
            var landfillUser = ControllerFunctions.LandfilluserController.SearchByID(LandfillUserID.Value);
            if (landfillUser != null)
            {
                TextBoxCompanyCoperate.Text = landfillUser.CompanyCoperateName;
                TextBoxFirstName.Text = landfillUser.FirstName;
                TextBoxLastName.Text = landfillUser.LastName;
                TextBoxPhoneNumber.Text = landfillUser.PhoneNumber;
                TextBoxAddress.Text = landfillUser.Address;
                TextBoxCity.Text = landfillUser.City;
                TextBoxEmail.Text = landfillUser.Email;
               // TextBoxPassword.Text = landfillUser.Password;
                if (landfillUser.Type == 1)
                    RadioButtonListUserType.SelectedValue = "1";
                else if (landfillUser.Type == 2)
                    RadioButtonListUserType.SelectedValue = "2";
                else if (landfillUser.Type == 3)
                    RadioButtonListUserType.SelectedValue = "3";

                RepeaterListPassageLandfill.DataSource = getDataUser();
                RepeaterListPassageLandfill.DataBind();

            }
        }

        private List<ObjectsFunctions.PassageLandfill> getDataUser()
        {
            var passageLandfillList = ControllerFunctions.PassageLandfillController.SearchByUserID(this.LandfillUserID.Value);

            return passageLandfillList;
        }
        public void FillValues()
        {
            RepeaterListPassageLandfill.DataSource = getDataUser();
            RepeaterListPassageLandfill.DataBind();
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            

            if (this.LandfillUserID.HasValue)
            {
                var landfillUser = ControllerFunctions.LandfilluserController.SearchByID(this.LandfillUserID.Value);
                if (landfillUser == null)
                    landfillUser = new ObjectsFunctions.LandfillUser();

                landfillUser.CompanyCoperateName = TextBoxCompanyCoperate.Text;
                landfillUser.FirstName = TextBoxFirstName.Text;
                landfillUser.LastName = TextBoxLastName.Text;
                landfillUser.PhoneNumber = TextBoxPhoneNumber.Text;
                landfillUser.Address = TextBoxAddress.Text;
                landfillUser.City = TextBoxCity.Text;
                landfillUser.Email = TextBoxEmail.Text;
               
                if (RadioButtonListUserType.SelectedValue == "1")
                    landfillUser.Type = 1;
                else if (RadioButtonListUserType.SelectedValue == "2")
                    landfillUser.Type = 2;
                else if (RadioButtonListUserType.SelectedValue == "3")
                    landfillUser.Type = 3;
                ControllerFunctions.LandfilluserController.Save(landfillUser);
                PanelSaveInformations.Visible = true;
                FillValues(landfillUser.ID);

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

                var landfillUser = new ObjectsFunctions.LandfillUser();

                landfillUser.CompanyCoperateName = TextBoxCompanyCoperate.Text;
                landfillUser.FirstName = TextBoxFirstName.Text;
                landfillUser.LastName = TextBoxLastName.Text;
                landfillUser.PhoneNumber = TextBoxPhoneNumber.Text;
                landfillUser.Address = TextBoxAddress.Text;
                landfillUser.City = TextBoxCity.Text;
                landfillUser.Email = TextBoxEmail.Text;
               
                landfillUser.Password = BCrypt.Net.BCrypt.HashPassword(TextBoxPassword.Text);
                if (RadioButtonListUserType.SelectedValue == "1")
                    landfillUser.Type = 1;
                else if (RadioButtonListUserType.SelectedValue == "2")
                    landfillUser.Type = 2;
                else if (RadioButtonListUserType.SelectedValue == "3")
                    landfillUser.Type = 3;
                ControllerFunctions.LandfilluserController.Save(landfillUser);
                PanelSaveInformations.Visible = true;
                FillValues(landfillUser.ID);
            }


        }

        protected void ButtonSavePassage_Click(object sender, EventArgs e)
        {
            var passagelandfill = new ObjectsFunctions.PassageLandfill();
            if (!string.IsNullOrEmpty(TextBoxDateOfPassage.Text) && !string.IsNullOrEmpty(RadioButtonListPay.SelectedValue))
            { 
                passagelandfill.DateOfPassage = DateTime.Parse(TextBoxDateOfPassage.Text);

                passagelandfill.Pay = int.Parse(RadioButtonListPay.SelectedValue);
                passagelandfill.UserID= this.LandfillUserID.Value; 

                ControllerFunctions.PassageLandfillController.Save(passagelandfill);
                PanelSaveInformations.Visible = true;
                FillValues();
            }

        }
    }
}
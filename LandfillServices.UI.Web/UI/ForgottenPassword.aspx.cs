using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LandfillServices.UI.Web.UI
{
    public partial class ForgottenPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            var landfillUser = ControllerFunctions.LandfilluserController.SearchByLogin(TextBoxEmail.Text);
            if(landfillUser != null)
            {
                PanelControlEmailUserExiste.Visible = false;

                if (TextBoxPassword.Text!=TextBoxPassword2.Text)
                {
                    PanelCheckPassword.Visible = true;
                    return;
                }
                    
                 landfillUser.Password = BCrypt.Net.BCrypt.HashPassword(TextBoxPassword.Text);
                
                ControllerFunctions.LandfilluserController.Save(landfillUser);

                Response.Redirect("/UI/Login.aspx");
            }
            else
            {
                PanelControlEmailUserExiste.Visible = true;
                PanelCheckPassword.Visible = false;
                return;
            }
           

        }
    }
}
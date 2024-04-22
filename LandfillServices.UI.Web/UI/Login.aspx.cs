using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LandfillServices.UI.Web.UI
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string login = null, psw = null;
            login = TextBoxLogin.Text;
            psw = TextBoxPassword.Text;
 
            var user = ControllerFunctions.LandfilluserController.SearchByLoginAndPsw(login, psw);

            if (user != null)
            {
                HttpContext.Current.User = user;
                System.Web.Security.FormsAuthentication.SetAuthCookie(User.Identity.Name, false);

                if (user.Type == 1 || user.Type == 2) //if administrator or operator
                {
                    Response.Redirect("/UI/StatistiquesData.aspx");
                }
                else if (user.Type == 3)
                {
                    Response.Redirect("/UI/PassageLandfillListByUser.aspx");

                }
            }
            else
            {
                HttpContext.Current.User = null;
                this.divErrorConnection.Visible = true;
                return;
            }

        }
        public static ObjectsFunctions.LandfillUser User
        {
            get
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                    return HttpContext.Current.User as ObjectsFunctions.LandfillUser;
                return null;
            }
        }
        protected void validateLoginPassword(object source, ServerValidateEventArgs args)
        {

        }

        protected void LinkButtonLostPassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("/UI/ForgottenPassword.aspx");
        }

        protected void LinkButtonRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("/UI/Register.aspx");
        }
    }
}
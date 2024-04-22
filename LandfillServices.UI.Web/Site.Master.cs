using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LandfillServices.UI.Web
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = ControllerFunctions.LandfilluserController.SearchByID(int.Parse(HttpContext.Current.User.Identity.Name)); 

            if (user == null)
                return; 
            //Searches for the User/client by ID if its not there it will send them back to the previous page.
            else
            {
                if(user.Type== 1 || user.Type==2) //if administrator or operator
                {
                    this.PassageOfLandfillListByUserID.Visible = false;
                    this.EditUser.Visible = true;
                    this.PassageOfLandfillList.Visible = true;
                    this.UserList.Visible = true;
                }
               else if (user.Type == 3) //if public
                {
                    this.PassageOfLandfillListByUserID.Visible = true;
                    this.EditUser.Visible = false;
                    this.PassageOfLandfillList.Visible = false;
                    this.UserList.Visible = false;
                }
            }
        }

        protected void LinkButtonDeconnexion_Click(object sender, EventArgs e)
        {
            HttpContext.Current.User = null;
            System.Web.Security.FormsAuthentication.SignOut();
            Response.Redirect("/UI/Login.aspx"); 
            //Sends them back to the Login page
        }
    }
}
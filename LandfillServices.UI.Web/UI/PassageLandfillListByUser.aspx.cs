using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LandfillServices.UI.Web.UI
{
    public partial class PassageLandfillListByUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int landfillUserID = int.Parse( HttpContext.Current.User.Identity.Name); 
            FillValues( landfillUserID );
        }
       
        private List<ObjectsFunctions.PassageLandfill> getDataUser(int landfillUserID)
        {
            var passageLandfill = ControllerFunctions.PassageLandfillController.SearchByUserID(landfillUserID);

            return passageLandfill;
        }

        public void FillValues(int landfillUserID)
        {
            RepeaterListPassageLandfill.DataSource = getDataUser(landfillUserID);
            RepeaterListPassageLandfill.DataBind();
        }
    }
}
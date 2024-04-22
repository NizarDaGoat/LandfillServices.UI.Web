using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LandfillServices.UI.Web.UI
{
    public partial class PassageLandfillList : System.Web.UI.Page
    {
         protected void Page_Load(object sender, EventArgs e)
        {
            FillValues();
        }

        private List<ObjectsFunctions.PassageLandfill> getDataUser()
        {
           var passageLandfill = ControllerFunctions.PassageLandfillController.SearchAll();

            return passageLandfill;
        }
         
        public void FillValues()
        {
            RepeaterListPassageLandfill.DataSource = getDataUser();
            RepeaterListPassageLandfill.DataBind();
        }
    }
}
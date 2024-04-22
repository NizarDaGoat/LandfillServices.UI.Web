using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LandfillServices.UI.Web.UI
{
    public partial class LogisticList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillValues();
        }

        private List<ObjectsFunctions.Logistic> getDataUser()
        {
            var logisticsList = ControllerFunctions.LogisticController.SearchAll();

            return logisticsList;
        }

        public void FillValues()
        {
            RepeaterListUser.DataSource = getDataUser();
            RepeaterListUser.DataBind();
        }
    }
}
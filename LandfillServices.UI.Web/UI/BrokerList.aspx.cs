using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LandfillServices.UI.Web.UI
{
    public partial class BrokerList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillValues();
        }

        private List<ObjectsFunctions.Broker> getDataUser()
        {
            var brokersList = ControllerFunctions.BrokerController.SearchAll();

            return brokersList;
        }

        public void FillValues()
        {
            RepeaterListUser.DataSource = getDataUser();
            RepeaterListUser.DataBind();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LandfillServices.UI.Web.UI
{
    public partial class BrokerPaymentCommissionList : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            FillValues();
        }

        private List<ObjectsFunctions.BrokerPaymentCommission> getDataUser()
        {
            var BrokerPaymentCommissionList = ControllerFunctions.BrokerPaymentCommissionController.SearchAll();

            return BrokerPaymentCommissionList;
        }

        public void FillValues()
        {
            RepeaterListCommissions.DataSource = getDataUser();
            RepeaterListCommissions.DataBind();
        }
    }
}
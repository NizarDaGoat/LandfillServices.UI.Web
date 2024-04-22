using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LandfillServices.UI.Web.UI
{
    public partial class LogisticPaymentCommissionList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillValues();
        }

        private List<ObjectsFunctions.LogisticPaymentCommission> getDataUser()
        {
            var LogisticPaymentCommissionList = ControllerFunctions.LogisticPaymentCommissionController.SearchAll();

            return LogisticPaymentCommissionList;
        }

        public void FillValues()
        {
            RepeaterListCommissions.DataSource = getDataUser();
            RepeaterListCommissions.DataBind();
        }
    }
}
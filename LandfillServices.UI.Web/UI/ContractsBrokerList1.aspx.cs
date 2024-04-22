using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LandfillServices.UI.Web.UI
{
    public partial class ContractsBrokerList1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillValues();
        }

        private List<ObjectsFunctions.ContractsBroker> getDataUser()
        {
            var ContractsBrokersList = ControllerFunctions.ContractsBrokerController.SearchAll();

            return ContractsBrokersList;
        }

        public void FillValues()
        {
            RepeaterListContractsBroker.DataSource = getDataUser();
            RepeaterListContractsBroker.DataBind();
        }
    }
}
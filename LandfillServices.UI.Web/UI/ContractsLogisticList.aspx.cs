using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LandfillServices.UI.Web.UI
{
    public partial class ContractsLogisticList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillValues();
        }

        private List<ObjectsFunctions.ContractsLogistic> getDataUser()
        {
            var ContractsLogisticsList = ControllerFunctions.ContractsLogisticController.SearchAll();

            return ContractsLogisticsList;
        }

        public void FillValues()
        {
            RepeaterListContractsLogistic.DataSource = getDataUser();
            RepeaterListContractsLogistic.DataBind();
        }
    }
}
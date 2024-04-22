using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LandfillServices.UI.Web.UI
{
    public partial class BrokerPassageProductList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillValues();
        }

        private List<ObjectsFunctions.BrokerPassageProduct> getDataSource()
        {
            var passageLandfill = ControllerFunctions.BrokerPassageProductController.SearchAll();

            return passageLandfill;
        }

        public void FillValues()
        {
            RepeaterListPassage.DataSource = getDataSource();
            RepeaterListPassage.DataBind();
        }
    }
}
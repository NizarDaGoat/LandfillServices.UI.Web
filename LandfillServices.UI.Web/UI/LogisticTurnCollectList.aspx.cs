using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LandfillServices.UI.Web.UI
{
    public partial class LogisticTurnCollectList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillValues();
        }

        private List<ObjectsFunctions.LogisticTurnCollect> getDataSource()
        {
            var passageLandfill = ControllerFunctions.LogisticTurnCollectController.SearchAll();

            return passageLandfill;
        }

        public void FillValues()
        {
            RepeaterListTurn.DataSource = getDataSource();
            RepeaterListTurn.DataBind();
        }
    }
}
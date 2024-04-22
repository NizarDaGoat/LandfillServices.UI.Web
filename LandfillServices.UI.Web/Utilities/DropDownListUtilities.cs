using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace LandfillServices.UI.Web.Utilities
{
    public class DropDownListUtilities
    {
        public static void FillEnumDisplay(DropDownList dropDownList, Type type, bool notSetPossible)
        {
            if (dropDownList == null)
                return;

            dropDownList.Items.Clear();
            if (notSetPossible == true)
                dropDownList.Items.Add(new ListItem("---", "-1"));
            var enumDisplayList = ControllerFunctions.EnumDisplayController.SearchByEnumType(type);
            foreach (ObjectsFunctions.EnumDisplay enumDisplay in enumDisplayList)
                dropDownList.Items.Add(new ListItem(enumDisplay?.Display?.ToString(), enumDisplay?.Key.ToString()));
        }
        public static void FillBrokers(DropDownList dropDownList, bool notSetPossible)
        {
            dropDownList.Items.Clear();
            if (notSetPossible == true)
                dropDownList.Items.Add(new ListItem("---", null));

            var list = from bllBroker in ControllerFunctions.BrokerController.SearchAll()
                       orderby bllBroker.CompanyCoperateName
                       select bllBroker;

            foreach (ObjectsFunctions.Broker broker in list.ToList())
                dropDownList.Items.Add(new ListItem(broker.CompanyCoperateName, broker.ID.ToString()));
        }

        public static void FillContractsBroker( DropDownList dropDownList, bool notSetPossible)
        {
            dropDownList.Items.Clear();
            if (notSetPossible == true)
                dropDownList.Items.Add(new ListItem("---", Guid.Empty.ToString()));

              var list = from bllContrat in ControllerFunctions.ContractsBrokerController.SearchAll()
                          orderby bllContrat.Number
                       select bllContrat;

            foreach (ObjectsFunctions.ContractsBroker contract in list.ToList())
            {
                  dropDownList.Items.Add(new ListItem(contract.Number + " " + "[" + contract.Broker.CompanyCoperateName + "]", contract.ID.ToString()));
                
            }
        }

        public static void FillLogistics(DropDownList dropDownList, bool notSetPossible)
        {
            dropDownList.Items.Clear();
            if (notSetPossible == true)
                dropDownList.Items.Add(new ListItem("---", null));

            var list = from bllLogistic in ControllerFunctions.LogisticController.SearchAll()
                       orderby bllLogistic.CompanyCoperateName
                       select bllLogistic;

            foreach (ObjectsFunctions.Logistic Logistic in list.ToList())
                dropDownList.Items.Add(new ListItem(Logistic.CompanyCoperateName, Logistic.ID.ToString()));
        }

        public static void FillContractsLogistic(DropDownList dropDownList, bool notSetPossible)
        {
            dropDownList.Items.Clear();
            if (notSetPossible == true)
                dropDownList.Items.Add(new ListItem("---", Guid.Empty.ToString()));

            var list = from bllContrat in ControllerFunctions.ContractsLogisticController.SearchAll()
                       orderby bllContrat.Number
                       select bllContrat;

            foreach (ObjectsFunctions.ContractsLogistic contract in list.ToList())
            {
                dropDownList.Items.Add(new ListItem(contract.Number + " " + "[" + contract.Logistic.CompanyCoperateName + "]", contract.ID.ToString()));

            }
        }
    }
}
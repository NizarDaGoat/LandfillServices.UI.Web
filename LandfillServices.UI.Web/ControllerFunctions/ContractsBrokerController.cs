using LandfillServices.UI.Web.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandfillServices.UI.Web.ControllerFunctions
{
    public class ContractsBrokerController
    {
        public static ObjectsFunctions.ContractsBroker SearchByID(int ID)
        {
            DataClassesLandfillDataContext context = Configuration.GetContext();
            LandfillServices.UI.Web.SQL.ContractsBroker sqlContractsBroker = context.ContractsBrokers.SingleOrDefault(a => a.ID == ID);
            if (sqlContractsBroker != null)
                return new ObjectsFunctions.ContractsBroker(sqlContractsBroker);
            return null;
        }
        public static List<ObjectsFunctions.ContractsBroker> SearchAll()
        {

            DataClassesLandfillDataContext context = Configuration.GetContext();
            var q = (from ContractsBroker in context.ContractsBrokers

                     select new ObjectsFunctions.ContractsBroker(ContractsBroker));
            return q.ToList();
        }
        public static List<ObjectsFunctions.ContractsBroker> SearchByBrokerID(int brokerID)
        {

            DataClassesLandfillDataContext context = Configuration.GetContext();
            var q = (from ContractsBroker in context.ContractsBrokers
                     where ContractsBroker.BrokerID == brokerID
                     select new ObjectsFunctions.ContractsBroker(ContractsBroker));
            return q.ToList();
        }

        /// <summary>
        /// calling the property of the nomenclature of the contract number
        /// </summary>
        /// <param name="contractsBroker"></param>
        /// <returns></returns>
        public static string GetNewContractNumber(ObjectsFunctions.ContractsBroker contractsBroker)
        {
            return contractsBroker.CurrentContractNumber;
        }
        public static void Insert(ObjectsFunctions.ContractsBroker ContractsBroker)
        {

            DataClassesLandfillDataContext context = Configuration.GetContext();
            context.ContractsBrokers.InsertOnSubmit(ContractsBroker.d_ContractsBroker);
            context.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
        }

        public static void Update(ObjectsFunctions.ContractsBroker ContractsBroker)
        {
            DataClassesLandfillDataContext context = LandfillServices.UI.Web.SQL.Configuration.GetContext();

            LandfillServices.UI.Web.SQL.ContractsBroker d_ContractsBroker = context.ContractsBrokers.Single(a => a.ID == ContractsBroker.d_ContractsBroker.ID);
            if (d_ContractsBroker != null)
            {
                ObjectsFunctions.ContractsBroker contextContractsBroker = new ObjectsFunctions.ContractsBroker(d_ContractsBroker);
                Utilities.PropertyHandler.CopyTo<ObjectsFunctions.ContractsBroker>(ContractsBroker, contextContractsBroker);
                contextContractsBroker.d_ContractsBroker.Updated = DateTime.Now;
                context.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
            }
        }

        public static void Delete(ObjectsFunctions.ContractsBroker ContractsBroker)
        {

            DataClassesLandfillDataContext context = Configuration.GetContext();

            LandfillServices.UI.Web.SQL.ContractsBroker d_ContractsBroker = context.ContractsBrokers.Single(a => a.ID == ContractsBroker.d_ContractsBroker.ID);
            if (ContractsBroker != null)
            {
                context.ContractsBrokers.DeleteOnSubmit(ContractsBroker.d_ContractsBroker);
                context.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
                ContractsBroker = null;
            }
        }

        public static void Save(ObjectsFunctions.ContractsBroker ContractsBroker)
        {

            if (ContractsBroker.ID == 0)
            {
                Insert(ContractsBroker);
                ContractsBroker.Number = ContractsBrokerController.GetNewContractNumber(ContractsBroker);
                Update(ContractsBroker);
            }
            else
                Update(ContractsBroker);

        }

    }
}
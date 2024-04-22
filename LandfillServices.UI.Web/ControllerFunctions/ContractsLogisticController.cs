using LandfillServices.UI.Web.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandfillServices.UI.Web.ControllerFunctions
{
    public class ContractsLogisticController
    {
        public static ObjectsFunctions.ContractsLogistic SearchByID(int ID)
        {
            DataClassesLandfillDataContext context = Configuration.GetContext();
            LandfillServices.UI.Web.SQL.ContractsLogistic sqlContractsLogistic = context.ContractsLogistics.SingleOrDefault(a => a.ID == ID);
            if (sqlContractsLogistic != null)
                return new ObjectsFunctions.ContractsLogistic(sqlContractsLogistic);
            return null;
        }
        public static List<ObjectsFunctions.ContractsLogistic> SearchAll()
        {

            DataClassesLandfillDataContext context = Configuration.GetContext();
            var q = (from ContractsLogistic in context.ContractsLogistics

                     select new ObjectsFunctions.ContractsLogistic(ContractsLogistic));
            return q.ToList();
        }
        public static List<ObjectsFunctions.ContractsLogistic> SearchByLogisticID(int logisticID)
        {

            DataClassesLandfillDataContext context = Configuration.GetContext();
            var q = (from ContractsLogistic in context.ContractsLogistics
                     where ContractsLogistic.LogisticsID == logisticID
                     select new ObjectsFunctions.ContractsLogistic(ContractsLogistic));
            return q.ToList();
        }

        /// <summary>
        /// calling the property of the nomenclature of the contract number
        /// </summary>
        /// <param name="contractsLogistic"></param>
        /// <returns></returns>
        public static string GetNewContractNumber(ObjectsFunctions.ContractsLogistic contractsLogistic)
        {
            return contractsLogistic.CurrentContractNumber;
        }
        public static void Insert(ObjectsFunctions.ContractsLogistic ContractsLogistic)
        {

            DataClassesLandfillDataContext context = Configuration.GetContext();
            context.ContractsLogistics.InsertOnSubmit(ContractsLogistic.d_ContractsLogistic);
            context.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
        }

        public static void Update(ObjectsFunctions.ContractsLogistic ContractsLogistic)
        {
            DataClassesLandfillDataContext context = Configuration.GetContext();

            LandfillServices.UI.Web.SQL.ContractsLogistic d_ContractsLogistic = context.ContractsLogistics.Single(a => a.ID == ContractsLogistic.ID);
            if (d_ContractsLogistic != null)
            {
                ObjectsFunctions.ContractsLogistic contextContractsLogistic = new ObjectsFunctions.ContractsLogistic(d_ContractsLogistic);
                Utilities.PropertyHandler.CopyTo<ObjectsFunctions.ContractsLogistic>(ContractsLogistic, contextContractsLogistic);
                contextContractsLogistic.d_ContractsLogistic.Updated = DateTime.Now;
                context.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
            }
        }

        public static void Delete(ObjectsFunctions.ContractsLogistic ContractsLogistic)
        {

            DataClassesLandfillDataContext context = Configuration.GetContext();

            LandfillServices.UI.Web.SQL.ContractsLogistic d_ContractsLogistic = context.ContractsLogistics.Single(a => a.ID == ContractsLogistic.d_ContractsLogistic.ID);
            if (ContractsLogistic != null)
            {
                context.ContractsLogistics.DeleteOnSubmit(ContractsLogistic.d_ContractsLogistic);
                context.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
                ContractsLogistic = null;
            }
        }

        public static void Save(ObjectsFunctions.ContractsLogistic ContractsLogistic)
        {

            if (ContractsLogistic.ID == 0)
            {
                Insert(ContractsLogistic);
                ContractsLogistic.Number = ContractsLogisticController.GetNewContractNumber(ContractsLogistic);
                Update(ContractsLogistic);
            }
            else
                Update(ContractsLogistic);

        }

    }
}
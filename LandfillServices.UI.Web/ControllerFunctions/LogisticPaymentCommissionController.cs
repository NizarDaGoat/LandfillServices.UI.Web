using LandfillServices.UI.Web.ObjectsFunctions;
using LandfillServices.UI.Web.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandfillServices.UI.Web.ControllerFunctions
{
    public class LogisticPaymentCommissionController
    {
        public static ObjectsFunctions.LogisticPaymentCommission SearchByID(int ID)
        {
            DataClassesLandfillDataContext context = Configuration.GetContext();
            LandfillServices.UI.Web.SQL.LogisticPaymentCommission sqlLogisticPaymentCommission = context.LogisticPaymentCommissions.SingleOrDefault(a => a.ID == ID);
            if (sqlLogisticPaymentCommission != null)
                return new ObjectsFunctions.LogisticPaymentCommission(sqlLogisticPaymentCommission);
            return null;
        }
        public static List<ObjectsFunctions.LogisticPaymentCommission> SearchAll()
        {

            DataClassesLandfillDataContext context = Configuration.GetContext();
            var q = (from LogisticPaymentCommission in context.LogisticPaymentCommissions

                     select new ObjectsFunctions.LogisticPaymentCommission(LogisticPaymentCommission));
            return q.ToList();
        }
        public static List<ObjectsFunctions.LogisticPaymentCommission> SearchByLogisticTurnCollectID(int logisticTurnCollectID)
        {

            DataClassesLandfillDataContext context = Configuration.GetContext();
            var q = (from LogisticPaymentCommission in context.LogisticPaymentCommissions
                     where LogisticPaymentCommission.LogisticTurnCollectID == logisticTurnCollectID
                     select new ObjectsFunctions.LogisticPaymentCommission(LogisticPaymentCommission));
            return q.ToList();
        }

        public static List<ObjectsFunctions.LogisticPaymentCommission> SearchByLogisticID(int LogisticID)
        {

            DataClassesLandfillDataContext context = Configuration.GetContext();
            var q = (from LogisticPaymentCommission in context.LogisticPaymentCommissions
                     where LogisticPaymentCommission.LogisticTurnCollect.ContractsLogistic.LogisticsID == LogisticID
                     select new ObjectsFunctions.LogisticPaymentCommission(LogisticPaymentCommission));
            return q.ToList();
        }

        /// <summary>
        /// Calculate Amount Of Commission
        /// </summary>
        /// <param name="contractsLogistic"></param>
        /// <param name="date"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public static decimal CalculateAmountOfCommission(ObjectsFunctions.ContractsLogistic contractsLogistic, DateTime date, decimal distance)
        {
            ObjectsFunctions.KmInterval kmInterval = KmInterval.Between_1_and_50;
        
            if (distance>=0 && distance<=50)
                kmInterval = KmInterval.Between_1_and_50;
            else if (distance > 50 && distance <= 100)
                kmInterval = KmInterval.Between_51_and_100;
            else if (distance > 100)
                kmInterval = KmInterval.Greater_100;

            var remurenateLogisticList = ControllerFunctions.ContratsLogisticsRemuneratedSettingController.SearchByContractLogisticID_And_Date_And_Product(contractsLogistic.ID, date, kmInterval);
            if (remurenateLogisticList.Count > 0)
            {
                return remurenateLogisticList.LastOrDefault().Value * distance;
            }
            return 0;
        }

        /// <summary>
        /// list of ungrouped commissions in the accounting
        /// </summary>
        /// <returns></returns>
        public static List<ObjectsFunctions.LogisticPaymentCommission> SearchToAccounting()
        {

            DataClassesLandfillDataContext context = Configuration.GetContext();
            var q = (from LogisticPaymentCommission in context.LogisticPaymentCommissions
                     where LogisticPaymentCommission.LogisticAccountingID.HasValue == false
                     select new ObjectsFunctions.LogisticPaymentCommission(LogisticPaymentCommission));
            return q.ToList();
        }

        public static void Insert(ObjectsFunctions.LogisticPaymentCommission LogisticPaymentCommission)
        {

            DataClassesLandfillDataContext context = Configuration.GetContext();
            context.LogisticPaymentCommissions.InsertOnSubmit(LogisticPaymentCommission.d_LogisticPaymentCommission);
            context.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
        }

        public static void Update(ObjectsFunctions.LogisticPaymentCommission LogisticPaymentCommission)
        {
            DataClassesLandfillDataContext context = LandfillServices.UI.Web.SQL.Configuration.GetContext();

            LandfillServices.UI.Web.SQL.LogisticPaymentCommission d_LogisticPaymentCommission = context.LogisticPaymentCommissions.Single(a => a.ID == LogisticPaymentCommission.d_LogisticPaymentCommission.ID);
            if (d_LogisticPaymentCommission != null)
            {
                ObjectsFunctions.LogisticPaymentCommission contextLogisticPaymentCommission = new ObjectsFunctions.LogisticPaymentCommission(d_LogisticPaymentCommission);
                Utilities.PropertyHandler.CopyTo<ObjectsFunctions.LogisticPaymentCommission>(LogisticPaymentCommission, contextLogisticPaymentCommission);
                contextLogisticPaymentCommission.d_LogisticPaymentCommission.Updated = DateTime.Now;
                context.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
            }
        }

        public static void Delete(ObjectsFunctions.LogisticPaymentCommission LogisticPaymentCommission)
        {

            DataClassesLandfillDataContext context = Configuration.GetContext();

            LandfillServices.UI.Web.SQL.LogisticPaymentCommission d_LogisticPaymentCommission = context.LogisticPaymentCommissions.Single(a => a.ID == LogisticPaymentCommission.d_LogisticPaymentCommission.ID);
            if (LogisticPaymentCommission != null)
            {
                context.LogisticPaymentCommissions.DeleteOnSubmit(LogisticPaymentCommission.d_LogisticPaymentCommission);
                context.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
                LogisticPaymentCommission = null;
            }
        }

        public static void Save(ObjectsFunctions.LogisticPaymentCommission LogisticPaymentCommission)
        {

            if (LogisticPaymentCommission.ID == 0)
            {
                Insert(LogisticPaymentCommission);

            }
            else
                Update(LogisticPaymentCommission);

        }
    }
}
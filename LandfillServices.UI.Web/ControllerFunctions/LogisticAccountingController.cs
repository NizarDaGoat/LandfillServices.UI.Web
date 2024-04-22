using LandfillServices.UI.Web.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandfillServices.UI.Web.ControllerFunctions
{
    public class LogisticAccountingController
    {
        public static ObjectsFunctions.LogisticAccounting SearchByID(int ID)
        {
            DataClassesLandfillDataContext context = Configuration.GetContext();
            LandfillServices.UI.Web.SQL.LogisticAccounting sqlLogisticAccounting = context.LogisticAccountings.SingleOrDefault(a => a.ID == ID);
            if (sqlLogisticAccounting != null)
                return new ObjectsFunctions.LogisticAccounting(sqlLogisticAccounting);
            return null;
        }
        public static List<ObjectsFunctions.LogisticAccounting> SearchAll()
        {

            DataClassesLandfillDataContext context = Configuration.GetContext();
            var q = (from LogisticAccounting in context.LogisticAccountings

                     select new ObjectsFunctions.LogisticAccounting(LogisticAccounting));
            return q.ToList();
        }
        public static List<ObjectsFunctions.LogisticAccounting> SearchByLogisticID(int LogisticID)
        {

            DataClassesLandfillDataContext context = Configuration.GetContext();
            var q = (from LogisticAccounting in context.LogisticAccountings
                     where LogisticAccounting.LogisticID == LogisticID
                     select new ObjectsFunctions.LogisticAccounting(LogisticAccounting));
            return q.ToList();
        }

        /// <summary>
        /// the list of untransferred commission groups
        /// </summary>
        /// <param name="LogisticID"></param>
        /// <returns></returns>
        public static ObjectsFunctions.LogisticAccounting SearchForAgregate(int LogisticID)
        {
            DataClassesLandfillDataContext context = Configuration.GetContext();
            var q = (from LogisticAccounting in context.LogisticAccountings
                     where LogisticAccounting.LogisticID == LogisticID
                     where LogisticAccounting.TransferDate.HasValue == false
                     select new ObjectsFunctions.LogisticAccounting(LogisticAccounting));
            return q.SingleOrDefault();
        }
        public static void Insert(ObjectsFunctions.LogisticAccounting LogisticAccounting)
        {

            DataClassesLandfillDataContext context = Configuration.GetContext();
            context.LogisticAccountings.InsertOnSubmit(LogisticAccounting.d_LogisticAccounting);
            context.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
        }

        public static void Update(ObjectsFunctions.LogisticAccounting LogisticAccounting)
        {
            DataClassesLandfillDataContext context = Configuration.GetContext();

            LandfillServices.UI.Web.SQL.LogisticAccounting d_LogisticAccounting = context.LogisticAccountings.Single(a => a.ID == LogisticAccounting.ID);
            if (d_LogisticAccounting != null)
            {
                ObjectsFunctions.LogisticAccounting contextLogisticAccounting = new ObjectsFunctions.LogisticAccounting(d_LogisticAccounting);
                Utilities.PropertyHandler.CopyTo<ObjectsFunctions.LogisticAccounting>(LogisticAccounting, contextLogisticAccounting);
                contextLogisticAccounting.d_LogisticAccounting.Updated = DateTime.Now;
                context.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
            }
        }

        public static void Delete(ObjectsFunctions.LogisticAccounting LogisticAccounting)
        {

            DataClassesLandfillDataContext context = Configuration.GetContext();

            LandfillServices.UI.Web.SQL.LogisticAccounting d_LogisticAccounting = context.LogisticAccountings.Single(a => a.ID == LogisticAccounting.d_LogisticAccounting.ID);
            if (LogisticAccounting != null)
            {
                context.LogisticAccountings.DeleteOnSubmit(LogisticAccounting.d_LogisticAccounting);
                context.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
                LogisticAccounting = null;
            }
        }

        public static void Save(ObjectsFunctions.LogisticAccounting LogisticAccounting)
        {

            if (LogisticAccounting.ID == 0)
            {
                Insert(LogisticAccounting);

            }
            else
                Update(LogisticAccounting);

        }
    }
}
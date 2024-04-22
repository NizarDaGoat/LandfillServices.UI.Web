using LandfillServices.UI.Web.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandfillServices.UI.Web.ControllerFunctions
{
    public class LogisticTurnCollectController
    {
        public static ObjectsFunctions.LogisticTurnCollect SearchByID(int ID)
        {
            DataClassesLandfillDataContext context = Configuration.GetContext();
            LandfillServices.UI.Web.SQL.LogisticTurnCollect sqlLogisticTurnCollect = context.LogisticTurnCollects.SingleOrDefault(a => a.ID == ID);
            if (sqlLogisticTurnCollect != null)
                return new ObjectsFunctions.LogisticTurnCollect(sqlLogisticTurnCollect);
            return null;
        }
        public static List<ObjectsFunctions.LogisticTurnCollect> SearchAll()
        {

            DataClassesLandfillDataContext context = Configuration.GetContext();
            var q = (from LogisticTurnCollect in context.LogisticTurnCollects

                     select new ObjectsFunctions.LogisticTurnCollect(LogisticTurnCollect));
            return q.ToList();
        }
        public static List<ObjectsFunctions.LogisticTurnCollect> SearchByContractLogisticID(int contratsLogisticID)
        {

            DataClassesLandfillDataContext context = Configuration.GetContext();
            var q = (from LogisticTurnCollect in context.LogisticTurnCollects
                     where LogisticTurnCollect.ContractsLogisticsID == contratsLogisticID
                     select new ObjectsFunctions.LogisticTurnCollect(LogisticTurnCollect));
            return q.ToList();
        }


        public static void Insert(ObjectsFunctions.LogisticTurnCollect LogisticTurnCollect)
        {

            DataClassesLandfillDataContext context = Configuration.GetContext();
            context.LogisticTurnCollects.InsertOnSubmit(LogisticTurnCollect.d_LogisticTurnCollect);
            context.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
        }

        public static void Update(ObjectsFunctions.LogisticTurnCollect LogisticTurnCollect)
        {
            DataClassesLandfillDataContext context = Configuration.GetContext();

            LandfillServices.UI.Web.SQL.LogisticTurnCollect d_LogisticTurnCollect = context.LogisticTurnCollects.Single(a => a.ID == LogisticTurnCollect.ID);
            if (d_LogisticTurnCollect != null)
            {
                ObjectsFunctions.LogisticTurnCollect contextLogisticTurnCollect = new ObjectsFunctions.LogisticTurnCollect(d_LogisticTurnCollect);
                Utilities.PropertyHandler.CopyTo<ObjectsFunctions.LogisticTurnCollect>(LogisticTurnCollect, contextLogisticTurnCollect);
                contextLogisticTurnCollect.d_LogisticTurnCollect.Updated = DateTime.Now;
                context.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
            }
        }

        public static void Delete(ObjectsFunctions.LogisticTurnCollect LogisticTurnCollect)
        {

            DataClassesLandfillDataContext context = Configuration.GetContext();

            LandfillServices.UI.Web.SQL.LogisticTurnCollect d_LogisticTurnCollect = context.LogisticTurnCollects.Single(a => a.ID == LogisticTurnCollect.d_LogisticTurnCollect.ID);
            if (LogisticTurnCollect != null)
            {
                context.LogisticTurnCollects.DeleteOnSubmit(LogisticTurnCollect.d_LogisticTurnCollect);
                context.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
                LogisticTurnCollect = null;
            }
        }

        public static void Save(ObjectsFunctions.LogisticTurnCollect LogisticTurnCollect)
        {

            if (LogisticTurnCollect.ID == 0)
            {
                Insert(LogisticTurnCollect);

            }
            else
                Update(LogisticTurnCollect);

        }
    }
}
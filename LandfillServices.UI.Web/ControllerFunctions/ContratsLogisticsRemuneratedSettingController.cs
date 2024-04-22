using LandfillServices.UI.Web.ObjectsFunctions;
using LandfillServices.UI.Web.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandfillServices.UI.Web.ControllerFunctions
{
    public class ContratsLogisticsRemuneratedSettingController
    {
        public static ObjectsFunctions.ContratsLogisticsRemuneratedSetting SearchByID(int ID)
        {
            DataClassesLandfillDataContext context = Configuration.GetContext();
            LandfillServices.UI.Web.SQL.ContratsLogisticsRemuneratedSetting sqlContratsLogisticsRemuneratedSetting = context.ContratsLogisticsRemuneratedSettings.SingleOrDefault(a => a.ID == ID);
            if (sqlContratsLogisticsRemuneratedSetting != null)
                return new ObjectsFunctions.ContratsLogisticsRemuneratedSetting(sqlContratsLogisticsRemuneratedSetting);
            return null;
        }
        public static List<ObjectsFunctions.ContratsLogisticsRemuneratedSetting> SearchAll()
        {

            DataClassesLandfillDataContext context = Configuration.GetContext();
            var q = (from ContratsLogisticsRemuneratedSetting in context.ContratsLogisticsRemuneratedSettings

                     select new ObjectsFunctions.ContratsLogisticsRemuneratedSetting(ContratsLogisticsRemuneratedSetting));
            return q.ToList();
        }
        public static List<ObjectsFunctions.ContratsLogisticsRemuneratedSetting> SearchByContratLogisticsID(int contratsLogisticsID)
        {

            DataClassesLandfillDataContext context = Configuration.GetContext();
            var q = (from ContratsLogisticsRemuneratedSetting in context.ContratsLogisticsRemuneratedSettings
                     where ContratsLogisticsRemuneratedSetting.ContratsLogisticsID == contratsLogisticsID
                     select new ObjectsFunctions.ContratsLogisticsRemuneratedSetting(ContratsLogisticsRemuneratedSetting));
            return q.ToList();
        }

        /// <summary>
        /// find the remuneration with the criteria: date, Km Interval, and contract
        /// </summary>
        /// <param name="contratsLogisticID"></param>
        /// <param name="date"></param>
        /// <param name="kmInterval"></param>
        /// <returns></returns>
        public static List<ObjectsFunctions.ContratsLogisticsRemuneratedSetting> SearchByContractLogisticID_And_Date_And_Product(int contratsLogisticID, DateTime date, ObjectsFunctions.KmInterval kmInterval)
        {

            DataClassesLandfillDataContext context = Configuration.GetContext();
            var q = (from ContratsLogisticRemuneratedSetting in context.ContratsLogisticsRemuneratedSettings
                     where ContratsLogisticRemuneratedSetting.ContratsLogisticsID == contratsLogisticID
                     where ContratsLogisticRemuneratedSetting.KmInterval == (int)kmInterval
                     where ContratsLogisticRemuneratedSetting.StartDate <= date && ((ContratsLogisticRemuneratedSetting.EndDate.HasValue == false) || (ContratsLogisticRemuneratedSetting.EndDate.HasValue && ContratsLogisticRemuneratedSetting.EndDate >= date))
                     select new ObjectsFunctions.ContratsLogisticsRemuneratedSetting(ContratsLogisticRemuneratedSetting));
            return q.ToList();
        }


        public static void Insert(ObjectsFunctions.ContratsLogisticsRemuneratedSetting ContratsLogisticsRemuneratedSetting)
        {

            DataClassesLandfillDataContext context = Configuration.GetContext();
            context.ContratsLogisticsRemuneratedSettings.InsertOnSubmit(ContratsLogisticsRemuneratedSetting.d_ContratsLogisticsRemuneratedSetting);
            context.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
        }

        public static void Update(ObjectsFunctions.ContratsLogisticsRemuneratedSetting ContratsLogisticsRemuneratedSetting)
        {
            DataClassesLandfillDataContext context = Configuration.GetContext();

            LandfillServices.UI.Web.SQL.ContratsLogisticsRemuneratedSetting d_ContratsLogisticsRemuneratedSetting = context.ContratsLogisticsRemuneratedSettings.Single(a => a.ID == ContratsLogisticsRemuneratedSetting.ID);
            if (d_ContratsLogisticsRemuneratedSetting != null)
            {
                ObjectsFunctions.ContratsLogisticsRemuneratedSetting contextContratsLogisticsRemuneratedSetting = new ObjectsFunctions.ContratsLogisticsRemuneratedSetting(d_ContratsLogisticsRemuneratedSetting);
                Utilities.PropertyHandler.CopyTo<ObjectsFunctions.ContratsLogisticsRemuneratedSetting>(ContratsLogisticsRemuneratedSetting, contextContratsLogisticsRemuneratedSetting);
                contextContratsLogisticsRemuneratedSetting.d_ContratsLogisticsRemuneratedSetting.Updated = DateTime.Now;
                context.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
            }
        }

        public static void Delete(ObjectsFunctions.ContratsLogisticsRemuneratedSetting ContratsLogisticsRemuneratedSetting)
        {

            DataClassesLandfillDataContext context = Configuration.GetContext();

            LandfillServices.UI.Web.SQL.ContratsLogisticsRemuneratedSetting d_ContratsLogisticsRemuneratedSetting = context.ContratsLogisticsRemuneratedSettings.Single(a => a.ID == ContratsLogisticsRemuneratedSetting.d_ContratsLogisticsRemuneratedSetting.ID);
            if (ContratsLogisticsRemuneratedSetting != null)
            {
                context.ContratsLogisticsRemuneratedSettings.DeleteOnSubmit(ContratsLogisticsRemuneratedSetting.d_ContratsLogisticsRemuneratedSetting);
                context.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
                ContratsLogisticsRemuneratedSetting = null;
            }
        }

        public static void Save(ObjectsFunctions.ContratsLogisticsRemuneratedSetting ContratsLogisticsRemuneratedSetting)
        {

            if (ContratsLogisticsRemuneratedSetting.ID == 0)
            {
                Insert(ContratsLogisticsRemuneratedSetting);

            }
            else
                Update(ContratsLogisticsRemuneratedSetting);

        }

    }
}
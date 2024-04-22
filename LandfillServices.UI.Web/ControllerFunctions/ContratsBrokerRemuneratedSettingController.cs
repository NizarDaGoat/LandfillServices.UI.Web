using LandfillServices.UI.Web.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandfillServices.UI.Web.ControllerFunctions
{
    public class ContratsBrokerRemuneratedSettingController
    {
        public static ObjectsFunctions.ContratsBrokerRemuneratedSetting SearchByID(int ID)
        {
            DataClassesLandfillDataContext context = Configuration.GetContext();
            LandfillServices.UI.Web.SQL.ContratsBrokerRemuneratedSetting sqlContratsBrokerRemuneratedSetting = context.ContratsBrokerRemuneratedSettings.SingleOrDefault(a => a.ID == ID);
            if (sqlContratsBrokerRemuneratedSetting != null)
                return new ObjectsFunctions.ContratsBrokerRemuneratedSetting(sqlContratsBrokerRemuneratedSetting);
            return null;
        }
        public static List<ObjectsFunctions.ContratsBrokerRemuneratedSetting> SearchAll()
        {

            DataClassesLandfillDataContext context = Configuration.GetContext();
            var q = (from ContratsBrokerRemuneratedSetting in context.ContratsBrokerRemuneratedSettings

                     select new ObjectsFunctions.ContratsBrokerRemuneratedSetting(ContratsBrokerRemuneratedSetting));
            return q.ToList();
        }
        public static List<ObjectsFunctions.ContratsBrokerRemuneratedSetting> SearchByContractBrokerID(int contratsBrokerID)
        {

            DataClassesLandfillDataContext context = Configuration.GetContext();
            var q = (from ContratsBrokerRemuneratedSetting in context.ContratsBrokerRemuneratedSettings
                     where ContratsBrokerRemuneratedSetting.ContratsBrokerID == contratsBrokerID
                     select new ObjectsFunctions.ContratsBrokerRemuneratedSetting(ContratsBrokerRemuneratedSetting));
            return q.ToList();
        }

        /// <summary>
        /// find the remuneration with the criteria: date, product, and contract
        /// </summary>
        /// <param name="contratsBrokerID"></param>
        /// <param name="date"></param>
        /// <param name="productName"></param>
        /// <returns></returns>
        public static List<ObjectsFunctions.ContratsBrokerRemuneratedSetting> SearchByContractBrokerID_And_Date_And_Product(int contratsBrokerID, DateTime date, ObjectsFunctions.ProductName productName)
        {

            DataClassesLandfillDataContext context = Configuration.GetContext();
            var q = (from ContratsBrokerRemuneratedSetting in context.ContratsBrokerRemuneratedSettings
                     where ContratsBrokerRemuneratedSetting.ContratsBrokerID == contratsBrokerID
                     where ContratsBrokerRemuneratedSetting.ProductName ==(int) productName
                     where ContratsBrokerRemuneratedSetting.StartDate<= date && ((ContratsBrokerRemuneratedSetting.EndDate.HasValue==false) || (ContratsBrokerRemuneratedSetting.EndDate.HasValue && ContratsBrokerRemuneratedSetting.EndDate>= date))
                     select new ObjectsFunctions.ContratsBrokerRemuneratedSetting(ContratsBrokerRemuneratedSetting));
            return q.ToList();
        }

        public static void Insert(ObjectsFunctions.ContratsBrokerRemuneratedSetting ContratsBrokerRemuneratedSetting)
        {

            DataClassesLandfillDataContext context = Configuration.GetContext();
            context.ContratsBrokerRemuneratedSettings.InsertOnSubmit(ContratsBrokerRemuneratedSetting.d_ContratsBrokerRemuneratedSetting);
            context.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
        }

        public static void Update(ObjectsFunctions.ContratsBrokerRemuneratedSetting ContratsBrokerRemuneratedSetting)
        {
            DataClassesLandfillDataContext context = Configuration.GetContext();

            LandfillServices.UI.Web.SQL.ContratsBrokerRemuneratedSetting d_ContratsBrokerRemuneratedSetting = context.ContratsBrokerRemuneratedSettings.Single(a => a.ID == ContratsBrokerRemuneratedSetting.ID);
            if (d_ContratsBrokerRemuneratedSetting != null)
            {
                ObjectsFunctions.ContratsBrokerRemuneratedSetting contextContratsBrokerRemuneratedSetting = new ObjectsFunctions.ContratsBrokerRemuneratedSetting(d_ContratsBrokerRemuneratedSetting);
                Utilities.PropertyHandler.CopyTo<ObjectsFunctions.ContratsBrokerRemuneratedSetting>(ContratsBrokerRemuneratedSetting, contextContratsBrokerRemuneratedSetting);
                contextContratsBrokerRemuneratedSetting.d_ContratsBrokerRemuneratedSetting.Updated = DateTime.Now;
                context.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
            }
        }

        public static void Delete(ObjectsFunctions.ContratsBrokerRemuneratedSetting ContratsBrokerRemuneratedSetting)
        {

            DataClassesLandfillDataContext context = Configuration.GetContext();

            LandfillServices.UI.Web.SQL.ContratsBrokerRemuneratedSetting d_ContratsBrokerRemuneratedSetting = context.ContratsBrokerRemuneratedSettings.Single(a => a.ID == ContratsBrokerRemuneratedSetting.d_ContratsBrokerRemuneratedSetting.ID);
            if (ContratsBrokerRemuneratedSetting != null)
            {
                context.ContratsBrokerRemuneratedSettings.DeleteOnSubmit(ContratsBrokerRemuneratedSetting.d_ContratsBrokerRemuneratedSetting);
                context.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
                ContratsBrokerRemuneratedSetting = null;
            }
        }

        public static void Save(ObjectsFunctions.ContratsBrokerRemuneratedSetting ContratsBrokerRemuneratedSetting)
        {

            if (ContratsBrokerRemuneratedSetting.ID == 0)
            {
                Insert(ContratsBrokerRemuneratedSetting);

            }
            else
                Update(ContratsBrokerRemuneratedSetting);

        }

    }

}
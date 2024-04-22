using LandfillServices.UI.Web.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandfillServices.UI.Web.ControllerFunctions
{
    public class BrokerAccountingController
    {

        public static ObjectsFunctions.BrokerAccounting SearchByID(int ID)
        {
            DataClassesLandfillDataContext context = Configuration.GetContext();
            LandfillServices.UI.Web.SQL.BrokerAccounting sqlBrokerAccounting = context.BrokerAccountings.SingleOrDefault(a => a.ID == ID);
            if (sqlBrokerAccounting != null)
                return new ObjectsFunctions.BrokerAccounting(sqlBrokerAccounting);
            return null;
        }
        public static List<ObjectsFunctions.BrokerAccounting> SearchAll()
        {

            DataClassesLandfillDataContext context = Configuration.GetContext();
            var q = (from BrokerAccounting in context.BrokerAccountings

                     select new ObjectsFunctions.BrokerAccounting(BrokerAccounting));
            return q.ToList();
        }
        public static List<ObjectsFunctions.BrokerAccounting> SearchByBrokerID(int brokerID)
        {

            DataClassesLandfillDataContext context = Configuration.GetContext();
            var q = (from BrokerAccounting in context.BrokerAccountings
                     where BrokerAccounting.BrokerID == brokerID
                     select new ObjectsFunctions.BrokerAccounting(BrokerAccounting));
            return q.ToList();
        }

        /// <summary>
        /// the list of untransferred commission groups
        /// </summary>
        /// <param name="brokerID"></param>
        /// <returns></returns>
        public static ObjectsFunctions.BrokerAccounting SearchForAgregate(int brokerID)
        {
            DataClassesLandfillDataContext context = Configuration.GetContext();
            var q = (from BrokerAccounting in context.BrokerAccountings
                     where BrokerAccounting.BrokerID == brokerID
                     where BrokerAccounting.TransferDate.HasValue == false
                     select new ObjectsFunctions.BrokerAccounting(BrokerAccounting));
            return q.SingleOrDefault();
        }

        /// <summary>
        /// Insert object in data base
        /// </summary>
        /// <param name="BrokerAccounting"></param>
        public static void Insert(ObjectsFunctions.BrokerAccounting BrokerAccounting)
        {

            DataClassesLandfillDataContext context = Configuration.GetContext();
            context.BrokerAccountings.InsertOnSubmit(BrokerAccounting.d_BrokerAccounting);
            context.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
        }

        /// <summary>
        /// Update object in data base
        /// </summary>
        /// <param name="BrokerAccounting"></param>
        public static void Update(ObjectsFunctions.BrokerAccounting BrokerAccounting)
        {
            DataClassesLandfillDataContext context = Configuration.GetContext();

            LandfillServices.UI.Web.SQL.BrokerAccounting d_BrokerAccounting = context.BrokerAccountings.Single(a => a.ID == BrokerAccounting.ID);
            if (d_BrokerAccounting != null)
            {
                ObjectsFunctions.BrokerAccounting contextBrokerAccounting = new ObjectsFunctions.BrokerAccounting(d_BrokerAccounting);
                Utilities.PropertyHandler.CopyTo<ObjectsFunctions.BrokerAccounting>(BrokerAccounting, contextBrokerAccounting);
                contextBrokerAccounting.d_BrokerAccounting.Updated = DateTime.Now;
                context.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
            }
        }

        /// <summary>
        /// Delete object for data base
        /// </summary>
        /// <param name="BrokerAccounting"></param>
        public static void Delete(ObjectsFunctions.BrokerAccounting BrokerAccounting)
        {

            DataClassesLandfillDataContext context = Configuration.GetContext();

            LandfillServices.UI.Web.SQL.BrokerAccounting d_BrokerAccounting = context.BrokerAccountings.Single(a => a.ID == BrokerAccounting.d_BrokerAccounting.ID);
            if (BrokerAccounting != null)
            {
                context.BrokerAccountings.DeleteOnSubmit(BrokerAccounting.d_BrokerAccounting);
                context.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
                BrokerAccounting = null;
            }
        }

        /// <summary>
        /// Save object in data base (insert if not existe else updated)
        /// </summary>
        /// <param name="BrokerAccounting"></param>
        public static void Save(ObjectsFunctions.BrokerAccounting BrokerAccounting)
        {

            if (BrokerAccounting.ID == 0)
            {
                Insert(BrokerAccounting);

            }
            else
                Update(BrokerAccounting);

        }

    }
}
using Antlr.Runtime.Tree;
using LandfillServices.UI.Web.ObjectsFunctions;
using LandfillServices.UI.Web.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandfillServices.UI.Web.ControllerFunctions
{
    public class BrokerPaymentCommissionController
    {
        public static ObjectsFunctions.BrokerPaymentCommission SearchByID(int ID)
        {
            DataClassesLandfillDataContext context = Configuration.GetContext();
            LandfillServices.UI.Web.SQL.BrokerPaymentCommission sqlBrokerPaymentCommission = context.BrokerPaymentCommissions.SingleOrDefault(a => a.ID == ID);
            if (sqlBrokerPaymentCommission != null)
                return new ObjectsFunctions.BrokerPaymentCommission(sqlBrokerPaymentCommission);
            return null;
        }
        public static List<ObjectsFunctions.BrokerPaymentCommission> SearchAll()
        {

            DataClassesLandfillDataContext context = Configuration.GetContext();
            var q = (from BrokerPaymentCommission in context.BrokerPaymentCommissions

                     select new ObjectsFunctions.BrokerPaymentCommission(BrokerPaymentCommission));
            return q.ToList();
        }
        public static List<ObjectsFunctions.BrokerPaymentCommission> SearchByBrokerPassageProductID(int brokerPassageProductID)
        {

            DataClassesLandfillDataContext context = Configuration.GetContext();
            var q = (from BrokerPaymentCommission in context.BrokerPaymentCommissions
                     where BrokerPaymentCommission.BrokerPassageProductID == brokerPassageProductID
                     select new ObjectsFunctions.BrokerPaymentCommission(BrokerPaymentCommission));
            return q.ToList();
        }

        public static List<ObjectsFunctions.BrokerPaymentCommission> SearchByBrokerID(int brokerID)
        {

            DataClassesLandfillDataContext context = Configuration.GetContext();
            var q = (from BrokerPaymentCommission in context.BrokerPaymentCommissions
                     where BrokerPaymentCommission.BrokerPassageProduct.ContractsBroker.BrokerID == brokerID
                     select new ObjectsFunctions.BrokerPaymentCommission(BrokerPaymentCommission));
            return q.ToList();
        }

        /// <summary>
        /// Calculate Amount Of Commission
        /// </summary>
        /// <param name="contractsBroker"></param>
        /// <param name="date"></param>
        /// <param name="productName"></param>
        /// <param name="weight"></param>
        /// <returns></returns>
        public static decimal CalculateAmountOfCommission(ObjectsFunctions.ContractsBroker contractsBroker,DateTime date,ObjectsFunctions.ProductName productName,decimal weight)
        {
            var remurenateBrokerList = ControllerFunctions.ContratsBrokerRemuneratedSettingController.SearchByContractBrokerID_And_Date_And_Product(contractsBroker.ID, date, productName);
            if(remurenateBrokerList.Count>0)
            {
                return remurenateBrokerList.LastOrDefault().Value * weight;
            }
            return 0;
        }

        /// <summary>
        /// list of ungrouped commissions in the accounting
        /// </summary>
        /// <returns></returns>
        public static List<ObjectsFunctions.BrokerPaymentCommission> SearchToAccounting()
        {

            DataClassesLandfillDataContext context = Configuration.GetContext();
            var q = (from BrokerPaymentCommission in context.BrokerPaymentCommissions
                     where BrokerPaymentCommission.BrokerAccountingID.HasValue==false
                     select new ObjectsFunctions.BrokerPaymentCommission(BrokerPaymentCommission));
            return q.ToList();
        }
       
        public static void Insert(ObjectsFunctions.BrokerPaymentCommission BrokerPaymentCommission)
        {

            DataClassesLandfillDataContext context = Configuration.GetContext();
            context.BrokerPaymentCommissions.InsertOnSubmit(BrokerPaymentCommission.d_BrokerPaymentCommission);
            context.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
        }

        public static void Update(ObjectsFunctions.BrokerPaymentCommission BrokerPaymentCommission)
        {
            DataClassesLandfillDataContext context = LandfillServices.UI.Web.SQL.Configuration.GetContext();

            LandfillServices.UI.Web.SQL.BrokerPaymentCommission d_BrokerPaymentCommission = context.BrokerPaymentCommissions.Single(a => a.ID == BrokerPaymentCommission.d_BrokerPaymentCommission.ID);
            if (d_BrokerPaymentCommission != null)
            {
                ObjectsFunctions.BrokerPaymentCommission contextBrokerPaymentCommission = new ObjectsFunctions.BrokerPaymentCommission(d_BrokerPaymentCommission);
                Utilities.PropertyHandler.CopyTo<ObjectsFunctions.BrokerPaymentCommission>(BrokerPaymentCommission, contextBrokerPaymentCommission);
                contextBrokerPaymentCommission.d_BrokerPaymentCommission.Updated = DateTime.Now;
                context.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
            }
        }

        public static void Delete(ObjectsFunctions.BrokerPaymentCommission BrokerPaymentCommission)
        {

            DataClassesLandfillDataContext context = Configuration.GetContext();

            LandfillServices.UI.Web.SQL.BrokerPaymentCommission d_BrokerPaymentCommission = context.BrokerPaymentCommissions.Single(a => a.ID == BrokerPaymentCommission.d_BrokerPaymentCommission.ID);
            if (BrokerPaymentCommission != null)
            {
                context.BrokerPaymentCommissions.DeleteOnSubmit(BrokerPaymentCommission.d_BrokerPaymentCommission);
                context.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
                BrokerPaymentCommission = null;
            }
        }

        public static void Save(ObjectsFunctions.BrokerPaymentCommission BrokerPaymentCommission)
        {

            if (BrokerPaymentCommission.ID == 0)
            {
                Insert(BrokerPaymentCommission);
                
            }
            else
                Update(BrokerPaymentCommission);

        }
    }
}
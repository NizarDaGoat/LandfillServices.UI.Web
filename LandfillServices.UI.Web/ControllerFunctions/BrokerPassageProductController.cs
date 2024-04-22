using LandfillServices.UI.Web.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandfillServices.UI.Web.ControllerFunctions
{
    public class BrokerPassageProductController
    {
        public static ObjectsFunctions.BrokerPassageProduct SearchByID(int ID)
        {
            DataClassesLandfillDataContext context = Configuration.GetContext();
            LandfillServices.UI.Web.SQL.BrokerPassageProduct sqlBrokerPassageProduct = context.BrokerPassageProducts.SingleOrDefault(a => a.ID == ID);
            if (sqlBrokerPassageProduct != null)
                return new ObjectsFunctions.BrokerPassageProduct(sqlBrokerPassageProduct);
            return null;
        }
        public static List<ObjectsFunctions.BrokerPassageProduct> SearchAll()
        {

            DataClassesLandfillDataContext context = Configuration.GetContext();
            var q = (from BrokerPassageProduct in context.BrokerPassageProducts

                     select new ObjectsFunctions.BrokerPassageProduct(BrokerPassageProduct));
            return q.ToList();
        }
        public static List<ObjectsFunctions.BrokerPassageProduct> SearchByContractBrokerID(int contratsBrokerID)
        {

            DataClassesLandfillDataContext context = Configuration.GetContext();
            var q = (from BrokerPassageProduct in context.BrokerPassageProducts
                     where BrokerPassageProduct.ContractsBrokerID == contratsBrokerID
                     select new ObjectsFunctions.BrokerPassageProduct(BrokerPassageProduct));
            return q.ToList();
        }


        public static List<ObjectsFunctions.BrokerPassageProduct> SearchByDate(DateTime date)
        {

            DataClassesLandfillDataContext context = Configuration.GetContext();
            var q = (from BrokerPassageProduct in context.BrokerPassageProducts
                     where BrokerPassageProduct.Date.Year == date.Year && BrokerPassageProduct.Date.Month == date.Month
                     select new ObjectsFunctions.BrokerPassageProduct(BrokerPassageProduct));
            return q.ToList();
        }



        public static void Insert(ObjectsFunctions.BrokerPassageProduct BrokerPassageProduct)
        {

            DataClassesLandfillDataContext context = Configuration.GetContext();
            context.BrokerPassageProducts.InsertOnSubmit(BrokerPassageProduct.d_BrokerPassageProduct);
            context.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
        }

        public static void Update(ObjectsFunctions.BrokerPassageProduct BrokerPassageProduct)
        {
            DataClassesLandfillDataContext context = Configuration.GetContext();

            LandfillServices.UI.Web.SQL.BrokerPassageProduct d_BrokerPassageProduct = context.BrokerPassageProducts.Single(a => a.ID == BrokerPassageProduct.ID);
            if (d_BrokerPassageProduct != null)
            {
                ObjectsFunctions.BrokerPassageProduct contextBrokerPassageProduct = new ObjectsFunctions.BrokerPassageProduct(d_BrokerPassageProduct);
                Utilities.PropertyHandler.CopyTo<ObjectsFunctions.BrokerPassageProduct>(BrokerPassageProduct, contextBrokerPassageProduct);
                contextBrokerPassageProduct.d_BrokerPassageProduct.Updated = DateTime.Now;
                context.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
            }
        }

        public static void Delete(ObjectsFunctions.BrokerPassageProduct BrokerPassageProduct)
        {

            DataClassesLandfillDataContext context = Configuration.GetContext();

            LandfillServices.UI.Web.SQL.BrokerPassageProduct d_BrokerPassageProduct = context.BrokerPassageProducts.Single(a => a.ID == BrokerPassageProduct.d_BrokerPassageProduct.ID);
            if (BrokerPassageProduct != null)
            {
                context.BrokerPassageProducts.DeleteOnSubmit(BrokerPassageProduct.d_BrokerPassageProduct);
                context.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
                BrokerPassageProduct = null;
            }
        }

        public static void Save(ObjectsFunctions.BrokerPassageProduct BrokerPassageProduct)
        {

            if (BrokerPassageProduct.ID == 0)
            {
                Insert(BrokerPassageProduct);

            }
            else
                Update(BrokerPassageProduct);

        }

    }
}
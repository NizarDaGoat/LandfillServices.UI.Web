using LandfillServices.UI.Web.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 

namespace LandfillServices.UI.Web.ControllerFunctions
{
    public class BrokerController
    {
        #region private attributes

        #endregion //private attributes

        #region Search

        /// <summary>
        /// identification Broker by ID
        /// </summary>
        /// <param Name="ID">ID du Broker</param>
        /// <returns>Broker</returns>
        public static ObjectsFunctions.Broker SearchByID(int ID)
        {
            DataClassesLandfillDataContext context = Configuration.GetContext();
            var q = from Broker in context.Brokers
                    join landfillUser in context.LandfillUsers on Broker.ID equals landfillUser.ID
                    where Broker.ID == ID
                    select new ObjectsFunctions.Broker(landfillUser, Broker);
            return q.SingleOrDefault();
        }

        /// <summary>
        /// SearchByInternalCode
        /// </summary>
        /// <param name="internalCode"></param>
        /// <returns></returns>
        public static ObjectsFunctions.Broker SearchByInternalCode(string internalCode)
        {
            DataClassesLandfillDataContext context = Configuration.GetContext();
            var q = from Broker in context.Brokers
                    join landfillUser in context.LandfillUsers on Broker.ID equals landfillUser.ID
                    where Broker.InternalCode == internalCode
                    select new ObjectsFunctions.Broker(landfillUser, Broker);
            return q.FirstOrDefault();
        }

        
        /// <summary>
        /// Search
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static ObjectsFunctions.Broker SearchByEmail(string email)
        {
            email = email?.Trim();
            if (string.IsNullOrEmpty(email))
                return null;

            DataClassesLandfillDataContext context = Configuration.GetContext();
            var q = from Broker in context.Brokers
                    join landfillUser in context.LandfillUsers on Broker.ID equals landfillUser.ID
                    where landfillUser.Email == email
                    select new ObjectsFunctions.Broker(landfillUser, Broker);
            return q.FirstOrDefault();
        }

        
        public static ObjectsFunctions.Broker Search(string email, string password)
        {
            email = email?.Trim();
            password = password?.Trim();
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email))
                return null;

            DataClassesLandfillDataContext context = Configuration.GetContext();
            var q = from Broker in context.Brokers
                    join landfillUser in context.LandfillUsers on Broker.ID equals landfillUser.ID
                    where landfillUser.Email == email
                    where landfillUser.Password == password
                    select new ObjectsFunctions.Broker(landfillUser, Broker);
            return q.FirstOrDefault();
        }

        /// <summary>
        /// Rcupration de tous les Brokers
        /// </summary>
        /// <returns>BrokerList</returns>
        public static List<ObjectsFunctions.Broker> SearchAll()
        {
            DataClassesLandfillDataContext context = Configuration.GetContext();
            var q = from Broker in context.Brokers
                    join landfillUser in context.LandfillUsers on Broker.ID equals landfillUser.ID
                    orderby landfillUser.Created
                    select new ObjectsFunctions.Broker(landfillUser, Broker);
            return q.ToList();
        }
 
 

        #endregion //Search

        #region Utilities

        /// <summary>
        /// CheckEmailAndPasswordValidity
        /// </summary>
        /// <param name="Broker"></param>
        /// <returns></returns>
        public static bool CheckEmailAndPasswordValidity(ObjectsFunctions.Broker Broker)
        {
            Broker.Email = Broker.Email?.Trim();
            Broker.Password = Broker.Password?.Trim();

              if (string.IsNullOrEmpty(Broker.Password) || string.IsNullOrEmpty(Broker.Email))
                return false;

            var sameProprietaire = SearchByEmail(Broker.Email);

            if (sameProprietaire != null && sameProprietaire.ID != Broker.ID)
                return false;

            return true;
        }

        
          

           
        #endregion //Utilities

        #region CRUD

        private static void Insert(ObjectsFunctions.Broker Broker)
        {

            DataClassesLandfillDataContext context = Configuration.GetContext(); 
            
                context.LandfillUsers.InsertOnSubmit(Broker.d_landfillUser);
                context.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
                Broker.SQLBroker.ID = Broker.d_landfillUser.ID;
                context.Brokers.InsertOnSubmit(Broker.SQLBroker);
                context.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
                
        }

        private static void Update(ObjectsFunctions.Broker Broker)
        {
            DataClassesLandfillDataContext context = Configuration.GetContext();

            ObjectsFunctions.Broker contextBroker = (
                from dalBroker in context.Brokers
                join dalLandfillUsers in context.LandfillUsers on dalBroker.ID equals dalLandfillUsers.ID
                where dalBroker.ID == Broker.ID
                select new ObjectsFunctions.Broker(dalLandfillUsers, dalBroker)).SingleOrDefault();
            
            Utilities.PropertyHandler.CopyTo<ObjectsFunctions.Broker>(Broker, contextBroker);

            using (System.Transactions.TransactionScope scope = new System.Transactions.TransactionScope())
            {
                contextBroker.SQLBroker.Updated = DateTime.Now;
                contextBroker.d_landfillUser.Updated = DateTime.Now;

                context.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
            }
             Broker = contextBroker;

        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="Broker"></param>
        public static void Delete(ObjectsFunctions.Broker Broker)
        {
            DataClassesLandfillDataContext context = Configuration.GetContext();

            ObjectsFunctions.Broker contextBroker = (
                from dalBroker in context.Brokers
                join dalLandfillUsers in context.LandfillUsers on dalBroker.ID equals dalLandfillUsers.ID
                where dalBroker.ID == Broker.ID
                select new ObjectsFunctions.Broker(dalLandfillUsers, dalBroker)).SingleOrDefault();
            using (System.Transactions.TransactionScope scope = new System.Transactions.TransactionScope())
            {
                context.Brokers.DeleteOnSubmit(contextBroker.SQLBroker);
                context.LandfillUsers.DeleteOnSubmit(contextBroker.d_landfillUser);
                context.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
            }
            Broker = null;
        }

        /// <summary>
        /// Save
        /// </summary>
        /// <param name="Broker"></param>
        public static void Save(ObjectsFunctions.Broker Broker)
        {
            //if (CheckEmailAndPasswordValidity(Broker) == false)
            // throw new Exception("Mail ou mot de passe invalide");

            if (Broker.SQLBroker.ID == 0)
                Insert(Broker);
            else
                Update(Broker);
        }




        #endregion //CRUD
    }
}
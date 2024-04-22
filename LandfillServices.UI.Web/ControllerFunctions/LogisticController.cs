using LandfillServices.UI.Web.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandfillServices.UI.Web.ControllerFunctions
{
    public class LogisticController
    {
        #region private attributes

        #endregion //private attributes

        #region Search

        /// <summary>
        /// identification Logistic by ID
        /// </summary>
        /// <param Name="ID">ID du Logistic</param>
        /// <returns>Logistic</returns>
        public static ObjectsFunctions.Logistic SearchByID(int ID)
        {
            DataClassesLandfillDataContext context = Configuration.GetContext();
            var q = from Logistic in context.Logistics
                    join landfillUser in context.LandfillUsers on Logistic.ID equals landfillUser.ID
                    where Logistic.ID == ID
                    select new ObjectsFunctions.Logistic(landfillUser, Logistic);
            return q.SingleOrDefault();
        }

        /// <summary>
        /// SearchByInternalCode
        /// </summary>
        /// <param name="internalCode"></param>
        /// <returns></returns>
        public static ObjectsFunctions.Logistic SearchByInternalCode(string internalCode)
        {
            DataClassesLandfillDataContext context = Configuration.GetContext();
            var q = from Logistic in context.Logistics
                    join landfillUser in context.LandfillUsers on Logistic.ID equals landfillUser.ID
                    where Logistic.InternalCode == internalCode
                    select new ObjectsFunctions.Logistic(landfillUser, Logistic);
            return q.FirstOrDefault();
        }


        /// <summary>
        /// Search
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static ObjectsFunctions.Logistic SearchByEmail(string email)
        {
            email = email?.Trim();
            if (string.IsNullOrEmpty(email))
                return null;

            DataClassesLandfillDataContext context = Configuration.GetContext();
            var q = from Logistic in context.Logistics
                    join landfillUser in context.LandfillUsers on Logistic.ID equals landfillUser.ID
                    where landfillUser.Email == email
                    select new ObjectsFunctions.Logistic(landfillUser, Logistic);
            return q.FirstOrDefault();
        }


        public static ObjectsFunctions.Logistic Search(string email, string password)
        {
            email = email?.Trim();
            password = password?.Trim();
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email))
                return null;

            DataClassesLandfillDataContext context = Configuration.GetContext();
            var q = from Logistic in context.Logistics
                    join landfillUser in context.LandfillUsers on Logistic.ID equals landfillUser.ID
                    where landfillUser.Email == email
                    where landfillUser.Password == password
                    select new ObjectsFunctions.Logistic(landfillUser, Logistic);
            return q.FirstOrDefault();
        }

        /// <summary>
        /// Rcupration de tous les Logistics
        /// </summary>
        /// <returns>LogisticList</returns>
        public static List<ObjectsFunctions.Logistic> SearchAll()
        {
            DataClassesLandfillDataContext context = Configuration.GetContext();
            var q = from Logistic in context.Logistics
                    join landfillUser in context.LandfillUsers on Logistic.ID equals landfillUser.ID
                    orderby landfillUser.Created
                    select new ObjectsFunctions.Logistic(landfillUser, Logistic);
            return q.ToList();
        }



        #endregion //Search

        #region Utilities

        /// <summary>
        /// CheckEmailAndPasswordValidity
        /// </summary>
        /// <param name="Logistic"></param>
        /// <returns></returns>
        public static bool CheckEmailAndPasswordValidity(ObjectsFunctions.Logistic Logistic)
        {
            Logistic.Email = Logistic.Email?.Trim();
            Logistic.Password = Logistic.Password?.Trim();

            if (string.IsNullOrEmpty(Logistic.Password) || string.IsNullOrEmpty(Logistic.Email))
                return false;

            var sameProprietaire = SearchByEmail(Logistic.Email);

            if (sameProprietaire != null && sameProprietaire.ID != Logistic.ID)
                return false;

            return true;
        }





        #endregion //Utilities

        #region CRUD

        private static void Insert(ObjectsFunctions.Logistic Logistic)
        {

            DataClassesLandfillDataContext context = Configuration.GetContext();

            context.LandfillUsers.InsertOnSubmit(Logistic.d_landfillUser);
            context.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
            Logistic.SQLLogistic.ID = Logistic.d_landfillUser.ID;
            context.Logistics.InsertOnSubmit(Logistic.SQLLogistic);
            context.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);

        }

        private static void Update(ObjectsFunctions.Logistic Logistic)
        {
            DataClassesLandfillDataContext context = Configuration.GetContext();

            ObjectsFunctions.Logistic contextLogistic = (
                from dalLogistic in context.Logistics
                join dalLandfillUsers in context.LandfillUsers on dalLogistic.ID equals dalLandfillUsers.ID
                where dalLogistic.ID == Logistic.ID
                select new ObjectsFunctions.Logistic(dalLandfillUsers, dalLogistic)).SingleOrDefault();

            Utilities.PropertyHandler.CopyTo<ObjectsFunctions.Logistic>(Logistic, contextLogistic);

            contextLogistic.SQLLogistic.Updated = DateTime.Now;
            contextLogistic.d_landfillUser.Updated = DateTime.Now;

            context.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);

            Logistic = contextLogistic;

        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="Logistic"></param>
        public static void Delete(ObjectsFunctions.Logistic Logistic)
        {
            DataClassesLandfillDataContext context = Configuration.GetContext();

            ObjectsFunctions.Logistic contextLogistic = (
                from dalLogistic in context.Logistics
                join dalLandfillUsers in context.LandfillUsers on dalLogistic.ID equals dalLandfillUsers.ID
                where dalLogistic.ID == Logistic.ID
                select new ObjectsFunctions.Logistic(dalLandfillUsers, dalLogistic)).SingleOrDefault();

            context.Logistics.DeleteOnSubmit(contextLogistic.SQLLogistic);
            context.LandfillUsers.DeleteOnSubmit(contextLogistic.d_landfillUser);
            context.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);

            Logistic = null;
        }

        /// <summary>
        /// Save
        /// </summary>
        /// <param name="Logistic"></param>
        public static void Save(ObjectsFunctions.Logistic Logistic)
        {
            //if (CheckEmailAndPasswordValidity(Logistic) == false)
            // throw new Exception("Mail ou mot de passe invalide");

            if (Logistic.SQLLogistic.ID == 0)
                Insert(Logistic);
            else
                Update(Logistic);
        }




        #endregion //CRUD
    }
}
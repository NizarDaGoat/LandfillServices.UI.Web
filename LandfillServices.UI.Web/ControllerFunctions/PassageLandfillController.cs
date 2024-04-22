using LandfillServices.UI.Web.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandfillServices.UI.Web.ControllerFunctions
{
    public class PassageLandfillController
    {
        public static ObjectsFunctions.PassageLandfill SearchByID(int ID)
        {
            DataClassesLandfillDataContext context = Configuration.GetContext();
            LandfillServices.UI.Web.SQL.PassageLandfill sqlPassageLandfill = context.PassageLandfills.SingleOrDefault(a => a.ID == ID);
            if (sqlPassageLandfill!= null)
                return new ObjectsFunctions.PassageLandfill(sqlPassageLandfill);
            return null;
        }
        public static List<ObjectsFunctions.PassageLandfill> SearchAll()
        {

            DataClassesLandfillDataContext context = Configuration.GetContext();
            var q = (from passageLandfill in context.PassageLandfills

                     select new ObjectsFunctions.PassageLandfill(passageLandfill));
            return q.ToList();
        }
        public static List<ObjectsFunctions.PassageLandfill> SearchByUserID(int userID)
        {

            DataClassesLandfillDataContext context = Configuration.GetContext();
            var q = (from passageLandfill in context.PassageLandfills
                     where passageLandfill.UserID == userID
                     select new ObjectsFunctions.PassageLandfill(passageLandfill));
            return q.ToList();
        }


        public static void Insert(ObjectsFunctions.PassageLandfill passageLandfill)
        {

            DataClassesLandfillDataContext context = Configuration.GetContext();
            context.PassageLandfills.InsertOnSubmit(passageLandfill.d_PassageLandfill);
            context.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
        }

        public static void Update(ObjectsFunctions.PassageLandfill passageLandfill)
        {
            DataClassesLandfillDataContext context = Configuration.GetContext();

            LandfillServices.UI.Web.SQL.PassageLandfill d_PassageLandfill = context.PassageLandfills.Single(a => a.ID == passageLandfill.ID);
            if (d_PassageLandfill != null)
            {
                ObjectsFunctions.PassageLandfill contextPassageLandfill = new ObjectsFunctions.PassageLandfill(d_PassageLandfill);
                Utilities.PropertyHandler.CopyTo<ObjectsFunctions.PassageLandfill>(passageLandfill, contextPassageLandfill);
                contextPassageLandfill.d_PassageLandfill.Updated = DateTime.Now;
                context.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
            }
        }

        public static void Delete(ObjectsFunctions.PassageLandfill passageLandfill)
        {

            DataClassesLandfillDataContext context = Configuration.GetContext();

            LandfillServices.UI.Web.SQL.PassageLandfill d_PassageLandfill = context.PassageLandfills.Single(a => a.ID == passageLandfill.d_PassageLandfill.ID);
            if (passageLandfill != null)
            {
                context.PassageLandfills.DeleteOnSubmit(passageLandfill.d_PassageLandfill);
                context.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
                passageLandfill = null;
            }
        }

        public static void Save(ObjectsFunctions.PassageLandfill passageLandfill)
        {

            if (passageLandfill.ID == 0)
            {
                Insert(passageLandfill);

            }
            else
                Update(passageLandfill);

        }


    }
}
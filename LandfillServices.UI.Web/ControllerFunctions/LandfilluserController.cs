using LandfillServices.UI.Web.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace LandfillServices.UI.Web.ControllerFunctions
{
    public class LandfilluserController
    {
        public static ObjectsFunctions.LandfillUser SearchByID(int ID)
        {
            DataClassesLandfillDataContext context = Configuration.GetContext();
            LandfillServices.UI.Web.SQL.LandfillUser sqlLandfillUser = context.LandfillUsers.SingleOrDefault(a => a.ID == ID);
            if (sqlLandfillUser != null)
                return new ObjectsFunctions.LandfillUser(sqlLandfillUser);
            return null;
        }
        public static ObjectsFunctions.LandfillUser SearchByLogin(string login)
        {
             DataClassesLandfillDataContext context = Configuration.GetContext();
            LandfillServices.UI.Web.SQL.LandfillUser sqlLandfillUser = context.LandfillUsers.SingleOrDefault(a => a.Email == login);
            if (sqlLandfillUser != null)
                return new ObjectsFunctions.LandfillUser(sqlLandfillUser);
            return null;
        }
        public static ObjectsFunctions.LandfillUser SearchByLoginAndPsw(string login, string psw)
        {
            ObjectsFunctions.LandfillUser landfillUser = SearchByLogin(login);
            if (landfillUser != null && landfillUser.Password.Equals(psw))
                return landfillUser;
            return null;
        }
       
        public static List<ObjectsFunctions.LandfillUser> SearchAll()
        {

            DataClassesLandfillDataContext context = Configuration.GetContext();
            var q = (from landfillUser in context.LandfillUsers
                     
                     select new ObjectsFunctions.LandfillUser(landfillUser));
            return q.ToList();
        }

        public static void Insert(ObjectsFunctions.LandfillUser landfillUser)
        {
            
            DataClassesLandfillDataContext context = Configuration.GetContext();
            context.LandfillUsers.InsertOnSubmit(landfillUser.d_landfillUser);
            context.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
        }

        public static void Update(ObjectsFunctions.LandfillUser landfillUser)
        {
            DataClassesLandfillDataContext context = Configuration.GetContext();

            LandfillServices.UI.Web.SQL.LandfillUser d_LandfillUser = context.LandfillUsers.Single(a => a.ID == landfillUser.d_landfillUser.ID);
            if (d_LandfillUser != null)
            {
                ObjectsFunctions.LandfillUser contextLandfillUser = new ObjectsFunctions.LandfillUser(d_LandfillUser);
                Utilities.PropertyHandler.CopyTo<ObjectsFunctions.LandfillUser>(landfillUser, contextLandfillUser);
                contextLandfillUser.d_landfillUser.Updated = DateTime.Now;
                context.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
            }
        }

        public static void Delete(ObjectsFunctions.LandfillUser landfillUser)
        {

            DataClassesLandfillDataContext context = Configuration.GetContext();

            LandfillServices.UI.Web.SQL.LandfillUser d_LandfillUser = context.LandfillUsers.Single(a => a.ID == landfillUser.d_landfillUser.ID);
            if (landfillUser != null)
            {
                context.LandfillUsers.DeleteOnSubmit(landfillUser.d_landfillUser);
                context.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
                landfillUser = null;
            }
        }

        public static void Save(ObjectsFunctions.LandfillUser landfillUser)
        {
             
            if (landfillUser.ID == 0)
            {
                Insert(landfillUser);
                 
            }
            else  
                Update(landfillUser);
            
            }

        }

    }

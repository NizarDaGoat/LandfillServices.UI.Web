using LandfillServices.UI.Web.SQL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace LandfillServices.UI.Web.ControllerFunctions
{
    public class EnumDisplayController
    {
        #region private attributes

        private static DateTime m_LastReload = DateTime.Now.AddMinutes(-10);
        private static List<ObjectsFunctions.EnumDisplay> m_AllEnumDisplayList = null;

        #endregion //private attributes

        #region Search

          public static ObjectsFunctions.EnumDisplay SearchByID(int ID)
        {
            DataClassesLandfillDataContext context = SQL.Configuration.GetContext();
            LandfillServices.UI.Web.SQL.EnumDisplay dalEnumDisplay = context.EnumDisplays.SingleOrDefault(a => a.ID == ID);
            if (dalEnumDisplay != null)
                return new ObjectsFunctions.EnumDisplay(dalEnumDisplay);
            return null;
        }

        public static List<ObjectsFunctions.EnumDisplay> SearchAll()
        {
            if (m_LastReload < DateTime.Now.AddMinutes(-5) || m_AllEnumDisplayList == null)
            {
                lock (typeof(ObjectsFunctions.EnumDisplay))
                {
                    DataClassesLandfillDataContext context = SQL.Configuration.GetContext();
                    var q = from enumDisplay in context.EnumDisplays
                            orderby enumDisplay.Display
                            select new ObjectsFunctions.EnumDisplay(enumDisplay);
                    m_AllEnumDisplayList = q.ToList();
                    m_LastReload = DateTime.Now;
                }
            }
            return m_AllEnumDisplayList;
        }

         public static List<ObjectsFunctions.EnumDisplay> SearchAllByType(string type)
        {   lock (typeof(ObjectsFunctions.EnumDisplay))
                {
                    DataClassesLandfillDataContext context = SQL.Configuration.GetContext();
                    var q = from enumDisplay in context.EnumDisplays
                            where enumDisplay.Type == type
                            orderby enumDisplay.Display
                            select new ObjectsFunctions.EnumDisplay(enumDisplay);
                    m_AllEnumDisplayList = q.ToList();
                    m_LastReload = DateTime.Now;
                }
            
            return m_AllEnumDisplayList;
        }
        public static List<ObjectsFunctions.EnumDisplay> SearchByEnumType(Type type)
        {
            return SearchAllByType(type.ToString());
        }
        public static List<ObjectsFunctions.EnumDisplay> SearchByEnumType(string type)
        {
            return SearchAllByType(type);
        }
        public static string  SearchByEnumTypeAndKey(Type type,int key)
        {
            ObjectsFunctions.EnumDisplay enumDisplay = SearchByEnumType(type).FirstOrDefault(e => e.Key == key);
            if (enumDisplay != null)
            {
                if (enumDisplay.Display.IndexOf("---") >= 0)
                    return string.Empty;
                return enumDisplay.Display;
            }

            string enumString = null;

            try
            {
                enumString = Enum.ToObject(type, key)?.ToString();
                enumString = !string.IsNullOrWhiteSpace(enumString) && !int.TryParse(enumString, out int enumValue) ? enumString : "?";
            }
            catch (Exception)
            {
            }

            return enumString;
        }
        #endregion //Search

        #region Utilities

        #endregion //Utilities

        #region CRUD

        public static void Insert(ObjectsFunctions.EnumDisplay enumDisplay)
        {
            DataClassesLandfillDataContext context = SQL.Configuration.GetContext();
            context.EnumDisplays.InsertOnSubmit(enumDisplay.DalEnumDisplay);
            context.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
        }


        public static void Update(ObjectsFunctions.EnumDisplay enumDisplay)
        {
            DataClassesLandfillDataContext context = SQL.Configuration.GetContext();

            LandfillServices.UI.Web.SQL.EnumDisplay dalEnumDisplay = context.EnumDisplays.Single(a => a.ID == enumDisplay.DalEnumDisplay.ID);
            if (dalEnumDisplay != null)
            {
                ObjectsFunctions.EnumDisplay contextEnumDisplay = new ObjectsFunctions.EnumDisplay(dalEnumDisplay);
                Utilities.PropertyHandler.CopyTo<ObjectsFunctions.EnumDisplay>(enumDisplay, contextEnumDisplay);
                contextEnumDisplay.DalEnumDisplay.Updated = DateTime.Now;
                context.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
            }
        }


        public static void Delete(ObjectsFunctions.EnumDisplay enumDisplay)
        {

            DataClassesLandfillDataContext context = SQL.Configuration.GetContext();

            LandfillServices.UI.Web.SQL.EnumDisplay dalEnumDisplay = context.EnumDisplays.Single(a => a.ID == enumDisplay.DalEnumDisplay.ID);
            if (dalEnumDisplay != null)
            {
                context.EnumDisplays.DeleteOnSubmit(dalEnumDisplay);
                context.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
                enumDisplay = null;
            }
        }


        public static void Save(ObjectsFunctions.EnumDisplay enumDisplay)
        {
            if (enumDisplay.ID == 0)
                Insert(enumDisplay);
            else
                Update(enumDisplay);
        }


        #endregion //CRUD
    }
}
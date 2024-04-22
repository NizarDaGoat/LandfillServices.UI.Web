using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace LandfillServices.UI.Web.Utilities
{
    public class PropertyHandler
    {
        #region Set Properties
        public static void SetProperties(PropertyInfo[] fromFields,
                                         PropertyInfo[] toFields,
                                         object fromRecord,
                                         object toRecord)
        {
            PropertyInfo fromField = null;
            PropertyInfo toField = null;

            try
            {

                if (fromFields == null)
                {
                    return;
                }
                if (toFields == null)
                {
                    return;
                }

                for (int f = 0; f < fromFields.Length; f++)
                {

                    fromField = (PropertyInfo)fromFields[f];

                    for (int t = 0; t < toFields.Length; t++)
                    {

                        toField = (PropertyInfo)toFields[t];

                        if (fromField.Name != toField.Name)
                        {
                            continue;
                        }

                        if (fromField.CanWrite == true)
                            toField.SetValue(toRecord,
                                             fromField.GetValue(fromRecord, null),
                                             null);
                        break;

                    }

                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Set Properties
        public static void SetProperties(PropertyInfo[] fromFields,
                                         object fromRecord,
                                         object toRecord)
        {
            PropertyInfo fromField = null;

            try
            {

                if (fromFields == null)
                {
                    return;
                }

                for (int f = 0; f < fromFields.Length; f++)
                {

                    fromField = (PropertyInfo)fromFields[f];
                    if (fromField.CanWrite == true)
                        fromField.SetValue(toRecord,
                                           fromField.GetValue(fromRecord, null),
                                           null);
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        public static void CopyTo<T>(T fromT, T toT)
        {
            PropertyInfo[] fromFields = typeof(T).GetProperties();
            PropertyHandler.SetProperties(fromFields, fromT, toT);
        }
    }
}
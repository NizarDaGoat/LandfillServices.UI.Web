using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandfillServices.UI.Web.SQL
{
    public class Configuration
    {
        public static SQL.DataClassesLandfillDataContext GetContext()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["LandfillConnectionString"].ConnectionString;
            var context = new SQL.DataClassesLandfillDataContext (connectionString);

            //context.Log = System.Console.Out;
            context.CommandTimeout = 300;
            return context;
        }
        }
    }
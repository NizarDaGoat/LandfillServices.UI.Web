using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandfillServices.UI.Web.Utilities
{
    public class UserUtilities
    {

        public static ObjectsFunctions.LandfillUser User
        {
            get
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                    return HttpContext.Current.User as ObjectsFunctions.LandfillUser;
                return null;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandfillServices.UI.Web.Utilities
{
    public class StringUtilities
    {
        static bool CheckStrongPassword(string entercaractere)
        {
            int good = 0;
            foreach (char c in entercaractere)
            {
                if (c >= 'a' && c <= 'z')
                {
                    good++;
                    break;
                }
            }
            foreach (char c in entercaractere)
            {
                if (c >= 'A' && c <= 'Z')
                {
                    good++;
                    break;
                }
            }
            if (good == 0) return false;
            foreach (char c in entercaractere)
            {
                if (c >= '0' && c <= '9')
                {
                    good++;
                    break;
                }
            }
            if (good == 1) return false;
            if (good == 2)
            {
                char[] special = { '@', '#', '$', '%', '^', '&', '+', '=' };   
                if (entercaractere.IndexOfAny(special) == -1) return false;
            }
            return true;
        }
    }
}
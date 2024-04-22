using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandfillServices.UI.Web.Utilities
{
    public class DecimalUtilities
    {
        public static string ToString(Decimal? number)
        {
            if (number.HasValue)
                return number.Value.ToString("### ### ### ##0.00");
            return string.Empty;
        }

        public static string ToString6Decimal(Decimal? number)
        {
            if (number.HasValue)
                return number.Value.ToString("### ### ### ##0.000000");
            return string.Empty;
        }
    }
}
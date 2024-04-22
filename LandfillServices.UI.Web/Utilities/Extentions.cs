using System;
using System.Collections.Generic;
using System.Linq; 
using System.Web.UI.WebControls;
using System.Text;

namespace LandfillServices.UI.Web.Utilities
{
    public static class Extentions
    {

        public static string Decrypt(this string strQueryString)
        {
            if (String.IsNullOrEmpty(strQueryString))
                return string.Empty;
            else
            {
                EncryptDecryptQueryString objEDQueryString = new EncryptDecryptQueryString();
                return objEDQueryString.Decrypt(strQueryString, "r0b1nr0y");
            }
        }
        public static string Encrypt(this string strQueryString)
        {
            if (String.IsNullOrEmpty(strQueryString))
                return string.Empty;
            else
            {
                EncryptDecryptQueryString objEDQueryString = new EncryptDecryptQueryString();
                return objEDQueryString.Encrypt(strQueryString, "r0b1nr0y");
            }
        }
    }
}
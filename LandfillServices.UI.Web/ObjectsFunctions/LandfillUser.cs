using LandfillServices.UI.Web.SQL;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace LandfillServices.UI.Web.ObjectsFunctions
{
    /// <summary>
    ///  LandfillUser : the user of the application.he can be an administrator or manager, or customer ....
    /// </summary>
    public class LandfillUser : System.Security.Principal.IPrincipal, System.Security.Principal.IIdentity
    {
        private LandfillServices.UI.Web.SQL.LandfillUser m_SqlLandfillUser;
        public int ID
        {

            get
            {
                return m_SqlLandfillUser.ID;
            }
        }
        public DateTime Created 
        {

            get
            {
                return m_SqlLandfillUser.Created;
            }
        }
        public DateTime Updated
        {

            get
            {
                return m_SqlLandfillUser.Updated;
            }
        }
        public   string  CompanyCoperateName
        {
            get
            {
                return m_SqlLandfillUser.CompanyCoperateName;
            }
            set
            {
                 m_SqlLandfillUser.CompanyCoperateName=value;
            }

        }
        public string FirstName 
        {

            get
            {
                return m_SqlLandfillUser.FirstName;
            }
            set
            {
                 m_SqlLandfillUser.FirstName=value;
            }
        }
        public string FirstLastName
        {


            get
            {
                return this.FirstName + " " + this.LastName;
            }
                
            }
        
        public string LastName
        {

            get
            {
                return m_SqlLandfillUser.LastName;
            }
            set
            {
                 m_SqlLandfillUser.LastName=value;
            }
        }
        public string Address
        {

            get
            {
                return m_SqlLandfillUser.Address;
            }
            set
            {
                 m_SqlLandfillUser.Address=value;
            }
        }
        public string City
        {

            get
            {
                return m_SqlLandfillUser.City;
            }
            set
            {
              m_SqlLandfillUser.City = value;
            }
        }
        public string Email
        {
            get
            {
                return m_SqlLandfillUser.Email;
            }
            set
            {
                 m_SqlLandfillUser.Email=value;
            }
        }
        public string PhoneNumber
        {
            get
            {
                return m_SqlLandfillUser.PhoneNumber;
            }
            set
            {
                 m_SqlLandfillUser.PhoneNumber=value;
            }
        }
        /// <summary>
        /// the user profile type : Administrator ; operator...
        /// </summary>
        public int? Type
        {

            get
            {
                return m_SqlLandfillUser.Type;
            }
            set
            {
                 m_SqlLandfillUser.Type=value ;
            }
        }
        public string Password
        {
            get
            {
                return m_SqlLandfillUser.Password;
            }
            set
            {
                m_SqlLandfillUser.Password = value;
            }
        }
        internal LandfillServices.UI.Web.SQL.LandfillUser d_landfillUser
        {
            get
            {
                return m_SqlLandfillUser;
            }
           
        }
        internal LandfillUser(LandfillServices.UI.Web.SQL.LandfillUser sqlLandfillUser)
        {
            m_SqlLandfillUser = sqlLandfillUser;
        }

        public LandfillUser()
        {
            m_SqlLandfillUser = new SQL.LandfillUser () ;
            m_SqlLandfillUser.Created = DateTime.Now ; 
            m_SqlLandfillUser.Updated = DateTime.Now ;
        }

        public System.Security.Principal.IIdentity Identity
        {
            get
            {
                return this;
            }
        }
        public System.Security.Principal.IPrincipal IPrincipal
        {
            get
            {
                return this;
            }
        }
        public string Name
        {
            get
            {
                return this.ID.ToString();
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return true;
            }
        }
        public bool IsInRole(string roleName)
        {
            return true; 
        }
        public string AuthenticationType
        {
            get
            {
                return "";
            }
        }
    }

}
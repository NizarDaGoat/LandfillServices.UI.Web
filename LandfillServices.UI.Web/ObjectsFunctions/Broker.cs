using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Web;

namespace LandfillServices.UI.Web.ObjectsFunctions
{
    
    //Broker : it's a business provider whose mission is to provide the landfill with the various materials intended for recycling
    

    /// <summary>
    /// class Broker : inheritance of the Broker entity from the LandfillUser entity
    /// </summary>
    public class Broker : LandfillUser, System.Security.Principal.IPrincipal, System.Security.Principal.IIdentity
    {
        #region private attributes

        private LandfillServices.UI.Web.SQL.Broker m_SqlBroker;


        #endregion //private attributes

        #region public properties

        /// <summary>
        /// InternalCode : to uniquely identify a Broker in the information system
        /// </summary>
        public string InternalCode
        {
            get
            {
                return m_SqlBroker.InternalCode;
            }
            set
            {
                m_SqlBroker.InternalCode = value;
            }
        }
        /// <summary>
        /// creation of the code nomenclature
        /// </summary>
        public string CurrentBrokerInternalCode
        {
            get
            {
                string nom;
                nom = this.m_SqlBroker.LandfillUser.CompanyCoperateName.Trim().Replace(" ", "0").ToUpper();
                if (nom.Length < 4)
                    for (int i = 0; i < 5 - nom.Length; i++)
                        nom += "0";

                return "Br-"+nom.Substring(0, 4) + this.ID;
            }
        }


        /// <summary>
        /// Company Registration Number
        /// </summary>
        public string CompanyRegistrationNumber
        {
            get
            {
                return m_SqlBroker.CompanyRegistrationNumber;
            }
            set
            {
                m_SqlBroker.CompanyRegistrationNumber = value;
            }
        }
        /// <summary>
        /// Company Name
        /// </summary>
        public string CompanyName
        {
            get
            {
                return m_SqlBroker.CompanyName;
            }
            set
            {
                m_SqlBroker.CompanyName = value;
            }
        }



        #endregion //public properties

        #region internal property
        /// <summary>
        /// property object to sql data linq
        /// </summary>
        internal LandfillServices.UI.Web.SQL.Broker SQLBroker
        {
            get
            {
                return m_SqlBroker;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor with parameters required : to create a new object instance with required parameters
        /// </summary>
        /// <param name="compagny"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        public Broker( string compagny, string email, string password)
            : base()
        {
          m_SqlBroker = new LandfillServices.UI.Web.SQL.Broker
            {
                Created = DateTime.Now,
                Updated = DateTime.Now,
                
            };
             this.CompanyCoperateName = compagny;
            this.Email = email;
            this.Password = password;
         
        }

        /// <summary>
        /// simplified object constructor : to create a new object instance
        /// </summary>
        public Broker()
        {
            m_SqlBroker = new SQL.Broker();
            m_SqlBroker.Created = DateTime.Now;
            m_SqlBroker.Updated = DateTime.Now;
        }

        /// <summary>
        /// Constructor compound for the linq to sql selector
        /// </summary>
        /// <param name="SQLLandfillUser"></param>
        /// <param name="SQLBroker"></param>
        internal Broker(LandfillServices.UI.Web.SQL.LandfillUser SQLLandfillUser, LandfillServices.UI.Web.SQL.Broker  SQLBroker)
            : base(SQLLandfillUser)
        {
            m_SqlBroker = SQLBroker;
        }
        

        #endregion //Constructors
 
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Web;

namespace LandfillServices.UI.Web.ObjectsFunctions
{
    //Logistic : it is the person who goes around the waste collection points and brings them back to the sorting center


    /// <summary>
    /// class Logistic : inheritance of the Broker entity from the LandfillUser entity
    /// </summary>
    public class Logistic : LandfillUser, System.Security.Principal.IPrincipal, System.Security.Principal.IIdentity
    {
        #region private attributes

        private LandfillServices.UI.Web.SQL.Logistic m_SqlLogistic;


        #endregion //private attributes

        #region public properties

        /// <summary>
        /// SocieteID
        /// </summary>

        public string InternalCode
        {
            get
            {
                return m_SqlLogistic.InternalCode;
            }
            set
            {
                m_SqlLogistic.InternalCode = value;
            }
        }

        public string CurrentLogisticInternalCode
        {
            get
            {
                string nom;
                nom = this.m_SqlLogistic.LandfillUser.CompanyCoperateName.Trim().Replace(" ", "0").ToUpper();
                if (nom.Length < 4)
                    for (int i = 0; i < 5 - nom.Length; i++)
                        nom += "0";

                return "Lg-"+ nom.Substring(0, 4) + this.ID;
            }
        }

        public string CompanyName
        {
            get
            {
                return m_SqlLogistic.CompanyName;
            }
            set
            {
                m_SqlLogistic.CompanyName = value;
            }
        }



        public string CompanyRegistrationNumber
        {
            get
            {
                return m_SqlLogistic.CompanyRegistrationNumber;
            }
            set
            {
                m_SqlLogistic.CompanyRegistrationNumber = value;
            }
        }

        
        #endregion //public properties

        

        #region internal property
        internal LandfillServices.UI.Web.SQL.Logistic SQLLogistic
        {
            get
            {
                return m_SqlLogistic;
            }
        }

        #endregion

        #region Constructors

        public Logistic(string compagny, string email, string password)
            : base()
        {
            m_SqlLogistic = new LandfillServices.UI.Web.SQL.Logistic
            {
                Created = DateTime.Now,
                Updated = DateTime.Now,

            };
            this.CompanyCoperateName = compagny;
            this.Email = email;
            this.Password = password;

        }

        public Logistic()
        {
            m_SqlLogistic = new SQL.Logistic();
            m_SqlLogistic.Created = DateTime.Now;
            m_SqlLogistic.Updated = DateTime.Now;
        }
        internal Logistic(LandfillServices.UI.Web.SQL.LandfillUser SQLLandfillUser, LandfillServices.UI.Web.SQL.Logistic SQLLogistic)
            : base(SQLLandfillUser)
        {
            m_SqlLogistic = SQLLogistic;
        }


        #endregion //Constructors

        #region public methods

        #endregion //Constructors
    }
}
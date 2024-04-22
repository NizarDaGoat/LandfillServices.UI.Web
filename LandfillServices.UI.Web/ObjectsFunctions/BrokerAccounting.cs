using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandfillServices.UI.Web.ObjectsFunctions
{
    /// <summary>
    /// BrokerAccounting : the broker's accounting which allows you to track the payments of these commissions and whether they are paid or not. this brings together several commissions from the same broker
    /// </summary>
    public class BrokerAccounting
    {
        private LandfillServices.UI.Web.SQL.BrokerAccounting m_SqlBrokerAccounting;
        private Broker m_Broker;
        public int ID
        {
            get
            {
                return m_SqlBrokerAccounting.ID;
            }
        }

        /// <summary>
        /// the broker ID concerned by this Accounting
        /// </summary>
        public int BrokerID
        {
            get
            {
                return m_SqlBrokerAccounting.BrokerID;
            }
            set
            {
                m_SqlBrokerAccounting.BrokerID = value;
            }
        }

        /// <summary>
        /// the broker object concerned by this Accounting
        /// </summary>
        public Broker Broker
        {
            get
            {
                if (m_Broker == null)
                    m_Broker = ControllerFunctions.BrokerController.SearchByID(this.BrokerID);

                return m_Broker;
            }
        }

        /// <summary>
        /// Company Coperate Name of broker
        /// </summary>
        public string CompanyCoperateName
        {
            get
            {
                return this.Broker.CompanyCoperateName;
            }
        }

        /// <summary>
        /// the commission payment date (transfer date). if this is indicated then we consider that the commission is paid
        /// </summary>
        public DateTime? TransferDate
        {
            get
            {
                return m_SqlBrokerAccounting.TransferDate;
            }
            set
            {
                m_SqlBrokerAccounting.TransferDate = value;
            }
        }
        public DateTime Created
        {
            get
            {
                return m_SqlBrokerAccounting.Created;
            }
        }
        public DateTime Updated
        {
            get
            {
                return m_SqlBrokerAccounting.Updated;
            }
        }

        /// <summary>
        /// Formatted Transfer Date (for display) :jj/mm/aaaa
        /// </summary>
        public string TransferDateFormatted
        {
            get
            {
                if (m_SqlBrokerAccounting.TransferDate.HasValue)
                    return m_SqlBrokerAccounting.TransferDate.Value.ToShortDateString();
                else
                    return null;
            }

        }

        #region internal property
        /// <summary>
        /// property object to sql data linq
        /// </summary>
        internal LandfillServices.UI.Web.SQL.BrokerAccounting d_BrokerAccounting
        {
            get
            {
                return m_SqlBrokerAccounting;
            }

        }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor compound for the linq to sql selector 
        /// </summary>
        /// <param name="sqlBrokerAccounting"></param>
        internal BrokerAccounting(LandfillServices.UI.Web.SQL.BrokerAccounting sqlBrokerAccounting)
        {
            m_SqlBrokerAccounting = sqlBrokerAccounting;
        }

        /// <summary>
        /// simplified object constructor : to create a new object instance
        /// </summary>
        public BrokerAccounting()
        {
            m_SqlBrokerAccounting = new SQL.BrokerAccounting();
            m_SqlBrokerAccounting.Created = DateTime.Now;
            m_SqlBrokerAccounting.Updated = DateTime.Now;
        }
        #endregion

    }
}
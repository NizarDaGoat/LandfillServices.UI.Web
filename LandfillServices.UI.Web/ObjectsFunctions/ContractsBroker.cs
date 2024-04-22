using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandfillServices.UI.Web.ObjectsFunctions
{
    /// <summary>
    /// ContractsBroker : use to define a legal framework between the different parts of the deal
    /// </summary>
    public class ContractsBroker
    {
        private LandfillServices.UI.Web.SQL.ContractsBroker m_SqlContractsBroker;
        private Broker m_Broker;
        public int ID
        {
            get
            {
                return m_SqlContractsBroker.ID;
            }
        }
        public int BrokerID
        {
            get
            {
                return m_SqlContractsBroker.BrokerID;
            }
            set
            {
                m_SqlContractsBroker.BrokerID = value;
            }
        }

        public Broker Broker
        {
            get
            {
                if (m_Broker == null)
                    m_Broker = ControllerFunctions.BrokerController.SearchByID(this.BrokerID);

                return m_Broker;
            }
        }
        public DateTime Created
        {
            get
            {
                return m_SqlContractsBroker.Created;
            }
        }
        public DateTime Updated
        {
            get
            {
                return m_SqlContractsBroker.Updated;
            }
        }
        public string BrokerCompanyCoperateName
        {
            get
            {
                
                return this.Broker.CompanyCoperateName;
            }

        }
        /// <summary>
        /// Subscription Date is the effective date of contract
        /// </summary>
        public DateTime SubscriptionDate
        {
            get
            {
                return m_SqlContractsBroker.SubscriptionDate;
            }
            set
            {
                m_SqlContractsBroker.SubscriptionDate = value;
            }
        }
        public string SubscriptionDateFormatted
        {
            get
            {
                return m_SqlContractsBroker.SubscriptionDate.ToShortDateString();
            }

        }

        /// <summary>
        /// Termination Date is the contract termination date
        /// </summary>
        public DateTime? TerminationDate
        {
            get
            {
                return m_SqlContractsBroker.TerminationDate;
            }
            set
            {
                m_SqlContractsBroker.TerminationDate = value;
            }
        }
        public string TerminationDateFormatted
        {
            get
            {
                if(m_SqlContractsBroker.TerminationDate.HasValue)
                return m_SqlContractsBroker.TerminationDate.Value.ToShortDateString();
                return null;
            }

        }

        /// <summary>
        /// creation of the contract number nomenclature
        /// </summary>
        public string CurrentContractNumber
        {
            get
            {
                return  "C-BRK" + string.Format("{0:000000}", this.ID);
            }
        }

        /// <summary>
        /// Contracts Status : is a enum display value : Current ; Termined
        /// </summary>
        public ContractsBrokerStatus Status
        {
            get
            {
                 return (ContractsBrokerStatus)m_SqlContractsBroker.Status;
        
            }
            set
            {
                m_SqlContractsBroker.Status = (int)value;
                
            }
        }

        /// <summary>
        /// the contract number 
        /// </summary>
        public string Number
        {
            get
            {
                return m_SqlContractsBroker.Number;
            }
            set
            {
                m_SqlContractsBroker.Number = value;
            }
        }

        #region internal property
        /// <summary>
        /// property object to sql data linq
        /// </summary>      
        internal LandfillServices.UI.Web.SQL.ContractsBroker d_ContractsBroker
        {
            get
            {
                return m_SqlContractsBroker;
            }

        }

        #endregion

        #region Constructors
        /// <summary>
        /// Constructor compound for the linq to sql selector 
        /// </summary>
        /// <param name="sqlContractsBroker"></param>
        internal ContractsBroker(LandfillServices.UI.Web.SQL.ContractsBroker sqlContractsBroker)
        {
            m_SqlContractsBroker = sqlContractsBroker;
        }

        /// <summary>
        /// simplified object constructor : to create a new object instance
        /// </summary>
        public ContractsBroker()
        {
            m_SqlContractsBroker = new SQL.ContractsBroker();
            m_SqlContractsBroker.Created = DateTime.Now;
            m_SqlContractsBroker.Updated = DateTime.Now;
        }

        #endregion
    }

}

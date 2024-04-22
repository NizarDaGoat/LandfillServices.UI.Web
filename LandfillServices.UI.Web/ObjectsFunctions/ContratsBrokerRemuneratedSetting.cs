using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandfillServices.UI.Web.ObjectsFunctions
{
    /// <summary>
    /// brings together all the settings related to the contract. example the commission rate or the price
    /// </summary>
    public class ContratsBrokerRemuneratedSetting
    {
        private LandfillServices.UI.Web.SQL.ContratsBrokerRemuneratedSetting m_SqlContratsBrokerRemuneratedSetting;
        private ContractsBroker m_ContractsBroker;
        public int ID
        {
            get
            {
                return m_SqlContratsBrokerRemuneratedSetting.ID;
            }
        }
        /// <summary>
        /// the contract ID to which it is attached
        /// </summary>
        public int ContractsBrokerID
        {
            get
            {
                return m_SqlContratsBrokerRemuneratedSetting.ContratsBrokerID;
            }
            set
            {
                m_SqlContratsBrokerRemuneratedSetting.ContratsBrokerID = value;
            }
        }
        /// <summary>
        /// the contract object to which it is attached
        /// </summary>
        public ContractsBroker ContractsBroker
        {
            get
            {
                if (m_ContractsBroker == null)
                    m_ContractsBroker = ControllerFunctions.ContractsBrokerController.SearchByID(this.ContractsBrokerID);

                return m_ContractsBroker;
            }
        }
        public DateTime Created
        {
            get
            {
                return m_SqlContratsBrokerRemuneratedSetting.Created;
            }
        }
        public DateTime Updated
        {
            get
            {
                return m_SqlContratsBrokerRemuneratedSetting.Updated;
            }
        }
        /// <summary>
        /// setting start date is used to define the start of application of the values
        /// </summary>
        public DateTime StartDate
        {
            get
            {
                return m_SqlContratsBrokerRemuneratedSetting.StartDate;
            }
            set
            {
                m_SqlContratsBrokerRemuneratedSetting.StartDate = value;
            }
        }
        public string StartDateFormatted
        {
            get
            {
                return m_SqlContratsBrokerRemuneratedSetting.StartDate.ToShortDateString();
            }

        }
        /// <summary>
        /// end date of settings is used to define the end of application of the values
        /// </summary>
        public DateTime? EndDate
        {
            get
            {
                return m_SqlContratsBrokerRemuneratedSetting.EndDate;
            }
            set
            {
                m_SqlContratsBrokerRemuneratedSetting.EndDate = value;
            }
        }
        public string EndDateFormatted
        {
            get
            {
                if (m_SqlContratsBrokerRemuneratedSetting.EndDate.HasValue)
                    return m_SqlContratsBrokerRemuneratedSetting.EndDate.Value.ToShortDateString();
                return null;
            }

        }

        /// <summary>
        /// ProductName : type of product : plastics ; aliminum ; glass... it's a enum display value
        /// </summary>
        public ProductName ProductName
        {
            get
            {
                return (ProductName)m_SqlContratsBrokerRemuneratedSetting.ProductName;

            }
            set
            {
                m_SqlContratsBrokerRemuneratedSetting.ProductName = (int)value;

            }
        }

        /// <summary>
        /// the reference amount for calculating commissions. it is expressed in £ and multiplied by the weight in the calculation
        /// </summary>
        public decimal Value
        {
            get
            {
                return m_SqlContratsBrokerRemuneratedSetting.Value;
            }
            set
            {
                m_SqlContratsBrokerRemuneratedSetting.Value = value;
            }
        }
        internal LandfillServices.UI.Web.SQL.ContratsBrokerRemuneratedSetting d_ContratsBrokerRemuneratedSetting
        {
            get
            {
                return m_SqlContratsBrokerRemuneratedSetting;
            }

        }
        internal ContratsBrokerRemuneratedSetting(LandfillServices.UI.Web.SQL.ContratsBrokerRemuneratedSetting sqlContratsBrokerRemuneratedSetting)
        {
            m_SqlContratsBrokerRemuneratedSetting = sqlContratsBrokerRemuneratedSetting;
        }

        public ContratsBrokerRemuneratedSetting()
        {
            m_SqlContratsBrokerRemuneratedSetting = new SQL.ContratsBrokerRemuneratedSetting();
            m_SqlContratsBrokerRemuneratedSetting.Created = DateTime.Now;
            m_SqlContratsBrokerRemuneratedSetting.Updated = DateTime.Now;
        }


    }

}

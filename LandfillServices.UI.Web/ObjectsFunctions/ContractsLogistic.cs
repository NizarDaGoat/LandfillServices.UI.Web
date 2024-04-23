using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandfillServices.UI.Web.ObjectsFunctions
{
    public class ContractsLogistic
    {
        /// <summary>
        /// ContractsLogistic : use to define a legal framework between the different parts of the deal
        /// </summary>
        private LandfillServices.UI.Web.SQL.ContractsLogistic m_SqlContractsLogistic;
        private Logistic m_Logistic;
        public int ID
        {
            get
            {
                return m_SqlContractsLogistic.ID;
            }
        }
        public int LogisticID
        {
            get
            {
                return m_SqlContractsLogistic.LogisticsID;
            }
            set
            {
                m_SqlContractsLogistic.LogisticsID = value;
            }
        }

        public Logistic Logistic
        {
            get
            {
                if (m_Logistic == null)
                    m_Logistic = ControllerFunctions.LogisticController.SearchByID(this.LogisticID);

                return m_Logistic;
            }
        }
        public DateTime Created
        {
            get
            {
                return m_SqlContractsLogistic.Created;
            }
        }
        public DateTime Updated
        {
            get
            {
                return m_SqlContractsLogistic.Updated;
            }
        }
        public string LogisticCompanyCoperateName
        {
            get
            {

                return this.Logistic.CompanyCoperateName;
            }

        }
        public DateTime SubscriptionDate
        {
            get
            {
                return m_SqlContractsLogistic.SubscriptionDate;
            }
            set
            {
                m_SqlContractsLogistic.SubscriptionDate = value;
            }
        }
        public string SubscriptionDateFormatted
        {
            get
            {
                return m_SqlContractsLogistic.SubscriptionDate.ToShortDateString();
            }

        }
        public DateTime? TerminationDate
        {
            get
            {
                return m_SqlContractsLogistic.TerminationDate;
            }
            set
            {
                m_SqlContractsLogistic.TerminationDate = value;
            }
        }
        public string TerminationDateFormatted
        {
            get
            {
                if (m_SqlContractsLogistic.TerminationDate.HasValue)
                    return m_SqlContractsLogistic.TerminationDate.Value.ToShortDateString();
                return null;
            }

        }
        public string CurrentContractNumber
        {
            get
            {
                return "C-LGC" + string.Format("{0:000000}", this.ID);
            }
        }
        public ContractsLogisticStatus Status
        {
            get
            {
                return (ContractsLogisticStatus)m_SqlContractsLogistic.Status;

            }
            set
            {
                m_SqlContractsLogistic.Status = (int)value;

            }
        }
        public string Number
        {
            get
            {
                return m_SqlContractsLogistic.Number;
            }
            set
            {
                m_SqlContractsLogistic.Number = value;
            }
        }
        internal LandfillServices.UI.Web.SQL.ContractsLogistic d_ContractsLogistic
        {
            get
            {
                return m_SqlContractsLogistic;
            }

        }
        internal ContractsLogistic(LandfillServices.UI.Web.SQL.ContractsLogistic sqlContractsLogistic)
        {
            m_SqlContractsLogistic = sqlContractsLogistic;
        }

        public ContractsLogistic()
        {
            m_SqlContractsLogistic = new SQL.ContractsLogistic();
            m_SqlContractsLogistic.Created = DateTime.Now;
            m_SqlContractsLogistic.Updated = DateTime.Now;
        }


    }
}
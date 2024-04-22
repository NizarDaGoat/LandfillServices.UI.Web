using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandfillServices.UI.Web.ObjectsFunctions
{
    /// <summary>
    /// LogisticAccounting : the logistic's accounting which allows you to track the payments of these commissions and whether they are paid or not. this brings together several commissions from the same logistic
    /// </summary>
    public class LogisticAccounting
    {

        private LandfillServices.UI.Web.SQL.LogisticAccounting m_SqlLogisticAccounting;
        private Logistic m_Logistic;
        public int ID
        {
            get
            {
                return m_SqlLogisticAccounting.ID;
            }
        }
        public int LogisticID
        {
            get
            {
                return m_SqlLogisticAccounting.LogisticID;
            }
            set
            {
                m_SqlLogisticAccounting.LogisticID = value;
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
        public string CompanyCoperateName
        {
            get
            {
                return this.Logistic.CompanyCoperateName;
            }
        }
        public DateTime? TransferDate
        {
            get
            {
                return m_SqlLogisticAccounting.TransferDate;
            }
            set
            {
                m_SqlLogisticAccounting.TransferDate = value;
            }
        }
        public DateTime Created
        {
            get
            {
                return m_SqlLogisticAccounting.Created;
            }
        }
        public DateTime Updated
        {
            get
            {
                return m_SqlLogisticAccounting.Updated;
            }
        }


        public string TransferDateFormatted
        {
            get
            {
                if (m_SqlLogisticAccounting.TransferDate.HasValue)
                    return m_SqlLogisticAccounting.TransferDate.Value.ToShortDateString();
                else
                    return null;
            }

        }


        internal LandfillServices.UI.Web.SQL.LogisticAccounting d_LogisticAccounting
        {
            get
            {
                return m_SqlLogisticAccounting;
            }

        }
        internal LogisticAccounting(LandfillServices.UI.Web.SQL.LogisticAccounting sqlLogisticAccounting)
        {
            m_SqlLogisticAccounting = sqlLogisticAccounting;
        }

        public LogisticAccounting()
        {
            m_SqlLogisticAccounting = new SQL.LogisticAccounting();
            m_SqlLogisticAccounting.Created = DateTime.Now;
            m_SqlLogisticAccounting.Updated = DateTime.Now;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandfillServices.UI.Web.ObjectsFunctions
{
    public class LogisticPaymentCommission
    {
        private LandfillServices.UI.Web.SQL.LogisticPaymentCommission m_SqlLogisticPaymentCommission;
        private LogisticTurnCollect m_LogisticTurnCollect;
        private LogisticAccounting m_LogisticAccounting;
        public int ID
        {
            get
            {
                return m_SqlLogisticPaymentCommission.ID;
            }
        }
        public int LogisticTurnCollectID
        {
            get
            {
                return m_SqlLogisticPaymentCommission.LogisticTurnCollectID;
            }
            set
            {
                m_SqlLogisticPaymentCommission.LogisticTurnCollectID = value;
            }
        }

        public LogisticTurnCollect LogisticTurnCollect
        {
            get
            {
                if (m_LogisticTurnCollect == null)
                    m_LogisticTurnCollect = ControllerFunctions.LogisticTurnCollectController.SearchByID(this.LogisticTurnCollectID);

                return m_LogisticTurnCollect;
            }
        }

        public int? LogisticAccountingID
        {
            get
            {
                if (m_SqlLogisticPaymentCommission.LogisticAccountingID.HasValue)
                    return m_SqlLogisticPaymentCommission.LogisticAccountingID;
                else
                    return null;
            }
            set
            {
                m_SqlLogisticPaymentCommission.LogisticAccountingID = value;
            }
        }

        public LogisticAccounting LogisticAccounting
        {
            get
            {
                if (m_LogisticAccounting == null)
                    if (this.LogisticAccountingID.HasValue)
                        m_LogisticAccounting = ControllerFunctions.LogisticAccountingController.SearchByID(this.LogisticAccountingID.Value);

                return m_LogisticAccounting;
            }
        }
        public string CompanyCoperateName
        {
            get
            {
                return this.LogisticTurnCollect.ContractsLogistic.Logistic.CompanyCoperateName;
            }
        }
        public string ContractNumber
        {
            get
            {
                return this.LogisticTurnCollect.ContractsLogistic.Number;
            }
        }
      
      
        public DateTime Created
        {
            get
            {
                return m_SqlLogisticPaymentCommission.Created;
            }
        }
        public DateTime Updated
        {
            get
            {
                return m_SqlLogisticPaymentCommission.Updated;
            }
        }


        public DateTime? PaymentDate
        {
            get
            {
                return m_SqlLogisticPaymentCommission.PaymentDate;
            }
            set
            {
                m_SqlLogisticPaymentCommission.PaymentDate = value;
            }
        }
        public string PaymentDateFormatted
        {
            get
            {
                if (m_SqlLogisticPaymentCommission.PaymentDate.HasValue)
                    return m_SqlLogisticPaymentCommission.PaymentDate.Value.ToShortDateString();
                return null;
            }

        }
        public string CreatedFormatted
        {
            get
            {
                return m_SqlLogisticPaymentCommission.Created.ToShortDateString();
            }
        }


        public decimal Amount
        {
            get
            {
                return m_SqlLogisticPaymentCommission.Amount;
            }
            set
            {
                m_SqlLogisticPaymentCommission.Amount = value;
            }
        }
        internal LandfillServices.UI.Web.SQL.LogisticPaymentCommission d_LogisticPaymentCommission
        {
            get
            {
                return m_SqlLogisticPaymentCommission;
            }

        }
        internal LogisticPaymentCommission(LandfillServices.UI.Web.SQL.LogisticPaymentCommission sqlLogisticPaymentCommission)
        {
            m_SqlLogisticPaymentCommission = sqlLogisticPaymentCommission;
        }

        public LogisticPaymentCommission()
        {
            m_SqlLogisticPaymentCommission = new SQL.LogisticPaymentCommission();
            m_SqlLogisticPaymentCommission.Created = DateTime.Now;
            m_SqlLogisticPaymentCommission.Updated = DateTime.Now;
        }

    }
}
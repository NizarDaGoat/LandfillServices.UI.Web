using LandfillServices.UI.Web.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandfillServices.UI.Web.ObjectsFunctions
{
    /// <summary>
    /// brings together all the settings related to the contract. example the commission rate or the price
    /// </summary>
    public class ContratsLogisticsRemuneratedSetting
    {
        private LandfillServices.UI.Web.SQL.ContratsLogisticsRemuneratedSetting m_SqlContratsLogisticsRemuneratedSetting;
        private ContractsLogistic m_ContractsLogistic;
        public int ID
        {
            get
            {
                return m_SqlContratsLogisticsRemuneratedSetting.ID;
            }
        }
        public int ContractsLogisticsID
        {
            get
            {
                return m_SqlContratsLogisticsRemuneratedSetting.ContratsLogisticsID;
            }
            set
            {
                m_SqlContratsLogisticsRemuneratedSetting.ContratsLogisticsID = value;
            }
        }

        public ContractsLogistic ContractsLogistic
        {
            get
            {
                if (m_ContractsLogistic == null)
                    m_ContractsLogistic = ControllerFunctions.ContractsLogisticController.SearchByID(this.ContractsLogisticsID);

                return m_ContractsLogistic;
            }
        }
        public DateTime Created
        {
            get
            {
                return m_SqlContratsLogisticsRemuneratedSetting.Created;
            }
        }
        public DateTime Updated
        {
            get
            {
                return m_SqlContratsLogisticsRemuneratedSetting.Updated;
            }
        }

        public DateTime StartDate
        {
            get
            {
                return m_SqlContratsLogisticsRemuneratedSetting.StartDate;
            }
            set
            {
                m_SqlContratsLogisticsRemuneratedSetting.StartDate = value;
            }
        }
        public string StartDateFormatted
        {
            get
            {
                return m_SqlContratsLogisticsRemuneratedSetting.StartDate.ToShortDateString();
            }

        }
        public DateTime? EndDate
        {
            get
            {
                return m_SqlContratsLogisticsRemuneratedSetting.EndDate;
            }
            set
            {
                m_SqlContratsLogisticsRemuneratedSetting.EndDate = value;
            }
        }
        public string EndDateFormatted
        {
            get
            {
                if (m_SqlContratsLogisticsRemuneratedSetting.EndDate.HasValue)
                    return m_SqlContratsLogisticsRemuneratedSetting.EndDate.Value.ToShortDateString();
                return null;
            }

        }

        public KmInterval KmInterval
        {
            get
            {
                return (KmInterval)m_SqlContratsLogisticsRemuneratedSetting.KmInterval;

            }
            set
            {
                m_SqlContratsLogisticsRemuneratedSetting.KmInterval = (int)value;

            }
        }
        public string KmIntervalDisplay
        {
            get
            {
                return ControllerFunctions.EnumDisplayController.SearchByEnumTypeAndKey(typeof(ObjectsFunctions.KmInterval), (int)this.d_ContratsLogisticsRemuneratedSetting.KmInterval);
            }
        }
        public decimal Value
        {
            get
            {
                return m_SqlContratsLogisticsRemuneratedSetting.Value;
            }
            set
            {
                m_SqlContratsLogisticsRemuneratedSetting.Value = value;
            }
        }
        internal LandfillServices.UI.Web.SQL.ContratsLogisticsRemuneratedSetting d_ContratsLogisticsRemuneratedSetting
        {
            get
            {
                return m_SqlContratsLogisticsRemuneratedSetting;
            }

        }
        internal ContratsLogisticsRemuneratedSetting(LandfillServices.UI.Web.SQL.ContratsLogisticsRemuneratedSetting sqlContratsLogisticsRemuneratedSetting)
        {
            m_SqlContratsLogisticsRemuneratedSetting = sqlContratsLogisticsRemuneratedSetting;
        }

        public ContratsLogisticsRemuneratedSetting()
        {
            m_SqlContratsLogisticsRemuneratedSetting = new SQL.ContratsLogisticsRemuneratedSetting();
            m_SqlContratsLogisticsRemuneratedSetting.Created = DateTime.Now;
            m_SqlContratsLogisticsRemuneratedSetting.Updated = DateTime.Now;
        }

    }
}
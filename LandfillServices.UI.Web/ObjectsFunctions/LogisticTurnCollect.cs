using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandfillServices.UI.Web.ObjectsFunctions
{
    /// <summary>
    /// LogisticTurnCollect : to record waste collection rounds and visits to the sorting center
    /// </summary>
    public class LogisticTurnCollect
    {
        private LandfillServices.UI.Web.SQL.LogisticTurnCollect m_SqlLogisticTurnCollect;
        private ContractsLogistic m_ContractsLogistic;
        public int ID
        {
            get
            {
                return m_SqlLogisticTurnCollect.ID;
            }
        }
        public int ContractsLogisticID
        {
            get
            {
                return m_SqlLogisticTurnCollect.ContractsLogisticsID;
            }
            set
            {
                m_SqlLogisticTurnCollect.ContractsLogisticsID = value;
            }
        }

        public ContractsLogistic ContractsLogistic
        {
            get
            {
                if (m_ContractsLogistic == null)
                    m_ContractsLogistic = ControllerFunctions.ContractsLogisticController.SearchByID(this.ContractsLogisticID);

                return m_ContractsLogistic;
            }
        }
        public string ContractNumber
        {
            get
            {
                return this.ContractsLogistic.Number;
            }
        }
        public DateTime Created
        {
            get
            {
                return m_SqlLogisticTurnCollect.Created;
            }
        }
        public DateTime Updated
        {
            get
            {
                return m_SqlLogisticTurnCollect.Updated;
            }
        }

        public DateTime Date
        {
            get
            {
                return m_SqlLogisticTurnCollect.Date;
            }
            set
            {
                m_SqlLogisticTurnCollect.Date = value;
            }
        }
        public string DateFormatted
        {
            get
            {
                return m_SqlLogisticTurnCollect.Date.ToShortDateString();
            }

        }

        /// <summary>
        /// the distance traveled to collect waste through the collection points and the sorting center
        /// </summary>
        public decimal Distance
        {
            get
            {
                return m_SqlLogisticTurnCollect.Distance;
            }
            set
            {
                m_SqlLogisticTurnCollect.Distance = value;
            }
        }

        
        internal LandfillServices.UI.Web.SQL.LogisticTurnCollect d_LogisticTurnCollect
        {
            get
            {
                return m_SqlLogisticTurnCollect;
            }

        }
        internal LogisticTurnCollect(LandfillServices.UI.Web.SQL.LogisticTurnCollect sqlLogisticTurnCollect)
        {
            m_SqlLogisticTurnCollect = sqlLogisticTurnCollect;
        }

        public LogisticTurnCollect()
        {
            m_SqlLogisticTurnCollect = new SQL.LogisticTurnCollect();
            m_SqlLogisticTurnCollect.Created = DateTime.Now;
            m_SqlLogisticTurnCollect.Updated = DateTime.Now;
        }

    }
}
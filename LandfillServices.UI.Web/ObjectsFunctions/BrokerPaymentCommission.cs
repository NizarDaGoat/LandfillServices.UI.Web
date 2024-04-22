using LandfillServices.UI.Web.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandfillServices.UI.Web.ObjectsFunctions
{
    /// <summary>
    /// BrokerPaymentCommission : to manage broker commissions
    /// </summary>
    public class BrokerPaymentCommission
    {
        #region private attributes

        private LandfillServices.UI.Web.SQL.BrokerPaymentCommission m_SqlBrokerPaymentCommission;
        private BrokerPassageProduct m_BrokerPassageProduct;
        private BrokerAccounting m_BrokerAccounting;

        #endregion
        public int ID
        {
            get
            {
                return m_SqlBrokerPaymentCommission.ID;
            }
        }

        /// <summary>
        /// the BrokerPassageProduct ID attached to the BrokerPaymentCommission
        /// </summary>
        public int BrokerPassageProductID
        {
            get
            {
                return m_SqlBrokerPaymentCommission.BrokerPassageProductID;
            }
            set
            {
                m_SqlBrokerPaymentCommission.BrokerPassageProductID = value;
            }
        }

        /// <summary>
        /// the BrokerPassageProduct object attached to the BrokerPaymentCommission
        /// </summary>
        public BrokerPassageProduct BrokerPassageProduct
        {
            get
            {
                if (m_BrokerPassageProduct == null)
                    m_BrokerPassageProduct = ControllerFunctions.BrokerPassageProductController.SearchByID(this.BrokerPassageProductID);

                return m_BrokerPassageProduct;
            }
        }

        /// <summary>
        /// the BrokerAccounting ID attached to the BrokerPaymentCommission
        /// </summary>
        public int? BrokerAccountingID
        {
            get
            {
                if(m_SqlBrokerPaymentCommission.BrokerAccountingID.HasValue)
                    return m_SqlBrokerPaymentCommission.BrokerAccountingID;
              else
                    return null;
            }
            set
            {
                m_SqlBrokerPaymentCommission.BrokerAccountingID = value;
            }
        }

        /// <summary>
        /// the BrokerAccounting object attached to the BrokerPaymentCommission
        /// </summary>
        public BrokerAccounting BrokerAccounting
        {
            get
            {
                if (m_BrokerAccounting == null)
                    if(this.BrokerAccountingID.HasValue)
                    m_BrokerAccounting = ControllerFunctions.BrokerAccountingController.SearchByID(this.BrokerAccountingID.Value);

                return m_BrokerAccounting;
            }
        }


        /// <summary>
        /// Broker Company Coperate Name
        /// </summary>
        public string CompanyCoperateName
        {
            get
            {
                return this.BrokerPassageProduct.ContractsBroker.Broker.CompanyCoperateName;
            }
        }


        /// <summary>
        /// Contract Number attached to the BrokerPaymentCommission
        /// </summary>
        public string ContractNumber
        {
            get
            {
                return this.BrokerPassageProduct.ContractsBroker.Number;
            }
        }

        /// <summary>
        /// Product Name of this commission
        /// </summary>
        public string ProductName
        {
            get
            {
                return this.BrokerPassageProduct.ProductName.ToString();
            }
        }

        /// <summary>
        /// PaymentDate is null : record if payment is made
        /// </summary>
        public DateTime? PaymentDate
        {
            get
            {
                return m_SqlBrokerPaymentCommission.PaymentDate;
            }
            set
            {
                m_SqlBrokerPaymentCommission.PaymentDate = value;
            }
        }

        /// <summary>
        /// Formatted Payment Date (for display) :jj/mm/aaaa
        /// </summary>
        public string PaymentDateFormatted
        {
            get
            {
                if (m_SqlBrokerPaymentCommission.PaymentDate.HasValue)
                    return m_SqlBrokerPaymentCommission.PaymentDate.Value.ToShortDateString();
                return null;
            }

        }

        /// <summary>
        /// Formatted Created Date (for display) :jj/mm/aaaa
        /// </summary>
        public string CreatedFormatted
        {
            get
            {
                    return m_SqlBrokerPaymentCommission.Created.ToShortDateString();                 
            }
        }
         
        /// <summary>
        /// Amount of commissions
        /// </summary>
        public decimal Amount
        {
            get
            {
                return m_SqlBrokerPaymentCommission.Amount;
            }
            set
            {
                m_SqlBrokerPaymentCommission.Amount = value;
            }
        }

        public DateTime Created
        {
            get
            {
                return m_SqlBrokerPaymentCommission.Created;
            }
        }
        public DateTime Updated
        {
            get
            {
                return m_SqlBrokerPaymentCommission.Updated;
            }
        }


        #region internal property
        /// <summary>
        /// property object to sql data linq
        /// </summary>      
    
        internal LandfillServices.UI.Web.SQL.BrokerPaymentCommission d_BrokerPaymentCommission
        {
            get
            {
                return m_SqlBrokerPaymentCommission;
            }

        }

        #endregion

        #region Constructors
        /// <summary>
        /// Constructor compound for the linq to sql selector 
        /// </summary>
        /// <param name="sqlBrokerPaymentCommission"></param>
        internal BrokerPaymentCommission(LandfillServices.UI.Web.SQL.BrokerPaymentCommission sqlBrokerPaymentCommission)
        {
            m_SqlBrokerPaymentCommission = sqlBrokerPaymentCommission;
        }

        /// <summary>
        /// simplified object constructor : to create a new object instance
        /// </summary>
        public BrokerPaymentCommission()
        {
            m_SqlBrokerPaymentCommission = new SQL.BrokerPaymentCommission();
            m_SqlBrokerPaymentCommission.Created = DateTime.Now;
            m_SqlBrokerPaymentCommission.Updated = DateTime.Now;
        }

        #endregion
    }
}
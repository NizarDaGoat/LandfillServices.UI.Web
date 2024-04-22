using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandfillServices.UI.Web.ObjectsFunctions
{
    /// <summary>
    /// BrokerPassageProduct : to record the transition from broker to landfill with quantity, product type and date
    /// </summary>
    public class BrokerPassageProduct
    {
        private LandfillServices.UI.Web.SQL.BrokerPassageProduct m_SqlBrokerPassageProduct;
        private ContractsBroker m_ContractsBroker;
        public int ID
        {
            get
            {
                return m_SqlBrokerPassageProduct.ID;
            }
        }

        /// <summary>
        /// the contract ID to which it is attached
        /// </summary>
        public int ContractsBrokerID
        {
            get
            {
                return m_SqlBrokerPassageProduct.ContractsBrokerID;
            }
            set
            {
                m_SqlBrokerPassageProduct.ContractsBrokerID = value;
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

        /// <summary>
        /// Contract Number
        /// </summary>
        public string ContractNumber
        {
            get
            {
                return this.ContractsBroker.Number;
            }
        }
        public DateTime Created
        {
            get
            {
                return m_SqlBrokerPassageProduct.Created;
            }
        }
        public DateTime Updated
        {
            get
            {
                return m_SqlBrokerPassageProduct.Updated;
            }
        }
       
        /// <summary>
        /// Date of passage
        /// </summary>
        public DateTime Date
        {
            get
            {
                return m_SqlBrokerPassageProduct.Date;
            }
            set
            {
                m_SqlBrokerPassageProduct.Date = value;
            }
        }

        /// <summary>
        /// Formatted Date of passage (for display) :jj/mm/aaaa
        /// </summary>
        public string DateFormatted
        {
            get
            {
                return m_SqlBrokerPassageProduct.Date.ToShortDateString();
            }

        }

        /// <summary>
        /// Weight : quantity of products in kilograms
        /// </summary>
        public decimal Weight
        {
            get
            {
                return m_SqlBrokerPassageProduct.Weight;
            }
            set
            {
                m_SqlBrokerPassageProduct.Weight = value;
            }
        }

        /// <summary>
        /// Broker Company Coperate Name
        /// </summary>
        public string BrokerCompanyCoperateName
        {
            get
            {
                return this.ContractsBroker.BrokerCompanyCoperateName;
            }
        }

        /// <summary>
        /// ProductName : type of product : plastics ; aliminum ; glass... it's a enum display value
        /// </summary>
        public ProductName ProductName
        {
            get
            {
                return (ProductName)m_SqlBrokerPassageProduct.ProductName;

            }
            set
            {
                m_SqlBrokerPassageProduct.ProductName = (int)value;

            }
        }


        #region internal property
        /// <summary>
        /// property object to sql data linq
        /// </summary>
        internal LandfillServices.UI.Web.SQL.BrokerPassageProduct d_BrokerPassageProduct
        {
            get
            {
                return m_SqlBrokerPassageProduct;
            }

        }

        #endregion

        #region Constructors
        /// <summary>
        /// Constructor compound for the linq to sql selector 
        /// </summary>
        /// <param name="sqlBrokerPassageProduct"></param>
        internal BrokerPassageProduct(LandfillServices.UI.Web.SQL.BrokerPassageProduct sqlBrokerPassageProduct)
        {
            m_SqlBrokerPassageProduct = sqlBrokerPassageProduct;
        }

        /// <summary>
        /// simplified object constructor : to create a new object instance
        /// </summary>
        public BrokerPassageProduct()
        {
            m_SqlBrokerPassageProduct = new SQL.BrokerPassageProduct();
            m_SqlBrokerPassageProduct.Created = DateTime.Now;
            m_SqlBrokerPassageProduct.Updated = DateTime.Now;
        }

        #endregion

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LandfillServices.UI.Web.UI
{
    public partial class StatistiquesData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public List<ObjectsFunctions.LogisticTurnCollect> LogisticTurnCollectList
        {
            get
            {
                return ControllerFunctions.LogisticTurnCollectController.SearchAll();
            }
        }

        public List<ObjectsFunctions.LogisticPaymentCommission> LogisticPaymentCommissionList
        {
            get
            {
                return ControllerFunctions.LogisticPaymentCommissionController.SearchAll();
            }
        }
        public List< ObjectsFunctions.BrokerPassageProduct> BrokerPassageProductList
        {
            get
            {
                return ControllerFunctions.BrokerPassageProductController.SearchByDate(DateTime.Now);
            }
        }

        public List<ObjectsFunctions.BrokerPaymentCommission> BrokerPaymentCommissionList
        {
            get
            {
                return ControllerFunctions.BrokerPaymentCommissionController.SearchAll();
            }
        }

        public decimal TotalAmountBroker
        {
            get
            {
                decimal total = 0;
                if (BrokerPaymentCommissionList.Count > 0)
                {
                    foreach (var commission in BrokerPaymentCommissionList)
                    {
                        total += commission.Amount;
                    }
                }
                return total;
            }
        }
        public string FormattedTotalAmount
        {
            get
            {
                   return Utilities.DecimalUtilities.ToString(TotalAmountBroker);
            }
        }
        public string FormattedTotalAmountObjectveBroker
        {
            get
            {
                decimal budget = 200000;
               
                return Utilities.DecimalUtilities.ToString(TotalAmountBroker/ budget);
            }
        }
        public string FormattedDateNow
        {
            get
            {
                 return DateTime.Now.ToShortTimeString();
            }
        }
        public decimal TotalWeight
        {
            get
            {
                decimal totalWeight = 0;
                if (BrokerPassageProductList.Count > 0)
                {
                    foreach (var brokerproduct in BrokerPassageProductList)
                    {
                            totalWeight += brokerproduct.Weight;
                    }
                }
                return totalWeight;
            }
        }
        public string FormattedTotalWeightAliminum
        {
            get
            {
                decimal totalWeight = 0;
                if (BrokerPassageProductList.Count > 0)
                {
                    foreach(var brokerproduct in  BrokerPassageProductList) 
                    {
                        if (brokerproduct.ProductName == ObjectsFunctions.ProductName.Aluminum)
                            totalWeight += brokerproduct.Weight;
                    }
                }
                        return Utilities.DecimalUtilities.ToString( totalWeight);                
            }
        }
        public decimal TotalWeightAliminum
        {
            get
            {
                decimal totalWeight = 0;
                if (BrokerPassageProductList.Count > 0)
                {
                    foreach (var brokerproduct in BrokerPassageProductList)
                    {
                        if (brokerproduct.ProductName == ObjectsFunctions.ProductName.Aluminum)
                            totalWeight += brokerproduct.Weight;
                    }
                }
                return totalWeight;
            }
        }
        public string PercentAliminum
        {
            get
            {
                decimal totalWeight = 0;
                if (BrokerPassageProductList.Count > 0)
                {
                    foreach (var brokerproduct in BrokerPassageProductList)
                    {
                         totalWeight += brokerproduct.Weight;
                    }
                }
                return Utilities.DecimalUtilities.ToString( (TotalWeightAliminum/totalWeight)*100);

            }
        }


        public string FormattedTotalWeightMetal
        {
            get
            {
                decimal totalWeight = 0;
                if (BrokerPassageProductList.Count > 0)
                {
                    foreach (var brokerproduct in BrokerPassageProductList)
                    {
                        if (brokerproduct.ProductName == ObjectsFunctions.ProductName.Aluminum)
                            totalWeight += brokerproduct.Weight;
                    }
                }
                return Utilities.DecimalUtilities.ToString(totalWeight);
            }
        }
        public decimal TotalWeightMetal
        {
            get
            {
                decimal totalWeight = 0;
                if (BrokerPassageProductList.Count > 0)
                {
                    foreach (var brokerproduct in BrokerPassageProductList)
                    {
                        if (brokerproduct.ProductName == ObjectsFunctions.ProductName.Metal)
                            totalWeight += brokerproduct.Weight;
                    }
                }
                return totalWeight;
            }
        }
        public string PercentMetal
        {
            get
            {
                decimal totalWeight = 0;
                if (BrokerPassageProductList.Count > 0)
                {
                    foreach (var brokerproduct in BrokerPassageProductList)
                    {
                        totalWeight += brokerproduct.Weight;
                    }
                }
                return Utilities.DecimalUtilities.ToString((TotalWeightMetal / totalWeight) * 100);

            }
        }

        public string FormattedTotalWeightPaper
        {
            get
            {
                decimal totalWeight = 0;
                if (BrokerPassageProductList.Count > 0)
                {
                    foreach (var brokerproduct in BrokerPassageProductList)
                    {
                        if (brokerproduct.ProductName == ObjectsFunctions.ProductName.Aluminum)
                            totalWeight += brokerproduct.Weight;
                    }
                }
                return Utilities.DecimalUtilities.ToString(totalWeight);
            }
        }
        public decimal TotalWeightPaper
        {
            get
            {
                decimal totalWeight = 0;
                if (BrokerPassageProductList.Count > 0)
                {
                    foreach (var brokerproduct in BrokerPassageProductList)
                    {
                        if (brokerproduct.ProductName == ObjectsFunctions.ProductName.Paper)
                            totalWeight += brokerproduct.Weight;
                    }
                }
                return totalWeight;
            }
        }
        public string PercentPaper
        {
            get
            {
                decimal totalWeight = 0;
                if (BrokerPassageProductList.Count > 0)
                {
                    foreach (var brokerproduct in BrokerPassageProductList)
                    {
                        totalWeight += brokerproduct.Weight;
                    }
                }
                return Utilities.DecimalUtilities.ToString((TotalWeightPaper / totalWeight) * 100);

            }
        }

        public string FormattedTotalWeightGlass
        {
            get
            {
                decimal totalWeight = 0;
                if (BrokerPassageProductList.Count > 0)
                {
                    foreach (var brokerproduct in BrokerPassageProductList)
                    {
                        if (brokerproduct.ProductName == ObjectsFunctions.ProductName.Glass)
                            totalWeight += brokerproduct.Weight;
                    }
                }
                return Utilities.DecimalUtilities.ToString(totalWeight);
            }
        }
        public decimal TotalWeightGlass
        {
            get
            {
                decimal totalWeight = 0;
                if (BrokerPassageProductList.Count > 0)
                {
                    foreach (var brokerproduct in BrokerPassageProductList)
                    {
                        if (brokerproduct.ProductName == ObjectsFunctions.ProductName.Glass)
                            totalWeight += brokerproduct.Weight;
                    }
                }
                return totalWeight;
            }
        }
        public string PercentGlass
        {
            get
            {
                decimal totalWeight = 0;
                if (BrokerPassageProductList.Count > 0)
                {
                    foreach (var brokerproduct in BrokerPassageProductList)
                    {
                        totalWeight += brokerproduct.Weight;
                    }
                }
                return Utilities.DecimalUtilities.ToString((TotalWeightGlass / totalWeight) * 100);

            }
        }

        public string FormattedTotalWeightPlastics
        {
            get
            {
                decimal totalWeight = 0;
                if (BrokerPassageProductList.Count > 0)
                {
                    foreach (var brokerproduct in BrokerPassageProductList)
                    {
                        if (brokerproduct.ProductName == ObjectsFunctions.ProductName.Plastics)
                            totalWeight += brokerproduct.Weight;
                    }
                }
                return Utilities.DecimalUtilities.ToString(totalWeight);
            }
        }
        public decimal TotalWeightPlastics
        {
            get
            {
                decimal totalWeight = 0;
                if (BrokerPassageProductList.Count > 0)
                {
                    foreach (var brokerproduct in BrokerPassageProductList)
                    {
                        if (brokerproduct.ProductName == ObjectsFunctions.ProductName.Plastics)
                            totalWeight += brokerproduct.Weight;
                    }
                }
                return totalWeight;
            }
        }
        public string PercentPlastics
        {
            get
            {
                decimal totalWeight = 0;
                if (BrokerPassageProductList.Count > 0)
                {
                    foreach (var brokerproduct in BrokerPassageProductList)
                    {
                        totalWeight += brokerproduct.Weight;
                    }
                }
                return Utilities.DecimalUtilities.ToString((TotalWeightPlastics / totalWeight) * 100);

            }
        }

        public string FormattedTotalWeightElectronics
        {
            get
            {
                decimal totalWeight = 0;
                if (BrokerPassageProductList.Count > 0)
                {
                    foreach (var brokerproduct in BrokerPassageProductList)
                    {
                        if (brokerproduct.ProductName == ObjectsFunctions.ProductName.Electronics)
                            totalWeight += brokerproduct.Weight;
                    }
                }
                return Utilities.DecimalUtilities.ToString(totalWeight);
            }
        }
        public decimal TotalWeightElectronics
        {
            get
            {
                decimal totalWeight = 0;
                if (BrokerPassageProductList.Count > 0)
                {
                    foreach (var brokerproduct in BrokerPassageProductList)
                    {
                        if (brokerproduct.ProductName == ObjectsFunctions.ProductName.Electronics)
                            totalWeight += brokerproduct.Weight;
                    }
                }
                return totalWeight;
            }
        }
        public string PercentElectronics
        {
            get
            {
                decimal totalWeight = 0;
                if (BrokerPassageProductList.Count > 0)
                {
                    foreach (var brokerproduct in BrokerPassageProductList)
                    {
                        totalWeight += brokerproduct.Weight;
                    }
                }
                return Utilities.DecimalUtilities.ToString((TotalWeightElectronics / totalWeight) * 100);

            }
        }

        public decimal TotalAmountLogistic
        {
            get
            {
                decimal total = 0;
                if (LogisticPaymentCommissionList.Count > 0)
                {
                    foreach (var commission in LogisticPaymentCommissionList)
                    {
                        total += commission.Amount;
                    }
                }
                return total;
            }
        }
        public string FormattedTotalLogistic
        {
            get
            {
                return Utilities.DecimalUtilities.ToString(TotalAmountLogistic);
            }
        }
        public string FormattedTotalAmountObjectveLogistic
        {
            get
            {
                decimal budget = 200000;

                return Utilities.DecimalUtilities.ToString(TotalAmountLogistic / budget);
            }
        }
    }
}
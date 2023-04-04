using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stockExange
{
    internal abstract class FinancialIntermediary
    {
        public virtual Asset Buy(string type,int amount,FinancialIntermediary interme) 
        {

            if (type == "stock")
            {
                StockIntermediary intermediary = (StockIntermediary)interme;
                return interme.Buy(type,amount,interme); 
            }
            else
            {
                CryptoIntermediary intermediary = (CryptoIntermediary)interme;
                return interme.Buy(type,amount,interme);
            }
        }

       // public abstract Asset BUYaSSET(Asset asset);
    }
}

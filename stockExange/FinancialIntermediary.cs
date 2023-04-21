using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stockExange
{
    internal abstract class FinancialIntermediary
    {
        protected virtual Asset Buy(int amount,FinancialIntermediary type) 
        {

            if (type is StockMarket)
            {
                StockIntermediary intermediary = (StockIntermediary)type;
                return type.Buy(amount,type); 
            }
            else
            {
                CryptoIntermediary intermediary = (CryptoIntermediary)type;
                return type.Buy(amount,type);
            }
        }

       // public abstract Asset BUYaSSET(Asset asset);
    }
}

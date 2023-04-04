using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stockExange
{
    internal class CommercialBank:FinancialIntermediary
    {
        FinancialIntermediary FinancialIntermediary { get; set; }

        public CommercialBank()
        {
            FinancialIntermediary = new StockMarket();
        }

        public void BuyStock(string name ,int amount)
        {
            base.Buy(name,amount,FinancialIntermediary);
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stockExange
{
     class StockMarket : StockIntermediary
    {
        public StockMarket() : base ("")
        { 
            
        }

        protected override Asset Buy(int amount, FinancialIntermediary interme)
        {
            return new Stock(amount);
        }


        public class Stock:Asset
        {
            public Stock(int amount) 
            {
            
            } 
        }
    }
}

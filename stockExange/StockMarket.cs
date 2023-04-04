using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stockExange
{
    internal class StockMarket : StockIntermediary
    {
        public StockMarket() : base ("")
        { 
            
        }

        public override Asset Buy(string type, int amount, FinancialIntermediary interme)
        {
            return new Stock(type,amount);
        }


        public class Stock:Asset
        {
            public Stock(string name, int amount) 
            {
            
            } 
        }
    }
}

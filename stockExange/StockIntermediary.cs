using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stockExange
{
    internal class StockIntermediary : FinancialIntermediary
    {
        string _name;
        public StockIntermediary(string name)
        {
            _name = name.ToLower();
        }

        protected override Asset Buy(int amount, FinancialIntermediary interme)
        {
            StockIntermediary stockMarket = (StockIntermediary)interme;
            StockMarket stockMarkets = (StockMarket)stockMarket; 
            return stockMarkets.Buy(amount, stockMarket);
        }
    }
}

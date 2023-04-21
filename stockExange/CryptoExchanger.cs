using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static stockExange.StockMarket;

namespace stockExange
{
    internal class CryptoExchanger:CryptoIntermediary
    {
        public CryptoExchanger()
        {
            
        }
        protected override Asset Buy(int amount, FinancialIntermediary interme)
        {
            return new Crypto(amount);
        }
        public class Crypto : Asset
        {
            public Crypto( int amount):base()
            {
            }
        }
    }
}

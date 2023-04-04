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



        public override Asset Buy(string type, int amount, FinancialIntermediary interme)
        {
            return new Crypto(type, amount);
        }

        public class Crypto : Asset
        {
            public Crypto(string type , int amount):base()
            {

            }
        }
    }
}

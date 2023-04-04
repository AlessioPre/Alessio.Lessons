using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stockExange
{
    public class CryptoIntermediary : FinancialIntermediary
    {
        public CryptoIntermediary()
        {
        }

        public override Asset Buy(string type, int amount, FinancialIntermediary interme)
        {
            CryptoExchanger cryptoExchanger = (CryptoExchanger)interme;
            return (interme).Buy(type, amount, interme);
        }

       
    }
}

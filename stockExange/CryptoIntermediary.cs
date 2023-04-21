using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stockExange
{
    internal class CryptoIntermediary : FinancialIntermediary
    {
        public CryptoIntermediary()
        {
        }
        protected override Asset Buy(int amount, FinancialIntermediary interme)
        {
            CryptoExchanger cryptoExchanger = (CryptoExchanger)interme;
            return cryptoExchanger.Buy(amount, interme);
        }
    }
}

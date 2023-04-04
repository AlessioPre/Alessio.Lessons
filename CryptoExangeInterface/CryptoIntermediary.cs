using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoExangeInterface
{
    internal class CryptoIntermediary : FinancialIntermediary, Icrypto
    {
        public CryptoIntermediary()
        {
        }


        public override FinancialIntermediary Buy(IFinancial type)
        {
            return base.Buy(type);
        }
    }
}

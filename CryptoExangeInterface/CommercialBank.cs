using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoExangeInterface
{
    internal class CommercialBank : FinancialIntermediary
    {
        public CommercialBank()
        {
        }


        public override FinancialIntermediary Buy(IFinancial type)
        {
            return base.Buy(type);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace CryptoExangeInterface
{
    internal abstract class FinancialIntermediary : IFinancial
    {
        protected virtual FinancialIntermediary Buy(IFinancial type)
        {
            if (type is IStock)
            {
                return ((FinancialIntermediary) type).Buy(type);
            }
            else if(type is Icrypto)
            {
                return ((FinancialIntermediary)type).Buy(type);
            }
            else 
            {
                return null; 
            }
        }


        FinancialIntermediary IFinancial.Buy(CryptoExangeInterface.IFinancial type) 
        {
            

            return this.Buy(type);
        }

       
    }
}

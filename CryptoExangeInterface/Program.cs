using System;

namespace CryptoExangeInterface
{
    internal class Program
    {
        static void Main(string[] args)
        {
           CommercialBank commercialBank = new CommercialBank();
           IFinancial cryptoIntermediary = new CryptoIntermediary();
          
           commercialBank.Buy(cryptoIntermediary); 
           
        }
    }
}

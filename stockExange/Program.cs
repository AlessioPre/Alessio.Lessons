using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace stockExange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CommercialBank  commercialBank = new CommercialBank();
            StockMarket stockMarket = new StockMarket();
            commercialBank.BuyStock(stockMarket, 12);
            //commercialBank.Buy("crypto",3,intermediary);
        
        }     
    }
}

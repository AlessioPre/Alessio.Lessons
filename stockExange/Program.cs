using System;
using System.Runtime.InteropServices;

namespace stockExange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CommercialBank  commercialBank = new CommercialBank();
            StockMarket intermediary = new StockMarket();
            commercialBank.Buy("stock", 12,intermediary);
            //commercialBank.Buy("crypto",3,intermediary);
        }     
    }
}

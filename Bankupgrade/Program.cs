using System;
using System.Runtime.InteropServices;
using System.Xml.Linq;



namespace Bankupgrade
{
    internal class Program
    {

        static void Main(string[] args)
        {
            CentralBank RussianCentralBank = new CentralBank("Russia Central Bank", "Russia", 5);
            CentralBank BancaDitalia = new SwiftCentralBank("Banca D'Italia", "Italia", 3);


            CommertialBank SberBank = new CommertialBank("SberBank", "Russia", RussianCentralBank);
            CommertialBank VTBbank = new  CommertialBank("VTB Bank","Russia",RussianCentralBank);
            CommertialBank Unicredit = new CommertialBank("Unicredit", "Italy", BancaDitalia);
            CommertialBank Mediolanum = new CommertialBank("Mediolanum", "Italy", BancaDitalia);

            //Aggiungo Banche alla banca centrale 
            RussianCentralBank.AddCommercialBank(SberBank);
            RussianCentralBank.AddCommercialBank(VTBbank);
            // Aggiungo Banche Alla Banca centrale con SWIft
            BancaDitalia.AddCommercialBank(Mediolanum);
            BancaDitalia.AddCommercialBank(Unicredit);

            // Crea un conto Corrente e deposita dentro un dei soldi 
            SberBank.CreateAccount("Vladimir Putin", "NO DATA");
            SberBank.DepositFiat(100000, SberBank.Accounts[0].AccountNumber,"Euro"); ;
            SberBank.DepositCrypto(4,"BTC", SberBank.Accounts[0].AccountNumber) ;
            SberBank.InvestInStock(1,"MICROSOFT", SberBank.Accounts[0].AccountNumber);
            // Creo un secondo ContoCorrente
            VTBbank.CreateAccount("Gorbachof", "NO DATA");
            //VTBbank.DepositFiat(100M, SberBank.Accounts[0]);
            //VTBbank.DepositCrypto(1, SberBank.Accounts[0]);
            //VTBbank.InvestInStock(1, SberBank.Accounts[0]);
            // Crea un conto Corrente con saldo zero
            Unicredit.CreateAccount("Bruno Ferreira", "FRBBRIIM394NFNNF");
            // Creo un secondo conto Corrente con saldo zero 
            Mediolanum.CreateAccount("Alessio Presciuttini", "PRSLSS92L10F499Q");
          
            // Stampa Saldo iniziale dei due conti  
            Console.WriteLine("-------------------------------------- SALDO INIZIALE -------------------");

          //  Console.WriteLine($" L'account di Vladimir Putin ha un credito di :  {SberBank.account.Balance}");
          //  Console.WriteLine($" L'account di Bruno Ferreira ha un credito di :  {Unicredit.account.Balance}");
            Console.WriteLine("-------------------------------------------------------------------------------");
            ;

            bool result = SberBank.Transfer(Unicredit, new FIATDespositRequest() { _amount = 1000M, _accountfrom = 5548485187, _accountTo = 1112355477 });

            if (!result)
            {
                Console.WriteLine("Amount not Transfered! ");
                return;// Fine Programma! 
            }


            // Stampa Saldo Fianale dei due conti  
            Console.WriteLine("-------------------------------------- SALDO FINALE -------------------");

          // Console.WriteLine($" L'account di Vladimir Putin ha un credito di :  {SberBank.account.Balance}");
          //  Console.WriteLine($" L'account di Bruno Ferreira ha un credito di :  {Unicredit.account.Balance}");
            Console.WriteLine("-------------------------------------------------------------------------------");


            Console.ResetColor();

            // Show After before Transfer  

            Console.ReadLine();


        }
    }

}


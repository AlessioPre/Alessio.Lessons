using System;
using System.Reflection;
using System.Xml.Linq;
using System.Linq;
using static Bankupgrade.CommertialBank.Account;


namespace Bankupgrade

{
    class CommertialBank : Bank
    {
        int _counter;
        private CentralBank _centralBank;
        Account _account;
        Account[] _accounts;

        public Account account { get => _account; }
        public CentralBank CentralBank { get => _centralBank; }
        public Account[] Accounts { get => _accounts;  }
        public  int Counter { get => _counter; }

        public CommertialBank(string Name, string Country, CentralBank Bank) : base(Name, Country)
        {
            _centralBank = Bank;
            _country = Country;
            _name = Name;
            _code = new Random().Next(10000, 1000000);
            _accounts = new Account[0];
            _counter = 0;
        }

        /// <summary>
        /// Creo e Rimuovo un Account
        /// </summary>
        /// <param name="ClientName"></param>
        /// <param name="ClientCF"></param>
        public void CreateAccount(string ClientName, string ClientCF)
        {
            if (Array.Find(_accounts,i => i._client.Cf == ClientCF)==null)
            //{ 
            _account = new Account(ClientName, ClientCF, this);
            //  In un contesto reale avrò un array di Account.
            AddAccountsToArray(_account);
           //}
        }
        public void RemoveAccount(long ClientName)
        {
            if (Array.Exists(_accounts, i => i.AccountNumber== ClientName))
            {
             var result = _accounts.Where( i => i.AccountNumber != ClientName).ToArray();
            _accounts = result;
            }
            //var result = Array.Find(_accounts, i => i.Equals(ClientName));
            //this.RemoveAccountToArray(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="to"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        /// 
        public override bool Transfer(Bank to,Account AcTo, FIATDespositRequest data)
        {
            // CommertialBank transferFrom = (CommertialBank) from;
            CommertialBank transferTo = (CommertialBank)to;
            if (this._centralBank.CheckTransfer(this, transferTo,data._accountfrom,data._accountTo, data))
            {
                /*  
                   Prima di procedere con il versamento, verificare che l'ammontare da accreditare è stato effettivamente scalato dal conto del versatore
                   Quindi  avere una copia dello stato del conto prima di scalere i soldi per  poter confrontare che il prelievo è andato a buon fine.

                 */
                var account = Array.Find(Accounts, i => i.AccountNumber == data._accountfrom);
                // stato conto prima
                if (account != null)
                {
                    int index = Array.IndexOf(Accounts, account);
                    this.Accounts[index].WithdrawFIAT(data._amount,"Euro");
                }
                // confronto le due cifr dopo il prelievo. 
                Utility.GetAccountInfo(ConsoleColor.Red, this, false, data);

                //transferTo.account.DepositFIAT(data._amount);
                Utility.GetAccountInfo(ConsoleColor.Green, transferTo, true, data);


                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine($"The  amount {data._amount} from the account {data._accountfrom} from the Bank {this.Name} to " +
                    $"account {data._accountTo} of from the Bank {to.Name} has been made! ");
                Console.ResetColor();

                return true;
            }
            return false;

        }
        /// <summary>
        /// Deposito Asset
        /// </summary>
        /// <param name="Amount"></param>
        /// <param name="accountID"></param>
        /// <param name="kindOfValue"></param>
        public void DepositFiat(long Amount, long accountID, string kindOfValue)
        {
            var result = Array.Find(Accounts,i => i.AccountNumber == accountID);
            // Check Client // è biondo!
            if (result!= null)
            {
            var index = Array.IndexOf(this._accounts, result);
            _accounts[index].DepositFIAT(Amount, kindOfValue);
            }
        }
        public void DepositCrypto(decimal Amount,string kindOfValue, long accountID)
        {
            var result = Array.Find(Accounts, i => i.AccountNumber == accountID);
            // Check Client // è biondo!
            if (result != null)
            {
                var index = Array.IndexOf(this._accounts, result);
                _accounts[index].DepositCrypto(Amount, kindOfValue);
            }
        }
        public void InvestInStock(decimal Amount, string kindOfValue, long accountID)
        {
            var result = Array.Find(Accounts, i => i.AccountNumber == accountID);
            // Check Client // è biondo!
            if (result != null)
            {
                var index = Array.IndexOf(this._accounts, result);
                _accounts[index].DepositCrypto(Amount, kindOfValue);
            }
        }
        public void WithdrawFIAT(decimal Amount, string kindOfValue, long accountID)
        {
            var result = Array.Find(Accounts, i => i.AccountNumber == accountID);
            // Check Client // è biondo!
            if (result != null)
            {
                var index = Array.IndexOf(this._accounts, result);
                _accounts[index].WithdrawFIAT(Amount,kindOfValue);
            }
        }
        public void WithdrawCrypto(decimal Amount, string kindOfValue, long accountID)
        {
            var result = Array.Find(Accounts, i => i.AccountNumber == accountID);
            // Check Client // è biondo!
            if (result != null)
            {
                var index = Array.IndexOf(this._accounts, result);
                _accounts[index].WithdrawCrypto(Amount, kindOfValue);
            }
        }
        public void SellStoks(decimal Amount, string kindOfValue, long accountID)
        {
            var result = Array.Find(Accounts, i => i.AccountNumber == accountID);
            // Check Client // è biondo!
            if (result != null)
            {
                var index = Array.IndexOf(this._accounts, result);
                _accounts[index].SellStoks(Amount, kindOfValue);
            }
        }

        /// <summary>
        /// Gestione Array Account
        /// </summary>
        ///
        public void AddAccountsToArray(Account account)
        {


                Account[] items = new Account[_counter + 1];
                Array.Copy(_accounts, items, _accounts.Length);
                _accounts = items;
                _accounts[_counter] = account;
                account.AddAccounts(account._client.ClientId);
                _counter++;
            
              
        }

        //public void RemoveAccountToArray(Account account)
        //{
        //    var index = Array.IndexOf(Accounts, account);
        //    _accounts[index] = null;
        //    Array.Resize(ref _accounts, Counter-1);
        //    _counter--;
        //}

        public void FindAccount(Account account)
        {
            var result = Array.Find(Accounts, i => i.Equals(account.AccountNumber));
            if (result != null)
            {

            Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Account non trovato");
            }
        }
        public class Account
        {
            CommertialBank _commertialBank;
            public Client _client;        
            public long AccountNumber { get; }
            Fiat _fiat;
            Crypto _crypto;
            Stock _stocks;

            Asset[]  _GeneralPorfolio;   
            decimal  _interests;
            decimal _balance;


            //public decimal Amount { get { return _fiat.AmountInEuro + _crypto.AmountInEuro + _stocks.AmountInEuro; } }
            //public decimal Balance { get { return CalcAmount() + calcInterests(); } }

            internal Asset[] GeneralPorfolio { get => _GeneralPorfolio; }
            internal CommertialBank CommertialBank { get => _commertialBank; set => _commertialBank = value; }

            public Account(string ClientName, string ClientCF, CommertialBank commertialBank)
            {
                CommertialBank = commertialBank;
                _client = new Client(ClientName, ClientCF, this);
                AccountNumber = new Random().Next(10000, 1000000);
                _GeneralPorfolio = new Asset[0]; 
            }

            public void AddAccounts(long clientId)
            {
                if (clientId == _client.ClientId)
                {
                    _client.AddAccounts(this);
                }
            }

            //decimal calcInterests()
            //{
            //    //return _interests = (CalcAmount() / 100) * _commertialBank.CentralBank._interestRate;
            //}
            //decimal CalcAmount()
            //{
            //    //return _fiat.AmountInEuro + _crypto.AmountInEuro + _stocks.AmountInEuro;
            //}
            public void DepositFIAT(decimal Amount,string kindof)
            {
                _fiat = new Fiat(kindof, Amount);
                var asset = Array.Find(_GeneralPorfolio,A => A.Name  == kindof);
                if (asset!=null)
                {
                    _GeneralPorfolio[_GeneralPorfolio.Length]= _fiat;
                }
            }
            public void DepositCrypto(decimal Amount,string kindof)
            {
                _crypto = new Crypto(kindof, Amount);
                var asset = Array.Find(_GeneralPorfolio, A => A.Name == kindof);
                if (asset != null)
                {
                    _GeneralPorfolio[_GeneralPorfolio.Length] = _crypto;
                }
            }
            public void InvestInStoks(decimal Amount, string kindof)
            {
                _stocks = new Stock(kindof, Amount);
                var asset = Array.Find(_GeneralPorfolio, A => A.Name == kindof);
                if (asset == null)
                {
                    _GeneralPorfolio[_GeneralPorfolio.Length] = _stocks;
                }
            }
            public void WithdrawFIAT(decimal Amount , string kindOf)
            {
                var asset = Array.Find(_GeneralPorfolio, A => A.Name == kindOf);
                if (asset != null)
                {
                    int index = Array.IndexOf(_GeneralPorfolio,asset);
                    _GeneralPorfolio[index].Amount -= Amount;
                }
            }
            public void WithdrawCrypto(decimal Amount , string kindOf)
            {
                var asset = Array.Find(_GeneralPorfolio, A => A.Name == kindOf);
                if (asset != null)
                {
                    int index = Array.IndexOf(_GeneralPorfolio, asset);
                    _GeneralPorfolio[index].Amount -= Amount;
                }
            }
            public void SellStoks(decimal Amount, string kindOf)
            {
                var asset = Array.Find(_GeneralPorfolio, A => A.Name == kindOf);
                if (asset != null)
                {
                    int index = Array.IndexOf(_GeneralPorfolio, asset);
                    _GeneralPorfolio[index].Amount -= Amount;
                }
            }
            /// <summary>
            /// Metodi per aggiungere e togliere asset dal porfolio
            /// </summary>
            /// 
         
            public class Client
            {
                string _name;
                string _cf;
                Account _account;
                long _clientId;
                Account[] _accounts;
                int _counter;
                public Client(string ClientName, string ClientCF, Account account)
                {
                    Cf = ClientCF;
                    Name = ClientName;
                    _account = account;
                    _clientId = new Random().Next(10000, 100000);
                    Accounts = new Account[0];
                    //AddAccounts(account);

                }

                public string Name { get => _name; set => _name = value; }
                public long ClientId { get => _clientId; }
                public string Cf { get => _cf; set => _cf = value; }
                public Account[] Accounts { get => _accounts; set => _accounts = value; }

                public void AddAccounts( Account account)
                {
                    if (!Array.Exists(Accounts,i=> i.AccountNumber == account.AccountNumber))
                        {
                        Account[] items = new Account[_counter + 1];
                        Array.Copy(Accounts, items, Accounts.Length);
                        Accounts = items;
                        Accounts[_counter] = new Account(this.Name,this.Cf,_account.CommertialBank);
                        _counter++;
                    }
                }
                public void RemoveAccounts()
                {
                    if (!Array.Exists(Accounts, i => i.AccountNumber == _account.AccountNumber))
                    {
                        Accounts[Accounts.Length] = _account;
                    }
                }
            }
            public abstract class Asset
            {
                Account _account;
                string _name;
                decimal _price;
                //public abstract decimal AmountInEuro { get; }
                public string Name { get => _name; set => _name = value; }
                public decimal Amount { get; internal set; }

                public Asset(string name,decimal value)
                {
                    
                    _name = name;
                    _price= value;

                }

                
            }
            public class Fiat : Asset
            {
 
                public static decimal _euroPrice = 1;
                decimal _gbpPrice = 0.89M;
               //public override decimal AmountInEuro { get => EuroAmount + (GbpAmount * _gbpPrice); } // Converti in EURO. Per esempio, se ho altre FIAT come Dollari, Yen , Sterline 
                // public decimal FiatAmount { get => _fiatAmount; set => _fiatAmount = value; }
                public Fiat(string name,decimal Amount) : base(name,Amount)
                {
                }
               

            }
            public class Crypto : Asset
            {
                decimal _cryptoAmount;
                decimal _cryptoPrice = 28000;
                


                //public override decimal AmountInEuro { get => _cryptoAmount * _cryptoPrice; }
                public decimal CryptoAmount { get => _cryptoAmount; set => _cryptoAmount = value; }

                public Crypto(string name, decimal Amount) : base(name, Amount)
                {

                }
            }
            public class Stock : Asset
            {
                decimal _stockAmount;
                decimal _stockPrice = 500;
               // public override decimal AmountInEuro { get => _stockAmount * _stockPrice; }
                public decimal StockAmount { get => _stockAmount; set => _stockAmount = value; }
                public Stock(string name, decimal Amount) : base(name, Amount)
                {

                }
            }
        }
    }



}


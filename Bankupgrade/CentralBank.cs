using System;
using System.Diagnostics;
using System.Linq;
using static Bankupgrade.CommertialBank;

namespace Bankupgrade

{
    class CentralBank : Bank
    {
        public int _interestRate;
        CommertialBank [] _commercialBank;
        int count;
        

        public void AddCommercialBank(CommertialBank bank )
        {
            CommertialBank[] commercialBank = new CommertialBank[count+1];
            Array.Copy(_commercialBank, commercialBank, count);
            _commercialBank= commercialBank;
            _commercialBank[count] = bank;
            count++;
        }
        public void RemoveAccount(string Name)
        {
            var result = _commercialBank.Where(i => i.Name != Name).ToArray();

            _commercialBank = result;
        }
        public bool CheckTransfer(Bank from, Bank to, long Acfrom, long Acto, FIATDespositRequest data)
        {
            if (from.Country == to.Country)
            {
                return from.Transfer(to, data);
            }
            else
            {
                if (WordBank.Transfer((CommertialBank)from, (CommertialBank)to, data))
                {
                    return true;
                }
                return false;
            }
        }
        //public bool CheckTransferToAccount(Bank from, Bank to,int AccounttFrom, int AccounttTo, FIATDespositRequest data)
        //{
        //    if (from.Country == to.Country)
        //    {
        //        return from.Transfer(to, data);
        //    }
        //    else
        //    {
        //        if (WordBank.Transfer((CommertialBank)from, (CommertialBank)to, data))
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //}
        const decimal _maxInterestTax = 5;
        public CentralBank(string name, string Country, int MaxInterestRate) : base(name, Country)
        {
            _commercialBank = new CommertialBank[0];
            count= 0;
        }
    }

}


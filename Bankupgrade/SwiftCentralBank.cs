
namespace Bankupgrade

{
    class SwiftCentralBank : CentralBank, ISwiftSystem
    {
        public SwiftCentralBank(string name, string Country, int MaxInterestRate) : base(name, Country, MaxInterestRate)
        {

        }
    }

}


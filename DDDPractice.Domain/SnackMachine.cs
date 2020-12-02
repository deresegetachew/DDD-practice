using System;

namespace DDDPractice.Domain
{
    public sealed class SnackMachine
    {
        public Money MoneyBalance { get; private set; }
        public Money MoneyInTransaction { get; private set; }



        public void InsertMoney(Money money)
        {
            MoneyInTransaction += money;
        }

        public void ReturnMoney()
        {
            
        }

        public void BuySnack()
        {
            MoneyBalance += MoneyInTransaction;
        }
    }
}
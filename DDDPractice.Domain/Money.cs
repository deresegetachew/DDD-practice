using System;

namespace DDDPractice.Domain
{
    public class Money : ValueObject<Money>
    {
        
        public int TenCentBalance { get; private set; }
        public int QuarterCentBalance { get; private set; }
        public int FiftyCentBalance { get; private set; }
        public int OneBirrBalance { get;  private set; }
        public int FiveBirrBalance { get; private set; }
        public int TenBirrBalance { get; private set; }

        public Money(int tenCentCount, 
                int quarterCentCount, int fiftyCentCount, 
                int oneBirrCount, int fiveBirrCount, int tenBirrCount)
        {
            
            if(tenCentCount < 0)
                throw new InvalidOperationException();
            if(quarterCentCount < 0)
                    throw new InvalidOperationException();
            if(fiftyCentCount < 0)
                    throw  new InvalidOperationException();
            if(oneBirrCount < 0)
                    throw new InvalidOperationException();
            if(fiveBirrCount < 0)
                throw  new InvalidOperationException();
            if(tenBirrCount < 0)
                throw new InvalidOperationException();
            
            
            TenCentBalance = tenCentCount;
            QuarterCentBalance = quarterCentCount;
            FiftyCentBalance = fiftyCentCount;
            OneBirrBalance = oneBirrCount;
            FiveBirrBalance = fiveBirrCount;
            TenBirrBalance = tenBirrCount;
        }


        public static Money operator +(Money m1, Money m2)
        {
            Money sum = new Money(
                    m1.TenCentBalance + m2.TenCentBalance,
                    m1.QuarterCentBalance + m2.QuarterCentBalance,
                    m1.FiftyCentBalance + m2.FiftyCentBalance,
                    m1.OneBirrBalance + m2.OneBirrBalance,
                    m1.FiveBirrBalance + m2.FiveBirrBalance,
                    m1.TenBirrBalance + m2.TenBirrBalance
                );
            return sum;
        }

        protected override bool EqualsCore(Money other)
        {
            return TenCentBalance == other.TenCentBalance
                   && QuarterCentBalance == other.QuarterCentBalance
                   && FiftyCentBalance == other.FiftyCentBalance
                   && OneBirrBalance == other.OneBirrBalance
                   && FiveBirrBalance == other.FiveBirrBalance
                   && TenBirrBalance == other.TenBirrBalance;

        }

        protected override int GetHashCodeCore()
        {
            int hashCode = TenCentBalance;
            hashCode = (hashCode * 397) ^ QuarterCentBalance;
            hashCode = (hashCode * 397) ^ FiftyCentBalance;
            hashCode = (hashCode * 397) ^ OneBirrBalance;
            hashCode = (hashCode * 397) ^ FiveBirrBalance;
            hashCode = (hashCode * 397) ^ TenBirrBalance;

            return hashCode;
        }
    }
}
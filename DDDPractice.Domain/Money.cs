namespace DDDPractice.Domain
{
    public class Money
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
                    m1.FiftyCentBalance + m2.QuarterCentBalance,
                    m1.FiftyCentBalance + m2.FiftyCentBalance,
                    m1.OneBirrBalance + m2.OneBirrBalance,
                    m1.TenBirrBalance + m2.TenBirrBalance
                );
            return sum;
        }
    }
}
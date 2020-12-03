using System;
using DDDPractice.Domain;
using FluentAssertions;
using FluentAssertions.Common;
using Xunit;

namespace DDDPractice.Tests
{
    public class MoneySpecs
    {
        [Fact]
        public void sum_of_two_money_objects_produces_correct_result()
        {
            Money money1 = new Money(1,2,3,4,5,6);
            Money money2 = new Money(1,2,3,4,5,6);

            Money sum = money1 + money2;

            sum.TenCentBalance.Should().Be(2);
            sum.QuarterCentBalance.Should().Be(4);
            sum.FiftyCentBalance.Should().Be(6);
            sum.OneBirrBalance.Should().Be(8);
            sum.FiveBirrBalance.Should().Be(10);
            sum.TenBirrBalance.Should().Be(12);
        }
        
        [Fact]
        public  void two_money_instances_are_equal_if_contain_same_money_amount()
        {
            Money m1 = new Money(1,2,3,4,5,6);
            Money m2 = new Money(1,2,3,4,5,6);

            m1.Should().Be(m2);
            m1.GetHashCode().Should().Be(m2.GetHashCode());
        }


        [Fact]
        public void two_money_instances_do_not_equal_if_contain_different_money_amount()
        {
            Money m1 = new Money(0,0,0,0,0,1);
            Money m2 = new Money(100,0,0,0,0,0);

            m1.Should().NotBe(m2);
            m1.GetHashCode().Should().NotBe(m2.GetHashCode());
        }

        [Theory]
        [InlineData(-1,0,0,0,0,0)]
        [InlineData(0,-2,0,0,0,0)]
        [InlineData(0,0,-3,0,0,0)]
        [InlineData(0,0,0,-4,0,0)]
        [InlineData(0,0,0,0,-5,0)]
        [InlineData(0,0,0,0,0,-6)]
        public void can_not_Create_money_with_negative_value(
            int tenCentBalance,
            int quarterCentBalance,
            int fifityCentBalance,
            int oneBirrBalance,
            int fiveBirrBalance,
            int tenBirrBalance)
        {
            Action action = () => new Money(
                tenCentBalance,
                quarterCentBalance,
                fifityCentBalance,
                oneBirrBalance,
                fiveBirrBalance,
                tenBirrBalance
                );

            action.Should().Throw<InvalidOperationException>();
        }
        
        
        [Theory]
        [InlineData(0,0,0,0,0,0,0)]
        [InlineData(1,0,0,0,0,0,0.1)]
        [InlineData(1,2,0,0,0,0,0.6)]
        [InlineData(1,2,3,0,0,0,2.1)]
        [InlineData(1,2,3,4,0,0,6.1)]
        [InlineData(1,2,3,4,5,0,31.1)]
        [InlineData(1,2,3,4,5,6,91.1)]
        public void amount_is_calculated_correctly(
            int tenCentBalance,
            int quarterCentBalance,
            int fifityCentBalance,
            int oneBirrBalance,
            int fiveBirrBalance,
            int tenBirrBalance,
            double expectedAmount)
        {
            Money money = new Money(
                tenCentBalance,
                quarterCentBalance,
                fifityCentBalance,
                oneBirrBalance,
                fiveBirrBalance,
                tenBirrBalance);

            
            decimal d =  Convert.ToDecimal(expectedAmount);
            
            money.Amount.Should().Be(d);
        }

        [Fact]
        public void Subtraction_of_two_money_objects_produces_correct_result()
        {
            Money m1 = new Money(10,10,10,10,10,10);
            Money m2 = new Money(1, 2, 3, 4, 5, 6);

            Money result = m1 - m2;

            result.TenCentBalance.Should().Be(9);
            result.QuarterCentBalance.Should().Be(8);
            result.FiftyCentBalance.Should().Be(7);
            result.OneBirrBalance.Should().Be(6);
            result.FiveBirrBalance.Should().Be(5);
            result.TenBirrBalance.Should().Be(4); 
        }

        [Fact]
        public void Cannot_subtract_more_than_balance()
        {
            Money m1 = new Money(0,1,0,0,0,0);
            Money m2 = new Money(1,0,0,0,0,0);

            Action action = () =>
            {
                Money money = m1 - m2;
            };

            action.Should().Throw<InvalidOperationException>();
        }
        
    }
}
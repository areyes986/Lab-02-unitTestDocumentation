using System;
using Xunit;
using UnitTestingAndDoc;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void CanWithdraw()
        {
            Program.Balance = 8000m;
            decimal takeOut = Program.Withdrawl(200m);
            Assert.Equal(7800m, takeOut);
        }

        [Fact]
        public void CantWithdrawMoreThanBalance()
        {
            Program.Balance = 8000m;
            decimal takeOut = Program.Withdrawl(9000m);
            Assert.Equal(8000m, takeOut);
        }

        [Fact]
        public void CantWithdrawNegativeNumber()
        {
            Program.Balance = 8000m;
            decimal neg = Program.Withdrawl(-900m);
            Assert.Equal(8000m, neg);
        }

        [Fact]
        public void CanDeposit()
        {
            Program.Balance = 8000m;
            decimal input = Program.Deposit(500m);
            Assert.Equal(8500m, input);
        }
        [Fact]
        public void CantDepositNegativeNumber()
        {
            Program.Balance = 8000m;
            decimal neg = Program.Deposit(-50);
            Assert.Equal(8000m, neg);
        }

    }
}

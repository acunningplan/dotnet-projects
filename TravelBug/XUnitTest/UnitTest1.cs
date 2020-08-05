using System;
using Xunit;
using Application.User;
using Persistence;

namespace XUnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.False(5 * 2 < 3);
        }

        [Fact]
        public void Test2()
        {
            Assert.Throws<IndexOutOfRangeException>(
                () =>
                {
                    int[] array1 = new int[] { 1, 2, 3, 4 };
                    array1[5] = 3;
                }
            );
        }

    }

}

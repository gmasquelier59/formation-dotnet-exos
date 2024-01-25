using Exercice02_Fib;
using System.Linq;

namespace Exercice02_Fib.Tests
{
    public class FibTest
    {
        [Fact]
        public void GetFibSeries_Range_1_HasValues()
        {
            Fib fib = new Fib(1);

            List<int> result = fib.GetFibSeries();

            Assert.NotEqual(0, result.Count);
        }

        [Fact]
        public void GetFibSeries_Range_1_ContainsValue_0()
        {
            Fib fib = new Fib(1);

            List<int> result = fib.GetFibSeries();

            Assert.Contains(0, result);
        }

        [Fact]
        public void GetFibSeries_Range_6_ContainsValue_3()
        {
            Fib fib = new Fib(6);

            List<int> result = fib.GetFibSeries();

            Assert.Contains(3, result);
        }

        [Fact]
        public void GetFibSeries_Range_6_Has_6_Values()
        {
            Fib fib = new Fib(6);

            List<int> result = fib.GetFibSeries();

            Assert.Equal(6, result.Count);
        }

        [Fact]
        public void GetFibSeries_Range_6_NotContainsValue_4()
        {
            Fib fib = new Fib(6);

            List<int> result = fib.GetFibSeries();

            Assert.DoesNotContain(4, result);
        }

        [Fact]
        public void GetFibSeries_Range_6_CollectionIsValid()
        {
            Fib fib = new Fib(6);

            List<int> result = fib.GetFibSeries();

            Assert.Equal(new List<int>() { 0, 1, 1, 2, 3, 5 }, result);
        }

        [Fact]
        public void GetFibSeries_Range_6_CollectionIsSortedAsc()
        {
            Fib fib = new Fib(6);

            List<int> result = fib.GetFibSeries();

            List<int> expected = result.OrderBy(x => x).ToList<int>();

            Assert.True(expected.SequenceEqual(result));
        }
    }
}
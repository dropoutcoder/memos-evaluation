using NUnit.Framework.Legacy;

namespace DropoutCoder.SmartGuideTdd.SumWithoutHighestAndLowest.Tests
{
    [TestFixture]
    public class ArraySummarizerTests
    {
        [Test]
        public void Array_Is_Null_Throws_ArgumentNullException()
        {
            var summarizer = new ArraySummarizer();

            var action = () => summarizer.Sum(null!);

            Assert.Throws<ArgumentNullException>(() => action());
        }

        [Test]
        public void Array_Sum_Overflows_Throws_OverflowException()
        {
            var summarizer = new ArraySummarizer();

            var action = () => summarizer.Sum(new int[] { int.MaxValue, int.MaxValue - 1, int.MaxValue - 2, int.MaxValue - 3, int.MaxValue - 4 });

            Assert.Throws<OverflowException>(() => action());
        }

        [TestCase(new int[] { -10, 0, -10, 10, 9, 10 }, 9)]
        [TestCase(new int[] { -23, 5, 5, -1, 11, 9, 10 }, 28)]
        [TestCase(new int[] { 121, -9, 122, 81, 15 }, 217)]
        [TestCase(new int[] { 0, 1, -1, -10, 10 }, 0)]
        public void Array_Is_Null_Throws_ArgumentNullException(int[] value, int expected)
        {
            var summarizer = new ArraySummarizer();

            var actual = summarizer.Sum(value);

            ClassicAssert.That(actual, Is.EqualTo(expected));
        }
    }
}
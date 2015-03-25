using GameInventory.Api.Models;
using NUnit.Framework;

namespace GameInventory.Api.Tests
{
    [TestFixture]
    public class RandomNumberGeneratorTests
    {
        [Test]
        public void CanInstantiateNewRandomNumberGenerator()
        {
            Assert.DoesNotThrow(() => new RandomNumberGenerator());
        }

        [Test]
        public void GetRandomNumberGeneratesPositiveNumberLessThanMaxValue()
        {
            var randomNumberGenerator = new RandomNumberGenerator();

            for (var i = 0; i < 1000; i++)
            {
                var result = randomNumberGenerator.GetRandomNumber(10);
                Assert.That(result, Is.InRange(0, 9));
            }
           
        }
    }
}

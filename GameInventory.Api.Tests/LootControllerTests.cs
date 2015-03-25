using GameInventory.Api.Controllers;
using GameInventory.Api.Domain;
using GameInventory.Api.Models;
using NUnit.Framework;

namespace GameInventory.Api.Tests
{
    [TestFixture]
    public class LootControllerTests
    {
        [Test]
        public void CanInstantiateNewLootController()
        {
            Assert.DoesNotThrow(() => new LootController(new RandomNumberGenerator()));
        }

        [Test]
        public void GetMethodReturnsLootItem()
        {
            var lootController = new LootController(new RandomNumberGenerator());
            
            var result = lootController.Get();

            Assert.That(result, Is.InstanceOf<LootItem>());
            Assert.That(result, Is.Not.Null);
        }
    }
}

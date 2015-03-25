using GameInventory.Api.Domain;
using NUnit.Framework;

namespace GameInventory.Api.Tests.GameInventory.Api.Domain.Tests
{
    [TestFixture]
    public class LootItemTests
    {
        [Test]
        public void CanInstantiateNewLootItem()
        {
            Assert.DoesNotThrow(() => new LootItem("test", 1));
        }

        [Test]
        public void CanSetItemAndDropChanceThroughConstructor()
        {
            var lootItem = new LootItem("Test Item", 1);

            Assert.That(lootItem.Item, Is.EqualTo("Test Item"));
            Assert.That(lootItem.DropChance, Is.EqualTo(1));
        }

    }
}

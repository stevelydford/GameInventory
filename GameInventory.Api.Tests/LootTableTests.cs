using System.Collections.Generic;
using GameInventory.Api.Domain;
using GameInventory.Api.Models;
using GameInventory.Api.Models.Interfaces;
using Moq;
using NUnit.Framework;

namespace GameInventory.Api.Tests
{
    [TestFixture]
    public class LootTableTests
    {
        [Test]
        public void CanInstantiateNewLootTable()
        {
            Assert.DoesNotThrow(() => new LootTable(new RandomNumberGenerator(), new List<LootItem>()));
        }

        [Test]
        public void CanSetLootTableItemsThroughConstructor()
        {
            var lootItems = new List<LootItem>
            {
                new LootItem ("Item 1", 1),
                new LootItem ("Item 2", 2),
                new LootItem ("Item 3", 3)
            };

            var lootTable = new LootTable(new RandomNumberGenerator(), lootItems);

            Assert.That(lootTable.LootItems.Count, Is.EqualTo(3));
        }

        [Test]
        public void RollMethodReturnsALootItem()
        {
            var lootItems = new List<LootItem>
            {
                new LootItem ("Item 1", 100)
            };
            var lootTable = new LootTable(new RandomNumberGenerator(), lootItems);

            var result = lootTable.Roll();

            Assert.That(result, Is.InstanceOf<LootItem>());
        }

        [TestCase(0, "Sword")]
        [TestCase(10, "Shield")]
        [TestCase(35, "Health Potion")]
        [TestCase(99, "Scroll of Wisdom")]
        public void RollMethodReturnsExpectedLootItem(int randomNumber, string expectedLootItem)
        {
            var lootItems = new List<LootItem>
            {
                new LootItem("Sword", 10),
                new LootItem("Shield", 10),
                new LootItem("Health Potion", 30),
                new LootItem("Resurrection Phial", 30),
                new LootItem("Scroll of Wisdom", 20)
            };

            var mockRandomGenerator = new Mock<IRandomNumberGenerator>();
            mockRandomGenerator.Setup(x => x.GetRandomNumber(It.IsAny<int>())).Returns(randomNumber);

            var lootTable = new LootTable(mockRandomGenerator.Object, lootItems);

            var result = lootTable.Roll().Item;
            Assert.That(result, Is.EqualTo(expectedLootItem));
        }

        [Test]
        public void GetsLootItemsFromFileIfNotPassedInConstructor()
        {
            var lootTable = new LootTable(new RandomNumberGenerator());
            
            Assert.That(lootTable.LootItems.Count, Is.Not.Null);
            Assert.That(lootTable.LootItems.Count, Is.GreaterThan(0));
        }
    }
}

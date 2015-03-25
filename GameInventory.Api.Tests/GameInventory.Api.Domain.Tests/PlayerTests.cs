using GameInventory.Api.Domain;
using NUnit.Framework;

namespace GameInventory.Api.Tests.GameInventory.Api.Domain.Tests
{
    [TestFixture]
    public class PlayerTests
    {
        [Test]
        public void CanInstantiatePlayer()
        {
            Assert.DoesNotThrow(() => new Player());
        }

        [Test]
        public void NewPlayerHasName()
        {
            var player = new Player();

            Assert.That(player.Name, Is.EqualTo("player1"));
        }

        [Test]
        public void CanSetPlayerNameThroughConstructor()
        {
            var player = new Player("Test Player");

            Assert.That(player.Name, Is.EqualTo("Test Player"));
        }

        [Test]
        public void NewPlayerHasNullLootItem()
        {
            var player = new Player();

            Assert.That(player.LootItem, Is.Null);
        }
    }
}

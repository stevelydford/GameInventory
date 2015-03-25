using System.Collections.Generic;
using GameInventory.Api.Domain;
using GameInventory.Api.Models;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace GameInventory.Api.Specs
{
    [Binding]
    public class ReceiveAnItemSteps
    {
        private Player _player;
        private LootTable _lootTable;

        [Given]
        public void GivenIHaveAPlayer()
        {
            _player = new Player();
        }

        [Given]
        public void GivenAConfiguredLootTable()
        {
            var lootItems = new List<LootItem>
            {
                new LootItem("Sword", 10),
                new LootItem("Shield", 10),
                new LootItem("Health Potion", 30),
                new LootItem("Resurrection Phial", 30),
                new LootItem("Scroll of Wisdom", 20)
            };

            _lootTable = new LootTable(new RandomNumberGenerator(), lootItems);
        }

        [Given]
        public void GivenAnExistingRuntimeConfigurableLootTable()
        {
            _lootTable = new LootTable(new RandomNumberGenerator());
        }

        [When]
        public void WhenIRollOnThisLootTable()
        {
            _player.LootItem = _lootTable.Roll();
        }

        [Then]
        public void ThenIReceiveARandomItemFromTheLootTable()
        {
            Assert.That(_player.LootItem, Is.InstanceOf<LootItem>());
            Assert.That(_player.LootItem, Is.Not.Null);
        }

    }
}

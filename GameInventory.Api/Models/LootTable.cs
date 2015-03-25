using System.Collections.Generic;
using System.IO;
using GameInventory.Api.Domain;
using GameInventory.Api.Models.Interfaces;

namespace GameInventory.Api.Models
{
    public class LootTable
    {
        private readonly IRandomNumberGenerator _randomNumberGenerator;
        public List<LootItem> LootItems { get; set; }

        public LootTable(IRandomNumberGenerator randomNumberGenerator)
        {
            this._randomNumberGenerator = randomNumberGenerator;
            LootItems = GetLootTableFromFile();
        }

        public LootTable(IRandomNumberGenerator randomNumberGenerator, List<LootItem> lootItems)
        {
            _randomNumberGenerator = randomNumberGenerator;
            LootItems = lootItems;
        }

        public LootItem Roll()
        {
            var randomNumber = _randomNumberGenerator.GetRandomNumber(100);

            LootItem selectedLootItem = null;
            foreach (var lootItem in LootItems)
            {
                if (randomNumber < lootItem.DropChance)
                {
                    selectedLootItem = lootItem;
                    break;
                }

                randomNumber = randomNumber - lootItem.DropChance;
            }

            return selectedLootItem;
        }

        private static List<LootItem> GetLootTableFromFile()
        {
            var reader = new StreamReader(File.OpenRead(@"c:\Data\LootItems.csv"));
            var lootItems = new List<LootItem>();

            while (!reader.EndOfStream)
            {
                var readLine = reader.ReadLine();
                if (readLine != null)
                {
                    var values = readLine.Split(',');
                    lootItems.Add(new LootItem(values[0].Trim(), int.Parse(values[1].Trim())));
                }
            }

            return lootItems;
        }
    }
}

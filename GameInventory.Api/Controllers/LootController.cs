using System.Web.Http;
using GameInventory.Api.Domain;
using GameInventory.Api.Models;
using GameInventory.Api.Models.Interfaces;

namespace GameInventory.Api.Controllers
{
    public class LootController : ApiController
    {
        private readonly IRandomNumberGenerator _randomNumberGenerator;

        public LootController(IRandomNumberGenerator randomNumberGenerator)
        {
            _randomNumberGenerator = randomNumberGenerator;
        }

        /// <summary>
        /// Gets a weighted random LootItem.
        /// </summary>
        public LootItem Get()
        {
            var lootTable = new LootTable(_randomNumberGenerator);
            var lootItem = lootTable.Roll();
            return lootItem;
        }
    }
}

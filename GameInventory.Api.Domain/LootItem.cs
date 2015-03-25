namespace GameInventory.Api.Domain
{
    public class LootItem
    {
        public string Item { get; set; }

        public int DropChance { get; set; }

        public LootItem(string item, int dropChance)
        {
            this.Item = item;
            this.DropChance = dropChance;
        }
    }
}

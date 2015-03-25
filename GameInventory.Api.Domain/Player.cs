namespace GameInventory.Api.Domain
{
    public class Player
    {
        public string Name { get; set; }
        public LootItem LootItem { get; set; }

        public Player()
        {
            this.Name = "player1";
        }

        public Player(string name)
        {
            this.Name = name;
        }
    }
}

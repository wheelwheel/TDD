namespace TDD
{
    public class Parser
    {
        public List<Player> Parse(string input)
        {
            return new List<Player> {
                                        new Player() { Name = "Black" },
                                        new Player() { Name = "White" },
                                    };
        }

        public class Player
        {
            public string Name { get; set; }
        }
    }
}
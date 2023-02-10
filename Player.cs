namespace TDD
{
    public partial class Parser
    {
        public class Player
        {
            public string Name { get; set; }
            public List<Card> Cards { get; set; }
        }

        public class Card
        {
            public string Suit { get; set; }
            public int Value { get; set; }
            public string Output { get; set; }
        }
    }
}
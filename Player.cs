namespace TDD
{
    public class Player
    {
        public string Name { get; set; }
        public List<Card> Cards { get; set; }

        public PokerHands GetPokerHands()
        {
            return new PokerHands(Cards);
        }
    }
}
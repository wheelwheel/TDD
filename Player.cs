namespace TDD
{
    public class Player
    {
        public string Name { get; set; }
        public List<Card> Cards { get; set; }

        public IEnumerable<Card> GetPokerHands()
        {
            return Cards.OrderByDescending(x => x.Value);
        }
    }
}
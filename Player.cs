using System.Collections;

namespace TDD
{
    public class Player
    {
        public string Name { get; set; }
        public List<Card> Cards { get; set; }

        public IEnumerable<Card> GetPokerHands()
        {
            return new PokerHands(Cards.OrderByDescending(x => x.Value));
        }
    }

    public class PokerHands : IEnumerable<Card>
    {
        private readonly IEnumerable<Card> _cards;

        public PokerHands(IEnumerable<Card> cards)
        {
            _cards = cards;
        }

        public IEnumerator<Card> GetEnumerator()
        {
            return _cards.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
           return GetEnumerator();
        }
    }
}
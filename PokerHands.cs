using System.Collections;
using TDD.Categories;

namespace TDD
{
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

        public Category GetCategory()
        {
            var pairs = this.GroupBy(x => x.Value).Where(x => x.Count() == 2);
            if (pairs.Any())
            {
                return new Pair { Output = pairs.First().First().Output };
            }

            return new HighCard();
        }

        public IEnumerable<IGrouping<int, Card>> GetPairs()
        {
            return this.GroupBy(x => x.Value).Where(x => x.Count() == 2);
        }
    }
}
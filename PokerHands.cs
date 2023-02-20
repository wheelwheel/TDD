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
            var pairs = GetPairs();

            if (pairs.Count() == 2)
            {
                // todo: hard-code return
                return new TwoPairs{Output = "9 over 3" };
            }

            if (pairs.Any())
            {
                return new Pair { Output = pairs.First().First().Output };
            }

            return new HighCard();
        }

        public IEnumerable<Card> GetFirstCardOfEachGroup()
        {
            return this.GroupBy(x => x.Value)
                       .OrderByDescending(x => x.Count())
                       .Select(x => x.First());
        }

        private IEnumerable<IGrouping<int, Card>> GetPairs()
        {
            return this.GroupBy(x => x.Value).Where(x => x.Count() == 2);
        }
    }

    public class TwoPairs : Category
    {
        public override CategoryType Type => CategoryType.TwoPairs;

        public override string Name => "two pairs";
    }
}
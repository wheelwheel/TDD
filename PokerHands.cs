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
            if (IsMatchedTwoPairs(this))
            {
                var biggerPair = GetPairs().First().First().Output;
                var smallerPair = GetPairs().Last().First().Output;
                return new TwoPairs { Output = $"{biggerPair} over {smallerPair}" };
            }
            else
            {
                if (IsMatchedPair(this))
                {
                    return new Pair { Output = GetPairs().First().First().Output };
                }
                return new HighCard();
            }
        }

        private static bool IsMatchedPair(PokerHands pokerhands)
        {
            return pokerhands.GetPairs().Any();
        }

        private static bool IsMatchedTwoPairs(PokerHands pokerhands)
        {
            return pokerhands.GetPairs().Count() == 2;
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
}
using System.Collections;
using TDD.Categories;
using TDD.CategoryMatchers;

namespace TDD
{
    public class PokerHands : IEnumerable<Card>
    {
        private readonly IEnumerable<Card> _cards;
        private readonly CategoryMatcher _categoryMatcher;

        public PokerHands(IEnumerable<Card> cards)
        {
            _cards = cards;
            _categoryMatcher = new FlushMatcher(
                new StraightMatcher(
                new ThreeOfAKindMatcher(
                    new TwoPairsMatcher(
                        new PairMatcher(null)))));
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
            return _categoryMatcher.DecidedCategory(this);
        }

        public IEnumerable<Card> GetFirstCardOfEachGroup()
        {
            return this.GroupBy(x => x.Value)
                       .OrderByDescending(x => x.Count())
                       .Select(x => x.First());
        }

        public IEnumerable<IGrouping<int, Card>> GetPairs()
        {
            return this.GroupBy(x => x.Value).Where(x => x.Count() == 2);
        }

        public IEnumerable<IGrouping<int, Card>> GetThreeOfAKind()
        {
            return this.GroupBy(x => x.Value).Where(x => x.Count() == 3);
        }

        public bool IsFiush()
        {
            return this.GroupBy(x => x.Suit).Count() == 1;
        }

       public bool IsStraight()
        {
            var cardTexts = string.Join("", this.Select(x => x.Text));
            return new string[] { "AKQJT98765432", "A5432" }.Any(x => x.Contains(cardTexts));
        }

        public bool IsPair()
        {
            return GetPairs().Any();
        }

        public bool IsTwoPairs()
        {
            return GetPairs().Count() == 2;
        }

        public bool IsThreeOfAKind()
        {
            return GetThreeOfAKind().Any();
        }
    }
}
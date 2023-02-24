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
            _categoryMatcher = new StraightMatcher(new ThreeOfAKindMatcher(new TwoPairsMatcher(new PairMatcher(null))));
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

    internal class StraightMatcher : CategoryMatcher
    {
        public StraightMatcher(CategoryMatcher nextCategoryMatcher) : base(nextCategoryMatcher)
        {
        }

        protected override Category GetMatchedCategory(PokerHands pokerHands)
        {
            return new Straight() { Output = pokerHands.First().Output};
        }

        protected override bool IsMatched(PokerHands pokerHands)
        {
            var straightPatten = "AKQJT98765432";


            var cardTexts = string.Join("", pokerHands.Select(x => x.Text));

            return straightPatten.Contains(cardTexts);
        }
    }

    public class Straight : Category
    {
        public override CategoryType Type => CategoryType.Strairht;

        public override string Name => "straight";
    }
}
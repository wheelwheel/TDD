using TDD.Categories;

namespace TDD.CategoryMatchers
{
    public abstract class CategoryMatcher
    {
        private readonly PairMatcher _nextCategoryMatcher;

        protected CategoryMatcher(PairMatcher nextCategoryMatcher)
        {
            _nextCategoryMatcher = nextCategoryMatcher;
        }

        public Category DecidedCategory(PokerHands pokerHands)
        {
            if (IsMatched(pokerHands))
            {
                return GetMatchedCategory(pokerHands);
            }
            else
            {
                return _nextCategoryMatcher.DecidedCategory(pokerHands);
            }
        }

        protected abstract Category GetMatchedCategory(PokerHands pokerHands);
        protected abstract bool IsMatched(PokerHands pokerHands);
    }

    public class TwoPairsMatcher : CategoryMatcher
    {
        public TwoPairsMatcher(PairMatcher nextCategoryMatcher) : base(nextCategoryMatcher)
        {
        }

        protected override Category GetMatchedCategory(PokerHands pokerHands)
        {
            var biggerPair = pokerHands.GetPairs().First().First().Output;
            var smallerPair = pokerHands.GetPairs().Last().First().Output;
            return new TwoPairs { Output = $"{biggerPair} over {smallerPair}" };
        }

        protected override bool IsMatched(PokerHands pokerHands)
        {
            return pokerHands.GetPairs().Count() == 2;
        }
    }
}
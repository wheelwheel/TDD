using TDD.Categories;

namespace TDD.CategoryMatchers
{
    public class TwoPairsMatcher
    {
        private readonly PairMatcher _nextCategoryMatcher;

        public TwoPairsMatcher()
        {
            _nextCategoryMatcher = new PairMatcher();
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

        private Category GetMatchedCategory(PokerHands pokerHands)
        {
            var biggerPair = pokerHands.GetPairs().First().First().Output;
            var smallerPair = pokerHands.GetPairs().Last().First().Output;
            return new TwoPairs { Output = $"{biggerPair} over {smallerPair}" };
        }

        private bool IsMatched(PokerHands pokerHands)
        {
            return pokerHands.GetPairs().Count() == 2;
        }
    }
}
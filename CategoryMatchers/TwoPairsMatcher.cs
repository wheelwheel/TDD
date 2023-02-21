using TDD.Categories;

namespace TDD.CategoryMatchers
{
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
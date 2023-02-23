using TDD.Categories;

namespace TDD.CategoryMatchers
{
    public class PairMatcher : CategoryMatcher
    {
        public PairMatcher(PairMatcher nextCategoryMatcher) : base(nextCategoryMatcher)
        {
        }

        protected override Category GetMatchedCategory(PokerHands pokerHands)
        {
            return new Pair { Output = pokerHands.GetPairs().First().First().Output };
        }

        protected override bool IsMatched(PokerHands pokerHands)
        {
            return pokerHands.IsPair();
        }
    }
}
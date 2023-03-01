using TDD.Categories;

namespace TDD.CategoryMatchers
{
    internal class StraightFlushMatcher : CategoryMatcher
    {
        public StraightFlushMatcher(CategoryMatcher nextCategoryMatcher) : base(nextCategoryMatcher)
        {
        }

        protected override Category GetMatchedCategory(PokerHands pokerHands)
        {
            return new StraightFlush() { Output = pokerHands.First().Output };
        }

        protected override bool IsMatched(PokerHands pokerHands)
        {
            return pokerHands.IsStraight() && pokerHands.IsFiush();
        }
    }
}
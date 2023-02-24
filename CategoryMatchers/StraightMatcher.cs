using TDD.Categories;

namespace TDD.CategoryMatchers
{
    internal class StraightMatcher : CategoryMatcher
    {
        public StraightMatcher(CategoryMatcher nextCategoryMatcher) : base(nextCategoryMatcher)
        {
        }

        protected override Category GetMatchedCategory(PokerHands pokerHands)
        {
            return new Straight() { Output = pokerHands.First().Output };
        }

        protected override bool IsMatched(PokerHands pokerHands)
        {
            return pokerHands.IsStraight();
        }
    }
}
using TDD.Categories;

namespace TDD.CategoryMatchers
{
    public class FlushMatcher : CategoryMatcher
    {
        public FlushMatcher(CategoryMatcher nextCategoryMatcher) : base(nextCategoryMatcher)
        {
        }

        protected override Category GetMatchedCategory(PokerHands pokerHands)
        {
            return new Flush() { Output = pokerHands.First().Output };
        }

        protected override bool IsMatched(PokerHands pokerHands)
        {
            return pokerHands.IsFiush();
        }
    }
}
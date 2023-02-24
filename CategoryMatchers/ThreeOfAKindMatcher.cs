using TDD.Categories;

namespace TDD.CategoryMatchers
{
    public class ThreeOfAKindMatcher : CategoryMatcher
    {
        public ThreeOfAKindMatcher(CategoryMatcher nextCategoryMatcher) : base(nextCategoryMatcher)
        {
        }

        protected override Category GetMatchedCategory(PokerHands pokerHands)
        {
            return new ThreeOfAKind() { Output = pokerHands.GetThreeOfAKind().First().First().Output };
        }

        protected override bool IsMatched(PokerHands pokerHands)
        {
            return pokerHands.IsThreeOfAKind();
        }
    }
}
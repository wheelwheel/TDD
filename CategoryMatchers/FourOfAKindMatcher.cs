using TDD.Categories;

namespace TDD.CategoryMatchers
{
    internal class FourOfAKindMatcher : CategoryMatcher
    {
        public FourOfAKindMatcher(CategoryMatcher nextCategoryMatcher) : base(nextCategoryMatcher)
        {
        }

        protected override Category GetMatchedCategory(PokerHands pokerHands)
        {
            return new FourOfAKind() { Output = pokerHands.GetFourOfAKind().First().First().Output };
        }

        protected override bool IsMatched(PokerHands pokerHands)
        {
            return pokerHands.GetFourOfAKind().Any();
        }
    }
}
using TDD.Categories;

namespace TDD.CategoryMatchers
{
    internal class FullHouseMatcher : CategoryMatcher
    {
        public FullHouseMatcher(CategoryMatcher nextCategoryMatcher) : base(nextCategoryMatcher)
        {
        }

        protected override Category GetMatchedCategory(PokerHands pokerHands)
        {
            var threeOfAKind = pokerHands.GetThreeOfAKind().First().First().Output;
            var pair = pokerHands.GetPairs().First().First().Output;
            return new FullHouse() { Output = $"{threeOfAKind} over {pair}" };
        }

        protected override bool IsMatched(PokerHands pokerHands)
        {
            return pokerHands.IsThreeOfAKind() && pokerHands.IsPair();
        }
    }
}
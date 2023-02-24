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
            var straightPatten = "AKQJT98765432";

            var cardTexts = string.Join("", pokerHands.Select(x => x.Text));

            return straightPatten.Contains(cardTexts);
        }
    }
}
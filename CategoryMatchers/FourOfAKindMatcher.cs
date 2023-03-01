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
            return new FourOfAKind() { Output = GetFourOfAKind(pokerHands).First().First().Output };
        }

        protected override bool IsMatched(PokerHands pokerHands)
        {
            return GetFourOfAKind(pokerHands).Any();
        }

        private static IEnumerable<IGrouping<int, Card>> GetFourOfAKind(PokerHands pokerHands)
        {
            return pokerHands.GroupBy(x => x.Value).Where(x => x.Count() == 4);
        }
    }
}
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
            return new ThreeOfAKind() { Output = GetThreeOfAKind(pokerHands).First().First().Output };
        }

        protected override bool IsMatched(PokerHands pokerHands)
        {
            return GetThreeOfAKind(pokerHands).Any();
        }

        private static IEnumerable<IGrouping<int, Card>> GetThreeOfAKind(PokerHands pokerHands)
        {
            return pokerHands.GroupBy(x => x.Value).Where(x => x.Count() == 3);
        }
    }
}
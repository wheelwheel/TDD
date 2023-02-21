using TDD.Categories;

namespace TDD.CategoryMatchers
{
    public class PairMatcher
    {
        public PairMatcher()
        {
        }

        private bool IsMatchedPair(PokerHands pokerHands)
        {
            return pokerHands.GetPairs().Any();
        }

        public Category DecidedCategory(PokerHands pokerHands)
        {
            if (IsMatchedPair(pokerHands))
            {
                return new Pair { Output = pokerHands.GetPairs().First().First().Output };
            }
            return new HighCard();
        }
    }
}
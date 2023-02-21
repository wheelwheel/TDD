using TDD.Categories;

namespace TDD.CategoryMatchers
{
    public class PairMatcher : CategoryMatcher
    {
        public PairMatcher(PairMatcher nextCategoryMatcher) : base(nextCategoryMatcher)
        {
        }

        //public Category DecidedCategory(PokerHands pokerHands)
        //{
        //    if (IsMatchedPair(pokerHands))
        //    {
        //        return new Pair { Output = pokerHands.GetPairs().First().First().Output };
        //    }
        //    return new HighCard();
        //}

        protected override Category GetMatchedCategory(PokerHands pokerHands)
        {
            return new Pair { Output = pokerHands.GetPairs().First().First().Output };
        }

        protected override bool IsMatched(PokerHands pokerHands)
        {
            return IsMatchedPair(pokerHands);
        }

        private bool IsMatchedPair(PokerHands pokerHands)
        {
            return pokerHands.GetPairs().Any();
        }
    }
}
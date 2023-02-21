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

        public Category NextMatch(PokerHands pokerHands)
        {
            if (IsMatchedPair(pokerHands))
            {
                return new Pair { Output = pokerHands.GetPairs().First().First().Output };
            }
            return new HighCard();
        }
    }

    public class TwoPairsMatcher
    {
        private readonly PairMatcher _pairMatcher;

        public TwoPairsMatcher()
        {
            _pairMatcher = new PairMatcher();
        }

        public Category DecidedCategory(PokerHands pokerHands)
        {
            if (IsMatched(pokerHands))
            {
                return GetMatchedCategory(pokerHands);
            }
            else
            {
                return _pairMatcher.NextMatch(pokerHands);
            }
        }

        private Category GetMatchedCategory(PokerHands pokerHands)
        {
            var biggerPair = pokerHands.GetPairs().First().First().Output;
            var smallerPair = pokerHands.GetPairs().Last().First().Output;
            return new TwoPairs { Output = $"{biggerPair} over {smallerPair}" };
        }

        private bool IsMatched(PokerHands pokerHands)
        {
            return pokerHands.GetPairs().Count() == 2;
        }
    }
}
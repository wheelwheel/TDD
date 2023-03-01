using TDD.Categories;

namespace TDD.Comparers
{
    public class PokerHandsComparer : IPokerHandsComparer
    {
        private static readonly Dictionary<CategoryType, IPokerHandsComparer> SameComparersLookup =
            new Dictionary<CategoryType, IPokerHandsComparer>
            {
                { CategoryType.StraightFlush,new StraightFlushComparer()},
                { CategoryType.FourOfAKind,new FourOfAKindComparer()},
                { CategoryType.FullHouse,new FullHouseComparer()},
                { CategoryType.Flush,new FlushComparer()},
                { CategoryType.Straight,new StraightComparer()},
                { CategoryType.ThreeOfAKind,new ThreeOfAKindComparer()},
                { CategoryType.TwoPairs,new TwoPairsComparer()},
                { CategoryType.Pair,new PairComparer()},
                { CategoryType.HighCard,new HighCardComparer()},
            };

        public string WinnerOutput { get; private set; }

        public string WinnerCategory { get; private set; }

        public int Compare(PokerHands pokerHands1, PokerHands pokerHands2)
        {
            var comparer = GetComparer(pokerHands1, pokerHands2);
            var compareResult = comparer.Compare(pokerHands1, pokerHands2);
            WinnerOutput = comparer.WinnerOutput;
            WinnerCategory = comparer.WinnerCategory;

            return compareResult;
        }
        private static IPokerHandsComparer GetComparer(PokerHands pokerHands1, PokerHands pokerHands2)
        {
            var categoryType1 = pokerHands1.GetCategory().Type;
            var categoryType2 = pokerHands2.GetCategory().Type;
            if (categoryType1 != categoryType2)
                return new DifferentCategoryComparer();

            return SameComparersLookup[categoryType1];
        }
    }
}
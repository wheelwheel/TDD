﻿using TDD.Categories;
using TDD.Comparers;

namespace TDD
{
    public class Game
    {
        private static readonly Dictionary<CategoryType, IPokerHandsComparer> SameComparersLookup = 
            new Dictionary<CategoryType, IPokerHandsComparer>
            {
                { CategoryType.FourOfAKind,new FourOfAKindComparer()},
                { CategoryType.FullHouse,new FullHouseComparer()},
                { CategoryType.Flush,new FlushComparer()},
                { CategoryType.Straight,new StraightComparer()},
                { CategoryType.ThreeOfAKind,new ThreeOfAKindComparer()},
                { CategoryType.TwoPairs,new TwoPairsComparer()},
                { CategoryType.Pair,new PairComparer()},
                { CategoryType.HighCard,new HighCardComparer()},
            };

        public string ShowResult(string input)
        {
            var players = new Parser().Parse(input);

            var pokerHands1 = players[0].GetPokerHands();
            var pokerHands2 = players[1].GetPokerHands();

            var comparer = GetComparer(pokerHands1, pokerHands2);

            var compareResult = comparer.Compare(pokerHands1, pokerHands2);

            if (compareResult != 0)
            {
                var winnerPlayer = compareResult < 0 ? players[1].Name : players[0].Name;
                var winnerOutput = comparer.WinnerOutput;
                var winnerCategory = comparer.WinnerCategory;
                return $"{winnerPlayer} wins. - with {winnerCategory}: {winnerOutput}";
            }

            return "Tie.";
        }

        private static IPokerHandsComparer GetComparer(PokerHands pokerHands1, PokerHands pokerHands2)
        {

            var categoryType1 = pokerHands1.GetCategory().Type;
            var categoryType2 = pokerHands2.GetCategory().Type;
            if (categoryType1 != categoryType2)
            {
                return new DifferentCategoryComparer();
            }

            return SameComparersLookup[categoryType1];
        }
    }

    internal class FourOfAKindComparer : SameCategoryComparer
    {
        public override string WinnerCategory => "four of a kind";

        public override int Compare(PokerHands pokerHands1, PokerHands pokerHands2)
        {
            return CompareCardsByValue(pokerHands1.GetFirstCardOfEachGroup(), pokerHands2.GetFirstCardOfEachGroup());
        }
    }
}
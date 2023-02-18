﻿using TDD.Categories;
using TDD.Comparers;

namespace TDD
{
    public class Game
    {
        public string ShowResult(string input)
        {
            var players = new Parser().Parse(input);

            var pokerHands1 = players[0].GetPokerHands();
            var pokerHands2 = players[1].GetPokerHands();
            var category1 = GetCategory(pokerHands1);
            var category2 = GetCategory(pokerHands2);

            if (category1.Type > category2.Type)
            {
                var winnerPlayer = players[0].Name;
                var winnerCategory = category1.Name;
                var winnerOutput = category1.Output;
                return $"{winnerPlayer} wins. - with {winnerCategory}: {winnerOutput}";
            }

            var highCardComparer = new HighCardComparer();
            var compareResult = highCardComparer.Compare(pokerHands1, pokerHands2);

            if (compareResult != 0)
            {
                var winnerPlayer = compareResult < 0 ? players[1].Name : players[0].Name;
                var winnerOutput = highCardComparer.WinnerOutput;
                return $"{winnerPlayer} wins. - with high card: {winnerOutput}";
            }

            return "Tie.";
        }

        private static Category GetCategory(IEnumerable<Card> pokerHands)
        {
            var pairs = pokerHands.GroupBy(x => x.Value).Where(x => x.Count() == 2);
            if (pairs.Any())
            {
                return new Pair {Output =pairs.First().First().Output};
            }

            return new HighCard();
        }
    }

    internal class HighCard : Category
    {
        public override CategoryType Type => CategoryType.HighCard;
        public override string Name => "high card";
    }

    internal class Pair : Category
    {
        public override CategoryType Type => CategoryType.Pair;
        public override string Name => "pair";
    }
}
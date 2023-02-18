using TDD.Categories;
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
            if (pokerHands1.GetCategory().Type != pokerHands2.GetCategory().Type)
            {
                return new DifferentCategoryComparer();
            }

            return new HighCardComparer();
        }
    }
}
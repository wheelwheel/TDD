using TDD.Categories;
using TDD.Comparers;

namespace TDD
{
    public class Game
    {
        private readonly DifferentCategoryComparer _differentCategoryComparer = new DifferentCategoryComparer();

        public string ShowResult(string input)
        {
            var players = new Parser().Parse(input);

            var pokerHands1 = players[0].GetPokerHands();
            var pokerHands2 = players[1].GetPokerHands();

            int compareResult;
            string winnerCategory;
            string winnerOutput;
            if (pokerHands1.GetCategory().Type != pokerHands2.GetCategory().Type)
            {
                var differentCategoryComparer = new DifferentCategoryComparer();
                compareResult = differentCategoryComparer.Compare(pokerHands1.GetCategory(), pokerHands2.GetCategory());
                winnerOutput = differentCategoryComparer.WinnerOutput;
                winnerCategory = differentCategoryComparer.WinnerCategory;
            }
            else
            {
                var highCardComparer = new HighCardComparer();
                compareResult = highCardComparer.Compare(pokerHands1, pokerHands2);
                winnerOutput = highCardComparer.WinnerOutput;
                winnerCategory = highCardComparer.WinnerCategory;
            }

            if (compareResult != 0)
            {
                var winnerPlayer = compareResult < 0 ? players[1].Name : players[0].Name;
                return $"{winnerPlayer} wins. - with {winnerCategory}: {winnerOutput}";
            }

            return "Tie.";
        }
    }
}
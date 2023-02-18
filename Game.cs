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
            var category1 = pokerHands1.GetCategory();
            var category2 = pokerHands2.GetCategory();

            int compareResult;
            string winnerCategory;
            string winnerOutput;
            if (category1.Type != category2.Type)
            {
                var differentCategoryComparer = new DifferentCategoryComparer();
                compareResult = differentCategoryComparer.Compare(category1, category2);
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
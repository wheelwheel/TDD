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
            var category1 = GetCategory(pokerHands1);
            var category2 = GetCategory(pokerHands2);

            int compareResult;
            string winnerCategory;
            string winnerOutput;
            if (category1.Type != category2.Type)
            {
                compareResult = DifferentCategoryCompare(category1, category2, out winnerCategory, out winnerOutput);
            }
            else
            {
                var highCardComparer = new HighCardComparer();
                compareResult = highCardComparer.Compare(pokerHands1, pokerHands2);
                winnerOutput = highCardComparer.WinnerOutput;
                winnerCategory = highCardComparer.CategoryName;
            }

            if (compareResult != 0)
            {
                var winnerPlayer = compareResult < 0 ? players[1].Name : players[0].Name;
                return $"{winnerPlayer} wins. - with {winnerCategory}: {winnerOutput}";
            }

            return "Tie.";
        }
        
        private static int DifferentCategoryCompare(Category category1, Category category2, out string winnerCategory, out string winnerOutput)
        {
            var compareResult = category1.Type - category2.Type;
            if (category1.Type > category2.Type)
            {
                winnerCategory = category1.Name;
                winnerOutput = category1.Output;
            }
            else
            {
                winnerCategory = category2.Name;
                winnerOutput = category2.Output;
            }

            return compareResult;
        }

        private static Category GetCategory(IEnumerable<Card> pokerHands)
        {
            var pairs = pokerHands.GroupBy(x => x.Value).Where(x => x.Count() == 2);
            if (pairs.Any())
            {
                return new Pair { Output = pairs.First().First().Output };
            }

            return new HighCard();
        }
    }
}
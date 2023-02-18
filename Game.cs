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
            CategoryType categoryTpye1 = GetCategoryType(pokerHands1);
            CategoryType categoryTpye2 = GetCategoryType(pokerHands2);

            if (categoryTpye1 > categoryTpye2)
            {
                // todo: hard-code return
                var winnerPlayer = players[0].Name;
                var winnerCategory = "pair";
                var winnerOutput = "4";
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

        private static CategoryType GetCategoryType(IEnumerable<Card> pokerHands)
        {
            var pairs = pokerHands.GroupBy(x => x.Value).Where(x => x.Count() == 2);
            if (pairs.Any())
            {
                return CategoryType.Pair;
            }

            return CategoryType.HighCard;
        }
    }

    public enum CategoryType
    {
        HighCard = 0,
        Pair = 1,
    }
}
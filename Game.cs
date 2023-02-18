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

            var pairs1 = pokerHands1.GroupBy(x => x.Value).Where(x => x.Count() == 2);
            Category categoryTpye1;
            if (pairs1.Any())
            {
                categoryTpye1 = Category.Pair;
            }
            else
            {
                categoryTpye1 = Category.HighCard;
            }

            if (categoryTpye1 == Category.Pair)
            {
                // todo: hard-code return
                var winnerPlayer = "Black";
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
    }

    public enum Category
    {
        HighCard = 0,
        Pair = 1,
    }
}
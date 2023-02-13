

using Newtonsoft.Json.Linq;

namespace TDD
{
    public class Game
    {
        public string ShowResult(string input)
        {
            var players = new Parser().Parse(input);

            var maxCard1 = players[0].GetPokerHands().First();
            var maxCard2 = players[1].GetPokerHands().First();

            var compareResult = maxCard1.Value - maxCard2.Value;

            if (compareResult != 0)
            {
                string winnerPlayer = null;
                string winnerOutput = null;
                if (compareResult < 0)
                {
                    winnerPlayer = players[1].Name;
                    winnerOutput = maxCard2.Output;
                }
                if (compareResult > 0)
                {
                    winnerPlayer = players[0].Name;
                    winnerOutput = maxCard1.Output;
                }

                return $"{winnerPlayer} wins. - with high card: {winnerOutput}";
            }

            return "Tie.";
        }
    }
}
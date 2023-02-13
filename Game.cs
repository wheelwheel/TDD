namespace TDD
{
    public class Game
    {
        public string ShowResult(string input)
        {
            var players = new Parser().Parse(input);
                
            var maxCard1 = players[0].GetPokerHands().First();
            var maxCard2 = players[1].GetPokerHands().First();

            string winnerPlayer;
            string winnerOutput;
            if (maxCard2.Value > maxCard1.Value)
            {
                winnerPlayer = players[1].Name;
                winnerOutput = maxCard2.Output;
            }
            else
            {
                winnerPlayer = players[0].Name;
                winnerOutput = maxCard1.Output;
            }

            return $"{winnerPlayer} wins. - with high card: {winnerOutput}";

        }
    }
}
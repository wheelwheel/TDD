namespace TDD
{
    public class Game
    {
        public string ShowResult(string input)
        {
            // todo: hard-cod return
            // Black: 2H 3D 5S 8C 6D  White: 2C 3H 4S 9C 5H
            var parser = new Parser();
            var players = parser.Parse(input);
                
            var maxCard1 = players[0].GetPokerHands().First();
            var maxCard2 = players[1].GetPokerHands().First();

            if (maxCard2.Value > maxCard1.Value)
            {
                var winnerPlayer = players[1].Name;
                var winnerOutput = maxCard2.Output;
                return $"{winnerPlayer} wins. - with high card: {winnerOutput}";
            }
            else
            {
                var winnerPlayer = players[0].Name;
                var winnerOutput = maxCard1.Output;
                return $"{winnerPlayer} wins. - with high card: {winnerOutput}";
            }
        }
    }
}
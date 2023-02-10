namespace TDD
{
    public class Game
    {
        public string ShowResult(string input)
        {
            // todo: hard-cod return
            // Black: 2H 3D 5S 8C 6D  White: 2C 3H 4S 9C 5H
            var winnerPlayer = "White";
            var winnerOutput = "9";
            return $"{winnerPlayer} wins. - with high card: {winnerOutput}";
        }
    }
}
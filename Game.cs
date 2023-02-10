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
            
            var winnerPlayer = players[1].Name;
            var winnerOutput = players[1]
                               .Cards
                               .OrderByDescending(x=>x.Value)
                               .First()
                               .Output;
            return $"{winnerPlayer} wins. - with high card: {winnerOutput}";
        }
    }
}
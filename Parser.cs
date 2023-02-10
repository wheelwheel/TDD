namespace TDD
{
    public class Parser
    {
        public List<Player> Parse(string input)
        {
            // Black: 2H 3D 5S 8C 6D  White: 2C 3H 4S 9C 5H
            var playerSections = input.Split(new[] { "  " }, StringSplitOptions.RemoveEmptyEntries);
            var player1Name = playerSections[0].Split(":".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0];
            var player2Name = playerSections[1].Split(":".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0]; 

            return new List<Player> {
                                        new Player() { Name = player1Name },
                                        new Player() { Name = player2Name },
                                    };
        }

        public class Player
        {
            public string Name { get; set; }
        }
    }
}
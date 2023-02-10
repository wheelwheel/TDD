using static TDD.Parser;

namespace TDD
{
    public partial class Parser
    {
        public List<Player> Parse(string input)
        {
            // Black: 2H 3D 5S 8C 6D  White: 2C 3H 4S 9C 5H
            var playerSections = input.Split(new[] { "  " }, StringSplitOptions.RemoveEmptyEntries);

            return new List<Player> {
                                        GetPlayer(playerSections, 0),
                                        GetPlayer(playerSections, 1), 
                                    };
        }

        private static int GetValue(char c)
        {
            var valueLookup = new Dictionary<char, int>()
            {
                { 'T',10 },
                { 'J',11 },
            };

            if (valueLookup.ContainsKey(c))
                return valueLookup[c];

            return (int)char.GetNumericValue(c);
        }

        private static string GetOutput(char c)
        {
            if (c == 'T')
                return "10";
            if (c == 'J')
                return "Jack";
            return c.ToString();
        }

        private static Player GetPlayer(string[] playerSections, int playerIndex)
        {
            var name = playerSections[playerIndex].Split(":".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0];
            var cards = playerSections[playerIndex].Split(":".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[1]
                                          .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                                          .Select(x => new Card()
                                          {
                                              Suit = x[1].ToString(),
                                              Value = GetValue(x[0]),
                                              Output = GetOutput(x[0]),
                                          })
                                          .ToList();

            return new Player()
            {
                Name = name,
                Cards = cards
            };
        }
    }
}
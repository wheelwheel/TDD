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

        private static Player GetPlayer(string[] playerSections, int playerIndex)
        {
            var name = playerSections[playerIndex].Split(":".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0];
            var cards = playerSections[playerIndex].Split(":".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[1]
                                          .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                                          .Select(x => new Card()
                                          {
                                              Suit = x[1].ToString(),
                                              Value = (int)char.GetNumericValue(x[0]),
                                              Output = x[0].ToString(),
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
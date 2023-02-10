using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TDD.Parser;

namespace TDD
{
    [TestFixture]
    public class ParserTests
    {
        [Test]
        public void parse_players()
        {
            var parser = new Parser();
            // Black: 2H 3D 5S 8C 6D  White: 2C 3H 4S 9C 5H
            var players = parser.Parse("Black: 2H 3D 5S 8C 6D  White: 2C 3H 4S JC TH");
            players.Should()
                   .BeEquivalentTo(new List<Player> {
                                                                new Player()
                                                                {
                                                                    Name = "Black",
                                                                    Cards = new List<Card>
                                                                    {
                                                                        new Card(){Suit = "H",Value = 2,Output="2"},
                                                                        new Card(){Suit = "D",Value = 3,Output="3"},
                                                                        new Card(){Suit = "S",Value = 5,Output="5"},
                                                                        new Card(){Suit = "C",Value = 8,Output="8"},
                                                                        new Card(){Suit = "D",Value = 6,Output="6"}
                                                                    }

                                                                },
                                                                new Player() { 
                                                                    Name = "White",
                                                                    Cards = new List<Card>
                                                                    {
                                                                        new Card(){Suit = "C",Value = 2,Output="2"},
                                                                        new Card(){Suit = "H",Value = 3,Output="3"},
                                                                        new Card(){Suit = "S",Value = 4,Output="4"},
                                                                        new Card(){Suit = "C",Value = 11,Output="Jack"},
                                                                        new Card(){Suit = "H",Value = 10,Output="10"}
                                                                    }},
                                                               }, options => options.WithStrictOrdering());
        }
    }
}

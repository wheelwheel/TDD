using FluentAssertions;
namespace TDD
{
    [TestFixture]
    public class GameTests
    {
        private Game _game;

        [SetUp]
        public void SetUp() 
        {
            _game = new Game();
        }

        [Test]
        public void both_high_card()
        {
            // HighCard vs HighCard
            ResultSholdBe("Black: 2H 3D 5S 8C KD  White: 2C 3H 4S 8C AH",
                       "White wins. - with high card: Ace");

            // decided by 2nd cards
            ResultSholdBe("Black: 2H 3D 5S 9C KD  White: 2C 3H 4S 8C KH",
                        "Black wins. - with high card: 9");

            // decided by 3nd cards
            ResultSholdBe("Black: 2H 3D 5S 9C KD  White: 2C 3H 4S 9C KH",
                        "Black wins. - with high card: 5");

            // HighCard vs HighCard when Tie
            ResultSholdBe("Black: 2H 3D 5S 9C KD  White: 2D 3H 5C KS 9H",
                        "Tie.");
        }

        private void ResultSholdBe(string input, string expected)
        {
            var showResult = _game.ShowResult(input);
            showResult.Should().Be(expected);
        }
    }
}
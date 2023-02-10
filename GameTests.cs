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
        public void show_winner_card_output()
        {
            // 2~9
            ResultSholdBe("Black: 2H 3D 5S 8C 6D  White: 2C 3H 4S 9C 5H",
                        "White wins. - with high card: 9");

            // compare Black or White win by max Valuecard
            // Black: 2H 3D 5S 8C KD  White: 2C 3H 4S JC 5H 
            // Black wins. - with high card: King
        }

        private void ResultSholdBe(string input, string expected)
        {
            var showResult = _game.ShowResult(input);
            showResult.Should().Be(expected);
        }
    }
}
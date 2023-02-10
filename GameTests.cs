using FluentAssertions;
namespace TDD
{
    [TestFixture]
    public class GameTests
    {
        [Test]
        public void show_winner_card_output()
        {
            var game = new Game();
            // 2~9
            // Black: 2H 3D 5S 8C 6D  White: 2C 3H 4S 9C 5H
            // White wins. - with high card: 9
            var showResult = game.ShowResult("Black: 2H 3D 5S 8C 6D  White: 2C 3H 4S 9C 5H");
            showResult.Should().Be("White wins. - with high card: 9");
        }
    }
}
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
        [Category("high card")]
        [Category("same category")]
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

        [Test]
        [Category("pair")]
        [Category("different category")]
        public void pair_win_others()
        {
            // pair compare with high card when player1 win
            ResultSholdBe("Black: 3H 4S 4C 2D 5H  White: 2S 8S AS QH 3S",
                        "Black wins. - with pair: 4");

            // different category compare when player2 win
            ResultSholdBe("Black: 3H 4S 7C 2D 5H  White: QS 8S AS QH 3S",
                        "White wins. - with pair: Queen");
        }

        [Test]
        [Category("pair")]
        [Category("same category")]
        public void both_pair()
        {
            // 比較 pair 點數大小
            ResultSholdBe("Black: 2H 3D TS TC KD  White: 2D 3H 3C 9S AH",
                        "Black wins. - with pair: 10");
        }

        private void ResultSholdBe(string input, string expected)
        {
            var showResult = _game.ShowResult(input);
            showResult.Should().Be(expected);
        }
    }
}
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
            // ゑ耕 pair 翴计
            ResultSholdBe("Black: 2H 3D TS TC KD  White: 2D 3H 3C 9S AH",
                        "Black wins. - with pair: 10");

            // pair 翴计妓ㄌゑㄤ獶 pair 礟翴计
            ResultSholdBe("Black: 2H 3D TS TC KD  White: 2D TH TC 9S AH",
                        "White wins. - with pair: Ace");

            // pair 翴计妓ㄌゑㄤ獶 pair 礟翴计, last one
            ResultSholdBe("Black: 9H 3D TS TC KD  White: 2D TH TC 9S KH",
                        "Black wins. - with pair: 3");

            // tie when both pair
            ResultSholdBe("Black: 9H 3D TS TC KD  White: 3D TH TC 9S KH",
                        "Tie.");
        }

        [Test]
        [Category("two pair")]
        [Category("different category")]
        public void two_pairs_wins_other()
        {
            // ぃ礟 ゑ耕
            ResultSholdBe("Black: 2H 3D TS TC KD  White: 9D 3H 3C 9S AH",
                        "White wins. - with two pairs: 9 over 3");

            // ぃ礟 ゑ耕 絋粄疭 output
            ResultSholdBe("Black: KH 3D TS TC KD  White: 9D 3H AC 8S AH",
                        "Black wins. - with two pairs: King over 10");
        }

        [Test]
        [Category("two pair")]
        [Category("same category")]
        public void both_two_pairs()
        {
            // 1st pair decided winner
            ResultSholdBe("Black: KH 4D 4S TC KD  White: 9D 8H 8C 9S AH",
                        "Black wins. - with two pairs: King");

            // 2nd pair decided winner
            ResultSholdBe("Black: KH 4D 4S TC KD  White: KC 8H 8C 9S KS",
                        "White wins. - with two pairs: 8");

            // tie
            ResultSholdBe("Black: KH 4D 4S TC KD  White: KD 4H 4C TS KH",
                        "Tie.");
        }

        [Test]
        [Category("three of a kind")]
        [Category("different category")]
        public void three_of_a_kind_win_others()
        {
            ResultSholdBe("Black: KH 3D TS TC KD  White: 9D 3H 9C 9S AH",
                        "White wins. - with three of a kind: 9");
        }

        [Test]
        [Category("three of a kind")]
        [Category("same category")]
        public void both_three_of_a_kind()
        {
            // win by three of a kind
            ResultSholdBe("Black: KH 4D 4S TC 4D  White: 9D 8H 8C 8S AH",
                        "White wins. - with three of a kind: 8");

            // win by other card
            ResultSholdBe("Black: KH 4D 4S TC 4D  White: 9D 4H 4C 4S TH",
                        "Black wins. - with three of a kind: King");

            // tie
            ResultSholdBe("Black: KH 4D 4S TC 4D  White: KD 4H 4C 4S TH",
                        "Tie.");
        }

        [Test]
        [Category("straight")]
        [Category("differeny category")]
        public void straight_win_others()
        {
            // 2~9
            ResultSholdBe("Black: 2H 3D 6S 5C 4D  White: 9D 3H 9C 9S AH",
                        "Black wins. - with straight: 6");
        }

        private void ResultSholdBe(string input, string expected)
        {
            var showResult = _game.ShowResult(input);
            showResult.Should().Be(expected);
        }
    }
}
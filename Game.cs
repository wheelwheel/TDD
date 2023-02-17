namespace TDD
{
    public class Game
    {
        public string ShowResult(string input)
        {
            var players = new Parser().Parse(input);

            var pokerHands1 = players[0].GetPokerHands();
            var pokerHands2 = players[1].GetPokerHands();

            var enumerator1 = pokerHands1.GetEnumerator();
            var enumerator2 = pokerHands2.GetEnumerator();

            while (enumerator1.MoveNext() && enumerator2.MoveNext())
            {
                var currentCard1 = enumerator1.Current;
                var currentCard2 = enumerator2.Current;

                var compareResult = currentCard1.Value - currentCard2.Value;

                if (compareResult != 0)
                {
                    string winnerPlayer;
                    string winnerOutput;
                    if (compareResult < 0)
                    {
                        winnerPlayer = players[1].Name;
                        winnerOutput = currentCard2.Output;
                    }
                    else
                    {
                        winnerPlayer = players[0].Name;
                        winnerOutput = currentCard1.Output;
                    }

                    return $"{winnerPlayer} wins. - with high card: {winnerOutput}";
                }
            }

            return "Tie.";
        }
    }
}
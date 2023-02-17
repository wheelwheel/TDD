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

            var compareResult = 0;
            string winnerOutput = null;
            while (enumerator1.MoveNext() && enumerator2.MoveNext())
            {
                var currentCard1 = enumerator1.Current;
                var currentCard2 = enumerator2.Current;

                compareResult = currentCard1.Value - currentCard2.Value;
                if (compareResult != 0)
                {
                    winnerOutput = compareResult < 0 ? currentCard2.Output: currentCard1.Output;
                    break;
                }
            }

            if (compareResult != 0)
            {
                var winnerPlayer = compareResult < 0 ? players[1].Name : players[0].Name;
                return $"{winnerPlayer} wins. - with high card: {winnerOutput}";
            }

            return "Tie.";
        }
    }
}
namespace TDD
{
    public class HighCardComparer
    {
        public int Compare(IEnumerable<Card> pokerHands1, IEnumerable<Card> pokerHands2, out string winnerOutput)
        {
            var enumerator1 = pokerHands1.GetEnumerator();
            var enumerator2 = pokerHands2.GetEnumerator();

            var compareResult = 0;
            winnerOutput = null;
            while (enumerator1.MoveNext() && enumerator2.MoveNext())
            {
                var currentCard1 = enumerator1.Current;
                var currentCard2 = enumerator2.Current;

                compareResult = currentCard1.Value - currentCard2.Value;
                if (compareResult != 0)
                {
                    winnerOutput = compareResult < 0 ? currentCard2.Output : currentCard1.Output;
                    break;
                }
            }

            return compareResult;
        }
    }

    public class Game 
    {
        private readonly HighCardComparer _highCardComparer = new HighCardComparer();

        public string ShowResult(string input)
        {
            var players = new Parser().Parse(input);

            var pokerHands1 = players[0].GetPokerHands();
            var pokerHands2 = players[1].GetPokerHands();

            var compareResult = _highCardComparer.Compare(pokerHands1, pokerHands2, out var winnerOutput);

            if (compareResult != 0)
            {
                var winnerPlayer = compareResult < 0 ? players[1].Name : players[0].Name;
                return $"{winnerPlayer} wins. - with high card: {winnerOutput}";
            }

            return "Tie.";
        }
    }
}
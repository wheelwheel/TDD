namespace TDD.Comparers
{
    internal class PairCpmaprer : IPokerHandsComparer
    {
        public string WinnerOutput { get; private set; }
        public string WinnerCategory => "pair";

        public int Compare(PokerHands pokerHands1, PokerHands pokerHands2)
        {
            var firstCardOfEachGroup1 = GetFirstCardOfEachGroup(pokerHands1);
            var firstCardOfEachGroup2 = pokerHands2.GroupBy(x => x.Value)
                                                   .OrderByDescending(x => x.Count())
                                                   .Select(x => x.First());

            var highCardComparer = new HighCardComparer();
            var compareResult = highCardComparer.CompareCardsByValue(firstCardOfEachGroup1, firstCardOfEachGroup2);
            WinnerOutput = highCardComparer.WinnerOutput;

            return compareResult;
        }

        private static IEnumerable<Card> GetFirstCardOfEachGroup(PokerHands pokerHands)
        {
            return pokerHands.GroupBy(x => x.Value)
                             .OrderByDescending(x => x.Count())
                             .Select(x => x.First());
        }
    }
}
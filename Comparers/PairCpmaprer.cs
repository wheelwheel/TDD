namespace TDD.Comparers
{
    internal class PairCpmaprer : IPokerHandsComparer
    {
        public string WinnerOutput { get; private set; }
        public string WinnerCategory => "pair";

        public int Compare(PokerHands pokerHands1, PokerHands pokerHands2)
        {
            var pairs1 = pokerHands1.GroupBy(x => x.Value).Where(x => x.Count() == 2);
            var pairs2 = pokerHands2.GroupBy(x => x.Value).Where(x => x.Count() == 2);

            var compareResult = pairs1.First().First().Value - pairs2.First().First().Value;
            WinnerOutput = compareResult > 0 ? pairs1.First().First().Output : pairs2.First().First().Output;

            return compareResult;
        }
    }
}
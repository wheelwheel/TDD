namespace TDD.Comparers
{
    public abstract class SameCategoryComparer : IPokerHandsComparer
    {
        public string WinnerOutput { get; private set; }

        public abstract string WinnerCategory { get; }

        public abstract int Compare(PokerHands pokerHands1, PokerHands pokerHands2);

        protected int CompareCardsByValue(IEnumerable<Card> cards1, IEnumerable<Card> cards2)
        {
            var enumerator1 = cards1.GetEnumerator();
            var enumerator2 = cards2.GetEnumerator();

            var compareResult = 0;
            while (enumerator1.MoveNext() && enumerator2.MoveNext())
            {
                var currentCard1 = enumerator1.Current;
                var currentCard2 = enumerator2.Current;

                compareResult = currentCard1.Value - currentCard2.Value;
                if (compareResult != 0)
                {
                    WinnerOutput = compareResult < 0 ? currentCard2.Output : currentCard1.Output;
                    break;
                }
            }

            return compareResult;
        }
    }
}
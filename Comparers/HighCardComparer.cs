﻿namespace TDD.Comparers
{
    public class HighCardComparer : IPokerHandsComparer
    {
        public string WinnerOutput { get; private set; }
        public string WinnerCategory => "high card";

        public int Compare(PokerHands pokerHands1, PokerHands pokerHands2)
        {
            return CompareCardsByValue(pokerHands1, pokerHands2);
        }

        public int CompareCardsByValue(IEnumerable<Card> pokerHands1, IEnumerable<Card> pokerHands2)
        {
            var enumerator1 = pokerHands1.GetEnumerator();
            var enumerator2 = pokerHands2.GetEnumerator();

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
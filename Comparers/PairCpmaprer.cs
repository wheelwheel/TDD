namespace TDD.Comparers
{
    internal class PairComparer : SameCategoryComparer
    {
        public override string WinnerCategory => "pair";

        public override int Compare(PokerHands pokerHands1, PokerHands pokerHands2)
        {
            var firstCardOfEachGroup1 = pokerHands1.GetFirstCardOfEachGroup();
            var firstCardOfEachGroup2 = pokerHands2.GetFirstCardOfEachGroup();

            return CompareCardsByValue(firstCardOfEachGroup1, firstCardOfEachGroup2);
        }
    }
}
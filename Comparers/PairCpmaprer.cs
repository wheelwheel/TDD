namespace TDD.Comparers
{
    internal class PairComparer : SameCategoryComparer
    {
        public override string WinnerCategory => "pair";

        public override int Compare(PokerHands pokerHands1, PokerHands pokerHands2)
        {
            return CompareCardsByValue(pokerHands1.GetFirstCardOfEachGroup(), pokerHands2.GetFirstCardOfEachGroup());
        }
    }
}
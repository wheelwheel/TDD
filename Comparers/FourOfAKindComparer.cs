namespace TDD.Comparers
{
    internal class FourOfAKindComparer : SameCategoryComparer
    {
        public override string WinnerCategory => "four of a kind";

        public override int Compare(PokerHands pokerHands1, PokerHands pokerHands2)
        {
            return CompareCardsByValue(pokerHands1.GetFirstCardOfEachGroup(), pokerHands2.GetFirstCardOfEachGroup());
        }
    }
}
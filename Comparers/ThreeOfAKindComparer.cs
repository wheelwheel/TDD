namespace TDD.Comparers
{
    internal class ThreeOfAKindComparer : SameCategoryComparer
    {
        public override string WinnerCategory => "three of a kind";

        public override int Compare(PokerHands pokerHands1, PokerHands pokerHands2)
        {
            return CompareCardsByValue(pokerHands1.GetFirstCardOfEachGroup(), pokerHands2.GetFirstCardOfEachGroup());
        }
    }
}
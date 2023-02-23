namespace TDD.Comparers
{
    internal class TwoPairsComparer : SameCategoryComparer
    {
        public override string WinnerCategory => "two pairs";

        public override int Compare(PokerHands pokerHands1, PokerHands pokerHands2)
        {
            return CompareCardsByValue(pokerHands1.GetFirstCardOfEachGroup(), pokerHands2.GetFirstCardOfEachGroup());
        }
    }
}
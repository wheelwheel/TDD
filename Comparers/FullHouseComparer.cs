namespace TDD.Comparers
{
    internal class FullHouseComparer : SameCategoryComparer
    {
        public override string WinnerCategory => "full house";

        public override int Compare(PokerHands pokerHands1, PokerHands pokerHands2)
        {
            return CompareCardsByValue(pokerHands1.GetFirstCardOfEachGroup(), pokerHands2.GetFirstCardOfEachGroup());
        }
    }
}
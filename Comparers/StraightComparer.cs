namespace TDD.Comparers
{
    internal class StraightComparer : SameCategoryComparer
    {
        public override string WinnerCategory => "straight";

        public override int Compare(PokerHands pokerHands1, PokerHands pokerHands2)
        {
            return CompareCardsByValue(pokerHands1, pokerHands2);
        }
    }
}
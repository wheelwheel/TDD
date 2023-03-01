namespace TDD.Comparers
{
    internal class StraightFlushComparer : SameCategoryComparer
    {
        public override string WinnerCategory => "straight flush";

        public override int Compare(PokerHands pokerHands1, PokerHands pokerHands2)
        {
            return CompareCardsByValue(pokerHands1, pokerHands2);
        }
    }
}
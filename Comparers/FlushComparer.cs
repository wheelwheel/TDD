namespace TDD.Comparers
{
    internal class FlushComparer : SameCategoryComparer
    {
        public override string WinnerCategory => "flush";

        public override int Compare(PokerHands pokerHands1, PokerHands pokerHands2)
        {
            return CompareCardsByValue(pokerHands1, pokerHands2);
        }
    }
}
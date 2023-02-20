namespace TDD.Comparers
{

    public class HighCardComparer : SameCategoryComparer
    {
        public override string WinnerCategory => "high card";

        public override int Compare(PokerHands pokerHands1, PokerHands pokerHands2)
        {
            return CompareCardsByValue(pokerHands1, pokerHands2);
        }
    }
}
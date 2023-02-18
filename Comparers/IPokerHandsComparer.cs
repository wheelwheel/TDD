namespace TDD.Comparers
{
    public interface IPokerHandsComparer
    {
        string WinnerCategory { get; }
        string WinnerOutput { get; }

        int Compare(PokerHands pokerHands1, PokerHands pokerHands2);
    }
}
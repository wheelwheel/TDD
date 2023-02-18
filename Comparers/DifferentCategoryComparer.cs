namespace TDD.Comparers
{
    public interface IPokerHandsComparer
    {
        string WinnerCategory { get; }
        string WinnerOutput { get; }

        int Compare(PokerHands pokerHands1, PokerHands pokerHands2);
    }

    public class DifferentCategoryComparer : IPokerHandsComparer
    {
        public string WinnerCategory { get; private set; }
        public string WinnerOutput { get; private set; }

        public int Compare(PokerHands pokerHands1, PokerHands pokerHands2)
        {
            var category1 = pokerHands1.GetCategory();
            var category2 = pokerHands2.GetCategory();
            var compareResult = category1.Type - category2.Type;
            if (category1.Type > category2.Type)
            {
                WinnerCategory = category1.Name;
                WinnerOutput = category1.Output;
            }
            else
            {
                WinnerCategory = category2.Name;
                WinnerOutput = category2.Output;
            }

            return compareResult;
        }
    }
}
using TDD.Categories;

namespace TDD.Comparers
{
    public class DifferentCategoryComparer
    {
        public string WinnerCategory { get; private set; }
        public string WinnerOutput { get; private set; }

        public int Compare(Category category1, Category category2)
        {
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
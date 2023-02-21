using TDD.Categories;

namespace TDD.CategoryMatchers
{
    public abstract class CategoryMatcher
    {
        private readonly PairMatcher _nextCategoryMatcher;

        protected CategoryMatcher(PairMatcher nextCategoryMatcher)
        {
            _nextCategoryMatcher = nextCategoryMatcher;
        }

        public Category DecidedCategory(PokerHands pokerHands)
        {
            if (IsMatched(pokerHands))
            {
                return GetMatchedCategory(pokerHands);
            }

            var dicidedCategory = _nextCategoryMatcher != null
                ? _nextCategoryMatcher.DecidedCategory(pokerHands)
                : new HighCard();
            return dicidedCategory;

        }

        protected abstract Category GetMatchedCategory(PokerHands pokerHands);
        protected abstract bool IsMatched(PokerHands pokerHands);
    }
}
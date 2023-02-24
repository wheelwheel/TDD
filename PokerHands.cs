﻿using System.Collections;
using TDD.Categories;
using TDD.CategoryMatchers;

namespace TDD
{
    public class PokerHands : IEnumerable<Card>
    {
        private readonly IEnumerable<Card> _cards;
        private readonly CategoryMatcher _categoryMatcher;

        public PokerHands(IEnumerable<Card> cards)
        {
            _cards = cards;
            _categoryMatcher = new ThreeOfAKindMatcher(new TwoPairsMatcher(new PairMatcher(null)));
        }

        public IEnumerator<Card> GetEnumerator()
        {
            return _cards.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Category GetCategory()
        {
            return _categoryMatcher.DecidedCategory(this);
        }

        public IEnumerable<Card> GetFirstCardOfEachGroup()
        {
            return this.GroupBy(x => x.Value)
                       .OrderByDescending(x => x.Count())
                       .Select(x => x.First());
        }

        public IEnumerable<IGrouping<int, Card>> GetPairs()
        {
            return this.GroupBy(x => x.Value).Where(x => x.Count() == 2);
        }

        public bool IsTwoPairs()
        {
            return GetPairs().Count() == 2;
        }

       public bool IsPair()
        {
            return GetPairs().Any();
        }
    }

    public class ThreeOfAKindMatcher : CategoryMatcher
    {
        public ThreeOfAKindMatcher(CategoryMatcher nextCategoryMatcher) : base(nextCategoryMatcher)
        {
        }

        protected override Category GetMatchedCategory(PokerHands pokerHands)
        {
            return new ThreeOfAKind() { Output = GetThreeOfAKind(pokerHands).First().First().Output};
        }

        protected override bool IsMatched(PokerHands pokerHands)
        {
            IEnumerable<IGrouping<int, Card>> threeOfAKind = GetThreeOfAKind(pokerHands);

            return threeOfAKind.Any();
        }

        private static IEnumerable<IGrouping<int, Card>> GetThreeOfAKind(PokerHands pokerHands)
        {
            return pokerHands.GroupBy(x => x.Value).Where(x => x.Count() == 3);
        }
    }

    public class ThreeOfAKind : Category
    {
        public override CategoryType Type => CategoryType.ThreeOfAKind;

        public override string Name => "three of a kind";
    }
}
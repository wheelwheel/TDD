﻿using System.Collections;
using TDD.Categories;

namespace TDD
{
    public class TwoPairsMatcher
    {
        public TwoPairsMatcher()
        {
        }
        
        public Category DecidedCategory(PokerHands pokerHands)
        {
            if (IsMatchedTwoPairs(pokerHands))
            {
                var biggerPair = pokerHands.GetPairs().First().First().Output;
                var smallerPair = pokerHands.GetPairs().Last().First().Output;
                return new TwoPairs { Output = $"{biggerPair} over {smallerPair}" };
            }
            else
            {
                return NextMatch(pokerHands);
            }
        }

        private static bool IsMatchedPair(PokerHands pokerHands)
        {
            return pokerHands.GetPairs().Any();
        }

        private static bool IsMatchedTwoPairs(PokerHands pokerHands)
        {
            return pokerHands.GetPairs().Count() == 2;
        }

        private Category NextMatch(PokerHands pokerHands)   
        {
            if (IsMatchedPair(pokerHands))
            {
                return new Pair { Output = pokerHands.GetPairs().First().First().Output };
            }
            return new HighCard();
        }
    }

    public class PokerHands : IEnumerable<Card>
    {
        private readonly IEnumerable<Card> _cards;
        private readonly TwoPairsMatcher _twoPairsMatcher;

        public PokerHands(IEnumerable<Card> cards)
        {
            _cards = cards;
            _twoPairsMatcher = new TwoPairsMatcher();
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
            return _twoPairsMatcher.DecidedCategory(this);
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
    }
}
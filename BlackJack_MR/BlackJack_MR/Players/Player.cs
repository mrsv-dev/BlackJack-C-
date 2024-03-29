﻿using BlackJack_MR.Common;
using System.Collections.Generic;
using System.Text;

namespace BlackJack_MR.Players
{
    public class Player
    {
        private List<Card> hand = new List<Card>();
        private int myScore;

        public bool Busted { get; set; }

        public Player()
        {
            Busted = false;
        }

        public void HitMe(Card dealtCard)
        {
            hand.Add(dealtCard);
        }

        public List<Card> ShowHand()
        {
            return hand;
        }

        public Card LastCard()
        {
            return hand[hand.Count - 1];
        }

        public string ShoutHand()
        {
            StringBuilder handString = new StringBuilder();
            foreach (Card card in hand)
            {
                handString.AppendLine(card.Suit.ToString() + ' ' + card.Value.ToString());
            }
            return handString.ToString();
        }

        public int GetScore()
        {
            myScore = 0;
            for (int i = 0; i < hand.Count; i++)
            {
                if ((int)hand[i].Value < 10)
                {
                    myScore += (int)hand[i].Value;
                }
                else
                {
                    myScore += 10;
                }
            }

            if (hand.Count == 2 && ((hand[0].Value == CardValue.Ace && (int)hand[1].Value >= 10) || (hand[1].Value == CardValue.Ace && (int)hand[0].Value >= 10)))
            {
                return 21;
            }

            if (myScore > 21)
            {
                Busted = true;
            }

            return myScore;
        }

        public void ThrowCards()
        {
            hand.Clear();
            Busted = false;
        }
    }
}

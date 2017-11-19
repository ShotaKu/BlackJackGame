using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace BlackJackClass
{
    public class Card
    {
        private int number;
        public enum Suit { Spades, Heart, Club, Diamond }
        private Suit suit;

        public Card() { }
        public Card(int number, Suit format)
        {
            this.number = number;
            suit = format;
        }
        public Card(int number, int format)
        {
            this.number = number;
            suit = getFormatByNumber(format);
        }
        public Card(string stringCard)
        {
            stringCard = stringCard.Replace("[", "");
            stringCard = stringCard.Replace("]", "");
            string[] format = stringCard.Split(':');
            suit = GetFormatByString(format[0]);
            number = int.Parse(format[1]);
        }
        public static Suit GetFormatByString(string format)
        {
            Suit f = Suit.Club;
            if (Suit.Spades.ToString() == format)
                f = Suit.Spades;
            else if (Suit.Diamond.ToString() == format)
                f = Suit.Diamond;
            else if (Suit.Heart.ToString() == format)
                f = Suit.Heart;
            else if (format != Suit.Club.ToString())
                Debug.LogError("Invarid Format = "+format);
            return f;
        }
        public int getNumber()
        { return number; }

        public string getNumberByString()
        {
            //char number = cardNubmer.ToString()[0];
            string number = this.number.ToString();
            //Debug.Log(cardNubmer.ToString()+" "+number.ToString());
            if (this.number == 1)
                number = "A";
            else if (this.number == 11)
                number = "J";
            else if (this.number == 12)
                number = "Q";
            else if (this.number == 13)
                number = "K";

            return number;
        }

        public Suit getFormats()
        { return suit; }

        /// <summary>
        /// Return card format by input number. 0 = Spades, 1 = Harts, 2 = Clubs, 3 = Diamonds
        /// </summary>
        /// <param name="formatNumber">Digit 0 - 4</param>
        /// <returns></returns>
        public Suit getFormatByNumber(int formatNumber)
        {
            Suit f = Suit.Spades;
            if (formatNumber == 1)
                f = Suit.Heart;
            else if (formatNumber == 2)
                f = Suit.Club;
            else if (formatNumber == 3)
                f = Suit.Diamond;

            return f;
        }

        public static string[] CardsToString(Card[] hand)
        {
            string[] cards = new string[hand.Length];

            int i = 0;
            foreach (Card card in hand)
            {
                cards[i] = card.ToString();
                i++;
            }
            return cards;
        }
        public static Card[] StringToCards(string[] hand)
        {
            Card[] cards = new Card[hand.Length];

            int i = 0;
            foreach (string card in hand)
            {
                cards[i] = new Card(card);
                i++;
            }
            return cards;
        }

        public override string ToString()
        {
            return "["+suit+":"+number+"]";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace BlackJackClass
{
    public class Card
    {
        private int cardNubmer;
        public enum Formats { Spades, Heart, Club, Diamond }
        private Formats cardFormats;

        public Card() { }
        public Card(int number, Formats format)
        {
            cardNubmer = number;
            cardFormats = format;
        }
        public Card(int number, int format)
        {
            cardNubmer = number;
            cardFormats = getFormatByNumber(format);
        }

        public int getNumber()
        { return cardNubmer; }

        public string getNumberByString()
        {
            //char number = cardNubmer.ToString()[0];
            string number = cardNubmer.ToString();
            //Debug.Log(cardNubmer.ToString()+" "+number.ToString());
            if (cardNubmer == 1)
                number = "A";
            else if (cardNubmer == 11)
                number = "J";
            else if (cardNubmer == 12)
                number = "Q";
            else if (cardNubmer == 13)
                number = "K";

            return number;
        }

        public Formats getFormats()
        { return cardFormats; }

        /// <summary>
        /// Return card format by input number. 0 = Spades, 1 = Harts, 2 = Clubs, 3 = Diamonds
        /// </summary>
        /// <param name="formatNumber">Digit 0 - 4</param>
        /// <returns></returns>
        public Formats getFormatByNumber(int formatNumber)
        {
            Formats f = Formats.Spades;
            if (formatNumber == 1)
                f = Formats.Heart;
            else if (formatNumber == 2)
                f = Formats.Club;
            else if (formatNumber == 3)
                f = Formats.Diamond;

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

        public override string ToString()
        {
            return "["+cardFormats+":"+cardNubmer+"]";
        }
    }
}

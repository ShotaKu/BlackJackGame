using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BlackJackClass
{
    /// <summary>
    /// Responsiblity : Keep status of Player (Both of Dealer and player)
    /// - Fields:
    ///     - name(string) : Name of user
    ///     - money(int) : total money of user
    ///     - bet(int) : number of money that player bet for each game
    ///     - isDealer(boolean) : is this player is dealer or not (using in vs computer mode)
    ///     - hands (List of Card) : Cards of player hands
    ///     - 
    /// </summary>
    public class Player
    {
        private long id;
        private string name;
        private int money;
        private int bet;
        private bool isDealer;
        private List<Card> hands = new List<Card>();

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        // private LoadCardMaterial playerHand = null;     //Should not at here

        public Player() { }
        public Player(string n, int m,bool dealer = false, LoadCardMaterial ph = null)
        {
            name = n;
            money = m;
            isDealer = dealer;
            //playerHand = ph;
            bet = 1000;
        }
        
        //public void setPlayerHand(LoadCardMaterial ph)      //Should not be here
        //{ playerHand = ph; }

        public bool setBet(int b)
        {
            if ((1000 <= bet) && (bet <= money))
            {
                bet = b;
                return true;
            }
            return false;
        }

        public int getBet()
        { return bet; }
        /*public bool isWon(Player dealer)
        {
            return (dealer.getHandTotal() < getHandTotal());
        }*/

        public string getName()
        { return name; }
        public void setName(string name)
        { this.name=name; }

        public void addHand(params Card[] cards)
        {
            foreach (Card card in cards)
            {
                hands.Add(card);
            }
        }

        public void lose()          //Should not be here (change to be reduceMoney)
        { money = (bet <= money) ? (money - bet) : 0; }

        public void won()           // Should not be here (Change to be addMoney)
        { money += bet; }

        /// <summary>
        /// Only dealer can use this method. Dealer can get player bet if the dealer won
        /// </summary>
        /// <param name="playerBet">Player's bet of that game</param>
        // TODO: Should not be here. (Add this to Vs computer or black jack)
        public int won(int playerBet)       
        {
            if(isDealer)
                money += playerBet;
            return money;
        }

        public int lose(int playerBet)      //Should not be here? (Check this player is dealer or not at black jack)
        {
            if(isDealer)
                money = (playerBet <= money) ? (money - playerBet) : 0;
            return money;
        }

        public List<Card> getHand()
        { return hands; }

        public List<Card> getSortedHand()
        { return hands.OrderByDescending(h => h.getNumber()).ToList(); }

        public int getHandTotal()
        {
            int total = 0;
            Card[] temp = hands.OrderByDescending(h => h.getNumber()).ToArray();
                        /*(from c in hands
                           orderby c.getNubmer()
                           select c).ToArray();*/
            foreach (Card c in temp)
            {

                if (c.getNumber() == 1)
                {
                    if (BlackJack.isBust(total + 11))
                        total += 1;
                    else
                        total += 11;
                }
                else if (11 <= c.getNumber())
                {
                    total += 10;
                }
                else
                    total += c.getNumber();
            }
            return total;
        }

        public int getFirstCard()
        {
            int card = 0;
            if (hands.Count == 0)
                Debug.LogError("Player \"" + name + "\" hand is zero!!");
            else                                                                                //Should not be here?
            {
                //card = (hands[0].getNumber() == 1) ? 11 : hands[0].getNumber();
                card = hands[0].getNumber();
                if (card == 1)
                { }
            }

            return card;
        }

        public bool isBust()                                                        //Should not be here
        { return 21 < getHandTotal(); }

        public void setMoney(int m)
        { money = m;}
        public int getMoney()
        { return money; }

        public override string ToString()
        {
            string hand = "";
            foreach (Card c in hands)
                hand += (c.ToString() + " ");
            return name + " : " + hand;
        }
        //public void openAllCards()                                          //Should no be here
        //{ playerHand.openAllCard(); }

        public void clearHand()
        { hands.Clear(); }

        public Card[] GetHand()
        {
            return hands.ToArray(); ;
        }

    }
}

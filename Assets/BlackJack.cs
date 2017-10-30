using System.Collections.Generic;

namespace BlackJackClass
{
    public class BlackJack
    {
        private Card[] Deck = new Card[52];
        private int topCard;

        public enum Result {Win, Lose, Draw};

        private Card[] getDeck()
        {
            Card[] deck = new Card[52];

            int deckIndex = 0;
            int format = 0;
            while (format < 4)
            {
                int numbers = 1;
                while (numbers <= 13)
                {
                    deck[deckIndex] = new Card(numbers,format);
                    numbers++;
                    deckIndex++;
                }
                format++;
            }
            return deck;
        }

        public BlackJack()
        {
            Deck = getDeck();
            shaffleDeck();      //reset topCard
        }

        private void shaffleDeck()
        {
            System.Random rng = new System.Random();
            topCard = 0;
            
            int n = Deck.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card tmp = Deck[k];
                Deck[k] = Deck[n];
                Deck[n] = tmp;
            }
        }

        public Card DrawCard(ref Player player)
        {
            Card c = Deck[topCard];
            player.addHand(c);
            topCard++;
            return c;
        }

        public Card DrawCard()
        {
            Card c = Deck[topCard];
            topCard++;
            return c;
        }

        public static int GetPlayerHandScore(Player player)
        {
            List<Card> hand = player.getSortedHand();
            int numberOfOne = 0;

            int score = 0;
            foreach (Card c in hand)
            {
                int num = c.getNumber();
                if (11 <= num)
                    num = 10;
                if (num == 1)
                {
                    numberOfOne++;
                }
            }

            return score;
        }

        public static Result Stand(ref Player dealer, ref Player player)
        {
            Result result = Result.Draw;
            if (isBust(dealer.getHandTotal()) || isBust(player.getHandTotal()))     //Some player is bust
            {
                if (isBust(dealer.getHandTotal()) && isBust(player.getHandTotal()))     //Both of them bust!
                    result = Result.Draw;
                else if (isBust(dealer.getHandTotal()))         //Dealer Bust
                {
                    player.won();
                    dealer.lose(player.getBet());
                    result = Result.Win;
                }
                else                    //Player Bust
                {
                    dealer.won(player.getBet());
                    player.lose();
                    result = Result.Lose;
                }
            }
            else            //Nobady bust
            {

                if (player.getHandTotal() < dealer.getHandTotal())      //Dealer win
                {
                    dealer.won(player.getBet());
                    player.lose();
                    result = Result.Lose;
                }

                else if (dealer.getHandTotal() < player.getHandTotal())     //Player win
                {
                    player.won();
                    dealer.lose(player.getBet());
                    result = Result.Win;
                }
                else                                                        //Draw
                {
                    result = Result.Draw;
                }
            }
            player.clearHand();
            dealer.clearHand();

            return result;
                
        }

        public static bool isBust(int totalCard)
        { return totalCard > 21; }

        public bool canHit(int playerScore)
        { return !isBust(playerScore); }

        
    }
}

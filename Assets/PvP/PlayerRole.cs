using BlackJackClass;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRole : MonoBehaviour {

    public static PlayerRole _PvP;
    public string playersRole = "";

    private long gameID = -1;
    private Player Player;
    private Player Dealer;
    private BlackJack game;

    public long GameID
    {
        get { return gameID; }
        set { gameID = value; }
    }

    void Awake()
    {
        _PvP = this;

    }
    public int getPlayerMoney()
    {
        return Player.getMoney();
    }

    public void GetPlayerHand()
    {

    }
    public void SetPlayerHandForDisplay(string[] cardsStr)
    {
        Card[] cards = Card.StringToCards(cardsStr);
        Player.addHand(cards);
        GameItemsController.AddPlayerHandForDisplay(false, cards);
    }

    public void SetOpponentHandForDisplay(string[] cardsStr)
    {
        Card[] cards = Card.StringToCards(cardsStr);
        Dealer.addHand(cards);
        GameItemsController.AddOpponentHandForDisplay(true, cards);
    }

    public void Stand()
    {

    }
    

    public void updateMoney()
    {
        int playerMoney = Player.getMoney();
        int dealerMoney = Dealer.getMoney();

        PlayerPerfController perfCon = new PlayerPerfController();
        perfCon.updateMoney(playerMoney);
    }
    public void displayMoney()
    {
        int playerMoney = Player.getMoney();
        int dealerMoney = Dealer.getMoney();

    }

    public void DealerHit()
    {
        
    }

    public void setPlayerBet(int bet)
    { Player.setBet(bet); }

    public static PlayerRole getThisBattle()
    { return _PvP; }
    
    private string getScoreText(Player target)
    {
        string newScore = "**";
        if (target.isBust())
            newScore = "<color=red>" + newScore + "</color>";
        return newScore.Replace("**", target.getHandTotal() + " / 21");
    }
    private string getScoreText(int score)
    {
        return score + " / 21";
    }

    /// <summary>
    /// Add new card to player's hand
    /// </summary>
    /// <returns>return True if player can hit more (not bust yet)</returns>
    public void PlayerHit()
    {
        //TODO: Player hit request to database
    }

    public bool canPlayerHit()
    { return !Player.isBust(); }
    public bool canDealerHit()
    { return !Dealer.isBust(); }

    public Player getPlayer()
    { return Player; }
    
}

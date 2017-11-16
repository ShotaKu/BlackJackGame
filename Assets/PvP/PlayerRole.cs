using BlackJackClass;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRole : MonoBehaviour {

    //[SerializeField]
    private LoadCardMaterial DealerCards = null;
    //[SerializeField]
    private LoadCardMaterial PlayerCards = null;

    [SerializeField]
    private Text PlayerScore = null;
    [SerializeField]
    private Text DealerScore = null;
    [SerializeField]
    private Text PlayerMoney = null;
    [SerializeField]
    private Text DealerMoney = null;

    [SerializeField]
    private ButtonUI ControllerUI = null;
    [SerializeField]
    private ButtonUI RetryUI = null;
    [SerializeField]
    private ButtonUI ChangeBetUI = null;

    [SerializeField]
    private Animator ResultAnimator = null;
    [SerializeField]
    private DeckAnimation DeckAnimator = null;

    [SerializeField]
    FireWorksMaker effect = null;
    BlackJack.Result resultGame = BlackJack.Result.Draw;

    public static PlayerRole _PvP;
    public string playersRole = "";
    private Player Player;
    private Player Dealer;
    private BlackJack game;

    void Start()
    {
        _PvP = this;
        DealerCards = Canvas.getObject("GameItems").FindChild("DealerCards").GetComponent<LoadCardMaterial>();
        PlayerCards = Canvas.getObject("GameItems").FindChild("MyCards").GetComponent<LoadCardMaterial>();
        //Score = Canvas.getObject("Score").GetComponent<Text>();

        print(DealerCards);

        PlayerPerfController perfCon = new PlayerPerfController();

        //Dealer = new Player("Dealer", 300000, true);
        //Player = perfCon.LoadPlayerInformation();

        displayMoney();

        //Dealer.setPlayerHand(DealerCards);
        //Player.setPlayerHand(PlayerCards);

        ControllerUI.setActiveUI(false);
        RetryUI.setActiveUI(false);
    }

    public void Deal()
    {
        ControllerUI.setActiveUI(true);
        RetryUI.setActiveUI(false);
        setActiveChangeBetUI(false);

        game = new BlackJack();

        //clearBothCards();

        //Player.addHand(game.DrawCard());
        //Dealer.addHand(game.DrawCard());
        //DeckAnimator.DrawBoth();


        //Player.addHand(game.DrawCard());
        //Dealer.addHand(game.DrawCard());
        //DeckAnimator.DrawBoth();

        PlayerHit();
        PlayerHit();

        showDealerFirstCardScore();
        updatePlayerScore();

        if (Player.isBust())
        {
            //print("Already Bust!!") ;
            Stand();
        }

    }

    public int getPlayerMoney()
    {
        return Player.getMoney();
    }

    public void clearBothCards()
    {
        DealerCards.clearCard();
        PlayerCards.clearCard();
    }

    public void GetPlayerHand()
    {

    }

    public void Stand()
    {
        while (DealerHit()) { }
        DealerCards.openAllCards();
        showDealerTotalScore();
        resultGame = BlackJack.Stand(ref Dealer, ref Player);

        switch (resultGame)
        {
            case BlackJack.Result.Win:
                ResultAnimator.Play("Win", 0, 0);
                effect.generateFireWorks();
                break;
            case BlackJack.Result.Lose:
                ResultAnimator.Play("Lose", 0, 0);
                break;
        }

        updateMoney();
        ControllerUI.setActiveUI(false);
        RetryUI.setActiveUI(true);

    }

    public BlackJack.Result getResultGame()
    { return resultGame; }
    public void resetResult()
    { resultGame = BlackJack.Result.Draw; }

    public void updateMoney()
    {
        int playerMoney = Player.getMoney();
        int dealerMoney = Dealer.getMoney();
        PlayerMoney.text = "Money: " + playerMoney;
        DealerMoney.text = "Money: " + dealerMoney;
        PlayerPerfController perfCon = new PlayerPerfController();
        perfCon.updateMoney(playerMoney);
    }
    public void displayMoney()
    {
        int playerMoney = Player.getMoney();
        int dealerMoney = Dealer.getMoney();
        PlayerMoney.text = "Money: " + playerMoney;
        DealerMoney.text = "Money: " + dealerMoney;
    }
    public Animator getAnmation()
    { return ResultAnimator; }

    public bool DealerHit()
    {
        if (Dealer.getHandTotal() <= 16)        //if hand is less than 11, dealer have to hit (Dealer rule)
        {
            Card card = game.DrawCard();
            Dealer.addHand(card);    //So, draw a card
            print(card);
            DealerCards.SetNewCard(true,card);
            DeckAnimator.DealerDraw();
            return canDealerHit();              //check dealer is bust or not
        }
        else
            return false;                       //never draw card!
    }

    public void setPlayerBet(int bet)
    { Player.setBet(bet); }

    public static PlayerRole getThisBattle()
    { return _PvP; }
    public void updatePlayerScore()
    { PlayerScore.text = getScoreText(Player); }
    public void showDealerFirstCardScore()
    { DealerScore.text = getScoreText(Dealer.getFirstCard()); }
    public void showDealerTotalScore()
    { DealerScore.text = getScoreText(Dealer); }
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
    public bool PlayerHit()
    {
        Card card = game.DrawCard();
        Player.addHand(card);
        PlayerCards.SetNewCard(false,card);
        DeckAnimator.PlayerDraw();
        updatePlayerScore();
        DealerHit();
        //if (isDealerHit)
        //
        //else

        return canPlayerHit();
    }

    public bool canPlayerHit()
    { return !Player.isBust(); }
    public bool canDealerHit()
    { return !Dealer.isBust(); }

    public Player getPlayer()
    { return Player; }

    public void setActiveChangeBetUI(bool isActive)
    {
        ChangeBetUI.setActiveUI(isActive);
    }
    public void setActiveRetryUI(bool isActive)
    {
        RetryUI.setActiveUI(isActive);
    }
}

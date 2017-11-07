using BlackJackClass;
using BlackJackGame.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Player is Dealer in this Class
/// </summary>
public class DealerRole : MonoBehaviour {

    private LoadCardMaterial OpponentCards = null;
    private LoadCardMaterial PlayerCards = null;

    private Text PlayerScore = null;
    private Text OpponentScore = null;
    private Text PlayerMoney = null;
    private Text OpponentMoney = null;

    private ButtonUI ControllerUI = null;
    private ButtonUI RetryUI = null;
    private ButtonUI ChangeBetUI = null;

    private Animator ResultAnimator = null;
    private DeckAnimation DeckAnimator = null;

    FireWorksMaker effect = null;
    BlackJack.Result resultGame = BlackJack.Result.Draw;

    public static DealerRole _PvP;
    public string playersRole = "";
    private Player Player;
    private Player Opponent;
    private BlackJack game;

    void Start()
    {
        _PvP = this;
        print("Loaded");
        OpponentCards = Canvas.getObject("GameItems").FindChild("DealerCards").GetComponent<LoadCardMaterial>();
        PlayerCards = Canvas.getObject("GameItems").FindChild("MyCards").GetComponent<LoadCardMaterial>();

        print(OpponentCards);

        PlayerPerfController perfCon = new PlayerPerfController();

        Opponent = new Player();
        Player = perfCon.LoadPlayerInformation();

        //displayMoney();

        //ControllerUI.setActiveUI(false);
        //RetryUI.setActiveUI(false);
    }
    public static bool isCreateGameSuccess = false;
    public void Deal()
    {

        //ControllerUI.setActiveUI(true);
        //RetryUI.setActiveUI(false);
        //setActiveChangeBetUI(false);

        game = new BlackJack();

        //PlayerHit();
        //PlayerHit();

        //showOpponentFirstCardScore();
        //updatePlayerScore();

        string[] OpponentHand = GetOpponentHand();
        CreateGame.CreateGameOnDB(transform.GetComponent<GetPost>(),GetPlayerHand(),Player.getHandTotal(),Player.getBet(),GetOpponentHand(),Opponent.getHandTotal(), response =>
        {
            GameResult result = ResponceFormBuilder.GetResult<GameResult>(response.text);
            if (0 <= result.ErrorCode)
            {

            }
            else
            {
                MessageWindow.setErrorMessage(result.Message);
                MessageWindow.setActive(true);
            }
            print("Start corutine");
            //CheckUntil checking = transform.GetComponent<CheckUntil>();
            //checking.CheckUntilGetResult(0.5f, 2, JoinChecker.CheckJoinStatus(), JoinChecker.Loaded(), JoinChecker.Timeout());

        });

        if (Player.isBust())
        {
            Stand();
        }

    }

    public string[] GetOpponentHand()
    {
        return Card.CardsToString(Opponent.GetHand());
    }

    public int getPlayerMoney()
    {
        return Player.getMoney();
    }

    public void clearBothCards()
    {
        OpponentCards.clearCard();
        PlayerCards.clearCard();
    }

    public string[] GetPlayerHand()
    {
        return Card.CardsToString(Player.GetHand());
    }

    public void Stand()
    {
        while (OpponentHit()) { }
        OpponentCards.openAllCards();
        showOpponentTotalScore();
        resultGame = BlackJack.Stand(ref Opponent, ref Player);

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
        int opponentMoney = Opponent.getMoney();
        PlayerMoney.text = "Money: " + playerMoney;
        OpponentMoney.text = "Money: " + opponentMoney;
        PlayerPerfController perfCon = new PlayerPerfController();
        perfCon.updateMoney(playerMoney);
    }
    public void displayMoney()
    {
        int playerMoney = Player.getMoney();
        int opponentMoney = Opponent.getMoney();
        PlayerMoney.text = "Money: " + playerMoney;
        OpponentMoney.text = "Money: " + opponentMoney;
    }
    public Animator getAnmation()
    { return ResultAnimator; }

    public bool OpponentHit()
    {
        if (Opponent.getHandTotal() <= 16)        //if hand is less than 11, Opponent have to hit (Opponent rule)
        {
            Card card = game.DrawCard();
            Opponent.addHand(card);    //So, draw a card
            print(card);
            OpponentCards.setCards(card, (Opponent.getHand().Count + 1), true);
            DeckAnimator.DealerDraw();
            return canOpponentHit();              //check Opponent is bust or not
        }
        else
            return false;                       //never draw card!
    }

    public void setPlayerBet(int bet)
    { Player.setBet(bet); }

    public static DealerRole getThisBattle()
    { return _PvP; }
    public void updatePlayerScore()
    { PlayerScore.text = getScoreText(Player); }
    public void showOpponentFirstCardScore()
    { OpponentScore.text = getScoreText(Opponent.getFirstCard()); }
    public void showOpponentTotalScore()
    { OpponentScore.text = getScoreText(Opponent); }
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
        PlayerCards.setCards(card, (Opponent.getHand().Count + 1), false);
        DeckAnimator.PlayerDraw();
        updatePlayerScore();
        OpponentHit();
        //if (isOpponentHit)
        //
        //else

        return canPlayerHit();
    }

    public bool canPlayerHit()
    { return !Player.isBust(); }
    public bool canOpponentHit()
    { return !Opponent.isBust(); }

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

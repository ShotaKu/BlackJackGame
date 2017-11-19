using BlackJackClass;
using BlackJackGame.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

/// <summary>
/// Player is Dealer in this Class
/// </summary>
public class DealerRole : MonoBehaviour {
    
    private GameItemsController items = null;

    FireWorksMaker effect = null;
    BlackJack.Result resultGame = BlackJack.Result.Draw;

    public static DealerRole _PvP;
    public string playersRole = "";
    private Player Player;
    private Player Opponent;
    private BlackJack game;
    private long gameID;
    private static string OpponentLastAction = "";

    void Start()
    {
        _PvP = this;
        print("Loaded");


        //print(OpponentCardchas);
        PlayerPerfController perfCon = new PlayerPerfController();

        Opponent = new Player();
        Player = perfCon.LoadPlayerInformation();
        GameItemsController.SetActiveControllerUI(false);
        GameItemsController.SetActiveRetryUI(false);


        //displayMoney();

        //ControllerUI.setActiveUI(false);
        //RetryUI.setActiveUI(false);
    }
    public static bool isCreateGameSuccess = false;
    public void Deal()
    {
        game = new BlackJack();

        OpponentHit(false);
        PlayerHit(false);
        OpponentHit(false);
        PlayerHit(false);

        string[] OpponentHand = GetOpponentHand();
        print(string.Join(",", GetOpponentHand()));
        string[] PlayerHand = GetPlayerHand();
        print(string.Join(",", GetPlayerHand()));
        CreateGame.CreateGameOnDB(transform.GetComponent<GetPost>(), GetPlayerHand(), Player.getHandTotal(), Player.getBet(), GetOpponentHand(), Opponent.getHandTotal(), response =>
        {
            print("Deal: Pass Create Game");
            GameResult result = ResponceFormBuilder.GetResult<GameResult>(response.text);
            if (0 <= result.ErrorCode)
            {
                gameID = result.GameID;
                print("Deal: No error. GameID = " + gameID);
                print("Start corutine");
                CheckUntil checking = transform.GetComponent<CheckUntil>();
                if (checking == null)
                    checking = gameObject.AddComponent<CheckUntil>();
                //checking.SetCheckingTime(15,5);
                checking.CheckUntilGetResult(10, 5, JoinChecker.CheckJoinStatus(gameObject, gameID), JoinChecker.CheckJoinLoaded(() => DisplayAllCardsAndInformation()), JoinChecker.CheckJoinTimeout());
                GameItemsController.SetRole("Dealer");
            }
            else
            {
                MessageWindow.setErrorMessage(result.Message);
                MessageWindow.setActive(true);
            }

            //displayAllcards();
        });

        if (Player.isBust())
        {
            Stand();
        }

    }
    void DisplayAllCardsAndInformation()
    {
        GameItemsController.AddPlayerHandForDisplay(false, Player.GetHand());
        GameItemsController.SetPlayerScoreForDisplay(Player.getHandTotal());
        GameItemsController.SetPlayerInformation(Player);
        GameItemsController.AddOpponentHandForDisplay(true,Opponent.GetHand());
        GameItemsController.SetOpponentScoreForDisplay(-1);
        GameItemsController.SetOpponentInformation(Opponent);
    }

    public string[] GetOpponentHand()
    {
        return Card.CardsToString(Opponent.GetHand());
    }

    public string[] GetPlayerHand()
    {
        return Card.CardsToString(Player.GetHand());
    }

    public void Stand()
    {
        while (OpponentHit()) { }
        //OpponentCards.openAllCards();
        //showOpponentTotalScore();
        resultGame = BlackJack.Stand(ref Opponent, ref Player);

        switch (resultGame)
        {
            case BlackJack.Result.Win:
                //ResultAnimator.Play("Win", 0, 0);
                effect.generateFireWorks();
                break;
            case BlackJack.Result.Lose:
                //ResultAnimator.Play("Lose", 0, 0);
                break;
        }

        updateMoney();
        //ControllerUI.setActiveUI(false);
        //RetryUI.setActiveUI(true);

    }

    public BlackJack.Result getResultGame()
    { return resultGame; }
    public void resetResult()
    { resultGame = BlackJack.Result.Draw; }

    private void updateMoney()
    {
        int playerMoney = Player.getMoney();
        int opponentMoney = Opponent.getMoney();
        //PlayerMoney.text = "Money: " + playerMoney;
        //OpponentMoney.text = "Money: " + opponentMoney;
        PlayerPerfController perfCon = new PlayerPerfController();
        perfCon.updateMoney(playerMoney);
    }

    public bool OpponentHit(bool withDisplay = false)
    {
        if (!Opponent.isBust())        
        {
            Card card = game.DrawCard();
            Opponent.addHand(card);    //So, draw a card
            if(withDisplay)
                GameItemsController.AddOpponentHandForDisplay(true,card);
            print(card);
            
        }
        return Opponent.isBust();
    }
    public void PassCard()
    {
        //TODO: Check until card success
    }
    public static DealerRole getThisBattle()
    { return _PvP; }
    private void setOpponentNameAndID(string name, long id)
    {
        Opponent.setName(name);
        Opponent.Id = id;
    }
    private string getScoreText(Player target)
    {
        string newScore = "**";
        if (target.isBust())
            newScore = "<color=red>" + newScore + "</color>";
        return newScore.Replace("**", target.getHandTotal() + " / 21");
    }

    /// <summary>
    /// Add new card to player's hand
    /// </summary>
    /// <returns>return True if player can hit more (not bust yet)</returns>
    public void PlayerHit(bool withDisplay = false)
    {
        Card card = game.DrawCard();
        Player.addHand(card);
        if(withDisplay)
            GameItemsController.AddPlayerHandForDisplay(false,card);
        //updatePlayerScore();
    }

    public void SetOpponentPlayer(Player p)
    {
        Opponent = p;
    }
    public static void SetOpponentNameAndID(string name, long id)
    {
        _PvP.setOpponentNameAndID(name,id);
    }
    public static void SetOpponentLastAction(string action)
    {
        OpponentLastAction = action;
    }

    public void CheckOpponentAction()
    {
        if (OpponentLastAction == "Hit Request")
        {
            PassCard();
        }
        else if (OpponentLastAction == "Double Request")
        {
            PassCard();
            //TODO: Update bet
        }
        else if (OpponentLastAction == "Stand")
        {
            //Notthing to do?
        }
    }
}

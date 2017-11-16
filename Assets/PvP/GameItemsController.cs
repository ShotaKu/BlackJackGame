using BlackJackClass;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameItemsController : MonoBehaviour {

    private static LoadCardMaterial OpponentCards = null;
    private static LoadCardMaterial PlayerCards = null;

    private static PlayerInformationUI PlayerInformation = null;
    private static PlayerInformationUI OpponentInformation = null;

    private static Text PlayerScore = null;
    private static Text OpponentScore = null;
    private static Text PlayerMoney = null;
    //private static Text OpponentMoney = null;

    private static ButtonUI ControllerUI = null;
    private static ButtonUI RetryUI = null;
    private static ButtonUI ChangeBetUI = null;

    private static Animator ResultAnimator = null;
    private static DeckAnimation DeckAnimator = null;
    void Awake()
    {
        OpponentCards = transform.FindChild("DealerCards").GetComponent<LoadCardMaterial>();
        PlayerCards = transform.FindChild("MyCards").GetComponent<LoadCardMaterial>();
        
        Transform UIs = transform.FindChild("UI");

        Transform PlayerInfo = UIs.FindChild("PlayerInformation");
        PlayerInformation = PlayerInfo.GetComponent<PlayerInformationUI>();
        Transform DealerInfo = UIs.FindChild("DealerInformation");
        OpponentInformation = DealerInfo.GetComponent<PlayerInformationUI>();
        PlayerScore = transform.FindChild("Score").GetComponent<Text>();
        OpponentScore = transform.FindChild("DealerScore").GetComponent<Text>();
        PlayerMoney = PlayerInfo.FindChild("Money").FindChild("Text").GetComponent<Text>();
        //OpponentMoney = DealerInfo.FindChild("Money").FindChild("Text").GetComponent<Text>();

        ControllerUI = UIs.FindChild("ControlButtons").GetComponent<ButtonUI>();
        RetryUI = UIs.FindChild("RetryButtons").GetComponent<ButtonUI>();
        ChangeBetUI = UIs.FindChild("ChangeBetUI").GetComponent<ButtonUI>();
        ResultAnimator = transform.FindChild("GameResult").GetComponent<Animator>();
        DeckAnimator = transform.FindChild("Deck").GetComponent<DeckAnimation>();
    }
    public static void AddPlayerHandForDisplay(bool isReverced,params Card[] c)
    {
        PlayerCards.SetNewCard(isReverced,c);
    }
    public static void AddOpponentHandForDisplay(bool isReverced, params Card[] c)
    {
        print("<color=red>Display hand called</color>");
        OpponentCards.SetNewCard(isReverced, c);
    }
    public static void SetActiveControllerUI(bool isActive)
    {
        ControllerUI.setActiveUI(isActive);
    }
    public static void SetActiveRetryUI(bool isActive)
    {
        RetryUI.setActiveUI(isActive);
    }
    public static void SetActiveChangeBetUI(bool isActive)
    {
        ChangeBetUI.setActiveUI(isActive);
    }
    public static void SetPlayerMoneyForDisplay(int money)
    {
        PlayerMoney.text = "Money: " + money;
        if (money < 0)
            PlayerMoney.color = Color.red;
        else
            PlayerMoney.color = Color.white;
    }
    public static void SetOpponentMoneyForDisplay(int money)
    {
        //OpponentMoney.text = "Money: " + money;
    }
    public static void SetPlayerScoreForDisplay(int Score)
    {
        PlayerScore.text = Score + " / 21";
    }
    public static void SetOpponentScoreForDisplay(int Score)
    {
        if(Score == -1)
            OpponentScore.text = "? / 21";
        else
            OpponentScore.text = Score + " / 21";
    }
    public static void SetPlayerInformation(Player p)
    {
        PlayerInformation.SetID(p.Id);
        PlayerInformation.SetName(p.getName());
        PlayerInformation.SetMoney(p.getMoney());

    }
    public static void SetOpponentInformation(Player p)
    {
        OpponentInformation.SetID(p.Id);
        OpponentInformation.SetName(p.getName());
        OpponentInformation.SetMoney(p.getMoney());
    }
    //TODO: Method for access LoadCardMaterial
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameListItem : MonoBehaviour {

    private long GameID = -1;
    private string DealerName = null;
    private int DealerBet = 0;

    public void setDealerInformation(string name, int bet,long gameID)
    {
        DealerName = name;
        DealerBet = bet;
        GameID = gameID;

        transform.FindChild("DealerName").GetComponent<Text>().text = "Dealer: " + name;
        transform.FindChild("DealerBet").GetComponent<Text>().text = "Bet: " + bet + " Coin";
    }
    public void OnClick()
    {
        //TODO: check until join success
        print(GameID+ " was pushed!");
        JoinGame.JoinToGame(transform,GameID);
    }
    public string GetDealerName()
    { return DealerName; }

    public int GetDealerBet()
    { return DealerBet; }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameListItem : MonoBehaviour {

    private string DealerName = null;
    private int DealerBet = 0;

    public void setDealerInformation(string name, int bet)
    {
        DealerName = name;
        DealerBet = bet;

        transform.FindChild("DealerName").GetComponent<Text>().text = "Dealer: " + name;
        transform.FindChild("DealerBet").GetComponent<Text>().text = "Bet: " + bet + " Coin";
    }
    public string GetDealerName()
    { return DealerName; }

    public int GetDealerBet()
    { return DealerBet; }
}

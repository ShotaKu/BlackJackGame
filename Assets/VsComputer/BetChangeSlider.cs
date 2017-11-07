using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BetChangeSlider : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    private Text BetUI = null;

    public static BetChangeSlider Slider;
    private Slider BetChanger;

    void Start ()
    {
        Slider = this;
        BetChanger = transform.GetComponent<Slider>();
    }
    public void OnValueChanged()
    {
        changeBet();
    }
    public void updateMaxBet()
    {
        BetChanger.maxValue = VsComputer.getThisBattle().getPlayerMoney();
    }
    public void changeBet()
    {
        int bet = (int)BetChanger.value;

        BetUI.text = "Bet: " + bet;
        VsComputer.getThisBattle().setPlayerBet(bet);
    }
}

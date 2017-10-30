using BlackJackClass;
using UnityEngine;

public class RetryButton : MonoBehaviour {

    // Use this for initialization
    private VsComputer thisButtle = null;
    [SerializeField]
    FireWorksMaker effect = null;

    public void OnClick()
    {
        print("*----------RETRY----------*");
        effect.clearAll();
        if (thisButtle == null)
            thisButtle = VsComputer.getThisBattle();
        if (thisButtle.getResultGame() == BlackJack.Result.Win)
            thisButtle.getAnmation().Play("WinEnd", 0, 0);
        else if (thisButtle.getResultGame() == BlackJack.Result.Lose)
            thisButtle.getAnmation().Play("LoseEnd", 0, 0);
        else
            Debug.LogError("DrawResult!!");
        thisButtle.clearBothCards();
        thisButtle.setActiveChangeBetUI(true);
        thisButtle.setActiveRetryUI(false);
        thisButtle.updatePlayerScore();
        thisButtle.showDealerTotalScore();
        //thisButtle.Deal();
    }
}

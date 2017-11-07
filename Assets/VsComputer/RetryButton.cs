using BlackJackClass;
using UnityEngine;

public class RetryButton : MonoBehaviour {
    
    [SerializeField]
    FireWorksMaker effect = null;

    public void OnClick()
    {
        print("*----------RETRY----------*");
        effect.clearAll();

        VsComputer thisButtle = VsComputer.getThisBattle();
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
    public void OnClickPvP()
    {
        print("*----------RETRY----------*");
        effect.clearAll();
        PvP thisButtle = PvP.getThisBattle();
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

using UnityEngine;

public class StandButton : MonoBehaviour {

    // Use this for initialization
    VsComputer thisButtle = null;
    public void OnClick()
    {
        if(thisButtle == null)
            thisButtle = VsComputer.getThisBattle();

        thisButtle.Stand();
        //thisButtle.showDealerTotalScore();
    }
}

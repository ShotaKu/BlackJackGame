using UnityEngine;

public class StandButton : MonoBehaviour {

    // Use this for initialization

    public void OnClick()
    {

        VsComputer.getThisBattle().Stand();
    }

    public void OnClickPvP()
    {
        PvP.getThisBattle().Stand();
    }
}

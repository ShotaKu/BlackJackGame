using UnityEngine;

public class StandButton : MonoBehaviour {

    // Use this for initialization

    public void OnClick()
    {
        VsComputer.getThisBattle().Stand();
    }
    private string role = "";

    public string Role
    {
        get { return role; }
        set { role = value; }
    }

    public void OnClickPvP()
    {
        //TODO: Check until game finish (Dealer/Same)
    }
}

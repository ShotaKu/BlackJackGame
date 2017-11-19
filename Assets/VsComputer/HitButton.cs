using UnityEngine.UI;
using UnityEngine;

public class HitButton : MonoBehaviour {

    
    private VsComputer ThisBattle = null;
    private PvP ThisPvP = null;
    public void OnClick()
    {
        if (ThisBattle == null)
            ThisBattle = VsComputer.getThisBattle();

        if (!ThisBattle.PlayerHit())
            ThisBattle.Stand();

    }
    private string role = "";

    public string Role
    {
        get { return role; }
        set { role = value; }
    }

    public void OnClickPvP()
    {
        //TODO: Dealer -> Check Until Player is not Thinking time

        //TODO: Player -> Check until Thinking time

    }

}

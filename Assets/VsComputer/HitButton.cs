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
    public void OnClickPvP()
    {
        PvP ThisPvP = PvP.getThisBattle();

        if (!ThisPvP.PlayerHit())
            ThisPvP.Stand();


    }

}

using UnityEngine.UI;
using UnityEngine;

public class HitButton : MonoBehaviour {

    
    private VsComputer ThisBattle = null;
    public void OnClick()
    {
        if (ThisBattle == null)
            ThisBattle = VsComputer.getThisBattle();

        if (!ThisBattle.PlayerHit())
            ThisBattle.Stand();

        
    }

}

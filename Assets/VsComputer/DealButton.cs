using UnityEngine;

public class DealButton : MonoBehaviour
{
    public void OnClick()
    {
        VsComputer.getThisBattle().Deal();
    }
    public void OnClickPvP()
    {
        PvP.getThisBattle().Deal();
    }
}

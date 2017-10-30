using UnityEngine;

public class DealButton : MonoBehaviour
{
    
    //[SerializeField]
    //ButtonUI Controller = null;
    
    public void OnClick()
    {
        VsComputer.getThisBattle().Deal();
    }
}

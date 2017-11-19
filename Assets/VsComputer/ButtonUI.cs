using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonUI : MonoBehaviour {
    
    public void setActiveUI(bool active)
    {
        gameObject.SetActive(active);
    }

    public void SetRole(string role)
    {
        transform.FindChild("Stand").GetComponent<StandButton>().Role = role;
        transform.FindChild("Hit").GetComponent<HitButton>().Role = role;
        //transform.FindChild("Double").GetComponent<DoubleButton>().SetRole(role);
    }
	
}

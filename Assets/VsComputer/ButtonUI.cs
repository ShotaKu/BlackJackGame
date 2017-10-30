using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonUI : MonoBehaviour {

    //private static ChangeBetUI UI;

	// Use this for initialization
	
    public void setActiveUI(bool active)
    {
        gameObject.SetActive(active);
    }
	
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeSelector : MonoBehaviour {

    // Use this for initialization
    public void toVsComputer()
    {
        SceneManager.LoadScene("VsComputer");
    }
    public void toPvP()
    {
        SceneManager.LoadScene("PvP");
    }
    public void toPartyMode()
    {
        SceneManager.LoadScene("Party Mode");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

    // Use this for initialization
    public void OnClickCreateGame()
    {
        GetPost load =  Canvas.GetLoadingObject();
        
    }

    public void OnClickJpinGame()
    {

    }

    public void OnClickBack()
    {
        SceneManager.LoadScene("StartPage");
    }
}

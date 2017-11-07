using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PvPUIButtonManager : MonoBehaviour
{
    [SerializeField]
    ListUI gameList = null;
    [SerializeField]
    GameObject GameItems = null;
    // Use this for initialization
    public void OnCreateGameClicked()
    {
        PlayerRole p = transform.GetComponent<PlayerRole>();
        if (p != null)
        {
            Destroy(p);
        }
        GameItems.AddComponent<DealerRole>();
        GameItems.SetActive(true);
        gameObject.SetActive(false);
    }

    public void OnJoinGameClicked()
    {
        DealerRole d = transform.GetComponent<DealerRole>();
        if (d != null)
        {
            Destroy(d);
        }
        GameItems.AddComponent<PlayerRole>();
        gameList.EnableAndLoad();
    }

    public void OnBackClicked()
    {
        SceneManager.LoadScene("StartPage");
    }

}

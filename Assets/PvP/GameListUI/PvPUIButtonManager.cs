using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PvPUIButtonManager : MonoBehaviour
{
    [SerializeField]
    ListUI gameList = null;
    // Use this for initialization
    public void OnCreateGameClicked()
    {
        
    }

    public void OnJoinGameClicked()
    {
        gameList.EnableAndLoad();
    }

    public void OnBackClicked()
    {

    }

}

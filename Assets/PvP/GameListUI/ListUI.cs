using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListUI : MonoBehaviour
{


    void Start()
    {
        OnClickClose();
    }

    public void EnableAndLoad()
    {
        gameObject.SetActive(true);
        GameListLoader loader = transform.FindChild("ListObject").FindChild("List").GetComponent<GameListLoader>();
        loader.LoadGameList();
    }
    public void OnClickClose()
    {
        gameObject.SetActive(false);
    }

}

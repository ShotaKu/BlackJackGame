using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameListItemBuilder{

    // Use this for initialization
    private static Object itemPrefab = Resources.Load("Prefab/GameListItem") as GameObject;
    public Object CreateGameListItem(string name, int bet)
    {
        return itemPrefab;
    }
}

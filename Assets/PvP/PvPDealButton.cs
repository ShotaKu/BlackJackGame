using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PvPDealButton : MonoBehaviour
{
    // public static bool isSomePlayerJoin = false;
    public static bool isCreateGameSuccess = false;
    
    public void OnClick()
    {
        DealerRole thisBattle = DealerRole.getThisBattle();
        thisBattle.Deal();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinChecker
{

    public static Func<bool> CheckJoinStatus()
    {
        Func<bool> callback = () =>
        {
            //TODO: Checking some player join to game or not.
            return true;
        };

        return callback;
    }

    public static Action Timeout()
    {
        Action action = () =>
        {
            Debug.Log("Timeout");
            MessageWindow.setErrorMessage("Created Game are Timeout.Please push back button and create new game.");
            MessageWindow.setActive(true);
        };

        return action;
    }
    public static Action Loaded()
    {
        Action action = () =>
        {
            Debug.Log("Loaded");
        };

        return action;
    }

}

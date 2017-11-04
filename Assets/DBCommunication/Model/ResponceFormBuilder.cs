using BlackJackGame.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponceFormBuilder
{
    public static RegistrationResult getRegistrationResult(string jsonResponse)
    {
        RegistrationResult player = new RegistrationResult();
        if (jsonResponse != "" || jsonResponse != null)
        {
            player = JsonUtility.FromJson<RegistrationResult>(jsonResponse);
        }
        else
        {
            throw new System.ArgumentException("Parameter cannot be null", "original");
        }
        return player;
    }

    public static T GetResult<T>(string jsonResponse)
    {
        T result;
        if (jsonResponse != "" || jsonResponse != null)
        {
            result = JsonUtility.FromJson<T>(jsonResponse);
        }
        else
        {
            throw new System.ArgumentException("Parameter cannot be null", "original");
        }
        return result;
    }
}

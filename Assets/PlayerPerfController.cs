using BlackJackClass;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPerfController
{
    private readonly static string PLAYER_ID_KEY = "BlackJack_ID";
    private readonly static string PLAYER_MONEY_KEY = "BlackJack_Money";
    private readonly static string PLAYER_NAME_KEY = "BlackJack_NAME";
    private readonly static string PLAYER_CODE_KEY = "BlackJack_Code";
    private readonly static string PLAYER_EMAIL_KEY = "BlackJack_Email";

    public Player LoadPlayerInformation()
    {
        //PlayerPrefs.DeleteAll();
        //PlayerPrefs.Save();
        int playerMoney = PlayerPrefs.GetInt(PLAYER_MONEY_KEY, -1);
        
        if (playerMoney == -1)
        {
            updateMoney(30000);
            playerMoney = 30000;
        }
            
        string playerName = PlayerPrefs.GetString(PLAYER_NAME_KEY, null);
        if (playerName == null)
        {
            //ERROR
            playerName = "Guest Player";
        }

        return new Player(playerName,playerMoney);
    }

    public static string LoadPlayerEmailAddress()
    {
        string email = PlayerPrefs.GetString(PLAYER_EMAIL_KEY, null);
        if (email == null)
        {
            email = "Unregistrated";
        }

        return email;

    }

    /// <summary>
    /// Return null when player  didn't register yet.
    /// </summary>
    /// <returns>string: Player name (or null)</returns>
    public static string LoadPlayerName()
    {
        string email = PlayerPrefs.GetString(PLAYER_NAME_KEY, null);
        return email;
    }

    public static void SaveRegistratedInformation(long playerID, string name, string email, string code)
    {
        PlayerPrefs.SetString(PLAYER_ID_KEY, playerID.ToString());
        PlayerPrefs.SetString(PLAYER_NAME_KEY, name);
        PlayerPrefs.SetString(PLAYER_EMAIL_KEY, email);
        PlayerPrefs.SetString(PLAYER_CODE_KEY, code);
    }
    public static void SavePlayerID(long playerID)
    {
        PlayerPrefs.SetString(PLAYER_ID_KEY, playerID.ToString());
    }
    public static long LoadPlayerID()
    {
        long id = -1;
        long.TryParse(PlayerPrefs.GetString(PLAYER_ID_KEY, null),out id);

        if (id == -1)
        {
            Debug.LogError("Load playerID failed.");
        }
        return id;
    }

    public void updateMoney(int m)
    {
        if (m <= 0)
            m = 1000;
        PlayerPrefs.SetInt(PLAYER_MONEY_KEY, m);
        PlayerPrefs.Save();
    }
	
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPostFormBuilder
{

    public Dictionary<string, string> GetRegistrationPostFormat(string email, string name)
    {
        Dictionary<string, string> format = new Dictionary<string, string>
        {
            { "email" , email},
            { "playerName" , name}
        };

        return format;
    }

    public Dictionary<string, string> GetCreateGamePostFormat(long dealerID, string[] dealerHand, int dealerScore, int dealerBet, string[] playerHand, int playerScore)
    {
        string dealerHandStr = string.Join(",", dealerHand);
        string playerHandStr = string.Join(",", playerHand);
        Dictionary<string,string> format = new Dictionary<string, string>
        {
            { "dealerID" , dealerID.ToString()},
            { "dealerHand" , dealerHandStr },
            { "dealerScore", dealerScore.ToString() },
            { "dealerBet" ,dealerBet.ToString()},
            { "playerHand",playerHandStr },
            { "playerScore",playerScore.ToString() }
        };

        return format;
    }
}
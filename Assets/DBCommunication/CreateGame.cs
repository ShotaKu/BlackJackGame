using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGame
{

    public static void CreateGameOnDB(GetPost post,string[] dealerHand,int dealerScore, int dealerBet,string[] playerHand, int playerScore, Action<WWW> callBack)
    {
        Loading.startLoading();
        long dealerID = PlayerPerfController.LoadPlayerID();
        if (dealerID != -1)
        {
            GetPostFormBuilder gpfBuilder = new GetPostFormBuilder();
            var postData = gpfBuilder.GetCreateGamePostFormat(dealerID, dealerHand, dealerScore, dealerBet, playerHand, playerScore);
            post.POST("http://blackjackgame-hybridappdev.azurewebsites.net/Game/CreateGame", postData,callBack);
        }
    }

}

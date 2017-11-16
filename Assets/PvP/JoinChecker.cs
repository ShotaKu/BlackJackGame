using BlackJackClass;
using BlackJackGame.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinChecker
{
    private static bool isJoin = false;
    private static GameInformation responce = new GameInformation();
    public static Func<bool> CheckJoinStatus(GameObject game,long gameID)
    {
        Func<bool> callback = () =>
        {
            //TODO: Checking some player join to game or not.

            GetPost getPost = game.AddComponent<GetPost>();
            GetPostFormBuilder gpBuilder = new GetPostFormBuilder();
            var post = gpBuilder.GetGetGamePostFormat(gameID);
            getPost.POST("http://blackjackgame-hybridappdev.azurewebsites.net/Game/GetGame", post, result =>
            {
                //TODO: Reult
                responce = ResponceFormBuilder.GetResult<GameInformation>(result.text);
                Debug.LogWarning("Player = " + responce.PlayerID.ToString()+ "gameID = "+ responce.GameID + "is Join = " + isJoin);
                isJoin = (responce.PlayerID != -1);
            });
            
            return isJoin;
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
            isJoin = false;
        };

        return action;
    }
    public static Action Loaded(Action callback)
    {
        Action action = () =>
        {
            Debug.Log("Loaded");
            GameItemsController.SetActiveChangeBetUI(false);
            GameItemsController.SetActiveControllerUI(true);
            //Player p = new Player();
            DealerRole.getThisBattle().SetOpponentNameAndID(responce.PlayerName,responce.PlayerID);
            callback();
            Loading.stopLoading();
            isJoin = false;
        };

        return action;
    }

}

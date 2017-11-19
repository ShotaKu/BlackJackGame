using BlackJackGame.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionChecker
{
    private static bool isJoin = false;
    private static GameInformation responce = new GameInformation();
    public static Func<bool> CheckJoinStatus(GameObject game, long gameID)
    {
        Func<bool> callback = () =>
        {
            //TODO: Checking some player join to game or not.

            GetPost getPost = game.AddComponent<GetPost>();
            GetPostFormBuilder gpBuilder = new GetPostFormBuilder();
            var post = gpBuilder.GetGetGamePostFormat(gameID);
            getPost.POST("", post, result =>
            {
                //TODO: Reult
                responce = ResponceFormBuilder.GetResult<GameInformation>(result.text);
                isJoin = (responce.PlayerLastAction != "Thinking Time");
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
            MessageWindow.setErrorMessage("Time limit to Player. You win");
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


            callback();
            Loading.stopLoading();
            isJoin = false;
        };

        return action;
    }

}

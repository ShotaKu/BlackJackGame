using BlackJackGame.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinGame
{

    public static void JoinToGame(Transform transform,long gameID)
    {
        Transform UI = Canvas.getObject("GameItems");
        
        GetPost getPost = transform.GetComponent<GetPost>();
        if (getPost == null)
            getPost = transform.gameObject.AddComponent<GetPost>();

        GetPostFormBuilder gpfBuilder = new GetPostFormBuilder();

        var postData = gpfBuilder.GetJoinGamePostFormat(gameID, PlayerPerfController.LoadPlayerID());
        Loading.startLoading();
        getPost.POST("http://blackjackgame-hybridappdev.azurewebsites.net/Game/JoinGame",postData,result=> 
        {
            //TODO: Open controllerUI(not changeBetUI) and set gameID.
            transform.parent.parent.parent.parent.gameObject.SetActive(false);
            Debug.Log(result.text);

            JoinResult responce = ResponceFormBuilder.GetResult<JoinResult>(result.text);

            UI.gameObject.SetActive(true);
            GameItemsController.SetActiveRetryUI(false);
            GameItemsController.SetActiveChangeBetUI(false);
            PlayerRole.getThisBattle().GameID = responce.GameID;
            PlayerRole.getThisBattle().SetPlayerHandForDisplay(responce.PlayerHand);
            PlayerRole.getThisBattle().SetOpponentHandForDisplay(responce.DealerHand);
            Loading.stopLoading();
        });
    }
}

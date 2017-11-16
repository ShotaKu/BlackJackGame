using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BlackJackGame.Models;
using DBErrorCodeAndMessages;
using UnityEngine.UI;

public class GameListLoader : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    GameObject NoGame = null;
    private static RectTransform itemPrefab = null;

    void Start()
    {
        itemPrefab = Resources.Load<RectTransform>("Prefab/GameListItem");
        print("isPrefabNull = " + (itemPrefab == null));

    }

    public void LoadGameList()
    {
        NoGame.SetActive(false);
        ClearList();
        //Make get list to allow get
        GetPost getPost = transform.GetComponent<GetPost>();
        if (getPost == null)
            getPost = gameObject.AddComponent<GetPost>();
        Loading.startLoading();
        //Debug Mode -> GetAllArivedGame    Not Debuug -> GetAllArivedNoPlayerGame
        getPost.GET("http://blackjackgame-hybridappdev.azurewebsites.net/Game/SearchAllArriveGame", result =>
        {
            //ResponceFormBuilder resBuilder = new ResponceFormBuilder();
            print(result.text);
            GameResultList lists = ResponceFormBuilder.GetResult<GameResultList>(result.text);
            ErrorCodes error = new ErrorCodes("");
            print(lists.GameResults.Count);

            if (0 < lists.GameResults.Count && lists != null)
            {
                if (error.isError(lists.GameResults[0].ErrorCode))      //ERROR!
                {
                    print("Error");
                    MessageWindow.setErrorMessage(lists.GameResults[0].Message);
                    MessageWindow.setActive(true);
                }
                else        //Succsess
                {
                    //GameListItemBuilder gItemBuilder = new GameListItemBuilder();
                    foreach (GameResult game in lists.GameResults)
                    {
                        print("Success");
                        RectTransform prefab = Instantiate(itemPrefab) as RectTransform;
                        print("isPrefabNull = " + (prefab == null));
                        prefab.GetComponent<GameListItem>().setDealerInformation(game.DealerName,game.DealerBet);
                        prefab.transform.SetParent(transform,false);
                    }
                }
            }
            else
            {
                //TODO: Show "No games opend"
                print("No games");
                NoGame.SetActive(true);
            }

            Loading.stopLoading();

            Debug.Log(lists.GameResults[0].ErrorCode);
        });
    }

    public void ClearList()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}

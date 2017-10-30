using Result;
using System.Collections.Generic;
using UnityEngine;
using DBErrorCodeAndMessages;
using UnityEngine.UI;

public class RegistorOrCancel : MonoBehaviour {

    [SerializeField]
    Button Registration = null;

    [SerializeField]
    InputField Email = null;
    [SerializeField]
    InputField Name = null;

    public void OnClickRegistor()
    {
        GetPostFormBuilder builder = new GetPostFormBuilder();
        Dictionary<string, string> postData = builder.getRegistrationPostFormat(Email.text, Name.text);

        GetPost getPost = transform.GetComponent<GetPost>();

        Loading.startLoading();
        getPost.POST("http://blackjackgame-hybridappdev.azurewebsites.net/Registration/registorNewPlayer", postData,result => 
        {
            //ResponceFormBuilder resBuilder = new ResponceFormBuilder();
            print(result.text);
            RegistrationResult player = ResponceFormBuilder.getRegistrationResult(result.text);
            ErrorCodes error = new ErrorCodes();
            print(player.Message);

            if (error.isError(player.ErrorCode))
            {
                MessageWindow.setErrorMessage(player.Message);
                MessageWindow.setActive(true);
            }
            else
            {
                //Save player information to plyerPerfit
                PlayerPerfController pCon = new PlayerPerfController();
                PlayerPerfController.SaveRegistratedInformation(Name.text,Email.text,player.FriendCode);
                OnClickCancel();
                MessageWindow.setMessage("Welcome to Black Jack Game!");
                MessageWindow.setActive(true);
            }
            Loading.stopLoading();
            Email.text = "";
            Name.text = "";

            Debug.Log(player.Message);
        });
    }

    public void OnClickCancel()
    {
        Email.text = "";
        Name.text = "";
        Registration.onClick.Invoke();
    }
}

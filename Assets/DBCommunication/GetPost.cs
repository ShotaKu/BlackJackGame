using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPost : MonoBehaviour
{

    public WWW GET(string url)
    {
        WWW www = new WWW(url);
        StartCoroutine(WaitForRequest(www));
        return www;
    }

    public WWW POST(string url, Dictionary<string, string> post, Action<WWW> callBack = null)
    {
        WWWForm form = new WWWForm();
        foreach (KeyValuePair<string, string> post_arg in post)
        {
            form.AddField(post_arg.Key, post_arg.Value);
        }
        WWW www = new WWW(url, form);
        StartCoroutine(WaitForRequest(www,callBack));
        return www;
    }

    private IEnumerator WaitForRequest(WWW www, Action<WWW> onSuccess = null)
    {
        yield return www;

        // check for errors
        if (www.error == null)
        {
            Debug.Log("WWW Ok!: " + www.text);
            if (onSuccess != null)      //Should not delete
            {
                onSuccess(www);
            }
        }
        else
        {
            MessageWindow.setErrorMessage(www.error);
            MessageWindow.setActive(true);
        }
    }
}

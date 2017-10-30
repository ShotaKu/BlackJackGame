using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading : MonoBehaviour {

    private static Animator loadingAnimation;
    private static GameObject loadingWindow;

    void Start()
    {
        loadingWindow = gameObject;
        loadingAnimation = transform.GetComponent<Animator>();
        gameObject.SetActive(false);
    }

    public static void startLoading()
    {
        loadingAnimation.Play("Loading");
        loadingWindow.SetActive(true);
    }
    public static void stopLoading()
    {
        loadingAnimation.Stop();
        loadingWindow.SetActive(false);
    }
}

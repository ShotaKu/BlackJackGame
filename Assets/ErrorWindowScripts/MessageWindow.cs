using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageWindow : MonoBehaviour {

    private static GameObject Window = null;
    private static Text Title = null;
    private const string WindowName = "Window";
    private const string MessageName = "Message";

    void Start()
    {
        Window = transform.gameObject;
        Title = transform.FindChild("Window").FindChild("Title").FindChild("Text").GetComponent<Text>();
        Window.SetActive(false);
        print(Window != null);
    }

    public static void setActive(bool isActive)
    {
        Window.SetActive(isActive);
    }

    public static void setErrorMessage(string message)
    {
        Title.text = "ERROR";
        Title.color = Color.red;
        Window.transform.FindChild(WindowName).FindChild(MessageName).GetComponent<Text>().text = message;
    }
    public static void setMessage(string message)
    {
        Title.text = "Message";
        Title.color = Color.black;
        Window.transform.FindChild(WindowName).FindChild(MessageName).GetComponent<Text>().text = message;
    }
}

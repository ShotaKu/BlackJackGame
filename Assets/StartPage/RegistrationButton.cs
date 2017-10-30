using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegistrationButton : MonoBehaviour {

	public static bool isActive = false;
    [SerializeField]
    GameObject RegistrationUI = null;

    void Start()
    {
        string name = PlayerPerfController.LoadPlayerName();
        if (name != null)
        {
            transform.FindChild("Text").GetComponent<Text>().text = name;
            GetComponent<Button>().enabled = false;
        }
    }

    public void OnClick()
    {
        isActive = !isActive;
        RegistrationUI.SetActive(isActive);
    }

    public void Cancel()
    {
        isActive = false;
        RegistrationUI.SetActive(isActive);
    }
}

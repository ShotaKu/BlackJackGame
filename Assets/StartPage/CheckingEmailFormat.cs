using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckingEmailFormat : MonoBehaviour {

    [SerializeField]
    GameObject ErrorMessage = null;

    public void OnEndEdit(string input)
    {
        bool correctFormat = IsValidEmail(input);
        ErrorMessage.SetActive(!correctFormat);
    }

    private bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }
}

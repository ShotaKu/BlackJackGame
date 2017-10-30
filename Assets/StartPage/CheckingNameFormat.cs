using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class CheckingNameFormat : MonoBehaviour {

    [SerializeField]
    GameObject ErrorMessage = null;

    public void OnEndEdit(string input)
    {
        bool correctFormat = IsValidName(input);
        ErrorMessage.SetActive(!correctFormat);
    }

    private bool IsValidName(string name)
    {
        return (Regex.IsMatch(name, "^[a-zA-Z0-9]*$"));
    }
}

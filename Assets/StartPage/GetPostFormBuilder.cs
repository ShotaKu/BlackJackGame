using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPostFormBuilder
{

    public Dictionary<string, string> getRegistrationPostFormat(string email, string name)
    {
        Dictionary<string, string> format = new Dictionary<string, string>
        {
            { "email" , email},
            { "playerName" , name}
        };

        return format;
    }
    
}

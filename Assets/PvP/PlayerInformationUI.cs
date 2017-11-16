using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInformationUI : MonoBehaviour
{
    public void SetID(long id)
    {
        transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "ID: " + id;
    }
    public void SetName(string name)
    {
        transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "Name: " + name;
    }
    public void SetMoney(int money)
    {
        bool isActive = (money != -1);
            transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "Money: " + money;
        transform.GetChild(2).gameObject.SetActive(isActive);
    }
    public void SetActiveMoney(bool isActive)
    {
        transform.GetChild(2).gameObject.SetActive(isActive);
    }
	
}

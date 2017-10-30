using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetEnable : MonoBehaviour {

    // Use this for initialization
    public void setEnable(bool isEnable)
    {
        gameObject.SetActive(isEnable);
    }
}

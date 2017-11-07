﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckUntil : MonoBehaviour {
    
    private int CheckedTime = 0;
    private float Delay = 2f;
    private int TimeoutMinits = 5;
    private int CheckingTime;
    
    public static bool isGetResult = false;

    /// <summary>
    /// Process CallBack Function 
    /// </summary>
    public void CheckUntilGetResult(float delay, int timeoutMinits, Func<bool> checkAction, Action whenLoaded,Action whenTimeout)
    {
        CheckedTime = 0;
        CheckingTime = (TimeoutMinits * 60) / (int)(Delay * 10);
        StartCoroutine(Check(checkAction,whenLoaded, whenTimeout));
    }

    IEnumerator Check(Func<bool> checkAction, Action whenLoaded,Action whenTimeout)
    {
        print("Checking...(" + CheckedTime + "/" + CheckingTime + ")");
        yield return new WaitForSeconds(Delay);

        isGetResult = checkAction();

        if (isGetResult)   // Someone Joined
        {
            //print("Stop it");
            Loading.stopLoading();
            whenLoaded();
            //StartGame
            yield break;
        }
        else        //Noone Join
        {
            CheckedTime++;
            //print("Not Stop");
            if (CheckingTime <= CheckedTime)
            {
                //print("Time Out");
                //ShowTimeout
                whenTimeout();
                isGetResult = true;
                yield break;
            }
            //Rechecking

            StartCoroutine(Check(checkAction, whenLoaded, whenTimeout));
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Role
{
    void DisplayAllCards();
    string[] GetOpponentHand();
    string[] GetPlayerHand();
    void clearBothCards();

    void Stand();
    //void Hit();
    void PlayerHit();
    void OpponentHit();
    void DisplayPlayerInformation();
    void DisplayOpponentInformation();

    void SavePlayerMoney();
    void IsAnyOneBusted();
    void DisplayAllcards();
}

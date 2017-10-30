using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckAnimation : MonoBehaviour {

    // Use this for initialization
    Animator deck = null;
	void Start ()
    {
        deck = transform.GetComponent<Animator>();
    }
    public void PlayerDraw()
    {
        deck.Play("PassCardToPlayer", 0, 0);
    }
    public void DealerDraw()
    {
        deck.Play("PassCardToDealer", 0, 0);
    }
    public void DrawBoth()
    {
        deck.Play("PassCardToBoth", 0, 0);
    }
}

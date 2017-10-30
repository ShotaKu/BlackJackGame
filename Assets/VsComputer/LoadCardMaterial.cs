﻿using BlackJackClass;
using UnityEngine;

public class LoadCardMaterial : MonoBehaviour {

    public void setCards(Card card,int cardInHand, bool isRevers = false)
    {
        if (card != null)
        {
            print("CardPrefab/PlayingCards_" + card.getNumberByString()+"("+card.getNumber()+")" + card.getFormats());
            var newCard = Instantiate(Resources.Load("CardPrefab/PlayingCards_" + card.getNumberByString() + card.getFormats())) as GameObject;
            newCard.transform.SetParent(transform, false);

            RectTransform pos = newCard.GetComponent<RectTransform>();

            pos.localPosition = new Vector3(pos.localPosition.x,pos.localPosition.y,(-1*cardInHand));

            if (isRevers)
                pos.Rotate(new Vector3(0, 180, 0));
                
        }
    }

    public void openAllCards()
    {
        foreach (Transform card in transform)
        {
            float rotation = card.GetComponent<RectTransform>().localRotation.y;
            bool isRevers = (rotation<1);
            //print("(-1 <= " + rotation + " && " + rotation + " <= 1)" + " is " +isRevers);
            if(isRevers)
                card.GetComponent<RectTransform>().Rotate(0,-180,0);

        }
    }

    public void clearCard()
    {
        foreach (Transform card in transform)
        {
            Destroy(card.gameObject);
        }
    }

}

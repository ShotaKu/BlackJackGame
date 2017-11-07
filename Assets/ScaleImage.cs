using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleImage : MonoBehaviour {

    [SerializeField]
    Texture2D image;
    [SerializeField]
    int x = 0;
    [SerializeField]
    int y = 0;

    void Start()
    {
        Rect size = transform.GetComponent<RectTransform>().rect;
        Color[] crop = image.GetPixels(x, y, (int)size.width, (int)size.height);
        Texture2D destTex = new Texture2D((int)size.width, (int)size.height);
        destTex.SetPixels(crop);
        destTex.Apply();
        transform.GetComponent<Image>().sprite = Sprite.Create(destTex, new Rect(0, 0, (int)size.width, (int)size.height), Vector2.zero);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

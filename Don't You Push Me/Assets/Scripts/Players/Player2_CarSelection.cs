using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player2_CarSelection : MonoBehaviour {

    public List<CarModel_Base> carModels;

    public Image image;
    [HideInInspector] public int index = 0;

    public void Next()
    {
        index++;
        if (index == carModels.Count)
            index = 0;

        ShowSprite();
    }

    public void Prev()
    {
        index--;
        if (index < 0)
            index = carModels.Count - 1;

        ShowSprite();
    }

	// Use this for initialization
	void Start () {
        ShowSprite();
	}
	
    void ShowSprite()
    {
        image.sprite = carModels[index].sprite;
    }
}

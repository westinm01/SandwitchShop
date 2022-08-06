using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Hand
{
    //public static SpriteRenderer onHandItem = GameObject.GetByTag("Hand").GetComponent<SpriteRenderer>();
    public static Ingredients whatItem = null; 

    public static void setItem(Ingredients currItem){
        whatItem = currItem;
        SpriteRenderer onHandItem = GameObject.FindWithTag("Hand").GetComponent<SpriteRenderer>();
        Sprite tempSprite = currItem.GetComponent<SpriteRenderer>().sprite;
        onHandItem.sprite = tempSprite;
    }
}

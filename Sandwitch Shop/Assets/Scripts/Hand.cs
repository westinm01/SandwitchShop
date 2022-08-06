using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Hand
{
    //public static SpriteRenderer onHandItem = GameObject.GetByTag("Hand").GetComponent<SpriteRenderer>();
    public static Food whatItem = null; 

    public static void setItem(Food currItem, Sprite whatHold){
        whatItem = currItem;
        Debug.Log(whatItem);
        GameObject.FindWithTag("Hand").GetComponent<SpriteRenderer>().sprite = whatHold;
    }

    public static void dropItem(){
        whatItem = null;
    }
}

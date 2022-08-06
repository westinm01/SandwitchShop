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
        Color tmp = GameObject.FindWithTag("Hand").GetComponent<SpriteRenderer>().color;
        tmp.a = 1f;
        GameObject.FindWithTag("Hand").GetComponent<SpriteRenderer>().color = tmp;
    }

    public static void dropItem(){
        whatItem = null;
        GameObject.FindWithTag("Hand").GetComponent<SpriteRenderer>().sprite = null;
        Color tmp = GameObject.FindWithTag("Hand").GetComponent<SpriteRenderer>().color;
        tmp.a = 0f;
        GameObject.FindWithTag("Hand").GetComponent<SpriteRenderer>().color = tmp;
    }

    public static Food getItem(){
        return whatItem;
    }
}

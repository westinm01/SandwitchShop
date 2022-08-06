using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Veggy : Food
{
    public Ingredients.veggy veggy;
    [SerializeField] Sprite[] veggySprites;
    public bool isCut;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        isCuttable = true;
        //isCut = false;
    }

    public Sprite GetSprite(Ingredients.veggy veggyType)
    {
        Sprite veggySprite = null;

        switch (veggyType)
        {
            case Ingredients.veggy.Potato:
                veggySprite = veggySprites[0];
                break;
            case Ingredients.veggy.Lettuce:
                veggySprite = veggySprites[1];
                break;
            case Ingredients.veggy.Tomato:
                veggySprite = veggySprites[2];
                break;
            case Ingredients.veggy.Onion:
                veggySprite = veggySprites[3];
                break;
            case Ingredients.veggy.Mushroom:
                veggySprite = veggySprites[4];
                break;
            default:
                Debug.Log("Veggy Type Not Recognized");
                break;
        }

        return veggySprite;
    }
}

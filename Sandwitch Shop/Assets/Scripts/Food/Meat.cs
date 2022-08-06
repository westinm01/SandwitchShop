using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meat : Food
{
    public Ingredients.meat meat;
    [SerializeField] Sprite[] meatSprites;

    // Start is called before the first frame update
    protected override void Start()
    {
        isCuttable = false;
    }

    public Sprite GetSprite(Ingredients.meat meatType)
    {
        Sprite meatSprite = null;

        switch (meatType)
        {
            case Ingredients.meat.Frog:
                meatSprite = meatSprites[0];
                break;
            case Ingredients.meat.Dragon:
                meatSprite = meatSprites[1];
                break;
            case Ingredients.meat.Jelly:
                meatSprite = meatSprites[2];
                break;

            case Ingredients.meat.Piranha:
                meatSprite = meatSprites[3];
                break;
            case Ingredients.meat.Cthulu:
                meatSprite = meatSprites[4];
                break;

            case Ingredients.meat.RollyPolly:
                meatSprite = meatSprites[5];
                break;
            default:
                Debug.Log("Meat Type Not Recognized");
                break;
        }

        return meatSprite;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bread : Food
{
    public Ingredients.bread bread;
    [SerializeField] Sprite[] breadSprites;

    // Start is called before the first frame update
    protected override void Start()
    {
        isCuttable = false;
    }

    public Sprite GetSprite(Ingredients.bread breadType)
    {
        Sprite breadSprite = null;

        switch (breadType)
        {
            case Ingredients.bread.Sourdough:
                breadSprite = breadSprites[0];
                break;
            case Ingredients.bread.White:
                breadSprite = breadSprites[1];
                break;
            case Ingredients.bread.WholeGrain:
                breadSprite = breadSprites[2];
                break;
            default:
                Debug.Log("Bread Type Not Recognized");
                break;
        }

        return breadSprite;
    }
}

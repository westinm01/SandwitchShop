using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dressing : Food
{
    public Ingredients.dressing dressing;
    [SerializeField] Sprite[] dressingSprites;
    // Start is called before the first frame update
    protected override void Start()
    {
        isCuttable = false;
    }

    public Sprite GetSprite(Ingredients.dressing dressingType)
    {
        Sprite dressingSprite = null;

        switch (dressingType)
        {
            case Ingredients.dressing.Vinegar:
                dressingSprite = dressingSprites[0];
                break;
            case Ingredients.dressing.Ketchup:
                dressingSprite = dressingSprites[1];
                break;
            case Ingredients.dressing.Mustard:
                dressingSprite = dressingSprites[2];
                break;
            case Ingredients.dressing.NoDressing:
                dressingSprite = null;
                break;
            default:
                Debug.Log("Dressing Type Not Recognized");
                break;
        }

        return dressingSprite;
    }
}

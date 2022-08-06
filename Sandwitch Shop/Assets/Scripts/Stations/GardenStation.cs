using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenStation : Station
{
    public List<Ingredients.veggy> veggies = new List<Ingredients.veggy>();
    private int index = 0;
    private SpriteRenderer thisSpriteRenderer;
    public Sprite defaultSprite;
    public List<Sprite> sproutGardenSprites = new List<Sprite>();
    public List<Sprite> finalGardenSprites = new List<Sprite>();
    private SpriteRenderer iconSprite;
    public List<Sprite> iconSprites = new List<Sprite>();

    private bool isGrowing = false;

    public float timeToGrow = 2.0f;
    private float currentTime = 0.0f;

    private int currentStage = 0;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        veggies.Add(Ingredients.veggy.Potato);//0
        veggies.Add(Ingredients.veggy.Lettuce);//1
        veggies.Add(Ingredients.veggy.Tomato);//2
        veggies.Add(Ingredients.veggy.Onion);//3
        veggies.Add(Ingredients.veggy.Mushroom);//4

        thisSpriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        iconSprite = this.gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        iconSprite.sprite = iconSprites[0];

        leftFunction = () => MoveIndex(-1);
        rightFunction = () => MoveIndex(1);
        actionFunction = () => GrowItem();
        

    }

    protected override void Update()
    {
        
        base.Update();
        if(isSelected)
        {
            Debug.Log("gets selected");
            if(Input.GetKey("down") && isGrowing)
            {
                Debug.Log("it do be growing");
                currentTime += Time.deltaTime;
                if(currentStage == 0 && currentTime >= timeToGrow / 3.0f)
                {
                    currentStage++;
                    if(index == 4)
                    {
                        thisSpriteRenderer.sprite = sproutGardenSprites[1];
                    }
                    else
                    {
                        thisSpriteRenderer.sprite = sproutGardenSprites[0];
                    }
                }
                else if(currentStage == 1 && currentTime >= timeToGrow/1.5f)
                {
                    currentStage++;
                    thisSpriteRenderer.sprite = finalGardenSprites[index];
                }
            }
            if(currentStage == 2 && Input.GetKeyDown(KeyCode.DownArrow))
            {
                currentStage = 0;
                thisSpriteRenderer.sprite = defaultSprite;

                if (!player.hasFood)
                    {
                        GameObject newFood = new GameObject();
                        newFood.AddComponent<Veggy>();
                        newFood.GetComponent<Veggy>().veggy = veggies[index];
                        Hand.setItem(newFood.GetComponent<Veggy>(), iconSprites[index]);
                        player.hasFood = true;
                    }
            }
        }
    }
    public void MoveIndex(int direction)
    {
        if(!isGrowing)
        {
            index+=direction;
            if (index < 0)
            {
                index = veggies.Count - 1;
            }
            else if(index >= veggies.Count)
            {
                index = 0;
            }
            iconSprite.sprite = iconSprites[index];
        }
        
    }

    public void GrowItem()
    {
        isGrowing = true;
    }
}

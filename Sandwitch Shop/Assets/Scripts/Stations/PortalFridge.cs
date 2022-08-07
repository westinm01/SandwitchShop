using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalFridge : Station
{
    public List<Ingredients.meat> meats = new List<Ingredients.meat>();
    private int index = 0;
    //private SpriteRenderer thisSpriteRenderer;
    
    private SpriteRenderer iconSprite;
    public List<Sprite> iconSprites = new List<Sprite>();

    public AudioClip itemSound;
    
    protected override void Start()
    {
        leftFunction = () => MoveIndex(-1);
        rightFunction = () => MoveIndex(1);
        actionFunction = () => SelectItem();
        iconSprite = this.gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        iconSprite.sprite = iconSprites[0];
    }

    
    protected override void Update()
    {
        base.Update();
        if(isSelected && Hand.getItem() == null)
        {
            player.GetComponent<Animator>().SetInteger("StationNumber", 7);
            player.gameObject.transform.position = new Vector3(player.gameObject.transform.position.x, -2f, -4f);
            
        }
        else if(Hand.getItem())
        {
            base.DeselectStation();
            /*player.GetComponent<Animator>().SetInteger("StationNumber", 0);
            player.gameObject.transform.position = new Vector3(player.gameObject.transform.position.x, -1.8f, 1f);*/
        }
        
        //play animation here?
    }

    public void MoveIndex(int direction)
    {

        index+=direction;
        if (index < 0)
        {
            index = meats.Count - 1;
        }
        else if (index >= meats.Count)
        {
            index = 0;
        }
        iconSprite.sprite = iconSprites[index];
         
    }

    public void SelectItem()
    {
        if(Hand.getItem() == null)
        {
            GameObject newFood = new GameObject();
            newFood.AddComponent<Meat>();
            newFood.GetComponent<Meat>().meat = meats[index];
            Hand.setItem(newFood.GetComponent<Meat>(), iconSprites[index]);
            base.DeselectStation();
            FindObjectOfType<MusicPlayer>().RecieveAndPlaySFX(itemSound);
        }
    }
}

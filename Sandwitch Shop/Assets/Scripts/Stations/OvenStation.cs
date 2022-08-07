using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenStation : Station
{
    // Start is called before the first frame update

    public float timeToBake = 5f;
    private float currentTime = 0f;

    private bool isBaking = false;
    private bool meatReady = false;

    private GameObject pan;
    public Sprite defaultPan;
    public Sprite rawPan;
    public Sprite cookedPan;

    private Ingredients.meat meatType;
    
    protected override void Start()
    {
        base.Start();
        actionFunction = () => Bake();
        pan = this.gameObject.transform.GetChild(0).gameObject;
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
         if(isBaking)
        {
            currentTime += Time.deltaTime;
            if(currentTime >= timeToBake)
            {
               
                meatReady = true;
                isBaking = false;
                pan.GetComponent<SpriteRenderer>().sprite = cookedPan;
            }
        }
    }

    void Bake()
    {
        if (Hand.getItem() != null && Hand.getItem().isBakable && !isBaking && !meatReady)
        {
            //meatType = Hand.getItem().TryGetComponent<Meat>().meat;
            player.hasFood = false; //need to drop item from Hand too...
            isBaking = true;
            pan.SetActive(true);
            pan.GetComponent<SpriteRenderer>().sprite = rawPan;
            Hand.dropItem();
        }
        else if (Hand.getItem() == null && !isBaking && meatReady)
        {
            //pan.SetActive(false);
            currentTime = 0;
            meatReady = false;
            player.hasFood = true;
            pan.GetComponent<SpriteRenderer>().sprite = defaultPan;
            pan.SetActive(false);
            
            //Meat cookedMeat = new Meat();
            //cookedMeat.meat = meatType;
            //Hand.setItem(cookedMeat, iconSprites[index]);// would be nice to make more brown cuz of the cooking
            //player.currentFood.isBaked = true;
            /*GameObject newFood = new GameObject();
            newFood.AddComponent<Bread>();
            newFood.GetComponent<Bread>().bread = breads[index];
            Hand.setItem(newFood.GetComponent<Bread>(), iconSprites[index]);
            player.hasFood = true;*/
        }
        
    }
}

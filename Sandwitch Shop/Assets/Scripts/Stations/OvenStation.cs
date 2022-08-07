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

    public Meat spriteHolder;
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
        if (Hand.getItem() != null && Hand.getItem().isBakable && Hand.getItem().isPunched && !isBaking && !meatReady)
        {
            //meatType = Hand.getItem().TryGetComponent<Meat>().meat;
            player.hasFood = false; //need to drop item from Hand too...
            isBaking = true;
            pan.SetActive(true);
            pan.GetComponent<SpriteRenderer>().sprite = rawPan;
            if(Hand.getItem().TryGetComponent<Meat>(out Meat heldMeat))
            {
                meatType = heldMeat.meat;
                Hand.dropItem();
            }
            
            
        }
        else if (Hand.getItem() == null && !isBaking && meatReady)
        {
            
            currentTime = 0;
            meatReady = false;

            pan.GetComponent<SpriteRenderer>().sprite = defaultPan;
            pan.SetActive(false);

            GameObject cookedFood = new GameObject();
            cookedFood.AddComponent<Meat>();
            cookedFood.GetComponent<Meat>().meat = meatType;
            cookedFood.GetComponent<Meat>().isReadyForAssembly = true;
            Hand.setItem(cookedFood.GetComponent<Meat>(), spriteHolder.GetSprite(cookedFood.GetComponent<Meat>().meat));
            player.hasFood = true;
            
        }
        
    }
}

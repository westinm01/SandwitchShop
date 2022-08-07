using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenStation : Station
{
    // Start is called before the first frame update

    public float timeToBake = 5f;
    private float currentTime = 0f;

    private bool isBaking = false;
    private bool meatReady = true;
    
    protected override void Start()
    {
        base.Start();
        actionFunction = () => Bake();
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
            }
        }
    }

    void Bake()
    {
        if (Hand.getItem() != null && player.currentFood.isBakable && !isBaking && !meatReady)
        {
            player.hasFood = false; //need to drop item from Hand too...
            isBaking = true;
        }
        else if (Hand.getItem() == null && !isBaking && meatReady)
        {
                        currentTime = 0;
                        meatReady = false;
                        //player.currentFood.isBaked = true;
                        /*GameObject newFood = new GameObject();
                        newFood.AddComponent<Bread>();
                        newFood.GetComponent<Bread>().bread = breads[index];
                        Hand.setItem(newFood.GetComponent<Bread>(), iconSprites[index]);
                        player.hasFood = true;*/
        }
        
    }
}

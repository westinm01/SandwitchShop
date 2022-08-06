using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashStation : Station
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if(isSelected){
            if(Input.GetKey("down")){
                if(Hand.getItem() == null){

                }else{
                    Hand.dropItem();
                    player.hasFood = false;
                }
            }
        }
    }
}

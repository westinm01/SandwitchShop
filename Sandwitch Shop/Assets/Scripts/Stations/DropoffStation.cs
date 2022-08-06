using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropoffStation : Station
{
    GeneratedOrder desiredSandwich;
    [SerializeField] OrderGenerator thePlaceWhereTheOrderGenerates;
    //these 2 on top can wait till we implement the window for food ordering
    [SerializeField] List<Food> foodOnPlate = new List<Food>();

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
                    foodOnPlate.Add(Hand.getItem());
                    Hand.dropItem();
                }
            }
        }
    }
}

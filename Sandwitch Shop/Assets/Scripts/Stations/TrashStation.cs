using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashStation : Station
{
    // Start is called before the first frame update
    private Animator thisAnimator;
    protected override void Start()
    {
        base.Start();
        thisAnimator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        //might need to access Player.currentFood
        base.Update();
        if(isSelected){
            if(Input.GetKey("down")){
                if(Hand.getItem() == null){

                }else{
                    Hand.dropItem();
                    player.hasFood = false;
                    thisAnimator.SetBool("ThrowAway", true);
                }
            }
        }
    }
}

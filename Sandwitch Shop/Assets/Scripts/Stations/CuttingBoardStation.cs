using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingBoardStation : Station
{
    //public Player player;
    protected override void Start()
    {
        base.Start();
        //assign buttons
        actionFunction = () => Cut();
    }

/*
    protected override void Update()
    {
        base.Update();
    }
    */
    void Cut(){
        if(player.hasFood && player.currentFood.isCuttable){
            //play cut animation
            //change currentFood's sprite
        }
    }
}

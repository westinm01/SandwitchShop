using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingBoardStation : Station
{

    public Sprite defaultSprite;
    public Sprite cuttingSprite;
    public SpriteRenderer thisSpriteRenderer;

    public int numberOfCuts = 15;
    private int cutsMade = 0;
    public bool isCutting = false;
    public bool doneCutting = false;

    //public Player player;
    protected override void Start()
    {
        base.Start();
        //assign buttons
        actionFunction = () => Cut();
        thisSpriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }


    protected override void Update()
    {
        base.Update();
        if(doneCutting)
        {
            if(Input.GetKeyUp(KeyCode.DownArrow))
            {
                //set a flag indicating that the veggy has been cut.
                thisSpriteRenderer.sprite = defaultSprite;
                doneCutting = false;
            }
        }
    }
    
    void Cut(){
        
        if(Hand.getItem().isCuttable && !Hand.getItem().isReadyForAssembly && !doneCutting){
            thisSpriteRenderer.sprite = cuttingSprite;
            cutsMade++;
            isCutting = true;
            //play cut animation
            if(cutsMade >= numberOfCuts)
            {
                doneCutting = true;
                isCutting = false;
                cutsMade = 0;
                Hand.getItem().isReadyForAssembly = true;
            }
            
        }
        else{
            
            if(!Hand.getItem().isCuttable)
            {
                Debug.Log("Not holding veggy");
            }
            else{
                Debug.Log("Cannot Cut");
            }
            
        }
    }
}

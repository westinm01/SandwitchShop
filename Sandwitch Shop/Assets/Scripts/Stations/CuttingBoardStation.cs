using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingBoardStation : Station
{

    public Sprite defaultSprite;
    public Sprite cuttingSprite;
    public SpriteRenderer thisSpriteRenderer;
    private SpriteRenderer playerArms;

    public Sprite knifeUp;
    public Sprite knifeDown;

    public int numberOfCuts = 15;
    private int cutsMade = 0;
    public bool isCutting = false;
    public bool doneCutting = false;

    public bool isPunching = false;
    public bool donePunching = false;

    //public Player player;
    protected override void Start()
    {
        base.Start();
        //assign buttons
        actionFunction = () => Cut();
        thisSpriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        playerArms = player.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
    }


    protected override void Update()
    {
        
        base.Update();
        if(doneCutting)
        {
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                //set a flag indicating that the veggy has been cut.
                thisSpriteRenderer.sprite = defaultSprite;
                doneCutting = false;
            }
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow) && isCutting)
        {
            playerArms.sprite = knifeUp;
        }
    }
    
    void Cut(){
        
        if(Hand.getItem().isCuttable && !Hand.getItem().isReadyForAssembly && !doneCutting){
            thisSpriteRenderer.sprite = cuttingSprite;
            cutsMade++;
            isCutting = true;
            //play cut animation
            playerArms.sprite = knifeDown;

            if(cutsMade >= numberOfCuts)
            {
                playerArms.sprite = null;
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
    /*
    void Punch(){
        if(Hand.getItem().isPunchable && !Hand.getItem().isPunched && !donePunching)
        {
            cutsMade++;
            isPunching = true;
            //play punching animation;
            

            if(cutsMade >= numberOfCuts)
            {
                doneCutting = true;
                cutsMade = 0;
                Hand.getItem().isReadyForAssembly = true;
            }
        }
    }*/
}

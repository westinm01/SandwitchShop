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

    public Sprite punchDefault;
    public Sprite punchLeft;
    public Sprite punchRight;
    private bool LRChoose = false;

    public bool isPunching = false;
    public bool donePunching = false;

    
    private SpriteRenderer foodSpriteRenderer;
    public List<Sprite> foodCutSprites = new List<Sprite>();
    private int fcsIndex;
    public List <Sprite> foodPunchSprites = new List<Sprite>();
    private int fpsIndex;
    
    public AudioClip cutAudio;
    public AudioClip punchAudio;
    //public Player player;
    protected override void Start()
    {
        base.Start();
        //assign buttons
        actionFunction = () => Cut();
        thisSpriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        playerArms = player.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        foodSpriteRenderer = this.gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
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
                foodSpriteRenderer.sprite = null;
            }
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow) && isCutting)
        {
            playerArms.sprite = knifeUp;
            //foodSpriteRenderer.sprite = foodPunchSprites[fpsIndex];
        }
        else if(Input.GetKeyUp(KeyCode.DownArrow) && isPunching)
        {
            playerArms.sprite = punchDefault;
            foodSpriteRenderer.sprite = foodPunchSprites[fpsIndex];
        }
    }
    
    void Cut(){
        //for Veggies
        if(Hand.getItem().isCuttable && !Hand.getItem().isReadyForAssembly && !doneCutting){
            canQuit = false;
            thisSpriteRenderer.sprite = cuttingSprite;
            cutsMade++;
            isCutting = true;
            //play cut animation
            playerArms.sprite = knifeDown;

            if(Hand.getItem().TryGetComponent<Veggy>(out Veggy heldVeggy))
            {
                switch (heldVeggy.veggy){
                    case Ingredients.veggy.Potato:
                        fcsIndex = 0;
                    break;
                    case Ingredients.veggy.Lettuce:
                        fcsIndex = 1;
                    break;
                    case Ingredients.veggy.Tomato:
                        fcsIndex = 2;
                    break;
                    case Ingredients.veggy.Onion:
                        fcsIndex = 3;
                    break;
                    case Ingredients.veggy.Mushroom:
                        fcsIndex = 4;
                    break;
                    default:
                    break;
                }
                foodSpriteRenderer.sprite = foodCutSprites[fcsIndex];
            }

            FindObjectOfType<MusicPlayer>().RecieveAndPlaySFX(cutAudio);
            if(cutsMade >= numberOfCuts)
            {
                playerArms.sprite = null;
                doneCutting = true;
                isCutting = false;
                cutsMade = 0;
                Hand.getItem().isReadyForAssembly = true;
                canQuit = true;
            }
            
        }
        //for Meats
        else if(Hand.getItem().isPunchable && !Hand.getItem().isPunched && !doneCutting)
        {
            canQuit = false;
            if(Hand.getItem().TryGetComponent<Meat>(out Meat heldMeat))
            {
                switch (heldMeat.meat){
                    case Ingredients.meat.Frog:
                        fpsIndex = 0;
                    break;
                    case Ingredients.meat.Dragon:
                        fpsIndex = 2;
                    break;
                    case Ingredients.meat.Jelly:
                        fpsIndex = 4;
                    break;
                    case Ingredients.meat.Piranha:
                        fpsIndex = 6;
                    break;
                    case Ingredients.meat.Cthulu:
                        fpsIndex = 8;
                    break;
                    case Ingredients.meat.RollyPolly:
                        fpsIndex = 10;
                    break;
                    default:
                    break;
                }
            }
            
            cutsMade++;
            isPunching = true;
            FindObjectOfType<MusicPlayer>().RecieveAndPlaySFX(punchAudio);
            if(LRChoose)
            {
                playerArms.sprite = punchLeft;
            }
            else{
                playerArms.sprite = punchRight;
            }
            LRChoose = !LRChoose;

            foodSpriteRenderer.sprite = foodPunchSprites[fpsIndex + 1];

            if(cutsMade >= numberOfCuts)
            {
                playerArms.sprite = null;
                doneCutting = true;
                isPunching = false;
                cutsMade = 0;
                Hand.getItem().isPunched = true;
                canQuit = true;
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

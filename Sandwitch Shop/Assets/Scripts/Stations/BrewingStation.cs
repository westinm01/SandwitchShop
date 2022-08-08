using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrewingStation : Station
{
    public List<Ingredients.dressing> dressings = new List<Ingredients.dressing>();
    [SerializeField] public List<KeyCode> sequenceOfBrewing = new List<KeyCode>();
    [SerializeField] public List<KeyCode> playerSequence = new List<KeyCode>();
    [SerializeField] int whichAction = -1;
    [SerializeField] public GameObject objects;
    [SerializeField] public Sprite arrowDown;
    [SerializeField] public Sprite arrowLeft;
    [SerializeField] public Sprite arrowRight;
    [SerializeField] public RuntimeAnimatorController poofSmoke;
    [SerializeField] public GameObject brewText;

    private int index = 0;
    private SpriteRenderer thisSpriteRenderer;
    public Sprite defaultSprite;
    public Sprite defaultSprite2;
    public Sprite brewingSprite;
    public Sprite doneSprite;
    private SpriteRenderer iconSprite;
    public List<Sprite> iconSprites = new List<Sprite>();

    [SerializeField] bool beginBrew = false;

    public AudioClip itemSound;
    public AudioClip brewSound;
    // Start is called before the first frame update
    protected override void Start()
    {
        brewText = GameObject.FindWithTag("BrewText");
        brewText.SetActive(false);
        dressings.Add(Ingredients.dressing.Vinegar);//0
        dressings.Add(Ingredients.dressing.Ketchup);//1
        dressings.Add(Ingredients.dressing.Mustard);//2
        index = 0;
        whichAction = -1;
        base.Start();

        sequenceOfBrewing = new List<KeyCode>();
        playerSequence = new List<KeyCode>();
        List<KeyCode> allTheInputs = new List<KeyCode>();
        allTheInputs.Add(KeyCode.DownArrow);
        allTheInputs.Add(KeyCode.LeftArrow);
        allTheInputs.Add(KeyCode.RightArrow);
        for(int i=0; i<16; ++i){
            int randInput = Mathf.RoundToInt(Random.Range(0, 3));
            if(randInput == 3){
                randInput = 2;
            }
            sequenceOfBrewing.Add(allTheInputs[randInput]);
        }

        thisSpriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        thisSpriteRenderer.sprite = defaultSprite;
        iconSprite = this.gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        //iconSprite.sprite = iconSprites[0];

        leftFunction = () => MoveIndex(-1);
        rightFunction = () => MoveIndex(1);
        actionFunction = () => Brew();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if(isSelected && beginBrew){
            brewText.SetActive(true);
            if(whichAction < 0){
                //thisSpriteRenderer.sprite = defaultSprite;
                objects.SetActive(true);
            }else if(whichAction < 3){
                if(playerSequence[playerSequence.Count-1] == sequenceOfBrewing[playerSequence.Count-1]){
                    thisSpriteRenderer.sprite = defaultSprite;
                }else{
                    playerSequence.RemoveAt(playerSequence.Count-1);
                    whichAction--;
                    StartCoroutine(stun());
                }
            }else if(whichAction < 7){
                if(playerSequence[playerSequence.Count-1] == sequenceOfBrewing[playerSequence.Count-1]){
                    thisSpriteRenderer.sprite = defaultSprite2;
                }else{
                    playerSequence.RemoveAt(playerSequence.Count-1);
                    whichAction--;
                    StartCoroutine(stun());
                }
            }else if(whichAction < 15){
                if(playerSequence[playerSequence.Count-1] == sequenceOfBrewing[playerSequence.Count-1]){
                    thisSpriteRenderer.sprite = brewingSprite;
                }else{
                    playerSequence.RemoveAt(playerSequence.Count-1);
                    whichAction--;
                    StartCoroutine(stun());
                }
            }else{
                if(playerSequence.Count > sequenceOfBrewing.Count){
                    playerSequence.RemoveAt(playerSequence.Count-1);
                    whichAction--;
                }else if(playerSequence[playerSequence.Count-1] == sequenceOfBrewing[playerSequence.Count-1]){
                    thisSpriteRenderer.sprite = doneSprite;
                    brewText.SetActive(false);
                    if (Hand.getItem() == null){
                        GameObject newFood = new GameObject();
                        newFood.AddComponent<Dressing>();
                        newFood.GetComponent<Dressing>().dressing = dressings[index];
                        newFood.GetComponent<Dressing>().isReadyForAssembly = true;
                        Hand.setItem(newFood.GetComponent<Dressing>(), iconSprites[index]);
                        player.hasFood = true;
                        FindObjectOfType<MusicPlayer>().RecieveAndPlaySFX(itemSound);
                    }
                }else{
                    playerSequence.RemoveAt(playerSequence.Count-1);
                    whichAction--;
                    StartCoroutine(stun());
                }
            }
            checkPics();
        }else if(!isSelected && thisSpriteRenderer.sprite == doneSprite){
            brewText.SetActive(false);
            thisSpriteRenderer.sprite = defaultSprite;
            sequenceOfBrewing = new List<KeyCode>();
            playerSequence = new List<KeyCode>();
            List<KeyCode> allTheInputs = new List<KeyCode>();
            allTheInputs.Add(KeyCode.DownArrow);
            allTheInputs.Add(KeyCode.LeftArrow);
            allTheInputs.Add(KeyCode.RightArrow);
            for(int i=0; i<16; ++i){
                int randInput = Mathf.RoundToInt(Random.Range(0, 3));
                if(randInput == 3){
                    randInput = 2;
                }
                sequenceOfBrewing.Add(allTheInputs[randInput]);
            }
            //index = 0;
            whichAction = -1;
            for(int i=0; i<16; ++i){
                objects.transform.GetChild(i).gameObject.SetActive(true);
                objects.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().sprite = null;
            }
            beginBrew = false;
            leftFunction = () => MoveIndex(-1);
            rightFunction = () => MoveIndex(1);
            actionFunction = () => Brew();
        }
    }

    IEnumerator stun(){
        objects.transform.GetChild(playerSequence.Count).gameObject.GetComponent<Animator>().runtimeAnimatorController = poofSmoke;
        objects.transform.GetChild(playerSequence.Count).gameObject.GetComponent<Animator>().SetBool("smokeCloudAnim", true);
        beginBrew = false;
        leftFunction = () => doNothing();
        rightFunction = () => doNothing();
        actionFunction = () => doNothing();
        yield return new WaitForSeconds(0.5f);
        objects.transform.GetChild(playerSequence.Count).gameObject.GetComponent<Animator>().SetBool("smokeCloudAnim", false);
        objects.transform.GetChild(playerSequence.Count).gameObject.GetComponent<Animator>().runtimeAnimatorController = null;
        Brew();
        StopCoroutine(stun());
    }

    void doNothing(){

    }

    void Brew(){
        beginBrew = true;
        leftFunction = () => brewLeft();
        rightFunction = () => brewRight();
        actionFunction = () => brewDown();
        putPics();
        FindObjectOfType<MusicPlayer>().RecieveAndPlaySFX(brewSound);
    }

    void putPics(){
        for(int i=0; i<16; ++i){
            Sprite whatToDisplay;
            if(sequenceOfBrewing[i] == KeyCode.DownArrow){
                whatToDisplay = arrowDown;
            }else if(sequenceOfBrewing[i] == KeyCode.LeftArrow){
                whatToDisplay = arrowLeft;
            }else{
                whatToDisplay = arrowRight;
            }
            objects.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().sprite = whatToDisplay;
        }
    }

    void checkPics(){
        //objects.transform.GetChild(whichAction+1).gameObject.SetActive(false);
        if(whichAction == -1){

        }else{
            objects.transform.GetChild(whichAction).gameObject.SetActive(false);
        }
    }

    void brewLeft(){
        playerSequence.Add(KeyCode.LeftArrow);
        whichAction++;
    }

    void brewRight(){
        playerSequence.Add(KeyCode.RightArrow);
        whichAction++;
    }

    void brewDown(){
        playerSequence.Add(KeyCode.DownArrow);
        whichAction++;
    }

    public void MoveIndex(int direction)
    {
        if(!beginBrew){
            Debug.Log(index);
            index+=direction;
            if (index < 0){
                index = dressings.Count - 1;
            }
            else if(index >= dressings.Count){
                index = 0;
            }
            iconSprite.sprite = iconSprites[index];
        }
    }
}

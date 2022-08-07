using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToastStation : Station
{
    public List<Ingredients.bread> breads = new List<Ingredients.bread>();
    private int index = 0;
    private SpriteRenderer thisSpriteRenderer;
    public Sprite defaultSprite;
    public Sprite toastingSprite;
    public Sprite doneSprite;
    private SpriteRenderer iconSprite;
    public List<Sprite> iconSprites = new List<Sprite>();

    private bool isToasting = false;
    public float timeToToast = 10.0f;
    private float currentTime = 0.0f;
    private bool breadReady = false;

    public AudioClip breadIn;
    public AudioClip breadOut;

    public AudioClip itemSound;

    
    // Start is called before the first frame update
    protected override void Start()
    {
        breads.Add(Ingredients.bread.Sourdough);//0
        breads.Add(Ingredients.bread.White);//1
        breads.Add(Ingredients.bread.WholeGrain);//2
        base.Start();

        thisSpriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        iconSprite = this.gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        iconSprite.sprite = iconSprites[0];

        leftFunction = () => MoveIndex(-1);
        rightFunction = () => MoveIndex(1);
        actionFunction = () => Toast();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if(isToasting)
        {
            currentTime += Time.deltaTime;
            if(currentTime >= timeToToast)
            {
               thisSpriteRenderer.sprite = doneSprite;
                breadReady = true;
                isToasting = false;
                FindObjectOfType<MusicPlayer>().RecieveAndPlaySFX(breadOut);
            }
        }
    }

    public void MoveIndex(int direction)
    {
        if(!isToasting && !breadReady)
        {
            index+=direction;
            if (index < 0)
            {
                index = breads.Count - 1;
            }
            else if(index >= breads.Count)
            {
                index = 0;
            }
            iconSprite.sprite = iconSprites[index];
        }
        
    }

    void Toast()
    {
        if(!breadReady)
        {
            isToasting = true;
            thisSpriteRenderer.sprite = toastingSprite;
            FindObjectOfType<MusicPlayer>().RecieveAndPlaySFX(breadIn);
        }
        else
        {
            if (Hand.getItem() == null)
                    {
                        thisSpriteRenderer.sprite = defaultSprite;
                        currentTime = 0;
                        GameObject newFood = new GameObject();
                        newFood.AddComponent<Bread>();
                        newFood.GetComponent<Bread>().bread = breads[index];
                        newFood.GetComponent<Bread>().isReadyForAssembly = true;
                        Hand.setItem(newFood.GetComponent<Bread>(), iconSprites[index]);
                        player.hasFood = true;
                        breadReady = false;
                        FindObjectOfType<MusicPlayer>().RecieveAndPlaySFX(itemSound);
                    }
        }
        
    }
}

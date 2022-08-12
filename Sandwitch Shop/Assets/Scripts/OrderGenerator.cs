using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderGenerator : MonoBehaviour
{
    // Order Stats and Variables
    [SerializeField] int ordersInRound = 7;
    [SerializeField] float timePerOrder = 20f;
    [SerializeField] float bossOrderTime = 30f;
    [SerializeField] int orderScoreValue = 1000;

    // Boss sandwich
    [SerializeField] Ingredients.bread bossBread;
    [SerializeField] Ingredients.meat bossMeat;
    [SerializeField] Ingredients.veggy bossVeggy;

    // Images for Order Menu
    [SerializeField] Image breadImage;
    [SerializeField] Image meatImage;
    [SerializeField] Image veggyImage;
    [SerializeField] Image dressingImage;

    // checkmarks
    [SerializeField] GameObject checkMark;
    [SerializeField] GameObject parentForChecks;
    private Queue<GameObject> checkMarks = new Queue<GameObject>();
    

    // Private Variables
    int ordersComplete = 0;
    bool orderInProgress = false;
    GeneratedOrder currentOrder = null;

    // Cached References
    OrderStation orderStation;
    OrderTimer orderTimer;
    System.Random random = new System.Random();

    private void Start()
    {
        orderTimer = FindObjectOfType<OrderTimer>();
        orderStation = FindObjectOfType<OrderStation>();
        orderTimer.UpdateMaxTime(timePerOrder);
        GenerateRandomOrder();
    }

    private void Update()
    {
        
        if((ordersComplete < ordersInRound) && !orderInProgress)
        {
            GenerateRandomOrder();
        } 
        else if((ordersComplete == ordersInRound) && !orderInProgress)
        {
            GenerateBossOrder();
        } 
        else if((ordersComplete > ordersInRound) && !orderInProgress)
        {
            FindObjectOfType<LevelManager>().WinGame();
        }
    }

    private void GenerateRandomOrder()
    {
        orderInProgress = true;

        // Update the slider
        orderTimer.UpdateMaxTime(timePerOrder);

        // Get random ingredients
        Ingredients.bread randomBread = GetRandomBread();
        Ingredients.meat randomMeat = GetRandomMeat();
        Ingredients.veggy randomVeggy = GetRandomVeggy();
        Ingredients.dressing randomDressing = GetRandomDressing();

        // Create the order with the 4 random items
        GeneratedOrder order = new GeneratedOrder
        {
            bread = randomBread,
            meat = randomMeat,
            veggy = randomVeggy,
            dressing = randomDressing
        };

        currentOrder = order;
        orderStation.RecieveDesiredOrder(currentOrder);
        // Update UI to show the 4 random items
        breadImage.sprite = this.gameObject.transform.GetChild(0).GetComponent<Bread>().GetSprite(randomBread);
        meatImage.sprite = this.gameObject.transform.GetChild(0).GetComponent<Meat>().GetSprite(randomMeat);
        veggyImage.sprite = this.gameObject.transform.GetChild(0).GetComponent<Veggy>().GetSprite(randomVeggy);
        dressingImage.sprite = this.gameObject.transform.GetChild(0).GetComponent<Dressing>().GetSprite(randomDressing);

        
    }

    private void GenerateBossOrder()
    {
        orderInProgress = true;
        FindObjectOfType<LevelManager>().PlayLevelBossMusic();
        FindObjectOfType<LevelManager>().ActivateBossImage();

        // Update Slider to use boss order time
        orderTimer.UpdateMaxTime(bossOrderTime);

        // Create the order with the 4 items
        GeneratedOrder bossOrder = new GeneratedOrder
        {
            bread = bossBread,
            meat = bossMeat,
            veggy = bossVeggy,
            dressing = Ingredients.dressing.NoDressing
        };
        // Update UI to show the 4 items
        
        breadImage.sprite = this.gameObject.transform.GetChild(0).GetComponent<Bread>().GetSprite(bossBread);
        meatImage.sprite = this.gameObject.transform.GetChild(0).GetComponent<Meat>().GetSprite(bossMeat);
        veggyImage.sprite = this.gameObject.transform.GetChild(0).GetComponent<Veggy>().GetSprite(bossVeggy);
        dressingImage.sprite = this.gameObject.transform.GetChild(0).GetComponent<Dressing>().GetSprite(Ingredients.dressing.NoDressing);

        currentOrder = bossOrder;
        orderStation.RecieveDesiredOrder(currentOrder);
    }

    public void CompleteOrder()
    {
        orderInProgress = false;
        ordersComplete++;
        ResetChecks();
        //FindObjectOfType<ScoreKeeper>().AddScore(orderScoreValue);
    }

    private Ingredients.bread GetRandomBread()
    {
        int randomInt = UnityEngine.Random.Range(0,2);
        Ingredients.bread randomBread = Ingredients.bread.Sourdough;
        switch(randomInt)
        {
            case 0:
                randomBread = Ingredients.bread.Sourdough;
                break;
            case 1:
                randomBread = Ingredients.bread.White;
            break;
            case 2:
                randomBread = Ingredients.bread.WholeGrain;
            break;
            
        }
        /*Type type = typeof(Ingredients.bread);
        Array values = type.GetEnumValues();
        int index = random.Next(values.Length);
        Ingredients.bread randomBread = (Ingredients.bread)values.GetValue(index);*/
        return randomBread;
    }
    private void ResetChecks()
    {
        while(checkMarks.Count > 0)
        {
            Destroy(checkMarks.Dequeue());
        }
    }

    public void CheckBread()
    {
        GameObject check = Instantiate(checkMark, breadImage.transform.position, Quaternion.identity);
        check.transform.parent = parentForChecks.transform;
        checkMarks.Enqueue(check);
    }
    public void CheckMeat()
    {
        GameObject check = Instantiate(checkMark, meatImage.transform.position, Quaternion.identity);
        check.transform.parent = parentForChecks.transform;
        checkMarks.Enqueue(check);
    }
    public void CheckVeggy()
    {
        GameObject check = Instantiate(checkMark, veggyImage.transform.position, Quaternion.identity);
        check.transform.parent = parentForChecks.transform;
        checkMarks.Enqueue(check);
    }
    public void CheckDressing()
    {
        GameObject check = Instantiate(checkMark, dressingImage.transform.position, Quaternion.identity);
        check.transform.parent = parentForChecks.transform;
        checkMarks.Enqueue(check);
    }

    private Ingredients.meat GetRandomMeat()
    {
        int randomInt = UnityEngine.Random.Range(0,6); //not maximally inclusive for integers
        Ingredients.meat randomMeat = Ingredients.meat.Frog;
        switch(randomInt)
        {
            case 0:
                randomMeat = Ingredients.meat.Frog;
                break;
            case 1:
                randomMeat = Ingredients.meat.Dragon;
            break;
            case 2:
                randomMeat = Ingredients.meat.Jelly;
            break;
            case 3:
                randomMeat = Ingredients.meat.Piranha;
            break;
            case 4:
                randomMeat = Ingredients.meat.Cthulu;
            break;
            case 5:
                randomMeat = Ingredients.meat.RollyPolly;
            break;
            default:
                randomMeat = Ingredients.meat.RollyPolly;
            break;
            
        }
        /*
        Type type = typeof(Ingredients.meat);
        Array values = type.GetEnumValues();
        int index = random.Next(values.Length);
        Ingredients.meat randomMeat = (Ingredients.meat)values.GetValue(index);*/
        return randomMeat;
    }
    private Ingredients.veggy GetRandomVeggy()
    {

        int randomInt = UnityEngine.Random.Range(0,5);
        Ingredients.veggy randomVeggy = Ingredients.veggy.Potato;
        switch(randomInt)
        {
            case 0:
                randomVeggy = Ingredients.veggy.Potato;
                break;
            case 1:
                randomVeggy = Ingredients.veggy.Lettuce;
            break;
            case 2:
                randomVeggy = Ingredients.veggy.Tomato;
            break;
            case 3:
                randomVeggy = Ingredients.veggy.Onion;
            break;
            case 4:
                randomVeggy = Ingredients.veggy.Mushroom;
            break;
            default:
                randomVeggy = Ingredients.veggy.Mushroom;
            break;
        } 
        /*
        Type type = typeof(Ingredients.veggy);
        Array values = type.GetEnumValues();
        int index = random.Next(values.Length);
        Ingredients.veggy randomVeggy = (Ingredients.veggy)values.GetValue(index);*/
        return randomVeggy;
    }
    private Ingredients.dressing GetRandomDressing()
    {

        int randomInt = UnityEngine.Random.Range(0,3); //not maximally inclusive for integers
        Ingredients.dressing randomDressing = Ingredients.dressing.Vinegar;
        switch(randomInt)
        {
            case 0:
                randomDressing = Ingredients.dressing.Vinegar;
                break;
            case 1:
                randomDressing = Ingredients.dressing.Ketchup;
            break;
            case 2:
                randomDressing = Ingredients.dressing.Mustard;
            break;
            default:
                randomDressing = Ingredients.dressing.Mustard;
            break;
            
        }
        /*
        Type type = typeof(Ingredients.dressing);
        Array values = type.GetEnumValues();
        int index = random.Next(values.Length);
        Ingredients.dressing randomDressing = (Ingredients.dressing)values.GetValue(index);*/
        return randomDressing;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderGenerator : MonoBehaviour
{
    // Game Stats
    [SerializeField] int ordersInRound = 7;
    [SerializeField] OrderTimer orderTimer;
    [SerializeField] float timePerOrder = 20f;
    [SerializeField] float bossOrderTime = 30f;

    // Boss sandwich
    [SerializeField] Ingredients.bread bossBread;
    [SerializeField] Ingredients.meat bossMeat;
    [SerializeField] Ingredients.veggy bossVeggy;
    [SerializeField] Ingredients.dressing bossDressing;

    // Images for Order Menu
    [SerializeField] Image breadImage;
    [SerializeField] Image meatImage;
    [SerializeField] Image veggyImage;
    [SerializeField] Image dressingImage;

    // Private Variables
    int ordersComplete = 0;
    bool orderInProgress = false;

    System.Random random = new System.Random();

    private void Awake()
    {
        orderTimer.UpdateMaxTime(timePerOrder);
    }

    private void Update()
    {
        if((ordersComplete < ordersInRound) && !orderInProgress)
        {
            GenerateRandomOrder();
        } 
        else if(ordersComplete == ordersInRound)
        {
            GenerateBossOrder();
        }
    }

    private GeneratedOrder GenerateRandomOrder()
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
        // Update UI to show the 4 random items
        breadImage.sprite = FindObjectOfType<Bread>().GetSprite(randomBread);
        meatImage.sprite = FindObjectOfType<Meat>().GetSprite(randomMeat);
        veggyImage.sprite = FindObjectOfType<Veggy>().GetSprite(randomVeggy);
        dressingImage.sprite = FindObjectOfType<Dressing>().GetSprite(randomDressing);

        return order;
    }

    private GeneratedOrder GenerateBossOrder()
    {
        // Update Slider to use boss order time
        orderTimer.UpdateMaxTime(bossOrderTime);

        // Create the order with the 4 items
        GeneratedOrder bossOrder = new GeneratedOrder
        {
            bread = bossBread,
            meat = bossMeat,
            veggy = bossVeggy,
            dressing = bossDressing
        };
        // Update UI to show the 4 items
        breadImage.sprite = FindObjectOfType<Bread>().GetSprite(bossBread);
        meatImage.sprite = FindObjectOfType<Meat>().GetSprite(bossMeat);
        veggyImage.sprite = FindObjectOfType<Veggy>().GetSprite(bossVeggy);
        dressingImage.sprite = FindObjectOfType<Dressing>().GetSprite(bossDressing);

        return bossOrder;
    }

    public void OrderComplete()
    {
        orderInProgress = false;
        ordersComplete++;
    }

    private Ingredients.bread GetRandomBread()
    {
        Type type = typeof(Ingredients.bread);
        Array values = type.GetEnumValues();
        int index = random.Next(values.Length);
        Ingredients.bread randomBread = (Ingredients.bread)values.GetValue(index);
        return randomBread;
    }
    private Ingredients.meat GetRandomMeat()
    {
        Type type = typeof(Ingredients.meat);
        Array values = type.GetEnumValues();
        int index = random.Next(values.Length);
        Ingredients.meat randomMeat = (Ingredients.meat)values.GetValue(index);
        return randomMeat;
    }
    private Ingredients.veggy GetRandomVeggy()
    {
        Type type = typeof(Ingredients.veggy);
        Array values = type.GetEnumValues();
        int index = random.Next(values.Length);
        Ingredients.veggy randomVeggy = (Ingredients.veggy)values.GetValue(index);
        return randomVeggy;
    }
    private Ingredients.dressing GetRandomDressing()
    {
        Type type = typeof(Ingredients.dressing);
        Array values = type.GetEnumValues();
        int index = random.Next(values.Length);
        Ingredients.dressing randomDressing = (Ingredients.dressing)values.GetValue(index);
        return randomDressing;
    }
}

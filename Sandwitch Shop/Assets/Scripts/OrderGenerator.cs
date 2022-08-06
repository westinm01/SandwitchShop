using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderGenerator : MonoBehaviour
{
    [SerializeField] int ordersInRound = 7;
    [SerializeField] float timePerOrder = 20f;
    [SerializeField] float bossOrderTime = 30f;
    [SerializeField] Ingredients.bread bossBread;
    [SerializeField] Ingredients.meat bossMeat;
    [SerializeField] Ingredients.veggy bossVeggy;
    [SerializeField] Ingredients.dressing bossDressing;

    [SerializeField] Image breadImage;
    [SerializeField] Image meatImage;
    [SerializeField] Image veggyImage;
    [SerializeField] Image dressingImage;

    System.Random random = new System.Random();

    private void Awake()
    {
        GenerateOrder();
    }

    private GeneratedOrder GenerateOrder()
    {
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

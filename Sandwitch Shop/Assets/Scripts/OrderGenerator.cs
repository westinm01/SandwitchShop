using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderGenerator : MonoBehaviour
{
    System.Random random = new System.Random();

    private GeneratedOrder GenerateOrder()
    {
        Ingredients.bread randomBread = GetRandomBread();
        Ingredients.meat randomMeat = GetRandomMeat();
        Ingredients.veggy randomVeggy = GetRandomVeggy();
        Ingredients.dressing randomDressing = GetRandomDressing();

        GeneratedOrder order = new GeneratedOrder
        {
            bread = randomBread,
            meat = randomMeat,
            veggy = randomVeggy,
            dressing = randomDressing
        };

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

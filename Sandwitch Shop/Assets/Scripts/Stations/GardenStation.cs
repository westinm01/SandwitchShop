using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenStation : Station
{
    public List<Ingredients.veggy> veggies = new List<Ingredients.veggy>();
    private int index = 0;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        veggies.Add(Ingredients.veggy.Potato);
        veggies.Add(Ingredients.veggy.Lettuce);
        veggies.Add(Ingredients.veggy.Tomato);
        veggies.Add(Ingredients.veggy.Onion);
        veggies.Add(Ingredients.veggy.Mushroom);

        leftFunction = () => MoveIndex(-1);
        rightFunction = () => MoveIndex(1);
        actionFunction = () => GrowItem();
    }

    public void MoveIndex(int direction)
    {
        index+=direction;
        if (index < 0)
        {
            index = veggies.Count - 1;
        }
        else if(index >= veggies.Count)
        {
            index = 0;
        }
    }

    public void GrowItem()
    {
        if (!player.hasFood)
        {
            GameObject newFood = new GameObject();
            newFood.AddComponent<Veggy>();
            newFood.GetComponent<Veggy>().veggy = veggies[index];
            player.hasFood = true;
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenStation : Station
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        actionFunction = () => Bake();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    void Bake()
    {
        if (player.hasFood && player.currentFood.isBakable)
        {
            player.currentFood.isBaked = true;
            player.hasFood = false;
        }
    }
}

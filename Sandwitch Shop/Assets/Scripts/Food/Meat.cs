using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meat : Food
{
    public Ingredients.meat meat;
    // Start is called before the first frame update
    protected override void Start()
    {
        isCuttable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

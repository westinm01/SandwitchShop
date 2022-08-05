using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Veggy : Food
{
    public Ingredients.veggy veggy;
    // Start is called before the first frame update
    protected override void Start()
    {
        isCuttable = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

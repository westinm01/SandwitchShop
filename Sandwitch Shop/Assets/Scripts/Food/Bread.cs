using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bread : Food
{
    public Ingredients.bread bread;
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

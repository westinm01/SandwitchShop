using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Veggy : Food
{
    public Ingredients.veggy veggy;
    //public bool isCut;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        isCuttable = true;
        //isCut = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

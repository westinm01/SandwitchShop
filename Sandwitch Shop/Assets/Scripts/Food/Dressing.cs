using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dressing : Food
{
    public Ingredients.dressing dressing;
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

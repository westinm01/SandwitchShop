using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Station : MonoBehaviour
{

    public bool isSelected;
    
    public bool hasFood;

    Action leftFunction;
    Action rightFunction;
    Action actionFunction;


    // Start is called before the first frame update
    void Start()
    {
        isSelected = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void leftPress(){

    }
    protected void rightPress(){

    }
    protected void actionPress(){

    }
}

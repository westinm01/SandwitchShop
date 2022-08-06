using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Station : MonoBehaviour
{

    public bool isSelected;
    public Player player;

    protected Action leftFunction;
    protected Action rightFunction;
    protected Action actionFunction;
    //These are defined in derived classes.


    // Start is called before the first frame update
    protected virtual void Start()
    {
        isSelected = false;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if(isSelected)
        {
            if(Input.GetKeyDown(KeyCode.LeftArrow) && Input.GetKeyDown(KeyCode.RightArrow) && Input.GetKeyDown(KeyCode.DownArrow))
            {
                isSelected = false;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                leftFunction();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                rightFunction();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                actionFunction();
            }
        }
    }
}

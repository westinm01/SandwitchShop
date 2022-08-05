using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Station : MonoBehaviour
{

    public bool isSelected;

    protected Action leftFunction;
    protected Action rightFunction;
    protected Action actionFunction;
    //These are defined in derived classes.


    // Start is called before the first frame update
    void Start()
    {
        isSelected = false;
    }

    // Update is called once per frame
    void Update()
    {
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

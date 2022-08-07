using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Station : MonoBehaviour
{

    public bool isSelected;
    //public SelectStation ss;
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
                player.GetComponent<Animator>().SetInteger("StationNumber", 0);
                isSelected = false;
                player.gameObject.transform.position = new Vector3(0f, -1.8f, 1f);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
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

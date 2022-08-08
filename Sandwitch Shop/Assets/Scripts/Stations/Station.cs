using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public abstract class Station : MonoBehaviour
{

    public bool isSelected;
    public bool canQuit = true;
    //public SelectStation ss;
    public Player player;

    protected Action leftFunction;
    protected Action rightFunction;
    protected Action actionFunction;

    public GameObject instruction;
    //protected GameObject instructionCanvas;
    public GameObject defaultInstruction;
    //These are defined in derived classes.
    

    // Start is called before the first frame update
    protected virtual void Start()
    {
        isSelected = false;
        leftFunction = () => placeHolder();
        rightFunction = () => placeHolder();
        actionFunction = () => placeHolder();
        //instructionCanvas = GameObject.FindWithTag("InstructionCanvas");
        
    }


    // Update is called once per frame
    protected virtual void Update()
    {
        
        if(isSelected)
        {
            activateInstruction();
            Debug.Log("Instruction activated");
            if(Input.GetKeyDown(KeyCode.LeftArrow) && Input.GetKeyDown(KeyCode.RightArrow) && canQuit)
            {
                deactivateInstruction();
                Debug.Log("Deactivated");
                player.GetComponent<Animator>().SetInteger("StationNumber", 0);
                isSelected = false;
                player.gameObject.transform.position = new Vector3(0f, -1.6f, 1f);
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

    protected void placeHolder(){

    }

    protected void DeselectStation()
    {
        player.GetComponent<Animator>().SetInteger("StationNumber", 0);
        isSelected = false;
        player.gameObject.transform.position = new Vector3(0f, -1.6f, 1f);
        //Debug.Log("Station deselected");
    }
    
    public virtual void activateInstruction()
    {
        Debug.Log("Activated fr");
        //instructionCanvas.transform.GetChild(0).gameObject.SetActive(false);
        instruction.SetActive(true);
        defaultInstruction.SetActive(false);
        
    }

    public virtual void deactivateInstruction()
    {
        //instructionCanvas.transform.GetChild(0).gameObject.SetActive(true);
        instruction.SetActive(false);
        defaultInstruction.SetActive(true);
    }
}

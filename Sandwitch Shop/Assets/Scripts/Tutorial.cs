using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject fridge;
    public GameObject cuttingBoard;
    public GameObject toaster;
    public GameObject stove;
    public GameObject brewery;
    

    
    private int stage = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(stage == 0 && Hand.getItem() != null)
        {
            cuttingBoard.SetActive(true);
            stage = 1;
        }
        if(stage == 1 && Hand.getItem() == null)
        {
            toaster.SetActive(true);
            stage = 2;
        }
        if(stage == 2 && Hand.getItem()!= null && Hand.getItem().isReadyForAssembly)
        {

            stage = 3;
        }
        if(stage == 3 && Hand.getItem() == null)
        {
            fridge.SetActive(true);
        }
        if(stage == 3 && Hand.getItem() != null && Hand.getItem().isPunched)
        {
            stove.SetActive(true);
            stage = 4;
        }
        if(stage == 4 && Hand.getItem() == null)
        {
            stage = 5;
        }
        if(stage == 5 && Hand.getItem() != null && Hand.getItem().isReadyForAssembly)
        {
            stage = 6;
        }
        if(stage == 6 && Hand.getItem() == null)
        {
            brewery.SetActive(true);
        }
    }
}

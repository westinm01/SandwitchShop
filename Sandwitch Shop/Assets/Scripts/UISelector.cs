using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISelector : MonoBehaviour
{
    [SerializeField] GameObject[] interactableUI;

    int currentlySelectedUI = 0;

    private void Update()
    {
        Debug.Log(currentlySelectedUI);
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            interactableUI[currentlySelectedUI].GetComponent<UnityEvent>().InvokeUnityEvent();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentlySelectedUI + 1 < interactableUI.Length)
            {
                currentlySelectedUI += 1;
            }
           
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(currentlySelectedUI - 1 >= 0)
            {
                currentlySelectedUI -= 1;
            }
        }
    }
}

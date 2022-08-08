using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISelector : MonoBehaviour
{
    [SerializeField] GameObject selectorIcon;
    [SerializeField] GameObject[] interactableUI;

    int currentlySelectedUI = 0;
    [SerializeField] float selectorYPosOffset = 160f;

    private void Update()
    {
        Vector3 currentUIPos = interactableUI[currentlySelectedUI].transform.position;
        selectorIcon.transform.position = new Vector3(currentUIPos.x, currentUIPos.y + selectorYPosOffset, currentUIPos.z);
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("Try To Select");
            SelectAtPosition();
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

    public void SelectAtPosition()
    {
        interactableUI[currentlySelectedUI].GetComponent<UnityEvent>().InvokeUnityEvent();
    }
}

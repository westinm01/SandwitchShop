using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    [SerializeField] float timeToPause = 3f;
    float timeHeldDown = 0f;
    bool tryingToPause = false;

    void Update()
    {
        //start trying to pause if all 3 keys are held down
        if(!tryingToPause && Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            tryingToPause = true;
            //Debug.Log("Try To Pause");
            //StartCoroutine(TryToPause());
        }

        //adds time between and eventually pauses the game when it hits the time needed to pause
        if (tryingToPause)
        {
            // if any of 3 keys was released, stop trying to pause
            if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                tryingToPause = false;
                timeHeldDown = 0f;
            }
            //Add the real time that has passed between frames
            timeHeldDown += Time.deltaTime;
            //pause game when time held down meets time needed to pause
            if(timeHeldDown >= timeToPause)
            {
                timeHeldDown = 0f;
                FindObjectOfType<GameStateManager>().PauseGame();
            }
        }
    }

   /* IEnumerator TryToPause()
    {
        tryingToPause = true;
        while (tryingToPause)
        {
            if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                tryingToPause = false;
                break;
            }
        }
        yield return new WaitForSeconds(timeToPause);
        tryingToPause = false;
        FindObjectOfType<GameStateManager>().PauseGame();
    } */
}

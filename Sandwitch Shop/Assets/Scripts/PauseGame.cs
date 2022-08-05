using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    [SerializeField] float timeToPause = 3f;
    bool tryingToPause = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!tryingToPause && Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("Try To Pause");
            StartCoroutine(TryToPause());
        }
    }

    IEnumerator TryToPause()
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
    }
}

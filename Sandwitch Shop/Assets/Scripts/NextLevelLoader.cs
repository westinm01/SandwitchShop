using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelLoader : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            FindObjectOfType<SceneLoader>().LoadNextScene();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    int levelsCompleted = 0;

    private void Awake()
    {
        int singletonCount = FindObjectsOfType<Singleton>().Length;
        if(singletonCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void IncrementLevelsCompleted()
    {
        levelsCompleted++;
    }
    public int GetLevelsCompleted()
    {
        return levelsCompleted;
    }
}

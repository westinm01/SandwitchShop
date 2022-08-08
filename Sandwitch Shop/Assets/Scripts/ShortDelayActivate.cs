using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortDelayActivate : MonoBehaviour
{
    [SerializeField] GameObject[] itemsToActivate;
    float timePassed = 0f;

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        if(timePassed >= 0.25f)
        {
            foreach(GameObject g in itemsToActivate)
            {
                g.SetActive(true);
            }
        }
    }
}

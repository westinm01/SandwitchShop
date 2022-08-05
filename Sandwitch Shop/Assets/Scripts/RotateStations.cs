using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateStations : MonoBehaviour
{
    [SerializeField] GameObject counter;
    //float currRotation;
    int clockwise = 0;

    IEnumerator coolRotate(){
        yield return new WaitUntil(() => clockwise!=0);
        if(clockwise == 1){
            counter.transform.Rotate(new Vector3(0,0,1)*30);
        }else{
            counter.transform.Rotate(new Vector3(0,0,1)*-30);
        }
        yield return new WaitForSeconds(1.0f);
        clockwise = 0;
        StartCoroutine(coolRotate());
    }

    void Start(){
        StartCoroutine(coolRotate());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal") != 0){
            //currRotation = counter.transform.rotation;
            if(Input.GetAxis("Horizontal") < 0){
                clockwise = -1;
            }else{
                clockwise = 1;
            }
        }
    }
}

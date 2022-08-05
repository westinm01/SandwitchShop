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
        Destroy(counter.GetComponent<SelectStation>());
        if(clockwise == 1){
            for(int i=0; i<5; ++i){
                counter.transform.Rotate(new Vector3(0,0,7));
                yield return new WaitForSeconds(0.02f);
            }
            counter.transform.Rotate(new Vector3(0,0,-5));
        }else{
            for(int i=0; i<5; ++i){
                counter.transform.Rotate(new Vector3(0,0,-7));
                yield return new WaitForSeconds(0.02f);
            }
            counter.transform.Rotate(new Vector3(0,0,5));
        }
        counter.AddComponent<SelectStation>();
        yield return new WaitForSeconds(0.3f);
        clockwise = 0;
        StartCoroutine(coolRotate());
    }

    void Start(){
        counter = GameObject.FindWithTag("Table");
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectStation : MonoBehaviour
{
    [SerializeField] GameObject allTheStations;
    [SerializeField] GameObject dizzy;
    bool selected = false;
    GameObject selectedStation;

    IEnumerator actuallySelectStation(){
        yield return new WaitUntil(() => selected);
        if(selectedStation != null){
            selectedStation = null;
            allTheStations.AddComponent<RotateStations>();
        }else{
            for(int i=0; i<allTheStations.transform.childCount; ++i){
                Transform station = allTheStations.transform.GetChild(i);
                if(Mathf.RoundToInt(station.position.x) == Mathf.RoundToInt(dizzy.transform.position.x) && Mathf.RoundToInt(station.position.y) <= Mathf.RoundToInt(dizzy.transform.position.y)){
                    selectedStation = station.gameObject;
                }
            }
            Destroy(allTheStations.GetComponent<RotateStations>());
        }
        Debug.Log(selectedStation);
        yield return new WaitForSeconds(0.25f);
        selected = false;
        StartCoroutine(actuallySelectStation());
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(actuallySelectStation());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Vertical") < 0){
            selected = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectStation : MonoBehaviour
{
    [SerializeField] GameObject allTheStations;
    [SerializeField] GameObject dizzy;
    public bool selected = false;
    GameObject selectedStation;

    public GameObject getStation(){
        return selectedStation;
    }

    IEnumerator actuallySelectStation(){
        yield return new WaitUntil(() => selected);
        // if((selectedStation != null) && (Input.GetKeyDown(KeyCode.LeftArrow) && Input.GetKeyDown(KeyCode.RightArrow) && Input.GetKeyDown(KeyCode.DownArrow))){
        //     selectedStation.GetComponent<Station>().isSelected = false;
        //     selectedStation = null;
        //     allTheStations.AddComponent<RotateStations>();
        // }else{
            for(int i=0; i<allTheStations.transform.childCount; ++i){
                Transform station = allTheStations.transform.GetChild(i);
                if(Mathf.RoundToInt(station.position.x) == Mathf.RoundToInt(dizzy.transform.position.x) && Mathf.RoundToInt(station.position.y) <= Mathf.RoundToInt(dizzy.transform.position.y)){
                    selectedStation = station.gameObject;
                    selectedStation.GetComponent<Station>().isSelected = true;
                    dizzy.gameObject.transform.position = new Vector3(0f,-1.6f,1f);
                    
                }
            }
            Destroy(allTheStations.GetComponent<RotateStations>());
            if(selectedStation == null){
                allTheStations.AddComponent<RotateStations>();
            }
        //}
        Debug.Log(selectedStation);
        yield return new WaitForSeconds(0.5f);
        selected = false;
        StartCoroutine(actuallySelectStation());
    }

    IEnumerator unselectStation(){
        yield return new WaitUntil(() => selectedStation!=null);
        if((Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow)) && selectedStation.GetComponent<Station>().canQuit){
            selectedStation.GetComponent<Station>().isSelected = false;
            selectedStation.GetComponent<Station>().deactivateInstruction();
            selectedStation = null;
            allTheStations.AddComponent<RotateStations>();
            
        }
        StartCoroutine(unselectStation());
    }

    // Start is called before the first frame update
    void Start()
    {
        dizzy = GameObject.FindWithTag("Player");
        allTheStations = GameObject.FindWithTag("Table");
        StartCoroutine(actuallySelectStation());
        StartCoroutine(unselectStation());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Vertical") < 0){
            selected = true;
        }
    }
}

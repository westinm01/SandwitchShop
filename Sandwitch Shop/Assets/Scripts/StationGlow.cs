using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationGlow : MonoBehaviour
{
    private GameObject cuttingLight;
    private GameObject stoveLight;
    private GameObject deliveryLight;

    private List<GameObject> lights = new List<GameObject>();
    public Station cuttingStation;
    public Station stoveStation;
    public Station deliveryStation;

    public SelectStation stationSelector;

    // Start is called before the first frame update
    void Start()
    {
        lights.Add(cuttingStation.gameObject.transform.GetChild(1).gameObject);
        lights.Add(stoveStation.gameObject.transform.GetChild(1).gameObject);
        lights.Add(deliveryStation.gameObject.transform.GetChild(2).gameObject);
        LightUp(-1);

    }

    // Update is called once per frame
    void Update()
    {
        if(Hand.getItem() != null)
        {
            Food currItem = Hand.getItem();
            if(currItem.isBakable)
            {
                if(!currItem.isPunched && !currItem.isBaked && cuttingStation != stationSelector.getStation())
                {
                    LightUp(0);
                }
                else if(currItem.isPunched && !currItem.isBaked && stoveStation != stationSelector.getStation())
                {
                    LightUp(1);
                }
            }
            else if(currItem.isCuttable)
            {
                if(!currItem.isReadyForAssembly && cuttingStation != stationSelector.getStation())
                {
                    LightUp(0);
                }
                
            }
           if(currItem.isReadyForAssembly && deliveryStation != stationSelector.getStation())
            {
                LightUp(2);
            }
        }
        else{
            LightUp(-1);
        }
         
    }

    private void LightUp(int lightIndex)
    {
        for (int i = 0; i < lights.Count; i++)
        {
            if (i != lightIndex)
            {
                lights[i].SetActive(false);
            }
            else{
                lights[i].SetActive(true);
            }
        }
    }

    
}

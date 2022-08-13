using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class NameDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    public List<string> stationNames = new List<string>();
    
    public int index = 0;

    private TMP_Text tmp;
    void Start()
    {
        stationNames.Add("Garden");
        stationNames.Add("Cutting Board");
        stationNames.Add("Toaster");
        stationNames.Add("Delivery");
        stationNames.Add("Trash");
        stationNames.Add("Brewery");
        stationNames.Add("Fridge");
        stationNames.Add("Stove");

        tmp = GetComponent<TextMeshProUGUI>();
        tmp.text = stationNames[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(index > stationNames.Count - 1)
        {
            index = 0;
        }
        else if(index < 0)
        {
            index = stationNames.Count - 1;
        }
        
        tmp.text = stationNames[index];
    }
}

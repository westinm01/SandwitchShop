using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Food : MonoBehaviour
{
    public bool isCuttable;
    public bool isBakable;
    public bool isBaked;
    public bool isPunchable;
    public bool isPunched;
    public bool isReadyForAssembly;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        isCuttable = false;
        isBakable = false;
        isBaked = false;
        isPunchable = false;
        isPunched = false;
        isReadyForAssembly = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

}

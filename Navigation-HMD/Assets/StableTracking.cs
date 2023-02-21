using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StableTracking : MonoBehaviour
{
    public VarjoMarkerManager VarjoManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        VarjoManager.stableTracking = true;
    }
    
    private void OnTriggerExit(Collider other) {
        VarjoManager.stableTracking = false;
    }
}


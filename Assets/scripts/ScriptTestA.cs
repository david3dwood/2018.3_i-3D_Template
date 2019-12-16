using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptTestA : MonoBehaviour {
    ScriptTestOperatorB convert2LatLon;

    void Start () {
        // use this way if you want to access and use another script on same GameObject
        convert2LatLon = GetComponent<ScriptTestOperatorB> ();
        Debug.Log (convert2LatLon.xpos_One);
    }

    void Update () {
    }
}
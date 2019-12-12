using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnableDisableKey_I : MonoBehaviour {

public GameObject theObject;

	// Use this for initialization
	void Start () {
	    theObject.SetActive(false);	
	}
	
	// Update is called once per frame
	void Update () {

	if (Input.GetKeyDown(KeyCode.I))
    theObject.SetActive(true);

	if (Input.GetKeyDown(KeyCode.Escape))
    theObject.SetActive(false);

//	else if (Input.GetKeyUp(KeyCode.Escape))
// 	theObject.SetActive(true);
		
	}
}

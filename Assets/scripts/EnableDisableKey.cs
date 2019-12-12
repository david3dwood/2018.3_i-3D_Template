using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnableDisableKey : MonoBehaviour {

public GameObject theObject;

	// Use this for initialization
	void Start () {
	    theObject.SetActive(true);	
	}
	
	// Update is called once per frame
	void Update () {

	if (Input.GetKeyDown(KeyCode.H))
    theObject.SetActive(true);
        //Detect when the H arrow key is pressed down
         if (Input.GetKeyUp("k"))
     {
         Debug.Log("K was pressed");
     }

	if (Input.GetKeyDown(KeyCode.Escape))
    theObject.SetActive(false);

//	else if (Input.GetKeyUp(KeyCode.Escape))
// 	theObject.SetActive(true);
		
	}
}

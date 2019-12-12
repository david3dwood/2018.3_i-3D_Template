using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnableKey : MonoBehaviour {

public GameObject theObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		 if (Input.GetKeyDown(KeyCode.H))
     theObject.SetActive(true);
 
 //else if (Input.GetKeyUp(KeyCode.Escape))
 //    theObject.SetActive(true);
		
	}
}

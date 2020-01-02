using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectsWithTag : MonoBehaviour {

    public string tag1 = "measure";

    public void DestroyTagged () {
        GameObject[] gos = GameObject.FindGameObjectsWithTag (tag1);
        foreach (GameObject go in gos)
            if (gameObject != null) {
                // Destroy (go);
                go.SetActive (false);
            }

    }

}
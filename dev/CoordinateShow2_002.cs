using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Show Unity coordinates
public class CoordinateShow2 : MonoBehaviour {

    public Text sceneCoordinate;
    public Text RW_UTM_E;
    public Text RW_UTM;
    public float xloc;
    public float xadjust;
    public float yloc;
    public float zloc;

    public Transform cubeTransform;

    void Update () {
        ShowMouseCoord ();
    }

    void ShowMouseCoord () {
        Vector3 mouseScreenCoord = Input.mousePosition;
        Vector3 mouseViewportCoord = Camera.main.ScreenToViewportPoint (mouseScreenCoord);

        // Mouse pointing spot in world space
        Ray ray = Camera.main.ScreenPointToRay (mouseScreenCoord);
        RaycastHit hit;
        Physics.Raycast (ray, out hit);
        Vector3 mouseWorldCoord = hit.point;
        sceneCoordinate.text = ("mouse raw coordinate: " + (mouseWorldCoord.ToString ()));

        // Adjust mouse world coordinate to real world coordinates
        xloc = mouseWorldCoord.x;
        yloc = mouseWorldCoord.y;       
        // print (xloc + xadjust);
        RW_UTM_E.text = ("UTM E = " + (xloc + xadjust).ToString());
        RW_UTM.text = ( ("UTM "  + (xloc + xadjust).ToString() ) + (" E")  + (yloc.ToString())       );
    }

    //                   TEST SCENE INFO   
    //  47° 4'13.76"N
    //  10°11'28.75"E

    //  47.070492°
    //  10.191325°

    // 32 T
    // 590451.52 m E
    // 5213686.25 m N

}
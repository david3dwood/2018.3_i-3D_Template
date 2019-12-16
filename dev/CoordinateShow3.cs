using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

// Show Unity coordinates
public class CoordinateShow3 : MonoBehaviour {

// public LatLngUTMConverter LatLngUTMConverter (UTM); //= new LatLngUTMConverter (String, datumNameIn);
//public LatLng convertUtmToLatLng (double UTMEasting, double UTMNorthing, int UTMZoneNumber, String UTMZoneLetter);


    GPSEncoder ConvertUCStolatlon;

    public Text sceneCoordinate;
    public Text RW_UTM;
    public Text RW_elevation;
     float xloc;
    public float xOffset;
     float yloc;
    public float yOffset;
     float zloc;
    public float zOffset;

    void LateUpdate () {
        ShowMouseCoord ();
        ConvertUCStolatlon = GetComponent<GPSEncoder>();
    }

    void ShowMouseCoord () {
        Vector3 mouseScreenCoord = Input.mousePosition;
        Vector3 mouseViewportCoord = Camera.main.ScreenToViewportPoint (mouseScreenCoord);

        // Mouse pointing spot in scene space
        Ray ray = Camera.main.ScreenPointToRay (mouseScreenCoord);
        RaycastHit hit;
        Physics.Raycast (ray, out hit);
        Vector3 mouseWorldCoord = hit.point;
        sceneCoordinate.text = ("mouse raw coordinate: " + (mouseWorldCoord.ToString ()));

        // Adjust mouse scene coordinate to real world coordinates
        xloc = mouseWorldCoord.x;
        yloc = mouseWorldCoord.y; 
        zloc = mouseWorldCoord.z;      
        // print (xloc + xOffset);
        RW_UTM.text = (  ("UTM "  + (zloc + zOffset).ToString() ) + (" N ") + ( (xloc + xOffset).ToString() ) + (" E ")    );
        RW_elevation.text = (  ("elevation " + (yloc + yOffset).ToString()  ) + (" m")  );
//Debug.Log("Text: " + RW_UTM.text);
    }

    //                   TEST SCENE INFO   
    //  1667 m elevation

    //  47° 4'13.76"N
    //  10°11'28.75"E

    //  47.070492°
    //  10.191325°

    // 32 T
    // 590451.52 m E
    // 5213686.25 m N

}
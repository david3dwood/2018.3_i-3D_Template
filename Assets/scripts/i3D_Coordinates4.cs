using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Show Unity coordinates
public class i3D_Coordinates4 : MonoBehaviour {

    public Text sceneCoordinate;
    public Text RW_UTM;
    // public TextMeshProUGUI RW_elevation;    ... cant figure out how to get TMPro text out to UI from equation below ???????????
    public Text RW_elevation;
    private float xloc;
    public float xadjust;
    private float yloc;
    public float yadjust;
    double elevation;
    private float zloc;
    public float zadjust;
    public double utmN = 590451.52;
    public double utmE = 5213686.25;
    public string utmZone = "32T";

    void Update () {
        ShowMouseCoord ();
        // convert2LatLon = GetComponent<Coordinate_UTM_to_LATLON>();
        // print ("Latitude: " + (convert2LatLon.latitude.ToString()) + " Longitude: "+ (convert2LatLon.longitude.ToString()));
    }

    void ShowMouseCoord () {
        Vector3 mouseScreenCoord = Input.mousePosition;
        Vector3 mouseViewportCoord = Camera.main.ScreenToViewportPoint (mouseScreenCoord);
        //    RW_elevation = RW_elevation.GetComponent<TextMeshProUGUI>() ;

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
        // print (xloc + xadjust);
        utmN = (zloc + zadjust);
        utmE = (xloc + xadjust);
        RW_UTM.text = (("UTM:  " + utmZone + "   " + (zloc + zadjust).ToString ()) + (" N   ") + ((xloc + xadjust).ToString ()) + (" E "));
        // elevation_s = (yloc + yadjust).ToString ();   // dont need this variable anymore
        elevation = (yloc + yadjust);
        elevation = Math.Round (elevation, 1);
        RW_elevation.text = ("elevation " + (elevation.ToString ()) + " m"); // working // this part buggy for objects >  (elevation_s.Substring (0, elevation_s.Length - 2)
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
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Coordinate_UTM_to_LATLON_TMPro : MonoBehaviour {

    public TextMeshProUGUI Latitude_T;
    // private TextMeshProUGUI Latitude_T;
    [SerializeField] public Text Longitude_T;
    i3D_Coordinates4 UTM_Coordinates;
    double latitude;
    double longitude;

    void Start () {
        UTM_Coordinates = GetComponent<i3D_Coordinates4> ();
        // Get a reference to an existing TextMeshPro component or Add one if needed.
        Latitude_T = GetComponent<TMPro.TextMeshProUGUI> ();
        Latitude_T.text = "Latitude: Text here is a test ";
    }

    void LateUpdate () {
        ToLatLon (UTM_Coordinates.utmE, UTM_Coordinates.utmN, UTM_Coordinates.utmZone);
        // Latitude_T.text = ("Latitude: " + (latitude.ToString ()));
        Longitude_T.text = ("Longitude: " + (longitude.ToString ()));
        // Debug.Log ("Latitude: " + (latitude.ToString ()) + " Longitude: " + (longitude.ToString ()));
    }

    public void ToLatLon (double utmN, double utmE, String utmZone) { // take out static?
        bool isNorthHemisphere = utmZone.Last () >= 'N';
        var diflat = -0.00066286966871111111111111111111111111;
        var diflon = -0.0003868060578;
        var zone = int.Parse (utmZone.Remove (utmZone.Length - 1));
        var c_sa = 6378137.000000;
        var c_sb = 6356752.314245;
        var e2 = Math.Pow ((Math.Pow (c_sa, 2) - Math.Pow (c_sb, 2)), 0.5) / c_sb;
        var e2cuadrada = Math.Pow (e2, 2);
        var c = Math.Pow (c_sa, 2) / c_sb;
        var x = utmN - 500000;
        var y = isNorthHemisphere ? utmE : utmE - 10000000;
        var s = ((zone * 6.0) - 183.0);
        var lat = y / (6366197.724 * 0.9996); // Change c_sa for 6366197.724
        var v = (c / Math.Pow (1 + (e2cuadrada * Math.Pow (Math.Cos (lat), 2)), 0.5)) * 0.9996;
        var a = x / v;
        var a1 = Math.Sin (2 * lat);
        var a2 = a1 * Math.Pow ((Math.Cos (lat)), 2);
        var j2 = lat + (a1 / 2.0);
        var j4 = ((3 * j2) + a2) / 4.0;
        var j6 = (5 * j4 + a2 * Math.Pow ((Math.Cos (lat)), 2)) / 3.0; // take a2 from multiplying by the cosine of lat and squared
        var alfa = (3.0 / 4.0) * e2cuadrada;
        var beta = (5.0 / 3.0) * Math.Pow (alfa, 2);
        var gama = (35.0 / 27.0) * Math.Pow (alfa, 3);
        var bm = 0.9996 * c * (lat - alfa * j2 + beta * j4 - gama * j6);
        var b = (y - bm) / v;
        var epsi = ((e2cuadrada * Math.Pow (a, 2)) / 2.0) * Math.Pow ((Math.Cos (lat)), 2);
        var eps = a * (1 - (epsi / 3.0));
        var nab = (b * (1 - epsi)) + lat;
        var senoheps = (Math.Exp (eps) - Math.Exp (-eps)) / 2.0;
        var delt = Math.Atan (senoheps / (Math.Cos (nab)));
        var tao = Math.Atan (Math.Cos (delt) * Math.Tan (nab));
        longitude = (delt / Math.PI) * 180 + s;
        latitude = (((lat + (1 + e2cuadrada * Math.Pow (Math.Cos (lat), 2) - (3.0 / 2.0) * e2cuadrada * Math.Sin (lat) * Math.Cos (lat) * (tao - lat)) * (tao - lat))) / Math.PI) * 180; // era incorrecto el calculo
    }

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
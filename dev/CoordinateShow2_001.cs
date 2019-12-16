using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 


// Show Unity coordinates
public class CoordinateShow2 : MonoBehaviour
{

    public Text sceneCoordinate;
    public Text WCadjusted;
    public Text worldCoordinate;
    public Text mouseCoordAdjusted;
    public int xloc;
    public int yloc;    
    public int zloc;

    public Transform cubeTransform;

    void Update(){
        ShowMouseCoord();
    }

    void ShowMouseCoord()
    {
        Vector3 mouseScreenCoord = Input.mousePosition;
        Vector3 mouseViewportCoord = Camera.main.ScreenToViewportPoint(mouseScreenCoord);

        // Mouse pointing spot in world space
        Ray ray = Camera.main.ScreenPointToRay(mouseScreenCoord);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        Vector3 mouseWorldCoord = hit.point;
        worldCoordinate.text = ("mouse raw coordinate: "+ (mouseWorldCoord.ToString()));

    }
}

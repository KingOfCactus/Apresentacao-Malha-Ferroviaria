using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.ARFoundation;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ARTrackedImageManager))]
public class ImageTrackingTest : MonoBehaviour
{
    ARTrackedImageManager trackingManager;
    GameObject mask;
    
    void Start()
    {
        trackingManager = GetComponent<ARTrackedImageManager>();
    }

    public void ToogleMask()
    {
        if (mask == null) mask = GameObject.Find("Mask");
        mask.SetActive(!mask.activeInHierarchy);
    } 
    
    public void ToogleTracking() => trackingManager.enabled = !trackingManager.enabled;

}

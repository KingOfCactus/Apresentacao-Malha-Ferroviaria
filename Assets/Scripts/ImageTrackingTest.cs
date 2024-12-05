using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

[RequireComponent(typeof(ARTrackedImageManager))]
public class ImageTrackingTest : MonoBehaviour
{
    [SerializeField] Slider maskScaleSlider;
    [SerializeField] TextMeshProUGUI maskScaleText;

    [SerializeField] Slider maskHeightSlider;
    [SerializeField] TextMeshProUGUI maskHeightText;

    [SerializeField] Slider modelHeightSlider;
    [SerializeField] TextMeshProUGUI modelHeightText;

    ARTrackedImageManager trackingManager;
    GameObject mask, model;
    
    float frameRate;
    float elapsedTime, elapsedFrames;
    
    
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
    
    public void UpdateMaskScale()
    {
        if (mask == null) return;
        maskScaleText.text = maskScaleSlider.value.ToString();
        mask.transform.localScale = Vector3.one * maskScaleSlider.value;
    }

    public void UpdateMaskHeight()
    {
        if (mask == null) return;
        var oldPos = mask.transform.localPosition;
        maskHeightText.text = maskHeightSlider.value.ToString();
        mask.transform.localPosition = new Vector3(oldPos.x, maskHeightSlider.value, oldPos.z);
    }

    public void UpdateModelHeight()
    {
        if (model == null) model = GameObject.Find("Model");
        var oldPos = model.transform.localPosition;
        modelHeightText.text = modelHeightSlider.value.ToString();
        model.transform.localPosition = new Vector3(oldPos.x, modelHeightSlider.value, oldPos.z);
    }


    void Update()
    {
        if (elapsedTime >= 1f)
        {
            frameRate = elapsedFrames / elapsedTime;
            elapsedFrames = 0;
            elapsedTime = .0f;
        }

        elapsedFrames++;
        elapsedTime += Time.deltaTime;
    }

    void OnGUI()
    {
        var labelStyle = GUI.skin.label;
        labelStyle.fontSize = 24;

        GUILayout.Label($"FPS: {frameRate}", labelStyle);
        GUILayout.Label($"Camera Transform: {Camera.main.transform.position}", labelStyle);


    }

    public void ForwardX()
    {
        model = GameObject.Find("Model");
        model.GetComponent<Station>().ForwardX();
    }
    public void ForwardZ()
    {
        model = GameObject.Find("Model");
        model.GetComponent<Station>().ForwardZ();
    }
    public void BackX()
    {
        model = GameObject.Find("Model");
        model.GetComponent<Station>().BackX();
    }
    public void BackZ()
    {
        model = GameObject.Find("Model");
        model.GetComponent<Station>().BackZ();
    }
}

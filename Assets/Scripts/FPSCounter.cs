using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class FPSCounter : MonoBehaviour
{
    [Range(0.1f, 1f)]
    [SerializeField] float sampleTime;
    TextMeshProUGUI text;
    
    float elapsedTime;
    int elapsedFrames;

    void Start() => text = GetComponent<TextMeshProUGUI>();

    void Update()
    {
        if (elapsedTime >= sampleTime)
        {
            text.text = (elapsedFrames/elapsedTime).ToString();
            elapsedFrames = 0;
            elapsedTime = .0f;
        }

        elapsedFrames++;
        elapsedTime += Time.deltaTime;
    }
}

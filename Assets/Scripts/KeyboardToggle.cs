using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardToggle : MonoBehaviour
{
    [SerializeField] string button;
    MeshRenderer _rndr;

    void Start()
    {
        _rndr =  GetComponent<MeshRenderer>();   
        if (button != "1")
            _rndr.enabled = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(button))
        {
            _rndr.enabled = !_rndr.enabled; 
        }
    }
}

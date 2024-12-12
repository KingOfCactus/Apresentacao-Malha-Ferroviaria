using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    [SerializeField] Vector3 offset = new Vector3(0, 180, 0);
    Transform cam;

    void Start() => cam = Camera.main.transform;
    void LateUpdate()
    {
        var oldRot = transform.eulerAngles; 
        transform.LookAt(cam.position);
        transform.Rotate(offset);

        // transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 
        //                                     oldRot.z);
    }
}

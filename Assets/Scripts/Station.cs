using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Station : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    public void ForwardX() => transform.Translate(transform.forward * moveSpeed * Time.deltaTime);
    public void BackX() => transform.Translate(-transform.forward * moveSpeed * Time.deltaTime);

    public void ForwardZ() => transform.Translate(transform.right * moveSpeed * Time.deltaTime);
    public void BackZ() => transform.Translate(-transform.right * moveSpeed * Time.deltaTime);

}

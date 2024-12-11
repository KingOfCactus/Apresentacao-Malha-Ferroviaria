using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class VRButton : MonoBehaviour
{
    public UnityEvent onClick;
    [SerializeField] Image fill;
    [SerializeField] float buttonCountdown;    

    float selectionTimer, step;
    bool isHighlighted, wasPressed = false;

    public void OnPointerEnter() => isHighlighted = true;
    public void OnPointerExit()
    {
        isHighlighted = false;
        wasPressed = false;
    }

    public void Start()
    {
        if (fill.Equals(null))
           Debug.LogError($"[{transform.name}] Fill image not selected");
    }

    public void Update()
    {
        //Check if pressed
        wasPressed = fill.fillAmount >= 1f;
        if (wasPressed)
        {
            onClick.Invoke();
            selectionTimer = 0f;
            return;
        }

        // Increases or decreases selection timer
        selectionTimer += Time.deltaTime * (isHighlighted ? 1f : -1f);
        selectionTimer = Mathf.Clamp(selectionTimer, 0, buttonCountdown);
        fill.fillAmount = selectionTimer / buttonCountdown;
    }
}

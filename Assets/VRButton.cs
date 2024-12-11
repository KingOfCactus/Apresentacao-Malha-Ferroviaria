using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRButton : MonoBehaviour
{
    [SerializeField] Image fill;
    [SerializeField] float buttonCountdown;
    float selectionTimer, step;
    bool isHighlighted;

    public void OnPointerEnter() => isHighlighted = true;
    public void OnPointerExit() => isHighlighted = false;

    public void Start()
    {
        if (fill.Equals(null))
           Debug.LogError($"[{transform.name}] Fill image not selected");
    }

    public void Update()
    {
        selectionTimer += Time.deltaTime * (isHighlighted ? 1f : -1f);
        selectionTimer = Mathf.Clamp(selectionTimer, 0, buttonCountdown);
        fill.fillAmount = selectionTimer / buttonCountdown;
    }
}

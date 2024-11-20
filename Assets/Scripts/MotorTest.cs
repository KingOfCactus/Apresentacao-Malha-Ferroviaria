using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Slider))]
public class MotorTest : MonoBehaviour
{
    Slider _slider;

    void Start()
    {
        _slider = GetComponent<Slider>();
    }
    public void UpdateMotor()
    {
        Gamepad.current.SetMotorSpeeds(_slider.value, _slider.value);
        Debug.Log($"Setting {_slider.value} for {Gamepad.current.name}");
    }
}
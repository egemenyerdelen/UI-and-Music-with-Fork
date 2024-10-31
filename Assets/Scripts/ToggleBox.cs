using System;
using UnityEngine;
using UnityEngine.UI;

public class ToggleBox : MonoBehaviour
{
    private Slider _slider;
    private Toggle _toggle;

    private void Start()
    {
        _slider = GetComponentInParent<Slider>();
        _toggle = GetComponent<Toggle>();
    }

    private void Update()
    {
        if (_slider.value == _slider.minValue)
        {
            Debug.Log("Toggle script is working");
        }
    }
}

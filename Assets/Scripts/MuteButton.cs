using System;
using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour
{
    [SerializeField] private GameObject onIcon;
    [SerializeField] private GameObject offIcon;
    
    private Slider _slider;

    private void Start()
    {
        _slider = GetComponentInParent<Slider>();
        
        ChangeMuteButtonImage(_slider.value);
        _slider.onValueChanged.AddListener(ChangeMuteButtonImage);
    }

    public void ChangeMuteButtonImage(float sliderValue)
    {
        if (sliderValue == _slider.minValue)
        {
            var onColor = onIcon.GetComponent<Image>().color;
            onColor.a = 0;
            onIcon.GetComponent<Image>().color = onColor;
            
            var offColor = offIcon.GetComponent<Image>().color;
            offColor.a = 1;
            offIcon.GetComponent<Image>().color = offColor;
        }
        else
        {
            var offColor = offIcon.GetComponent<Image>().color;
            offColor.a = 0;
            offIcon.GetComponent<Image>().color = offColor;
            
            var onColor = onIcon.GetComponent<Image>().color;
            onColor.a = 1;
            onIcon.GetComponent<Image>().color = onColor;
        }
    }
}

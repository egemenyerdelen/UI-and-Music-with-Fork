using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer volumeMixer;
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    private const string MasterKey = "MasterVolume";
    private const string MusicKey = "MusicVolume";
    private const string SfxKey = "SfxVolume";

    private float _cachedMasterSliderValue;
    private float _cachedMusicSliderValue;
    private float _cachedSfxSliderValue;

    private void Start()
    {
        SetAllValues(masterSlider.value, musicSlider.value, sfxSlider.value);
        
        masterSlider.onValueChanged.AddListener(SetMasterValue);
        musicSlider.onValueChanged.AddListener(SetMusicValue);
        sfxSlider.onValueChanged.AddListener(SetSfxValue);
        
        // For test
        AudioManager.Instance.PlayMusic("ThemeMusic");
        InvokeRepeating(nameof(TestMethod), 2f, 2f );
    }

    //For test
    private void TestMethod()
    {
        AudioManager.Instance.PlaySoundFX("Effect_2");
    }

    public void ToggleBox(string targetMixerKey)
    {
        var keyAndSliderDictionary = new Dictionary<string, Slider>()
        {
            { "MasterVolume", masterSlider },
            { "MusicVolume", musicSlider },
            { "SfxVolume", sfxSlider }
        };
        // Assign current volume value of targetMixer to currentFloat for check if is muted or not
        volumeMixer.GetFloat(targetMixerKey, out var currentFloat);
        var targetSlider = keyAndSliderDictionary[targetMixerKey];

        // ReSharper disable once CompareOfFloatsByEqualityOperator
        if (currentFloat != -80)
        {
            // Mute
            CacheSliderValue(targetSlider);
            volumeMixer.SetFloat(targetMixerKey, -80);
            targetSlider.value = targetSlider.minValue;
        }
        else
        {
            // Unmute
            targetSlider.value = GetCachedSliderValue(targetSlider);
            volumeMixer.SetFloat(targetMixerKey, Mathf.Log10(targetSlider.value) * 20);
        }
    }

    private float GetCachedSliderValue(Slider slider)
    {
        var sliderToTakeValue = new Dictionary<Slider, float>()
        {
            { masterSlider, _cachedMasterSliderValue },
            { musicSlider, _cachedMusicSliderValue },
            { sfxSlider , _cachedSfxSliderValue}
        };
        return sliderToTakeValue[slider];
    }
    
    private void CacheSliderValue(Slider slider)
    {
        var sliderToCache = new Dictionary<Slider, float>()
        {
            { masterSlider, _cachedMasterSliderValue },
            { musicSlider, _cachedMusicSliderValue },
            { sfxSlider , _cachedSfxSliderValue}
        };

        sliderToCache[slider] = slider.value;
    }
    
    private void SetAllValues(float masterValue, float musicValue, float sfxValue)
    {
        volumeMixer.SetFloat(MasterKey, Mathf.Log10(masterValue) * 20);
        volumeMixer.SetFloat(MusicKey, Mathf.Log10(musicValue) * 20);
        volumeMixer.SetFloat(SfxKey, Mathf.Log10(sfxValue) * 20);
    }
    
    private void SetMasterValue(float value)
    {
        volumeMixer.SetFloat(MasterKey, Mathf.Log10(value) * 20);
    }
    private void SetMusicValue(float value)
    {
        volumeMixer.SetFloat(MusicKey, Mathf.Log10(value) * 20);
    }
    private void SetSfxValue(float value)
    {
        volumeMixer.SetFloat(SfxKey, Mathf.Log10(value) * 20);
    }
}

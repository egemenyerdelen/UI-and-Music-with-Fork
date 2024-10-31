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

    private Dictionary<string, Slider> _keyAndSliderDictionary;
    private Dictionary<Slider, float> _cachedSliderValues;

    private void Start()
    {
        InitializeDictionaries();
        
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
        var targetSlider = _keyAndSliderDictionary[targetMixerKey];
        
        // ReSharper disable once CompareOfFloatsByEqualityOperator
        if (targetSlider.value != targetSlider.minValue)
        {
            // Mute
            CacheSliderValue(targetSlider);
            targetSlider.value = targetSlider.minValue; 
        }
        else
        {
            // Unmute
            targetSlider.value = GetCachedSliderValue(targetSlider);
        }
    }

    private void InitializeDictionaries()
    {
        _keyAndSliderDictionary = new Dictionary<string, Slider>
        {
            { "MasterVolume", masterSlider },
            { "MusicVolume", musicSlider },
            { "SfxVolume", sfxSlider }
        };
        
        _cachedSliderValues = new Dictionary<Slider, float>
        {
            { masterSlider, masterSlider.value },
            { musicSlider, musicSlider.value },
            { sfxSlider, sfxSlider.value }
        };
    }
    
    private float GetCachedSliderValue(Slider slider)
    {
        return _cachedSliderValues[slider];
    }
    
    private void CacheSliderValue(Slider slider)
    {
        _cachedSliderValues[slider] = slider.value;
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

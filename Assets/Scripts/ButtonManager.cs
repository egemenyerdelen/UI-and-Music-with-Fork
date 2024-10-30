using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public void MusicButton()
    {
        AudioManager.Instance.PlayMusic("ThemeMusic", 0);
    }

    public void Button1()
    {
        AudioManager.Instance.PlaySoundFX("Effect_1", 1);
    }
    public void Button2()
    {
        AudioManager.Instance.PlaySoundFX("Effect_2", 1);
    }
    public void Button3()
    {
        AudioManager.Instance.PlaySoundEffectOnPoint("Effect_3", 
            new Vector3((float)7.25974607,(float)-0.222291946,(float)-6.60501051));
    }
}

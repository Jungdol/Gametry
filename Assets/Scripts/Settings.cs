using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    [Header("소리 음소거")]
    public Toggle BGMSoundToggle;
    public Toggle SFXSoundToggle;

    [Header("오디오 믹서")]
    public AudioMixer mixer;

    [Header("버튼 소리")]
    public string buttonSound;

    AudioManager theAudio;

    void Start()
    {
        theAudio = FindObjectOfType<AudioManager>();
        DataCreate();
        
    }
    void DataCreate()
    {
        SoundInt();
    }

    public void SettingClear()
    {
        theAudio.Play(buttonSound);

        PlayerPrefs.DeleteAll();
        DataCreate();
    }

    void ToggleBool(string soundType)
    {
        bool SoundBool = (PlayerPrefs.GetInt(soundType) == 100) ? true : false;
        //SoundToggle.isOn = SoundBool;
    }

    public void OnShakeToggle(bool _isBool)
    {
        if (_isBool)
            PlayerPrefs.SetInt("soundType", 100);
        else
            PlayerPrefs.SetInt("ShakeOn", 0);
        theAudio.Play(buttonSound);
    }

    void SoundInt()
    {
        if (!PlayerPrefs.HasKey("MasterSound"))
        {
            PlayerPrefs.HasKey("MasterSound");
            PlayerPrefs.SetInt("MasterSound", 100);
        }
        if (!PlayerPrefs.HasKey("BGMSound"))
        {
            PlayerPrefs.HasKey("BGMSound");
            PlayerPrefs.SetInt("BGMSound", 100);
        }
        if (!PlayerPrefs.HasKey("SFXSound"))
        {
            PlayerPrefs.HasKey("SFXSound");
            PlayerPrefs.SetInt("SFXSound", 100);
        }

        mixer.SetFloat("Master", PlayerPrefs.GetInt("MasterSound") - 80);
        mixer.SetFloat("BGM", PlayerPrefs.GetInt("BGMSound") - 80);
        mixer.SetFloat("SFX", PlayerPrefs.GetInt("SFXSound") - 80);
    }
}

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
        BGMSoundToggle.isOn = ToggleBool("BGMSound");
        SFXSoundToggle.isOn = ToggleBool("SFXSound");
    }

    public void SettingClear()
    {
        theAudio.Play(buttonSound);

        PlayerPrefs.DeleteAll();
        DataCreate();
    }

    bool ToggleBool(string soundType)
    {
        bool SoundBool = (PlayerPrefs.GetInt(soundType) == 0) ? true : false;

        return SoundBool;
    }

    public void BGMSound(bool _isBool)
    {
        if (_isBool)
            PlayerPrefs.SetInt("BGMSound", 0);
        else
            PlayerPrefs.SetInt("BGMSound", -80);
        SoundInt();
        theAudio.Play(buttonSound);
    }

    public void SFXSound(bool _isBool)
    {
        if (_isBool)
            PlayerPrefs.SetInt("SFXSound", 0);
        else
            PlayerPrefs.SetInt("SFXSound", -80);
        SoundInt();
        theAudio.Play(buttonSound);
    }

    public void EndButton()
    {
        theAudio.AllStop();
        LoadingSceneController.LoadScene("TitleScene");
    }

    void SoundInt()
    {
        if (!PlayerPrefs.HasKey("MasterSound"))
        {
            PlayerPrefs.HasKey("MasterSound");
            PlayerPrefs.SetInt("MasterSound", 0);
        }
        if (!PlayerPrefs.HasKey("BGMSound"))
        {
            PlayerPrefs.HasKey("BGMSound");
            PlayerPrefs.SetInt("BGMSound", 0);
        }
        if (!PlayerPrefs.HasKey("SFXSound"))
        {
            PlayerPrefs.HasKey("SFXSound");
            PlayerPrefs.SetInt("SFXSound", 0);
        }

        mixer.SetFloat("BGM", PlayerPrefs.GetInt("BGMSound"));
        mixer.SetFloat("SFX", PlayerPrefs.GetInt("SFXSound"));
    }
}

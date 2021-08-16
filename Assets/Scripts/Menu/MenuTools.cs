using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuTools : MonoBehaviour
{

    [SerializeField] private Toggle _soundToggle;
    [SerializeField] private Toggle _vibrationToggle;
    [SerializeField] private TMP_Dropdown _languageChange;

    private void Awake()
    {
        if (_soundToggle)
        {
            _soundToggle.isOn = Convert.ToBoolean(PlayerPrefs.GetInt("SoundValue"));
            _soundToggle.onValueChanged.AddListener((value) =>
            {
                SetSound(value);
            });
        }
        if (_vibrationToggle)
        {
            _vibrationToggle.isOn = Convert.ToBoolean(PlayerPrefs.GetInt("VibrationValue"));
            _vibrationToggle.onValueChanged.AddListener((value) =>
            {
                SetVibration(value);
            });
        }
        if (_languageChange)
        {
            _languageChange.value =PlayerPrefs.GetInt("LanguageId");
            _languageChange.onValueChanged.AddListener((value) =>
            {
                SetLanguage(value);
            });
        }
    }

    public void GoToScene(int _sceneId) 
    {
        SceneManager.LoadScene(_sceneId);
    }

    public void GameQuit() 
    {
        Application.Quit();
    }

    public void SetSound(bool value) 
    {
        PlayerPrefs.SetInt("SoundValue", Convert.ToInt32(value));
        PlayerPrefs.Save();
    }

    public void SetVibration(bool value)
    {
        PlayerPrefs.SetInt("VibrationValue", Convert.ToInt32(value));
        PlayerPrefs.Save();;
    }

    public void SetLanguage(int value)
    {
        PlayerPrefs.SetString("Language", _languageChange.options[value].text);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("LanguageId", value);
        PlayerPrefs.Save();
        LanguageChange.ChangeLanguage();
    }

}

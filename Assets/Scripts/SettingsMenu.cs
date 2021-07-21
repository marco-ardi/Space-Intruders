using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public Slider volSlider;
    public Dropdown qualityDropdown;
    public Dropdown resolutionDropdown;
    public Dropdown difficultDropdown;
    public Toggle fullscreenToggle;
    private int screenInt;
    Resolution[] resolutions;

    public static float difficultValue=1.0f;

    const string prefName = "optionvalue";
    const string resName = "resolutionoption";
    const string difName = "difficults";

    private void Awake()
    {
        screenInt = PlayerPrefs.GetInt("togglestate");
        if (screenInt == 1)
        {
            fullscreenToggle.isOn = true;
        }
        else
            fullscreenToggle.isOn = false;

        //aggiungo i listener agli sliders
        resolutionDropdown.onValueChanged.AddListener(new UnityAction<int>(index => { 
            PlayerPrefs.SetInt(resName, resolutionDropdown.value);
            PlayerPrefs.Save();
        }));

        qualityDropdown.onValueChanged.AddListener(new UnityAction<int>(index =>
        {
            PlayerPrefs.SetInt(prefName, qualityDropdown.value);
            PlayerPrefs.Save();
        }));

        difficultDropdown.onValueChanged.AddListener(new UnityAction<int>(index =>
        {
            PlayerPrefs.SetInt(difName, difficultDropdown.value);
            PlayerPrefs.Save();
        }));
    }

    void Start()
    {
        volSlider.value = PlayerPrefs.GetFloat("MVolume", 1f);
        //volMixer.SetFloat("volume", PlayerPrefs.GetFloat("MVolume"));

        qualityDropdown.value = PlayerPrefs.GetInt(prefName, 1);

        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        List<string> difOptions = new List<string>();

        int currentResolutionIndex = 0;

        for(int i=0; i< resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height + " " + resolutions[i].refreshRate + "Hz";
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height &&
                resolutions[i].refreshRate == Screen.currentResolution.refreshRate)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = PlayerPrefs.GetInt(resName, currentResolutionIndex);
        resolutionDropdown.RefreshShownValue();

        difOptions.Add("Easy");
        difOptions.Add("Medium");
        difOptions.Add("Hard");
        difficultDropdown.AddOptions(difOptions);
        difficultDropdown.value = PlayerPrefs.GetInt(difName);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetDifficult(int difficultIndex)
    {
        if (difficultIndex == 0)        //difficultValue viene moltiplicato alla velocità degli enemy
            difficultValue = 0.9f;
        else if (difficultIndex == 1)
            difficultValue = 1.0f;
        else if (difficultIndex == 2)
            difficultValue = 1.1f;
    }

    public void SetFullscreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
        if (isFullScreen == false)
            PlayerPrefs.SetInt("togglestate", 0);
        else
        {
            PlayerPrefs.SetInt("togglestate", 1);
        }
    }
}

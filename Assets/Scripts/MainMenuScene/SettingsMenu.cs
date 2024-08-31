

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    // Variables for settings
    public AudioMixer audioMixer;
    public TMP_Dropdown resolutionDropdown; // TextMeshPro Dropdown
    public TMP_Dropdown qualityDropdown; // For Quality Settings
    public Toggle fullscreenToggle; // For Fullscreen Toggle
    public Slider volumeSlider; // For Volume Control

    Resolution[] resolutions;

    void Start()
    {
        // Initialize Resolutions
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height + " @ " + resolutions[i].refreshRate + "hz";
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && 
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        // Set initial states
        fullscreenToggle.isOn = Screen.fullScreen;
        volumeSlider.value = GetInitialVolume();
        qualityDropdown.value = QualitySettings.GetQualityLevel();
    }

    // Set Resolution
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        Debug.Log("Resolution set to: " + resolution.width + "x" + resolution.height);
    }

    // Set Volume
    public void SetVolume(float sliderValue)
    {
        float volume = Mathf.Lerp(-80f, 0f, sliderValue); 
        audioMixer.SetFloat("volume", volume);
        Debug.Log("Volume set to: " + volume);
    }


    // Get initial volume level
    private float GetInitialVolume()
    {
        float volume;
        audioMixer.GetFloat("volume", out volume);
        return volume;
    }

    // Set Quality
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        Debug.Log("Graphics Quality set to: " + QualitySettings.names[qualityIndex]);
    }


    // Set Fullscreen
    public void SetFullscreen(bool isFullscreen)
    {
        // Choose the full-screen mode based on whether fullscreen is enabled
        if (isFullscreen)
        {
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen; // Change this to FullScreenWindow if you prefer windowed full-screen
        }
        else
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }

        Screen.fullScreen = isFullscreen;
        Debug.Log("Fullscreen set to: " + isFullscreen + ", Mode: " + Screen.fullScreenMode);
    }


}

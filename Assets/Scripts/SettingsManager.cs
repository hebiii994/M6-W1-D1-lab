using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{

    public Slider volumeSlider;
    public Slider brightnessSlider;
    public Toggle fullscreenToggle;

    private const string VolumeKey = "MasterVolume";
    private const string BrightnessKey = "MasterBrightness";
    private const string FullscreenKey = "MasterFullscreen";


    void Start()
    {
        LoadSettings();
    }

    public void SaveSettings()
    {

        float volumeValue = volumeSlider.value;
        float brightnessValue = brightnessSlider.value;
        int fullscreenValue = fullscreenToggle.isOn ? 1 : 0; 

        PlayerPrefs.SetFloat(VolumeKey, volumeValue);
        PlayerPrefs.SetFloat(BrightnessKey, brightnessValue);
        PlayerPrefs.SetInt(FullscreenKey, fullscreenValue);


        PlayerPrefs.Save();

        Debug.Log("Settings saved!");
    }


    public void LoadSettings()
    {

        if (PlayerPrefs.HasKey(VolumeKey))
        {

            float volumeValue = PlayerPrefs.GetFloat(VolumeKey);
            float brightnessValue = PlayerPrefs.GetFloat(BrightnessKey);
            int fullscreenValue = PlayerPrefs.GetInt(FullscreenKey);


            volumeSlider.value = volumeValue;
            brightnessSlider.value = brightnessValue;
            fullscreenToggle.isOn = (fullscreenValue == 1);

            Debug.Log("Settings loaded!");
        }
        else
        {
            Debug.Log("No saved settings found.");
        }
    }
}
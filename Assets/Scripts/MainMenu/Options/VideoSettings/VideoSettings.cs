using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VideoSettings : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;

    Resolution[] resolutions;


    void Start()
    {
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        List<Resolution> filteredResolutions = new List<Resolution>();
        HashSet<string> uniqueOptions = new HashSet<string>();

        resolutions = Screen.resolutions;
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            float refreshRateFloat = (float)resolutions[i].refreshRateRatio.value;
            int refreshRateInt = Mathf.RoundToInt(refreshRateFloat);

            // Оставляем только стандартные частоты
            if (refreshRateInt == 60 || refreshRateInt == 75 || refreshRateInt == 120 || refreshRateInt == 144 || refreshRateInt == 165 || refreshRateInt == 240)
            {
                string option = $"{resolutions[i].width} X {resolutions[i].height} {refreshRateInt} Hz";

                // Проверяем на дубликаты
                if (!uniqueOptions.Contains(option))
                {
                    uniqueOptions.Add(option);
                    options.Add(option);
                    filteredResolutions.Add(resolutions[i]);

                    if (resolutions[i].width == Screen.currentResolution.width &&
                        resolutions[i].height == Screen.currentResolution.height)
                    {
                        currentResolutionIndex = filteredResolutions.Count - 1;
                    }
                }
            }
        }

        resolutions = filteredResolutions.ToArray();
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetFullscreen(bool IsFullscreen)
    {
        Screen.fullScreen = IsFullscreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}

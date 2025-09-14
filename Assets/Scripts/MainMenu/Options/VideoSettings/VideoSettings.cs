using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VideoSettings : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    [SerializeField] private Toggle fullscreenToggle;

    private DisplayInfo lastDisplayInfo;
    private bool haveLastDisplayInfo = false;

    Resolution[] resolutions;

    void Update()
    {
        var currentDisplay = Screen.mainWindowDisplayInfo;

        bool monitorChanged = !haveLastDisplayInfo ||
                              currentDisplay.name != lastDisplayInfo.name ||
                              currentDisplay.width != lastDisplayInfo.width ||
                              currentDisplay.height != lastDisplayInfo.height ||
                              currentDisplay.workArea.width != lastDisplayInfo.workArea.width ||
                              currentDisplay.workArea.height != lastDisplayInfo.workArea.height;

        if (monitorChanged)
        {
            OnMonitorChanged(currentDisplay); // вызов своей функции обновления
            lastDisplayInfo = currentDisplay;
            haveLastDisplayInfo = true;
        }
    }

    private void OnMonitorChanged(DisplayInfo display)
    {
        // Обновляем состояние полноэкранного режима
        fullscreenToggle.isOn = Screen.fullScreen;

        // Очищаем dropdown и подготавливаем списки
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        List<Resolution> filteredResolutions = new List<Resolution>();
        HashSet<string> uniqueOptions = new HashSet<string>();

        // Получаем все доступные разрешения
        var allResolutions = Screen.resolutions;
        int currentResolutionIndex = 0;

        // Фильтруем разрешения по критериям
        for (int i = 0; i < allResolutions.Length; i++)
        {
            var res = allResolutions[i];
            float refreshRateFloat = (float)res.refreshRateRatio.value;
            int refreshRateInt = Mathf.RoundToInt(refreshRateFloat);
            float aspectRatio = (float)res.width / res.height;
            bool is16to9 = Mathf.Abs(aspectRatio - (16f / 9f)) < 0.01f;

            // Проверяем все условия фильтрации
            bool isValidRefreshRate = refreshRateInt == 60 || refreshRateInt == 75 ||
                                     refreshRateInt == 120 || refreshRateInt == 144 ||
                                     refreshRateInt == 165 || refreshRateInt == 240;

            bool fitsInDisplay = res.width <= display.width && res.height <= display.height;

            if (isValidRefreshRate && is16to9 && fitsInDisplay)
            {
                string option = $"{res.width} X {res.height} {refreshRateInt} Hz";
                if (!uniqueOptions.Contains(option))
                {
                    uniqueOptions.Add(option);
                    options.Add(option);
                    filteredResolutions.Add(res);

                    // Определяем текущее разрешение для dropdown
                    if (res.width == Screen.currentResolution.width &&
                        res.height == Screen.currentResolution.height)
                    {
                        currentResolutionIndex = filteredResolutions.Count - 1;
                    }
                }
            }
        }

        // Обновляем массив разрешений и dropdown
        resolutions = filteredResolutions.ToArray();
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    void OnEnable()
    {
        fullscreenToggle.isOn = Screen.fullScreen;
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

            float aspectRatio = (float)resolutions[i].width / resolutions[i].height;
            bool is16to9 = Mathf.Abs(aspectRatio - (16f / 9f)) < 0.01f;

            if ((refreshRateInt == 60 || refreshRateInt == 75 || refreshRateInt == 120 || refreshRateInt == 144 || refreshRateInt == 165 || refreshRateInt == 240) && is16to9)
            {
                string option = $"{resolutions[i].width} X {resolutions[i].height} {refreshRateInt} Hz";

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

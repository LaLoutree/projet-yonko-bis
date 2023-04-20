using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Soptions : MonoBehaviour
{
    [SerializeField] private Dropdown resolutionsDropdown;
    [SerializeField] private Dropdown QualitiesDropdown;
    
    
    void Start()
    {
        //QUALITY

        string[] qualities = QualitySettings.names;
        QualitiesDropdown.ClearOptions();

        List<string> qualityOptions = new List<string>();
        int currentQualityIndex = 0;
        for (int i = 0; i < qualities.Length; i++)
        {
            qualityOptions.Add(qualities[i]);
            if (i==QualitySettings.GetQualityLevel())
            {
                currentQualityIndex = i;
            }
        }
        QualitiesDropdown.AddOptions(qualityOptions);
        QualitiesDropdown.value = currentQualityIndex;
        QualitiesDropdown.RefreshShownValue();


        // RESOLUTION
        Resolution[] resolutions = Screen.resolutions;
        resolutionsDropdown.ClearOptions();
        List<string> resolutionOptions = new List<string>();
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height + " (" + resolutions[i].refreshRate +
                            " Hz";
            resolutionOptions.Add(option);
            if (resolutions[i].width== Screen.width && resolutions[i].height== Screen.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionsDropdown.AddOptions(resolutionOptions);
        resolutionsDropdown.value = currentResolutionIndex;
        resolutionsDropdown.RefreshShownValue();
    }

    public void SetResolutions(int resoIndex)
    {
        Resolution resolution = Screen.resolutions[resoIndex];
        Screen.SetResolution(resolution.width,resolution.height,Screen.fullScreen);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetQuality(int Qualityindex)
    {
        QualitySettings.SetQualityLevel(Qualityindex);
    }
}

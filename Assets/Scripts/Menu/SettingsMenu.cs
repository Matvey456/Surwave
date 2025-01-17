using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    [Header("Display")] 
    [SerializeField] private GameObject displayContextMenu;
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    
    [Header("Control")]
    [SerializeField] private GameObject controlContextMenu;

    [Header("Other")]
    [SerializeField] private TMP_Text totelKilled;
    [SerializeField] private MenuButtons menuButtons;

    private Resolution[] _resolutions;

    private bool _isOpen;

    private void Start()
    {
        totelKilled.text = $"total enemies killed: {StaticHolder.enemyDeath}";
        
        _resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        
        List<string> options = new List<string>();

        for (int i = 0; i < _resolutions.Length; i++)
        {
            var newResolution = $"{_resolutions[i].height} x {_resolutions[i].width} hz {_resolutions[i].refreshRate}";
            options.Add(newResolution);
        }
        
        resolutionDropdown.AddOptions(options);
    }

    private void Update() => totelKilled.text = $"total enemies killed: {StaticHolder.enemyDeath}";

    public void ChangeResolution(int resolutionIndex)
    {
        var resolution = _resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SaveAndExitSettings()
    {
        menuButtons.settingsMenu.SetActive(false);
        menuButtons.mainMenu.SetActive(true);
    }

    public void FullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    
    public void DisplayMenu()
    {
        _isOpen = !_isOpen;
        displayContextMenu.SetActive(_isOpen);
    }
    
    public void ControlMenu()
    {
        _isOpen = !_isOpen;
        controlContextMenu.SetActive(_isOpen);
    }
}

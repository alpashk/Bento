using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUi : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button exitButton;

    private void OnEnable()
    {
        playButton.onClick.AddListener(PlayButton_OnClick);
        settingsButton.onClick.AddListener(SettingsButton_OnClick);
        exitButton.onClick.AddListener(ExitButton_OnClick);
    }

    private void OnDisable()
    {
        playButton.onClick.RemoveAllListeners();
        settingsButton.onClick.RemoveAllListeners();
        exitButton.onClick.RemoveAllListeners();
    }

    private void PlayButton_OnClick()
    {
        
    }
    
    private void SettingsButton_OnClick()
    {
        
    }
    
    private void ExitButton_OnClick()
    {
        
    }
};

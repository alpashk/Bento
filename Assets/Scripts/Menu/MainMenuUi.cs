using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUi : BaseUiScreen
{
    #region Fields

    [SerializeField] private Button playButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button exitButton;

    private Action onPlayClick;
    private Action onSettingsClick;
    private Action onExitClick;

    #endregion


    
    #region Unity lifecycle

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

    #endregion

    

    #region Methods

    public void Initialize(Action onPlayClick, Action onSettingsClick, Action onExitClick)
    {
        this.onPlayClick += onPlayClick;
        this.onSettingsClick += onSettingsClick;
        this.onExitClick += onExitClick;
    }
    
    #endregion
    
    
    
    #region Event Handlers

    private void PlayButton_OnClick()
    {
        onPlayClick?.Invoke();
    }
    
    
    private void SettingsButton_OnClick()
    {
        onSettingsClick?.Invoke();
    }
    
    private void ExitButton_OnClick()
    {
        onExitClick?.Invoke();
    }
    

    #endregion
};

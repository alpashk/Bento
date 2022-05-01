using System;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUi : BaseUiScreen
{
    #region Fields

    [SerializeField] private Toggle soundToggle;
    [SerializeField] private Toggle musicToggle;

    [SerializeField] private Button hintButton;
    [SerializeField] private Button closeButton;

    private Action onHintClick;
    private Action onCloseClick;

    #endregion


    
    #region Unity lifecycle

    private void OnEnable()
    {
        soundToggle.onValueChanged.AddListener(SoundToggle_OnClick);
        musicToggle.onValueChanged.AddListener(MusicToggle_OnClick);
        
        closeButton.onClick.AddListener(CloseButton_OnClick);
        hintButton.onClick.AddListener(HintButton_OnClick);
    }

    
    private void OnDisable()
    {
        soundToggle.onValueChanged.RemoveAllListeners();
        musicToggle.onValueChanged.RemoveAllListeners();
        
        closeButton.onClick.RemoveAllListeners();
        hintButton.onClick.RemoveAllListeners();
    }

    #endregion

    

    #region Methods

    public void Initialize(Action onHintClick, Action onCloseClick)
    {
        this.onHintClick += onHintClick;
        this.onCloseClick += onCloseClick;
    }

    #endregion



    #region Event handlers

    private void SoundToggle_OnClick(bool value)
    {
        
    }
    
    
    private void MusicToggle_OnClick(bool value)
    {
        
    }
    
    
    private void CloseButton_OnClick()
    {
        onCloseClick?.Invoke();
    }
    
    
    private void HintButton_OnClick()
    {
        onHintClick?.Invoke();
    }

    #endregion
}

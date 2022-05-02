using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayUi : MonoBehaviour
{
    #region Fields
    
    [SerializeField] private Button hintButton;
    [SerializeField] private Button resetButton;
    [SerializeField] private Button menuButton;

    private readonly string mainMenuScene = "MainMenu";
    private readonly string gameplayScene = "Gameplay";

    private Action onHintClick;

    #endregion

    

    #region Unity lifecycle

    private void OnEnable()
    {
        hintButton.onClick.AddListener(HintButton_OnClick);
        resetButton.onClick.AddListener(ResetButton_OnClick);
        menuButton.onClick.AddListener(MenuButton_OnClick);
    }

    private void OnDisable()
    {
        hintButton.onClick.RemoveAllListeners();
        resetButton.onClick.RemoveAllListeners();
        menuButton.onClick.RemoveAllListeners();
    }

    #endregion


    #region Methods

    public void Initialize(Action onHintClick)
    {
        this.onHintClick = onHintClick;
    }

    #endregion

    
    
    #region Event handlers

    private void HintButton_OnClick()
    {
        onHintClick?.Invoke();
    }
    
    
    private void ResetButton_OnClick()
    {
        SceneManager.LoadScene(gameplayScene);
    }
    
    
    private void MenuButton_OnClick()
    {
        SceneManager.LoadScene(mainMenuScene);
    }

    #endregion
}

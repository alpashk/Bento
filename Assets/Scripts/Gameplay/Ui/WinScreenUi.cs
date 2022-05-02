using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinScreenUi : MonoBehaviour
{
    #region Fields

    [SerializeField] private Button nextLevelButton;
    [SerializeField] private Button menuButton;

    private readonly string mainMenuScene = "MainMenu";
    private readonly string gameplayScene = "Gameplay";

    #endregion


    
    #region Unity lifecycle

    private void OnEnable()
    {
        nextLevelButton.onClick.AddListener(NextLevelButton_OnClick);
        menuButton.onClick.AddListener(MenuButton_OnClick);
    }

    private void OnDisable()
    {
        nextLevelButton.onClick.RemoveAllListeners();
        menuButton.onClick.RemoveAllListeners();
    }


    #endregion
    
    
    
    #region Methods

    public void Initialize(bool nextLevelIsAvailable)
    {
        nextLevelButton.interactable = nextLevelIsAvailable;
    }

    public void Enable(bool value)
    {
        gameObject.SetActive(value);
    }

    #endregion

    

    #region Event handlers

    private void NextLevelButton_OnClick()
    {
        SceneManager.LoadScene(gameplayScene);
    }
    
    
    private void MenuButton_OnClick()
    {
        SceneManager.LoadScene(mainMenuScene);
    }

    #endregion
}

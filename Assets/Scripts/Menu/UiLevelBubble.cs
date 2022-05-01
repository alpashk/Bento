using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiLevelBubble : MonoBehaviour
{
    #region Fields

    [SerializeField] private TMP_Text levelNumberText;
    [SerializeField] private Button levelButton;
    
    private int levelNumber;
    private Action<int> onLevelClick;

    #endregion
    


    #region Unity lifecycle
    
    private void OnEnable()
    {
        levelButton.onClick.AddListener(LevelButton_OnClick);
    }

    
    private void OnDisable()
    {
        levelButton.onClick.RemoveAllListeners();
    }

    #endregion

    
    
    #region Methods

    public void Initialize(int levelNumber, Action<int> onLevelClick)
    {
        levelNumberText.text = (levelNumber+1).ToString();
        this.levelNumber = levelNumber;
        this.onLevelClick = onLevelClick;
    }

    public void SetActive(bool value)
    {
        levelButton.interactable = value;
    }

    #endregion



    #region Event handlers

    private void LevelButton_OnClick()
    {
        onLevelClick?.Invoke(levelNumber);
    }

    #endregion
}

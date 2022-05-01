using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiLevelBubble : MonoBehaviour
{
    #region Fields

    [SerializeField] private TMP_Text levelNumber;
    [SerializeField] private Button levelButton;
    
    private int levelScriptable;
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

    public void Initialize(int levelNumber, int levelScriptable, Action<int> onLevelClick)
    {
        this.levelNumber.text = levelNumber.ToString();
        this.levelScriptable = levelScriptable;
        this.onLevelClick = onLevelClick;
    }

    #endregion



    #region Event handlers

    private void LevelButton_OnClick()
    {
        onLevelClick?.Invoke(levelScriptable);
    }

    #endregion
}

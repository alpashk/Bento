using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectUi : BaseUiScreen
{
    #region Fields

    [SerializeField] private Button closeButton;
    [SerializeField] private Transform layoutParent;

    [SerializeField] private GameObject horizontalLayoutPrefab;
    [SerializeField] private UiLevelBubble levelBubblePrefab;

    private Action onCloseClick;
    private Action<int> onLevelStart;

    #endregion
    
    

    #region Unity lifecycle

    private void Awake()
    {
        LevelContainer levelContainer = LevelContainer.instance;
        List<int> levels = levelContainer.LevelList;
        GameObject bubblesParent = null;

        for (int i = 0; i < levels.Count; i++)
        {
            if (i % 4 == 0)
            {
                bubblesParent = Instantiate(horizontalLayoutPrefab, layoutParent);
            }

            UiLevelBubble levelBubble = Instantiate(levelBubblePrefab, bubblesParent.transform);
            levelBubble.Initialize(i+1, levels[i], LevelBubble_OnClick);
        }
    }

    
    private void OnEnable()
    {
        closeButton.onClick.AddListener(CloseButton_OnClick);
    }

    
    private void OnDisable()
    {
        closeButton.onClick.RemoveAllListeners();
    }

    #endregion

    
    
    #region Methods

    public void Initialize(Action<int> onLevelStart, Action onCloseClick)
    {
        this.onLevelStart += onLevelStart;
        this.onCloseClick += onCloseClick;
    }

    #endregion
    
    

    #region Event handlers

    private void CloseButton_OnClick()
    {
        onCloseClick?.Invoke();
    }


    private void LevelBubble_OnClick(int levelNumber)
    {
        onLevelStart?.Invoke(levelNumber);
    }

    #endregion
}

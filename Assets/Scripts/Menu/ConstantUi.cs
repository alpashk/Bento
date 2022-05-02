using System;
using TMPro;
using UnityEngine;

public class ConstantUi : MonoBehaviour
{
    #region Fields

    [SerializeField] private TMP_Text hintText;
    
    private GameData gameData;

    #endregion

    

    #region Unity lifecycle

    private void Awake()
    {
        gameData = GameData.Instance;
        hintText.text = gameData.HintAmount.ToString();
    }

    
    private void OnEnable()
    {
        gameData.OnHintsUpdated += GameData_OnHintCountChanged;
    }
    

    private void OnDisable()
    {
        gameData.OnHintsUpdated -= GameData_OnHintCountChanged;
    }
    
    #endregion


    
    #region Event handlers

    private void GameData_OnHintCountChanged(int amount)
    {
        hintText.text = amount.ToString();
    }

    #endregion

}

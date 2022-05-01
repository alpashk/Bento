using System;
using UnityEngine;

public class GameData
{

    #region Fields

    private static GameData instance;

    private readonly string maxCompletedLevelKey = "maxUnlockedLevel";
    private readonly string hintsAmountKey = "hintsAmount";
    private readonly int startHints = 5;

    private int hintAmount;
    private int maxUnlockedLevel;
    private int currentLevel;

    public Action<int> onHintsUpdated;

    #endregion
    
    

    #region Properties

    public static GameData Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameData();
            }

            return instance;
        }
    }


    public int HintAmount
    {
        get => hintAmount;
        set
        {
            hintAmount = value;
            onHintsUpdated?.Invoke(value);
            PlayerPrefs.SetInt(hintsAmountKey, startHints);
        }
    }
    

    public int MaxUnlockedLevel
    {
        get => maxUnlockedLevel;
        private set
        {
            maxUnlockedLevel = value;
            PlayerPrefs.SetInt(maxCompletedLevelKey, maxUnlockedLevel);
        }
    }


    public int CurrentLevel
    {
        get => currentLevel;
        set => currentLevel = value;
    }

    #endregion



    #region Class lifecycle

    private GameData()
    {
        hintAmount = PlayerPrefs.GetInt(hintsAmountKey, startHints);
        maxUnlockedLevel = PlayerPrefs.GetInt(maxCompletedLevelKey, 0);
    }


    public void LevelCompleted()
    {
        if (currentLevel == MaxUnlockedLevel)
        {
            MaxUnlockedLevel++;
        }

        currentLevel++;
    }

    #endregion
}

using UnityEngine;

public class MenuUiManager : MonoBehaviour
{
    #region Fields

    [SerializeField] private MainMenuUi mainMenu;
    [SerializeField] private SettingsUi settings;
    [SerializeField] private LevelSelectUi levelSelect;

    private GameData gameData;

    #endregion
    
    

    #region Unity lifecycle

    private void Awake()
    {
        gameData = GameData.Instance;
        mainMenu.Initialize(UiScreen_OnShowLevelSelect, UiScreen_OnShowSettings, MenuUi_OnExit);
        settings.Initialize(SettingsUi_OnHintClick, UiScreen_OnShowMenu);
        levelSelect.Initialize(LevelSelect_OnLevelClick, UiScreen_OnShowMenu);
        
        UiScreen_OnShowMenu();
    }

    #endregion

    

    #region Event handlers

    private void UiScreen_OnShowMenu()
    {
        mainMenu.Show();
        settings.Hide();
        levelSelect.Hide();
    }
    

    private void UiScreen_OnShowSettings()
    {
        mainMenu.Hide();
        settings.Show();
        levelSelect.Hide();
    }
    

    private void UiScreen_OnShowLevelSelect()
    {
        mainMenu.Hide();
        settings.Hide();
        levelSelect.Show();
    }
    

    private void MenuUi_OnExit()
    {
        Application.Quit();
    }


    private void SettingsUi_OnHintClick()
    {
        gameData.HintAmount += 5;
    }


    private void LevelSelect_OnLevelClick(int levelNumber)
    {
        Debug.Log($"LevelSelected {levelNumber}");
        gameData.CurrentLevel = levelNumber;
        
        //TODO remove later
        gameData.LevelCompleted();
        Debug.Log(gameData.MaxUnlockedLevel);
    }

    #endregion
}

using UnityEngine;

public class MenuUiManager : MonoBehaviour
{
    [SerializeField] private MainMenuUi mainMenu;
    [SerializeField] private SettingsUi settings;
    [SerializeField] private LevelSelectUi levelSelect;

    private void Awake()
    {
        mainMenu.Initialize(UiScreen_OnShowLevelSelect, UiScreen_OnShowSettings, MenuUi_OnExit);
        settings.Initialize(SettingsUi_OnHintClick, UiScreen_OnShowMenu);
        levelSelect.Initialize(LevelSelect_OnLevelClick, UiScreen_OnShowMenu);
        
        UiScreen_OnShowMenu();
    }
    

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
        //GetHints
    }


    private void LevelSelect_OnLevelClick(int levelNumber)
    {
        Debug.Log($"LevelSelected {levelNumber}");
    }
}

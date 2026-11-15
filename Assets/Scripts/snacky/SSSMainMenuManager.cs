using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SSSMainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject UIMainMenuPanel;
    [SerializeField] private GameObject UIThemeSelectPanel;
    [SerializeField] private GameObject UIGameSelectMenu;
    [SerializeField] private GameObject UISettingsMenu;
    [SerializeField] private SpriteRenderer background;

    public void LoadGame()
    {
        UIMainMenuPanel.SetActive(false);
        SceneManager.LoadScene("Snacky");
    }

    public void ExitToMainMenu()
    {
        UIMainMenuPanel.SetActive(true);
    }
    public void LoadThemeMenu()
    {
        UIThemeSelectPanel.SetActive(true);
    }

    public void ExitThemeMenu()
    {
        UIThemeSelectPanel.SetActive(false);
    }

    public void LoadGameSelectMenu()
    {
        UIGameSelectMenu.SetActive(true);
    }

    public void ExitGameSelectMenu()
    {
        UIGameSelectMenu.SetActive(false);
    }

    public void LoadSettingsMenu()
    {
        UISettingsMenu.SetActive(true);
    }

    public void ExitSettingsMenu()
    {
        UISettingsMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ThemeSelect_02()
    {
        Color Theme02_back;

        if(ColorUtility.TryParseHtmlString("#210613", out Theme02_back)){
            background.color = Theme02_back;
        }
    }
}

using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SSSMainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject UIMainMenuPanel;
    [SerializeField] private GameObject UIThemeSelectPanel;
    [SerializeField] private GameObject UIGameSelectMenu;
    [SerializeField] private GameObject UISettingsMenu;

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
}

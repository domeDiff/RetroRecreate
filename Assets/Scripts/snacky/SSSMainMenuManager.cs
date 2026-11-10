using System;
using Unity.VisualScripting;
using UnityEngine;

public class SSSMainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject UIMainMenuPanel;
    [SerializeField] private GameObject UIThemeSelectPanel;

    public void LoadGame()
    {
        UIMainMenuPanel.SetActive(false);
    }

    public void QuitToMainMenu()
    {
        UIMainMenuPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void LoadThemeMenu()
    {
        UIThemeSelectPanel.SetActive(true);
    }

    public void ExitThemeMenu()
    {
        UIThemeSelectPanel.SetActive(false);
    }
}

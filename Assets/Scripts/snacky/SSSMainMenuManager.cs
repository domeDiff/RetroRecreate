using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SSSMainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject UIMainMenuPanel;
    [SerializeField] private GameObject UIThemeSelectPanel;
    [SerializeField] private GameObject UIGameSelectMenu;
    [SerializeField] private GameObject UISettingsMenu;
    [SerializeField] private SpriteRenderer background;

    [Header("Theme Elements")]
    [SerializeField] private Camera camBackgroundMM;
    [SerializeField] private Camera camBackgroundGM;
    [SerializeField] private SpriteRenderer[] sceneSprites;
    [SerializeField] private Image[] buttons;
    [SerializeField] private Image[] panels;
    [SerializeField] private TMP_Text[] texts;
    private const string ThemeKey = "SelectedTheme";

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

    public void ApplyTheme(string backgroundHex, string buttonHex, string textHex)
    {
        Color backgroundColor;
        Color buttonColor;
        Color textColor;

        if(!ColorUtility.TryParseHtmlString(backgroundHex, out backgroundColor) || 
            !ColorUtility.TryParseHtmlString(buttonHex, out buttonColor) || 
            !ColorUtility.TryParseHtmlString(textHex, out textColor))
        {
            Debug.Log("Invalide color code");
            return;
        }

        camBackgroundMM.backgroundColor = backgroundColor;
        camBackgroundGM.backgroundColor = backgroundColor;

        foreach(SpriteRenderer sprite in sceneSprites)
        {
            if (sprite != null)
                sprite.color = backgroundColor;
        }

        foreach (Image panel in panels)
        {
            if (panel != null)
                panel.color = backgroundColor;
        }

        foreach (Image button in buttons)
        {
            if (button != null)
                button.color = buttonColor;
     
        }

        foreach(TMP_Text text in texts)
        {
            if(text != null)
            {
                text.color = textColor;
            }
        }
    }

    public void styx()
    {
        ApplyTheme("#2c2c2a", "#fff3f3", "#a07cff");
        SaveTheme(0);
    }

    public void sangria()
    {
        ApplyTheme("#210613", "#fffff5", "#f63090");
        SaveTheme(1);
    }

    public void BWR()
    {
        ApplyTheme("#1c1626", "#fefffb", "#ff2961");
        SaveTheme(2);
    }

    public void Obsidian()
    {
        ApplyTheme("#000828", "#590c68", "#92215f");
        SaveTheme(3);
    }

    private void SaveTheme(int themeID)
    {
        PlayerPrefs.SetInt(ThemeKey, themeID);
        PlayerPrefs.Save();
    }

    public void LoadSnacky()
    {
        SceneManager.LoadScene("Snacky");
    }

    public void LoadYY()
    {
        SceneManager.LoadScene("YatoYattack");
    }
}

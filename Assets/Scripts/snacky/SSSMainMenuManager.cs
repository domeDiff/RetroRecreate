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
    [SerializeField] private Camera camBackground;
    [SerializeField] private SpriteRenderer[] sceneSprites;
    [SerializeField] private Image[] buttons;
    [SerializeField] private Image[] panels;
    [SerializeField] private TMP_Text[] texts;

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

        camBackground.backgroundColor = backgroundColor;

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
        int themeCode = 02;
        SaveTheme(themeCode);
    }

    public void sangria()
    {
        ApplyTheme("#210613", "#fffff5", "#f63090");
    }

    public void BWR()
    {
        ApplyTheme("#1c1626", "#fefffb", "#ff2961");
    }

    public void Obsidian()
    {
        ApplyTheme("#000828", "#590c68", "#92215f");
    }

    private void SaveTheme(int x)
    {
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

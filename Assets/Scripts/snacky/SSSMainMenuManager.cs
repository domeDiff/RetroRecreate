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
    [SerializeField] private SpriteRenderer[] sceneSprites;
    [SerializeField] private Image[] buttons;
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

        foreach(SpriteRenderer sprite in sceneSprites)
        {
            if (sprite != null)
                sprite.color = backgroundColor;
        }

        foreach(Image button in buttons)
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

    public void ThemeSelect_02()
    {
        ApplyTheme("#210613", "##fffff5", "#f63090");
    }

    public void ThemeSelect_03()
    {
        ApplyTheme("#210613", "##fffff5", "#f63090");
    }
}

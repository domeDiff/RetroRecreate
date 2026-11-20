using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameThemeManager : MonoBehaviour
{
    [SerializeField] private Camera camBackground;
    [SerializeField] private SpriteRenderer[] sceneSprites;
    [SerializeField] private SpriteRenderer[] snacks;
    [SerializeField] private SpriteRenderer[] snakes;
    [SerializeField] private TMP_Text[] texts;

    private void Start()
    {
        LoadSavedTheme();
    }

    private void LoadSavedTheme()
    {
        int themeID = PlayerPrefs.GetInt("SelectedTheme", 0);

        switch (themeID)
        {
            case 0:
                ApplyTheme("#2c2c2a", "#fff3f3", "#a07cff");
                break;

            case 1:
                ApplyTheme("#210613", "#fffff5", "#f63090");
                break;

            case 2:
                ApplyTheme("#1c1626", "#fefffb", "#ff2961");
                break;

            case 3:
                ApplyTheme("#000828", "#590c68", "#92215f");
                break;

            default:
                ApplyTheme("#2c2c2a", "#fff3f3", "#a07cff");
                break;
        }
    }

    private void ApplyTheme(string backgroundHex, string buttonHex, string textHex)
    {
        Color backgroundColor;
        Color buttonColor;
        Color textColor;

        ColorUtility.TryParseHtmlString(backgroundHex, out backgroundColor);
        ColorUtility.TryParseHtmlString(buttonHex, out buttonColor);
        ColorUtility.TryParseHtmlString(textHex, out textColor);

        camBackground.backgroundColor = backgroundColor;

        foreach (SpriteRenderer sprite in sceneSprites)
        {
            if (sprite != null)
                sprite.color = backgroundColor;
        }

        foreach (SpriteRenderer snack in snacks)
        {
            if (snack != null)
                snack.color = buttonColor;
        }

        foreach (SpriteRenderer snake in snakes)
        {
            if (snake != null)
                snake.color = textColor;
        }
    }
}
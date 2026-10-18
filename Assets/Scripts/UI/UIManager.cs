using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [Header("UI Text References")]
    [SerializeField] private TextMeshProUGUI calmLightsText;
    [SerializeField] private TextMeshProUGUI subtitleText;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    // Updates the light counter text
    public void UpdateCalmLights(int count)
    {
        if (calmLightsText != null)
        {
            calmLightsText.text = "Calm Lights: " + count;
        }
    }

    // Displays subtitle text on screen
    public void DisplaySubtitle(string text)
    {
        if (subtitleText != null)
        {
            subtitleText.text = text;
        }
    }
}
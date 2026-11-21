using UnityEngine;
using UnityEngine.SceneManagement;

public class CalmLightCollectible : MonoBehaviour
{
    [Header("Audio Reference")]
    [SerializeField] private AudioClip collectSound;

    [Header("Collectible Settings")]
    [SerializeField] private int lightValue = 1;

    private static int collectedLights = 0;
    private static int totalLights = 0;
    private static int currentSceneBuildIndex = -1;

    private void Awake()
    {
        int sceneBuildIndex = SceneManager.GetActiveScene().buildIndex;

        // Reset Calm Light progress when entering a new scene
        if (currentSceneBuildIndex != sceneBuildIndex)
        {
            currentSceneBuildIndex = sceneBuildIndex;
            collectedLights = 0;

            totalLights = FindObjectsOfType<CalmLightCollectible>(true).Length;
        }
    }

    private void Start()
    {
        if (UIManager.Instance != null)
        {
            UIManager.Instance.UpdateCalmLights(collectedLights, totalLights);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object colliding with the collectible is the player
        if (!collision.CompareTag("Player"))
            return;

        // Play collectible sound
        if (AudioManager.Instance != null && collectSound != null)
        {
            AudioManager.Instance.PlaySFX(collectSound);
        }

        // Increase Calm Light count
        collectedLights += lightValue;

        // Check if Calm Focus can be unlocked
        if (CalmFocusAbility.Instance != null)
        {
            CalmFocusAbility.Instance.CheckUnlock(collectedLights);
        }

        // Update HUD counter
        if (UIManager.Instance != null)
        {
            UIManager.Instance.UpdateCalmLights(collectedLights, totalLights);
        }

        // Check if all Calm Lights have been collected
        if (collectedLights >= totalLights)
        {
            LoadNextScene();
        }

        // Remove collected Calm Light
        Destroy(gameObject);
    }

    private void LoadNextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("No next scene configured in Build Settings.");
        }
    }
}
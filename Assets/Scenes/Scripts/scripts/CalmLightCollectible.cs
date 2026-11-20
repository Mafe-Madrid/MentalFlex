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
        if (!collision.CompareTag("Player"))
            return;

        if (AudioManager.Instance != null && collectSound != null)
        {
            AudioManager.Instance.PlaySFX(collectSound);
        }

        collectedLights += lightValue;

        if (UIManager.Instance != null)
        {
            UIManager.Instance.UpdateCalmLights(collectedLights, totalLights);
        }

        // Load the next scene after collecting all Calm Lights
        if (collectedLights >= totalLights)
        {
            LoadNextScene();
        }

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
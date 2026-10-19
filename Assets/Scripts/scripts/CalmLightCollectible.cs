using UnityEngine;

public class CalmLightCollectible : MonoBehaviour
{
    [Header("Audio Reference")]
    [SerializeField] private AudioClip collectSound;

    [SerializeField] private int lightValue = 1;

        private static int collectedLights = 0;
    private static int totalLights = 2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object colliding with the collectible is the player
        if (collision.CompareTag("Player"))
        {
            if (AudioManager.instance != null && collectSound != null)
            {
                AudioManager.instance.PlaySFX(collectSound);
            }

            // Increase the global count of collected light items
            collectedLights += lightValue;

            // Update the user interface counter on the screen via UIManager
            if (UIManager.instance != null)
            {
                UIManager.instance.UpdateCalmLights(collectedLights, totalLights);
            }

            // Destroy the collectible object from the scene 
            Destroy(gameObject);
        }
    }
}

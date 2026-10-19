using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

///<summary>
///Manages player health, respawn checkpoints, collection tracking, and hazard collisions.
///Author: Jasbleidy Mayerly Rodriguez Medina
///</summary>

public class PlayerHealthAndRespawn : MonoBehaviour
{
    [Header("Respawn Settings")]

    public Vector3 currentCheckpoint;

    [Header("Score and Progress")]

    public int calmLightsCollected = 0;
    public int totalCalmLights = 10;

    [Header("Audio Clips")]

    public AudioClip collectSound;

    void Start()
    {
        // Set the initial checkpoint position to the player's starting spawn point
        currentCheckpoint = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player collides with the hazard area (SwampWater)
        if (collision.CompareTag("SwampWater"))
        {
            RaspawnAtLastCheckpoint();
        }

        // Check if the player collects a calm light item
        if (collision.CompareTag("CalmLight"))
        {
            calmLightsCollected++;

            // Play collection sound effect if available
            if (AudioManager.instance != null && collectSound != null)
            {
                AudioManager.instance.PlaySFX(collectSound);
            }

            // Update the user interface via UIManager singleton
            if (UIManager.instance != null)
            {
                UIManager.instance.UpdateCalmLights(calmLightsCollected, totalCalmLights);
            }

            // Remove the collected light object from the scene
            Destroy(collision.gameObject);
        }

        // Check if the player reaches a new checkpoint
        if (collision.CompareTag("Checkpoint"))
        {
            currentCheckpoint = collision.transform.position;
        }
    }

    public void RaspawnAtLastCheckpoint()
    {
        // Reset player position to the last saved checkpoint
        transform.position = currentCheckpoint;

        // Stop movement physics by resetting linear velocity
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
    }

}

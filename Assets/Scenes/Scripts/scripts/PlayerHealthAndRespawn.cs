using UnityEngine;

/// <summary>
/// Manages player health, respawn checkpoints,
/// collection tracking, and hazard collisions.
/// Author: Jasbleidy Mayerly Rodriguez Medina
/// </summary>
public class PlayerHealthAndRespawn : MonoBehaviour
{
    [Header("Respawn Settings")]
    public Vector3 currentCheckpoint;

    [Header("Animation")]
    public Animator abanAnimator;

    [Header("Score and Progress")]
    public int calmLightsCollected = 0;
    public int totalCalmLights = 10;

    [Header("Audio Clips")]
    public AudioClip collectSound;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Set the initial checkpoint position
        // to the player's starting spawn point
        currentCheckpoint = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player collides with the hazard area
        if (collision.CompareTag("SwampWater"))
        {
            RespawnAtLastCheckpoint();
        }

        // Check if the player collects a calm light
        if (collision.CompareTag("CalmLight"))
        {
            calmLightsCollected++;

            // Play collection sound effect
            if (AudioManager.Instance != null && collectSound != null)
            {
                AudioManager.Instance.PlaySFX(collectSound);
            }

            // Update the user interface
            if (UIManager.Instance != null)
            {
                UIManager.Instance.UpdateCalmLights(
                    calmLightsCollected,
                    totalCalmLights
                );
            }

            // Remove the collected light
            Destroy(collision.gameObject);
        }

        // Check if the player reaches a new checkpoint
        if (collision.CompareTag("Checkpoint"))
        {
            currentCheckpoint = collision.transform.position;
        }
    }

    public void RespawnAtLastCheckpoint()
    {
        // Move player to the last saved checkpoint
        transform.position = currentCheckpoint;

        // Stop player movement
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
        }

        // Play respawn animation
        if (abanAnimator != null)
        {
            abanAnimator.SetTrigger("Respawn");
        }
    }
}
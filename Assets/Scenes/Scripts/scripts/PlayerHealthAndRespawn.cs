using UnityEngine;

//I handle player respawn points and collisions with hazards.

public class PlayerHealthAndRespawn : MonoBehaviour
{
    [Header("Respawn Settings")]

    public Vector3 currentCheckpoint;

    [Header("Animation")]

    public Animator characterAnimator;

    [Header("Audio Clips")]

    public AudioClip hazardSound;
    public AudioClip checkpointSound;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        if (characterAnimator == null)
        {
            characterAnimator = GetComponentInChildren<Animator>();
        }
    }

    private void Start()
    {
        // Block covering how to use the starting position as an initial control point

        currentCheckpoint = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Respawn when touching a danger zone

        if (collision.CompareTag("SwampWater"))
        {
            if (AudioManager.Instance != null && hazardSound != null)
            {
                AudioManager.Instance.PlaySFX(hazardSound);
            }

            RespawnAtLastCheckpoint();
        }

        // Save new checkpoint position

        if (collision.CompareTag("Checkpoint"))
        {
            currentCheckpoint = collision.transform.position;

            if (AudioManager.Instance != null && checkpointSound != null)
            {
                AudioManager.Instance.PlaySFX(checkpointSound);
            }
        }
    }

    public void RespawnAtLastCheckpoint()
    {
        // Place the player at the last checkpoint

        transform.position = currentCheckpoint;

        // restore the player's speed so they stop falling

        if (rb != null)
        {
            rb.velocity = Vector2.zero;
        }

        // Activate the respawn animation

        if (characterAnimator != null)
        {
            characterAnimator.SetTrigger("Respawn");
        }
    }
}
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

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
        currentCheckpoint = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SwampWater"))
        {
            RaspawnAtLastCheckpoint();
        }

        if (collision.CompareTag("CalmLight"))
        {
            calmLightsCollected++;

           if (AudioManager.instance != null && collectSound != null)
            {
                AudioManager.instance.PlaySFX(collectSound);
            }

           if (UIManager.instance != null)
            {
                UIManager.instance.UpdateCalmLights(calmLightsCollected, totalCalmLights);
            }

            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Checkpoint"))
        {
            currentCheckpoint = collision.transform.position;
        }
    }

    public void RaspawnAtLastCheckpoint()
    {
        transform.position = currentCheckpoint;

        GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
    }

}

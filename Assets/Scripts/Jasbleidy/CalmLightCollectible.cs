using UnityEngine;

public class CalmLightCollectible : MonoBehaviour
{
    [Header("Audio Reference")]
    [SerializeField] private AudioClip collectSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            if (AudioManager.instance != null && collectSound != null)
            {
                AudioManager.instance.PlaySFX(collectSound);
            }

            Destroy(gameObject);
        }
    }
}

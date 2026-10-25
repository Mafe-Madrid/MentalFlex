using UnityEngine;

public class SceneAudioController : MonoBehaviour
{
    [Header("Background Music")]
    [SerializeField] private AudioClip backgroundMusic;

    [Header("Sound Effects (SFX)")]
    [SerializeField] private AudioClip checkpointSound;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip collectionSound;
    [SerializeField] private AudioClip buttonClickSound;

    private void Start()
    {
        if (backgroundMusic != null && AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayMusic(backgroundMusic);
        }
    }

    public void PlayCheckpointSound()
    {
        if (checkpointSound != null && AudioManager.Instance != null)
        {
            AudioManager.Instance.PlaySFX(checkpointSound);
        }
    }

    public void PlayJumpSound()
    {
        if (jumpSound != null && AudioManager.Instance != null)
        {
            AudioManager.Instance.PlaySFX(jumpSound);
        }
    }

    public void PlayCollectionSound()
    {
        if (collectionSound != null && AudioManager.Instance != null)
        {
            AudioManager.Instance.PlaySFX(collectionSound);
        }
    }

    public void PlayButtonClickSound()
    {
        if (buttonClickSound != null && AudioManager.Instance != null)
        {
            AudioManager.Instance.PlaySFX(buttonClickSound);
        }
    }
}
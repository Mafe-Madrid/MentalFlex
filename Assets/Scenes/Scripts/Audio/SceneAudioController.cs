using UnityEngine;

public class SceneAudioController : MonoBehaviour
{
    [Header("Background Music")]
    [SerializeField] private AudioClip backgroundMusic;
    [SerializeField] private AudioClip[] zoneMusic;

    [Header("Sound Effects (SFX)")]
    [SerializeField] private AudioClip walkSound;
    [SerializeField] private AudioClip checkpointSound;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip collectionSound;

    private void Start()
    {
        // Sends the background music to the AudioManager when the scene starts
        if (backgroundMusic != null && AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayMusic(backgroundMusic);
        }
    }

    // Public methods for team members to trigger zone music and SFX easily
    public void PlayZoneMusic(int zoneIndex)
    {
        if (zoneMusic != null && zoneIndex >= 0 && zoneIndex < zoneMusic.Length && AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayMusic(zoneMusic[zoneIndex]);
        }
    }

    public void PlayWalkSound()
    {
        if (walkSound != null && AudioManager.Instance != null)
            AudioManager.Instance.PlaySFX(walkSound);
    }

    public void PlayCheckpointSound()
    {
        if (checkpointSound != null && AudioManager.Instance != null)
            AudioManager.Instance.PlaySFX(checkpointSound);
    }

    public void PlayJumpSound()
    {
        if (jumpSound != null && AudioManager.Instance != null)
            AudioManager.Instance.PlaySFX(jumpSound);
    }

    public void PlayCollectionSound()
    {
        if (collectionSound != null && AudioManager.Instance != null)
            AudioManager.Instance.PlaySFX(collectionSound);
    }
}
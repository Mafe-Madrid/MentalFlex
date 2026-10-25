using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    private bool musicMuted = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Play background music
    public void PlayMusic(AudioClip clip)
    {
        if (clip == null || musicSource == null)
            return;

        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
    }

    // Play a sound effect
    public void PlaySFX(AudioClip clip)
    {
        if (clip == null || sfxSource == null)
            return;

        sfxSource.PlayOneShot(clip);
    }

    // Change music volume
    public void SetMusicVolume(float volume)
    {
        if (musicSource != null)
        {
            musicSource.volume = volume;
        }
    }

    // Turn background music on/off
    public void ToggleMusic()
    {
        if (musicSource == null)
            return;

        musicMuted = !musicMuted;
        musicSource.mute = musicMuted;

        Debug.Log(musicMuted ? "Music OFF" : "Music ON");
    }
}
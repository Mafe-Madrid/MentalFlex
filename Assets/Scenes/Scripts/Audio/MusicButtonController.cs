using UnityEngine;

public class MusicButtonController : MonoBehaviour
{
    public void ToggleMusic()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.ToggleMusic();
        }
    }
}
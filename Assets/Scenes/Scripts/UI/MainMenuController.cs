using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("SC_CharacterSelection");
    }

    public void ShowCredits()
    {
        SceneManager.LoadScene("SC_Credits");
    }

    public void ExitGame()
    {
        Debug.Log("Exit game.");

        Application.Quit();
    }
}
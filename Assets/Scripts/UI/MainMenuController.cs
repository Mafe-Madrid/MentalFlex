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
        Debug.Log("Credits selected.");
    }

    public void ExitGame()
    {
        Debug.Log("Exit game.");

        Application.Quit();
    }
}
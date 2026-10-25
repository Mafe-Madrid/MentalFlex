using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectionController : MonoBehaviour
{
    public void SelectAban()
    {
        SceneManager.LoadScene("SC_Zone01_AnxietyFog");
    }

    public void GoBack()
    {
        SceneManager.LoadScene("SC_MainMenu");
    }
}
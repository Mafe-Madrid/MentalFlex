using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectionController : MonoBehaviour
{
    public void SelectAban()
    {
        PlayerPrefs.SetString("SelectedCharacter", "Aban");
        PlayerPrefs.Save();

        SceneManager.LoadScene("SC_Zone01_AnxietyFog");
    }

    public void SelectTrista()
    {
        PlayerPrefs.SetString("SelectedCharacter", "Trista");
        PlayerPrefs.Save();

        SceneManager.LoadScene("SC_Zone01_AnxietyFog");
    }

    public void SelectFragita()
    {
        PlayerPrefs.SetString("SelectedCharacter", "Fragita");
        PlayerPrefs.Save();

        SceneManager.LoadScene("SC_Zone01_AnxietyFog");
    }

    public void GoBack()
    {
        SceneManager.LoadScene("SC_MainMenu");
    }
}
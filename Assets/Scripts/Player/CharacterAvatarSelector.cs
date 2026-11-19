using UnityEngine;

public class CharacterAvatarSelector : MonoBehaviour
{
    public GameObject aban;
    public GameObject trista;
    public GameObject fragita;

    private void Start()
    {
        string selectedCharacter = PlayerPrefs.GetString("SelectedCharacter", "Aban");

        aban.SetActive(false);
        trista.SetActive(false);
        fragita.SetActive(false);

        switch (selectedCharacter)
        {
            case "Trista":
                trista.SetActive(true);
                break;

            case "Fragita":
                fragita.SetActive(true);
                break;

            default:
                aban.SetActive(true);
                break;
        }
    }
}

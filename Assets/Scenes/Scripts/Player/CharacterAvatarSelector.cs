using UnityEngine;

public class CharacterAvatarSelector : MonoBehaviour
{
    [Header("Characters")]
    public GameObject aban;
    public GameObject trista;
    public GameObject fragita;

    [Header("Player References")]
    public PlayerController playerController;
    public PlayerHealthAndRespawn playerHealth;

    private void Start()
    {
        string selectedCharacter =
            PlayerPrefs.GetString("SelectedCharacter", "Aban");

        aban.SetActive(false);
        trista.SetActive(false);
        fragita.SetActive(false);

        GameObject selectedAvatar;

        switch (selectedCharacter)
        {
            case "Trista":
                selectedAvatar = trista;
                break;

            case "Fragita":
                selectedAvatar = fragita;
                break;

            default:
                selectedAvatar = aban;
                break;
        }

        ActivateCharacter(selectedAvatar);
    }

    private void ActivateCharacter(GameObject character)
    {
        if (character == null)
            return;

        character.SetActive(true);

        SpriteRenderer spriteRenderer =
            character.GetComponentInChildren<SpriteRenderer>();

        Animator animator =
            character.GetComponentInChildren<Animator>();

        if (playerController != null)
        {
            playerController.characterSprite = spriteRenderer;
            playerController.characterAnimator = animator;

            // Trista sprites are originally facing left.
            // Aban and Fragita face right.
            playerController.characterFacesLeft =
                character == trista;
        }

        if (playerHealth != null)
        {
            playerHealth.characterAnimator = animator;
        }
    }
}
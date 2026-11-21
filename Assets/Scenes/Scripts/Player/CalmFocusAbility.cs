using UnityEngine;
using TMPro;
using System.Collections;

public class CalmFocusAbility : MonoBehaviour
{
    public static CalmFocusAbility Instance { get; private set; }

    [Header("Unlock Settings")]
    [SerializeField] private int lightsRequired = 2;

    [Header("Ability Settings")]
    [SerializeField] private float effectRadius = 5f;
    [SerializeField] private float calmDuration = 3f;
    [SerializeField] private float cooldown = 5f;

    [Header("UI")]
    [SerializeField] private TMP_Text abilityMessageText;

    [Header("Optional Animation")]
    [SerializeField] private Animator playerAnimator;

    private bool isUnlocked = false;
    private bool isOnCooldown = false;

    private void Awake()
    {
        Instance = this;

        if (abilityMessageText != null)
        {
            abilityMessageText.text = "";
        }
    }

    private void Update()
    {
        if (!isUnlocked || isOnCooldown)
            return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            ActivateCalmFocus();
        }
    }

    public void CheckUnlock(int collectedLights)
    {
        if (!isUnlocked && collectedLights >= lightsRequired)
        {
            isUnlocked = true;

            Debug.Log("Calm Focus unlocked!");

            if (abilityMessageText != null)
            {
                StopAllCoroutines();
                StartCoroutine(ShowUnlockMessage());
            }
        }
    }

    private IEnumerator ShowUnlockMessage()
    {
        abilityMessageText.text =
            "Nueva habilidad: Calm Focus\nPresiona E para calmar los obstáculos cercanos.";

        yield return new WaitForSeconds(5f);

        abilityMessageText.text = "";
    }

    private void ActivateCalmFocus()
    {
        if (playerAnimator != null)
        {
            playerAnimator.SetTrigger("Ability");
        }

        Collider2D[] nearbyObjects = Physics2D.OverlapCircleAll(
            transform.position,
            effectRadius
        );

        foreach (Collider2D nearbyObject in nearbyObjects)
        {
            FloatingBrain brain = nearbyObject.GetComponent<FloatingBrain>();

            if (brain != null)
            {
                brain.CalmBrain(calmDuration);
            }
        }

        StartCoroutine(CooldownRoutine());
    }

    private IEnumerator CooldownRoutine()
    {
        isOnCooldown = true;

        yield return new WaitForSeconds(cooldown);

        isOnCooldown = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, effectRadius);
    }
}
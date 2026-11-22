using UnityEngine;

// Controls player movement, jumping, animations
// Script corrected by Gemini AI

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private bool isGrounded;

    [Header("Visual")]
    public SpriteRenderer characterSprite;
    public Animator characterAnimator;
    public bool characterFacesLeft = false;

    [Header("Audio Clips")]
    public AudioClip jumpSound;
    public AudioClip skillSound;

    [Header("Skill Settings")]
    public KeyCode skillKey = KeyCode.E;
    public bool isSkillActive = false;
    public float skillDuration = 4f;

    private Rigidbody2D rb;
    private float horizontalInput;
    private float skillTimer = 0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        if (characterSprite == null)
        {
            characterSprite = GetComponentInChildren<SpriteRenderer>();
        }

        if (characterAnimator == null)
        {
            characterAnimator = GetComponentInChildren<Animator>();
        }
    }

    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        // Check if the player is touching the ground
        if (groundCheck != null)
        {
            isGrounded = Physics2D.OverlapCircle(
                groundCheck.position,
                groundCheckRadius,
                groundLayer
            );
        }

        // Update animation parameters
        if (characterAnimator != null)
        {
            characterAnimator.SetBool("IsGrounded", isGrounded);
            characterAnimator.SetFloat(
                "Speed",
                Mathf.Abs(horizontalInput)
            );
        }

        // Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }

        // Ability
        if (Input.GetKeyDown(skillKey) && !isSkillActive)
        {
            ActivateRegulationSkill();
        }

        // Ability duration
        if (isSkillActive)
        {
            skillTimer -= Time.deltaTime;

            if (skillTimer <= 0f)
            {
                isSkillActive = false;
            }
        }

        UpdateFacingDirection();
    }

    private void FixedUpdate()
    {
        if (rb != null)
        {
            rb.velocity = new Vector2(
                horizontalInput * moveSpeed,
                rb.velocity.y
            );
        }
    }

    private void UpdateFacingDirection()
    {
        if (characterSprite == null)
            return;

        if (horizontalInput > 0f)
        {
            characterSprite.flipX = characterFacesLeft;
        }
        else if (horizontalInput < 0f)
        {
            characterSprite.flipX = !characterFacesLeft;
        }
    }

    private void Jump()
    {
        if (rb != null)
        {
            rb.velocity = new Vector2(
                rb.velocity.x,
                jumpForce
            );
        }

        // Immediately tell the Animator that the player
        // is no longer touching the ground.
        isGrounded = false;

        if (characterAnimator != null)
        {
            characterAnimator.SetBool(
                "IsGrounded",
                false
            );

            characterAnimator.SetTrigger(
                "Jump"
            );
        }

        if (AudioManager.Instance != null &&
            jumpSound != null)
        {
            AudioManager.Instance.PlaySFX(
                jumpSound
            );
        }
    }

    private void ActivateRegulationSkill()
    {
        isSkillActive = true;
        skillTimer = skillDuration;

        if (characterAnimator != null)
        {
            characterAnimator.SetTrigger(
                "Ability"
            );
        }

        if (AudioManager.Instance != null &&
            skillSound != null)
        {
            AudioManager.Instance.PlaySFX(
                skillSound
            );
        }
    }

    public void TriggerRespawn()
    {
        if (characterAnimator != null)
        {
            characterAnimator.SetTrigger(
                "Respawn"
            );
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.yellow;

            Gizmos.DrawWireSphere(
                groundCheck.position,
                groundCheckRadius
            );
        }
    }
}
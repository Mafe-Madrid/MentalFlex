using UnityEngine;

/// <summary>
/// Controls player movement, jumping, animations,
/// visual direction, and emotional regulation skill activation.
/// </summary>
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
    public SpriteRenderer abanSprite;
    public Animator abanAnimator;

    [Header("Audio Clips")]
    public AudioClip jumpSound;
    public AudioClip skillSound;

    [Header("Skill Settings")]
    public KeyCode skillKey = KeyCode.E;
    public bool isSkillActive = false;

    private Rigidbody2D rb;
    private float horizontalInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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

        // Update animations
        if (abanAnimator != null)
        {
            abanAnimator.SetBool("IsGrounded", isGrounded);
            abanAnimator.SetFloat("Speed", Mathf.Abs(horizontalInput));
        }

        // Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }

        // Emotional regulation skill
        if (Input.GetKeyDown(skillKey) && !isSkillActive)
        {
            ActivateRegulationSkill();
        }

        UpdateFacingDirection();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(
            horizontalInput * moveSpeed,
            rb.velocity.y
        );
    }

    private void UpdateFacingDirection()
    {
        if (abanSprite == null)
            return;

        if (horizontalInput > 0)
        {
            abanSprite.flipX = false;
        }
        else if (horizontalInput < 0)
        {
            abanSprite.flipX = true;
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(
            rb.velocity.x,
            jumpForce
        );

        if (AudioManager.Instance != null && jumpSound != null)
        {
            AudioManager.Instance.PlaySFX(jumpSound);
        }
    }

    private void ActivateRegulationSkill()
    {
        isSkillActive = true;

        if (AudioManager.Instance != null && skillSound != null)
        {
            AudioManager.Instance.PlaySFX(skillSound);
        }

        Invoke(nameof(ResetSkill), 4f);
    }

    private void ResetSkill()
    {
        isSkillActive = false;
    }
}
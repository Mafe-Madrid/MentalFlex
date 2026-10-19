using NUnit.Framework;
using System.Text.RegularExpressions;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

///<summary>
///Controls player movement, jumping, and emotional regulation skill activatiom.
///Author: Jasbleidy Mayerly Rodriguez Medina
///</summary>
public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]

    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    [Header("Ground check")]

    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    private bool isGrounded;

    [Header("Audio Clips (Local Reference)")]

    public AudioClip jumpSound;
    public AudioClip skillSound;

    [Header("Skill Settings")]

    public KeyCode skillKey = KeyCode.E;
    public bool isSkillActive = false;

    private Rigidbody2D rb;
    private float horizontalInput;

    void Start()
    {
        // Cache the Rigidbody2D component attached to the player
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Capture horizontal input from standard axes (A / D or Left/ Right arrows)
        horizontalInput = Input.GetAxisRaw("Horizontal");

        // Check if the player is touching the ground layer using an overlap circle
        if (groundCheck != null)
        {

            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        }

        // Trigger jump if jump button is pressed and the player is grounded
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }

        // Trigger emotional regulation skill if assigned key is pressed and skill is ready
        if (Input.GetKeyDown(skillKey) && !isSkillActive)
        {
            ActivateRegulationSkill();
        }
    }

    void FixedUpdate()
    {
        // Apply physics-based horizontal velocity while maintaining current vertical velocity
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y); 
    }

    private void Jump()
    {
        // Apply vertical force for jumping
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

        // Play jump sound effect if audio manager and sound clip are available
        if (AudioManager.instance != null && jumpSound != null)
        {
            AudioManager.instance.PlaySFX(jumpSound);
        }
    }

    private void ActivateRegulationSkill()
    {
        // Activate the regulation skill state
        isSkillActive = true;
        Debug.Log("Emotional Regulation Skill Activated!");

        // Play skill audio effect if available
        if (AudioManager.instance != null && skillSound != null)
        {
            AudioManager.instance.PlaySFX(skillSound);
        }

        // Reset the skill state after a 4-second delay
        Invoke(nameof(ResetSkill), 4f);
    }

    private void ResetSkill()
    {
        // Deactivate the skill flag to allow reuse
        isSkillActive = false;   
    }
}


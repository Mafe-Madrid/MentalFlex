using UnityEngine;

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
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (groundCheck != null)
        {

            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }

        if (Input.GetKeyDown(skillKey) && !isSkillActive)
        {
            ActivateRegulationSkill();
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y); 
    }

    private void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

        if (AudioManager.instance != null && jumpSound != null)
        {
            AudioManager.instance.PlaySFX(jumpSound);
        }
    }

    private void ActivateRegulationSkill()
    {
        isSkillActive = true;
        Debug.Log("Emotional Regulation Skill Activated!");

        if (AudioManager.instance != null && skillSound != null)
        {
            AudioManager.instance.PlaySFX(skillSound);
        }

        Invoke(nameof(ResetSkill), 4f);
    }

    private void ResetSkill()
    {
        isSkillActive = false;   
    }
}


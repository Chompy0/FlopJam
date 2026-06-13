using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{
    [SerializeField] private bool isGrounded;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D rb;
    private MainController controller;

    void Awake()
    {
        controller = new MainController();
        rb = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        controller.Enable();
        controller.Player.Jump.performed += OnJump;
    }

    void OnDisable()
    {
        controller.Player.Jump.performed -= OnJump;
        controller.Disable();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,groundLayer);
    }
    private void OnJump(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            isGrounded = false;
            rb.linearVelocityY = jumpForce;
        }
    }
}

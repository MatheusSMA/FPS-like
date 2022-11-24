using UnityEngine;

public class InputMove : MonoBehaviour
{
    private CharacterController _charactherController;

    [Header("Mov vars")]
    [SerializeField] private float speed;
    Vector3 velocity;
    private float gravity = -9.81f;

    [Header("Ground check Vars")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask groundLayer;
    private bool isGrounded;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        _charactherController = GetComponent<CharacterController>();
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void FixedUpdate()
    {
        Move();
        GroundCheck();
    }

    private void Move()
    {
        velocity.y += gravity * Time.deltaTime;

        float inputX = Input.GetAxis("Vertical");
        float inputZ = Input.GetAxis("Horizontal");

        Vector3 moving = transform.right * inputZ + transform.forward * inputX;
        _charactherController.SimpleMove(moving * speed * Time.deltaTime);


    }

    private void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(groundCheck.transform.position, groundCheckRadius, groundLayer);
        if (isGrounded && velocity.y < 0f) velocity.y = -1f;
    }
}
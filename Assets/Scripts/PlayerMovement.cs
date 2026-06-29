using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float turnSpeed = 80f;
    public float gravity = -20f;
    public float jumpHeight = 1.5f;

    private CharacterController controller;
    private Vector3 velocity;
    private Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        bool grounded = controller.isGrounded;

        if (grounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");

        if (animator != null)
        {
            animator.SetFloat("speed", Mathf.Abs(vertical));
        }

        transform.Rotate(0f, horizontal * turnSpeed * Time.deltaTime, 0f);

        Vector3 move = transform.forward * vertical;
        controller.Move(move * moveSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
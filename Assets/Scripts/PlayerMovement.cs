using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float turnSpeed = 80f;
    public float gravity = -20f;
    public float jumpHeight = 1.5f;

    public Transform cameraPivot;
    public float cameraSensitivity = 120f;

    private CharacterController controller;
    private Vector3 velocity;
    private float cameraPitch = 20f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        HandleCamera();
        MovePlayer();
    }

    void HandleCamera()
    {
        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            transform.Rotate(Vector3.up * mouseX * cameraSensitivity * Time.deltaTime);

            cameraPitch -= mouseY * cameraSensitivity * Time.deltaTime;
            cameraPitch = Mathf.Clamp(cameraPitch, -30f, 60f);

            cameraPivot.localRotation = Quaternion.Euler(cameraPitch, 0f, 0f);
        }
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
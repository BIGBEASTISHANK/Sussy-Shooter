using UnityEngine;

public class movenment : MonoBehaviour
{
    private float moveSpeed;
    private bool isGrounded;

    private Vector3 velocity;
    private CharacterController controller;

    [SerializeField] private float walkSpeed, runSpeed, gravity, groundCheckSize, jumpHeight;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private GameObject inGameUI, pauseUI;

    private void Start()
    {
        controller = GetComponentInChildren<CharacterController>();
    }

    private void Update()
    {
        if(Time.timeScale == 1) Move();
        GamePause();
    }

    private void Move()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckSize, groundLayer);

        if (isGrounded && velocity.y < 0) velocity.y = -2;

        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");

        Vector3 move = new Vector3(moveX, 0, moveZ);
        move = transform.TransformDirection(move);

        if (move != Vector3.zero && !Input.GetKey(KeyCode.LeftShift)) Walk();

        else if (move != Vector3.zero && Input.GetKey(KeyCode.LeftShift)) Run();

        if (isGrounded) Jump();

        move *= moveSpeed;
        controller.Move(move * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void Walk()
    {
        moveSpeed = walkSpeed;
    }

    private void Run()
    {
        moveSpeed = runSpeed;
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump")) velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
    }

    private void GamePause()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                inGameUI.SetActive(false);
                pauseUI.SetActive(true);

            }
            else
            {
                Time.timeScale = 1;
                pauseUI.SetActive(false);
                inGameUI.SetActive(true);
            }
        }
    }
}
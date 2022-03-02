using UnityEngine;

public class camera : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity, xRotation, yRotation, zRotation;

    [SerializeField] private Transform player;
    public AudioSource sound;

    void Start()
    {
        sound = GetComponent<AudioSource>();
        player = transform.parent;
    }

    void Update()
    {
        if (Time.timeScale == 1) Cursor.lockState = CursorLockMode.Locked;
        if (Time.timeScale == 0) Cursor.lockState = CursorLockMode.None;

        float mouseX = Input.GetAxisRaw("Mouse X");
        float mouseY = Input.GetAxisRaw("Mouse Y");

        xRotation -= mouseY * mouseSensitivity * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, zRotation);

        player.Rotate(Vector3.up * mouseX * mouseSensitivity * Time.deltaTime);

    }
}
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float gravity = -9.81f;

    private CharacterController characterController;
    private Vector2 moveInput;
    private float verticalVelocity;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void Update()
    {
        Vector3 movement = transform.right * moveInput.x + transform.forward * moveInput.y;

        if (characterController.isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = -2f;
        }

        verticalVelocity += gravity * Time.deltaTime;

        movement.y = verticalVelocity;

        characterController.Move(movement * speed * Time.deltaTime);
    }
}
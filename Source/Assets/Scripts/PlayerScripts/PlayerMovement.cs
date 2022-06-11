using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    PlayerController controller;
    Rigidbody rb;
    Transform sphereCheckPos;
    LayerMask groundMask;
    
    Vector3 moveVector;
    public float speed, jumpForce, groundDistance, dashCooldown, dashForce;
    bool isGrounded;
    bool canDash = true;

    void Start()
    {
        controller = new PlayerController();
        rb = GetComponent<Rigidbody>();
        groundMask = LayerMask.GetMask("Ground");

        foreach(Transform child in transform)
        {
            if (child.name == "GroundCheck")
            {
                sphereCheckPos = child;
                break;
            }
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = Quaternion.AngleAxis(transform.eulerAngles.y, Vector3.up) * moveVector * speed;
        rb.angularVelocity = Vector3.zero;
        rb.MovePosition(rb.position + movement);
        rb.AddForce(movement * 2f);
    }

    public void Jump(InputAction.CallbackContext callback)
    {
        isGrounded = Physics.CheckSphere(sphereCheckPos.position, groundDistance, groundMask);

        if (isGrounded && callback.action.WasPerformedThisFrame())
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
    }

    public void Move(InputAction.CallbackContext callback)
    {
        Vector2 input = callback.action.ReadValue<Vector2>().normalized;
        moveVector = new Vector3(input.x, 0f, input.y);
    }

    public void Dash(InputAction.CallbackContext callback)
    {
        if (canDash && callback.action.WasPerformedThisFrame())
        {
            canDash = false;
            rb.AddForce(transform.forward * speed * dashForce, ForceMode.Impulse);
            StartCoroutine(Cooldown());
        }
    }

    public void EnableMove() => controller.Player.Enable();
    public void DisableMove() => controller.Player.Disable();

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public PlayerController controller;
    Rigidbody rb;
    Transform sphereCheckPos;
    public LayerMask groundMask;

    Vector3 moveVector, dashMove, recoilMove;
    public float speed, jumpForce, groundDistance, dashCooldown, dashForce, dashDuration, recoilDuration;
    bool isGrounded;
    bool canDash = true;

    void Start()
    {
        controller = new PlayerController();
        rb = GetComponent<Rigidbody>();

        foreach (Transform child in transform)
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
        Vector3 movement = Quaternion.AngleAxis(transform.eulerAngles.y, Vector3.up) * moveVector * speed / 2f;
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z) + dashMove + recoilMove;
        rb.angularVelocity = Vector3.zero;
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
            StartCoroutine(Dash(transform.forward * speed * dashForce));
        }
    }

    public void EnableMove() => controller.Player.Enable();
    public void DisableMove() => controller.Player.Disable();

    IEnumerator Dash(Vector3 force)
    {
        canDash = false;
        float timer = 0f;

        while (timer < dashDuration)
        {
            dashMove = Vector3.Lerp(force, Vector3.zero, timer / dashDuration);
            timer += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }

        dashMove = Vector3.zero;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    public IEnumerator Recoil(Vector3 force)
    {
        float timer = 0f;

        while (timer < recoilDuration)
        {
            recoilMove = Vector3.Lerp(force, Vector3.zero, timer / recoilDuration);
            timer += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }

        recoilMove = Vector3.zero;
    }
}

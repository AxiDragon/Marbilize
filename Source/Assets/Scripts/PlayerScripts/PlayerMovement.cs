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
    float coyoteTime = .5f;
    float coyoteTimeCounter;
    bool isGrounded;
    bool canDash = true;

    void Start()
    {
        coyoteTimeCounter = coyoteTime;
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
        isGrounded = Physics.CheckSphere(sphereCheckPos.position, groundDistance, groundMask);

        if (isGrounded)
            coyoteTimeCounter = coyoteTime;
        else
            coyoteTimeCounter -= Time.deltaTime;

        Vector3 movement = Quaternion.AngleAxis(transform.eulerAngles.y, Vector3.up) * moveVector * speed * ItemStats.speedMod / 2f;
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z) + dashMove + recoilMove;
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, 50f);
        rb.angularVelocity = Vector3.zero;
    }

    public void Jump(InputAction.CallbackContext callback)
    {

        if (coyoteTimeCounter > 0f && callback.action.WasPerformedThisFrame())
            rb.AddForce(Vector3.up * jumpForce * ItemStats.jumpMod, ForceMode.VelocityChange);
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
            StartCoroutine(Dash(transform.forward * speed * dashForce * ItemStats.dashMod));
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

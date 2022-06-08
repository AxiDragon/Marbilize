using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 groundAdjust;
    private bool groundedPlayer;
    public float playerSpeed = 2.0f;
    public float jumpHeight = 1.0f;
    public float gravityValue = -9.81f;
    private LayerMask ground;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Bounds playerBounds = GetComponent<Collider>().bounds;
        groundAdjust = new Vector3(0f, -playerBounds.size.y / 2f, 0f);
        ground = LayerMask.GetMask("Ground");
    }

    void Update()
    {

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")) / (groundedPlayer ? 1f : 3f);

        rb.MovePosition(transform.position + move * Time.deltaTime * playerSpeed);


        groundedPlayer = Physics.CheckSphere(transform.position + groundAdjust, 0.1f, ground);

        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.VelocityChange);
        }
    }
}

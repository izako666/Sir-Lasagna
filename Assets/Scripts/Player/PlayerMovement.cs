using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 20;
    public LayerMask groundMask;
    public Transform groundTransform;
    public Boolean isGrounded;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundTransform.position, 0.4f, groundMask);
        Vector3 movementVector = transform.right * Input.GetAxis("horizontal") + -transform.forward * Input.GetAxis("vertical");
        float truespeed = speed;

        if (Input.GetButton("shift")) {

            truespeed = speed * 1.5f;
        }
        rb.velocity = new Vector3(movementVector.x * truespeed * Time.deltaTime ,rb.velocity.y, movementVector.z * truespeed * Time.deltaTime);
        if (Input.GetButtonDown("jump") && isGrounded) {

            rb.AddForce(new Vector3(0, 100, 0), ForceMode.Impulse);
        }
        
    }
}

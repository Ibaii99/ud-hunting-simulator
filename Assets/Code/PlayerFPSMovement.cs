﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFPSMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 10f;
    public float runSpeed = 20f;
    public float gravity = -10f;
    public float jumpHeight = 2f;

    public Transform groundCheck;
    public float groundDistance = 0.001f;
    public LayerMask groundMask;

    Animator anim;
    int jumpHash = Animator.StringToHash("Jump");
    int moveHash = Animator.StringToHash("Move");
    int runHash = Animator.StringToHash("Run");
    int aimingHash = Animator.StringToHash("Aiming");
    int shootHash = Animator.StringToHash("Shoot");

    Vector3 velocity;
    bool isGrounded;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        if(x== 0 && z == 0) {
            anim.SetBool(moveHash, false);
            anim.SetBool(runHash, false);
        }
        else
        {
            anim.SetBool(moveHash, true);
            anim.SetBool(aimingHash, false);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                controller.Move(move * runSpeed * Time.deltaTime);
                anim.SetBool(runHash, true);
            }
            else
            {
                controller.Move(move * speed * Time.deltaTime);
                anim.SetBool(runHash, false);
            }
        }

        

        

        if (Input.GetButton("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            anim.SetTrigger(jumpHash);
            anim.SetBool(moveHash, false);
            anim.SetBool(runHash, false);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }
}

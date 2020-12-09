using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class SoldierMovement : MonoBehaviour
{
    public Rigidbody playerRigidBody;

    public float moveSpeed = 30;
    public float rotateSpeed = 100;
    public bool isGrounded = true;

    private void Awake()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (isGrounded && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftControl))
        {
            Rotate(-1);
        }
        else if (isGrounded && Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftControl))
        {
            Rotate(1);
        }
        else if(isGrounded && Input.GetKey(KeyCode.W))
        {
            Move3(1);
        }
        else if(isGrounded && Input.GetKey(KeyCode.S))
        {
            Move3(-1);
        }
        else if(isGrounded && Input.GetKey(KeyCode.A))
        {
            Move2(1);
        }
        else if(isGrounded && Input.GetKey(KeyCode.D))
        {
            Move2(-1);
        }
        //if (Input.GetKey(KeyCode.LeftAlt))
       // {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            transform.rotation = Quaternion.Euler(
                transform.rotation.eulerAngles.x - mouseY,
                transform.rotation.eulerAngles.y + mouseX,
                0);
       // }

    }

    private void Move3(float value)
    {
        playerRigidBody.MovePosition(transform.position + transform.forward * Time.deltaTime * moveSpeed * value);
    }
    private void Move2(float value)
    {
        playerRigidBody.MovePosition(transform.position + transform.forward * Time.deltaTime * moveSpeed * value);
    }
    private void Rotate(float value)
    {
        transform.Rotate(Vector2.up * Time.deltaTime * rotateSpeed * value);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}
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
    public Camera camera;

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
        if (HasMouseMoved())
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            transform.rotation = Quaternion.Euler(
                0,
                transform.rotation.eulerAngles.y + mouseX,
                0);
            camera.transform.rotation = Quaternion.Euler(
                    camera.transform.rotation.eulerAngles.x - mouseY,
                    transform.rotation.eulerAngles.y + mouseX,
                    0);
        }

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
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            print("True");
        }
        print("Ha salido de colisión pero no era Ground");
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
        print("False");
    }
    bool HasMouseMoved()
    { 
        return (Input.GetAxis("Mouse X") != 0) || (Input.GetAxis("Mouse Y") != 0);
    }
}
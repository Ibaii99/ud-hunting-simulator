using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            transform.rotation = Quaternion.Euler(
                transform.rotation.eulerAngles.x - mouseY,
                transform.rotation.eulerAngles.y + mouseX,
                0);
        }
    }

}

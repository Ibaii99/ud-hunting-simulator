﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{



    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
       Destroy(GetComponent<Collider>());
       Destroy(GetComponent<Renderer>());
       Destroy(gameObject, 0.1f);

        
    }
}

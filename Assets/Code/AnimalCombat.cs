using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalCombat : MonoBehaviour
{
    public float health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health -= 50;
        }
        if(health<= 0)
        {
            Destroy(GetComponent<Collider>());
            Destroy(GetComponent<Renderer>());
            Destroy(gameObject, 0.1f);
        }
           


        }
    }

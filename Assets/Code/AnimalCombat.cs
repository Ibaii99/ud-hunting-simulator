using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalCombat : MonoBehaviour
{
    public AudioSource hitmarker;
    public float health;
    // Start is called before the first frame update
    void Start()
    {
        hitmarker = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            hitmarker.Play();
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

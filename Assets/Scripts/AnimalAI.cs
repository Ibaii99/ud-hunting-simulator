using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalAI : MonoBehaviour
{
    //Multiplicador de la velocidad
    public float animalSpeed;

    public CharacterController animalCharacter;
    private Rigidbody animalRigidbody;
    private Animator animator;

    private bool isMoving;



    public int rotationRange;
    private int rotation;

    public float moveTime;
    private float routineTime;

    void Start()
    {
        rotation = Random.Range(-rotationRange, rotationRange);
        isMoving = false;
        animalRigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        animalCharacter = GetComponent<CharacterController>();
        routineTime = moveTime;
    }

    void Update()
    {
        animator.SetBool("Moving", isMoving);

    }

    private void FixedUpdate()
    {

        routineTime -= Time.deltaTime;
        if(routineTime >= 0)
        {
            isMoving = true;
            avance();
        }
        else
        {
            isMoving = false;
            if (routineTime <= -2)
            {

                rotate();
                if (routineTime <= -3)
                {
                    routineTime = moveTime;
                }
            }
        }
    }

    private void avance()
    {
        animalCharacter.Move(transform.forward * animalSpeed * Time.deltaTime);
    }

    public void rotate()
    {
        this.transform.Rotate(new Vector3(0, rotation, 0) * animalSpeed * Time.deltaTime);
    }   



}

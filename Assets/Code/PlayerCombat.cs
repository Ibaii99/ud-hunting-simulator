using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerCombat : MonoBehaviour
{
    public Transform rightGunBone;
    public CharacterController controller;
    public GameObject weapon;
    public Camera camara;

    Animator anim;
    Animator weaponAnim;
    int aimingHash = Animator.StringToHash("Aiming");
    int shootHash = Animator.StringToHash("Shoot");
    int deathHash = Animator.StringToHash("Death");
    int health = 100;
    bool apuntando = false;
    private float currentFOV;
    private float startingFOV;

    private void Start()
    {
        startingFOV = camara.fieldOfView;
        anim = GetComponent<Animator>();
        print(anim.name);
        GameObject newRightGun = (GameObject)Instantiate(weapon);
        newRightGun.transform.parent = rightGunBone;
        newRightGun.transform.localPosition = Vector3.zero;
        newRightGun.transform.localRotation = Quaternion.Euler(90, 0, 0);
        currentFOV = camara.fieldOfView;
    }

    void Update()
    {
        if (health <= 0)
        {
            anim.SetTrigger(deathHash);
            //Finalizar la partida
        }

        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");


        if (Input.GetKey(KeyCode.Mouse1) && (x == 0 && z == 0))
        {
            print("Apuntando");
            if (apuntando == false)
            {
                print("Empezando a apuntar");
                anim.SetBool(aimingHash, true);
                apuntando = true;
                currentFOV = startingFOV - 8;
            }
            
        }
        else
        {
            currentFOV = startingFOV;
            apuntando = false;
            anim.SetBool(aimingHash, false);
        }
        camara.fieldOfView = currentFOV;
        if (Input.GetKey(KeyCode.Mouse0))
        {
            print("Disparo");
            anim.SetTrigger(shootHash);
        }
        


    }
}

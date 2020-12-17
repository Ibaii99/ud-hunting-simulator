using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]
public class PlayerCombat : MonoBehaviour
{
    public Transform rightGunBone;
    public CharacterController controller;
    public GameObject weapon;
    public Camera camara;
    public GameObject bullet;
    public float bulletSpeed;

    GameObject newRightGun;
    Animator anim;
    Animator weaponAnim;
    int aimingHash = Animator.StringToHash("Aiming");
    int shootHash = Animator.StringToHash("Shoot");
    int deathHash = Animator.StringToHash("Death");
    int health = 100;
    int playerScore = 5000;
    int enemigos;
    bool apuntando = false;
    private float currentFOV;
    private float startingFOV;

    void OnDisable()
    {
        PlayerPrefs.SetInt("score", playerScore);
        print("Ha salido");
    }
    private void Start()
    {
        startingFOV = camara.fieldOfView;
        anim = GetComponent<Animator>();
        newRightGun = (GameObject)Instantiate(weapon);
        newRightGun.transform.parent = rightGunBone;
        newRightGun.transform.localPosition = Vector3.zero;
        newRightGun.transform.localRotation = Quaternion.Euler(90, 0, 0);
        currentFOV = camara.fieldOfView;
        enemigos = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    private void Awake()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        int enemigosActuales = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemigosActuales < enemigos)
        {
            playerScore += 1000;
            enemigos = enemigosActuales;
        }
        playerScore -= 1;
        if (health <= 0)
        {
            anim.SetTrigger(deathHash);
            //Finalizar la partida
        }

        if(Input.GetKeyDown(KeyCode.R) || GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
		    SceneManager.LoadScene("FinalScene");
		    //Escena de puntuación
	    }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
	

        if (Input.GetKey(KeyCode.Mouse1) && (x == 0 && z == 0))
        {
            if (apuntando == false)
            {
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
            anim.SetTrigger(shootHash);
            GameObject bulletInstance = Instantiate(bullet, newRightGun.transform.GetChild(0).gameObject.transform.position, Quaternion.identity) as GameObject;
            Rigidbody bulletInstanceRigibody = bulletInstance.GetComponent<Rigidbody>();
            bulletInstanceRigibody.AddForce(camara.transform.forward * bulletSpeed);
        }
        


    }
    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.tag == "Enemy"){
            Debug.Log("Le dio");   
            SceneManager.LoadScene("MainScene");     
        }
     }
}

using UnityEngine;
using System.Collections;

public class Duck_Controller : MonoBehaviour {
	public Transform Myself;
	public GameObject myobject;
	public float Speed = 3;
	public Vector3 targetPosition;
	private GameObject player;
	private int path;
	private int way1;
	private int way2;
	private int way3;
	private string objname = "";
	private bool animstatus = true;
	private bool death = false;
	private float distance = 0;
	
	private int attackpoint1;
	private int attackpoint;
	private bool runattack1 = true;
	private bool runattack2 = false;
	private Vector3 attackposition;
	private int point = 0;
	public Vector3 desiredPos;
	private Vector3 originalPos;


	public AnimationClip falltogroud;
	private bool falltogroundplayed = false;
	private string falltogroudname ; 
	private float terriandistance;
	private bool grounded = false;
	private bool fallen = false;
	private float height;
	
	private RaycastHit hit;
	private float heightAboveGround = 0;	
	private bool counter = true;

	void Start () 
	{	
		counter = true;
		point = 0;
		runattack1 = true;
		runattack2 = false;
		death = false;
		animstatus = true;
		objname = gameObject.name;
		way1 = Random.Range (1, 4);
		way2 = Random.Range (1, 4);
		way3 = Random.Range (1, 4);
		path=0;
		//!GUI_Controller.gameover=false;
		if(!GUI_Controller.gameover)
		{	
			Myself.GetComponent<Animation>().CrossFade("fly", 0.1f);
		}
		player=GameObject.FindGameObjectWithTag("target" + way3);
		targetPosition=player.transform.position;
	}
	
	void Update ()
	{		
		if(!GUI_Controller.gameover)
		{
			if(!death)
			{				
				if(objname == Hit_Body.name)				
				{
					death = true;
				}
			}
			if(death)
			{
				Ray downRay = new Ray(Myself.position, Vector3.down);
				if(Physics.Raycast(downRay, out hit))
				{
					heightAboveGround = hit.distance;
				}
				if(heightAboveGround < 0.3f)
				{
					myobject.GetComponent<Rigidbody>().isKinematic = true;
					grounded = true;					
				}
				if(!grounded)
				{
//					if(soundstatus)
//					{
//						audio.PlayOneShot(deathsound);
//						soundstatus = false;
//					}
					if(!falltogroundplayed)
					{
						Myself.GetComponent<Animation>().Play("falling");
						falltogroudname = falltogroud.name;
						if(GetComponent<Animation>().IsPlaying(falltogroudname)&& falltogroundplayed ==false)
						{
							myobject.AddComponent<Rigidbody>();
							myobject.GetComponent<Rigidbody>().mass = 5000;
							falltogroundplayed = true;
						}		
					}
					if(falltogroundplayed)
					{
						Myself.GetComponent<Animation>().Play("falling");
					}
				}
				if(grounded)
				{
					
					myobject.GetComponent<Rigidbody>().isKinematic = true;
					if(!fallen)
					{

						Myself.GetComponent<Animation>().Play("FallingToHitTheFloor");
						if(counter)
						{
							DragonCounter.killedanimals = DragonCounter.killedanimals + 1;
							counter = false;
						}
						StartCoroutine(waitforfall());
					}
				}
			}



			if(!death)		
			{			

					Myself.GetComponent<Animation>().CrossFade("fly", 0.1f);				
					if(this.transform.position==targetPosition&& path==0)
					{
						path=1;
						player=GameObject.FindGameObjectWithTag("target" + way1);
						targetPosition=player.transform.position;
					}				
					if(this.transform.position==targetPosition&& path==1)
					{
						path=2;
						player=GameObject.FindGameObjectWithTag("target" + way2);
						targetPosition=player.transform.position;
					}				
					if(this.transform.position==targetPosition&& path==2)
					{
						path=0;
						player=GameObject.FindGameObjectWithTag("target" + way3);
						targetPosition=player.transform.position;
					}
					targetPosition.y = transform.position.y;                        
					transform.LookAt(targetPosition);
					transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * Speed);				
			}
		}
	}
//	void OnCollisionEnter(Collision col)
//	{
//		if(col.transform.tag == "Bullet")
//		{
//			if(!death)
//			{
//				DragonCounter.killedanimals = DragonCounter.killedanimals + 1;
//			}
//		}
//	}
	
	IEnumerator waitfordeath()
	{
		yield return new WaitForSeconds (3.0f);
		if(!death)
		{
			GUI_Controller.missionfailed = true;
			Time.timeScale = 0;
		}
	}
	IEnumerator waitforfall()
	{

		yield return new WaitForSeconds (0.0f);
		fallen = true;
	}

	
}
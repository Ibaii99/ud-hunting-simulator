using UnityEngine;
using System.Collections;

public class Eagle_controllerNew : MonoBehaviour {

	public float moveSpeed = 3.0f;
	private float rotationSpeed = 3.0f;
	//private bool soundstatus = true;	
	public Transform starttarget;
	public Transform target2;
	public Transform target3;
	public Transform target4;		
	public Transform myTransform;
	public GameObject myobject;
	
	private float distance;
	private bool starttar = true;
	
	private float number = 0;	
	private string transformname = "";	
	private bool death = false;	
	private bool counter = true;


	public AnimationClip falltogroud;
	private bool falltogroundplayed = false;
	private string falltogroudname ; 
	private float terriandistance;
	private bool grounded = false;
	private bool fallen = false;
	private float height;
	private RaycastHit hit;
	private float heightAboveGround = 0;	
	private bool deadcount = true;
	void Start () 
	{
		//soundstatus = true;
		deadcount = true;
		death = false;
		transformname = myTransform.name;
	}
	
	void Update () 
	{	
		if(!GUI_Controller.gameover)
		{
			if(!death)
			{				
				if(transformname == Hit_Body.name)				
				{
					death = true;
					if(deadcount)
					{
						DragonCounter.killedanimals = DragonCounter.killedanimals + 1;
						deadcount = false;
					}
				}
			}
			if(death)
			{
				Ray downRay = new Ray(myTransform.position, Vector3.down);
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
					if(!falltogroundplayed)
					{
						myTransform.GetComponent<Animation>().Play("falling");
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
						myTransform.GetComponent<Animation>().Play("falling");
					}
				}
				if(grounded)
				{
					
					myobject.GetComponent<Rigidbody>().isKinematic = true;
					if(!fallen)
					{
						
						myTransform.GetComponent<Animation>().Play("hitTheGround");
						if(counter)
						{
//							DragonCounter.killedanimals = DragonCounter.killedanimals + 1;
							counter = false;
						}
						StartCoroutine(waitforfall());
					}
				}
			}

			if (!death) 
			{
				if (starttar) 
				{
					distance = (starttarget.position - myTransform.position).magnitude;
					if (distance > 3) {
						myTransform.GetComponent<Animation>().Play ("flyNormal");
						var lookDir = starttarget.position - myTransform.position;
						//lookDir.y = 0; // zero the height difference 
						myTransform.rotation = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation (lookDir), rotationSpeed * Time.deltaTime); 
						myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;	
					}
					if(distance<3)
					{
						starttar = false;
						number = 1.0f;	
					}
				}				
				if (number == 1.0f) 
				{
					distance = (target2.position - myTransform.position).magnitude;
					if (distance > 3) {
						myTransform.GetComponent<Animation>().Play ("flyNormal");
						var lookDir = target2.position - myTransform.position;
						//lookDir.y = 0; // zero the height difference 
						myTransform.rotation = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation (lookDir), rotationSpeed * Time.deltaTime); 
						myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;	
					}
					if(distance<3)
					{
						number = 2.0f;	
					}
				}
				if (number == 2.0f) 
				{
					distance = (target3.position - myTransform.position).magnitude;
					if (distance > 3) {
						myTransform.GetComponent<Animation>().Play ("flyNormal");
						var lookDir = target3.position - myTransform.position;
						//lookDir.y = 0; // zero the height difference 
						myTransform.rotation = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation (lookDir), rotationSpeed * Time.deltaTime); 
						myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
					}
					if(distance<3)
					{
						number = 3.0f;	
					}
				}
				if (number == 3.0f) 
				{			
					distance = (target4.position - myTransform.position).magnitude;
					if (distance > 3) {
						myTransform.GetComponent<Animation>().Play ("flyNormal");
						var lookDir = target4.position - myTransform.position;
						//lookDir.y = 0; // zero the height difference 
						myTransform.rotation = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation (lookDir), rotationSpeed * Time.deltaTime); 
						myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;	
					}
					if(distance<3)
					{
						number = 4.0f;	
					}
				}
				if (number == 4.0f) 
				{
					distance = (starttarget.position - myTransform.position).magnitude;
					if (distance > 3) 
					{
						myTransform.GetComponent<Animation>().Play ("flyNormal");
						var lookDir = starttarget.position - myTransform.position;
						//lookDir.y = 0; // zero the height difference 
						myTransform.rotation = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation (lookDir), rotationSpeed * Time.deltaTime); 
						myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;	
					}
					if(distance<3)
					{
						number = 1.0f;
					}
				}						
			}
		}
	}

	IEnumerator waitforfall()
	{
		
		yield return new WaitForSeconds (0.0f);
		fallen = true;
	}

}

using UnityEngine;
using System.Collections;

public class LionController : MonoBehaviour 
{
	public float moveSpeed = 3.0f;
	public float runSpeed = 3.0f;
	private float rotationSpeed = 3.0f;
	//private bool soundstatus = true;	
	public Transform starttarget;
	public Transform target2;
	public Transform target3;
	public Transform target4;		
	public Transform myTransform;
	public Transform player;
	
	private float distance;
	private bool starttar = true;
	
	private float number = 0;	
	private float attacknumber = 1;
	private string transformname = "";
	private bool bulletfire = false;
	
	private bool death = false;
	private bool animstate = true;	
	private bool attackmode = false;
	
	public Transform attackpoint1;
	public Transform attackpoint2;
	public AudioClip deathsound;

	public float attackdistance = 0;

	void Start () 
	{
		//soundstatus = true;
		attacknumber = 1;
		attackmode = false;
		death = false;
		animstate = true;
		bulletfire = false;
		transformname = myTransform.name;
	}
	
	void Update () 
	{		
		Vector3 pos = myTransform.position;
		float x = myTransform.localScale.y/12;
		myTransform.position = new Vector3(pos.x,Terrain.activeTerrain.SampleHeight(pos),pos.z);
		if(!GUI_Controller.gameover)
		{
			if(FPSInputController.firestatus)
			{
				if(!death)
				{
					if(!attackmode)
					{
						StartCoroutine(Waitlook());
						myTransform.GetComponent<Animation>().Play("idle");
					}
				}
			}
			if(!death)
			{				
				if(transformname == Hit_Body.name)				
				{
					if(animstate)
					{
						if (PlayerPrefs.GetInt("FX")==1) 
						{
							GetComponent<AudioSource>().PlayOneShot(deathsound);
						}
						transform.tag = "deadbody";
						myTransform.GetComponent<Animation>().Play("death");
						myTransform.GetComponent<Collider>().enabled = false;
						animstate = false;
						DragonCounter.killedanimals = DragonCounter.killedanimals + 1;
						death = true;
					}
				}
			}
			
			if(attackmode)
			{
				if(!death)
				{
					if (attacknumber == 1.0f) 
					{
						distance = (attackpoint1.position - myTransform.position).magnitude;
						if (distance >= 3) {
							myTransform.GetComponent<Animation>().Play ("run");
							var lookDir = attackpoint1.position - myTransform.position;
							lookDir.y = 0; // zero the height difference 
							myTransform.rotation = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation (lookDir), rotationSpeed * Time.deltaTime); 
							myTransform.position += myTransform.forward * runSpeed * Time.deltaTime;	
						}
						if(distance<3)
						{
							attacknumber = 2;
						}
					}
					if (attacknumber == 2.0f) 
					{
						distance = (attackpoint2.position - myTransform.position).magnitude;
						if (distance >= 3) {
							myTransform.GetComponent<Animation>().Play ("run");
							var lookDir = attackpoint2.position - myTransform.position;
							lookDir.y = 0; // zero the height difference 
							myTransform.rotation = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation (lookDir), rotationSpeed * Time.deltaTime); 
							myTransform.position += myTransform.forward * runSpeed * Time.deltaTime;	
						}
						if(distance<3)
						{
							attacknumber = 3;
						}
					}

					if (attacknumber == 3.0f) 
					{
						distance = (player.position - myTransform.position).magnitude;
						if (distance >= 3) {
							myTransform.GetComponent<Animation>().Play ("run");
							var lookDir = player.position - myTransform.position;
							lookDir.y = 0; // zero the height difference 
							myTransform.rotation = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation (lookDir), rotationSpeed * Time.deltaTime); 
							myTransform.position += myTransform.forward * runSpeed * Time.deltaTime;	
						}
						if(distance < attackdistance)
						{
							myTransform.GetComponent<Animation>().Play("clawsAttackCombo");
							myTransform.LookAt(player);
							if(PlayerHealth.playerhealth >= 0)
							{
								PlayerHealth.playerhealth -=  1.0f; 
							}
						}
					}
					
					
				}
			}
			if (!bulletfire) 
			{
				if (starttar) {
					distance = (starttarget.position - myTransform.position).magnitude;
					if (distance > 3) {
						myTransform.GetComponent<Animation>().Play ("walk");
						var lookDir = starttarget.position - myTransform.position;
						lookDir.y = 0; // zero the height difference 
						myTransform.rotation = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation (lookDir), rotationSpeed * Time.deltaTime); 
						myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;	
					}
					if(distance<3)
					{
						myTransform.GetComponent<Animation>().Play ("idle");
						starttar = false;
						StartCoroutine(Waitone(3.0F));
					}
				}				
				if (number == 1.0f) 
				{
					distance = (target2.position - myTransform.position).magnitude;
					if (distance > 3) {
						myTransform.GetComponent<Animation>().Play ("walk");
						var lookDir = target2.position - myTransform.position;
						lookDir.y = 0; // zero the height difference 
						myTransform.rotation = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation (lookDir), rotationSpeed * Time.deltaTime); 
						myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;	
					}
					if(distance<3)
					{
						myTransform.GetComponent<Animation>().Play ("idle");
						StartCoroutine(Waittwo(2.8F));
					}
				}
				if (number == 2.0f) 
				{
					distance = (target3.position - myTransform.position).magnitude;
					if (distance > 3) {
						myTransform.GetComponent<Animation>().Play ("walk");
						var lookDir = target3.position - myTransform.position;
						lookDir.y = 0; // zero the height difference 
						myTransform.rotation = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation (lookDir), rotationSpeed * Time.deltaTime); 
						myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
					}
					if(distance<3)
					{
						myTransform.GetComponent<Animation>().Play ("idle");
						StartCoroutine(Waitthree(3.0F));
					}
				}
				if (number == 3.0f) 
				{			
					distance = (target4.position - myTransform.position).magnitude;
					if (distance > 3) {
						myTransform.GetComponent<Animation>().Play ("walk");
						var lookDir = target4.position - myTransform.position;
						lookDir.y = 0; // zero the height difference 
						myTransform.rotation = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation (lookDir), rotationSpeed * Time.deltaTime); 
						myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;	
					}
					if(distance<3)
					{
						myTransform.GetComponent<Animation>().Play ("idle");
						StartCoroutine(Waitfour(2.8F));
					}
				}
				if (number == 4.0f) 
				{
					distance = (starttarget.position - myTransform.position).magnitude;
					if (distance > 3) 
					{
						myTransform.GetComponent<Animation>().Play ("walk");
						var lookDir = starttarget.position - myTransform.position;
						lookDir.y = 0; // zero the height difference 
						myTransform.rotation = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation (lookDir), rotationSpeed * Time.deltaTime); 
						myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;	
					}
					if(distance<3)
					{
						myTransform.GetComponent<Animation>().Play ("idle");
						StartCoroutine(Waitone(2.0F));
					}
				}						
			}
		}
	}		
	
	IEnumerator Waitlook(){
		bulletfire = true;
		yield return new WaitForSeconds(2.0f);
		attackmode = true;	
	}
	
	IEnumerator Waitone(float waitTime){		
		yield return new WaitForSeconds(waitTime);
		number = 1.0f;		
	}
	IEnumerator Waittwo(float waitTime){		
		yield return new WaitForSeconds(waitTime);
		number = 2.0f;		
	}
	IEnumerator Waitthree(float waitTime){		
		yield return new WaitForSeconds(waitTime);
		number = 3.0f;		
	}
	IEnumerator Waitfour(float waitTime){		
		yield return new WaitForSeconds(waitTime);
		number = 4.0f;		
	}	
}


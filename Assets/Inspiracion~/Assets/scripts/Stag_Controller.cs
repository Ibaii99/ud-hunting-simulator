using UnityEngine;
using System.Collections;

public class Stag_Controller : MonoBehaviour {
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
	private float runnumber = 1;
	private string transformname = "";
	private bool bulletfire = false;
	
	private bool death = false;
	private bool animstate = true;	
	private bool runmode = false;

	public Transform runpoint1;
	public Transform runpoint2;
	public Transform runpoint3;

	public AudioClip deathsound;

	public Hit_Body bodyhit;
	public Hit_Head headhit;
	
	public bool headshoot ;
	public bool bodyshoot ;
	public GameObject labelobject;


	void Start () 
	{
		headshoot = headhit.GetComponent<Hit_Head> ().headshoot;

		//soundstatus = true;
		runnumber = 1;
		runmode = false;
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

		headshoot = headhit.GetComponent<Hit_Head> ().headshoot;
		bodyshoot = bodyhit.GetComponent<Hit_Body> ().bodyshoot;

		if(!GUI_Controller.gameover)
		{
			if(FPSInputController.firestatus)
			{
				if(!death)
				{
					if(!runmode)
					{
						StartCoroutine(Waitlook());
						myTransform.GetComponent<Animation>().Play("idle2");
					}
				}
			}
			if(!death)
			{	


				if(headshoot)
				{
					if(transformname ==  headhit.GetComponent<Hit_Head> ().headname)
					{
						Debug.Log("head shoot");
						if(animstate)
						{
							GameObject headlabel = Instantiate(labelobject) as GameObject;
							headlabel.GetComponent<GUIText>().text = "Head Shoot\n$50";
							if (PlayerPrefs.GetInt("FX")==1) 
							{
								GetComponent<AudioSource>().PlayOneShot(deathsound);
							}
							transform.tag = "deadbody";
							myTransform.GetComponent<Animation>().Play("death");
//							myTransform.collider.enabled = false;
							animstate = false;
							
							DragonCounter.headshoots = DragonCounter.headshoots + 1;
//							DragonCounter.killedanimals = DragonCounter.killedanimals + 1;
							death = true;
						}
					}
				}
				else if(bodyshoot)
				{
					if(transformname ==  bodyhit.GetComponent<Hit_Body> ().bodyname)
					{
						Debug.Log("body shoot");			
						
						if(animstate)
						{
							GameObject bodylabel = Instantiate(labelobject) as GameObject;
							bodylabel.GetComponent<GUIText>().text = "Body Shoot\n$25";
							
							if (PlayerPrefs.GetInt("FX")==1) 
							{
								GetComponent<AudioSource>().PlayOneShot(deathsound);
							}
							transform.tag = "deadbody";
							myTransform.GetComponent<Animation>().Play("death");
//							myTransform.collider.enabled = false;
							animstate = false;
							DragonCounter.bodyshoots = DragonCounter.bodyshoots + 1;
							//							DragonCounter.killedanimals = DragonCounter.killedanimals + 1;
							death = true;
						}
					}
				}
//				if(transformname == Hit_Body.name)				
//				{
//					if(animstate)
//					{
//						if (PlayerPrefs.GetInt("FX")==1) 
//						{
//							audio.PlayOneShot(deathsound);
//						}
//						transform.tag = "deadbody";
//						myTransform.animation.Play("death");
//						myTransform.collider.enabled = false;
//						animstate = false;
//						DragonCounter.killedanimals = DragonCounter.killedanimals + 1;
//						death = true;
//					}
//				}
			}
			if(!death)
			{
				if(runmode)
				{
					if (runnumber == 1.0f) 
					{
						distance = (runpoint1.position - myTransform.position).magnitude;
						if (distance > 3) {
							myTransform.GetComponent<Animation>().Play ("run");
							var lookDir = runpoint1.position - myTransform.position;
							lookDir.y = 0; // zero the height difference 
							myTransform.rotation = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation (lookDir), rotationSpeed * Time.deltaTime); 
							myTransform.position += myTransform.forward * runSpeed * Time.deltaTime;	
						}
						if(distance<3)
						{
							runnumber = 2;
						}
					}
					if (runnumber == 2.0f) 
					{
						distance = (runpoint2.position - myTransform.position).magnitude;
						if (distance > 3) {
							myTransform.GetComponent<Animation>().Play ("run");
							var lookDir = runpoint2.position - myTransform.position;
							lookDir.y = 0; // zero the height difference 
							myTransform.rotation = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation (lookDir), rotationSpeed * Time.deltaTime); 
							myTransform.position += myTransform.forward * runSpeed * Time.deltaTime;	
						}
						if(distance<3)
						{
							runnumber = 3;
						}
					}
					if (runnumber == 3.0f) 
					{
						distance = (runpoint3.position - myTransform.position).magnitude;
						if (distance >= 3) {
							myTransform.GetComponent<Animation>().Play ("run");
							var lookDir = runpoint3.position - myTransform.position;
							lookDir.y = 0; // zero the height difference 
							myTransform.rotation = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation (lookDir), rotationSpeed * Time.deltaTime); 
							myTransform.position += myTransform.forward * runSpeed * Time.deltaTime;	
						}
						if(distance < 3)
						{
							myTransform.GetComponent<Animation>().Play("idle2");
						}
					}
				}

				if (!bulletfire) 
				{
					if (starttar) 
					{
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
							myTransform.GetComponent<Animation>().Play ("idle1");
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
							myTransform.GetComponent<Animation>().Play ("idle2");
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
							myTransform.GetComponent<Animation>().Play ("idle1");
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
							myTransform.GetComponent<Animation>().Play ("idle2");
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
							myTransform.GetComponent<Animation>().Play ("idle1");
							StartCoroutine(Waitone(2.0F));





						}
					}						
				}
			}
		}
	}		
	
	IEnumerator Waitlook(){
		bulletfire = true;
		yield return new WaitForSeconds(3.0f);
		runmode = true;	
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

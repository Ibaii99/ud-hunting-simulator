using UnityEngine;
using System.Collections;

public class Wolf_Controller_New : MonoBehaviour {

	public float moveSpeed = 3.0f;
	private float rotationSpeed = 3.0f;

	public Transform starttarget;
	public Transform target2;
	public Transform target3;
	public Transform target4;		
	public Transform myTransform;
	public Transform player;
	
	private float distance;
	private bool starttar = true;
	
	private float number = 0;	
	private string transformname = "";
	
	private bool death = false;
	private bool animstate = true;	
	
	public AudioClip deathsound;
	
	void Start () 
	{
		death = false;
		animstate = true;
		transformname = myTransform.name;
	}
	
	void Update () 
	{		
		Vector3 pos = myTransform.position;
		float x = myTransform.localScale.y/12;
		myTransform.position = new Vector3(pos.x,Terrain.activeTerrain.SampleHeight(pos),pos.z);
		if(!GUI_Controller.gameover)
		{
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
			if(!death)
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
						myTransform.GetComponent<Animation>().Play ("idleNormal");
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
						myTransform.GetComponent<Animation>().Play ("howl");
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
						myTransform.GetComponent<Animation>().Play ("idleNormal");
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
						myTransform.GetComponent<Animation>().Play ("howl");
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
						myTransform.GetComponent<Animation>().Play ("idleNormal");
						StartCoroutine(Waitone(2.0F));
					}
				}


			}
		}
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

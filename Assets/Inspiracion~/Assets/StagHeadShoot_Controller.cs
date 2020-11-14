using UnityEngine;
using System.Collections;

public class StagHeadShoot_Controller : MonoBehaviour {
	public float moveSpeed = 3.0f;
	private float rotationSpeed = 3.0f;
	public Transform target1;
	public Transform target2;
	public Transform target3;
	public Transform target4;		

	private Transform myTransform;	
	private float distance;	
	private float number = 1;	
	private string transformname = "";	
	private bool death = false;
	private bool animstate = true;	

	public AudioClip deathsound;		
	public Hit_Body bodyhit;
	public Hit_Head headhit;

	public bool headshoot ;
	public bool bodyshoot ;

	public GameObject labelobject;
	void Start () 
	{
		headshoot = headhit.GetComponent<Hit_Head> ().headshoot;

		number = 1;
		death = false;
		animstate = true;
		myTransform = this.transform;
		transformname = myTransform.name;
		Time.timeScale = 1;
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
							headlabel.GetComponent<GUIText>().text = "Head Shoot \n$50";
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
							bodylabel.GetComponent<GUIText>().text = "Body Shoot \n$25";
							
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
						StartCoroutine(Waittwo(3.8F));
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
						StartCoroutine(Waitthree(4.0F));
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
						StartCoroutine(Waitfour(3.8F));
					}
				}
				if (number == 4.0f) 
				{
					distance = (target1.position - myTransform.position).magnitude;
					if (distance > 3) 
					{
						myTransform.GetComponent<Animation>().Play ("walk");
						var lookDir = target1.position - myTransform.position;
						lookDir.y = 0; // zero the height difference 
						myTransform.rotation = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation (lookDir), rotationSpeed * Time.deltaTime); 
						myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;	
					}
					if(distance<3)
					{
						myTransform.GetComponent<Animation>().Play ("idle1");
						StartCoroutine(Waitone(3.0F));
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

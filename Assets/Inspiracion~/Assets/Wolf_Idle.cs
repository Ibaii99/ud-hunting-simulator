using UnityEngine;
using System.Collections;

public class Wolf_Idle : MonoBehaviour {
	public float waittime = 4.0f;

	public float runSpeed = 3.0f;
	private float rotationSpeed = 3.0f;
	public Transform myTransform;
	public Transform player;
	
	private float distance;
	private float attacknumber = 1;
	private string transformname = "";
	private bool bulletfire = false;
	
	private bool death = false;
	private bool animstate = true;	
	private bool attackmode = false;

	public AudioClip deathsound;
	
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
//			if(FPSInputController.firestatus)
//			{
//				if(!death)
//				{
//					if(!attackmode)
//					{
//						StartCoroutine(Waitlook());
//						myTransform.animation.Play("idleLookAround");
//					}
//				}
//			}
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
			
//			if(attackmode)
//			{
//				if(!death)
//				{
//					if (attacknumber == 1.0f) 
//					{
//						distance = (player.position - myTransform.position).magnitude;
//						if (distance > 4) {
//							myTransform.animation.Play ("run");
//							var lookDir = player.position - myTransform.position;
//							lookDir.y = 0; // zero the height difference 
//							myTransform.rotation = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation (lookDir), rotationSpeed * Time.deltaTime); 
//							myTransform.position += myTransform.forward * runSpeed * Time.deltaTime;	
//						}
//						if(distance < 4)
//						{
//							myTransform.animation.Play("standBite");
//							if(PlayerHealth.playerhealth >= 0)
//							{
//								PlayerHealth.playerhealth -=  1.0f; 
//							}
//						}
//					}			
//					
//				}
//			}

		}
	}		
	
	IEnumerator Waitlook(){
		bulletfire = true;
		yield return new WaitForSeconds(waittime);
		attackmode = true;	
	}	

}

using UnityEngine;
using System.Collections;
public class Rabbit_Idle : MonoBehaviour 
{	
	public Transform Myself;
	private GameObject player;
	private string objname = "";
	private bool animstatus = true;
	private bool death = false;	

	public AudioClip deathsound;

	void Start () 
	{
		death = false;
		animstatus = true;
		objname = gameObject.name;
	}
	
	void Update ()
	{		
		if(!GUI_Controller.gameover)
		{
			if(!death)
			{				
				if(objname == Hit_Body.name)				
				{
					if(animstatus)
					{
						if (PlayerPrefs.GetInt("FX")==1) 
						{
							GetComponent<AudioSource>().PlayOneShot(deathsound);
						}
						transform.tag = "deadbody";
						Myself.GetComponent<Animation>().Play("death");
						Myself.GetComponent<Collider>().enabled = false;
						animstatus = false;
						DragonCounter.killedanimals = DragonCounter.killedanimals + 1;
						death = true;
					}
				}
			}
			if(!death)
			{
				Myself.GetComponent<Animation>().CrossFade("idle1", 0.1f);					
			}
		}
	}	
}
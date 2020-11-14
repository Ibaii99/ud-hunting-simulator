using UnityEngine;
using System.Collections;

public class BoarController_Idle : MonoBehaviour {
	public Transform myTransform;
	public Transform player;
	private string transformname = "";	
	private bool death = false;
	private bool animstate = true;		
	public AudioClip deathsound;
	
	void Start () 
	{
		death = false;
		animstate = true;
		myTransform = this.transform;
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
				else
				{
					myTransform.GetComponent<Animation>().Play("idle1");
				}
			}

		}
	}	

}

using UnityEngine;
using System.Collections;

public class Rabbit_Controller : MonoBehaviour {
	
	public Transform Myself;
	public float Speed = 3;
	public float runspeed = 3;
	public AudioClip[] footstepSound;
	public Vector3 targetPosition;
	public int timethink = 0;
	private GameObject player;
	private int path;
	private int way1;
	private int way2;
	private int way3;
	private string objname = "";
	private bool animstatus = true;
	private bool death = false;
	
	public Transform myplayer;
	private float distance = 0;
	
	private int attackpoint1;
	private int attackpoint;
	private bool runattack1 = true;
	private bool runattack2 = false;
	private Vector3 attackposition;
	private int point = 0;
	public Vector3 desiredPos;
	private Vector3 originalPos;
	public AudioClip deathsound;
	void Start () 
	{	
		
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
			Myself.GetComponent<Animation>().CrossFade("run", 0.1f);
		}
		player=GameObject.FindGameObjectWithTag("target" + way3);
		targetPosition=player.transform.position;
	}
	
	void Update ()
	{		
		Vector3 pos = Myself.position;
		float x = Myself.localScale.y/12;
		Myself.position = new Vector3(pos.x,Terrain.activeTerrain.SampleHeight(pos),pos.z);
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
					Myself.GetComponent<Animation>().CrossFade("run", 0.1f);				
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
	
	IEnumerator waitfordeath()
	{
		yield return new WaitForSeconds (3.0f);
		if(!death)
		{
			GUI_Controller.missionfailed = true;
			Time.timeScale = 0;
		}
	}
	
}
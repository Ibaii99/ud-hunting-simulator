using UnityEngine;
using System.Collections;

public class BearEnemy : MonoBehaviour {
	
	public Transform Myself;
	public float Speed = 3;
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

	private bool playertarget = false;
	private int attackpoint1;
	private int attackpoint;
	private bool runattack1 = true;
	private bool runattack2 = false;
	private Vector3 attackposition;
	private int point = 0;
	public Vector3 desiredPos;
	private Vector3 originalPos;

	void Start () 
	{	

		point = 0;
		runattack1 = true;
		runattack2 = false;
		death = false;
		playertarget = false;
		animstatus = true;
		objname = gameObject.name;
		way1 = Random.Range (1, 4);
		way2 = Random.Range (1, 4);
		way3 = Random.Range (1, 4);
		path=0;
		//FPSInputController.startGame=false;

		if(!GUI_Controller.gameover)
		{	
			Myself.GetComponent<Animation>().CrossFade("walk", 0.1f);
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
					if(animstatus)
					{
						transform.tag = "deadbody";
						Myself.GetComponent<Animation>().Play("die");
						Myself.GetComponent<Collider>().enabled = false;
						animstatus = false;
						death = true;
					}
				}
			}
			if(!death)
			{
				if(FPSInputController.firestatus)
				{
					distance = (myplayer.transform.position - Myself .transform.position).magnitude;
					
					if(distance < 80)
					{
						if(!playertarget)
						{
							if(runattack1)
							{
								attackpoint = Random.Range(1, 4);
								point = 1;
								runattack1 = false;
							}
							if(runattack2)
							{
								attackpoint = Random.Range(5, 6);
								point  = 2;
								runattack2 = false;
							}

							attackposition = GameObject.FindGameObjectWithTag("Attack" + attackpoint).transform.position;
							if(point == 1)
							{
								if(this.transform.position == attackposition)
								{
									runattack2 = true;
								}
								else
								{
									Myself.GetComponent<Animation>().Play("Run");                     
									transform.LookAt(attackposition);
									transform.position = Vector3.MoveTowards(transform.position, attackposition, Time.deltaTime * 4.0f);
								}
							}
							if(point == 2)
							{
								if(this.transform.position == attackposition)
								{
									playertarget = true;
								}
								else
								{
									Myself.GetComponent<Animation>().Play("Run");                     
									transform.LookAt(attackposition);
									transform.position = Vector3.MoveTowards(transform.position, attackposition, Time.deltaTime * 4.0f);
								}
							}
						}
						if(playertarget)
						{
							if(distance <= 3)
							{
								Myself.GetComponent<Animation>().Play("2LegsBiteAttack");
								StartCoroutine(waitfordeath());
							}
							else if(distance > 3)
							{
								Myself.GetComponent<Animation>().Play("Run");
								targetPosition = myplayer.transform.position;
								targetPosition.y = transform.position.y;                        
								transform.LookAt(targetPosition);
								transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * 6.0f);
							}
						}

					}
					
					
					else
					{
						Myself.GetComponent<Animation>().CrossFade("walk", 0.1f);				
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
				
				
				if(!FPSInputController.firestatus)
				{
					Myself.GetComponent<Animation>().CrossFade("walk", 0.1f);				
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
	}

	IEnumerator waitfordeath()
	{
		yield return new WaitForSeconds (2.0f);
		if(!death)
		{
			GUI_Controller.gameover = true;
			Time.timeScale = 0;
		}
	}

}
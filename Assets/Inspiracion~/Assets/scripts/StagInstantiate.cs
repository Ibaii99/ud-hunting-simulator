using UnityEngine;
using System.Collections;

public class StagInstantiate : MonoBehaviour 
{
	public GameObject Stag1;
	public GameObject Stag2;
	public GameObject Stag3;
	public GameObject Stag4;
	public GameObject Stag5;
	public GameObject Stag6;
	public GameObject Stag7;
	public GameObject Stag8;
	public GameObject Stag9;
	public GameObject Stag10;

	public GameObject Rabbit0;
	public GameObject Rabbit1;
	public GameObject Rabbit2;
	public GameObject Rabbit3;
	public GameObject Rabbit4;
	public GameObject Rabbit5;
	public GameObject Rabbit6;
	public GameObject Rabbit7;
	public GameObject Rabbit8;
	public GameObject Rabbit9;
	public GameObject Rabbit10;

	public Transform campoint1;
	public Transform campoint2;
	public Transform Rabbitcampoint;
	public Transform Rabbitcampoint2;

	public Transform player;
	void Awake()
	{


	}
	void Start ()
	{
		Time.timeScale = 1;

		Debug.Log (PlayerPrefs.GetInt("Staglevel1"));
		if(PlayerPrefs.GetInt("Staglevel3") == 1)
		{
			player.position = campoint1.position;
			player.rotation = campoint1.rotation;
			Stag1.SetActive(true);
			Stag2.SetActive(true);
			
			Stag3.SetActive(false);
			Stag4.SetActive(false);
			
			Stag5.SetActive(false);
			Stag6.SetActive(false);
			Stag7.SetActive(false);
			Stag8.SetActive(false);
			Stag9.SetActive(false);
			Stag10.SetActive(false);
			
			Rabbit0.SetActive(false);
			Rabbit1.SetActive(false);
			Rabbit2.SetActive(false);
			Rabbit3.SetActive(false);
			Rabbit4.SetActive(false);
			Rabbit5.SetActive(false);
			Rabbit6.SetActive(false);
			Rabbit7.SetActive(false);
			Rabbit8.SetActive(false);
			Rabbit9.SetActive(false);
			Rabbit10.SetActive(false);
		}
		if(PlayerPrefs.GetInt("Staglevel4") == 1)
		{
			player.position = campoint1.position;
			player.rotation = campoint1.rotation;
			
			Stag1.SetActive(true);
			Stag2.SetActive(true);
			Stag3.SetActive(true);
			Stag4.SetActive(true);
			
			Stag5.SetActive(true);
			Stag6.SetActive(true);
			Stag7.SetActive(false);
			
			Stag8.SetActive(true);
			Stag9.SetActive(false);
			Stag10.SetActive(true);
			
			Rabbit0.SetActive(false);
			Rabbit1.SetActive(false);
			Rabbit2.SetActive(false);
			Rabbit3.SetActive(false);
			Rabbit4.SetActive(false);
			Rabbit5.SetActive(false);
			Rabbit6.SetActive(false);
			Rabbit7.SetActive(false);
			Rabbit8.SetActive(false);
			Rabbit9.SetActive(false);
			Rabbit10.SetActive(false);
		}
		if(PlayerPrefs.GetInt("Staglevel7") == 1)
		{
			player.position = campoint2.position;
			player.rotation = campoint2.rotation;
			
			Stag1.SetActive(true);
			Stag2.SetActive(true);
			
			Stag3.SetActive(true);
			Stag4.SetActive(true);
			
			Stag5.SetActive(true);
			Stag6.SetActive(true);
			Stag7.SetActive(true);
			
			Stag8.SetActive(true);
			Stag9.SetActive(false);
			Stag10.SetActive(false);
			
			Rabbit0.SetActive(false);
			Rabbit1.SetActive(false);
			Rabbit2.SetActive(false);
			Rabbit3.SetActive(false);
			Rabbit4.SetActive(false);
			Rabbit5.SetActive(false);
			Rabbit6.SetActive(false);
			Rabbit7.SetActive(false);
			Rabbit8.SetActive(false);
			Rabbit9.SetActive(false);
			Rabbit10.SetActive(false);
		}
		
		if(PlayerPrefs.GetInt("RabbitLevel1") == 1)
		{
			player.position = Rabbitcampoint.position;
			player.rotation = Rabbitcampoint.rotation;
			
			Stag1.SetActive(false);
			Stag2.SetActive(false);			
			Stag3.SetActive(false);
			Stag4.SetActive(false);
			Stag5.SetActive(false);
			Stag6.SetActive(false);
			Stag7.SetActive(false);
			Stag8.SetActive(false);
			Stag9.SetActive(false);
			Stag10.SetActive(false);
			
			
			Rabbit0.SetActive(true);
			Rabbit1.SetActive(true);
			Rabbit2.SetActive(false);
			Rabbit3.SetActive(false);
			Rabbit4.SetActive(false);
			Rabbit5.SetActive(false);
			Rabbit6.SetActive(false);
			Rabbit7.SetActive(false);
			Rabbit8.SetActive(false);
			Rabbit9.SetActive(false);
			Rabbit10.SetActive(false);
		}
		
		if(PlayerPrefs.GetInt("RabbitLevel2") == 1)
		{
			player.position = Rabbitcampoint2.position;
			player.rotation = Rabbitcampoint2.rotation;
			
			Stag1.SetActive(false);
			Stag2.SetActive(false);			
			Stag3.SetActive(false);
			Stag4.SetActive(false);
			Stag5.SetActive(false);
			Stag6.SetActive(false);
			Stag7.SetActive(false);
			Stag8.SetActive(false);
			Stag9.SetActive(false);
			Stag10.SetActive(false);
			
			
			Rabbit0.SetActive(true);
			Rabbit1.SetActive(false);
			Rabbit2.SetActive(false);
			Rabbit3.SetActive(false);
			Rabbit4.SetActive(true);
			Rabbit5.SetActive(true);
			Rabbit6.SetActive(true);
			Rabbit7.SetActive(true);
			Rabbit8.SetActive(false);
			Rabbit9.SetActive(false);
			Rabbit10.SetActive(false);
		}
		if(PlayerPrefs.GetInt("RabbitLevel4") == 1)
		{
			player.position = Rabbitcampoint.position;
			player.rotation = Rabbitcampoint.rotation;
			
			Stag1.SetActive(false);
			Stag2.SetActive(false);			
			Stag3.SetActive(false);
			Stag4.SetActive(false);
			Stag5.SetActive(false);
			Stag6.SetActive(false);
			Stag7.SetActive(false);
			Stag8.SetActive(false);
			Stag9.SetActive(false);
			Stag10.SetActive(false);
			
			
			Rabbit0.SetActive(true);
			Rabbit1.SetActive(true);
			Rabbit2.SetActive(true);
			Rabbit3.SetActive(true);
			Rabbit4.SetActive(true);
			Rabbit5.SetActive(false);
			Rabbit6.SetActive(false);
			Rabbit7.SetActive(false);
			Rabbit8.SetActive(false);
			Rabbit9.SetActive(false);
			Rabbit10.SetActive(false);
		}
		if(PlayerPrefs.GetInt("RabbitLevel6") == 1)
		{
			player.position = Rabbitcampoint2.position;
			player.rotation = Rabbitcampoint2.rotation;
			
			Stag1.SetActive(false);
			Stag2.SetActive(false);			
			Stag3.SetActive(false);
			Stag4.SetActive(false);
			Stag5.SetActive(false);
			Stag6.SetActive(false);
			Stag7.SetActive(false);
			Stag8.SetActive(false);
			Stag9.SetActive(false);
			Stag10.SetActive(false);
			
			
			Rabbit0.SetActive(false);
			Rabbit1.SetActive(false);
			Rabbit2.SetActive(true);
			Rabbit3.SetActive(true);
			Rabbit4.SetActive(true);
			Rabbit5.SetActive(true);
			Rabbit6.SetActive(true);
			Rabbit7.SetActive(true);
			Rabbit8.SetActive(true);
			Rabbit9.SetActive(true);
			Rabbit10.SetActive(true);
		}
		if(PlayerPrefs.GetInt("RabbitLevel7") == 1)
		{
			player.position = Rabbitcampoint2.position;
			player.rotation = Rabbitcampoint2.rotation;
			
			Stag1.SetActive(false);
			Stag2.SetActive(false);			
			Stag3.SetActive(false);
			Stag4.SetActive(false);
			Stag5.SetActive(false);
			Stag6.SetActive(false);
			Stag7.SetActive(false);
			Stag8.SetActive(false);
			Stag9.SetActive(false);
			Stag10.SetActive(false);
			
			
			Rabbit0.SetActive(true);
			Rabbit1.SetActive(true);
			Rabbit2.SetActive(true);
			Rabbit3.SetActive(true);
			Rabbit4.SetActive(true);
			Rabbit5.SetActive(true);
			Rabbit6.SetActive(true);
			Rabbit7.SetActive(true);
			Rabbit8.SetActive(true);
			Rabbit9.SetActive(true);
			Rabbit10.SetActive(true);
		}
	
	}
}

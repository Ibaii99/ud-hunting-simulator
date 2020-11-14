using UnityEngine;
using System.Collections;
public class WolfInstantiate : MonoBehaviour {

	public Material skyboxday;
	public Material skyboxnight;

	public GameObject wolf1;
	public GameObject wolf2;
	public GameObject wolf3;

	public GameObject boar1;
	public GameObject boar2;
	public GameObject boar3;
	public GameObject boar4;
	public GameObject boar5;
	public GameObject boar6;
	public GameObject boar7;
	public GameObject boar8;


	public GameObject eagle1;
	public GameObject eagle2;
	public GameObject eagle3;
	public GameObject eagle4;
	public GameObject eagle5;
	public GameObject eagle6;
	public GameObject eagle7;
	public GameObject eagle8;
	public GameObject eagle9;
	public GameObject eagle10;
	public GameObject eagle11;
	public GameObject eagle12;


	public Transform wolfcampoint;
	public Transform BoarCamPoint1;
	public Transform BoarCamPoint2;
	public Transform eagle1campoint;
	public Transform eagle1campoint2;
	public Transform player;
	void Start ()
	{
		//Wolf Levels
		if(PlayerPrefs.GetInt("Wolflevel1") == 1)
		{
			player.position = wolfcampoint.position;
			player.rotation = wolfcampoint.rotation;

			wolf1.SetActive(true);
			wolf2.SetActive(true);
			wolf3.SetActive(false);

			boar1.SetActive(false);
			boar2.SetActive(false);
			boar3.SetActive(false);
			boar4.SetActive(false);
			boar5.SetActive(false);
			boar6.SetActive(false);
			boar7.SetActive(false);
			boar8.SetActive(false);

			eagle1.SetActive(false);
			eagle2.SetActive(false);
			eagle3.SetActive(false);
			eagle4.SetActive(false);
			eagle5.SetActive(false);
			eagle6.SetActive(false);
			eagle7.SetActive(false);
			eagle8.SetActive(false);
			eagle9.SetActive(false);
			eagle10.SetActive(false);
			eagle11.SetActive(false);
			eagle12.SetActive(false);
		}
		else if(PlayerPrefs.GetInt("Wolflevel2") == 1)
		{
			player.position = wolfcampoint.position;
			player.rotation = wolfcampoint.rotation;

			wolf1.SetActive(true);
			wolf2.SetActive(true);
			wolf3.SetActive(true);

			boar1.SetActive(false);
			boar2.SetActive(false);
			boar3.SetActive(false);
			boar4.SetActive(false);
			boar5.SetActive(false);
			boar6.SetActive(false);
			boar7.SetActive(false);
			boar8.SetActive(false);

			eagle1.SetActive(false);
			eagle2.SetActive(false);
			eagle3.SetActive(false);
			eagle4.SetActive(false);
			eagle5.SetActive(false);
			eagle6.SetActive(false);
			eagle7.SetActive(false);
			eagle8.SetActive(false);
			eagle9.SetActive(false);
			eagle10.SetActive(false);
			eagle11.SetActive(false);
			eagle12.SetActive(false);
		}

		//Boar Level
		if(PlayerPrefs.GetInt("Boarlevel1") == 1)
		{
			player.position = BoarCamPoint1.position;
			player.rotation = BoarCamPoint1.rotation;
			
			wolf1.SetActive(false);
			wolf2.SetActive(false);
			wolf3.SetActive(false);
			
			boar1.SetActive(true);
			boar2.SetActive(true);
			boar3.SetActive(false);
			boar4.SetActive(false);
			boar5.SetActive(false);
			boar6.SetActive(false);
			boar7.SetActive(false);
			boar8.SetActive(false);

			eagle1.SetActive(false);
			eagle2.SetActive(false);
			eagle3.SetActive(false);
			eagle4.SetActive(false);
			eagle5.SetActive(false);
			eagle6.SetActive(false);
			eagle7.SetActive(false);
			eagle8.SetActive(false);
			eagle9.SetActive(false);
			eagle10.SetActive(false);
			eagle11.SetActive(false);
			eagle12.SetActive(false);
		}
		else if(PlayerPrefs.GetInt("Boarlevel2") == 1)
		{
			player.position = BoarCamPoint1.position;
			player.rotation = BoarCamPoint1.rotation;
			
			wolf1.SetActive(false);
			wolf2.SetActive(false);
			wolf3.SetActive(false);
			
			boar1.SetActive(true);
			boar2.SetActive(true);
			boar3.SetActive(true);
			boar4.SetActive(false);
			boar5.SetActive(false);
			boar6.SetActive(false);
			boar7.SetActive(false);
			boar8.SetActive(false);

			eagle1.SetActive(false);
			eagle2.SetActive(false);
			eagle3.SetActive(false);
			eagle4.SetActive(false);
			eagle5.SetActive(false);
			eagle6.SetActive(false);
			eagle7.SetActive(false);
			eagle8.SetActive(false);
			eagle9.SetActive(false);
			eagle10.SetActive(false);
			eagle11.SetActive(false);
			eagle12.SetActive(false);
		}
		else if(PlayerPrefs.GetInt("Boarlevel4") == 1)
		{
			player.position = BoarCamPoint1.position;
			player.rotation = BoarCamPoint1.rotation;
			
			wolf1.SetActive(false);
			wolf2.SetActive(false);
			wolf3.SetActive(false);
			
			boar1.SetActive(true);
			boar2.SetActive(true);
			boar3.SetActive(true);
			boar4.SetActive(true);
			boar5.SetActive(true);
			boar6.SetActive(false);
			boar7.SetActive(false);
			boar8.SetActive(false);

			eagle1.SetActive(false);
			eagle2.SetActive(false);
			eagle3.SetActive(false);
			eagle4.SetActive(false);
			eagle5.SetActive(false);
			eagle6.SetActive(false);
			eagle7.SetActive(false);
			eagle8.SetActive(false);
			eagle9.SetActive(false);
			eagle10.SetActive(false);
			eagle11.SetActive(false);
			eagle12.SetActive(false);
		}
		else if(PlayerPrefs.GetInt("Boarlevel8") == 1)
		{
			player.position = BoarCamPoint1.position;
			player.rotation = BoarCamPoint1.rotation;
			
			wolf1.SetActive(false);
			wolf2.SetActive(false);
			wolf3.SetActive(false);
			
			boar1.SetActive(true);
			boar2.SetActive(true);
			boar3.SetActive(true);
			boar4.SetActive(true);
			boar5.SetActive(true);
			boar6.SetActive(true);
			boar7.SetActive(true);
			boar8.SetActive(true);

			eagle1.SetActive(false);
			eagle2.SetActive(false);
			eagle3.SetActive(false);
			eagle4.SetActive(false);
			eagle5.SetActive(false);
			eagle6.SetActive(false);
			eagle7.SetActive(false);
			eagle8.SetActive(false);
			eagle9.SetActive(false);
			eagle10.SetActive(false);
			eagle11.SetActive(false);
			eagle12.SetActive(false);
		}

		//Eagle Loading
		if(PlayerPrefs.GetInt("Eaglelevel1") == 1)
		{
			player.position = eagle1campoint.position;
			player.rotation = eagle1campoint.rotation;
			
			wolf1.SetActive(false);
			wolf2.SetActive(false);
			wolf3.SetActive(false);
			
			boar1.SetActive(false);
			boar2.SetActive(false);
			boar3.SetActive(false);
			boar4.SetActive(false);
			boar5.SetActive(false);
			boar6.SetActive(false);
			boar7.SetActive(false);
			boar8.SetActive(false);
			
			eagle1.SetActive(true);
			eagle2.SetActive(true);
			eagle3.SetActive(false);
			eagle4.SetActive(false);
			eagle5.SetActive(false);
			eagle6.SetActive(false);
			eagle7.SetActive(false);
			eagle8.SetActive(false);
			eagle9.SetActive(false);
			eagle10.SetActive(false);
			eagle11.SetActive(true);
			eagle12.SetActive(true);
		}
		else if(PlayerPrefs.GetInt("Eaglelevel2") == 1)
		{
			player.position = eagle1campoint.position;
			player.rotation = eagle1campoint.rotation;
			
			wolf1.SetActive(false);
			wolf2.SetActive(false);
			wolf3.SetActive(false);
			
			boar1.SetActive(false);
			boar2.SetActive(false);
			boar3.SetActive(false);
			boar4.SetActive(false);
			boar5.SetActive(false);
			boar6.SetActive(false);
			boar7.SetActive(false);
			boar8.SetActive(false);
			
			eagle1.SetActive(true);
			eagle2.SetActive(true);
			eagle3.SetActive(true);
			eagle4.SetActive(true);
			eagle5.SetActive(false);
			eagle6.SetActive(false);
			eagle7.SetActive(false);
			eagle8.SetActive(false);
			eagle9.SetActive(false);
			eagle10.SetActive(false);
			eagle11.SetActive(false);
			eagle12.SetActive(false);
		}
		else if(PlayerPrefs.GetInt("Eaglelevel3") == 1)
		{
			player.position = eagle1campoint2.position;
			player.rotation = eagle1campoint2.rotation;
			
			wolf1.SetActive(false);
			wolf2.SetActive(false);
			wolf3.SetActive(false);
			
			boar1.SetActive(false);
			boar2.SetActive(false);
			boar3.SetActive(false);
			boar4.SetActive(false);
			boar5.SetActive(false);
			boar6.SetActive(false);
			boar7.SetActive(false);
			boar8.SetActive(false);
			
			eagle1.SetActive(false);
			eagle2.SetActive(false);
			eagle3.SetActive(false);
			eagle4.SetActive(false);
			eagle5.SetActive(false);
			eagle6.SetActive(true);
			eagle7.SetActive(true);
			eagle8.SetActive(true);
			eagle9.SetActive(true);
			eagle10.SetActive(true);
			eagle11.SetActive(true);
			eagle12.SetActive(false);
		}
		else if(PlayerPrefs.GetInt("Eaglelevel4") == 1)
		{
			player.position = eagle1campoint2.position;
			player.rotation = eagle1campoint2.rotation;
			
			wolf1.SetActive(false);
			wolf2.SetActive(false);
			wolf3.SetActive(false);
			
			boar1.SetActive(false);
			boar2.SetActive(false);
			boar3.SetActive(false);
			boar4.SetActive(false);
			boar5.SetActive(false);
			boar6.SetActive(false);
			boar7.SetActive(false);
			boar8.SetActive(false);
			
			eagle1.SetActive(true);
			eagle2.SetActive(true);
			eagle3.SetActive(true);
			eagle4.SetActive(false);
			eagle5.SetActive(false);
			eagle6.SetActive(false);
			eagle7.SetActive(false);
			eagle8.SetActive(true);
			eagle9.SetActive(true);
			eagle10.SetActive(true);
			eagle11.SetActive(true);
			eagle12.SetActive(true);
		}
		else if(PlayerPrefs.GetInt("Eaglelevel7") == 1)
		{
			player.position = eagle1campoint2.position;
			player.rotation = eagle1campoint2.rotation;
			
			wolf1.SetActive(false);
			wolf2.SetActive(false);
			wolf3.SetActive(false);
			
			boar1.SetActive(false);
			boar2.SetActive(false);
			boar3.SetActive(false);
			boar4.SetActive(false);
			boar5.SetActive(false);
			boar6.SetActive(false);
			boar7.SetActive(false);
			boar8.SetActive(false);
			
			eagle1.SetActive(true);
			eagle2.SetActive(true);
			eagle3.SetActive(true);
			eagle4.SetActive(true);
			eagle5.SetActive(true);
			eagle6.SetActive(true);
			eagle7.SetActive(true);
			eagle8.SetActive(true);
			eagle9.SetActive(true);
			eagle10.SetActive(true);
			eagle11.SetActive(true);
			eagle12.SetActive(true);
		}
	}
}

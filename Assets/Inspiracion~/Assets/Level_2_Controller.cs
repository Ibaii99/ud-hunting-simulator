using UnityEngine;
using System.Collections;

public class Level_2_Controller : MonoBehaviour {

	private float originalWidth = 1024.0f;
	private float originalHeight = 768.0f;
	private Vector3 scale;

	public Material skyboxnight;
	public GameObject mainlight;
	public GUIStyle nightstyle;
	public bool nightmode = false;

	public NightVision nightvision;
	public NightVision nightvision1;

	public GameObject Rabbit1;
	public GameObject Rabbit2;
	public GameObject Rabbit3;
	public GameObject Rabbit4;
	public GameObject Rabbit5;
	public GameObject Rabbit6;
	public GameObject Rabbit7;
	public GameObject Rabbit8;

	public GameObject Eagle1;
	public GameObject Eagle2;
	public GameObject Eagle3;
	public GameObject Eagle4;
	public GameObject Eagle5;
	public GameObject Eagle6;
	public GameObject Eagle7;
	public GameObject Eagle8;
	public GameObject Eagle9;
	public GameObject Eagle10;

	public GUIStyle textstyle;

	void Start () 
	{
		if(PlayerPrefs.GetInt("RabbitLevel3") == 1)
		{
			RenderSettings.skybox = skyboxnight;
			RenderSettings.ambientLight = new Color(0.074f, 0.073f, 0.073f,1.00f);
			mainlight.SetActive(false);

			Rabbit1.SetActive(true);
			Rabbit2.SetActive(true);
			Rabbit3.SetActive(true);
			Rabbit4.SetActive(false);
			Rabbit5.SetActive(false);
			Rabbit6.SetActive(false);
			Rabbit7.SetActive(false);
			Rabbit8.SetActive(false);

			Eagle1.SetActive(false);
			Eagle2.SetActive(false);
			Eagle3.SetActive(false);
			Eagle4.SetActive(false);
			Eagle5.SetActive(false);
			Eagle6.SetActive(false);
			Eagle7.SetActive(false);
			Eagle8.SetActive(false);
			Eagle9.SetActive(false);
			Eagle10.SetActive(false);

		}
		else if(PlayerPrefs.GetInt("RabbitLevel5") == 1)
		{
			RenderSettings.skybox = skyboxnight;
			RenderSettings.ambientLight = new Color(0.074f, 0.073f, 0.073f,1.00f);
			mainlight.SetActive(false);

			Rabbit1.SetActive(true);
			Rabbit2.SetActive(true);
			Rabbit3.SetActive(true);
			Rabbit4.SetActive(false);
			Rabbit5.SetActive(false);
			Rabbit6.SetActive(true);
			Rabbit7.SetActive(false);
			Rabbit8.SetActive(true);

			Eagle1.SetActive(false);
			Eagle2.SetActive(false);
			Eagle3.SetActive(false);
			Eagle4.SetActive(false);
			Eagle5.SetActive(false);
			Eagle6.SetActive(false);
			Eagle7.SetActive(false);
			Eagle8.SetActive(false);
			Eagle9.SetActive(false);
			Eagle10.SetActive(false);
		}
		else if(PlayerPrefs.GetInt("RabbitLevel8") == 1)
		{
			RenderSettings.skybox = skyboxnight;
			RenderSettings.ambientLight = new Color(0.074f, 0.073f, 0.073f,1.00f);
			mainlight.SetActive(false);

			Rabbit1.SetActive(true);
			Rabbit2.SetActive(true);
			Rabbit3.SetActive(true);
			Rabbit4.SetActive(true);
			Rabbit5.SetActive(true);
			Rabbit6.SetActive(true);
			Rabbit7.SetActive(true);
			Rabbit8.SetActive(true);

			Eagle1.SetActive(false);
			Eagle2.SetActive(false);
			Eagle3.SetActive(false);
			Eagle4.SetActive(false);
			Eagle5.SetActive(false);
			Eagle6.SetActive(false);
			Eagle7.SetActive(false);
			Eagle8.SetActive(false);
			Eagle9.SetActive(false);
			Eagle10.SetActive(false);
		}

		//Eagle Level
		if(PlayerPrefs.GetInt("Eaglelevel5") == 1)
		{
			RenderSettings.skybox = skyboxnight;
			RenderSettings.ambientLight = new Color(0.074f, 0.073f, 0.073f,1.00f);
			mainlight.SetActive(false);
			
			Rabbit1.SetActive(false);
			Rabbit2.SetActive(false);
			Rabbit3.SetActive(false);
			Rabbit4.SetActive(false);
			Rabbit5.SetActive(false);
			Rabbit6.SetActive(false);
			Rabbit7.SetActive(false);
			Rabbit8.SetActive(false);
			
			Eagle1.SetActive(true);
			Eagle2.SetActive(true);
			Eagle3.SetActive(false);
			Eagle4.SetActive(false);
			Eagle5.SetActive(true);
			Eagle6.SetActive(false);
			Eagle7.SetActive(true);
			Eagle8.SetActive(false);
			Eagle9.SetActive(true);
			Eagle10.SetActive(false);
		}
		else if(PlayerPrefs.GetInt("Eaglelevel6") == 1)
		{
			RenderSettings.skybox = skyboxnight;
			RenderSettings.ambientLight = new Color(0.074f, 0.073f, 0.073f,1.00f);
			mainlight.SetActive(false);
			
			Rabbit1.SetActive(false);
			Rabbit2.SetActive(false);
			Rabbit3.SetActive(false);
			Rabbit4.SetActive(false);
			Rabbit5.SetActive(false);
			Rabbit6.SetActive(false);
			Rabbit7.SetActive(false);
			Rabbit8.SetActive(false);
			
			Eagle1.SetActive(false);
			Eagle2.SetActive(true);
			Eagle3.SetActive(true);
			Eagle4.SetActive(false);
			Eagle5.SetActive(true);
			Eagle6.SetActive(true);
			Eagle7.SetActive(true);
			Eagle8.SetActive(false);
			Eagle9.SetActive(true);
			Eagle10.SetActive(true);
		}
		else if(PlayerPrefs.GetInt("Eaglelevel8") == 1)
		{
			RenderSettings.skybox = skyboxnight;
			RenderSettings.ambientLight = new Color(0.074f, 0.073f, 0.073f,1.00f);
			mainlight.SetActive(false);
			
			Rabbit1.SetActive(false);
			Rabbit2.SetActive(false);
			Rabbit3.SetActive(false);
			Rabbit4.SetActive(false);
			Rabbit5.SetActive(false);
			Rabbit6.SetActive(false);
			Rabbit7.SetActive(false);
			Rabbit8.SetActive(false);
			
			Eagle1.SetActive(true);
			Eagle2.SetActive(true);
			Eagle3.SetActive(true);
			Eagle4.SetActive(true);
			Eagle5.SetActive(true);
			Eagle6.SetActive(true);
			Eagle7.SetActive(true);
			Eagle8.SetActive(true);
			Eagle9.SetActive(true);
			Eagle10.SetActive(true);
		}
	
	}

	void OnGUI()
	{
		scale.x = Screen.width/originalWidth; // calculate hor scale
		scale.y = Screen.height/originalHeight; // calculate vert scale
		scale.z = 1.0f;
		var svMat= GUI.matrix; 
		GUI.matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity,scale);
		if(!GUI_Controller.gameover)
		{
			if(PlayerPrefs.GetInt("RabbitLevel3") == 1)
			{
				if(!nightmode)
				{
					GUI.Label(new Rect(originalWidth - 160 , 300 , 150 , 100), "equip nightvision goggles",textstyle);
				}

				if(GUI.Button(new Rect(originalWidth - 150, 240, 112, 112), "",nightstyle))
				{
					if(nightmode == false)
					{
						nightvision.enabled = true;
						nightvision1.enabled = true;
						nightmode = true;
					}
					else if(nightmode == true)
					{
						nightvision.enabled = false;
						nightvision1.enabled = false;
						nightmode = false;
					}
				}
			}
			else if(PlayerPrefs.GetInt("RabbitLevel5") == 1)
			{
				if(!nightmode)
				{
					GUI.Label(new Rect(originalWidth - 160 , 300 , 150 , 100), "equip nightvision goggles",textstyle);
				}

				if(GUI.Button(new Rect(originalWidth - 150, 240, 112, 112), "",nightstyle))
				{
					if(nightmode == false)
					{
						nightvision.enabled = true;
						nightvision1.enabled = true;
						nightmode = true;
					}
					else if(nightmode == true)
					{
						nightvision.enabled = false;
						nightvision1.enabled = false;
						nightmode = false;
					}
				}
			}
			else if(PlayerPrefs.GetInt("RabbitLevel8") == 1)
			{
				if(!nightmode)
				{
					GUI.Label(new Rect(originalWidth - 160 , 300 , 150 , 100), "equip nightvision goggles",textstyle);
				}

				if(GUI.Button(new Rect(originalWidth - 150, 240, 112, 112), "",nightstyle))
				{
					if(nightmode == false)
					{
						nightvision.enabled = true;
						nightvision1.enabled = true;
						nightmode = true;
					}
					else if(nightmode == true)
					{
						nightvision.enabled = false;
						nightvision1.enabled = false;
						nightmode = false;
					}
				}
			}



			
			if(PlayerPrefs.GetInt("Eaglelevel5") == 1)
			{
				if(!nightmode)
				{
					GUI.Label(new Rect(originalWidth - 160 , 300 , 150 , 100), "equip nightvision goggles",textstyle);
				}

				if(GUI.Button(new Rect(originalWidth - 150, 240, 112, 112), "",nightstyle))
				{
					if(nightmode == false)
					{
						nightvision.enabled = true;
						nightvision1.enabled = true;
						nightmode = true;
					}
					else if(nightmode == true)
					{
						nightvision.enabled = false;
						nightvision1.enabled = false;
						nightmode = false;
					}
				}
			}
			else if(PlayerPrefs.GetInt("Eaglelevel6") == 1)
			{
				if(!nightmode)
				{
					GUI.Label(new Rect(originalWidth - 160 , 300 , 150 , 100), "equip nightvision goggles",textstyle);
				}

				if(GUI.Button(new Rect(originalWidth - 150, 240, 112, 112), "",nightstyle))
				{
					if(nightmode == false)
					{
						nightvision.enabled = true;
						nightvision1.enabled = true;
						nightmode = true;
					}
					else if(nightmode == true)
					{
						nightvision.enabled = false;
						nightvision1.enabled = false;
						nightmode = false;
					}
				}
			}
			else if(PlayerPrefs.GetInt("Eaglelevel8") == 1)
			{
				if(!nightmode)
				{
					GUI.Label(new Rect(originalWidth - 160 , 300 , 150 , 100), "equip nightvision goggles",textstyle);
				}

				if(GUI.Button(new Rect(originalWidth - 150, 240, 112, 112), "",nightstyle))
				{
					if(nightmode == false)
					{
						nightvision.enabled = true;
						nightvision1.enabled = true;
						nightmode = true;
					}
					else if(nightmode == true)
					{
						nightvision.enabled = false;
						nightvision1.enabled = false;
						nightmode = false;
					}
				}
			}
		}
		GUI.matrix = svMat;
	}
}

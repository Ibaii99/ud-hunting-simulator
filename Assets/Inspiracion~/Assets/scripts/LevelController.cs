using UnityEngine;
using System.Collections;
public class LevelController : MonoBehaviour 
{
	public float originalWidth = 1024.0f;
	public float originalHeight = 768.0f;
	public Vector3 scale;
	public Material skyboxday;
	public Material skyboxnight;

	public GameObject wolfnight1;
	public GameObject wolfnight2;
	public GameObject wolfnight3;
	public GameObject wolfnight4;
	public GameObject wolfnight5;
	public GameObject wolfnight6;
	public GameObject wolfnight7;

	public GameObject boar1;
	public GameObject boar2;
	public GameObject boar3;
	public GameObject boar4;
	public GameObject boar5;
	public GameObject boar6;


	public GameObject mainlight;
	public GUIStyle nightstyle;
	public bool nightmode = false;
	public NightVision nightvision;
	public NightVision nightvision1;
	public GameObject rocks;
	public GUIStyle textstyle;


	void Start () 
	{
//		if(PlayerPrefs.GetInt("BearLevel1") == 1)
//		{
//			RenderSettings.skybox = skyboxday;
//			RenderSettings.ambientLight = new Color(0.640f, 0.665f, 0.687f,1.00f);
//			mainlight.SetActive(true);			
//			wolfnight1.SetActive(false);
//			wolfnight2.SetActive(false);
//			wolfnight3.SetActive(false);
//			wolfnight4.SetActive(false);
//			wolfnight5.SetActive(false);
//			wolfnight6.SetActive(false);
//			wolfnight7.SetActive(false);
//			wolfnight8.SetActive(false);
//
//			bear1.SetActive(true);
//			rocks.SetActive(true);
//			
//			
//			Lion_Night1.SetActive(false);
//			Lion_Night2.SetActive(false);
//		}
		if(PlayerPrefs.GetInt("Wolflevel3") == 1)
		{
			RenderSettings.skybox = skyboxnight;
			RenderSettings.ambientLight = new Color(0.074f, 0.073f, 0.073f,1.00f);
			mainlight.SetActive(false);

			wolfnight1.SetActive(true);
			wolfnight2.SetActive(true);
			wolfnight3.SetActive(false);
			wolfnight4.SetActive(false);
			wolfnight5.SetActive(false);
			wolfnight6.SetActive(false);
			wolfnight7.SetActive(false);


			boar1.SetActive(false);
			boar2.SetActive(false);
			boar3.SetActive(false);
			boar4.SetActive(false);
			boar5.SetActive(false);
			boar6.SetActive(false);


			rocks.SetActive(false);		
		}
		else if(PlayerPrefs.GetInt("Wolflevel4") == 1)
		{
			RenderSettings.skybox = skyboxnight;
			RenderSettings.ambientLight = new Color(0.074f, 0.073f, 0.073f,1.00f);
			mainlight.SetActive(false);

			wolfnight1.SetActive(true);
			wolfnight2.SetActive(true);
			wolfnight3.SetActive(true);
			wolfnight4.SetActive(true);
			wolfnight5.SetActive(false);
			wolfnight6.SetActive(false);
			wolfnight7.SetActive(false);

			boar1.SetActive(false);
			boar2.SetActive(false);
			boar3.SetActive(false);
			boar4.SetActive(false);
			boar5.SetActive(false);
			boar6.SetActive(false);
			
			rocks.SetActive(false);
			
			
		}
		else if(PlayerPrefs.GetInt("Wolflevel6") == 1)
		{
			RenderSettings.skybox = skyboxnight;
			RenderSettings.ambientLight = new Color(0.074f, 0.073f, 0.073f,1.00f);
			mainlight.SetActive(false);
			
			wolfnight1.SetActive(true);
			wolfnight2.SetActive(true);
			wolfnight3.SetActive(true);
			wolfnight4.SetActive(true);
			wolfnight5.SetActive(true);
			wolfnight6.SetActive(true);
			wolfnight7.SetActive(false);

			boar1.SetActive(false);
			boar2.SetActive(false);
			boar3.SetActive(false);
			boar4.SetActive(false);
			boar5.SetActive(false);
			boar6.SetActive(false);

			rocks.SetActive(false);	
			
		}
		else if(PlayerPrefs.GetInt("Wolflevel8") == 1)
		{
			RenderSettings.skybox = skyboxnight;
			RenderSettings.ambientLight = new Color(0.074f, 0.073f, 0.073f,1.00f);
			mainlight.SetActive(false);
			
			wolfnight1.SetActive(true);
			wolfnight2.SetActive(true);
			wolfnight3.SetActive(true);
			wolfnight4.SetActive(true);
			wolfnight5.SetActive(true);
			wolfnight6.SetActive(true);
			wolfnight7.SetActive(true);			

			boar1.SetActive(false);
			boar2.SetActive(false);
			boar3.SetActive(false);
			boar4.SetActive(false);
			boar5.SetActive(false);
			boar6.SetActive(false);

			rocks.SetActive(false);
			
		}

		if(PlayerPrefs.GetInt("Boarlevel3") == 1)
		{
			RenderSettings.skybox = skyboxnight;
			RenderSettings.ambientLight = new Color(0.074f, 0.073f, 0.073f,1.00f);
			mainlight.SetActive(false);
			
			wolfnight1.SetActive(false);
			wolfnight2.SetActive(false);
			wolfnight3.SetActive(false);
			wolfnight4.SetActive(false);
			wolfnight5.SetActive(false);
			wolfnight6.SetActive(false);
			wolfnight7.SetActive(false);	
			
			boar1.SetActive(true);
			boar2.SetActive(true);
			boar3.SetActive(true);
			boar4.SetActive(false);
			boar5.SetActive(false);
			boar6.SetActive(false);			
			
			rocks.SetActive(false);		
		}
		else if(PlayerPrefs.GetInt("Boarlevel5") == 1)
		{
			RenderSettings.skybox = skyboxnight;
			RenderSettings.ambientLight = new Color(0.074f, 0.073f, 0.073f,1.00f);
			mainlight.SetActive(false);
			
			wolfnight1.SetActive(false);
			wolfnight2.SetActive(false);
			wolfnight3.SetActive(false);
			wolfnight4.SetActive(false);
			wolfnight5.SetActive(false);
			wolfnight6.SetActive(false);
			wolfnight7.SetActive(false);	
			
			boar1.SetActive(true);
			boar2.SetActive(true);
			boar3.SetActive(true);
			boar4.SetActive(true);
			boar5.SetActive(false);
			boar6.SetActive(false);			
			
			rocks.SetActive(false);		
		}
		else if(PlayerPrefs.GetInt("Boarlevel6") == 1)
		{
			RenderSettings.skybox = skyboxnight;
			RenderSettings.ambientLight = new Color(0.074f, 0.073f, 0.073f,1.00f);
			mainlight.SetActive(false);
			
			wolfnight1.SetActive(false);
			wolfnight2.SetActive(false);
			wolfnight3.SetActive(false);
			wolfnight4.SetActive(false);
			wolfnight5.SetActive(false);
			wolfnight6.SetActive(false);
			wolfnight7.SetActive(false);	
			
			boar1.SetActive(true);
			boar2.SetActive(true);
			boar3.SetActive(true);
			boar4.SetActive(true);
			boar5.SetActive(true);
			boar6.SetActive(false);			
			
			rocks.SetActive(false);		
		}
		else if(PlayerPrefs.GetInt("Boarlevel7") == 1)
		{
			RenderSettings.skybox = skyboxnight;
			RenderSettings.ambientLight = new Color(0.074f, 0.073f, 0.073f,1.00f);
			mainlight.SetActive(false);
			
			wolfnight1.SetActive(false);
			wolfnight2.SetActive(false);
			wolfnight3.SetActive(false);
			wolfnight4.SetActive(false);
			wolfnight5.SetActive(false);
			wolfnight6.SetActive(false);
			wolfnight7.SetActive(false);	
			
			boar1.SetActive(true);
			boar2.SetActive(true);
			boar3.SetActive(true);
			boar4.SetActive(true);
			boar5.SetActive(true);
			boar6.SetActive(true);			
			
			rocks.SetActive(false);		
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
			if(PlayerPrefs.GetInt("Wolflevel3") == 1)
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
			else if(PlayerPrefs.GetInt("Wolflevel4") == 1)
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
			else if(PlayerPrefs.GetInt("Wolflevel6") == 1)
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
			else if(PlayerPrefs.GetInt("Wolflevel8") == 1)
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







			if(PlayerPrefs.GetInt("Boarlevel3") == 1)
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
			else if(PlayerPrefs.GetInt("Boarlevel5") == 1)
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
			else if(PlayerPrefs.GetInt("Boarlevel6") == 1)
			{
				if(!nightmode)
				{
					GUI.Label(new Rect(originalWidth - 160 , 300 , 150 , 100), "equip nightvision goggles",textstyle);
				}

				if(GUI.Button(new Rect(originalWidth - 150, 240, 116, 155), "",nightstyle))
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
			else if(PlayerPrefs.GetInt("Boarlevel7") == 1)
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
using UnityEngine;
using System.Collections;
public class DuckLevelController : MonoBehaviour 
{
	public float originalWidth = 1024.0f;
	public float originalHeight = 768.0f;
	public Vector3 scale;
	
	public Material skyboxday;
	public Material skyboxnight;
	public GameObject Duck1;
	public GameObject Duck2;
	public GameObject Duck3;
	public GameObject Duck4;
	public GameObject Duck5;
	public GameObject Duck6;
	public GameObject Duck7;
	public GameObject Duck8;
	public GameObject Duck9;
	public GameObject Duck10;
	public GameObject Duck11;
	public GameObject Duck12;

	public GameObject Stag1;
	public GameObject Stag2;
	public GameObject Stag3;
	public GameObject Stag4;
	public GameObject Stag5;
	public GameObject Stag6;
	public GameObject Stag7;


	public GameObject mainlight;
	
	public GUIStyle nightstyle;
	public bool nightmode = false;
	public NightVision nightvision;
	public NightVision nightvision1;
	public GameObject DuckTree;
	public GameObject StagTree;

	public GUIStyle textstyle;
	
	void Start () 
	{
		if(PlayerPrefs.GetInt("Ducklevel1") == 1)
		{
			RenderSettings.skybox = skyboxday;
			RenderSettings.fog = true;
			RenderSettings.ambientLight = new Color(0.640f, 0.665f, 0.687f,1.00f);
			mainlight.SetActive(true);	

			Duck1.SetActive(true);
			Duck2.SetActive(true);
			Duck3.SetActive(true);
			Duck4.SetActive(false);
			Duck5.SetActive(false);
			Duck6.SetActive(false);
			Duck7.SetActive(false);
			Duck8.SetActive(false);
			Duck9.SetActive(false);
			Duck10.SetActive(false);
			Duck11.SetActive(false);
			Duck12.SetActive(false);

			Stag1.SetActive(false);
			Stag2.SetActive(false);
			Stag3.SetActive(false);
			Stag4.SetActive(false);
			Stag5.SetActive(false);
			Stag6.SetActive(false);
			Stag7.SetActive(false);

			DuckTree.SetActive(true);
			StagTree.SetActive(false);
		}
		else if(PlayerPrefs.GetInt("Ducklevel2") == 1)
		{
			RenderSettings.skybox = skyboxday;
			RenderSettings.fog = true;
			RenderSettings.ambientLight = new Color(0.640f, 0.665f, 0.687f,1.00f);
			mainlight.SetActive(true);	
			
			Duck1.SetActive(true);
			Duck2.SetActive(true);
			Duck3.SetActive(true);
			Duck4.SetActive(true);
			Duck5.SetActive(false);
			Duck6.SetActive(false);
			Duck7.SetActive(false);
			Duck8.SetActive(false);
			Duck9.SetActive(false);
			Duck10.SetActive(false);
			Duck11.SetActive(false);
			Duck12.SetActive(false);
			
			
			Stag1.SetActive(false);
			Stag2.SetActive(false);
			Stag3.SetActive(false);
			Stag4.SetActive(false);
			Stag5.SetActive(false);
			Stag6.SetActive(false);
			Stag7.SetActive(false);
			
			DuckTree.SetActive(true);
			StagTree.SetActive(false);
		}
		else if(PlayerPrefs.GetInt("Ducklevel3") == 1)
		{
			RenderSettings.skybox = skyboxday;
			RenderSettings.fog = true;
			RenderSettings.ambientLight = new Color(0.640f, 0.665f, 0.687f,1.00f);
			mainlight.SetActive(true);	
			
			Duck1.SetActive(true);
			Duck2.SetActive(true);
			Duck3.SetActive(true);
			Duck4.SetActive(true);
			Duck5.SetActive(true);
			Duck6.SetActive(true);
			Duck7.SetActive(false);
			Duck8.SetActive(false);
			Duck9.SetActive(false);
			Duck10.SetActive(false);
			Duck11.SetActive(false);
			Duck12.SetActive(false);
			
			
			Stag1.SetActive(false);
			Stag2.SetActive(false);
			Stag3.SetActive(false);
			Stag4.SetActive(false);
			Stag5.SetActive(false);
			Stag6.SetActive(false);
			Stag7.SetActive(false);
			
			DuckTree.SetActive(true);
			StagTree.SetActive(false);
		}
		else if(PlayerPrefs.GetInt("Ducklevel4") == 1)
		{
			RenderSettings.skybox = skyboxnight;
			RenderSettings.fog = false;
			RenderSettings.ambientLight = new Color(0.074f, 0.073f, 0.073f,1.00f);			
			mainlight.SetActive(false);
			
			Duck1.SetActive(true);
			Duck2.SetActive(true);
			Duck3.SetActive(true);
			Duck4.SetActive(true);
			Duck5.SetActive(false);
			Duck6.SetActive(false);
			Duck7.SetActive(false);
			Duck8.SetActive(false);
			Duck9.SetActive(false);
			Duck10.SetActive(false);
			Duck11.SetActive(false);
			Duck12.SetActive(false);
			
			
			Stag1.SetActive(false);
			Stag2.SetActive(false);
			Stag3.SetActive(false);
			Stag4.SetActive(false);
			Stag5.SetActive(false);
			Stag6.SetActive(false);
			Stag7.SetActive(false);
			
			DuckTree.SetActive(false);
			StagTree.SetActive(true);
		}
		else if(PlayerPrefs.GetInt("Ducklevel5") == 1)
		{
			RenderSettings.skybox = skyboxnight;
			RenderSettings.fog = false;
			RenderSettings.ambientLight = new Color(0.074f, 0.073f, 0.073f,1.00f);			
			mainlight.SetActive(false);
			
			Duck1.SetActive(true);
			Duck2.SetActive(true);
			Duck3.SetActive(true);
			Duck4.SetActive(false);
			Duck5.SetActive(false);
			Duck6.SetActive(false);
			Duck7.SetActive(false);
			Duck8.SetActive(false);
			Duck9.SetActive(false);
			Duck10.SetActive(true);
			Duck11.SetActive(true);
			Duck12.SetActive(true);
			
			
			Stag1.SetActive(false);
			Stag2.SetActive(false);
			Stag3.SetActive(false);
			Stag4.SetActive(false);
			Stag5.SetActive(false);
			Stag6.SetActive(false);
			Stag7.SetActive(false);
			
			DuckTree.SetActive(false);
			StagTree.SetActive(true);
		}
		else if(PlayerPrefs.GetInt("Ducklevel6") == 1)
		{
			RenderSettings.skybox = skyboxday;
			RenderSettings.fog = true;
			RenderSettings.ambientLight = new Color(0.640f, 0.665f, 0.687f,1.00f);
			mainlight.SetActive(true);	
			
			Duck1.SetActive(true);
			Duck2.SetActive(true);
			Duck3.SetActive(true);
			Duck4.SetActive(true);
			Duck5.SetActive(true);
			Duck6.SetActive(true);
			Duck7.SetActive(false);
			Duck8.SetActive(false);
			Duck9.SetActive(true);
			Duck10.SetActive(true);
			Duck11.SetActive(true);
			Duck12.SetActive(true);
			
			
			Stag1.SetActive(false);
			Stag2.SetActive(false);
			Stag3.SetActive(false);
			Stag4.SetActive(false);
			Stag5.SetActive(false);
			Stag6.SetActive(false);
			Stag7.SetActive(false);
			
			DuckTree.SetActive(true);
			StagTree.SetActive(false);
		}
		else if(PlayerPrefs.GetInt("Ducklevel7") == 1)
		{
			RenderSettings.skybox = skyboxnight;
			RenderSettings.fog = false;
			RenderSettings.ambientLight = new Color(0.074f, 0.073f, 0.073f,1.00f);			
			mainlight.SetActive(false);
			
			Duck1.SetActive(false);
			Duck2.SetActive(false);
			Duck3.SetActive(true);
			Duck4.SetActive(true);
			Duck5.SetActive(true);
			Duck6.SetActive(true);
			Duck7.SetActive(true);
			Duck8.SetActive(true);
			Duck9.SetActive(true);
			Duck10.SetActive(true);
			Duck11.SetActive(false);
			Duck12.SetActive(false);			
			
			Stag1.SetActive(false);
			Stag2.SetActive(false);
			Stag3.SetActive(false);
			Stag4.SetActive(false);
			Stag5.SetActive(false);
			Stag6.SetActive(false);
			Stag7.SetActive(false);
			
			DuckTree.SetActive(false);
			StagTree.SetActive(true);
		}
		else if(PlayerPrefs.GetInt("Ducklevel8") == 1)
		{
			RenderSettings.skybox = skyboxnight;
			RenderSettings.fog = false;
			RenderSettings.ambientLight = new Color(0.074f, 0.073f, 0.073f,1.00f);			
			mainlight.SetActive(false);
			
			Duck1.SetActive(true);
			Duck2.SetActive(true);
			Duck3.SetActive(true);
			Duck4.SetActive(true);
			Duck5.SetActive(true);
			Duck6.SetActive(true);
			Duck7.SetActive(true);
			Duck8.SetActive(true);
			Duck9.SetActive(true);
			Duck10.SetActive(true);
			Duck11.SetActive(true);
			Duck12.SetActive(true);			
			
			Stag1.SetActive(false);
			Stag2.SetActive(false);
			Stag3.SetActive(false);
			Stag4.SetActive(false);
			Stag5.SetActive(false);
			Stag6.SetActive(false);
			Stag7.SetActive(false);
			
			DuckTree.SetActive(false);
			StagTree.SetActive(true);
		}



//		else if(PlayerPrefs.GetInt("Ducklevel1Night") == 1)
//		{
//			RenderSettings.skybox = skyboxnight;
//			RenderSettings.fog = false;
//			RenderSettings.ambientLight = new Color(0.074f, 0.073f, 0.073f,1.00f);			
//			mainlight.SetActive(false);
//			
//			Duck1.SetActive(false);
//			Duck2.SetActive(false);
//			Duck3.SetActive(false);
//			Duck4.SetActive(false);
//			Duck5.SetActive(false);
//			Duck6.SetActive(false);
//			Duck7.SetActive(false);
//			Duck8.SetActive(false);
//			Duck9.SetActive(false);
//			Duck10.SetActive(false);
//			Duck11.SetActive(false);
//			Duck12.SetActive(false);
//
//
//			Stag1.SetActive(false);
//			Stag2.SetActive(false);
//			Stag3.SetActive(false);
//			Stag4.SetActive(false);
//			Stag5.SetActive(false);
//			Stag6.SetActive(false);
//			Stag7.SetActive(false);
//
//			DuckTree.SetActive(false);
//			StagTree.SetActive(true);
//		}


		//Stag Levels
		if(PlayerPrefs.GetInt("Staglevel2") == 1)
		{
			RenderSettings.skybox = skyboxnight;
			RenderSettings.fog = false;
			RenderSettings.ambientLight = new Color(0.074f, 0.073f, 0.073f,1.00f);			
			mainlight.SetActive(false);
			
			Duck1.SetActive(false);
			Duck2.SetActive(false);
			Duck3.SetActive(false);
			Duck4.SetActive(false);
			Duck5.SetActive(false);
			Duck6.SetActive(false);
			Duck7.SetActive(false);
			Duck8.SetActive(false);
			Duck9.SetActive(false);
			Duck10.SetActive(false);
			Duck11.SetActive(false);
			Duck12.SetActive(false);
			
			
			Stag1.SetActive(true);
			Stag2.SetActive(true);
			Stag3.SetActive(true);
			Stag4.SetActive(true);
			Stag5.SetActive(false);
			Stag6.SetActive(false);
			Stag7.SetActive(false);

			DuckTree.SetActive(false);
			StagTree.SetActive(true);
		}
		else if(PlayerPrefs.GetInt("Staglevel5") == 1)
		{
			RenderSettings.skybox = skyboxnight;
			RenderSettings.fog = false;
			RenderSettings.ambientLight = new Color(0.074f, 0.073f, 0.073f,1.00f);			
			mainlight.SetActive(false);
			
			Duck1.SetActive(false);
			Duck2.SetActive(false);
			Duck3.SetActive(false);
			Duck4.SetActive(false);
			Duck5.SetActive(false);
			Duck6.SetActive(false);
			Duck7.SetActive(false);
			Duck8.SetActive(false);
			Duck9.SetActive(false);
			Duck10.SetActive(false);
			Duck11.SetActive(false);
			Duck12.SetActive(false);
			
			
			Stag1.SetActive(true);
			Stag2.SetActive(true);
			Stag3.SetActive(true);
			Stag4.SetActive(true);
			Stag5.SetActive(true);
			Stag6.SetActive(false);
			Stag7.SetActive(false);

			DuckTree.SetActive(false);
			StagTree.SetActive(true);
		}
		else if(PlayerPrefs.GetInt("Staglevel8") == 1)
		{
			RenderSettings.skybox = skyboxnight;
			RenderSettings.fog = false;
			RenderSettings.ambientLight = new Color(0.074f, 0.073f, 0.073f,1.00f);			
			mainlight.SetActive(false);
			
			Duck1.SetActive(false);
			Duck2.SetActive(false);
			Duck3.SetActive(false);
			Duck4.SetActive(false);
			Duck5.SetActive(false);
			Duck6.SetActive(false);
			Duck7.SetActive(false);
			Duck8.SetActive(false);
			Duck9.SetActive(false);
			Duck10.SetActive(false);
			Duck11.SetActive(false);
			Duck12.SetActive(false);
			
			
			Stag1.SetActive(true);
			Stag2.SetActive(true);
			Stag3.SetActive(true);
			Stag4.SetActive(true);
			Stag5.SetActive(true);
			Stag6.SetActive(true);
			Stag7.SetActive(true);

			DuckTree.SetActive(false);
			StagTree.SetActive(true);
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
			if(PlayerPrefs.GetInt("Staglevel8") == 1)
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
			if(PlayerPrefs.GetInt("Staglevel5") == 1)
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
			if(PlayerPrefs.GetInt("Staglevel2") == 1)
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
			if(PlayerPrefs.GetInt("Ducklevel1Night") == 1)
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


			//Duck Levels

			if(PlayerPrefs.GetInt("Ducklevel4") == 1)
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
			if(PlayerPrefs.GetInt("Ducklevel5") == 1)
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
			if(PlayerPrefs.GetInt("Ducklevel7") == 1)
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
			if(PlayerPrefs.GetInt("Ducklevel8") == 1)
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

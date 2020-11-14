using UnityEngine;
using System.Collections;
public class Level_Controller_Snow : MonoBehaviour 
{
	private float originalWidth = 1024.0f;
	private float originalHeight = 768.0f;
	private Vector3 scale;

	public Transform stagcampoint;
	public Transform WolfCamPoint;

	public Transform playerTransform;

	public GameObject Stag1;
	public GameObject Stag2;
	public GameObject Stag3;
	public GameObject Stag4;

	public GameObject Wolf1;
	public GameObject Wolf2;
	public GameObject Wolf3;
	public GameObject Wolf4;
	public GameObject Wolf5;
	public GameObject Wolf6;


	public NightVision nightvision;
	public NightVision nightvision1;
	public GUIStyle nightstyle;

	private bool nightmode = false;

	void Start () 
	{
		nightmode = false;

		if(PlayerPrefs.GetInt("Staglevel1") == 1)
		{
			playerTransform.position = stagcampoint.position;
			playerTransform.rotation = stagcampoint.rotation;

			Stag1.SetActive(true);
			Stag2.SetActive(true);
			Stag3.SetActive(false);
			Stag4.SetActive(false);

			Wolf1.SetActive(false);
			Wolf2.SetActive(false);
			Wolf3.SetActive(false);
			Wolf4.SetActive(false);
			Wolf5.SetActive(false);
			Wolf6.SetActive(false);

		}
		if(PlayerPrefs.GetInt("Staglevel6") == 1)
		{
			playerTransform.position = stagcampoint.position;
			playerTransform.rotation = stagcampoint.rotation;

			Stag1.SetActive(true);
			Stag2.SetActive(true);
			Stag3.SetActive(true);
			Stag4.SetActive(true);
			
			Wolf1.SetActive(false);
			Wolf2.SetActive(false);
			Wolf3.SetActive(false);
			Wolf4.SetActive(false);
			Wolf5.SetActive(false);
			Wolf6.SetActive(false);

		}
		if(PlayerPrefs.GetInt("Wolflevel5") == 1)
		{
			playerTransform.position = WolfCamPoint.position;
			playerTransform.rotation = WolfCamPoint.rotation;
			
			Stag1.SetActive(false);
			Stag2.SetActive(false);
			Stag3.SetActive(false);
			Stag4.SetActive(false);
			
			Wolf1.SetActive(true);
			Wolf2.SetActive(true);
			Wolf3.SetActive(true);
			Wolf4.SetActive(true);
			Wolf5.SetActive(false);
			Wolf6.SetActive(true);			
		}
		if(PlayerPrefs.GetInt("Wolflevel7") == 1)
		{
			playerTransform.position = WolfCamPoint.position;
			playerTransform.rotation = WolfCamPoint.rotation;
			
			Stag1.SetActive(false);
			Stag2.SetActive(false);
			Stag3.SetActive(false);
			Stag4.SetActive(false);
			
			Wolf1.SetActive(true);
			Wolf2.SetActive(true);
			Wolf3.SetActive(true);
			Wolf4.SetActive(true);
			Wolf5.SetActive(true);
			Wolf6.SetActive(true);			
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
		GUI.matrix = svMat;
	}
}

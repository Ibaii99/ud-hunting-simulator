﻿using UnityEngine;
using System.Collections;

public class BoarLevelSelection : MonoBehaviour {

	private float originalWidth = 1024.0f;
	private float originalHeight = 768.0f;
	private Vector3 scale;
	public AudioClip btnaudio;
	
	public Texture map1;	
	public Texture cashtexture;	
	public Texture cashbg;	
		public Texture zeeshan;
	public Texture labelBG;	

	public GUIStyle menustyle;
	public GUIStyle headlinestyle;
	public GUIStyle coinstyle;
	
	public GUIStyle levelstyle1;
	public GUIStyle levelstyle2;
	public GUIStyle levelstyle3;
	public GUIStyle levelstyle4;
	public GUIStyle levelstyle5;
	public GUIStyle levelstyle6;
	public GUIStyle levelstyle7;
	public GUIStyle levelstyle8;
	public GUIStyle lockedstyle;
	
	private int completedlevels;	
	private string titlename = "";
	
	void Start () 
	{
		completedlevels = PlayerPrefs.GetInt("BoarLevelCompleted");
		titlename = "Boar Levels";	
	}
	
	void OnGUI()
	{
		scale.x = Screen.width/originalWidth; // calculate hor scale
		scale.y = Screen.height/originalHeight; // calculate vert scale
		scale.z = 1.0f;
		var svMat= GUI.matrix; 
		GUI.matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity,scale);
		
		GUI.DrawTexture (new Rect(0,0, originalWidth, originalHeight), map1);		
		GUI.DrawTexture (new Rect(originalWidth / 2 - 238 , 200 , 476 , 67), labelBG);
				GUI.DrawTexture(new Rect(40 ,  100 , 305 , 64), zeeshan);
		GUI.DrawTexture(new Rect(originalWidth - 282 , 120 , 282,70), cashbg);
		GUI.DrawTexture(new Rect(originalWidth - 240 , 100 , 220,103), cashtexture);
		GUI.Label(new Rect(originalWidth - 160, 140,158, 36 ),PlayerPrefs.GetInt ("Earnings").ToString(), coinstyle );

		if(GUI.Button(new Rect(50, originalHeight / 2 - 80 , 112, 112), "", levelstyle1))
		{
			PlayerPrefs.SetInt ("Boarlevel1", 1);
			PlayerPrefs.SetInt ("Boarlevel2", 0);
			PlayerPrefs.SetInt ("Boarlevel3", 0);
			PlayerPrefs.SetInt ("Boarlevel4", 0);
			PlayerPrefs.SetInt ("Boarlevel5", 0);
			PlayerPrefs.SetInt ("Boarlevel6", 0);
			PlayerPrefs.SetInt ("Boarlevel7", 0);
			PlayerPrefs.SetInt ("Boarlevel8", 0);	

			PlayerPrefs.SetInt ("Wolflevel1", 0);
			PlayerPrefs.SetInt ("Wolflevel2", 0);
			
			DragonCounter.totalanimals = 1;
			GUI_Controller.time_Limit = 23;
			GUI_Controller.hint = "Hunt One Boar by sniper gun.";
			#if UNITY_ANDROID
			Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Small);
			#endif
			Handheld.StartActivityIndicator();
			Application.LoadLevel("Level4");
		}
		if(completedlevels >= 2)
		{
			if(GUI.Button(new Rect(70, originalHeight / 2 + 70, 112, 112), "", levelstyle2))
			{
				PlayerPrefs.SetInt ("Boarlevel1", 0);
				PlayerPrefs.SetInt ("Boarlevel2", 1);
				PlayerPrefs.SetInt ("Boarlevel3", 0);
				PlayerPrefs.SetInt ("Boarlevel4", 0);
				PlayerPrefs.SetInt ("Boarlevel5", 0);
				PlayerPrefs.SetInt ("Boarlevel6", 0);
				PlayerPrefs.SetInt ("Boarlevel7", 0);
				PlayerPrefs.SetInt ("Boarlevel8", 0);	

				PlayerPrefs.SetInt ("Wolflevel1", 0);
				PlayerPrefs.SetInt ("Wolflevel2", 0);
				
				DragonCounter.totalanimals = 2;
				GUI_Controller.time_Limit = 25;
				GUI_Controller.hint = "Hunt Two Boar's by sniper gun.";
				#if UNITY_ANDROID
				Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Small);
				#endif
				Handheld.StartActivityIndicator();
				Application.LoadLevel("Level4");
			}
		}
		else
		{
			GUI.Button(new Rect(70, originalHeight / 2 + 70, 112, 112), "", lockedstyle);
		}
		
		if(completedlevels >= 3)
		{
			if(GUI.Button(new Rect(originalWidth / 2 - 200, originalHeight / 2 - 80 , 112, 112), "", levelstyle3))
			{
				PlayerPrefs.SetInt ("Boarlevel1", 0);
				PlayerPrefs.SetInt ("Boarlevel2", 0);
				PlayerPrefs.SetInt ("Boarlevel3", 1);
				PlayerPrefs.SetInt ("Boarlevel4", 0);
				PlayerPrefs.SetInt ("Boarlevel5", 0);
				PlayerPrefs.SetInt ("Boarlevel6", 0);
				PlayerPrefs.SetInt ("Boarlevel7", 0);
				PlayerPrefs.SetInt ("Boarlevel8", 0);	

				PlayerPrefs.SetInt ("Wolflevel3", 0);
				PlayerPrefs.SetInt ("Wolflevel4", 0);
				PlayerPrefs.SetInt ("Wolflevel6", 0);
				PlayerPrefs.SetInt ("Wolflevel8", 0);
				
				DragonCounter.totalanimals = 2;
				GUI_Controller.time_Limit = 25;
				GUI_Controller.hint = "Hunt Two Boar's by sniper gun.";
				#if UNITY_ANDROID
				Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Small);
				#endif
				Handheld.StartActivityIndicator();
				Application.LoadLevel("Level1");
			}
		}
		else
		{
			GUI.Button(new Rect(originalWidth / 2 - 200, originalHeight / 2 - 80 , 112, 112), "", lockedstyle);
		}
		
		if(completedlevels >= 4)
		{
			if(GUI.Button(new Rect(originalWidth / 2 - 180, originalHeight / 2 + 70, 112, 112), "", levelstyle4))
			{
				PlayerPrefs.SetInt ("Boarlevel1", 0);
				PlayerPrefs.SetInt ("Boarlevel2", 0);
				PlayerPrefs.SetInt ("Boarlevel3", 0);
				PlayerPrefs.SetInt ("Boarlevel4", 1);
				PlayerPrefs.SetInt ("Boarlevel5", 0);
				PlayerPrefs.SetInt ("Boarlevel6", 0);
				PlayerPrefs.SetInt ("Boarlevel7", 0);
				PlayerPrefs.SetInt ("Boarlevel8", 0);	

				PlayerPrefs.SetInt ("Wolflevel1", 0);
				PlayerPrefs.SetInt ("Wolflevel2", 0);
				
				DragonCounter.totalanimals = 4;
				GUI_Controller.time_Limit = 30;
				GUI_Controller.hint = "Hunt Four Boar's by sniper gun.";
				#if UNITY_ANDROID
				Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Small);
				#endif
				Handheld.StartActivityIndicator();
				Application.LoadLevel("Level4");
			}
		}
		else
		{
			GUI.Button(new Rect(originalWidth / 2 - 180, originalHeight / 2 + 70, 112, 112), "", lockedstyle);
		}
		
		if(completedlevels >= 5)
		{
			if(GUI.Button(new Rect(originalWidth / 2 + 40, originalHeight / 2 - 80 , 112, 112), "", levelstyle5))
			{
				PlayerPrefs.SetInt ("Boarlevel1", 0);
				PlayerPrefs.SetInt ("Boarlevel2", 0);
				PlayerPrefs.SetInt ("Boarlevel3", 0);
				PlayerPrefs.SetInt ("Boarlevel4", 0);
				PlayerPrefs.SetInt ("Boarlevel5", 1);
				PlayerPrefs.SetInt ("Boarlevel6", 0);
				PlayerPrefs.SetInt ("Boarlevel7", 0);
				PlayerPrefs.SetInt ("Boarlevel8", 0);	

				PlayerPrefs.SetInt ("Wolflevel3", 0);
				PlayerPrefs.SetInt ("Wolflevel4", 0);
				PlayerPrefs.SetInt ("Wolflevel6", 0);
				PlayerPrefs.SetInt ("Wolflevel8", 0);
				
				DragonCounter.totalanimals = 4;
				GUI_Controller.time_Limit = 30;
				GUI_Controller.hint = "Hunt Four Boar by sniper gun.";
				#if UNITY_ANDROID
				Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Small);
				#endif
				Handheld.StartActivityIndicator();
				Application.LoadLevel("Level1");
			}
		}
		else
		{
			GUI.Button(new Rect(originalWidth / 2 + 40, originalHeight / 2 - 80 , 112, 112), "", lockedstyle);
		}
		
		if(completedlevels >= 6)
		{
			if(GUI.Button(new Rect(originalWidth / 2  + 80, originalHeight / 2 + 70 , 112, 112), "", levelstyle6))
			{
				PlayerPrefs.SetInt ("Boarlevel1", 0);
				PlayerPrefs.SetInt ("Boarlevel2", 0);
				PlayerPrefs.SetInt ("Boarlevel3", 0);
				PlayerPrefs.SetInt ("Boarlevel4", 0);
				PlayerPrefs.SetInt ("Boarlevel5", 0);
				PlayerPrefs.SetInt ("Boarlevel6", 1);
				PlayerPrefs.SetInt ("Boarlevel7", 0);
				PlayerPrefs.SetInt ("Boarlevel8", 0);	

				PlayerPrefs.SetInt ("Wolflevel3", 0);
				PlayerPrefs.SetInt ("Wolflevel4", 0);
				PlayerPrefs.SetInt ("Wolflevel6", 0);
				PlayerPrefs.SetInt ("Wolflevel8", 0);
				
				DragonCounter.totalanimals = 5;
				GUI_Controller.time_Limit = 35;
				GUI_Controller.hint = "Hunt Five Boar by sniper gun.";
				#if UNITY_ANDROID
				Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Small);
				#endif
				Handheld.StartActivityIndicator();
				Application.LoadLevel("Level1");
			}
		}
		else
		{
			GUI.Button(new Rect(originalWidth / 2  + 80, originalHeight / 2 + 70 , 112, 112), "", lockedstyle);
		}
		
		if(completedlevels >= 7)
		{
			if(GUI.Button(new Rect(originalWidth / 2 + 280, originalHeight / 2 -  80, 112, 112), "", levelstyle7))
			{
				PlayerPrefs.SetInt ("Boarlevel1", 0);
				PlayerPrefs.SetInt ("Boarlevel2", 0);
				PlayerPrefs.SetInt ("Boarlevel3", 0);
				PlayerPrefs.SetInt ("Boarlevel4", 0);
				PlayerPrefs.SetInt ("Boarlevel5", 0);
				PlayerPrefs.SetInt ("Boarlevel6", 0);
				PlayerPrefs.SetInt ("Boarlevel7", 1);
				PlayerPrefs.SetInt ("Boarlevel8", 0);				

				PlayerPrefs.SetInt ("Wolflevel3", 0);
				PlayerPrefs.SetInt ("Wolflevel4", 0);
				PlayerPrefs.SetInt ("Wolflevel6", 0);
				PlayerPrefs.SetInt ("Wolflevel8", 0);

				DragonCounter.totalanimals = 6;
				GUI_Controller.time_Limit = 40;
				GUI_Controller.hint = "Hunt Six Boar by sniper gun.";
				#if UNITY_ANDROID
				Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Small);
				#endif
				Handheld.StartActivityIndicator();
				Application.LoadLevel("Level1");
			}
		}
		else
		{
			GUI.Button(new Rect(originalWidth / 2 + 280, originalHeight / 2 -  80, 112, 112), "", lockedstyle);
		}
		
		if(completedlevels >= 8)
		{
			if(GUI.Button(new Rect(originalWidth / 2 + 320, originalHeight / 2  + 70 , 112, 112), "", levelstyle8))
			{
				PlayerPrefs.SetInt ("Boarlevel1", 0);
				PlayerPrefs.SetInt ("Boarlevel2", 0);
				PlayerPrefs.SetInt ("Boarlevel3", 0);
				PlayerPrefs.SetInt ("Boarlevel4", 0);
				PlayerPrefs.SetInt ("Boarlevel5", 0);
				PlayerPrefs.SetInt ("Boarlevel6", 0);
				PlayerPrefs.SetInt ("Boarlevel7", 0);
				PlayerPrefs.SetInt ("Boarlevel8", 1);	

				PlayerPrefs.SetInt ("Wolflevel1", 0);
				PlayerPrefs.SetInt ("Wolflevel2", 0);
				
				DragonCounter.totalanimals = 7;
				GUI_Controller.time_Limit = 50;
				GUI_Controller.hint = "Hunt Seven Boar by sniper gun.";
				#if UNITY_ANDROID
				Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Small);
				#endif
				Handheld.StartActivityIndicator();
				Application.LoadLevel("Level4");
			}
		}
		else
		{
			GUI.Button(new Rect(originalWidth / 2 + 320, originalHeight / 2  + 70 , 112, 112), "", lockedstyle);
		}	
		
		if(GUI.Button (new Rect ( 10,originalHeight - 80,200,65), "", menustyle))
		{
			if(PlayerPrefs.GetInt("FX") == 1)
			{ 
				StartCoroutine(waitformenusound());
			}
			else
			{
				#if UNITY_ANDROID
				Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Small);
				#endif
				Handheld.StartActivityIndicator();
				Application.LoadLevel("AnimalSelection");
			}
		}
		GUI.matrix = svMat;
	}
	IEnumerator waitformenusound()
	{
		GetComponent<AudioSource>().PlayOneShot(btnaudio);
		yield return new WaitForSeconds (1.0f);
		#if UNITY_ANDROID
		Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Small);
		#endif
		Handheld.StartActivityIndicator();
		Application.LoadLevel("AnimalSelection");
	}
	
	
	
	
}

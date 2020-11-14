using UnityEngine;
using System.Collections;

public class levelselect : MonoBehaviour {
	public float originalWidth; 
	public float originalHeight;
	public Vector3 scale;

	public int levels;
	public Texture bg;
	public Texture[] level;
	public Texture locked;

	public GUIStyle SelectLevelStyle;
	public GUIStyle homestyle;
	public GUIStyle NextButton;
	public GUIStyle PrevButton;

	private int no = 1;

	void Start () {
		no = 1;
		levels = PlayerPrefs.GetInt("LastLevel");	
		if (levels == 0) 
		{
			levels = 1;		
		}
	}
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
	void OnGUI()
	{			
		scale.x = Screen.width / originalWidth; 
		scale.y = Screen.height / originalHeight; 
		scale.z = 1.0f;
		var svMat = GUI.matrix; 
		GUI.matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity, scale);
		GUI.DrawTexture (new Rect (0, 0, originalWidth, originalHeight), bg);
		GUI.Label (new Rect (originalWidth/1.48f , originalHeight/4.3f - 42, 300 , 100),"SELECT LEVEL",SelectLevelStyle);
		if(no == 1)
		{
			for (int i=0; i <4; i++) 
			{
				if (i < levels)
				{
					if (GUI.Button (new Rect (originalWidth / 2 - (250 * 3 / 2) + (200 * i * 1.02f), originalHeight / 1.28f, 150, 150), level [i])) 
					{
						#if UNITY_ANDROID
						Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Large);
						#endif					
						Handheld.StartActivityIndicator();					
						Application.LoadLevel (1 + i);					
					}	
				} 
				else 
				{
					GUI.Button (new Rect (originalWidth / 2 - (250 * 3 / 2) + (200 * i * 1.026f), originalHeight / 1.28f, 140, 140), locked);
				}
			}
		}
		if(no == 2)
		{
			for (int i=4; i <8; i++) 
			{
				if (i < levels) 
				{
					
					if (GUI.Button (new Rect (originalWidth / 2 - (250 * 3 / 2) + (200 * (i - 4) * 1.02f), originalHeight / 1.28f, 150, 150), level [i])) {
						#if UNITY_ANDROID
						Handheld.SetActivityIndicatorStyle (AndroidActivityIndicatorStyle.Large);
						#endif					
						Handheld.StartActivityIndicator ();					
						Application.LoadLevel (1 + i);																
					}											
				} 
				else 
				{
					GUI.Button (new Rect (originalWidth / 2 - (250 * 3 / 2) + (200 * (i - 4) * 1.026f), originalHeight / 1.28f, 140, 140), locked);
				}
			}
		}
		if (GUI.Button (new Rect (originalWidth / 2 + 380 , originalHeight / 2 + 250 , 75, 75),"",NextButton)) 
		{
			no = no + 1;
		}

//		for (int i=4; i <8; i++) {
//			if (i < levels)
//			{
//				if (GUI.Button (new Rect (originalWidth / 2 - (250 * 3 / 2) + (200 * (i - 4) * 1.02f), originalHeight / 2 , 150, 150), level [i], levelstyle)) 
//				{
//					#if UNITY_ANDROID
//					Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Large);
//					#endif					
////					Handheld.StartActivityIndicator();					
//					Application.LoadLevel (1 + i);					
//				}	
//			} 
//			else 
//			{
//				GUI.Button (new Rect (originalWidth / 2 - (250 * 3 / 2) + (200 * (i - 4) * 1.026f), originalHeight / 2 , 150, 150), locked, levelstyle);
//			}
//		}

//		for (int i=8; i <12; i++) {
//			if (i < levels)
//			{
//				if (GUI.Button (new Rect (originalWidth / 2 - (250 * 3 / 2) + (200 * (i - 8) * 1.02f), originalHeight / 2 + 150, 150, 150), level [i], levelstyle)) 
//				{
//					#if UNITY_ANDROID
//					Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Large);
//					#endif					
////					Handheld.StartActivityIndicator();					
//					Application.LoadLevel (1 + i);					
//				}	
//			} 
//			else 
//			{			
//				GUI.Button (new Rect (originalWidth / 2 - (250 * 3 / 2) + (200 * (i - 8) * 1.026f), originalHeight / 2 + 150 , 150, 150), locked, levelstyle);
//			}
//		}
//		
		
		if (GUI.Button (new Rect (originalWidth/4 - 185, originalHeight/3 - 20, 90, 90), "" , homestyle)) 
		{
			Application.LoadLevel("Menu");	
		}
		
		GUI.matrix = svMat;					
		}
}

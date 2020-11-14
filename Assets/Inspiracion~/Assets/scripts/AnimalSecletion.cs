using UnityEngine;
using System.Collections;

public class AnimalSecletion : MonoBehaviour {
	private float originalWidth= 1024.0f;  // define here the original resolution
	private float originalHeight= 768.0f;
	private Vector3 scale;

	public GameObject stag;
	public GameObject rabbit;
	public GameObject wolf;
//	public GameObject fox;
	public GameObject boar;
	public GameObject eagle;
	public GameObject duck;

	private int counter;
	private string counerstring;
	public Light moonlight;
//	public static bool day = true;	

	public Texture cashTexture;
	public Texture bg;

	public GUIStyle style;
	public GUIStyle huntbtn;
	public GUIStyle RightArrowStyle;
	public GUIStyle LeftArrowStyle;
	public GUIStyle gunbutton;
	public GUIStyle cashStyle;
	public GUIStyle backbutton;

	public AudioClip btnClick;
	void  Start ()
	{	
		if(PlayerPrefs.GetInt("Gun") == 0)
		{
			PlayerPrefs.SetInt("Gun",1);
		}

		counter = 0;
		counerstring = counter.ToString();	
	}		
	void  OnGUI ()
	{
		////////////////  Scaling Code  ///////////////	
		scale.x = Screen.width/originalWidth; // calculate hor scale
		scale.y = Screen.height/originalHeight; // calculate vert scale
		scale.z = 1;
		var svMat= GUI.matrix; 
		GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scale);	
		GUI.DrawTexture( new Rect(0 , 0 , originalWidth, originalHeight),bg);

		if(counter == 0)
		{
			stag.SetActive(true);
			rabbit.SetActive(false);	
//			fox.SetActive(false);
			wolf.SetActive(false);
			boar.SetActive(false);
			eagle.SetActive(false);
			duck.SetActive(false);

			if(GUI.Button( new Rect(originalWidth - 280,originalHeight - 80, 200, 62 ),"", huntbtn))
			{
				PlayerPrefs.SetInt("SelectedAnimal" , 0);
				StartCoroutine(waitforsound());

//				#if UNITY_IPHONE
//				Handheld.SetActivityIndicatorStyle(iOSActivityIndicatorStyle.Gray);
//				#elif UNITY_ANDROID
//				Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Small);
//				#endif
//				Handheld.StartActivityIndicator(); 	
//
//				Application.LoadLevel("LevelSelection");
			}
		}
		if(counter == 1)
		{
			stag.SetActive(false);
			rabbit.SetActive(true);	
//			fox.SetActive(false);
			wolf.SetActive(false);
			boar.SetActive(false);
			eagle.SetActive(false);
			duck.SetActive(false);

			if(GUI.Button( new Rect(originalWidth - 280,originalHeight - 80, 200, 62 ),"", huntbtn))
			{
				PlayerPrefs.SetInt("SelectedAnimal" , 1);
				StartCoroutine(waitforsound());
//				#if UNITY_IPHONE
//				Handheld.SetActivityIndicatorStyle(iOSActivityIndicatorStyle.Gray);
//				#elif UNITY_ANDROID
//				Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Small);
//				#endif
//				Handheld.StartActivityIndicator(); 	
//
//				Application.LoadLevel("LevelSelection");
			}
		}
		if(counter == 2)
		{
			stag.SetActive(false);
			rabbit.SetActive(false);			
			wolf.SetActive(true);
//			fox.SetActive(false);
			boar.SetActive(false);
			eagle.SetActive(false);
			duck.SetActive(false);
			if(GUI.Button( new Rect(originalWidth - 280,originalHeight - 80, 200, 62 ),"", huntbtn))
			{
				PlayerPrefs.SetInt("SelectedAnimal" , 2);
				StartCoroutine(waitforsound());
//				#if UNITY_IPHONE
//				Handheld.SetActivityIndicatorStyle(iOSActivityIndicatorStyle.Gray);
//				#elif UNITY_ANDROID
//				Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Small);
//				#endif
//				Handheld.StartActivityIndicator(); 	
//				Application.LoadLevel("LevelSelection");
			}			
		}
//		if(counter==3)
//		{
//			stag.SetActive(false);
//			rabbit.SetActive(false);			
//			wolf.SetActive(false);
//			fox.SetActive(true);
//			boar.SetActive(false);
//			eagle.SetActive(false);
//			duck.SetActive(false);
//			if(GUI.Button( new Rect(originalWidth - 280,originalHeight - 80, 200, 62 ),"", huntbtn))
//			{
//				PlayerPrefs.SetInt("SelectedAnimal" , 3);
//				StartCoroutine(waitforsound());
//				#if UNITY_IPHONE
//				Handheld.SetActivityIndicatorStyle(iOSActivityIndicatorStyle.Gray);
//				#elif UNITY_ANDROID
//				Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Small);
//				#endif
//				Handheld.StartActivityIndicator(); 	
//				Application.LoadLevel("LevelSelection");
//			}			
//		}	
		if(counter == 3)
		{
			stag.SetActive(false);
			rabbit.SetActive(false);			
			wolf.SetActive(false);
//			fox.SetActive(false);
			boar.SetActive(true);
			eagle.SetActive(false);
			duck.SetActive(false);

			if(GUI.Button( new Rect(originalWidth - 280,originalHeight - 80, 200, 62 ),"", huntbtn))
			{
				PlayerPrefs.SetInt("SelectedAnimal" , 3);
				StartCoroutine(waitforsound());

//				#if UNITY_IPHONE
//				Handheld.SetActivityIndicatorStyle(iOSActivityIndicatorStyle.Gray);
//				#elif UNITY_ANDROID
//				Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Small);
//				#endif
//				Handheld.StartActivityIndicator();
//				Application.LoadLevel("LevelSelection");
			}		
		}
		if(counter == 4)
		{						
			stag.SetActive(false);
			rabbit.SetActive(false);			
			wolf.SetActive(false);
//			fox.SetActive(false);
			boar.SetActive(false);
			eagle.SetActive(true);
			duck.SetActive(false);
			if(GUI.Button( new Rect(originalWidth - 280,originalHeight - 80, 200, 62 ),"", huntbtn))
			{
				PlayerPrefs.SetInt("SelectedAnimal" , 4);
				StartCoroutine(waitforsound());

//				#if UNITY_IPHONE
//				Handheld.SetActivityIndicatorStyle(iOSActivityIndicatorStyle.Gray);
//				#elif UNITY_ANDROID
//				Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Small);
//				#endif
//				Handheld.StartActivityIndicator(); 	
//
//				Application.LoadLevel("LevelSelection");
			}		
		}	
		if(counter == 5)
		{			
			stag.SetActive(false);
			rabbit.SetActive(false);			
			wolf.SetActive(false);
//			fox.SetActive(false);
			boar.SetActive(false);
			eagle.SetActive(false);
			duck.SetActive(true);			
			if(GUI.Button( new Rect(originalWidth - 280,originalHeight - 80, 200, 62 ),"", huntbtn))
			{
				PlayerPrefs.SetInt("SelectedAnimal" , 5);
				StartCoroutine(waitforsound());
				

			}		
		}
		if(counter < 5)
		{
			if(GUI.Button( new Rect(originalWidth - 100, originalHeight / 2 - 35.5f, 53, 71),"", RightArrowStyle))
			{
				GetComponent<AudioSource>().PlayOneShot(btnClick);

				counter = counter + 1;
				counerstring = counter.ToString();	
				Cameramove_New.target = GameObject.FindGameObjectWithTag(counerstring).transform;					
			}
		}

		if(counter > 0)
		{
			if(GUI.Button( new Rect(29, originalHeight / 2 - 35.5f, 53, 71),"" , LeftArrowStyle))
			{
				GetComponent<AudioSource>().PlayOneShot(btnClick);

				counter = counter - 1;
				counerstring = counter.ToString();
				Cameramove_New.target = GameObject.FindGameObjectWithTag(counerstring).transform;
			}
		}	
		if(GUI.Button( new Rect(30,originalHeight - 80,196,62),"", backbutton))
		{
			GetComponent<AudioSource>().PlayOneShot(btnClick);

			Application.LoadLevel("Newmenu");				
		}		
		GUI.matrix = svMat;
	}	
	IEnumerator  waitforsound ()
	{
		GetComponent<AudioSource>().PlayOneShot(btnClick);

		yield return new WaitForSeconds(0.5f); 

		#if UNITY_IPHONE
		Handheld.SetActivityIndicatorStyle(iOSActivityIndicatorStyle.Gray);
		#elif UNITY_ANDROID
		Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Small);
		#endif
		Handheld.StartActivityIndicator(); 	
		
		Application.LoadLevel("LevelSelection");
	}	
}

using UnityEngine;
using System.Collections;
[RequireComponent(typeof(FPSController))]
public class FPSInputController : MonoBehaviour
{
	public float originalWidth = 1024.0f;
	public float originalHeight = 768.0f;
	public Vector3 scale;
	private GunHanddle gunHanddle;
	private FPSController FPSmotor;
	private TouchScreenVal touchMove;
	private TouchScreenVal touchAim;
	private TouchScreenVal touchShoot;
	private TouchScreenVal touchZoom;
	public GUITexture btn_GUITexture;
	public Texture[] btn_Textures;
	public GUIStyle zoomButton;
	public GUIStyle shootstyle;
	public static bool firestatus = false;

	public static int firecount = 0;

	public GUIStyle handMark;
	public GUIStyle zoomMark;
	public GUIStyle shootMark;
	public GUIStyle textstyle;

	private float handMovementHandle = 0;
	private float zoomMovementHandle = 0;
	private float shootMovementHandle = 0;
	public static float movingTime = 0;

	void Start()
	{
		firecount = 0;

		Application.targetFrameRate = 60;
		handMovementHandle = 0;
		zoomMovementHandle = 0;
		shootMovementHandle = 0;
		firestatus = false;
		#if !UNITY_EDITOR && !UNITY_WEBPLAYER && !UNITY_STANDALONE_WIN && !UNITY_STANDALONE_OSX
		// For mobile devices
		touchMove = new TouchScreenVal (new Rect (0, 0, Screen.width / 2, Screen.height));
		touchAim = new TouchScreenVal(new Rect(Screen.width/2,0,Screen.width,Screen.height));
		touchShoot = new TouchScreenVal(new Rect(Screen.width - 200,Screen.height - 200,200,200));
		touchZoom = new TouchScreenVal(new Rect(Screen.width - 400,Screen.height - 200,200,200));
		#endif		
	}
	void Awake ()
	{
		FPSmotor = GetComponent<FPSController> ();		
		gunHanddle = GetComponent<GunHanddle> (); 
	}	
	void Update ()
	{
		if(GUI_Controller.gameover)
		{
			btn_GUITexture.enabled = false;
		}
		if(!GUI_Controller.gameover)
		{
			if(Input.touchCount <= 0)
			{
				btn_GUITexture.enabled = true;
			}
			if(Input.touchCount>0)
			{
				foreach(Touch touch in Input.touches)
				{
					if(touch.phase ==TouchPhase.Began &&btn_GUITexture.HitTest(touch.position))
					{
						if(!GUI_Controller.missionfailed&&!GUI_Controller.missionsuccess&&!GUI_Controller.pause )
						{
							btn_GUITexture.texture=btn_Textures[1];
						}
					}				
					if(touch.phase==TouchPhase.Ended)
					{
						if(!GUI_Controller.missionfailed&&!GUI_Controller.missionsuccess&&!GUI_Controller.pause )
						{
							btn_GUITexture.texture=btn_Textures[0];						
						}
					}				
					if(btn_GUITexture.HitTest(touch.position))
					{
						if(!GUI_Controller.missionfailed&&!GUI_Controller.missionsuccess&&!GUI_Controller.pause )
						{
							gunHanddle.Shoot(); 						
							firestatus = true;
							PlayerPrefs.SetInt("Shoot", 1);
						}					
					}	

					if (touch.phase == TouchPhase.Moved) //add the touches to list as the swipe is being made
					{   
						movingTime++;
						if(movingTime >= 25){
							PlayerPrefs.SetInt("Aim" , 1);
						}
					}
				}
			}
			// Get the input vector from kayboard or analog stick
			#if UNITY_EDITOR || UNITY_WEBPLAYER || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX		
			FPSmotor.Aim(new Vector2(Input.GetAxis("Mouse X"),Input.GetAxis("Mouse Y")));
			FPSmotor.Move (new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical")));
			FPSmotor.Jump (Input.GetButton ("Jump"));
			if(Input.GetKey(KeyCode.LeftShift)){
				FPSmotor.Boost(1.4f);	
			}
			FPSmotor.Holdbreath(1);			
			if(Input.GetKey(KeyCode.LeftShift)){
				FPSmotor.Holdbreath(0);	
			}
			if(Input.GetButton("Fire1")){
				gunHanddle.Shoot();	
				firestatus = true;
			}
			if(Input.GetButtonDown("Fire2")){
				gunHanddle.Zoom();	
			}
			if (Input.GetAxis("Mouse ScrollWheel") < 0){
				gunHanddle.ZoomAdjust(-1);	
			}
			if (Input.GetAxis("Mouse ScrollWheel") > 0){
				gunHanddle.ZoomAdjust(1);	
			}
			if(Input.GetKeyDown(KeyCode.R)){
				gunHanddle.Reload();
			}
			if(Input.GetKeyDown(KeyCode.Q)){
				gunHanddle.SwitchGun();
			}
			// For Mobile Devices
			#else
			Vector2 aimdir = touchMove.OnDragDirection(true);
			FPSmotor.Aim(aimdir);
			Vector2 touchdir = touchMove.OnTouchDirection (false);
		//	FPSmotor.Move (new Vector3 (touchdir.x, 0, touchdir.y));
		//	FPSmotor.Jump (Input.GetButton ("Jump"));
		/*	if(touchShoot.OnTouchPress()){
				gunHanddle.Shoot();	
			}
			if(touchZoom.OnTouchPress()){
				gunHanddle.Zoom();
			}*/
			
			#endif
		}
	}
	void OnGUI()
	{
		scale.x = Screen.width/originalWidth; // calculate hor scale
		scale.y = Screen.height/originalHeight; // calculate vert scale
		scale.z = 1.0f;
		var svMat= GUI.matrix; 
		GUI.matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity,scale);
		if(!GUI_Controller.gameover )
		{
//			if(Application.loadedLevelName == "Level1")
//			{
//				if(PlayerPrefs.GetInt("Aim") == 0)
//				{
//					if(handMovementHandle <= 400)
//					{						
//						handMovementHandle = handMovementHandle + 1.5f;						
//						GUI.Button(new Rect((320 + handMovementHandle)/2,190,185,260),"" ,handMark);
//						GUI.Label(new Rect(originalWidth/2 - 250, originalHeight/2 + 50, 400, 100),"Tap here",textstyle);
//					}
//					else
//					{
//						handMovementHandle = 0;
//					}
//				}				
//				else if(PlayerPrefs.GetInt("Zoom") == 0)
//				{
//					if(zoomMovementHandle < 80)
//					{
//						zoomMovementHandle = zoomMovementHandle + 0.8f;
//						GUI.Button(new Rect(200-zoomMovementHandle,590,163,108),"" ,zoomMark);
//						GUI.Label(new Rect(originalWidth/2 - 350, originalHeight/2 + 170, 400, 100),"Zoom",textstyle);
//					}
//					else
//					{
//						zoomMovementHandle = 0;
//					}
//				}				
//				else if(PlayerPrefs.GetInt("Shoot") == 0)
//				{
//					if(shootMovementHandle <80)
//					{
//						shootMovementHandle = shootMovementHandle + 0.8f;
//						GUI.Button(new Rect(originalWidth - 400+ shootMovementHandle,590,163,108),"" ,shootMark);
//						GUI.Label(new Rect(originalWidth - 250, originalHeight/2 + 170, 400, 100),"Shoot",textstyle);
//					}
//					else
//					{
//						shootMovementHandle = 0;
//					}
//				}
//			}

			GUI.Button(new Rect(originalWidth - 141, originalHeight - 171, 120, 140),"", shootstyle);
			if(GUI.Button(new Rect(30,600,120,140),"",zoomButton))
			{
				gunHanddle.Zoom();
				gunHanddle.ZoomAdjust(1); 
				PlayerPrefs.SetInt("Zoom", 1);
			}
		}
		GUI.matrix = svMat;
	}
}

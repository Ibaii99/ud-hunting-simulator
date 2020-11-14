using UnityEngine;
using System.Collections;
public class GUI_Controller : MonoBehaviour {
	private float originalWidth = 1024.0f;
	private float originalHeight = 728.0f;
	private Vector3 scale;

	public AudioClip btnaudio;
	public GameObject timeraudio;
	public static bool timerstop = false;
	public static string hint;
	public static int Reward;
	public static bool pause;
	public static bool resume;
	public static bool missionfailed;
	public static bool missionsuccess;
	public static bool gameover = true;
	public static bool adstatus;

	public GUIStyle upgradebtn;

	public GUIStyle empty;
	public GUIStyle coinstyle;
	public GUIStyle rewardstyle;
	public GUIStyle pausebtn;
	public GUIStyle homestyle;
	public GUIStyle resumestyle;
	public GUIStyle retrystyle;
	public GUIStyle nextstyle;
	public GUIStyle startstyle;
	public GUIStyle textstyle;
	public GUIStyle Timerstyle;
	public GUIStyle countstyle;

	public Texture gameoverTexture;
	public Texture pausedTexture ;
	public Texture pausedtext ;
	public Texture completedtext ;
	public Texture failedtext ;
	public Texture hintbg;
	public Texture counterbg;
	public Texture healthbg;
	public Texture Startbg;
		public Texture zeeshan;

	public Texture upgradeweapongtexture;
	public bool upgradeshow = false;

	private bool start = true;
	private int savedlevel = 1;
	private int level;
	private int earn = 0;
	private int a;
	private int timeCount;
	public static int time_Limit;
	private int bonus = 0;
	private int total = 0;
	public AudioClip completesound;
	public AudioClip failedsound;
	public static int adcount = 0;

	private int headbonus = 0;
	private int otherbonus = 0;
		private int zeeshanpause;
		private int zeeshanover;
		private int zeeshanresume;

	private bool hidestart = false;
	void Awake()
	{
		hidestart = false;
		upgradeshow = true;
		headbonus = 0;
		otherbonus = 0;

		timerstop = false;
		start = true; // changed for testing
		gameover = true;
		Time.timeScale = 1;
		adstatus = true;
		pause = false; // changed for testing
		resume = true;
		bonus = 0;
		total = 0;
		missionfailed = false;
		missionsuccess = false;
//		HeyzapAds.start("bf7baac3ebf3c4529c7f1ff26f20b8f1", HeyzapAds.FLAG_NO_OPTIONS);
//		GoogleMobileAdsDemoScript.RequestInterstitial();

		if(PlayerPrefs.GetInt("AdFree") != 1)
		{

//			GoogleMobileAdsDemoScript.RequestBanner ();
		}
	}
	void Start()
	{
				zeeshanpause = 0;
				zeeshanover = 0;
				zeeshanresume = 0;
//		HeyzapAds.start("bf7baac3ebf3c4529c7f1ff26f20b8f1", HeyzapAds.FLAG_NO_OPTIONS);
//		GoogleMobileAdsDemoScript.RequestInterstitial();

		if(PlayerPrefs.GetInt("AdFree") != 1)
		{
//			GoogleMobileAdsDemoScript.bannerView.Show ();
//			HeyzapAds.start("bf7baac3ebf3c4529c7f1ff26f20b8f1", HeyzapAds.FLAG_NO_OPTIONS);
//			GoogleMobileAdsDemoScript.RequestInterstitial();
		}
		earn = 0;
	}

	void Update()
	{
				
		if(start)
		{
			a=(int)Time.time;
			return;
		}
		else
		{
			if(!gameover)
			{
				if(!timerstop)
				{
					timeCount=(int)Time.time-a;
					timeCount=time_Limit-timeCount;
				}
			}
		}
		if(timeCount <= 0)
		{
			missionfailed = true;
		}
		if(PlayerPrefs.GetInt("FX") == 1)
		{
			if(!pause && !gameover)
			{
				if(timeCount < 5 && timeCount >= 0)
				{
					timeraudio.SetActive(true);
				}
				else
				{
					timeraudio.SetActive(false);
				}
			}
			else
			{
				timeraudio.SetActive(false);
			}
		}
	}
	void waittoshow()
	{
		FPSInputController.firecount = 0;
	}
	void overmethod()
	{
		start = false;
		gameover = false;
	}
	void OnGUI()
	{
		scale.x = Screen.width/originalWidth; // calculate hor scale
		scale.y = Screen.height/originalHeight; // calculate vert scale
		scale.z = 1.0f;
		var svMat= GUI.matrix; 
		GUI.matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity,scale);

		if(start)
		{
			if(!hidestart)
			{
	//			GUI.DrawTexture(new Rect(0, originalHeight - 124, originalWidth, 124), hintbg);
				GUI.DrawTexture(new Rect(0, originalHeight /2 - 275, 500, 550), Startbg);
	//			GUI.Label(new Rect(27, originalHeight - 130 , 600, 80), hint, textstyle);

				GUI.Label(new Rect(15, originalHeight / 2 - 120, 600, 80), hint, textstyle);
				GUI.Label(new Rect(15, originalHeight / 2 - 30 , 600, 80), "Upgrade your weapon for better\nperformance.", textstyle);
				if(GUI.Button(new Rect(100, originalHeight - 180, 242, 64 ), "", startstyle))
				{
					Invoke("overmethod" , 0.5f);
					hidestart = true;
	//				gameover = false;
				}
			}
		}
		if(!start)
		{
			GUI.DrawTexture (new Rect (10, 100, 236, 170),counterbg);
			GUI.DrawTexture (new Rect (originalWidth / 2 + 170, 100, 236, 96),healthbg);
			GUI.Label(new Rect(130, 115, 60, 60), timeCount.ToString(), Timerstyle);

			GUI.Label(new Rect(90, 195, 60, 60), PlayerHealth.playerhealth.ToString()+ " / 100" , Timerstyle);

			int totalkilled = DragonCounter.killedanimals + DragonCounter.bodyshoots + DragonCounter.headshoots;

			GUI.Label(new Rect(originalWidth / 2 + 280, 120, 50, 60), totalkilled.ToString() , countstyle);
			GUI.Label(new Rect(originalWidth / 2 + 310, 120, 20, 60), "/", countstyle);
			GUI.Label(new Rect(originalWidth / 2 + 340, 120, 50, 60), DragonCounter.totalanimals.ToString(), countstyle);

			if(resume)
			{
				if(missionfailed == false && missionsuccess == false)
				{
					if(GUI.Button(new Rect(originalWidth - 120, 100 , 108, 96),"", pausebtn))
					{
//						GoogleMobileAdsDemoScript.bannerView.Hide ();
//						if(PlayerPrefs.GetInt("AdFree") != 1)
//						{
//							HZInterstitialAd.show();
//								
						if(PlayerPrefs.GetInt("FX") == 1)
						{
							GetComponent<AudioSource>().PlayOneShot(btnaudio);
						}
						gameover = true;
						Time.timeScale = 0;
						resume = false;
						pause = true;
					}

					if(FPSInputController.firecount >= 2)
					{
						if(upgradeshow)
						{
							GUI.DrawTexture(new Rect(10 , originalHeight / 2 - 70 , 280 , 140 ), upgradeweapongtexture);
							Invoke("waittoshow", 2);
						}
					}
				}
			}
			if(pause)
			{

				GUI.DrawTexture(new Rect(0, 0, originalWidth, originalHeight), pausedTexture);
								GUI.DrawTexture(new Rect( originalWidth/2-478/2,  260 , 478 , 84), zeeshan);
				if(GUI.Button(new Rect( 40, originalHeight - 270 , 200, 64),"", resumestyle))
				{
										Debug.Log ("resumehorha h ");

										zeeshanpause = 0;
					if(PlayerPrefs.GetInt("AdFree") != 1)
					{
//						GoogleMobileAdsDemoScript.bannerView.Show ();
					}
					if(PlayerPrefs.GetInt("FX") == 1)
					{
						GetComponent<AudioSource>().PlayOneShot(btnaudio);
					}
					gameover = false;
					Time.timeScale = 1;
					resume = true;
					pause = false;
				}
				if(GUI.Button(new Rect( originalWidth / 2 - 100, originalHeight - 270  , 200, 64),"", retrystyle))
				{
					if(PlayerPrefs.GetInt("FX") == 1)
					{
						GetComponent<AudioSource>().PlayOneShot(btnaudio);
					}
					#if UNITY_ANDROID
					Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Small);
					#endif
					Handheld.StartActivityIndicator();

					Application.LoadLevel(Application.loadedLevel);
				}
				if(GUI.Button(new Rect(originalWidth - 240, originalHeight - 270 , 200, 64), "", homestyle))
				{
					if(PlayerPrefs.GetInt("FX") == 1)
					{
						GetComponent<AudioSource>().PlayOneShot(btnaudio);
					}
					#if UNITY_ANDROID
					Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Small);
					#endif
					Handheld.StartActivityIndicator();
					MenuScript.gamestart = false;
					Application.LoadLevel("Newmenu");
				}
								zeeshanpause = zeeshanpause + 1;
								if (zeeshanpause == 1||zeeshanpause == 2) {
										GameObject.Find ("Admob").GetComponent<admobdemo> ().ShowInterstitial ();
								}
			}
			if(missionsuccess)
			{
				gameover = true;
				missionfailed = false;
				if(adstatus)
				{
					if (PlayerPrefs.GetInt("FX")==1) 
					{
						GetComponent<AudioSource>().PlayOneShot(completesound);
					}

//					GoogleMobileAdsDemoScript.ShowInterstitial();


					headbonus = DragonCounter.headshoots * 50 ;
					otherbonus = (DragonCounter.bodyshoots * 25) + (DragonCounter.killedanimals * 25) ;
//					int otherbonus = DragonCounter.killedanimals * 25;


					int enemyreward  = headbonus + otherbonus;
					bonus = timeCount * 10;
//					total = Reward + bonus ;
					total = enemyreward + bonus ;
					earn = total + Coins.earning;
					earnings(earn);
					level = Application.loadedLevel + 1;

					//Scene 1 Data
					if(Application.loadedLevelName == "Level1")
					{
						//wolf
						if(PlayerPrefs.GetInt("Wolflevel3") == 1)
						{
							int WolfLevelCompleted = PlayerPrefs.GetInt("WolfLevelCompleted");
							if(WolfLevelCompleted < 4)
							{
								PlayerPrefs.SetInt("WolfLevelCompleted" , 4);
							}
						}
						if(PlayerPrefs.GetInt("Wolflevel4") == 1)
						{
							int WolfLevelCompleted = PlayerPrefs.GetInt("WolfLevelCompleted");
							if(WolfLevelCompleted < 5)
							{
								PlayerPrefs.SetInt("WolfLevelCompleted" , 5);
							}
						}
						if(PlayerPrefs.GetInt("Wolflevel6") == 1)
						{
							int WolfLevelCompleted = PlayerPrefs.GetInt("WolfLevelCompleted");
							if(WolfLevelCompleted < 7)
							{
								PlayerPrefs.SetInt("WolfLevelCompleted" , 7);
							}
						}
						if(PlayerPrefs.GetInt("Wolflevel8") == 1)
						{
							int WolfLevelCompleted = PlayerPrefs.GetInt("WolfLevelCompleted");
							if(WolfLevelCompleted < 9)
							{
								PlayerPrefs.SetInt("WolfLevelCompleted" , 9);
							}
						}

						//boar
						if(PlayerPrefs.GetInt("Boarlevel3") == 1)
						{
							int boarcompletedlevel = PlayerPrefs.GetInt("BoarLevelCompleted");
							if(boarcompletedlevel < 4)
							{
								PlayerPrefs.SetInt("BoarLevelCompleted" , 4);
							}
						}
						if(PlayerPrefs.GetInt("Boarlevel5") == 1)
						{
							int boarcompletedlevel = PlayerPrefs.GetInt("BoarLevelCompleted");
							if(boarcompletedlevel < 6)
							{
								PlayerPrefs.SetInt("BoarLevelCompleted" , 6);
							}
						}
						if(PlayerPrefs.GetInt("Boarlevel6") == 1)
						{
							int boarcompletedlevel = PlayerPrefs.GetInt("BoarLevelCompleted");
							if(boarcompletedlevel < 7)
							{
								PlayerPrefs.SetInt("BoarLevelCompleted" , 7);
							}
						}
						if(PlayerPrefs.GetInt("Boarlevel7") == 1)
						{
							int boarcompletedlevel = PlayerPrefs.GetInt("BoarLevelCompleted");
							if(boarcompletedlevel < 8)
							{
								PlayerPrefs.SetInt("BoarLevelCompleted" , 8);
							}
						}
					}
					//Scene 2 Data
					if(Application.loadedLevelName == "Level2")
					{
						//Rabbit completion
						if(PlayerPrefs.GetInt("RabbitLevel3") == 1)
						{
							int RabbitLevelCompleted = PlayerPrefs.GetInt("RabbitLevelCompleted");
							if(RabbitLevelCompleted < 4)
							{
								PlayerPrefs.SetInt("RabbitLevelCompleted" , 4);
							}
						}
						if(PlayerPrefs.GetInt("RabbitLevel5") == 1)
						{
							int RabbitLevelCompleted = PlayerPrefs.GetInt("RabbitLevelCompleted");
							if(RabbitLevelCompleted < 6)
							{
								PlayerPrefs.SetInt("RabbitLevelCompleted" , 6);
							}
						}
						if(PlayerPrefs.GetInt("RabbitLevel8") == 1)
						{
							int RabbitLevelCompleted = PlayerPrefs.GetInt("RabbitLevelCompleted");
							if(RabbitLevelCompleted < 9)
							{
								PlayerPrefs.SetInt("RabbitLevelCompleted" , 9);
							}
						}

						//Eagle Completion
						if(PlayerPrefs.GetInt("Eaglelevel5") == 1)
						{
							int EagleLevelCompleted = PlayerPrefs.GetInt("EagleLevelCompleted");
							if(EagleLevelCompleted < 6)
							{
								PlayerPrefs.SetInt("EagleLevelCompleted" , 6);
							}
						}
						if(PlayerPrefs.GetInt("Eaglelevel6") == 1)
						{
							int EagleLevelCompleted = PlayerPrefs.GetInt("EagleLevelCompleted");
							if(EagleLevelCompleted < 7)
							{
								PlayerPrefs.SetInt("EagleLevelCompleted" , 7);
							}
						}
						if(PlayerPrefs.GetInt("Eaglelevel8") == 1)
						{
							int EagleLevelCompleted = PlayerPrefs.GetInt("EagleLevelCompleted");
							if(EagleLevelCompleted < 9)
							{
								PlayerPrefs.SetInt("EagleLevelCompleted" , 9);
							}
						}
					}
					//Scene 3 Data
					if(Application.loadedLevelName == "Level3")
					{
						//Stag Night

						if(PlayerPrefs.GetInt("Staglevel2") == 1)
						{					
							int completedlevels = PlayerPrefs.GetInt("StagLevelCompleted");
							if(completedlevels < 3)
							{
								PlayerPrefs.SetInt("StagLevelCompleted" , 3);
							}
						}

					
						if(PlayerPrefs.GetInt("Staglevel5") == 1)
						{
							int completedlevels = PlayerPrefs.GetInt("StagLevelCompleted");
							if(completedlevels < 6)
							{
								PlayerPrefs.SetInt("StagLevelCompleted" , 6);
							}
						}
						if(PlayerPrefs.GetInt("Staglevel8") == 1)
						{
							int completedlevels = PlayerPrefs.GetInt("StagLevelCompleted");
							if(completedlevels < 9)
							{
								PlayerPrefs.SetInt("StagLevelCompleted" , 9);
							}
						}
						//Duck Level
						if(PlayerPrefs.GetInt("Ducklevel1") == 1)
						{
							int completedlevels = PlayerPrefs.GetInt("DuckLevelCompleted");
							if(completedlevels < 2)
							{
								PlayerPrefs.SetInt("DuckLevelCompleted" , 2);
							}
						}
						if(PlayerPrefs.GetInt("Ducklevel2") == 1)
						{
							int completedlevels = PlayerPrefs.GetInt("DuckLevelCompleted");
							if(completedlevels < 3)
							{
								PlayerPrefs.SetInt("DuckLevelCompleted" , 3);
							}
						}
						if(PlayerPrefs.GetInt("Ducklevel3") == 1)
						{
							int completedlevels = PlayerPrefs.GetInt("DuckLevelCompleted");
							if(completedlevels < 4)
							{
								PlayerPrefs.SetInt("DuckLevelCompleted" , 4);
							}
						}
						if(PlayerPrefs.GetInt("Ducklevel4") == 1)
						{
							int completedlevels = PlayerPrefs.GetInt("DuckLevelCompleted");
							if(completedlevels < 5)
							{
								PlayerPrefs.SetInt("DuckLevelCompleted" , 5);
							}
						}
						if(PlayerPrefs.GetInt("Ducklevel5") == 1)
						{
							int completedlevels = PlayerPrefs.GetInt("DuckLevelCompleted");
							if(completedlevels < 6)
							{
								PlayerPrefs.SetInt("DuckLevelCompleted" , 6);
							}
						}
						if(PlayerPrefs.GetInt("Ducklevel6") == 1)
						{
							int completedlevels = PlayerPrefs.GetInt("DuckLevelCompleted");
							if(completedlevels < 7)
							{
								PlayerPrefs.SetInt("DuckLevelCompleted" , 7);
							}
						}
						if(PlayerPrefs.GetInt("Ducklevel7") == 1)
						{
							int completedlevels = PlayerPrefs.GetInt("DuckLevelCompleted");
							if(completedlevels < 8)
							{
								PlayerPrefs.SetInt("DuckLevelCompleted" , 8);
							}
						}
						if(PlayerPrefs.GetInt("Ducklevel8") == 1)
						{
							int completedlevels = PlayerPrefs.GetInt("DuckLevelCompleted");
							if(completedlevels < 9)
							{
								PlayerPrefs.SetInt("DuckLevelCompleted" , 9);
							}
						}
					}

					//Scene 4 Data
					if(Application.loadedLevelName == "Level4")
					{	
						// wolf
						if(PlayerPrefs.GetInt("Wolflevel1") == 1)
						{
							int WolfLevelCompleted = PlayerPrefs.GetInt("WolfLevelCompleted");
							if(WolfLevelCompleted < 2)
							{
								PlayerPrefs.SetInt("WolfLevelCompleted" , 2);
							}
						}
						if(PlayerPrefs.GetInt("Wolflevel2") == 1)
						{
							int WolfLevelCompleted = PlayerPrefs.GetInt("WolfLevelCompleted");
							if(WolfLevelCompleted < 3)
							{
								PlayerPrefs.SetInt("WolfLevelCompleted" , 3);
							}
						}

						//boar
						if(PlayerPrefs.GetInt("Boarlevel1") == 1)
						{
							int boarcompletedlevel = PlayerPrefs.GetInt("BoarLevelCompleted");
							if(boarcompletedlevel < 2)
							{
								PlayerPrefs.SetInt("BoarLevelCompleted" , 2);
							}
						}
						if(PlayerPrefs.GetInt("Boarlevel2") == 1)
						{
							int boarcompletedlevel = PlayerPrefs.GetInt("BoarLevelCompleted");
							if(boarcompletedlevel < 3)
							{
								PlayerPrefs.SetInt("BoarLevelCompleted" , 3);
							}
						}
						if(PlayerPrefs.GetInt("Boarlevel4") == 1)
						{
							int boarcompletedlevel = PlayerPrefs.GetInt("BoarLevelCompleted");
							if(boarcompletedlevel < 5)
							{
								PlayerPrefs.SetInt("BoarLevelCompleted" , 5);
							}
						}
						if(PlayerPrefs.GetInt("Boarlevel8") == 1)
						{
							int boarcompletedlevel = PlayerPrefs.GetInt("BoarLevelCompleted");
							if(boarcompletedlevel < 9)
							{
								PlayerPrefs.SetInt("BoarLevelCompleted" , 9);
							}
						}

						//Eagle Completion
						if(PlayerPrefs.GetInt("Eaglelevel1") == 1)
						{
							int EagleLevelCompleted = PlayerPrefs.GetInt("EagleLevelCompleted");
							if(EagleLevelCompleted < 2)
							{
								PlayerPrefs.SetInt("EagleLevelCompleted" , 2);
							}
						}
						if(PlayerPrefs.GetInt("Eaglelevel2") == 1)
						{
							int EagleLevelCompleted = PlayerPrefs.GetInt("EagleLevelCompleted");
							if(EagleLevelCompleted < 3)
							{
								PlayerPrefs.SetInt("EagleLevelCompleted" , 3);
							}
						}
						if(PlayerPrefs.GetInt("Eaglelevel3") == 1)
						{
							int EagleLevelCompleted = PlayerPrefs.GetInt("EagleLevelCompleted");
							if(EagleLevelCompleted < 4)
							{
								PlayerPrefs.SetInt("EagleLevelCompleted" , 4);
							}
						}
						if(PlayerPrefs.GetInt("Eaglelevel4") == 1)
						{
							int EagleLevelCompleted = PlayerPrefs.GetInt("EagleLevelCompleted");
							if(EagleLevelCompleted < 5)
							{
								PlayerPrefs.SetInt("EagleLevelCompleted" , 5);
							}
						}
						if(PlayerPrefs.GetInt("Eaglelevel7") == 1)
						{
							int EagleLevelCompleted = PlayerPrefs.GetInt("EagleLevelCompleted");
							if(EagleLevelCompleted < 8)
							{
								PlayerPrefs.SetInt("EagleLevelCompleted" , 8);
							}
						}
					}
					//Scene 5 Data
					if(Application.loadedLevelName == "Level5")
					{
						//Stag Day
						if(PlayerPrefs.GetInt("Staglevel3") == 1)
						{	
							int completedlevels = PlayerPrefs.GetInt("StagLevelCompleted");
							if(completedlevels < 4)
							{
								PlayerPrefs.SetInt("StagLevelCompleted" , 4);
							}
						}
						if(PlayerPrefs.GetInt("Staglevel4") == 1)
						{
							int completedlevels = PlayerPrefs.GetInt("StagLevelCompleted");
							if(completedlevels < 5)
							{
								PlayerPrefs.SetInt("StagLevelCompleted" , 5);
							}
						}

						if(PlayerPrefs.GetInt("Staglevel7") == 1)
						{
							int completedlevels = PlayerPrefs.GetInt("StagLevelCompleted");
							if(completedlevels < 8)
							{
								PlayerPrefs.SetInt("StagLevelCompleted" , 8);
							}

						}

						//Rabbit day
						if(PlayerPrefs.GetInt("RabbitLevel1") == 1)
						{
							int RabbitLevelCompleted = PlayerPrefs.GetInt("RabbitLevelCompleted");
							if(RabbitLevelCompleted < 2)
							{
								PlayerPrefs.SetInt("RabbitLevelCompleted" , 2);
							}
						}
						if(PlayerPrefs.GetInt("RabbitLevel2") == 1)
						{
							int RabbitLevelCompleted = PlayerPrefs.GetInt("RabbitLevelCompleted");
							if(RabbitLevelCompleted < 3)
							{
								PlayerPrefs.SetInt("RabbitLevelCompleted" , 3);
							}
						}
						if(PlayerPrefs.GetInt("RabbitLevel4") == 1)
						{
							int RabbitLevelCompleted = PlayerPrefs.GetInt("RabbitLevelCompleted");
							if(RabbitLevelCompleted < 5)
							{
								PlayerPrefs.SetInt("RabbitLevelCompleted" , 5);
							}
						}
						if(PlayerPrefs.GetInt("RabbitLevel6") == 1)
						{
							int RabbitLevelCompleted = PlayerPrefs.GetInt("RabbitLevelCompleted");
							if(RabbitLevelCompleted < 7)
							{
								PlayerPrefs.SetInt("RabbitLevelCompleted" , 7);
							}
						}
						if(PlayerPrefs.GetInt("RabbitLevel7") == 1)
						{
							int RabbitLevelCompleted = PlayerPrefs.GetInt("RabbitLevelCompleted");
							if(RabbitLevelCompleted < 8)
							{
								PlayerPrefs.SetInt("RabbitLevelCompleted" , 8);
							}
						}
					}

					//Scene 6 Data
					if(Application.loadedLevelName == "Level6")
					{
						//stag snow
						if(PlayerPrefs.GetInt("Staglevel1") == 1)
						{					
							int completedlevels = PlayerPrefs.GetInt("StagLevelCompleted");
							if(completedlevels < 2)
							{
								PlayerPrefs.SetInt("StagLevelCompleted" , 2);
							}
						}
					
						if(PlayerPrefs.GetInt("Staglevel6") == 1)
						{				
							int completedlevels = PlayerPrefs.GetInt("StagLevelCompleted");
							if(completedlevels < 7)
							{
								PlayerPrefs.SetInt("StagLevelCompleted" , 7);
							}
						}

						//wolf snow
						if(PlayerPrefs.GetInt("Wolflevel5") == 1)
						{
							int WolfLevelCompleted = PlayerPrefs.GetInt("WolfLevelCompleted");
							if(WolfLevelCompleted < 6)
							{
								PlayerPrefs.SetInt("WolfLevelCompleted" , 6);
							}
						}
						if(PlayerPrefs.GetInt("Wolflevel7") == 1)
						{
							int WolfLevelCompleted = PlayerPrefs.GetInt("WolfLevelCompleted");
							if(WolfLevelCompleted < 8)
							{
								PlayerPrefs.SetInt("WolfLevelCompleted" , 8);
							}
						}
					}

					adstatus = false ;
				}
				GUI.DrawTexture(new Rect(0, 0, originalWidth, originalHeight), gameoverTexture);


				GUI.Label(new Rect(originalWidth / 2 + 60, originalHeight / 2 - 45 ,130, 20 ), headbonus.ToString(), rewardstyle );

				GUI.Label(new Rect(originalWidth / 2 + 60, originalHeight / 2 + 10 ,130, 20 ), otherbonus.ToString(), rewardstyle );
				GUI.Label(new Rect(originalWidth / 2 + 60, originalHeight / 2 + 65 ,130, 20 ), bonus.ToString(), rewardstyle );
				GUI.Label(new Rect(originalWidth / 2 + 60, originalHeight /2 + 120  ,130, 20 ), total.ToString(), rewardstyle );
				GUI.Label(new Rect(originalWidth / 2 + 60, originalHeight /2 + 175 ,130, 20 ), earn.ToString(), rewardstyle );

				GUI.DrawTexture(new Rect(originalWidth/2 - 235.5f, originalHeight/2 - 130 , 471, 65), completedtext);
				if(GUI.Button(new Rect(40, originalHeight  - 80 , 200, 64),"", nextstyle))
				{
					if(PlayerPrefs.GetInt("FX") == 1)
					{
						GetComponent<AudioSource>().PlayOneShot(btnaudio);
					}

					#if UNITY_ANDROID
					Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Small);
					#endif
					Handheld.StartActivityIndicator();
					Application.LoadLevel("LevelSelection");
				}			
								if(GUI.Button(new Rect(originalWidth - 240, originalHeight  - 80 , 200, 64),"", retrystyle))
				{	
					if(PlayerPrefs.GetInt("FX") == 1)
					{
						GetComponent<AudioSource>().PlayOneShot(btnaudio);
					}
					#if UNITY_ANDROID
					Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Small);
					#endif
					Handheld.StartActivityIndicator();
					Application.LoadLevel(Application.loadedLevel);
				}
				if(GUI.Button(new Rect(originalWidth - 240, originalHeight  - 250 , 200, 64), "", homestyle))
				{
					if(PlayerPrefs.GetInt("FX") == 1)
					{
						GetComponent<AudioSource>().PlayOneShot(btnaudio);
					}
					#if UNITY_ANDROID
					Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Small);
					#endif
					Handheld.StartActivityIndicator();
					MenuScript.gamestart = false;
					Application.LoadLevel("Newmenu");
				}
								zeeshanresume = zeeshanresume + 1;
								if (zeeshanresume == 1 || zeeshanresume == 2) {
										GameObject.Find ("Admob").GetComponent<admobdemo> ().ShowInterstitial ();
								}
			}
			if(missionfailed)
			{
				gameover = true;
				if(adstatus)
				{
					int enemyreward  = DragonCounter.killedanimals * 50;
					bonus = timeCount * 10;
					total = enemyreward + bonus ;
					earn = total + Coins.earning;
					earnings(earn);

//					GoogleMobileAdsDemoScript.ShowInterstitial();

//					if(adcount < 1)
//					{
//						adcount = 1;
////						if(PlayerPrefs.GetInt("AdFree") != 1)
////						{
////							
////						}
//					}
//					if(adcount > 2)
//					{
//						adcount = 1;
//						if(PlayerPrefs.GetInt("AdFree") != 1)
//						{
//							GoogleMobileAdsDemoScript.ShowInterstitial();
//						}
//					}
					if (PlayerPrefs.GetInt("FX")==1) 
					{
						GetComponent<AudioSource>().PlayOneShot(failedsound);
					}
					adstatus = false ;
				}
				GUI.DrawTexture(new Rect(0, 0, originalWidth, originalHeight), gameoverTexture);

//			    GUI.Label(new Rect(originalWidth - 210, 25,158, 36 ),PlayerPrefs.GetInt ("Earnings").ToString(), coinstyle );
//				GUI.Label(new Rect(originalWidth / 2 - 390, originalHeight /2 - 110 ,400, 50 ),hint, textstyle );
//				GUI.Label(new Rect(originalWidth / 2 - 390, originalHeight /2 - 70 ,400, 50 ),"Complete in time to get more reward.", textstyle );
//				GUI.Label(new Rect(originalWidth / 2 - 390, originalHeight /2 - 30 ,400, 50 ),"Beware of attacking animals.", textstyle );

				GUI.Label(new Rect(originalWidth / 2 + 60, originalHeight / 2 - 45 ,130, 20 ), DragonCounter.killedanimals.ToString(), rewardstyle );
				GUI.Label(new Rect(originalWidth / 2 + 60, originalHeight / 2 + 10 ,130, 20 ), bonus.ToString(), rewardstyle );
				GUI.Label(new Rect(originalWidth / 2 + 60, originalHeight /2 + 65  ,130, 20 ), total.ToString(), rewardstyle );
				GUI.Label(new Rect(originalWidth / 2 + 60, originalHeight /2 + 120 ,130, 20 ), earn.ToString(), rewardstyle );


				GUI.DrawTexture(new Rect(originalWidth/2 - 185, originalHeight/2 - 130 , 370, 60), failedtext);

				if(GUI.Button(new Rect(originalWidth / 2 + 190 , originalHeight / 2 - 20, 300 , 150 ), "", upgradebtn))
				{
					if(PlayerPrefs.GetInt("FX") == 1)
					{
						GetComponent<AudioSource>().PlayOneShot(btnaudio);
					}
					adcount = adcount + 1;
					#if UNITY_ANDROID
					Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Small);
					#endif
					Handheld.StartActivityIndicator();
					Application.LoadLevel("GunSelection");
				}

				if(GUI.Button(new Rect(40, originalHeight - 80 , 200, 64),"", retrystyle))
				{	
					if(PlayerPrefs.GetInt("FX") == 1)
					{
						GetComponent<AudioSource>().PlayOneShot(btnaudio);
					}
					adcount = adcount + 1;
					#if UNITY_ANDROID
					Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Small);
					#endif
					Handheld.StartActivityIndicator();
					Application.LoadLevel(Application.loadedLevel);
				}
				if(GUI.Button(new Rect(originalWidth - 240, originalHeight - 80 , 200, 64), "", homestyle))
				{
					if(PlayerPrefs.GetInt("FX") == 1)
					{
						GetComponent<AudioSource>().PlayOneShot(btnaudio);
					}
					#if UNITY_ANDROID
					Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Small);
					#endif
					Handheld.StartActivityIndicator();
					MenuScript.gamestart = false;
					Application.LoadLevel("Newmenu");
				}

//				GameObject.Find("Admob").GetComponent<admobdemo>().ShowInterstitial();
								if (zeeshanover == 1 || zeeshanover == 2) {
										GameObject.Find("Admob").GetComponent<admobdemo>().ShowInterstitial();
								}
			}
		}
		GUI.matrix = svMat;
	}
	public void earnings(int money)
	{
		if(money > Coins.earning)
		{
			PlayerPrefs.SetInt("Earnings", money);
		}
	}
	public void CheckLevel()
	{
		if (level > savedlevel)
		{
			PlayerPrefs.SetInt("LastLevel", level);
		}
	}

}

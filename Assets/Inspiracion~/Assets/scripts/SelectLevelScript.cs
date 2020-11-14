using System;
using UnityEngine;
using System.Collections;
//using GoogleMobileAds;
//using GoogleMobileAds.Api;
//using OnePF;
using System.Collections.Generic;
//using UnityEngine.Advertisements;

public class SelectLevelScript : MonoBehaviour 
{
	//IN APP Billing Start
	const string SKU_Coin_400 = "units_package_1";
	const string SKU_Coin_800 = "units_package_2";
	const string SKU_Coin_1200 = "units_package_3";	
	const string SKU_Ads_Free = "buy_remove_ads";	
	string _label = "";
	bool _isInitialized = false;
//	Inventory _inventory = null;
	// IN APP Billing End

//	public BannerView bannerView;
	public float originalWidth = 1024.0f;
	public float originalHeight = 768.0f;
	public Vector3 scale;
	public AudioClip btnaudio;
	public GUIStyle closestyle;
	public GUIStyle menustyle;
	public GUIStyle inappstyle;
	public GUIStyle warningstyle;
	public GUIStyle Labelstyle;
	public GUIStyle playstyle;
	public GUIStyle buytyle;
	public GUIStyle headlinestyle;
	public GUIStyle coinstyle;
	public GUIStyle rewardstyle;
	public GUIStyle levelstyle1;
	public GUIStyle levelstyle2;
	public GUIStyle levelstyle3;
	public GUIStyle levelstyle4;
	public GUIStyle levelstyle5;
	public GUIStyle levelstyle6;
	public GUIStyle levelstyle7;
	public GUIStyle levelstyle8;
	public GUIStyle levelstyle9;
	public GUIStyle levelstyle10;
	public GUIStyle levelstyle11;
	public GUIStyle levelstyle12;
	public GUIStyle levelstyle13;
	public GUIStyle levelstyle14;
	public GUIStyle levelstyle15;
	public GUIStyle levelstyle16;
	public GUIStyle levelstyle17;
	public GUIStyle levelstyle18;
	public GUIStyle levelstyle19;
	public GUIStyle levelstyle20;
	public GUIStyle levelstyle21;
	public GUIStyle levelstyle22;
	public GUIStyle levelstyle23;
	public GUIStyle levelstyle24;
	public GUIStyle levelstyle25;
	public GUIStyle levelstyle26;
	public GUIStyle levelstyle27;
	public GUIStyle levelstyle28;
	public GUIStyle levelstyle29;
	public GUIStyle levelstyle30;
	public int completedlevels;
	private int levelchoose = 0;
	private bool leveldes = false;
	private bool buypopup = false;
	private int coin = 0;
	private bool coinbox = false;
	public int[] LevelTime;
	public Texture map1;
	public Texture map2;
	public Texture map3;
	public Texture map4;
	public Texture lvldestex;
	public Texture warningpopup;
	public Texture warning;
	public Texture success;
	public Texture inappbox;
	public GUIStyle get400coins;
	public GUIStyle get800coins;
	public GUIStyle get1200coins;


	void Awake()
	{
		if(PlayerPrefs.GetInt("AdFree") != 1)
		{
//			RequestBanner ();
		}


	}
	void Start () 
	{
		if(PlayerPrefs.GetInt("AdFree") != 1)
		{
//			bannerView.Show();
		}
		//PlayerPrefs.SetInt("LastLevel", 16);
		completedlevels = PlayerPrefs.GetInt("LastLevel");

		// INAPP starts
		Initialize ();
		if (!_isInitialized)
			return;
//		OpenIAB.mapSku(SKU_Coin_400, OpenIAB_Android.STORE_GOOGLE, "units_package_1");
//		OpenIAB.mapSku(SKU_Coin_800, OpenIAB_Android.STORE_GOOGLE, "units_package_2");
//		OpenIAB.mapSku(SKU_Coin_1200, OpenIAB_Android.STORE_GOOGLE, "units_package_3");
		// INAPP Ends	
		buypopup = false;
		coinbox = false;
		levelchoose = 0;
		leveldes = false;
	}
//	public void RequestBanner()
//	{
//		#if UNITY_EDITOR
//		string adUnitId = "ca-app-pub-3626912056528981/6736020555";
//		#elif UNITY_ANDROID
//		string adUnitId = "ca-app-pub-3626912056528981/6736020555";
//		#elif UNITY_IPHONE
//		string adUnitId = "INSERT_IOS_BANNER_AD_UNIT_ID_HERE";
//		#else
//		string adUnitId = "unexpected_platform";
//		#endif		
		// Create a 320x50 banner at the top of the screen.
//		bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);
		// Register for ad events.
//		bannerView.AdLoaded += HandleAdLoaded;
//		bannerView.AdFailedToLoad += HandleAdFailedToLoad;
//		bannerView.AdOpened += HandleAdOpened;
//		bannerView.AdClosing += HandleAdClosing;
//		bannerView.AdClosed += HandleAdClosed;
//		bannerView.AdLeftApplication += HandleAdLeftApplication;
		// Load a banner ad.
//		bannerView.LoadAd(createAdRequest());
//	}
	void OnGUI()
	{
		scale.x = Screen.width/originalWidth; // calculate hor scale
		scale.y = Screen.height/originalHeight; // calculate vert scale
		scale.z = 1.0f;
		var svMat= GUI.matrix; 
		GUI.matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity,scale);

		if(completedlevels <= 6)
		{
			GUI.DrawTexture (new Rect(0,0, originalWidth, originalHeight), map1);
		}
		if(completedlevels > 6 && completedlevels <= 16 )
		{
			GUI.DrawTexture (new Rect(0,0, originalWidth, originalHeight), map2);
		}
		if(completedlevels > 16  && completedlevels <= 21)
		{
			GUI.DrawTexture (new Rect(0,0, originalWidth, originalHeight), map3);
		}
		if(completedlevels > 21  )
		{
			GUI.DrawTexture (new Rect(0,0, originalWidth, originalHeight), map4);
		}




		GUI.Label(new Rect(originalWidth - 210, 25,158, 36 ),PlayerPrefs.GetInt ("Earnings").ToString(), coinstyle );
		if(!leveldes)
		{
			if(!buypopup)
			{
				coinbox = false;
				GUI.Label(new Rect(originalWidth/2 - 200, 5 , 300, 80) , "Select Level", headlinestyle);
				if(GUI.Button(new Rect(20, originalHeight / 2 - 200 , 72, 98), "", levelstyle1))
				{
					levelchoose = 1;
					leveldes = true;
				}
				if(completedlevels >= 3)
				{
					if(GUI.Button(new Rect(100, originalHeight / 2 - 120, 72, 98), "", levelstyle2))
					{
						levelchoose = 2;
						leveldes = true;
					}
				}
				if(completedlevels >= 4)
				{
					if(GUI.Button(new Rect(80, originalHeight / 2 - 20 , 72, 98), "", levelstyle3))
					{
						levelchoose = 3;
						leveldes = true;
					}
				}
				if(completedlevels >= 5)
				{
					if(GUI.Button(new Rect(originalWidth / 2  - 350, originalHeight / 2 - 200, 72, 98), "", levelstyle4))
					{
						levelchoose = 4;
						leveldes = true;
					}
				}
				if(completedlevels >= 6)
				{
					if(GUI.Button(new Rect(180, originalHeight / 2 - 20 , 72, 98), "", levelstyle5))
					{
						levelchoose = 5;
						leveldes = true;
					}
				}
				if(completedlevels >= 7)
				{
					if(GUI.Button(new Rect(originalWidth / 2  - 240, originalHeight / 2 - 110 , 72, 98), "", levelstyle6))
					{
						levelchoose = 6;
						leveldes = true;
					}
				}
				if(completedlevels >= 8)
				{
					if(GUI.Button(new Rect(originalWidth / 2 + 50, originalHeight / 2 - 195 , 72, 98), "", levelstyle7))
					{
						
						leveldes = true;
						levelchoose = 7;
					}
				}
				if(completedlevels >= 9)
				{
					if(GUI.Button(new Rect(originalWidth / 2 + 70, originalHeight / 2 - 70 , 72, 98), "", levelstyle8))
					{
						levelchoose = 8;
						leveldes = true;
					}
				}
				
				if(completedlevels >= 10)
				{
					if(GUI.Button(new Rect(originalWidth / 2 + 140, originalHeight / 2 - 130 , 72, 98), "", levelstyle9))
					{
						levelchoose = 9;
						leveldes = true;
					}
				}
				if(completedlevels >= 11)
				{
					if(GUI.Button(new Rect(originalWidth / 2 + 175, originalHeight / 2 - 230, 72, 98), "", levelstyle10))
					{
						levelchoose = 10;
						leveldes = true;
					}
				}
				if(completedlevels >= 12)
				{
					if(GUI.Button(new Rect( originalWidth / 2 + 250, originalHeight / 2 - 120 , 72, 98), "", levelstyle11))
					{
						levelchoose = 11;
						leveldes = true;
					}
				}
				if(completedlevels >= 13)
				{
					if(GUI.Button(new Rect(originalWidth / 2 + 300, originalHeight / 2 - 250 , 72, 98), "", levelstyle12))
					{
						levelchoose = 12;
						leveldes = true;
					}
				}
				if(completedlevels >= 14)
				{
					if(GUI.Button(new Rect(originalWidth / 2 + 340, originalHeight / 2 - 100  , 72, 98), "", levelstyle13))
					{
						levelchoose = 13;
						leveldes = true;
					}
				}
				if(completedlevels >= 15)
				{
					if(GUI.Button(new Rect( originalWidth / 2 + 410, originalHeight / 2 - 210, 72, 98), "", levelstyle14))
					{
						levelchoose = 14;
						leveldes = true;
					}
				}
				if(completedlevels >= 16)
				{
					if(GUI.Button(new Rect( originalWidth / 2 + 435, originalHeight / 2 - 90 , 72, 98), "", levelstyle15))
					{
						levelchoose = 15;
						leveldes = true;
					}
				}
				if(completedlevels >= 17)
				{
					if(GUI.Button(new Rect( originalWidth / 2 - 275, originalHeight / 2 - 280 , 72, 98), "", levelstyle16))
					{
						levelchoose = 16;
						leveldes = true;
					}
				}
				if(completedlevels >= 18)
				{
					if(GUI.Button(new Rect( originalWidth / 2 - 180, originalHeight / 2 - 320 , 72, 98), "", levelstyle17))
					{
						levelchoose = 17;
						leveldes = true;
					}
				}
				if(completedlevels >= 19)
				{
					if(GUI.Button(new Rect( originalWidth / 2 - 100, originalHeight / 2 - 300 , 72, 98), "", levelstyle18))
					{
						levelchoose = 18;
						leveldes = true;
					}
				}
				if(completedlevels >= 20)
				{
					if(GUI.Button(new Rect( originalWidth / 2 - 200, originalHeight / 2 - 200 , 72, 98), "", levelstyle19))
					{
						levelchoose = 19;
						leveldes = true;
					}
				}
				if(completedlevels >= 21)
				{
					if(GUI.Button(new Rect( originalWidth / 2 - 130, originalHeight / 2 - 200 , 72, 98), "", levelstyle20))
					{
						levelchoose = 20;
						leveldes = true;
					}
				}

				if(completedlevels >= 22)
				{
					if(GUI.Button(new Rect( originalWidth / 2 - 270, originalHeight / 2 + 45 , 67, 93), "", levelstyle21))
					{
						levelchoose = 21;
						leveldes = true;
					}
				}

				if(completedlevels >= 23)
				{
					if(GUI.Button(new Rect( originalWidth / 2 - 300, originalHeight / 2 + 140 , 67, 93), "", levelstyle22))
					{
						levelchoose = 22;
						leveldes = true;
					}
				}
				if(completedlevels >= 24)
				{
					if(GUI.Button(new Rect( originalWidth / 2 - 220, originalHeight / 2 + 110 , 67, 93), "", levelstyle23))
					{
						levelchoose = 23;
						leveldes = true;
					}
				}
				if(completedlevels >= 25)
				{
					if(GUI.Button(new Rect( originalWidth / 2 - 150, originalHeight / 2 + 140 , 67, 93), "", levelstyle24))
					{
						levelchoose = 24;
						leveldes = true;
					}
				}
				if(completedlevels >= 26)
				{
					if(GUI.Button(new Rect( originalWidth / 2 - 190, originalHeight / 2 + 230 , 67, 93), "", levelstyle25))
					{
						levelchoose = 25;
						leveldes = true;
					}
				}
//				if(completedlevels >= 27)
//				{
//					if(GUI.Button(new Rect( originalWidth / 2 - 270, originalHeight / 2 + 250 , 67, 93), "", levelstyle26))
//					{
//						levelchoose = 26;
//						leveldes = true;
//					}
//				}

				if(GUI.Button (new Rect ( 5,5, 91, 78), "", menustyle))
				{
//					bannerView.Hide();
					if(PlayerPrefs.GetInt("FX") == 1)
					{ 
						StartCoroutine(waitformenusound());
					}
					else
					{
						#if UNITY_ANDROID
						Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Large);
						#endif
						Handheld.StartActivityIndicator();
						Application.LoadLevel("Newmenu");
					}
				}
			}
		}
		if(!coinbox)
		{
			if(leveldes)
			{
				//GUI.Box(new Rect(50, 50, 900, 668),"");
				GUI.DrawTexture(new Rect(0,0, originalWidth, originalHeight),lvldestex);
				GUI.Label(new Rect(originalWidth/2 - 220, originalHeight / 2 - 180 , 300, 100),"Level " + levelchoose, headlinestyle);		
				if(GUI.Button (new Rect ( 5,5, 91, 78), "", menustyle))
				{
					leveldes = false;
				}

				if(levelchoose == 1)
				{
					GUI.Label(new Rect(80, originalHeight / 2 - 80 , 600, 100), "Hunt One Bear by Sniper Gun.", Labelstyle);
					GUI.Label(new Rect(80, originalHeight / 2 - 40 , 740, 100), "Complete in time to get more reward.", Labelstyle);
					GUI.Label(new Rect(80, originalHeight / 2 , 600, 100), "Reward : 300.", Labelstyle);

					GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 170 ,130, 20 ),"1", rewardstyle );
					GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 137 ,130, 20 ),"$ 300", rewardstyle );
					GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 102 ,130, 20 ),"00 : " + LevelTime[0] , rewardstyle );


					if(GUI.Button(new Rect(originalWidth - 260, originalHeight - 150 , 220, 70), "" , playstyle))
					//if(GUI.Button(new Rect(originalWidth - 260, originalHeight - 150 , 220, 70), " 5000", buytyle))
					{
//						bannerView.Hide();
						#if UNITY_ANDROID
						Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Large);
						#endif
						Handheld.StartActivityIndicator();

						PlayerPrefs.SetInt("WolflevelNight", 0);
						PlayerPrefs.SetInt("BearLevel1", 1);
						PlayerPrefs.SetInt("Bear_NightLevel1", 0);
						PlayerPrefs.SetInt("Lion_NightLevel1", 0);
						GUI_Controller.adcount = 0;

						GUI_Controller.time_Limit = LevelTime[0];
						GUI_Controller.Reward = 300;
						GUI_Controller.hint = "Hunt One Bear by sniper gun.";
						DragonCounter.totalanimals = 1;
						Application.LoadLevel("Level1");

					}
				}
				if(levelchoose == 2)
				{
					if(!coinbox)
					{
						GUI.Label(new Rect(80, originalHeight / 2 - 80 , 600, 100), "Hunt One Rabbit by Sniper Gun.", Labelstyle);
						GUI.Label(new Rect(80, originalHeight / 2 - 40 , 740, 100), "Complete in time to get more reward.", Labelstyle);
						GUI.Label(new Rect(80, originalHeight / 2 , 600, 100), "Reward : 400.", Labelstyle);

						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 170 ,130, 20 ),"1", rewardstyle );
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 137 ,130, 20 ),"$ 400", rewardstyle );
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 102 ,130, 20 ),"00 : " + LevelTime[1] , rewardstyle );

						if(PlayerPrefs.GetInt("Level2") == 1)
						{
							if(GUI.Button(new Rect(originalWidth - 260, originalHeight - 150 , 220, 70), "" , playstyle))
							{
//								bannerView.Hide();
								#if UNITY_ANDROID
								Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Large);
								#endif
								Handheld.StartActivityIndicator();
								PlayerPrefs.SetInt ("Staglevel1", 0);
								PlayerPrefs.SetInt ("Staglevel2", 0);
								PlayerPrefs.SetInt ("Staglevel3", 0);
								PlayerPrefs.SetInt ("Staglevel4", 0);
								PlayerPrefs.SetInt ("Lionlevel1", 0);
								PlayerPrefs.SetInt ("Lionlevel2", 0);
								PlayerPrefs.SetInt ("RabbitLevel1", 1);
								GUI_Controller.adcount = 0;
								DragonCounter.totalanimals = 1;
								GUI_Controller.time_Limit = LevelTime[1];
								GUI_Controller.Reward = 400;
								GUI_Controller.hint = "Hunt One Rabbit by sniper gun.";
								Application.LoadLevel("Level8");
							}
						}
						else
						{
							if(GUI.Button(new Rect(originalWidth - 260, originalHeight - 150 , 220, 70), " 1000", buytyle))
							{
								coin = PlayerPrefs.GetInt ("Earnings");
								if(coin > 1000)
								{
									coin = PlayerPrefs.GetInt ("Earnings") - 1000;
									PlayerPrefs.SetInt ("Earnings", coin);
									buypopup = true;
									PlayerPrefs.SetInt("Level2", 1);
								}
								else
								{
									coinbox = true;
								}
							}
						}
					}
				}

				if(levelchoose == 3)
				{
					if(!coinbox)
					{
						GUI.Label(new Rect(80, originalHeight / 2 - 80 , 600, 100), "Hunt One Flyying Duck by Sniper Gun.", Labelstyle);
						GUI.Label(new Rect(80, originalHeight / 2 - 40 , 600, 100), "Complete in time to get more reward.", Labelstyle);
						GUI.Label(new Rect(80, originalHeight / 2 , 600, 100), "Reward : 600.", Labelstyle);

						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 170 ,130, 20 ),"1", rewardstyle );
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 137 ,130, 20 ),"$ 600", rewardstyle );
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 102 ,130, 20 ),"00 : " + LevelTime[2] , rewardstyle );

						if(PlayerPrefs.GetInt("Level3") == 1)
						{
							if(GUI.Button(new Rect(originalWidth - 260, originalHeight - 150 , 220, 70), "" , playstyle))
							{
//								bannerView.Hide();
								#if UNITY_ANDROID
								Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Large);
								#endif
								Handheld.StartActivityIndicator();
								DragonCounter.totalanimals = 1;
								GUI_Controller.time_Limit = LevelTime[2];
								GUI_Controller.Reward = 600;
								GUI_Controller.adcount = 0;
								PlayerPrefs.SetInt("DuckLevel1", 1);
								PlayerPrefs.SetInt("Staglevel1Night", 0);
								PlayerPrefs.SetInt("Ducklevel1Night", 0);
								GUI_Controller.hint = "Hunt One Flying Duck by sniper gun.";
								Application.LoadLevel("Level3");
							}
						}
						else
						{
							if(GUI.Button(new Rect(originalWidth - 260, originalHeight - 150 , 220, 70), " 1200", buytyle))
							{
								coin = PlayerPrefs.GetInt ("Earnings");
								if(coin > 1200)
								{
									coin = PlayerPrefs.GetInt ("Earnings") - 1200;
									PlayerPrefs.SetInt ("Earnings", coin);
										buypopup = true;
									PlayerPrefs.SetInt("Level3", 1);
								}
								else
								{
									coinbox = true;
								}
							}
						}
					}
				}
				if(levelchoose == 4)
				{
					if(!coinbox)
					{
						GUI.Label(new Rect(80, originalHeight / 2 - 80 , 600, 100), "Hunt One Golden Eagle by Sniper Gun.", Labelstyle);
						GUI.Label(new Rect(80, originalHeight / 2 - 40 , 600, 100), "Complete in time to get more reward.", Labelstyle);
						GUI.Label(new Rect(80, originalHeight / 2 , 600, 100), "Reward : 800.", Labelstyle);

						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 170 ,130, 20 ),"1", rewardstyle );
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 137 ,130, 20 ),"$ 800", rewardstyle );
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 102 ,130, 20 ),"00 : " + LevelTime[3] , rewardstyle );

						if(PlayerPrefs.GetInt("Level4") == 1)
						{
							if(GUI.Button(new Rect(originalWidth - 260, originalHeight - 150 , 220, 70), "" , playstyle))
							{
//								bannerView.Hide();
								#if UNITY_ANDROID
								Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Large);
								#endif
								Handheld.StartActivityIndicator();

								PlayerPrefs.SetInt("Wolflevel1", 0);
								PlayerPrefs.SetInt("Wolflevel2", 0);
								PlayerPrefs.SetInt("Bearlevel2", 0);
								PlayerPrefs.SetInt("Eaglelevel2", 1);
								PlayerPrefs.SetInt("Eaglelevel4", 0);
								GUI_Controller.adcount = 0;
								DragonCounter.totalanimals = 1;

								GUI_Controller.time_Limit = LevelTime[3];
								GUI_Controller.Reward = 800;
								GUI_Controller.hint = "Hunt One Eagle by sniper gun.";
								Application.LoadLevel("Level6");
							}
						}
						else
						{
							if(GUI.Button(new Rect(originalWidth - 260, originalHeight - 150 , 220, 70), " 1400", buytyle))
							{
								coin = PlayerPrefs.GetInt ("Earnings");
								if(coin > 1400)
								{
									coin = PlayerPrefs.GetInt ("Earnings") - 1400;
									PlayerPrefs.SetInt ("Earnings", coin);
										buypopup = true;
									PlayerPrefs.SetInt("Level4", 1);
								}
								else
								{
									coinbox = true;
								}
							}
						}
					}
				}
				if(levelchoose == 5)
				{
					if(!coinbox)
					{
						GUI.Label(new Rect(80, originalHeight / 2 - 80 , 600, 100), "Hunt Two Bear by Sniper Gun.", Labelstyle);
						GUI.Label(new Rect(80, originalHeight / 2 - 40 , 600, 100), "Complete in time to get more reward.", Labelstyle);
						GUI.Label(new Rect(80, originalHeight / 2 , 600, 100), "Reward : 900.", Labelstyle);

						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 170 ,130, 20 ),"2", rewardstyle );
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 137 ,130, 20 ),"$ 900", rewardstyle );
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 102 ,130, 20 ),"00 : " + LevelTime[4] , rewardstyle );

						if(PlayerPrefs.GetInt("Level5") == 1)
						{
							if(GUI.Button(new Rect(originalWidth - 260, originalHeight - 150 , 220, 70), "" , playstyle))
							{
//								bannerView.Hide();
								#if UNITY_ANDROID
								Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Large);
								#endif
								Handheld.StartActivityIndicator();
								//PlayerPrefs.SetInt("WolflevelNight", 0);
								PlayerPrefs.SetInt("Wolflevel1", 0);
								PlayerPrefs.SetInt("Wolflevel2", 0);
								PlayerPrefs.SetInt("Bearlevel2", 1);
								PlayerPrefs.SetInt("Eaglelevel2", 0);
								PlayerPrefs.SetInt("Eaglelevel4", 0);
								GUI_Controller.adcount = 0;
								DragonCounter.totalanimals = 2;
								GUI_Controller.time_Limit = LevelTime[4];
								GUI_Controller.Reward = 900;
								GUI_Controller.hint = "Hunt Two Bear by sniper gun.";
								Application.LoadLevel("Level6");
							}
						}
						else
						{
							if(GUI.Button(new Rect(originalWidth - 260, originalHeight - 150 , 220, 70), " 1600", buytyle))
							{
								coin = PlayerPrefs.GetInt ("Earnings");
								if(coin > 1600)
								{
									coin = PlayerPrefs.GetInt ("Earnings") - 1600;
									PlayerPrefs.SetInt ("Earnings", coin);
									buypopup = true;
									PlayerPrefs.SetInt("Level5", 1);
								}
								else
								{
									coinbox = true;
								}
							}
						}
					}
				}
				if(levelchoose == 6)
				{
					if(!coinbox)
					{
						GUI.Label(new Rect(80, originalHeight / 2 - 80 , 600, 100), "Hunt One Wolf by Sniper Gun.", Labelstyle);
						GUI.Label(new Rect(80, originalHeight / 2 - 40 , 600, 100), "Complete in time to get more reward.", Labelstyle);
						GUI.Label(new Rect(80, originalHeight / 2 , 600, 100), "Reward : 1000.", Labelstyle);

						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 170 ,130, 20 ),"1", rewardstyle );
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 137 ,130, 20 ),"$ 1000", rewardstyle );
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 102 ,130, 20 ),"00 : " + LevelTime[5] , rewardstyle );

						if(PlayerPrefs.GetInt("Level6") == 1)
						{
							if(GUI.Button(new Rect(originalWidth - 260, originalHeight - 150 , 220, 70), "" , playstyle))
							{
//								bannerView.Hide();
								#if UNITY_ANDROID
								Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Large);
								#endif
								Handheld.StartActivityIndicator();
								DragonCounter.totalanimals = 1;
								//PlayerPrefs.SetInt("WolflevelNight", 0);
								PlayerPrefs.SetInt("Wolflevel1", 1);
								PlayerPrefs.SetInt("Wolflevel2", 0);
								PlayerPrefs.SetInt("Bearlevel2", 0);
								PlayerPrefs.SetInt("Eaglelevel2", 0);
								PlayerPrefs.SetInt("Eaglelevel4", 0);
								GUI_Controller.adcount = 0;
								GUI_Controller.time_Limit = LevelTime[5];
								GUI_Controller.Reward = 1000;
								GUI_Controller.hint = "Hunt One Wolf by sniper gun.";
								Application.LoadLevel("Level6");
							}
						}
						else
						{
							if(GUI.Button(new Rect(originalWidth - 260, originalHeight - 150 , 220, 70), " 1900", buytyle))
							{
								coin = PlayerPrefs.GetInt ("Earnings");
								if(coin > 1900)
								{
									coin = PlayerPrefs.GetInt ("Earnings") - 1900;
									PlayerPrefs.SetInt ("Earnings", coin);
										buypopup = true;
									PlayerPrefs.SetInt("Level6", 1);
								}
								else
								{
									coinbox = true;
								}
							}
						}
					}
				}
				if(levelchoose == 7)
				{
					if(!coinbox)
					{
						GUI.Label(new Rect(80, originalHeight / 2 - 80 , 600, 100), "Hunt Two Wolf's by Sniper Gun.", Labelstyle);
						GUI.Label(new Rect(80, originalHeight / 2 - 40 , 600, 100), "Complete in time to get more reward.", Labelstyle);
						GUI.Label(new Rect(80, originalHeight / 2 , 600, 100), "Reward : 1200.", Labelstyle);

						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 170 ,130, 20 ),"2", rewardstyle );
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 137 ,130, 20 ),"$ 1200", rewardstyle );
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 102 ,130, 20 ),"00 : " + LevelTime[6] , rewardstyle );

						if(PlayerPrefs.GetInt("Level7") == 1)
						{
							if(GUI.Button(new Rect(originalWidth - 260, originalHeight - 150 , 220, 70), "" , playstyle))
							{
//								bannerView.Hide();
								#if UNITY_ANDROID
								Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Large);
								#endif
								Handheld.StartActivityIndicator();
								DragonCounter.totalanimals = 2;
								PlayerPrefs.SetInt("WolflevelNight", 1);
								PlayerPrefs.SetInt("BearLevel1", 0);
								PlayerPrefs.SetInt("Bear_NightLevel1", 0);
								PlayerPrefs.SetInt("Lion_NightLevel1", 0);
								GUI_Controller.time_Limit = LevelTime[6];
								GUI_Controller.Reward = 1200;
								GUI_Controller.adcount = 0;
								GUI_Controller.hint = "Hunt Two Wolf's by sniper gun.";
								Application.LoadLevel("Level1");
							}
						}
						else
						{
							if(GUI.Button(new Rect(originalWidth - 260, originalHeight - 150 , 220, 70), " 2200", buytyle))
							{
								coin = PlayerPrefs.GetInt ("Earnings");
								if(coin > 2200)
								{
									coin = PlayerPrefs.GetInt ("Earnings") - 2200;
									PlayerPrefs.SetInt ("Earnings", coin);
										buypopup = true;
									PlayerPrefs.SetInt("Level7", 1);
								}
								else
								{
									coinbox = true;
								}
							}
						}
					}
				}
				if(levelchoose == 8)
				{
					if(!coinbox)
					{
						GUI.Label(new Rect(80, originalHeight / 2 - 80 , 600, 100), "Hunt One Stag by Sniper Gun.", Labelstyle);
						GUI.Label(new Rect(80, originalHeight / 2 - 40 , 600, 100), "Complete in time to get more reward.", Labelstyle);
						GUI.Label(new Rect(80, originalHeight / 2 , 600, 100), "Reward : 1100.", Labelstyle);
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 170 ,130, 20 ),"1", rewardstyle );
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 137 ,130, 20 ),"$ 1100", rewardstyle );
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 102 ,130, 20 ),"00 : " + LevelTime[7] , rewardstyle );
						if(PlayerPrefs.GetInt("Level8") == 1)
						{
							if(GUI.Button(new Rect(originalWidth - 260, originalHeight - 150 , 220, 70), "" , playstyle))
							{
//								bannerView.Hide();
								#if UNITY_ANDROID
								Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Small);
								#endif
								Handheld.StartActivityIndicator();
								PlayerPrefs.SetInt ("Staglevel1", 1);
								PlayerPrefs.SetInt ("Staglevel2", 0);
								PlayerPrefs.SetInt ("Staglevel3", 0);
								PlayerPrefs.SetInt ("Staglevel4", 0);
								PlayerPrefs.SetInt ("Lionlevel1", 0);
								PlayerPrefs.SetInt ("Lionlevel2", 0);
								PlayerPrefs.SetInt ("RabbitLevel1", 0);
								DragonCounter.totalanimals = 1;
								GUI_Controller.time_Limit = LevelTime[7];
								GUI_Controller.Reward = 1100;
								GUI_Controller.adcount = 0;
								GUI_Controller.hint = "Hunt One Stag by sniper gun.";
								Application.LoadLevel("Level8");
							}
						}
						else
						{
							if(GUI.Button(new Rect(originalWidth - 260, originalHeight - 150 , 220, 70), " 2200", buytyle))
							{
								coin = PlayerPrefs.GetInt ("Earnings");
								if(coin > 2200)
								{
									coin = PlayerPrefs.GetInt ("Earnings") - 2200;
									PlayerPrefs.SetInt ("Earnings", coin);
										buypopup = true;
									PlayerPrefs.SetInt("Level8", 1);
								}
								else
								{
									coinbox = true;
								}
							}
						}
					}
				}
				if(levelchoose == 9)
				{
					if(!coinbox)
					{
						GUI.Label(new Rect(80, originalHeight / 2 - 80 , 600, 100), "Hunt Two Stag by Sniper Gun.", Labelstyle);
						GUI.Label(new Rect(80, originalHeight / 2 - 40 , 600, 100), "Complete in time to get more reward.", Labelstyle);
						GUI.Label(new Rect(80, originalHeight / 2 , 600, 100), "Reward : 1300.", Labelstyle);
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 170 ,130, 20 ),"2", rewardstyle );
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 137 ,130, 20 ),"$ 1300", rewardstyle );
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 102 ,130, 20 ),"00 : " + LevelTime[8] , rewardstyle );
						if(PlayerPrefs.GetInt("Level9") == 1)
						{
							if(GUI.Button(new Rect(originalWidth - 260, originalHeight - 150 , 220, 70), "" , playstyle))
							{
//								bannerView.Hide();
								#if UNITY_ANDROID
								Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Large);
								#endif
								Handheld.StartActivityIndicator();
								PlayerPrefs.SetInt ("Staglevel1", 0);
								PlayerPrefs.SetInt ("Staglevel2", 1);
								PlayerPrefs.SetInt ("Staglevel3", 0);
								PlayerPrefs.SetInt ("Staglevel4", 0);
								PlayerPrefs.SetInt ("Lionlevel1", 0);
								PlayerPrefs.SetInt ("Lionlevel2", 0);
								PlayerPrefs.SetInt ("RabbitLevel1", 0);
								DragonCounter.totalanimals = 2;
								GUI_Controller.time_Limit = LevelTime[8];
								GUI_Controller.Reward = 1300;
								GUI_Controller.adcount = 0;
								GUI_Controller.hint = "Hunt Two Stag's by sniper gun.";
								Application.LoadLevel("Level8");
							}
						}
						else
						{
							if(GUI.Button(new Rect(originalWidth - 260, originalHeight - 150 , 220, 70), " 2500", buytyle))
							{
								coin = PlayerPrefs.GetInt ("Earnings");
								if(coin > 2500)
								{
									coin = PlayerPrefs.GetInt ("Earnings") - 2500;
									PlayerPrefs.SetInt ("Earnings", coin);
										buypopup = true;
									PlayerPrefs.SetInt("Level9", 1);
								}
								else
								{
									coinbox = true;
								}
							}
						}
					}
				}
				if(levelchoose == 10)
				{
					if(!coinbox)
					{
						GUI.Label(new Rect(80, originalHeight / 2 - 80 , 600, 100), "Hunt Two Stag by Sniper Gun.", Labelstyle);
						GUI.Label(new Rect(80, originalHeight / 2 - 40 , 600, 100), "Complete in time to get more reward.", Labelstyle);
						GUI.Label(new Rect(80, originalHeight / 2 , 600, 100), "Reward : 1400.", Labelstyle);
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 170 ,130, 20 ),"2", rewardstyle );
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 137 ,130, 20 ),"$ 1400", rewardstyle );
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 102 ,130, 20 ),"00 : " + LevelTime[9] , rewardstyle );
						if(PlayerPrefs.GetInt("Level10") == 1)
						{
							if(GUI.Button(new Rect(originalWidth - 260, originalHeight - 150 , 220, 70), "" , playstyle))
							{
//								bannerView.Hide();
								#if UNITY_ANDROID
								Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Large);
								#endif
								Handheld.StartActivityIndicator();
								PlayerPrefs.SetInt ("Staglevel1", 0);
								PlayerPrefs.SetInt ("Staglevel2", 0);
								PlayerPrefs.SetInt ("Staglevel3", 1);
								PlayerPrefs.SetInt ("Staglevel4", 0);
								PlayerPrefs.SetInt ("Lionlevel1", 0);
								PlayerPrefs.SetInt ("Lionlevel2", 0);
								PlayerPrefs.SetInt ("RabbitLevel1", 0);
								DragonCounter.totalanimals = 2;
								GUI_Controller.time_Limit = LevelTime[9];
								GUI_Controller.Reward = 1400;
								GUI_Controller.adcount = 0;
								GUI_Controller.hint = "Hunt Two Stag's by sniper gun.";
								Application.LoadLevel("Level8");
							}
						}
						else
						{
							if(GUI.Button(new Rect(originalWidth - 260, originalHeight - 150 , 220, 70), " 2800", buytyle))
							{
								coin = PlayerPrefs.GetInt ("Earnings");
								if(coin > 2800)
								{
									coin = PlayerPrefs.GetInt ("Earnings") - 2800;
									PlayerPrefs.SetInt ("Earnings", coin);
										buypopup = true;
									PlayerPrefs.SetInt("Level10", 1);
								}
								else
								{
									coinbox = true;
								}
							}
						}
					}
				}
				if(levelchoose == 11)
				{
					if(!coinbox)
					{
						GUI.Label(new Rect(80, originalHeight / 2 - 80 , 600, 100), "Hunt One Lion by Sniper Gun.", Labelstyle);
						GUI.Label(new Rect(80, originalHeight / 2 - 40 , 600, 100), "Complete in time to get more reward.", Labelstyle);
						GUI.Label(new Rect(80, originalHeight / 2 , 600, 100), "Reward : 1500.", Labelstyle);
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 170 ,130, 20 ),"1", rewardstyle );
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 137 ,130, 20 ),"$ 1500", rewardstyle );
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 102 ,130, 20 ),"00 : " + LevelTime[10] , rewardstyle );

						if(PlayerPrefs.GetInt("Level11") == 1)
						{
							if(GUI.Button(new Rect(originalWidth - 260, originalHeight - 150 , 220, 70), "" , playstyle))
							{
//								bannerView.Hide();
								#if UNITY_ANDROID
								Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Large);
								#endif
								Handheld.StartActivityIndicator();
								PlayerPrefs.SetInt ("Staglevel1", 0);
								PlayerPrefs.SetInt ("Staglevel2", 0);
								PlayerPrefs.SetInt ("Staglevel3", 0);
								PlayerPrefs.SetInt ("Staglevel4", 0);
								PlayerPrefs.SetInt ("Lionlevel1", 1);
								PlayerPrefs.SetInt ("Lionlevel2", 0);
								PlayerPrefs.SetInt ("RabbitLevel1", 0);
								GUI_Controller.adcount = 0;
								DragonCounter.totalanimals = 1;
								GUI_Controller.time_Limit = LevelTime[10];
								GUI_Controller.Reward = 1500;
								GUI_Controller.hint = "Hunt One Lion by Sniper Gun.";
								Application.LoadLevel("Level8");
							}
						}
						else
						{
							if(GUI.Button(new Rect(originalWidth - 260, originalHeight - 150 , 220, 70), " 3200", buytyle))
							{
								coin = PlayerPrefs.GetInt ("Earnings");
								if(coin > 3200)
								{
									coin = PlayerPrefs.GetInt ("Earnings") - 3200;
									PlayerPrefs.SetInt ("Earnings", coin);
										buypopup = true;
									PlayerPrefs.SetInt("Level11", 1);
								}
								else
								{
									coinbox = true;
								}
							}
						}
					}
				}
				if(levelchoose == 12)
				{
					if(!coinbox)
					{
						GUI.Label(new Rect(80, originalHeight / 2 - 80 , 600, 100), "Hunt Two Lion by Sniper Gun.", Labelstyle);
						GUI.Label(new Rect(80, originalHeight / 2 - 40 , 600, 100), "Complete in time to get more reward.", Labelstyle);
						GUI.Label(new Rect(80, originalHeight / 2 , 600, 100), "Reward : 2000.", Labelstyle);
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 170 ,130, 20 ),"2", rewardstyle );
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 137 ,130, 20 ),"$ 2000", rewardstyle );
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 102 ,130, 20 ),"00 : " + LevelTime[11] , rewardstyle );
						if(PlayerPrefs.GetInt("Level12") == 1)
						{
							if(GUI.Button(new Rect(originalWidth - 260, originalHeight - 150 , 220, 70), "" , playstyle))
							{
//								bannerView.Hide();
								#if UNITY_ANDROID
								Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Large);
								#endif
								Handheld.StartActivityIndicator();
								PlayerPrefs.SetInt ("Staglevel1", 0);
								PlayerPrefs.SetInt ("Staglevel2", 0);
								PlayerPrefs.SetInt ("Staglevel3", 0);
								PlayerPrefs.SetInt ("Staglevel4", 0);
								PlayerPrefs.SetInt ("Lionlevel1", 0);
								PlayerPrefs.SetInt ("Lionlevel2", 1);
								PlayerPrefs.SetInt ("RabbitLevel1", 0);
								GUI_Controller.adcount = 0;
								DragonCounter.totalanimals = 2;
								GUI_Controller.time_Limit = LevelTime[11];
								GUI_Controller.Reward = 2000;
								GUI_Controller.hint = "Hunt Two Lion by Sniper Gun.";
								Application.LoadLevel("Level8");
							}
						}
						else
						{
							if(GUI.Button(new Rect(originalWidth - 260, originalHeight - 150 , 220, 70), " 4000", buytyle))
							{
								coin = PlayerPrefs.GetInt ("Earnings");
								if(coin > 4000)
								{
									coin = PlayerPrefs.GetInt ("Earnings") - 4000;
									PlayerPrefs.SetInt ("Earnings", coin);
										buypopup = true;
									PlayerPrefs.SetInt("Level12", 1);
								}
								else
								{
									coinbox = true;
								}
							}
						}
					}
				}


				if(levelchoose == 13)
				{
					if(!coinbox)
					{
						GUI.Label(new Rect(80, originalHeight / 2 - 80 , 600, 100), "Hunt Two Wolf's by Sniper Gun.", Labelstyle);
						GUI.Label(new Rect(80, originalHeight / 2 - 40 , 600, 100), "Complete in time to get more reward.", Labelstyle);
						GUI.Label(new Rect(80, originalHeight / 2 , 600, 100), "Reward : 2200.", Labelstyle);
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 170 ,130, 20 ),"2", rewardstyle );
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 137 ,130, 20 ),"$ 2200", rewardstyle );
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 102 ,130, 20 ),"00 : " + LevelTime[012] , rewardstyle );
						if(PlayerPrefs.GetInt("Level13") == 1)
						{
							if(GUI.Button(new Rect(originalWidth - 260, originalHeight - 150 , 220, 70), "" , playstyle))
							{
//								bannerView.Hide();
								#if UNITY_ANDROID
								Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Large);
								#endif
								Handheld.StartActivityIndicator();
								PlayerPrefs.SetInt("Wolflevel1", 0);
								PlayerPrefs.SetInt("Wolflevel2", 1);
								PlayerPrefs.SetInt("Bearlevel2", 0);
								PlayerPrefs.SetInt("Eaglelevel2", 0);
								PlayerPrefs.SetInt("Eaglelevel4", 0);
								GUI_Controller.adcount = 0;
								DragonCounter.totalanimals = 2;
								GUI_Controller.time_Limit = LevelTime[12];
								GUI_Controller.Reward = 2200;
								GUI_Controller.hint = "Hunt Two Wolf's by Sniper Gun.";
								Application.LoadLevel("Level6");
							}
						}
						else
						{
							if(GUI.Button(new Rect(originalWidth - 260, originalHeight - 150 , 220, 70), " 4500", buytyle))
							{
								coin = PlayerPrefs.GetInt ("Earnings");
								if(coin > 4500)
								{
									coin = PlayerPrefs.GetInt ("Earnings") - 4500;
									PlayerPrefs.SetInt ("Earnings", coin);
										buypopup = true;
									PlayerPrefs.SetInt("Level13", 1);
								}
								else
								{
									coinbox = true;
								}
							}
						}
					}
				}
				if(levelchoose == 14)
				{
					if(!coinbox)
					{
						GUI.Label(new Rect(80, originalHeight / 2 - 80 , 600, 100), "Hunt Four Eagle's by Sniper Gun.", Labelstyle);
						GUI.Label(new Rect(80, originalHeight / 2 - 40 , 600, 100), "Complete in time to get more reward.", Labelstyle);
						GUI.Label(new Rect(80, originalHeight / 2 , 600, 100), "Reward : 2500.", Labelstyle);
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 170 ,130, 20 ),"4", rewardstyle );
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 137 ,130, 20 ),"$ 2500", rewardstyle );
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 102 ,130, 20 ),"00 : " + LevelTime[13] , rewardstyle );
						if(PlayerPrefs.GetInt("Level14") == 1)
						{
							if(GUI.Button(new Rect(originalWidth - 260, originalHeight - 150 , 220, 70), "" , playstyle))
							{
//								bannerView.Hide();
								#if UNITY_ANDROID
								Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Large);
								#endif
								Handheld.StartActivityIndicator();
								PlayerPrefs.SetInt("Wolflevel1", 0);
								PlayerPrefs.SetInt("Wolflevel2", 0);
								PlayerPrefs.SetInt("Bearlevel2", 0);
								PlayerPrefs.SetInt("Eaglelevel2", 0);
								PlayerPrefs.SetInt("Eaglelevel4", 1);
								GUI_Controller.adcount = 0;
								DragonCounter.totalanimals = 4;
								GUI_Controller.time_Limit = LevelTime[13];
								GUI_Controller.Reward = 2500;
								GUI_Controller.hint = "Hunt Four Eagle's by Sniper Gun.";
								Application.LoadLevel("Level6");
							}
						}
						else
						{
							if(GUI.Button(new Rect(originalWidth - 260, originalHeight - 150 , 220, 70), " 5500", buytyle))
							{
								coin = PlayerPrefs.GetInt ("Earnings");
								if(coin > 5500)
								{
									coin = PlayerPrefs.GetInt ("Earnings") - 5500;
									PlayerPrefs.SetInt ("Earnings", coin);
										buypopup = true;
									PlayerPrefs.SetInt("Level14", 1);
								}
								else
								{
									coinbox = true;
								}
							}
						}
					}
				}
				if(levelchoose == 15)
				{
					if(!coinbox)
					{
						GUI.Label(new Rect(80, originalHeight / 2 - 80 , 600, 100), "Hunt Three Stag's by Sniper Gun.", Labelstyle);
						GUI.Label(new Rect(80, originalHeight / 2 - 40 , 600, 100), "Complete in time to get more reward.", Labelstyle);
						GUI.Label(new Rect(80, originalHeight / 2 , 600, 100), "Reward : 2800.", Labelstyle);
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 170 ,130, 20 ),"3", rewardstyle );
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 137 ,130, 20 ),"$ 2800", rewardstyle );
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 102 ,130, 20 ),"00 : " + LevelTime[14] , rewardstyle );
						if(PlayerPrefs.GetInt("Level15") == 1)
						{
							if(GUI.Button(new Rect(originalWidth - 260, originalHeight - 150 , 220, 70), "" , playstyle))
							{
//								bannerView.Hide();
								#if UNITY_ANDROID
								Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Large);
								#endif
								Handheld.StartActivityIndicator();
								PlayerPrefs.SetInt("DuckLevel1", 0);
								PlayerPrefs.SetInt("Staglevel1Night", 1);
								PlayerPrefs.SetInt("Ducklevel1Night", 0);
								DragonCounter.totalanimals = 3;
								GUI_Controller.time_Limit = LevelTime[14];
								GUI_Controller.adcount = 0;
								GUI_Controller.Reward = 2800;
								GUI_Controller.hint = "Hunt Three Stag's by Sniper Gun.";
								Application.LoadLevel("Level3");
							}
						}
						else
						{
							if(GUI.Button(new Rect(originalWidth - 260, originalHeight - 150 , 220, 70), " 6500", buytyle))
							{
								coin = PlayerPrefs.GetInt ("Earnings");
								if(coin > 6500)
								{
									coin = PlayerPrefs.GetInt ("Earnings") - 6500;
									PlayerPrefs.SetInt ("Earnings", coin);
										buypopup = true;
									PlayerPrefs.SetInt("Level15", 1);
								}
								else
								{
									coinbox = true;
								}
							}
						}
					}
				}
				if(levelchoose == 16)
				{
					if(!coinbox)
					{
						GUI.Label(new Rect(80, originalHeight / 2 - 80 , 600, 100), "Hunt One Bear by Sniper Gun.", Labelstyle);
						GUI.Label(new Rect(80, originalHeight / 2 - 40 , 600, 100), "Complete in time to get more reward.", Labelstyle);
						GUI.Label(new Rect(80, originalHeight / 2 , 600, 100), "Reward : 2500.", Labelstyle);
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 170 ,130, 20 ),"1", rewardstyle );
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 137 ,130, 20 ),"$ 2500", rewardstyle );
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 102 ,130, 20 ),"00 : " + LevelTime[15] , rewardstyle );
						if(PlayerPrefs.GetInt("Level16") == 1)
						{
							if(GUI.Button(new Rect(originalWidth - 260, originalHeight - 150 , 220, 70), "" , playstyle))
							{
//								bannerView.Hide();
								#if UNITY_ANDROID
								Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Large);
								#endif
								Handheld.StartActivityIndicator();
								PlayerPrefs.SetInt("WolflevelNight", 0);
								PlayerPrefs.SetInt("BearLevel1", 0);
								PlayerPrefs.SetInt("Bear_NightLevel1", 1);
								PlayerPrefs.SetInt("Lion_NightLevel1", 0);
								DragonCounter.totalanimals = 1;
								GUI_Controller.time_Limit = LevelTime[15];
								GUI_Controller.adcount = 0;
								GUI_Controller.Reward = 2500;
								GUI_Controller.hint = "Hunt One Bear by Sniper Gun.";
								Application.LoadLevel("Level1");
							}
						}
						else
						{
							if(GUI.Button(new Rect(originalWidth - 260, originalHeight - 150 , 220, 70), " 6500", buytyle))
							{
								coin = PlayerPrefs.GetInt ("Earnings");
								if(coin > 6500)
								{
									coin = PlayerPrefs.GetInt ("Earnings") - 6500;
									PlayerPrefs.SetInt ("Earnings", coin);
									buypopup = true;
									PlayerPrefs.SetInt("Level16", 1);
								}
								else
								{
									coinbox = true;
								}
							}
						}
					}		
				}
				if(levelchoose == 17)
				{
					if(!coinbox)
					{
						GUI.Label(new Rect(80, originalHeight / 2 - 80 , 600, 100), "Hunt One Lion by Sniper Gun.", Labelstyle);
						GUI.Label(new Rect(80, originalHeight / 2 - 40 , 600, 100), "Complete in time to get more reward.", Labelstyle);
						GUI.Label(new Rect(80, originalHeight / 2 , 600, 100), "Reward : 2800.", Labelstyle);
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 170 ,130, 20 ),"1", rewardstyle );
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 137 ,130, 20 ),"$ 2800", rewardstyle );
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 102 ,130, 20 ),"00 : " + LevelTime[16] , rewardstyle );
						if(PlayerPrefs.GetInt("Level17") == 1)
						{
							if(GUI.Button(new Rect(originalWidth - 260, originalHeight - 150 , 220, 70), "" , playstyle))
							{
//								bannerView.Hide();
								#if UNITY_ANDROID
								Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Large);
								#endif
								Handheld.StartActivityIndicator();
								PlayerPrefs.SetInt("WolflevelNight", 0);
								PlayerPrefs.SetInt("BearLevel1", 0);
								PlayerPrefs.SetInt("Bear_NightLevel1", 0);
								PlayerPrefs.SetInt("Lion_NightLevel1", 1);
								DragonCounter.totalanimals = 1;
								GUI_Controller.time_Limit = LevelTime[16];
								GUI_Controller.adcount = 0;
								GUI_Controller.Reward = 2800;
								GUI_Controller.hint = "Hunt One Lion by Sniper Gun.";
								Application.LoadLevel("Level1");
							}
						}
						else
						{
							if(GUI.Button(new Rect(originalWidth - 260, originalHeight - 150 , 220, 70), " 7500", buytyle))
							{
								coin = PlayerPrefs.GetInt ("Earnings");
								if(coin > 7500)
								{
									coin = PlayerPrefs.GetInt ("Earnings") - 7500;
									PlayerPrefs.SetInt ("Earnings", coin);
									buypopup = true;
									PlayerPrefs.SetInt("Level17", 1);
								}
								else
								{
									coinbox = true;
								}
							}
						}
					}
				}
				if(levelchoose == 18)
				{
					if(!coinbox)
					{
						GUI.Label(new Rect(80, originalHeight / 2 - 80 , 600, 100), "Hunt Four Duck's by Sniper Gun.", Labelstyle);
						GUI.Label(new Rect(80, originalHeight / 2 - 40 , 600, 100), "Complete in time to get more reward.", Labelstyle);
						GUI.Label(new Rect(80, originalHeight / 2 , 600, 100), "Reward : 3200.", Labelstyle);
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 170 ,130, 20 ),"4", rewardstyle );
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 137 ,130, 20 ),"$ 3200", rewardstyle );
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 102 ,130, 20 ),"00 : " + LevelTime[17] , rewardstyle );
						if(PlayerPrefs.GetInt("Level18") == 1)
						{
							if(GUI.Button(new Rect(originalWidth - 260, originalHeight - 150 , 220, 70), "" , playstyle))
							{
//								bannerView.Hide();
								#if UNITY_ANDROID
								Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Large);
								#endif
								Handheld.StartActivityIndicator();
								PlayerPrefs.SetInt("DuckLevel1", 0);
								PlayerPrefs.SetInt("Staglevel1Night", 0);
								PlayerPrefs.SetInt("Ducklevel1Night", 1);
								DragonCounter.totalanimals = 4;
								GUI_Controller.time_Limit = LevelTime[17];
								GUI_Controller.adcount = 0;
								GUI_Controller.Reward = 3200;
								GUI_Controller.hint = "Hunt Four Duck's by Sniper Gun.";
								Application.LoadLevel("Level3");
							}
						}
						else
						{
							if(GUI.Button(new Rect(originalWidth - 260, originalHeight - 150 , 220, 70), " 6500", buytyle))
							{
								coin = PlayerPrefs.GetInt ("Earnings");
								if(coin > 6500)
								{
									coin = PlayerPrefs.GetInt ("Earnings") - 6500;
									PlayerPrefs.SetInt ("Earnings", coin);
									buypopup = true;
									PlayerPrefs.SetInt("Level18", 1);
								}
								else
								{
									coinbox = true;
								}
							}
						}
					}
				}

				if(levelchoose == 19)
				{
					if(!coinbox)
					{
						GUI.Label(new Rect(80, originalHeight / 2 - 80 , 600, 100), "Hunt Four Stag's by Sniper Gun.", Labelstyle);
						GUI.Label(new Rect(80, originalHeight / 2 - 40 , 740, 100), "Complete in time to get more reward.", Labelstyle);
						GUI.Label(new Rect(80, originalHeight / 2 , 600, 100), "Reward : 4000.", Labelstyle);
						
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 170 ,130, 20 ),"4", rewardstyle );
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 137 ,130, 20 ),"$ 4000", rewardstyle );
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 102 ,130, 20 ),"00 : " + LevelTime[18] , rewardstyle );
						
						if(PlayerPrefs.GetInt("Level19") == 1)
						{
							if(GUI.Button(new Rect(originalWidth - 260, originalHeight - 150 , 220, 70), "" , playstyle))
							{
//								bannerView.Hide();
								#if UNITY_ANDROID
								Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Large);
								#endif
								Handheld.StartActivityIndicator();
								PlayerPrefs.SetInt ("Staglevel1", 0);
								PlayerPrefs.SetInt ("Staglevel2", 0);
								PlayerPrefs.SetInt ("Staglevel3", 0);
								PlayerPrefs.SetInt ("Staglevel4", 1);
								PlayerPrefs.SetInt ("Lionlevel1", 0);
								PlayerPrefs.SetInt ("Lionlevel2", 0);
								PlayerPrefs.SetInt ("RabbitLevel1", 0);
								GUI_Controller.adcount = 0;
								DragonCounter.totalanimals = 4;
								GUI_Controller.time_Limit = LevelTime[18];
								GUI_Controller.Reward = 4000;
								GUI_Controller.hint = "Hunt Four Stag's by Sniper Gun.";
								Application.LoadLevel("Level8");
							}
						}
						else
						{
							if(GUI.Button(new Rect(originalWidth - 260, originalHeight - 150 , 220, 70), " 7500", buytyle))
							{
								coin = PlayerPrefs.GetInt ("Earnings");
								if(coin > 7500)
								{
									coin = PlayerPrefs.GetInt ("Earnings") - 7500;
									PlayerPrefs.SetInt ("Earnings", coin);
									buypopup = true;
									PlayerPrefs.SetInt("Level19", 1);
								}
								else
								{
									coinbox = true;
								}
							}
						}
					}
				}


				if(levelchoose == 20)
				{
					if(!coinbox)
					{
						GUI.Label(new Rect(80, originalHeight / 2 - 80 , 600, 100), "Hunt Two Stag by Sniper Gun.", Labelstyle);
						GUI.Label(new Rect(80, originalHeight / 2 - 40 , 740, 100), "Complete in time to get more reward.", Labelstyle);
						GUI.Label(new Rect(80, originalHeight / 2 , 600, 100), "Reward : 1500.", Labelstyle);
						
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 170 ,130, 20 ),"2", rewardstyle );
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 137 ,130, 20 ),"$ 1500", rewardstyle );
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 102 ,130, 20 ),"00 : " + LevelTime[19] , rewardstyle );
						
						if(PlayerPrefs.GetInt("Level20") == 1)
						{
							if(GUI.Button(new Rect(originalWidth - 260, originalHeight - 150 , 220, 70), "" , playstyle))
							{
//								bannerView.Hide();
								#if UNITY_ANDROID
								Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Large);
								#endif
								Handheld.StartActivityIndicator();
								PlayerPrefs.SetInt ("Stag_Snow_Level1", 1);
								PlayerPrefs.SetInt ("Stag_Snow_Level2", 0);
								PlayerPrefs.SetInt ("Bear_Snow_Level1", 0);
								PlayerPrefs.SetInt ("Bear_Snow_Level2", 0);
								PlayerPrefs.SetInt ("Lion_Snow_Level1", 0);
								PlayerPrefs.SetInt ("Lion_Snow_Level2", 0);

								GUI_Controller.adcount = 0;
								DragonCounter.totalanimals = 2;
								GUI_Controller.time_Limit = LevelTime[19];
								GUI_Controller.Reward = 1500;
								GUI_Controller.hint = "Hunt Two Stag by Sniper Gun.";
								Application.LoadLevel("Level9");
							}
						}
						else
						{
							if(GUI.Button(new Rect(originalWidth - 260, originalHeight - 150 , 220, 70), " 8000", buytyle))
							{
								coin = PlayerPrefs.GetInt ("Earnings");
								if(coin > 8000)
								{
									coin = PlayerPrefs.GetInt ("Earnings") - 8000;
									PlayerPrefs.SetInt ("Earnings", coin);
									buypopup = true;
									PlayerPrefs.SetInt("Level20", 1);
								}
								else
								{
									coinbox = true;
								}
							}
						}
					}
				}

				if(levelchoose == 21)
				{
					if(!coinbox)
					{
						GUI.Label(new Rect(80, originalHeight / 2 - 80 , 600, 100), "Hunt Two Bear's by Sniper Gun.", Labelstyle);
						GUI.Label(new Rect(80, originalHeight / 2 - 40 , 740, 100), "Complete in time to get more reward.", Labelstyle);
						GUI.Label(new Rect(80, originalHeight / 2 , 600, 100), "Reward : 2000.", Labelstyle);
						
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 170 ,130, 20 ),"2", rewardstyle );
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 137 ,130, 20 ),"$ 2000", rewardstyle );
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 102 ,130, 20 ),"00 : " + LevelTime[20] , rewardstyle );
						
						if(PlayerPrefs.GetInt("Level21") == 1)
						{
							if(GUI.Button(new Rect(originalWidth - 260, originalHeight - 150 , 220, 70), "" , playstyle))
							{
//								bannerView.Hide();
								#if UNITY_ANDROID
								Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Large);
								#endif
								Handheld.StartActivityIndicator();
								PlayerPrefs.SetInt ("Stag_Snow_Level1", 0);
								PlayerPrefs.SetInt ("Stag_Snow_Level2", 0);
								PlayerPrefs.SetInt ("Bear_Snow_Level1", 1);
								PlayerPrefs.SetInt ("Bear_Snow_Level2", 0);
								PlayerPrefs.SetInt ("Lion_Snow_Level1", 0);
								PlayerPrefs.SetInt ("Lion_Snow_Level2", 0);
								
								GUI_Controller.adcount = 0;
								DragonCounter.totalanimals = 2;
								GUI_Controller.time_Limit = LevelTime[20];
								GUI_Controller.Reward = 2000;
								GUI_Controller.hint = "Hunt Two Bear's by Sniper Gun.";
								Application.LoadLevel("Level9");
							}
						}
						else
						{
							if(GUI.Button(new Rect(originalWidth - 260, originalHeight - 150 , 220, 70), " 8500", buytyle))
							{
								coin = PlayerPrefs.GetInt ("Earnings");
								if(coin > 8500)
								{
									coin = PlayerPrefs.GetInt ("Earnings") - 8500;
									PlayerPrefs.SetInt ("Earnings", coin);
									buypopup = true;
									PlayerPrefs.SetInt("Level21", 1);
								}
								else
								{
									coinbox = true;
								}
							}
						}
					}
				}


				if(levelchoose == 22)
				{
					if(!coinbox)
					{
						GUI.Label(new Rect(80, originalHeight / 2 - 80 , 600, 100), "Hunt Two Lion's by Sniper Gun.", Labelstyle);
						GUI.Label(new Rect(80, originalHeight / 2 - 40 , 740, 100), "Complete in time to get more reward.", Labelstyle);
						GUI.Label(new Rect(80, originalHeight / 2 , 600, 100), "Reward : 2500.", Labelstyle);
						
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 170 ,130, 20 ),"2", rewardstyle );
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 137 ,130, 20 ),"$ 2500", rewardstyle );
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 102 ,130, 20 ),"00 : " + LevelTime[21] , rewardstyle );
						
						if(PlayerPrefs.GetInt("Level22") == 1)
						{
							if(GUI.Button(new Rect(originalWidth - 260, originalHeight - 150 , 220, 70), "" , playstyle))
							{
//								bannerView.Hide();
								#if UNITY_ANDROID
								Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Large);
								#endif
								Handheld.StartActivityIndicator();
								PlayerPrefs.SetInt ("Stag_Snow_Level1", 0);
								PlayerPrefs.SetInt ("Stag_Snow_Level2", 0);
								PlayerPrefs.SetInt ("Bear_Snow_Level1", 0);
								PlayerPrefs.SetInt ("Bear_Snow_Level2", 0);
								PlayerPrefs.SetInt ("Lion_Snow_Level1", 1);
								PlayerPrefs.SetInt ("Lion_Snow_Level2", 0);
								
								GUI_Controller.adcount = 0;
								DragonCounter.totalanimals = 2;
								GUI_Controller.time_Limit = LevelTime[21];
								GUI_Controller.Reward = 2500;
								GUI_Controller.hint = "Hunt Two Lion's by Sniper Gun.";
								Application.LoadLevel("Level9");
							}
						}
						else
						{
							if(GUI.Button(new Rect(originalWidth - 260, originalHeight - 150 , 220, 70), " 9500", buytyle))
							{
								coin = PlayerPrefs.GetInt ("Earnings");
								if(coin > 9500)
								{
									coin = PlayerPrefs.GetInt ("Earnings") - 9500;
									PlayerPrefs.SetInt ("Earnings", coin);
									buypopup = true;
									PlayerPrefs.SetInt("Level22", 1);
								}
								else
								{
									coinbox = true;
								}
							}
						}
					}
				}

				if(levelchoose == 23)
				{
					if(!coinbox)
					{
						GUI.Label(new Rect(80, originalHeight / 2 - 80 , 600, 100), "Hunt Four Stag's by Sniper Gun.", Labelstyle);
						GUI.Label(new Rect(80, originalHeight / 2 - 40 , 740, 100), "Complete in time to get more reward.", Labelstyle);
						GUI.Label(new Rect(80, originalHeight / 2 , 600, 100), "Reward : 4000.", Labelstyle);
						
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 170 ,130, 20 ),"4", rewardstyle );
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 137 ,130, 20 ),"$ 4000", rewardstyle );
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 102 ,130, 20 ),"00 : " + LevelTime[22] , rewardstyle );
						
						if(PlayerPrefs.GetInt("Level23") == 1)
						{
							if(GUI.Button(new Rect(originalWidth - 260, originalHeight - 150 , 220, 70), "" , playstyle))
							{
//								bannerView.Hide();
								#if UNITY_ANDROID
								Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Large);
								#endif
								Handheld.StartActivityIndicator();
								PlayerPrefs.SetInt ("Stag_Snow_Level1", 0);
								PlayerPrefs.SetInt ("Stag_Snow_Level2", 1);
								PlayerPrefs.SetInt ("Bear_Snow_Level1", 0);
								PlayerPrefs.SetInt ("Bear_Snow_Level2", 0);
								PlayerPrefs.SetInt ("Lion_Snow_Level1", 0);
								PlayerPrefs.SetInt ("Lion_Snow_Level2", 0);
								
								GUI_Controller.adcount = 0;
								DragonCounter.totalanimals = 4;
								GUI_Controller.time_Limit = LevelTime[22];
								GUI_Controller.Reward = 4000;
								GUI_Controller.hint = "Hunt Four Stag's by Sniper Gun.";
								Application.LoadLevel("Level9");
							}
						}
						else
						{
							if(GUI.Button(new Rect(originalWidth - 260, originalHeight - 150 , 220, 70), " 11000", buytyle))
							{
								coin = PlayerPrefs.GetInt ("Earnings");
								if(coin > 11000)
								{
									coin = PlayerPrefs.GetInt ("Earnings") - 11000;
									PlayerPrefs.SetInt ("Earnings", coin);
									buypopup = true;
									PlayerPrefs.SetInt("Level23", 1);
								}
								else
								{
									coinbox = true;
								}
							}
						}
					}
				}


				if(levelchoose == 24)
				{
					if(!coinbox)
					{
						GUI.Label(new Rect(80, originalHeight / 2 - 80 , 600, 100), "Hunt Four Bear's by Sniper Gun.", Labelstyle);
						GUI.Label(new Rect(80, originalHeight / 2 - 40 , 740, 100), "Complete in time to get more reward.", Labelstyle);
						GUI.Label(new Rect(80, originalHeight / 2 , 600, 100), "Reward : 5000.", Labelstyle);
						
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 170 ,130, 20 ),"4", rewardstyle );
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 137 ,130, 20 ),"$ 5000", rewardstyle );
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 102 ,130, 20 ),"00 : " + LevelTime[23] , rewardstyle );
						
						if(PlayerPrefs.GetInt("Level24") == 1)
						{
							if(GUI.Button(new Rect(originalWidth - 260, originalHeight - 150 , 220, 70), "" , playstyle))
							{
//								bannerView.Hide();
								#if UNITY_ANDROID
								Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Large);
								#endif
								Handheld.StartActivityIndicator();
								PlayerPrefs.SetInt ("Stag_Snow_Level1", 0);
								PlayerPrefs.SetInt ("Stag_Snow_Level2", 0);
								PlayerPrefs.SetInt ("Bear_Snow_Level1", 0);
								PlayerPrefs.SetInt ("Bear_Snow_Level2", 1);
								PlayerPrefs.SetInt ("Lion_Snow_Level1", 0);
								PlayerPrefs.SetInt ("Lion_Snow_Level2", 0);
								
								GUI_Controller.adcount = 0;
								DragonCounter.totalanimals = 4;
								GUI_Controller.time_Limit = LevelTime[23];
								GUI_Controller.Reward = 5000;
								GUI_Controller.hint = "Hunt Four Bear's by Sniper Gun.";
								Application.LoadLevel("Level9");
							}
						}
						else
						{
							if(GUI.Button(new Rect(originalWidth - 260, originalHeight - 150 , 220, 70), " 13000", buytyle))
							{
								coin = PlayerPrefs.GetInt ("Earnings");
								if(coin > 13000)
								{
									coin = PlayerPrefs.GetInt ("Earnings") - 13000;
									PlayerPrefs.SetInt ("Earnings", coin);
									buypopup = true;
									PlayerPrefs.SetInt("Level24", 1);
								}
								else
								{
									coinbox = true;
								}
							}
						}
					}
				}


				if(levelchoose == 25)
				{
					if(!coinbox)
					{
						GUI.Label(new Rect(80, originalHeight / 2 - 80 , 600, 100), "Hunt Four Lion's by Sniper Gun.", Labelstyle);
						GUI.Label(new Rect(80, originalHeight / 2 - 40 , 740, 100), "Complete in time to get more reward.", Labelstyle);
						GUI.Label(new Rect(80, originalHeight / 2 , 600, 100), "Reward : 6000.", Labelstyle);
						
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 170 ,130, 20 ),"4", rewardstyle );
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 137 ,130, 20 ),"$ 6000", rewardstyle );
						GUI.Label(new Rect(originalWidth - 135, originalHeight /2 - 102 ,130, 20 ),"00 : " + LevelTime[24] , rewardstyle );
						
						if(PlayerPrefs.GetInt("Level25") == 1)
						{
							if(GUI.Button(new Rect(originalWidth - 260, originalHeight - 150 , 220, 70), "" , playstyle))
							{
//								bannerView.Hide();
								#if UNITY_ANDROID
								Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Large);
								#endif
								Handheld.StartActivityIndicator();
								PlayerPrefs.SetInt ("Stag_Snow_Level1", 0);
								PlayerPrefs.SetInt ("Stag_Snow_Level2", 0);
								PlayerPrefs.SetInt ("Bear_Snow_Level1", 0);
								PlayerPrefs.SetInt ("Bear_Snow_Level2", 0);
								PlayerPrefs.SetInt ("Lion_Snow_Level1", 0);
								PlayerPrefs.SetInt ("Lion_Snow_Level2", 1);
								
								GUI_Controller.adcount = 0;
								DragonCounter.totalanimals = 4;
								GUI_Controller.time_Limit = LevelTime[24];
								GUI_Controller.Reward = 6000;
								GUI_Controller.hint = "Hunt Four Lion's by Sniper Gun.";
								Application.LoadLevel("Level9");
							}
						}
						else
						{
							if(GUI.Button(new Rect(originalWidth - 260, originalHeight - 150 , 220, 70), " 15000", buytyle))
							{
								coin = PlayerPrefs.GetInt ("Earnings");
								if(coin > 15000)
								{
									coin = PlayerPrefs.GetInt ("Earnings") - 15000;
									PlayerPrefs.SetInt ("Earnings", coin);
									buypopup = true;
									PlayerPrefs.SetInt("Level25", 1);
								}
								else
								{
									coinbox = true;
								}
							}
						}
					}
				}






			}
		}
		//coinbox = true;
		if(coinbox)
		{
			GUI.DrawTexture(new Rect(originalWidth/2 - 464.5f , originalHeight / 2 - 230, 929, 460), inappbox);
			GUI.Label(new Rect(145 , originalHeight/2 - 90, 300, 100), "You have insufficent cash.", inappstyle);
			GUI.Label(new Rect(145 , originalHeight/2 - 40 , 300, 100), "Hunt more to earn cash or", inappstyle);
			GUI.Label(new Rect(145 , originalHeight/2 - 5, 300, 100), "Buy from Store. ", inappstyle);
			//GUI.Label(new Rect(145 , originalHeight/2 + 15 , 300, 100), "Or Buy Cash from Store. ", inappstyle);	

			if(GUI.Button (new Rect ( originalWidth - 110, originalHeight / 2 - 253 , 74, 78), "", closestyle))
			{
				leveldes = false;
				coinbox = false;
			}
			if(GUI.Button (new Rect (originalWidth - 290 , originalHeight / 2  - 80, 223, 90), "", get400coins))
			{
//				OpenIAB.purchaseProduct(SKU_Coin_400);
			}
			if(GUI.Button (new Rect (originalWidth - 290 , originalHeight / 2 + 15, 223, 90),  "", get800coins))
			{
//				OpenIAB.purchaseProduct(SKU_Coin_800);
			}
			if(GUI.Button (new Rect (originalWidth - 290 , originalHeight / 2  + 110, 223, 90),  "", get1200coins))
			{
//				OpenIAB.purchaseProduct(SKU_Coin_1200);
			}
		}

		if(buypopup)
		{
			leveldes = false;
			GUI.DrawTexture(new Rect(originalWidth/2 - 225 , originalHeight / 2 - 150, 450, 300), warningpopup);
			GUI.DrawTexture(new Rect (originalWidth/2 - 160 , originalHeight/2 - 140, 300, 40), success);
			GUI.Label(new Rect(originalWidth/2 - 175 , originalHeight/2 - 70, 300, 100), "Level unlocked successfully.", warningstyle);
			GUI.Label(new Rect(originalWidth/2 - 175 , originalHeight/2 - 30 , 300, 100), "Play previous Levels to ", warningstyle);		
			GUI.Label(new Rect(originalWidth/2 - 175 , originalHeight/2 - 10 , 300, 100), "earn more cash.", warningstyle);
			StartCoroutine(waitforsuccess());
		}
		GUI.matrix = svMat;
	}
	IEnumerator waitforsuccess() 
	{
		yield return new WaitForSeconds (2.0f);
		buypopup = false;
		leveldes = true;
	}
	IEnumerator waitformenusound()
	{
		GetComponent<AudioSource>().PlayOneShot(btnaudio);
		yield return new WaitForSeconds (1.0f);
		#if UNITY_ANDROID
		Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Large);
		#endif
		Handheld.StartActivityIndicator();
		Application.LoadLevel("Newmenu");
	}


//	public AdRequest createAdRequest()
//	{
//		return new AdRequest.Builder()
//			//.AddTestDevice(AdRequest.TestDeviceSimulator)
//			//	.AddTestDevice("0123456789ABCDEF0123456789ABCDEF")
//			//	.AddKeyword("game")
//			//	.SetGender(Gender.Male)
//			//	.SetBirthday(new DateTime(1985, 1, 1))
//			//	.TagForChildDirectedTreatment(false)
//			//	.AddExtra("color_bg", "9B30FF")
//			.Build();
//		
//	}
//	#region Banner callback handlers	
	public void HandleAdLoaded(object sender, EventArgs args)
	{
		print("HandleAdLoaded event received.");
	}
	
//	public void HandleAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
//	{
////		print("HandleFailedToReceiveAd event received with message: " + args.Message);
//	}
	
	public void HandleAdOpened(object sender, EventArgs args)
	{
		print("HandleAdOpened event received");
	}
	
	public void HandleAdClosing(object sender, EventArgs args)
	{
		print("HandleAdClosing event received");
	}
	
	public void HandleAdClosed(object sender, EventArgs args)
	{
		print("HandleAdClosed event received");
	}
	
	public void HandleAdLeftApplication(object sender, EventArgs args)
	{
		print("HandleAdLeftApplication event received");
	}	
//	#endregion

	//INAPP PURCHASE Code Starts
	private void OnEnable()
	{
		// Listen to all events for illustration purposes
//		OpenIABEventManager.billingSupportedEvent += billingSupportedEvent;
//		OpenIABEventManager.billingNotSupportedEvent += billingNotSupportedEvent;
//		OpenIABEventManager.queryInventorySucceededEvent += queryInventorySucceededEvent;
//		OpenIABEventManager.queryInventoryFailedEvent += queryInventoryFailedEvent;
//		OpenIABEventManager.purchaseSucceededEvent += purchaseSucceededEvent;
//		OpenIABEventManager.purchaseFailedEvent += purchaseFailedEvent;
//		OpenIABEventManager.consumePurchaseSucceededEvent += consumePurchaseSucceededEvent;
//		OpenIABEventManager.consumePurchaseFailedEvent += consumePurchaseFailedEvent;
	}
	private void OnDisable()
	{
		// Remove all event handlers
//		OpenIABEventManager.billingSupportedEvent -= billingSupportedEvent;
//		OpenIABEventManager.billingNotSupportedEvent -= billingNotSupportedEvent;
//		OpenIABEventManager.queryInventorySucceededEvent -= queryInventorySucceededEvent;
//		OpenIABEventManager.queryInventoryFailedEvent -= queryInventoryFailedEvent;
//		OpenIABEventManager.purchaseSucceededEvent -= purchaseSucceededEvent;
//		OpenIABEventManager.purchaseFailedEvent -= purchaseFailedEvent;
//		OpenIABEventManager.consumePurchaseSucceededEvent -= consumePurchaseSucceededEvent;
//		OpenIABEventManager.consumePurchaseFailedEvent -= consumePurchaseFailedEvent;
	}
	void Initialize()
	{
		// Application public key
//		var publicKey = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAlQZI7+uaNopb14LT2S/NA1phcJ5f4Ujvvba57GB+mzIye+FbMxcYQRZxLpMbYsCJbio87cpqnCw9fo3i6kGifwcmT+6BXsb8kLfw44hG1dPH206AJZQHyy7DDzxzbHcMn/Fp8l8QiFFrQglAxYZqgNUM6JzY4a5irVSMXpM72Nydu4wRAxespYKtJvm0dB+QjHkCJIMLk2k5Uu69M7wjScfE1XhWqb8Z/QKAvAl2jcATDYlBRWTkK0j3QIoh4oI4b91lCwXlQ2CAwhAD7AncnYUd7UTA8DQSciOU/OKL7GkYJvD+pja1VxUk7VA4dt2gbQNuaTHeItRwTOQ55wsFDQIDAQAB";
//		var options = new Options();
//		options.checkInventoryTimeoutMs = Options.INVENTORY_CHECK_TIMEOUT_MS * 2;
//		options.discoveryTimeoutMs = Options.DISCOVER_TIMEOUT_MS * 2;
//		options.checkInventory = false;
//		//options.verifyMode = OptionsVerifyMode.VERIFY_SKIP;
//		options.verifyMode = OptionsVerifyMode.VERIFY_ONLY_KNOWN;
//		options.prefferedStoreNames = new string[] { OpenIAB_Android.STORE_GOOGLE };
//		options.availableStoreNames = new string[] { OpenIAB_Android.STORE_GOOGLE };
//		options.storeKeys = new Dictionary<string, string> { {OpenIAB_Android.STORE_GOOGLE, publicKey} };
//		options.storeSearchStrategy = SearchStrategy.INSTALLER_THEN_BEST_FIT;		
//		// Transmit options and start the service
//		OpenIAB.init(options);
	}
	private void billingSupportedEvent()
	{
		_isInitialized = true;
		Debug.Log("billingSupportedEvent");
	}
	private void billingNotSupportedEvent(string error)
	{
		Debug.Log("billingNotSupportedEvent: " + error);
	}
//	private void queryInventorySucceededEvent(Inventory inventory)
//	{
//		Debug.Log("queryInventorySucceededEvent: " + inventory);
//		if (inventory != null)
//		{
//			_label = inventory.ToString();
//			_inventory = inventory;
//		}
//	}
	private void queryInventoryFailedEvent(string error)
	{
		Debug.Log("queryInventoryFailedEvent: " + error);
		_label = error;
	}
//	private void purchaseSucceededEvent(Purchase purchase)
//	{
//		Debug.Log("purchaseSucceededEvent: " + purchase);
//		_label = "PURCHASED:" + purchase.ToString();
//		switch (purchase.Sku)
//		{
////			case SKU_Test:
////				coin = PlayerPrefs.GetInt ("Earnings") + 200;
////				PlayerPrefs.SetInt ("Earnings", coin);
////
////				OpenIAB.queryInventory(new string[] { SKU_Test });
////				if (_inventory != null && _inventory.HasPurchase(SKU_Test))
////					OpenIAB.consumeProduct(_inventory.GetPurchase(SKU_Test));
////				break;
//		case SKU_Coin_400:
//				coin = PlayerPrefs.GetInt ("Earnings") + 400;
//				PlayerPrefs.SetInt ("Earnings", coin);
//			
//				OpenIAB.queryInventory(new string[] { SKU_Coin_400 });
//				if (_inventory != null && _inventory.HasPurchase(SKU_Coin_400))
//					OpenIAB.consumeProduct(_inventory.GetPurchase(SKU_Coin_400));
//				break;
//		case SKU_Coin_800:
//				coin = PlayerPrefs.GetInt ("Earnings") + 800;
//				PlayerPrefs.SetInt ("Earnings", coin);
//			
//				OpenIAB.queryInventory(new string[] { SKU_Coin_800 });
//				if (_inventory != null && _inventory.HasPurchase(SKU_Coin_800))
//					OpenIAB.consumeProduct(_inventory.GetPurchase(SKU_Coin_800));
//				break;
//		case SKU_Coin_1200:
//				coin = PlayerPrefs.GetInt ("Earnings") + 1200;
//				PlayerPrefs.SetInt ("Earnings", coin);
//			
//				OpenIAB.queryInventory(new string[] { SKU_Coin_1200 });
//				if (_inventory != null && _inventory.HasPurchase(SKU_Coin_1200))
//					OpenIAB.consumeProduct(_inventory.GetPurchase(SKU_Coin_1200));
//				break;
//		}
//	}
	private void purchaseFailedEvent(int errorCode, string errorMessage)
	{
		Debug.Log("purchaseFailedEvent: " + errorMessage);
		_label = "Purchase Failed: " + errorMessage;
	}
//	private void consumePurchaseSucceededEvent(Purchase purchase)
//	{
//		Debug.Log("consumePurchaseSucceededEvent: " + purchase);
//		_label = "CONSUMED: " + purchase.ToString();
//	}
	private void consumePurchaseFailedEvent(string error)
	{
		Debug.Log("consumePurchaseFailedEvent: " + error);
		_label = "Consume Failed: " + error;
	}
	// OPEN IAB CODE ENDs
}

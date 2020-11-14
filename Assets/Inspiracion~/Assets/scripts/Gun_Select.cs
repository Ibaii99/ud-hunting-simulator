using UnityEngine;
using System.Collections;
//using OnePF;
using System.Collections.Generic;

public class Gun_Select : MonoBehaviour {

//	//IN APP Billing Start
//	const string SKU_Coin_1000 = "coins_unit_1000";
//	const string SKU_Coin_5000 = "coins_unit_500";
//	const string SKU_Coin_10000 = "coins_unit_10000";	
//	string _label = "";
//	bool _isInitialized = false;
//	Inventory _inventory = null;
//	// IN APP Billing End

	private float originalWidth = 1024.0f;
	private float originalHeight = 768.0f;
	private Vector3 scalegui;

	public GameObject Gun1;
	public GameObject Gun2;
	public GameObject Gun3;
	public GameObject Gun4;
	public GameObject Gun5;
	public GameObject Gun6;
	public GameObject Gun7;
	public GameObject Gun8;

	
	public GUIStyle nextbtn;
	public GUIStyle previousbtn;
	public GUIStyle backbtn;
	public GUIStyle cashstyle;

	public GUIStyle lblstyle;

	public GUIStyle Descriptionstyle;
	public GUIStyle DescriptionTextstyle;

	public GUIStyle equipStyle;
	public GUIStyle equipedStyle;
	public GUIStyle buyStyle1;



	public GUIStyle get1000coins;
	public GUIStyle get5000coins;
	public GUIStyle get10000coins;
	public GUIStyle closestyle;
	public GUIStyle inappstyle;

	public Texture labelBG;

	public Texture DescriptionBG;
	public Texture inappbox;
//		public Texture zeeshan;
	private int no = 1;
	private int cash;
	private int money;
	private bool coinbox = false;
	private int coin = 0;
	
	public AudioClip weaponEquipSound;
	public AudioClip buttonSound;

	public GUIStyle priceStyle;
	private string dummytext; 
	void Start()
	{
		if(PlayerPrefs.GetInt("Gun") == 0)
		{
			PlayerPrefs.SetInt("Gun",1);
		}
		coinbox = false;
		no = 1;

//		// INAPP starts
//		Initialize ();
//		if (!_isInitialized)
//			return;
//		OpenIAB.mapSku(SKU_Coin_1000, OpenIAB_Android.STORE_GOOGLE, "coins_unit_1000");
//		OpenIAB.mapSku(SKU_Coin_5000, OpenIAB_Android.STORE_GOOGLE, "coins_unit_500");
//		OpenIAB.mapSku(SKU_Coin_10000, OpenIAB_Android.STORE_GOOGLE, "coins_unit_10000");
//		// INAPP Ends	

//		PlayerPrefs.SetInt("Earnings", 150000000);

	}
	void OnGUI()
	{
		cash = PlayerPrefs.GetInt("Earnings");
		scalegui.x = Screen.width/originalWidth; // calculate hor scale
		scalegui.y = Screen.height/originalHeight; // calculate vert scale
		scalegui.z = 1.0f;
		var svMat= GUI.matrix; 
		GUI.matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity,scalegui);
//		GUI.Label (new Rect (originalWidth - 230, 70 , 200, 90), cash.ToString (), cashstyle);
		GUI.Label(new Rect(originalWidth - 140, 140,158, 36 ),cash.ToString (), cashstyle );
		GUI.DrawTexture(new Rect(originalWidth / 2 - 250 , originalHeight/ 2 - 150 , 500 , 90), labelBG);
		GUI.DrawTexture(new Rect(originalWidth / 2 - 410 , originalHeight/ 2 - 30 , 230 , 200), DescriptionBG);
		GUI.Label(new Rect(originalWidth / 2 - 400 , originalHeight/ 2 - 20 , 100 , 50 ),"Zoom : ", Descriptionstyle );
		GUI.Label(new Rect(originalWidth / 2 - 400 , originalHeight/ 2 + 20 , 100 , 50 ),"Power : ", Descriptionstyle );
		GUI.Label(new Rect(originalWidth / 2 - 400 , originalHeight/ 2 + 60 , 100 , 50 ),"Capacity : ", Descriptionstyle );
		GUI.Label(new Rect(originalWidth / 2 - 400 , originalHeight/ 2 + 100 , 100 , 50 ),"Stability : ", Descriptionstyle );
//				GUI.DrawTexture(new Rect(40 ,  50 , 300 , 150), zeeshan);

		if(!coinbox)
		{		
			if(no != 1)
			{
				if(GUI.Button(new Rect(25, originalHeight / 2, 53, 71),"", previousbtn))
				{
					GetComponent<AudioSource>().PlayOneShot(buttonSound);
					no = no - 1;
				}
			}
			if(no != 7)
			{
				if(GUI.Button(new Rect(originalWidth - 80, originalHeight / 2, 53, 71),"", nextbtn ))
				{
					GetComponent<AudioSource>().PlayOneShot(buttonSound);
					no = no + 1;
				}
			}
			if(no == 1)
			{
				GUI.Label (new Rect(originalWidth / 2 - 75 ,   originalHeight / 2 - 138 , 150 , 100), "M 24 - Bolt Action" , lblstyle);


				GUI.Label(new Rect(originalWidth / 2 - 290 , originalHeight/ 2 - 20 , 100 , 50 ),"2 x", DescriptionTextstyle );
				GUI.Label(new Rect(originalWidth / 2 - 290 , originalHeight/ 2 + 20 , 100 , 50 ),"65", DescriptionTextstyle );
				GUI.Label(new Rect(originalWidth / 2 - 290 , originalHeight/ 2 + 60 , 100 , 50 ),"1 Bullet", DescriptionTextstyle );
				GUI.Label(new Rect(originalWidth / 2 - 290 , originalHeight/ 2 + 100 , 100 , 50 ),"10 m", DescriptionTextstyle );

				Gun1.SetActive(true);	
				Gun2.SetActive(false);	
				Gun3.SetActive(false);	
				Gun4.SetActive(false);	
				Gun5.SetActive(false);	
				Gun6.SetActive(false);	
				Gun7.SetActive(false);	
				Gun8.SetActive(false);	
				//if(PlayerPrefs.GetInt("Gun1") == 1)
				//{
					if(PlayerPrefs.GetInt("Gun") != 1)
					{						
						if(GUI.Button(new Rect(originalWidth / 2 - 100 , originalHeight - 150 , 192 , 68 ) , "" , equipStyle))
						{
							PlayerPrefs.SetInt("Gun", 1);
							GetComponent<AudioSource>().PlayOneShot(weaponEquipSound);
						}
					}
					else
					{						
						GUI.Button(new Rect(originalWidth / 2 - 100 , originalHeight - 150 , 192 , 68 ) , "" , equipedStyle);
					}

			}
			if(no == 2)
			{
				GUI.Label (new Rect(originalWidth / 2 - 75 ,   originalHeight / 2 - 138 , 150 , 100), "Dragunov 2015" , lblstyle);

				GUI.Label(new Rect(originalWidth / 2 - 290 , originalHeight/ 2 - 20 , 100 , 50 ),"4 x", DescriptionTextstyle );
				GUI.Label(new Rect(originalWidth / 2 - 290 , originalHeight/ 2 + 20 , 100 , 50 ),"65", DescriptionTextstyle );
				GUI.Label(new Rect(originalWidth / 2 - 290 , originalHeight/ 2 + 60 , 100 , 50 ),"2 Bullet", DescriptionTextstyle );
				GUI.Label(new Rect(originalWidth / 2 - 290 , originalHeight/ 2 + 100 , 100 , 50 ),"15 m", DescriptionTextstyle );

				Gun1.SetActive(false);	
				Gun2.SetActive(true);	
				Gun3.SetActive(false);	
				Gun4.SetActive(false);	
				Gun5.SetActive(false);	
				Gun6.SetActive(false);	
				Gun7.SetActive(false);	
				Gun8.SetActive(false);	
				if(PlayerPrefs.GetInt("Gun2") == 1)
				{
					if(PlayerPrefs.GetInt("Gun") != 2)
					{
						
						if(GUI.Button(new Rect(originalWidth / 2 - 100 , originalHeight - 150 , 192 , 68 ) , "" , equipStyle))
						{
							PlayerPrefs.SetInt("Gun", 2);
							GetComponent<AudioSource>().PlayOneShot(weaponEquipSound);
						}
					}
					else
					{
						
						GUI.Button(new Rect(originalWidth / 2 - 100 , originalHeight - 150 , 192 , 68 ) , "" , equipedStyle);
					}
				}
				else
				{				
					
					GUI.Label(new Rect(originalWidth / 2 - 100 , originalHeight - 155 , 192 , 68), " $4000", priceStyle);
					if(GUI.Button(new Rect(originalWidth - 280,originalHeight - 80, 192, 68  ) , "", buyStyle1))
					{
						GetComponent<AudioSource>().PlayOneShot(buttonSound);
						if(cash >= 4000)
						{
							money = cash - 4000;
							PlayerPrefs.SetInt("Earnings", money);
							PlayerPrefs.SetInt("Gun2", 1);
						}
						else
						{
							coinbox = true;
						}
					}
				}
			}
			if(no == 3)
			{
				GUI.Label (new Rect(originalWidth / 2 - 75 ,   originalHeight / 2 - 138 , 150 , 100), "Magnum - Hunter's Edition" , lblstyle);
				GUI.Label(new Rect(originalWidth / 2 - 290 , originalHeight/ 2 - 20 , 100 , 50 ),"6 x", DescriptionTextstyle );
				GUI.Label(new Rect(originalWidth / 2 - 290 , originalHeight/ 2 + 20 , 100 , 50 ),"70", DescriptionTextstyle );
				GUI.Label(new Rect(originalWidth / 2 - 290 , originalHeight/ 2 + 60 , 100 , 50 ),"3 Bullet", DescriptionTextstyle );
				GUI.Label(new Rect(originalWidth / 2 - 290 , originalHeight/ 2 + 100 , 100 , 50 ),"25 m", DescriptionTextstyle );

				Gun1.SetActive(false);	
				Gun2.SetActive(false);	
				Gun3.SetActive(true);	
				Gun4.SetActive(false);	
				Gun5.SetActive(false);	
				Gun6.SetActive(false);	
				Gun7.SetActive(false);	
				Gun8.SetActive(false);	
				if(PlayerPrefs.GetInt("Gun3") == 1)
				{
					if(PlayerPrefs.GetInt("Gun") != 3)
					{
						
						if(GUI.Button(new Rect(originalWidth / 2 - 100 , originalHeight - 150 , 192 , 68 ) , "" , equipStyle))
						{
							PlayerPrefs.SetInt("Gun", 3);
							GetComponent<AudioSource>().PlayOneShot(weaponEquipSound);
						}
					}
					else
					{
						
						GUI.Button(new Rect(originalWidth / 2 - 100 , originalHeight - 150 , 192 , 68 ) , "" , equipedStyle);
					}
				}
				else
				{
					
					
					GUI.Label(new Rect(originalWidth / 2 - 100 , originalHeight - 155 , 192 , 68), " $6000", priceStyle);
					if(GUI.Button(new Rect(originalWidth - 280,originalHeight - 80, 192, 68  ) , "", buyStyle1))
					{
						GetComponent<AudioSource>().PlayOneShot(buttonSound);
						if(cash >= 6000)
						{
							money = cash - 6000;
							PlayerPrefs.SetInt("Earnings", money);
							PlayerPrefs.SetInt("Gun3", 1);
						}
						else
						{
							coinbox = true;
						}
					}
				}
			}		

			if(no == 4)
			{
				GUI.Label (new Rect(originalWidth / 2 - 75 ,   originalHeight / 2 - 138 , 150 , 100), "Scar 35 MOD" , lblstyle);
				GUI.Label(new Rect(originalWidth / 2 - 290 , originalHeight/ 2 - 20 , 100 , 50 ),"6 x", DescriptionTextstyle );
				GUI.Label(new Rect(originalWidth / 2 - 290 , originalHeight/ 2 + 20 , 100 , 50 ),"85", DescriptionTextstyle );
				GUI.Label(new Rect(originalWidth / 2 - 290 , originalHeight/ 2 + 60 , 100 , 50 ),"4 Bullet", DescriptionTextstyle );
				GUI.Label(new Rect(originalWidth / 2 - 290 , originalHeight/ 2 + 100 , 100 , 50 ),"25 m", DescriptionTextstyle );
				Gun1.SetActive(false);	
				Gun2.SetActive(false);	
				Gun3.SetActive(false);	
				Gun4.SetActive(true);	
				Gun5.SetActive(false);	
				Gun6.SetActive(false);	
				Gun7.SetActive(false);	
				Gun8.SetActive(false);	
				if(PlayerPrefs.GetInt("Gun4") == 1)
				{
					if(PlayerPrefs.GetInt("Gun") != 4)
					{
						
						if(GUI.Button(new Rect(originalWidth / 2 - 100 , originalHeight - 150 , 192 , 68 ) , "" , equipStyle))
						{
							PlayerPrefs.SetInt("Gun", 4);
							GetComponent<AudioSource>().PlayOneShot(weaponEquipSound);
						}
					}
					else
					{
						
						GUI.Button(new Rect(originalWidth / 2 - 100 , originalHeight - 150 , 192 , 68 ) , "" , equipedStyle);
					}
				}
				else
				{
					
					
					GUI.Label(new Rect(originalWidth / 2 - 100 , originalHeight - 155 , 192 , 68), " $8000", priceStyle);
					if(GUI.Button(new Rect(originalWidth - 280,originalHeight - 80, 192, 68  ) , "", buyStyle1))
					{
						GetComponent<AudioSource>().PlayOneShot(buttonSound);
						if(cash >= 8000)
						{
							money = cash - 8000;
							PlayerPrefs.SetInt("Earnings", money);
							PlayerPrefs.SetInt("Gun4", 1);
						}
						else
						{
							coinbox = true;
						}
					}
				}
			}
			if(no == 5)
			{
				GUI.Label (new Rect(originalWidth / 2 - 75 ,   originalHeight / 2 - 138 , 150 , 100), "Scout SSG 07" , lblstyle);
				GUI.Label(new Rect(originalWidth / 2 - 290 , originalHeight/ 2 - 20 , 100 , 50 ),"8 x", DescriptionTextstyle );
				GUI.Label(new Rect(originalWidth / 2 - 290 , originalHeight/ 2 + 20 , 100 , 50 ),"100", DescriptionTextstyle );
				GUI.Label(new Rect(originalWidth / 2 - 290 , originalHeight/ 2 + 60 , 100 , 50 ),"8 Bullet", DescriptionTextstyle );
				GUI.Label(new Rect(originalWidth / 2 - 290 , originalHeight/ 2 + 100 , 100 , 50 ),"20 m", DescriptionTextstyle );

				Gun1.SetActive(false);	
				Gun2.SetActive(false);	
				Gun3.SetActive(false);	
				Gun4.SetActive(false);	
				Gun5.SetActive(true);	
				Gun6.SetActive(false);	
				Gun7.SetActive(false);	
				Gun8.SetActive(false);	
				if(PlayerPrefs.GetInt("Gun5") == 1)
				{
					if(PlayerPrefs.GetInt("Gun") != 5)
					{
						
						if(GUI.Button(new Rect(originalWidth / 2 - 100 , originalHeight - 150 , 192 , 68 ) , "" , equipStyle))
						{
							PlayerPrefs.SetInt("Gun", 5);
							GetComponent<AudioSource>().PlayOneShot(weaponEquipSound);
						}
					}
					else
					{
						
						GUI.Button(new Rect(originalWidth / 2 - 100 , originalHeight - 150 , 192 , 68 ) , "" , equipedStyle);
					}
				}
				else
				{
					
					
					GUI.Label(new Rect(originalWidth / 2 - 100 , originalHeight - 155 , 192 , 68), " $10000", priceStyle);
					if(GUI.Button(new Rect(originalWidth - 280,originalHeight - 80, 192, 68  ) , "", buyStyle1))
					{
						GetComponent<AudioSource>().PlayOneShot(buttonSound);
						if(cash >= 10000)
						{
							money = cash - 10000;
							PlayerPrefs.SetInt("Earnings", money);
							PlayerPrefs.SetInt("Gun5", 1);
						}
						else
						{
							coinbox = true;
						}
					}
				}
			}			
			if(no == 6)
			{
				GUI.Label (new Rect(originalWidth / 2 - 75 ,   originalHeight / 2 - 138 , 150 , 100), "Badger - Hunter's Riffle" , lblstyle);
				GUI.Label(new Rect(originalWidth / 2 - 290 , originalHeight/ 2 - 20 , 100 , 50 ),"10 x", DescriptionTextstyle );
				GUI.Label(new Rect(originalWidth / 2 - 290 , originalHeight/ 2 + 20 , 100 , 50 ),"105", DescriptionTextstyle );
				GUI.Label(new Rect(originalWidth / 2 - 290 , originalHeight/ 2 + 60 , 100 , 50 ),"6 Bullet", DescriptionTextstyle );
				GUI.Label(new Rect(originalWidth / 2 - 290 , originalHeight/ 2 + 100 , 100 , 50 ),"35 m", DescriptionTextstyle );

				Gun1.SetActive(false);	
				Gun2.SetActive(false);	
				Gun3.SetActive(false);	
				Gun4.SetActive(false);	
				Gun5.SetActive(false);	
				Gun6.SetActive(true);	
				Gun7.SetActive(false);	
				Gun8.SetActive(false);	
				if(PlayerPrefs.GetInt("Gun6") == 1)
				{
					if(PlayerPrefs.GetInt("Gun") != 6)
					{
						
						if(GUI.Button(new Rect(originalWidth / 2 - 100 , originalHeight - 150 , 192 , 68 ) , "" , equipStyle))
						{
							PlayerPrefs.SetInt("Gun", 6);
							GetComponent<AudioSource>().PlayOneShot(weaponEquipSound);
						}
					}
					else
					{
						
						GUI.Button(new Rect(originalWidth / 2 - 100 , originalHeight - 150 , 192 , 68 ) , "" , equipedStyle);
					}
				}
				else
				{
					
					
					GUI.Label(new Rect(originalWidth / 2 - 100 , originalHeight - 155 , 192 , 68), " $12000", priceStyle);
					if(GUI.Button(new Rect(originalWidth - 280,originalHeight - 80, 192, 68  ) , "", buyStyle1))
					{
						GetComponent<AudioSource>().PlayOneShot(buttonSound);
						if(cash >= 12000)
						{
							money = cash - 12000;
							PlayerPrefs.SetInt("Earnings", money);
							PlayerPrefs.SetInt("Gun6", 1);
						}
						else
						{
							coinbox = true;
						}
					}
				}
			}
			if(no == 7)
			{
				GUI.Label (new Rect(originalWidth / 2 - 75 ,   originalHeight / 2 - 138 , 150 , 100), "AR 25 - Eliminator Edition" , lblstyle);
				GUI.Label(new Rect(originalWidth / 2 - 290 , originalHeight/ 2 - 20 , 100 , 50 ),"12 x", DescriptionTextstyle );
				GUI.Label(new Rect(originalWidth / 2 - 290 , originalHeight/ 2 + 20 , 100 , 50 ),"130", DescriptionTextstyle );
				GUI.Label(new Rect(originalWidth / 2 - 290 , originalHeight/ 2 + 60 , 100 , 50 ),"10 Bullet", DescriptionTextstyle );
				GUI.Label(new Rect(originalWidth / 2 - 290 , originalHeight/ 2 + 100 , 100 , 50 ),"50 m", DescriptionTextstyle );

				Gun1.SetActive(false);	
				Gun2.SetActive(false);	
				Gun3.SetActive(false);	
				Gun4.SetActive(false);	
				Gun5.SetActive(false);	
				Gun6.SetActive(false);	
				Gun7.SetActive(true);	
				Gun8.SetActive(false);	
				if(PlayerPrefs.GetInt("Gun7") == 1)
				{
					if(PlayerPrefs.GetInt("Gun") != 7)
					{
						if(GUI.Button(new Rect(originalWidth / 2 - 100 , originalHeight - 150 , 192 , 68 ) , "" , equipStyle))
						{
							PlayerPrefs.SetInt("Gun", 7);
							GetComponent<AudioSource>().PlayOneShot(weaponEquipSound);
						}
					}
					else
					{
						GUI.Button(new Rect(originalWidth / 2 - 100 , originalHeight - 150 , 192 , 68 ) , "" , equipedStyle);
					}
				}
				else
				{
					GUI.Label(new Rect(originalWidth / 2 - 100 , originalHeight - 155 , 192 , 68), " $15000", priceStyle);
					if(GUI.Button(new Rect(originalWidth - 280,originalHeight - 80, 192, 68  ) , "", buyStyle1))
					{
						GetComponent<AudioSource>().PlayOneShot(buttonSound);
						if(cash >= 15000)
						{
							money = cash - 15000;
							PlayerPrefs.SetInt("Earnings", money);
							PlayerPrefs.SetInt("Gun7", 1);
						}
						else
						{
							coinbox = true;
						}
					}
				}
			}
			
						if(GUI.Button(new Rect(10,originalHeight - 80,200,65) , "", backbtn))
			{
				StartCoroutine(waitforMenu());
			}
		}
		if(coinbox)
		{
			GUI.DrawTexture(new Rect(originalWidth/2 - 275 , originalHeight / 2 - 162, 550,324), inappbox);
//			GUI.Label(new Rect(originalWidth / 2 - 210 , originalHeight/2 - 120, 300, 100), "You have insufficent cash.", inappstyle);
//			GUI.Label(new Rect(originalWidth / 2 - 210 , originalHeight/2 - 90 , 300, 100), "Hunt more to earn cash or", inappstyle);
//			GUI.Label(new Rect(originalWidth / 2 - 210 , originalHeight/2 - 60, 300, 100), "Buy from Store. ", inappstyle);			
			if(GUI.Button (new Rect ( originalWidth / 2 + 230, originalHeight / 2 - 190 , 80, 80), "", closestyle))
			{
				GetComponent<AudioSource>().PlayOneShot(buttonSound);
				coinbox = false;
			}

//			if(GUI.Button (new Rect (originalWidth / 2 - 273  , originalHeight / 2 + 27, 182, 132), "", get1000coins))
//			{
//				audio.PlayOneShot(buttonSound);
////				OpenIAB.purchaseProduct(SKU_Coin_1000);
//			}
//			if(GUI.Button (new Rect (originalWidth / 2 - 91 , originalHeight / 2  + 27, 182, 132),  "", get5000coins))
//			{
//				audio.PlayOneShot(buttonSound);
////				OpenIAB.purchaseProduct(SKU_Coin_5000);
//			}
//			if(GUI.Button (new Rect (originalWidth / 2  + 91 , originalHeight / 2  + 27, 182, 132),  "", get10000coins))
//			{
//				audio.PlayOneShot(buttonSound);
////				OpenIAB.purchaseProduct(SKU_Coin_10000);
//			}
		}
		GUI.matrix = svMat; 
	}
	
	IEnumerator waitforMenu()
	{
		GetComponent<AudioSource>().PlayOneShot(buttonSound);
		yield return new WaitForSeconds (0.4f);
		#if UNITY_ANDROID
		Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Small);
		#endif
		Handheld.StartActivityIndicator();
		Application.LoadLevel("Newmenu");
	}


//	//INAPP PURCHASE Code Starts
//	private void OnEnable()
//	{
//		// Listen to all events for illustration purposes
//		OpenIABEventManager.billingSupportedEvent += billingSupportedEvent;
//		OpenIABEventManager.billingNotSupportedEvent += billingNotSupportedEvent;
//		OpenIABEventManager.queryInventorySucceededEvent += queryInventorySucceededEvent;
//		OpenIABEventManager.queryInventoryFailedEvent += queryInventoryFailedEvent;
//		OpenIABEventManager.purchaseSucceededEvent += purchaseSucceededEvent;
//		OpenIABEventManager.purchaseFailedEvent += purchaseFailedEvent;
//		OpenIABEventManager.consumePurchaseSucceededEvent += consumePurchaseSucceededEvent;
//		OpenIABEventManager.consumePurchaseFailedEvent += consumePurchaseFailedEvent;
//	}
//	private void OnDisable()
//	{
//		// Remove all event handlers
//		OpenIABEventManager.billingSupportedEvent -= billingSupportedEvent;
//		OpenIABEventManager.billingNotSupportedEvent -= billingNotSupportedEvent;
//		OpenIABEventManager.queryInventorySucceededEvent -= queryInventorySucceededEvent;
//		OpenIABEventManager.queryInventoryFailedEvent -= queryInventoryFailedEvent;
//		OpenIABEventManager.purchaseSucceededEvent -= purchaseSucceededEvent;
//		OpenIABEventManager.purchaseFailedEvent -= purchaseFailedEvent;
//		OpenIABEventManager.consumePurchaseSucceededEvent -= consumePurchaseSucceededEvent;
//		OpenIABEventManager.consumePurchaseFailedEvent -= consumePurchaseFailedEvent;
//	}
//	void Initialize()
//	{
//		// Application public key
//		var publicKey = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAkQWXnqg2CUx1Sugz0sQfaN5MCDS8yAu1hrYxut/vSAo6aNnmRKGUMjEszlkqGB+6W5hJ4PGh0HoFKR+IgnVFwzVOfdw1qh2c5b8xHRUB6ExDow7dUm94cyQmQ88qJJCQ34+CJWKrynZPsW2LzcFWZsRa+4U13rSoUPQcEfDfa/nTp4aLxCgjCVWsO748Kx2g5cMbfbF8nUL+NP5V0pQlUv5ScBsEXyX3rZcmRChaU5V3PcxIAGeGC258VBD1YRykDIfsaEDLGBLw7j/RvBulPrwdrrAt10RaxD5YGBIsrYR+vIjUR7zDKz6CHYas5lIS18P/xNhHZM7PJG7tDuMx0wIDAQAB";
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
//	}
//	private void billingSupportedEvent()
//	{
//		_isInitialized = true;
//		Debug.Log("billingSupportedEvent");
//	}
//	private void billingNotSupportedEvent(string error)
//	{
//		Debug.Log("billingNotSupportedEvent: " + error);
//	}
//	private void queryInventorySucceededEvent(Inventory inventory)
//	{
//		Debug.Log("queryInventorySucceededEvent: " + inventory);
//		if (inventory != null)
//		{
//			_label = inventory.ToString();
//			_inventory = inventory;
//		}
//	}
//	private void queryInventoryFailedEvent(string error)
//	{
//		Debug.Log("queryInventoryFailedEvent: " + error);
//		_label = error;
//	}
//	private void purchaseSucceededEvent(Purchase purchase)
//	{
//		Debug.Log("purchaseSucceededEvent: " + purchase);
//		_label = "PURCHASED:" + purchase.ToString();
//		switch (purchase.Sku)
//		{
//		case SKU_Coin_1000:
//			coin = PlayerPrefs.GetInt ("Earnings") + 1000;
//			PlayerPrefs.SetInt ("Earnings", coin);
//			dummytext = "inapp successfull";
//			OpenIAB.queryInventory(new string[] { SKU_Coin_1000 });
//			if (_inventory != null && _inventory.HasPurchase(SKU_Coin_1000))
//				OpenIAB.consumeProduct(_inventory.GetPurchase(SKU_Coin_1000));
//			break;
//		case SKU_Coin_5000:
//			coin = PlayerPrefs.GetInt ("Earnings") + 5000;
//			PlayerPrefs.SetInt ("Earnings", coin);
//			dummytext = "inapp successfull";
//			OpenIAB.queryInventory(new string[] { SKU_Coin_5000 });
//			if (_inventory != null && _inventory.HasPurchase(SKU_Coin_5000))
//				OpenIAB.consumeProduct(_inventory.GetPurchase(SKU_Coin_5000));
//			break;
//		case SKU_Coin_10000:
//			coin = PlayerPrefs.GetInt ("Earnings") + 10000;
//			PlayerPrefs.SetInt ("Earnings", coin);
//			
//			OpenIAB.queryInventory(new string[] { SKU_Coin_10000 });
//			if (_inventory != null && _inventory.HasPurchase(SKU_Coin_10000))
//				OpenIAB.consumeProduct(_inventory.GetPurchase(SKU_Coin_10000));
//			break;
//		}
//	}
//	private void purchaseFailedEvent(int errorCode, string errorMessage)
//	{
//		Debug.Log("purchaseFailedEvent: " + errorMessage);
//		_label = "Purchase Failed: " + errorMessage;
//	}
//	private void consumePurchaseSucceededEvent(Purchase purchase)
//	{
//		Debug.Log("consumePurchaseSucceededEvent: " + purchase);
//		_label = "CONSUMED: " + purchase.ToString();
//	}
//	private void consumePurchaseFailedEvent(string error)
//	{
//		Debug.Log("consumePurchaseFailedEvent: " + error);
//		_label = "Consume Failed: " + error;
//	}
//	// OPEN IAB CODE ENDs

}
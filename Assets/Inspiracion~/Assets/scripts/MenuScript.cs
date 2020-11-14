using UnityEngine;
using System.Collections;
//using OnePF;
using System.Collections.Generic;

using UnityEngine.UI;
using System;

public class MenuScript : MonoBehaviour {
	// INAPP CODE Starts
	const string SKU_Ads_Free = "buy_remove_ads";	
	string _label = "";
	bool _isInitialized = false;
//	Inventory _inventory = null;
	// INAPP CODE Ends
	private float originalWidth = 1024.0f;
	private float originalHeight = 768.0f;
	private Vector3 scale;
	public static bool gamestart = true;
	public AudioClip btnaudio;
	public GUIStyle btnstyle;
	public GUIStyle playstyle;
	public GUIStyle morestyle;
	public GUIStyle ratestyle;
	public GUIStyle musicon;
	public GUIStyle musicoff;
	public GUIStyle soundon;
	public GUIStyle soundoff;
	public Texture logo;
	public Texture exitbg;
	public GUIStyle yesstyle;
	public GUIStyle nostyle;
	public GUIStyle empty;
	private bool exitdialogue = false;
	private float Buttonplay = 0f;
	private float Buttonmore = 0f;
	private float Buttonrate = 0f;
	private float Buttonaudio = 0f;
	private float logoanimation = -300f;
	private bool soundbtn = false;
	private bool btnratestate = false;
	private bool btnmorestate = false;

	private bool adfreepurchased = false;
	public GUIStyle stopads;
	public GUIStyle freecoins;

	public bool showcoinfree = true;


//	//unity ads code start	
//	[SerializeField] string gameID = "71559";	
//	public void ShowAd(string zone = "rewardedVideoZone")
//	{
//		#if UNITY_EDITOR
//		StartCoroutine(WaitForAd ());
//		#endif
//		
//		if (string.Equals (zone, "rewardedVideoZone"))
//			zone = null;
//		
//		ShowOptions options = new ShowOptions ();
//		options.resultCallback = AdCallbackhandler;
//		
//		if (Advertisement.isReady (zone))
//			Advertisement.Show (zone, options);
//	}	
//	void AdCallbackhandler (ShowResult result)
//	{
//		switch(result)
//		{
//			case ShowResult.Finished:
//				Debug.Log ("Ad Finished. Rewarding player...");
//				StartCoroutine(showfreecoinsbutton());
//				showcoinfree = false;
//				PlayerPrefs.SetInt ("Earnings", PlayerPrefs.GetInt ("Earnings") + 100);
//				break;
//			case ShowResult.Skipped:
//				Debug.Log ("Ad skipped. Son, I am dissapointed in you");
//				break;
//			case ShowResult.Failed:
//				Debug.Log("I swear this has never happened to me before");
//				break;
//		}
//	}	
//	IEnumerator WaitForAd()
//	{
//		float currentTimeScale = Time.timeScale;
//		Time.timeScale = 0f;
//		yield return null;
//		
//		while (Advertisement.isShowing)
//			yield return null;
//		
//		Time.timeScale = currentTimeScale;
//	}
//	//unity ads code ends
	void Awake()
	{
		showcoinfree = true;

		if(PlayerPrefs.GetInt("AdFree") != 1)
		{
			PlayerPrefs.SetInt("AdFree", 0);
		}
		Time.timeScale = 1;
		Buttonplay = 0.0f;
		Buttonmore = 0.0f;
		Buttonrate = 0.0f;
		logoanimation = -300f;
		Buttonaudio = 400f;
		soundbtn = false;
		btnratestate = false;
		btnmorestate = false;
		exitdialogue = false;
		if(PlayerPrefs.GetInt("AdFree") != 1)
		{
//			GoogleMobileAdsDemoScript.RequestBanner ();
		}

//		//unity ads integration start
		
//		Advertisement.Initialize (gameID, true);		
//		//unity ads integration ends
	}
	void Start()
	{
		if(PlayerPrefs.GetInt("AdFree") != 1)
		{
//			GoogleMobileAdsDemoScript.bannerView.Show();
		}
		if(PlayerPrefs.GetInt("Music") == 0)
		{
			PlayerPrefs.SetInt("Music",1);
		}
		if(PlayerPrefs.GetInt("FX") == 0)
		{
			PlayerPrefs.SetInt("FX",1); 
		}
		// INAPP starts
		Initialize ();
		if (!_isInitialized)
			return;
//		OpenIAB.mapSku(SKU_Ads_Free, OpenIAB_Android.STORE_GOOGLE, "buy_remove_ads");
		// INAPP Ends
	}
	void Update()
	{


		if(Input.GetKeyDown(KeyCode.Escape))
		{
			exitdialogue = true;
		}

		if(logoanimation < 10)
		{
			logoanimation += (Time.deltaTime * 300.0f);
		}
		else if(logoanimation >= 10)
		{
			logoanimation = 10.0f;
		}
		if(Buttonplay < 342)
		{
			Buttonplay += (Time.deltaTime * 400.0f);
		}
		else if(Buttonplay >= 342)
		{
			Buttonplay = 342.0f;
			btnratestate = true;
		}
		if(btnratestate)
		{
			if(Buttonrate < 278)
			{
				Buttonrate += (Time.deltaTime * 400.0f);
			}
			else if(Buttonrate >= 278)
			{
				Buttonrate = 278.0f;
				btnmorestate = true;
			}
		}
		if(btnmorestate)
		{
			if(Buttonmore < 278)
			{
				Buttonmore += (Time.deltaTime * 400.0f);
			}
			else if(Buttonmore >= 278)
			{
				Buttonmore = 278.0f;
				soundbtn = true;
			}
		}	
		if(soundbtn)
		{
			if(Buttonaudio > 260)
			{
				Buttonaudio -= (Time.deltaTime * 300.0f);
			}
			else if(Buttonaudio <= 260)
			{
				Buttonaudio = 260.0f;
			}
		}
	}	
	void  OnGUI (){
		scale.x = Screen.width/originalWidth; // calculate hor scale
		scale.y = Screen.height/originalHeight; // calculate vert scale
		scale.z = 1.0f;
		var svMat= GUI.matrix; 
		GUI.matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity,scale);
		GUI.DrawTexture (new Rect(originalWidth / 2 - 271, logoanimation, 542, 300), logo);

		//if(PlayerPrefs.GetInt("AdFree") != 1)
		{
			if(GUI.Button(new Rect(0, originalHeight -  300, 232, 149), "", stopads))
			{
//				OpenIAB.purchaseProduct(SKU_Ads_Free);				
			}
		}
		if(showcoinfree)
		{
			if(GUI.Button (new Rect(0, originalHeight  - 140, 232, 129), "" , freecoins))
			{			
//				ShowAd();	
				StartCoroutine(showfreecoinsbutton());
				showcoinfree = false;
			}
		}

		if(exitdialogue == true)
		{
			GUI.DrawTexture(new Rect (originalWidth/2 - 281, originalHeight/2 - 77,562, 350 ),exitbg);		
			if(GUI.Button(new Rect(originalWidth/2 - 235 , originalHeight/2 + 150 ,230, 70),"", yesstyle))
			{
				Application.OpenURL ("https://play.google.com/store/apps/details?id=com.rvx.jungle.sniper.hunting2");
			}
			if(GUI.Button(new Rect(originalWidth/2 + 5  , originalHeight/2 + 150 ,230, 70),"", nostyle))
			{
				Application.Quit();
			}
		}

		if(!exitdialogue)
		{
			if(GUI.Button(new Rect(originalWidth - Buttonplay , originalHeight / 2 + 40, 342, 119),"", playstyle ))
			{ 
				if(PlayerPrefs.GetInt("FX") == 1)
				{ 
					Debug.Log("audio playstyle");
					StartCoroutine(waitforlevelsound());
				}
				else
				{
					#if UNITY_ANDROID
					Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Large);
					#endif
					Handheld.StartActivityIndicator();
					Application.LoadLevel("LevelSelection"); 	
				}
//				GoogleMobileAdsDemoScript.bannerView.Hide();
				gamestart = false;
			}


			if(GUI.Button(new Rect(originalWidth - Buttonrate, originalHeight/2 + 160, 278, 102),"", ratestyle))
			{
				if(PlayerPrefs.GetInt("FX") == 1)
				{
					GetComponent<AudioSource>().PlayOneShot(btnaudio);
				}
				Application.OpenURL ("https://play.google.com/store/apps/details?id=com.rvx.jungle.sniper.hunting2");			
			} 

			if(GUI.Button(new Rect(originalWidth - Buttonmore, originalHeight/2 + 260, 278, 102),"", morestyle))
			{
				if(PlayerPrefs.GetInt("FX") == 1)
				{
					GetComponent<AudioSource>().PlayOneShot(btnaudio);
				}
				Application.OpenURL ("https://play.google.com/store/apps/developer?id=RationalVerx+Games+Studio");
			} 	

//			if(PlayerPrefs.GetInt("Music") == 1)
//			{
//				if(GUI.Button(new Rect( 20, originalHeight/2 + Buttonaudio, 106, 97),"", musicon))
//				{
//					if(PlayerPrefs.GetInt("FX") == 1)
//					{
//						audio.PlayOneShot(btnaudio);
//					}
//					PlayerPrefs.SetInt("Music",2);
//				}
//			}
//			if(PlayerPrefs.GetInt("Music") == 2)
//			{
//				if(GUI.Button(new Rect( 20, originalHeight/2 + Buttonaudio, 106, 97),"", musicoff))
//				{
//					if(PlayerPrefs.GetInt("FX") == 1)
//					{
//						audio.PlayOneShot(btnaudio);
//					}
//					PlayerPrefs.SetInt("Music",1);
//				}
//			}
//			if(PlayerPrefs.GetInt("FX") == 1)
//			{
//				if(GUI.Button(new Rect( 120, originalHeight/2 + Buttonaudio, 106, 97),"", soundon))
//				{
//					if(PlayerPrefs.GetInt("FX") == 1)
//					{
//						audio.PlayOneShot(btnaudio);
//					}
//					PlayerPrefs.SetInt("FX",2);
//				}
//			}
//			if(PlayerPrefs.GetInt("FX") == 2)
//			{
//				if(GUI.Button(new Rect( 120, originalHeight/2 + Buttonaudio, 106, 97),"", soundoff))
//				{
//					if(PlayerPrefs.GetInt("FX") == 1)
//					{
//						audio.PlayOneShot(btnaudio);
//					}
//					PlayerPrefs.SetInt("FX",1);
//				}
//			}
		}

//		if(GUI.Button(new Rect (originalWidth / 2 - 400, originalHeight / 2 + 40, 100, 100), "querry"))
//		{
//			OpenIAB.queryInventory(new string[] { "buy_remove_ads" });
//		}
//		if(GUI.Button(new Rect (originalWidth / 2 - 400, originalHeight / 2 + 140, 100, 100), "consume"))
//		{
//			if (_inventory != null && _inventory.HasPurchase("buy_remove_ads"))
//				OpenIAB.consumeProduct(_inventory.GetPurchase("buy_remove_ads"));
//		}

	//	GUI.Label (new Rect (originalWidth / 2 - 400, originalHeight / 2, 400, 200), _label);


		GUI.matrix = svMat; 
	}

	IEnumerator showfreecoinsbutton()
	{
		yield return new WaitForSeconds (30.0f);
		showcoinfree = true;	
	}
	IEnumerator waitforlevelsound()
	{
		GetComponent<AudioSource>().PlayOneShot(btnaudio, 1.0f);
		yield return new WaitForSeconds (1.0f);
		#if UNITY_ANDROID
		Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Large);
		#endif
		Handheld.StartActivityIndicator();
		Application.LoadLevel("LevelSelection");
	}
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
////			_label = inventory.GetPurchase(SKU_Ads_Free).Sku;
////			_inventory = inventory;
//			//switch (inventory.GetSkuDetails(SKU_Ads_Free))
//		}
//	}
	private void queryInventoryFailedEvent(string error)
	{

		Debug.Log("queryInventoryFailedEvent: " + error);
		_label = "querry failed " + error;
		if(error.Contains("querying owned items"))
		{
			_label = "item already purchased";
			//PlayerPrefs.SetInt("AdFree", 1);
			adfreepurchased = true;
		}
		else 
		{
			_label = "item not purchased";
			adfreepurchased = false;
		}
	}
//	private void purchaseSucceededEvent(Purchase purchase)
//	{
//		Debug.Log("purchaseSucceededEvent: " + purchase);
//		//_label = "PURCHASED:" + purchase.ToString();
//		switch (purchase.Sku)
//		{
//			case SKU_Ads_Free:
//				PlayerPrefs.SetInt("AdFree", 1);			
////				OpenIAB.queryInventory(new string[] { SKU_Ads_Free });
////				if (_inventory != null && _inventory.HasPurchase(SKU_Ads_Free))
////					OpenIAB.consumeProduct(_inventory.GetPurchase(SKU_Ads_Free));
//				break;
//		}
//	}
	private void purchaseFailedEvent(int errorCode, string errorMessage)
	{
		Debug.Log("purchaseFailedEvent: " + errorMessage);
		//_label = "Purchase Failed: " + errorMessage;
	}
//	private void consumePurchaseSucceededEvent(Purchase purchase)
//	{
//		Debug.Log("consumePurchaseSucceededEvent: " + purchase);
//		//_label = "CONSUMED: " + purchase.ToString();
//	}
	private void consumePurchaseFailedEvent(string error)
	{
		Debug.Log("consumePurchaseFailedEvent: " + error);
		//_label = "Consume Failed: " + error;
	}
	// OPEN IAB CODE ENDs
}
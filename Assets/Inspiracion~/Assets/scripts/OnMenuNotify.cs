

using UnityEngine;
using System.Collections;

public class OnMenuNotify : MonoBehaviour {
	

	public GameObject loadingText = null;


	public void PlayGame ()
	{
		Time.timeScale = 1.0f;
		Debug.Log ("PlayGame");
		Application.LoadLevel ("Levels");
	}


	public void onMusicClick ()
	{
			
	}


	public void onSoundClick ()
	{
		
	}

	public void dispMenu ()
	{
		Debug.Log ("dispMenu");	
		
		Application.LoadLevel ("mainmenu");
		
	}
	public void ExitGame ()
	{
		
		Application.Quit();
		
	}
	
	
	public void playAnimSound ()
	{
		//NGUITools.PlaySound (animSound, (float)1.0);
		
	}
	

	
	void  Awake (){
		
		 //ChartBoostAndroid.init ("539572b31873da32bc478673", "834827bb3abf53c550428d58ae19cbc9829039d1"); 
	//	ChartBoostAndroid.onStart ();
	//	ChartBoostAndroid.showInterstitial ("default");
	//	musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume",1.0f);;
	//	audio.volume = musicVolumeSlider.value;
		
	}
	
	// Use this for initialization
	void Start () {
		
	//	musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume",1.0f);;
	//	audio.volume = musicVolumeSlider.value;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.Escape)) {	
			
			Application.Quit ();
		}
		
	}
}

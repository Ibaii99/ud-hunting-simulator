using UnityEngine;
using System.Collections;

public class bgmusic : MonoBehaviour {
	public AudioClip bgmusicaud;
	public float clipLength ;
	void Update () 
	{
		if (PlayerPrefs.GetInt("Music")==1) 
		{
			if (!GetComponent<AudioSource>().isPlaying) 
			{
				GetComponent<AudioSource>().PlayOneShot (bgmusicaud); 
				GetComponent<AudioSource>().Play (); 						
			}
		}
		else if (PlayerPrefs.GetInt("Music")== 2) 
		{
			GetComponent<AudioSource>().Stop();
		
		}
	}
}

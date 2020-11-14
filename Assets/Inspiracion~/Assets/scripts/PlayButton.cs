using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour {

	public Texture2D normalTexture;
	public Texture2D hoverTexture; 
	
	public AudioClip btnClick;

	void Start()
	{
		PlayerPrefs.SetInt ("FX", 1);
		Time.timeScale = 1;
		GetComponent<GUITexture>().texture = normalTexture;
	}

	void OnMouseEnter () 
	{
		GetComponent<GUITexture>().texture = hoverTexture;
	}
	
	void OnMouseExit()
	{
		GetComponent<GUITexture>().texture = normalTexture;
	}
	
	void OnMouseDown()
	{
		if(PlayerPrefs.GetInt("soundfx") == 1)
		{
			GetComponent<AudioSource>().PlayOneShot(btnClick);
		}
		LoadingImage.loadingstart = true;
		Application.LoadLevel ("AnimalSelection");		
	}
}

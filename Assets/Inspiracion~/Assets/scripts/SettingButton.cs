using UnityEngine;
using System.Collections;

public class SettingButton : MonoBehaviour {
	public Texture2D normalTexture;
	public Texture2D hoverTexture; 
	
	public AudioClip btnClick;
	
	void Start()
	{
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
		
//		Application.LoadLevel ("AnimalSelection");		
	}
}

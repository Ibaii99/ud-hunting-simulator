using UnityEngine;
using System.Collections;

public class GunHanddle : MonoBehaviour
{

	public Gun[] Guns;
	public int GunIndex;
	[HideInInspector]
	public Gun CurrentGun;
	void Start ()
	{
		Debug.Log (PlayerPrefs.GetInt ("Gun"));
		//PlayerPrefs.SetInt("Gun", 2);	
		
		if(PlayerPrefs.GetInt("Gun") == 1)
		{
			for(int i=0;i<Guns.Length;i++){
				Hide(Guns[i].gameObject,false);
				Guns[i].SetActive(false);
			}
			GunIndex = 0;
			CurrentGun = Guns [GunIndex].gameObject.GetComponent<Gun> ();
			Hide(Guns[GunIndex].gameObject,true);
			Guns[GunIndex].SetActive(true);
		}
		if(PlayerPrefs.GetInt("Gun") == 2)
		{
			for(int i=0;i<Guns.Length;i++){
				Hide(Guns[i].gameObject,false);
				Guns[i].SetActive(false);
			}				
			GunIndex = 1;
			CurrentGun = Guns [GunIndex].gameObject.GetComponent<Gun> ();
			Hide(Guns[GunIndex].gameObject,true);
			Guns[GunIndex].SetActive(true);
		}
		if(PlayerPrefs.GetInt("Gun") == 3)
		{
			for(int i=0;i<Guns.Length;i++){
				Hide(Guns[i].gameObject,false);
				Guns[i].SetActive(false);
			}				
			GunIndex = 2;
			CurrentGun = Guns [GunIndex].gameObject.GetComponent<Gun> ();
			Hide(Guns[GunIndex].gameObject,true);
			Guns[GunIndex].SetActive(true);
		}
		if(PlayerPrefs.GetInt("Gun") == 4)
		{
			for(int i=0;i<Guns.Length;i++){
				Hide(Guns[i].gameObject,false);
				Guns[i].SetActive(false);
			}				
			GunIndex = 3;
			CurrentGun = Guns [GunIndex].gameObject.GetComponent<Gun> ();
			Hide(Guns[GunIndex].gameObject,true);
			Guns[GunIndex].SetActive(true);
		}
		if(PlayerPrefs.GetInt("Gun") == 5)
		{
			for(int i=0;i<Guns.Length;i++){
				Hide(Guns[i].gameObject,false);
				Guns[i].SetActive(false);
			}				
			GunIndex = 4;
			CurrentGun = Guns [GunIndex].gameObject.GetComponent<Gun> ();
			Hide(Guns[GunIndex].gameObject,true);
			Guns[GunIndex].SetActive(true);
		}
		if(PlayerPrefs.GetInt("Gun") == 6)
		{
			for(int i=0;i<Guns.Length;i++){
				Hide(Guns[i].gameObject,false);
				Guns[i].SetActive(false);
			}				
			GunIndex = 5;
			CurrentGun = Guns [GunIndex].gameObject.GetComponent<Gun> ();
			Hide(Guns[GunIndex].gameObject,true);
			Guns[GunIndex].SetActive(true);
		}
		if(PlayerPrefs.GetInt("Gun") == 7)
		{
			for(int i=0;i<Guns.Length;i++){
				Hide(Guns[i].gameObject,false);
				Guns[i].SetActive(false);
			}				
			GunIndex = 6;
			CurrentGun = Guns [GunIndex].gameObject.GetComponent<Gun> ();
			Hide(Guns[GunIndex].gameObject,true);
			Guns[GunIndex].SetActive(true);
		}
		if(PlayerPrefs.GetInt("Gun") == 8)
		{
			for(int i=0;i<Guns.Length;i++){
				Hide(Guns[i].gameObject,false);
				Guns[i].SetActive(false);
			}				
			GunIndex = 7;
			CurrentGun = Guns [GunIndex].gameObject.GetComponent<Gun> ();
			Hide(Guns[GunIndex].gameObject,true);
			Guns[GunIndex].SetActive(true);
		}
		
		//
		//		if (Guns.Length < 1) {
		//			Guns = this.gameObject.GetComponentsInChildren<Gun>();
		//		}
		//		SwitchGun (0);
	}
	void Update()
	{
		
	}
	
	void Hide(GameObject gameObject,bool show){
		/*Renderer[] renderers = gameObject.GetComponentsInChildren<Renderer>();
    	foreach (Renderer r in renderers) {
        	r.enabled = show;
    	}*/
	}
	
	public void Zoom ()
	{
		if (CurrentGun)
			CurrentGun.Zoom ();
	}
	
	public void Reload(){
		if (CurrentGun)
			CurrentGun.Reload();
	}
	
	public void ZoomAdjust (int delta)
	{
		if (CurrentGun)
			CurrentGun.ZoomDelta (delta);
	}
	
	public void SwitchGun (int index)
	{
		for(int i=0;i<Guns.Length;i++){
			Hide(Guns[i].gameObject,false);
			Guns[i].SetActive(false);
		}
		if (Guns.Length > 0 && index < Guns.Length && index >= 0) {
			GunIndex = index;
			CurrentGun = Guns [GunIndex].gameObject.GetComponent<Gun> ();
			Hide(Guns[GunIndex].gameObject,true);
			Guns[GunIndex].SetActive(true);
		}
	}
	public void SwitchGun ()
	{
		int index = GunIndex+1;
		if(index>= Guns.Length)
			index = 0;
		
		SwitchGun(index);
	}
	
	public void Shoot ()
	{
		if (CurrentGun)
			CurrentGun.Shoot ();
	}
	
	public void HoldBreath (int noiseMult)
	{
		if (CurrentGun)
			CurrentGun.FPSmotor.Holdbreath (noiseMult);
	}
}

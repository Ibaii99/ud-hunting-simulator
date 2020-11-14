using UnityEngine;
using System.Collections;
public class waterSound : MonoBehaviour {
	public AudioSource source;
	void Start () {	
		if (PlayerPrefs.GetInt ("FX") == 1) 
		{		
			source.enabled = true;
		}
		else
		{
			source.enabled = false;
		}
	}
}

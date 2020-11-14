using UnityEngine;
using System.Collections;

public class LoadingImage : MonoBehaviour {
	public static bool loadingstart = false;
	// Use this for initialization
	void Start () 
	{
		loadingstart = false;
		GetComponent<GUITexture>().enabled = false;
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(loadingstart)
		{
			GetComponent<GUITexture>().enabled = true;
		}	
	}

}

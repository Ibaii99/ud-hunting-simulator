using UnityEngine;
using System.Collections;
public class Coins : MonoBehaviour
{
	public static int earning = 0;
	void Start () 
	{	
		//earning = PlayerPrefs.GetInt ("Earnings");
		if(PlayerPrefs.GetInt ("Earnings") == 0)
		{
			PlayerPrefs.SetInt("Earnings", 600);
		}
		else
		{
			earning = PlayerPrefs.GetInt ("Earnings");
		}
	}
	void Update () 
	{
		earning = PlayerPrefs.GetInt ("Earnings");
//		Debug.Log ("total Income " + earning);
	}
}

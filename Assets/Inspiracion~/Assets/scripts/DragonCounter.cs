using UnityEngine;
using System.Collections;
public class DragonCounter : MonoBehaviour 
{
	public static int killedanimals = 0;
	public static int totalanimals;

	public static int headshoots = 0;
	public static int bodyshoots = 0;
	public int totalkilled = 0;
	//public int dummyanimals;
	void Start()
	{
		totalkilled = 0;
		headshoots = 0;
		bodyshoots = 0;

		killedanimals = 0;
	}
	void Update () 
	{
		totalkilled = headshoots + bodyshoots;
		if(totalkilled >= totalanimals)
		{
			GUI_Controller.timerstop = true;
			StartCoroutine(waitcomplete());
		}
	
		if(killedanimals == totalanimals)
		{
			GUI_Controller.timerstop = true;
			StartCoroutine(waitcomplete());
		}	
	}
	IEnumerator waitcomplete()
	{
		yield return new WaitForSeconds (2.0f);
		GUI_Controller.missionsuccess = true;
		GUI_Controller.missionfailed = false;
	}
}

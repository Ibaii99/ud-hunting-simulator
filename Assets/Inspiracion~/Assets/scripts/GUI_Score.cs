using UnityEngine;
using System.Collections;


public class GUI_Score : MonoBehaviour {
	
	public static int score;
	void Awake () {	 
		score = 0;
	}
	
	// Update is called once per frame
	void OnGUI () {
		
		//GUI.skin.box.fontSize=100;
		//GUIStyle style = new GUIStyle ();
		//style.fontSize = 100;
		

		
		//GUI.Label(new Rect(20,20,100,30)," Score: " + score);
		//GUI.Box (new Rect (10,10,100,40), "");
	}
}
using UnityEngine;
using System.Collections;

public class HowTo : MonoBehaviour {
	//faw variable


	string presetname = "Random Presets";
	
	void OnGUI(){
		//GUI.TextArea(new Rect(-200, 90, 150, 30),"\n  How to play\n\n   - Shoot :Left Mouse\n   - Zoom :Right Mouse\n   - Zoom Scale:Scroll Mouse\n   - Keep Breath :Hold Left Shift\n   - Switch Guns :Q \n   - Change Bullet Action :F \n     "+presetname);

		//GUI.Box (Rect (Screen.width-200, 90, 150, 30), "Score: " + score);

		if(Input.GetKeyDown(KeyCode.Escape)){
			//Application.LoadLevel(0);
		}

		AS_ActionCamera actioncam = (AS_ActionCamera)GameObject.FindObjectOfType(typeof(AS_ActionCamera));
		if(Input.GetKeyDown(KeyCode.F)){
			actioncam.PresetIndex += 1;
			presetname = "Preset "+(actioncam.PresetIndex);
			
			if(actioncam.PresetIndex>=actioncam.ActionPresets.Length){
				actioncam.PresetIndex = -1;	
				presetname = "Random Presets";

			}
		}	
	}
}
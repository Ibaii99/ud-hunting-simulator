using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour {


	// Button
	public Texture2D[] btn_Textures;
	public GUITexture btn_GUITexture;
	public string btn_Name;

	private GunHanddle action;


	// Use this for initialization
	void Start () {

		action=gameObject.GetComponent<GunHanddle>();
	
	}
	
	// Update is called once per frame
	void Update () {



		///////// Button
		if(Input.touchCount>0)
		{
			
			//for(var touch :Touch in Input.touches)
			foreach(Touch touch in Input.touches)
			{
				if(touch.phase ==TouchPhase.Began &&btn_GUITexture.HitTest(touch.position))
				{
					//if(Start_Race.touch)
					//	{
							btn_GUITexture.texture=btn_Textures[1];
					
					//	}
				}
				
				if(touch.phase==TouchPhase.Ended)
				{
					btn_GUITexture.texture=btn_Textures[0];
					
				}
				
				if(btn_GUITexture.HitTest(touch.position))
				{
					//if(Start_Race.touch)
					//		{
					toDo();
					
					//		}
					
				}
				
			}
			
			
		}
	
	}





	void toDo()
	{
		
		switch(btn_Name)
		{
		case "Fire":
					action.SendMessage("Shoot");	
					break;
		case "Zoom":
					action.SendMessage("Zoom");
					break;
		}
	}


}

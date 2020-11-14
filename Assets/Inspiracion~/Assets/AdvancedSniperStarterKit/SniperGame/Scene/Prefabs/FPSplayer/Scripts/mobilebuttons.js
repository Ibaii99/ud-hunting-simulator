#pragma strict

public var forMobile : boolean = false;

	//used for mobile to detect which button was touched
	public var focus : GUITexture;
	public var shoot : GUITexture;
	
	//public var pauseTexture : GUITexture;
	//public var pauseObject  : GameObject;
	
function Start () {
Input.multiTouchEnabled = true;
		//reset static variables
		//crash = false;
		//crashed = false;
		//isControllable = true;
	}
GUI.Box (Rect (10,10,100,90), "Loader Menu");

function Update () {
			if(forMobile)
			{
				var touches = Input.touches;			
}
}
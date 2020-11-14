using UnityEngine;
using System.Collections;
public class PlayerHealth : MonoBehaviour {
	public float originalWidth = 1024.0f;
	public float originalHeight = 768.0f;
	public Vector3 scale;
	public Texture healthbg;
	public Texture healthtexture;
	private float healthbarsize = 0;
	public static float playerhealth = 100;
	void Start () {
		playerhealth = 100;
	}
	void Update()
	{
		if(playerhealth <=0)
		{
			GUI_Controller.missionsuccess = false;
			GUI_Controller.missionfailed = true;
		}
	}
	void OnGUI()
	{
		scale.x = Screen.width/originalWidth; // calculate hor scale
		scale.y = Screen.height/originalHeight; // calculate vert scale
		scale.z = 1.0f;
		var svMat= GUI.matrix; 
		GUI.matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity,scale);		
		if(!GUI_Controller.gameover)
		{
			if(playerhealth > 0)
			{
				healthbarsize = playerhealth * 2.86f;
			}
			else
			{
				healthbarsize = 0;
			}
//			GUI.DrawTexture (new Rect (10, 80, 286, 61), healthbg);
//			GUI.DrawTexture (new Rect (10, 80, healthbarsize,61), healthtexture);
		}		
		GUI.matrix = svMat;
	}
}
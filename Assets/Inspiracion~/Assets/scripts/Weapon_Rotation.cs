using UnityEngine;
using System.Collections;

public class Weapon_Rotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	//	transform.Rotate(Vector3.right * (20 * Time.deltaTime));
		transform.Rotate(Vector3.up * (100 * Time.deltaTime), Space.World);
	}
}
